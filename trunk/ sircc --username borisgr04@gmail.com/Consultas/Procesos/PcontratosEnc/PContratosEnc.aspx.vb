﻿
Partial Class Consultas_Pcontratos_PContratosEnc
    Inherits PaginaComun

    Protected Sub FiltroPConP1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroPConE1.FiltrarClicked
        ValFiltro.Value = FiltroPConE1.Filtro
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
