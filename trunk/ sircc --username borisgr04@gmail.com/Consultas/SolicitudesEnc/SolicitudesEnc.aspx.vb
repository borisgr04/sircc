
Partial Class Consultas_SolicitudesEnc_SolicitudesEnc
    Inherits PaginaComun

    Protected Sub FiltroSolE1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroSolE1.FiltrarClicked
        ValFiltro.Value = FiltroSolE1.Filtro
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
