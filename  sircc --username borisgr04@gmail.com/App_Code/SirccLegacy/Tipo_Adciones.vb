Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel


Public Class Tipo_Adciones
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "Tipo_Adciones"
        Me.Vista = "Tipo_Adciones"

    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista

        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function



End Class



