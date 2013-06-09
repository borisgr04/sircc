Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class EstadosC
    Inherits BDDatos

    Sub New()
        Me.Vista = "vestados"
    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsD() As DataTable
        Dim queryString As String = "SELECT Distinct Upper(Estado) Estado FROM  Vestados Order by Estado"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
End Class
