
Partial Class Consultas_Formato20
    Inherits PaginaComun

    Protected Sub FiltroPConP1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroCon1.FiltrarClicked
        'ValFiltro.Value = FiltroCon1.Filtro
        Response.Redirect("~/Consultas/Contraloria/Formato20/Rpt.aspx?sql=" + FiltroCon1.Filtro)

    End Sub
End Class
