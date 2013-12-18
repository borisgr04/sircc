
Partial Class Consultas_ContratosSGR_ProyectosF18
    Inherits PaginaComun

    Protected Sub GridView1_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub BtnExport_Click(sender As Object, e As System.EventArgs) Handles BtnExport.Click
        ExportGridView(GridView1, "Export_F18")
    End Sub

    Protected Sub BtnBuscar_Click(sender As Object, e As System.EventArgs) Handles BtnBuscar.Click
        Dim p As New Proyectos()
        GridView1.DataSource = p.GetProyectosF18(CmbVig.SelectedValue)
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging

    End Sub
End Class
