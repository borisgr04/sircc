Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Prev_cdp
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "Prev_cdp"
        Me.Vista = "Prev_cdp"
        
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
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
      Public Function Insert(ByVal Vigencia As String, ByVal Num_Previo As String, ByVal VIGENCIA_CDP As String, ByVal NUM_CERTIFICADO As String, ByVal FEC_EXPEDICION As Date, ByVal VALOR_TOTAL As Decimal) As DataTable
        Dim queryString As String = "INSERT INTO PREV_CDP(Vigencia, Num_Previo, VIGENCIA_CDP, NUM_CERTIFICADO, FEC_EXPEDICION, VALOR_TOTAL)VALUES(:Vigencia, :Num_Previo, :VIGENCIA_CDP, :NUM_CERTIFICADO, :FEC_EXPEDICION, :VALOR_TOTAL)"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    
End Class



