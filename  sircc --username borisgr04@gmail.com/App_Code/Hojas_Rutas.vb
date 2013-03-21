Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Hojas_Rutas
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetEtapas() As DataTable
        Dim queryString As String = "SELECT * FROM  Etapas Where Proceso='SI'"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolPro(Codigo As String, Tipo As String) As DataTable
        If Tipo.ToUpper = "S" Then
            querystring = "SELECT * FROM  vPSolicitudes Where Cod_Sol=:Codigo"
        Else
            querystring = "SELECT * FROM  PContratos Where Pro_Sel_Nro=:Codigo"
        End If
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Codigo", Codigo)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(Cod_Sol As String, Tip As String, Eta As String, FEtapa As Boolean) As DataTable
        querystring = " Select nom_eta, des_tip AS nom_doc,  cod_eta, td.cod_tip, est_tip, cod_eta,Doc_Oblig,  Nvl(cod_Sol,0) cod_Sol,Fec_Doc,Ide_Doc, Folios From vTip_Doc td LEFT JOIN HRSolPro hrs On td.Cod_Tip=hrs.cod_tip And hrs.Cod_Sol='" + Cod_Sol + "' Where  Proceso = 'SI' "
        Dim Filtro As String = ""
        If Tip = "SIN" Then
            querystring += " And hrs.Cod_Sol Is Null "
        Else
            querystring += " And hrs.Cod_Sol Is Not Null And hrs.Cod_Sol='" + Cod_Sol + "'"
        End If
        If FEtapa Then
            querystring += " And td.cod_eta = '" + Eta + "' "
        End If

        querystring += " Order by td.Cod_Eta, Fec_Doc"


        Me.Conectar()
        Me.CrearComando(querystring)
        'Throw New Exception(querystring)
        'Me.AsignarParametroCadena(":Cod_HRuta", Cod_HRuta)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function


End Class
