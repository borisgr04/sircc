Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Tipo_Pagos
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "Tipo_Pago"
        Me.Vista = "Tipo_Pago"
        Me.VistaDB = "Tipo_Pago"

    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista
        'Me.Desconectar()
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
End Class
