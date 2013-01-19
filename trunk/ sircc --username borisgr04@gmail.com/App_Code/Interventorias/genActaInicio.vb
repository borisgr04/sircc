Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class genActaInicio
    Inherits genDocActas

    Function GenActa(ByVal Cod_Con As String, ByVal Ide_Pla As String, ByVal Ide_Acta As String) As String
        'Try
        'En listanomtabla va el nombre de las tablas que se llena en pplantillas_campos
        Dim ide_con As String = Cod_Con
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
        dtPlantilla = oPlantilla.GetPorIde(Ide_Pla)
        'Se obtiene la plantila
        'Generar el Documento Word
        If dtConsulta.Rows.Count > 0 Then
            'Se conecta a la base de datos
            lErrorG = False
            Conectar()
            ComenzarTransaccion()

            'Llenar los datos a Imprimir
            dtDatos = GetDatosPpales(Cod_Con) ' Datos del Acta

            'GetFecAprPol()
            Dim dtTabla As DataTable = GetRp(Cod_Con)            '= '**GetCertificadoL() ' LISTA DEL CONTRATO
            If dtTabla.Rows.Count > 0 Then
                ListaTablas.Add(dtTabla)
                ListaNomTablas.Add("VRP")
            End If
            Dim dtTablaCdp As DataTable = GetCdp(Cod_Con)            '= '**GetCertificadoL() ' LISTA DEL CONTRATO
            If dtTablaCdp.Rows.Count > 0 Then
                ListaTablas.Add(dtTablaCdp)
                ListaNomTablas.Add("VCDP")
            End If
            Dim dtTablaRubros As DataTable = GetRubros(Cod_Con)            '= '**GetCertificadoL() ' LISTA DEL CONTRATO
            If dtTablaRubros.Rows.Count > 0 Then
                ListaTablas.Add(dtTablaRubros)
                ListaNomTablas.Add("VRUBROS")
            End If

            Dim dtTablaPolizas As DataTable = GetPolizas(Cod_Con)        '= '**GetCertificadoL() ' LISTA DEL CONTRATO
            If dtTablaPolizas.Rows.Count > 0 Then
                ListaTablas.Add(dtTablaPolizas)
                ListaNomTablas.Add("VPOLIZAS")
            End If
            Dim Documento As Byte()
            Dim DocumentoPDF As Byte()
            Dim oWord As New GDocWordActas

            Me.Doc_BAS = DirectCast(dtPlantilla.Rows(0)("PLANTILLA"), Byte())

            If Not IsNothing(Me.Doc_BAS) Then
                If dtPlantilla.Rows(0)("EDITABLE").ToString = "1" Then
                    oWord.DocProtegido = True
                Else
                    oWord.DocProtegido = False
                End If
                oWord.DocProtegido = True
                oWord.ClavePlantilla = Publico.Clave_Minuta
                oWord.IdPlantilla = Ide_Pla
                oWord.ListaNomTablas = ListaNomTablas
                oWord.ListaTablas = ListaTablas
                Documento = oWord.GenerarDocumento(Me.Doc_BAS, dtConsulta, dtDatos)
                DocumentoPDF = oWord.Documento_Pdf
                lErrorG = oWord.lErrorG
                Msg = oWord.Msg
                If Not oWord.lErrorG Then
                    If Not IsNothing(Documento) Then
                        Doc_Doc = oWord.Documento_Word
                        Doc_PDF = oWord.Documento_Pdf
                        InsDocumento()
                        ConfirmarTransaccion()
                        Msg = "Se Generó el Documento "
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
        '    CancelarTransaccion()
        '    Msg = ex.Message
        '    lErrorG = True
        'End Try

        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Private Overloads Function GetDatosPpales(ByVal Cod_Con As String) As DataTable
        querystring = "SELECT * FROM vactaInicio Where Cod_Con = :id "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":id", Cod_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDatosPpalesP(ByVal Cod_Con As String) As DataTable
        Conectar()
        Dim dataTb As DataTable = GetDatosPpales(Cod_Con)
        Desconectar()
        Return dataTb
    End Function
    
End Class
