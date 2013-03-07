Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class TipPlantillas
    Inherits BDDatos
    Sub New()
        Me.Tabla = "TIPPLANTILLAS"
        Me.Vista = "TIPPLANTILLAS"
    End Sub

    ''' <summary>
    ''' Retorna los todos los registros de la tabla de la Base de datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista + " Order by id_tippla"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
End Class
