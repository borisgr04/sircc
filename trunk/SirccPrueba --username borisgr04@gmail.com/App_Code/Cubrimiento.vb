Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Cubrimiento
    Inherits BDDatos
    Sub New()
        Me.Tabla = "Cubrimiento"
        Me.Vista = "Cubrimiento"
        Me.VistaDB = "Cubrimiento"
    End Sub

    ''' <summary>
    ''' Consulta de estados de actividad
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
End Class
