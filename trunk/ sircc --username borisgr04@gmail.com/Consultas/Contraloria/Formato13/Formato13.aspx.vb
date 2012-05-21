
Partial Class Consultas_F13
    Inherits PaginaComun

    Protected Sub FiltroPConP1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroCon1.FiltrarClicked
        'ValFiltro.Value = FiltroCon1.Filtro
        Label1.Text = FiltroCon1.Filtro
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class
