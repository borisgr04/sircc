Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Public Class Con_DocContratos
    Inherits BDDatos
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDocFec() As DataTable
        querystring = "select to_char(fec_reg,'dd-mm-yyyy') fecha, count(*) Documentos from doc_contratos group by to_char(fec_reg,'dd-mm-yyyy') order by count(*)"
        Me.Conectar()
        Me.CrearComando(querystring)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDocCon() As DataTable
        querystring = "select cod_con Contrato, count(*) DocumentosAdjuntos from DOC_CONTRATOS group by cod_con order by cod_con"
        Me.Conectar()
        Me.CrearComando(querystring)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetConContratista() As DataTable
        querystring = "SELECT * FROM VCON_CONTRATISTA"
        Me.Conectar()
        Me.CrearComando(querystring)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
End Class
