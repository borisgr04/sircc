Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class TTerc
    Inherits BDDatos


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vTIPO_AGENT order by tag_cod"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function



End Class