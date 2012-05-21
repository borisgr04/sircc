
Partial Class Consultas_Pcontratos_PContratosDepN
    Inherits PaginaComun

    Protected Sub FiltroPConPN1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroPConN1.FiltrarClicked
        ValFiltro.Value = FiltroPConN1.Filtro
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
