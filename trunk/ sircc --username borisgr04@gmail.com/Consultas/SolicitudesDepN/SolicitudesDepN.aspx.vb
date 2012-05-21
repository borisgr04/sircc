
Partial Class Consultas_SolicitudesCord_SolicitudesDepN
    Inherits PaginaComun

    Protected Sub FiltroSolN1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroSolN1.FiltrarClicked
        ValFiltro.Value = FiltroSolN1.Filtro
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
