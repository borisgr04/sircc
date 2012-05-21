Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Public Class PolizasContratos
    Inherits BDDatos
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        querystring = "SELECT * FROM PolizasContratos  Where Num_Proc=:Num_Proc and Grupo=:Grupo"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Num_Proc", Num_Proc)
        AsignarParametroCadena(":Grupo", Grupo)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
End Class
