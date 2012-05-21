Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Tipo_Plazos
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "Tipo_Plazos"
        Me.Vista = "vTipo_Plazos"
        Me.VistaDB = "vTipo_PlazosDB"

    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        querystring = "SELECT * FROM  " + Vista
        'Me.Desconectar()
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

 <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByTipo1(ByVal tipo As String) As DataTable
        querystring = "select * from vtipo_plazos where ord_tpla<(select tp.ord_tpla from tipo_plazos tp where tp.COD_TPLA=:Ord_TPla) Order by ord_tpla desc"
        'Me.Desconectar()
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Ord_TPla", tipo)
        'Throw New Exception(vComando.CommandText)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
End Class
