
Partial Class Consultas_SolicitudesCord_SolicitudesCord
    Inherits PaginaComun

    Protected Sub FiltroSolP1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroSolP1.FiltrarClicked
        ValFiltro.Value = FiltroSolP1.Filtro
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
