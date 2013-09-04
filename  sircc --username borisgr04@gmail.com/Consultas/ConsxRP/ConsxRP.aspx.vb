Imports System.Data

Partial Class Consultas_ConsxRP_ConsxRP
    Inherits System.Web.UI.Page
    Private obj As New CtrConsxRP

    Private Function GetRecords() As DataTable
        Dim dt As DataTable = New DataTable
        dt = obj.GetxNroRp(TxtNroRp.Text)
        Return dt
    End Function

    Protected Sub BtnCons_Click(sender As Object, e As System.EventArgs) Handles BtnCons.Click
        grd.DataSource = GetRecords()
        grd.DataBind()
    End Sub
End Class
