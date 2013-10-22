
Partial Class Reportes_PorProyectos_PorProyectos
    Inherits System.Web.UI.Page

    Protected Sub BtnBuscar_Click(sender As Object, e As System.EventArgs) Handles BtnBuscar.Click
        Dim strsql As String
        Dim obj As New Contratos()
        Dim cFiltro As String = ""

        Util.AddFiltro(cFiltro, "pro_con='" + TxtBuscar.Text + "'")

        If cFiltro <> String.Empty Then
            cFiltro = "Where " + cFiltro
        End If
        strsql = "SELECT c.* FROM vcontratos_Sinc_p c  " + cFiltro + " ORDER BY numero"
        'Response.Write(strsql)
        'Response.End()
        Response.Redirect("ReportP.aspx?sql=" + Server.UrlEncode(strsql) & "&tit=" + Server.UrlEncode("") & "&Rpte=" + Server.UrlEncode("Pro_Con"))
    End Sub
End Class
