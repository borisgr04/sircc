Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Public Class TipProponente
    Inherits BDDatos
    Sub New()
        Me.Tabla = "TIPPROPONENTE"
        Me.Vista = "TIPPROPONENTE"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Vista
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
