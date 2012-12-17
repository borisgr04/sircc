Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class genPlanAnticipos
    Inherits BDDatos

    Dim mDoc_DOC As Byte()
    Dim mDoc_PDF As Byte()

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

    Function GenActa(ByVal Id_Acta As String) As String
        'Try
        'En listanomtabla va el nombre de las tablas que se llena en pplantillas_campos
        Dim ide_con As String = Id_Acta
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
        dtConsulta = oPlantillaC.GetRecords("VACTAS") ' Configuracion de la Plantillas
        'Throw New Exception(dtConsulta.Rows.Count)
        dtPlantilla = oPlantilla.GetPorIde("33")
        'Se obtiene la plantila
        'Generar el Documento Word
        If dtConsulta.Rows.Count > 0 Then
            'Se conecta a la base de datos
            lErrorG = False
            Conectar()
            ComenzarTransaccion()
            ''DATOS DEL CERTIFICADO
            'Crea el Registro del Certificado 
            '***Insert()
            'Llenar los datos a Imprimir
            dtDatos = GetDatosPpales() ' Datos del Acta
            Dim dtTabla As DataTable = GetRp()            '= '**GetCertificadoL() ' LISTA DEL CONTRATO
            If dtTabla.Rows.Count > 0 Then
                ListaTablas.Add(dtTabla)
                ListaNomTablas.Add("VRP")
            End If
            Dim dtTablaCdp As DataTable = GetCdp()            '= '**GetCertificadoL() ' LISTA DEL CONTRATO
            If dtTablaCdp.Rows.Count > 0 Then
                ListaTablas.Add(dtTablaCdp)
                ListaNomTablas.Add("VCDP")
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
                        'EnviarDocS()
                        ConfirmarTransaccion()
                        'Msg = "Se Generó el Certificado N°" + Me.Nro_Cert.ToString
                        lErrorG = False
                    End If
                End If
            Else
                Msg = "La plantilla no esta definida. Por favor verifique"
                lErrorG = True
            End If
            Desconectar()
        End If
        'Catch ex As Exception
        'CancelarTransaccion()
        'Msg = ex.Message
        'lErrorG = True
        'End Try

        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDatosPpales() As DataTable
        querystring = "Select * FROM vActasPlanAnticipo Where Cod_Con = :id and Estado='AC' and Est_Fin='01'"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":id", "2012020001")
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRp() As DataTable
        querystring = "Select NRO_Rp Numero,To_Char(Val_Rp,'999,999,999') Valor, To_Char(Fec_Rp,'dd/mm/yyyy') Fecha FROM Rp_Contratos Where Cod_Con = :id "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":id", "2012020001")
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCdp() As DataTable
        querystring = "Select NRO_Cdp Numero,To_Char(Val_Cdp,'999,999,999') Valor, To_Char(Fec_Cdp,'dd/mm/yyyy') Fecha FROM Cdp_Contratos Where Cod_Con = :id "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":id", "2012020001")
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function
End Class
