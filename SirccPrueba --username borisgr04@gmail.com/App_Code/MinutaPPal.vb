Imports Microsoft.VisualBasic
Imports System.Data
Public Class MinutaPPal
    Inherits BDDatos
    Public Function GetMinuta(ByRef Minuta As Byte()) As Boolean
        Me.Conectar()
        querystring = "SELECT * FROM PLANTILLAPPAL"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        If dataTb.Rows.Count > 0 Then
            Minuta = DirectCast(dataTb.Rows(0)("Plantilla"), Byte())
            Me.Desconectar()
            Return True
        Else
            Me.Desconectar()
            Return False
        End If
    End Function
End Class
