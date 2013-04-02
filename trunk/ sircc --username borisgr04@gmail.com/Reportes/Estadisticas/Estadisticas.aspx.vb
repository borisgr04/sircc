
Partial Class Reportes_Estadisticas_Estadisticas
    Inherits System.Web.UI.Page

    Protected Sub TxtCdp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCdp.TextChanged
        ReportViewer1.LocalReport.Refresh()
        ReportViewer2.LocalReport.Refresh()
        Dim r As New Rpt_Cdp_Dep
        'GridView1.DataSource = r.GetCdp_Dep("2012", TxtCdp.Text)
        'GridView1.DataBind()
        'GridView2.DataSource = r.GetCdp_Dep_Clase("2012", TxtCdp.Text)
        'GridView2.DataBind()
        'Title = Util.FormatCVS(TxtCdp.Text)

    End Sub

End Class
