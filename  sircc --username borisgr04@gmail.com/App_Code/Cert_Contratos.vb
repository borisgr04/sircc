Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common

Public Class Cert_Contratos
    Inherits BDDatos
    Dim mVig_Cert As String
    Dim mNro_Cert As Integer
    Dim mFec_Cert As Date
    Dim mDoc_DOC As Byte()
    Dim mDoc_PDF As Byte()
    Dim mLst_Cont As String
    Dim mNro_Imp As Integer
    Dim mEstado As String
    Dim mide_Con As String


    Public Property Ide_Con As String
        Get
            Return mide_Con
        End Get
        Set(ByVal value As String)
            mide_Con = value
        End Set
    End Property

    Public Property Nro_Cert As Integer
        Get
            Return mNro_Cert
        End Get
        Set(ByVal value As Integer)
            mNro_Cert = value
        End Set
    End Property

    Public Property Fec_Cert As Date
        Get
            Return mFec_Cert
        End Get
        Set(ByVal value As Date)
            mFec_Cert = value
        End Set
    End Property

    Public Property Vig_Cert As Integer
        Get
            Return mVig_Cert
        End Get
        Set(ByVal value As Integer)
            mVig_Cert = value
        End Set
    End Property

    Public Property Doc_Doc As Byte()
        Get
            Return mDoc_DOC
        End Get
        Set(ByVal value As Byte())
            mDoc_DOC = value
        End Set
    End Property

    Public Property Doc_PDF As Byte()
        Get
            Return mDoc_PDF
        End Get
        Set(ByVal value As Byte())
            mDoc_PDF = value
        End Set
    End Property

    Public Property Lst_Cont As String
        Get
            Return mLst_Cont
        End Get
        Set(ByVal value As String)
            mLst_Cont = value
        End Set
    End Property

    Public Property Nro_Imp As Integer
        Get
            Return mNro_Imp
        End Get
        Set(ByVal value As Integer)
            mNro_Imp = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
        End Set
    End Property
    ''' <summary>
    ''' Crea un Registro de un certificado, con vigencia del año actual, nro consecuitivo,  fecha de certificado la actual, 
    ''' Requiere, ide_con y la lista de Contratos 
    ''' </summary>
    ''' <returns> Mensaje de Resultado de la Operación </returns>
    ''' <remarks> </remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Private Function Insert() As String
        querystring = "CERT_INSERTAR"
        Me.CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = Me.AsignarParametroReturn(100)
        Me.AsignarParametroCad(":lst_cont", Lst_Cont)
        Me.AsignarParametroCad(":ide_con", Ide_Con)
        Me.num_reg = Me.EjecutarComando()
        Me.Nro_Cert = preturn.Value.ToString()
        Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
        Return Msg
    End Function
    ''' <summary>
    ''' Enviar Documentos, 
    ''' se requerie el Numero de Certificado y Los binarios en .Doc, y .PDF
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function EnviarDocS() As String
        querystring = "UPDATE Cert_Contratos SET doc_doc=:doc_doc, doc_pdf=:doc_pdf Where Nro_Cert=:Nro_Cert And Vig_cert=To_Char(sysdate,'yyyy')"
        Me.CrearComando(querystring)
        Me.AsignarParametroBLOB(":doc_doc", Doc_Doc)
        Me.AsignarParametroBLOB(":doc_pdf", Doc_PDF)
        Me.AsignarParametroCadena(":Nro_Cert", Nro_Cert)
        Me.num_reg = Me.EjecutarComando()
        Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
        Return Msg
    End Function
    ''' <summary>
    ''' Distinct Solo Registro Certificado por Contratista
    ''' </summary>
    ''' <param name="Ide_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Ide_Con As String) As DataTable
        Me.Conectar()
        querystring = "Select * FROM cert_contratos Where Ide_Con=:Ide_Con Order by Nro_Cert Desc"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Ide_Con", Ide_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Retorna Numero de Certificao
    ''' </summary>
    ''' <param name="Nro_Cert"></param>
    ''' <param name="Vig_Cert"></param>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Cargar(ByVal Nro_Cert As String, ByVal Vig_Cert As String) As Boolean
        Me.Conectar()
        querystring = "Select * FROM cert_contratos Where Nro_Cert=:Nro_Cert And Vig_Cert=:Vig_Cert"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Nro_Cert", Nro_Cert)
        AsignarParametroCadena(":Vig_Cert", Vig_Cert)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Me.Doc_Doc = dataTb.Rows(0)("Doc_Doc")
            Me.Doc_PDF = dataTb.Rows(0)("Doc_PDF")
            Me.Fec_Cert = dataTb.Rows(0)("Fec_Cert")
            Me.Estado = dataTb.Rows(0)("Estado")
            Me.Ide_Con = dataTb.Rows(0)("Ide_Con")
            Me.Lst_Cont = dataTb.Rows(0)("Lst_Cont")
            Return True
        Else
            Return False
        End If
    End Function


    Function GenCertificado() As String
        Try
            'En listanomtabla va el nombre de las tablas que se llena en pplantillas_campos
            Dim ide_con As String = Me.Ide_Con
            Dim dtDatos As New DataTable
            Dim dtPlantilla As New DataTable
            Dim ListaNomTablas As New List(Of String)
            Dim ListaTablas As New List(Of DataTable)
            Dim ListaGrupoNomTabla As New List(Of String)
            Dim ListaGrupoTabla As New List(Of DataTable)
            Dim oPlantilla As New PPlantillas
            Dim oPlantillaC As New PPlantillas_Campos
            Dim dtConsulta As New DataTable
            'Llenar la tabla de configuracion
            dtConsulta = oPlantillaC.GetRecords("VCERTIFICACIONES")
            dtPlantilla = oPlantilla.GetPorIde(Publico.Ide_Cert)
            'Se obtiene la plantila
            'Generar el Documento Word
            If dtConsulta.Rows.Count > 0 Then
                'Se conecta a la base de datos
                lErrorG = False
                Conectar()
                ComenzarTransaccion()
                ''DATOS DEL CERTIFICADO
                'Crea el Registro del Certificado 
                Insert()
                'Llenar los datos a Imprimir
                dtDatos = GetCertificadoD()
                Dim dtTabla As DataTable = GetCertificadoL() ' LISTA DEL CONTRATO
                If dtTabla.Rows.Count > 0 Then
                    ListaTablas.Add(dtTabla)
                    ListaNomTablas.Add("VLSTCONTRATOS")
                End If
                Dim DocPlantilla As Byte()
                Dim Documento As Byte()
                Dim DocumentoPDF As Byte()
                Dim oWord As New GDocWord
                DocPlantilla = DirectCast(dtPlantilla.Rows(0)("PLANTILLA"), Byte())
                If Not IsNothing(DocPlantilla) Then
                    If dtPlantilla.Rows(0)("EDITABLE").ToString = "1" Then
                        oWord.DocProtegido = True
                        oWord.ClavePlantilla = dtPlantilla.Rows(0)("CLAVE").ToString
                    Else
                        oWord.DocProtegido = False
                    End If
                    oWord.IdPlantilla = Publico.Ide_Cert
                    oWord.ListaNomTablas = ListaNomTablas
                    oWord.ListaTablas = ListaTablas
                    Documento = oWord.GenerarDocumento(DocPlantilla, dtConsulta, dtDatos)
                    DocumentoPDF = oWord.Documento_Pdf
                    lErrorG = oWord.lErrorG
                    Msg = oWord.Msg
                    If Not oWord.lErrorG Then
                        If Not IsNothing(Documento) Then
                            Doc_Doc = oWord.Documento_Word
                            Doc_PDF = oWord.Documento_Pdf
                            'Actualiza el Registro
                            EnviarDocS()
                            ConfirmarTransaccion()
                            Msg = "Se Generó el Certificado N°" + Me.Nro_Cert.ToString
                            lErrorG = False
                        End If
                    End If
                Else
                    Msg = "La plantilla no esta definida. Por favor verifique"
                    lErrorG = True
                End If
                Desconectar()
            End If
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            lErrorG = True
        End Try

        Return Msg
    End Function


    ''' <summary>
    ''' Distinct Solo Registro Certificado por Contratista
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCertificadoD() As DataTable
        querystring = "Select Distinct c.Ide_Con, Contratista, nom_tip_ide,EXP_IDE,LPAD(Nro_Cert,5,0) NRO_CERT, Fec_Cert,nomusuario(UsAp) Elaboro FROM vcontratos_sinc_p c,Cert_Contratos Where Nro_Cert=:Nro_Cert And c.Ide_Con=:Ide_Con And Numero In (" + Lst_Cont + ")"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Ide_Con", Ide_Con)
        AsignarParametroCadena(":Nro_Cert", Nro_Cert)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function


    ''' <summary>
    ''' Certificado por Contratista
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCertificadoL() As DataTable
        'And Dep_pCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo )
        querystring = "SELECT * FROM vLstContratos Where Ide_Con=:Ide_Con And Numero In (" + Lst_Cont + ") Order by Numero desc"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Ide_Con", Ide_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function
End Class
