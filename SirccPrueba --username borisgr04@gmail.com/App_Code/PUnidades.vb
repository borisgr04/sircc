Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class PUnidades
    Inherits BDDatos
    Sub New()
        Me.Tabla = "PUnidades"
        Me.Vista = "PUnidades"
        Me.VistaDB = "PUnidades"
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
