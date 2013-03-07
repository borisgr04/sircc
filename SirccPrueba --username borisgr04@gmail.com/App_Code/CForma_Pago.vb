Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Public Class CForma_Pago
    Inherits BDDatos
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VCFORMA_PAGO Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
