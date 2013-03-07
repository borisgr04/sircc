Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class TipUsu
    Inherits BDDatos


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM TIPousua"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function



End Class