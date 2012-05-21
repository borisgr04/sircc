
Partial Class Consultas_Pcontratos_PContratosCord
    Inherits PaginaComun

    Protected Sub FiltroPConP1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroPConP1.FiltrarClicked
        ValFiltro.Value = FiltroPConP1.Filtro
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
