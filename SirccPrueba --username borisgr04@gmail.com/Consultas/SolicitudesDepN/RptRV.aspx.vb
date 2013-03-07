Imports System.IO

Partial Class Solicitudes_ReporteRevision_RptRV
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim pdf As New GPdf

        Literal1.Text = pdf.GenerarHTML(Request("Cod_Sol"), Request("Id_Hrev"))

        Dim tw As New StringWriter()
        Dim hw As New HtmlTextWriter(tw)
        Literal1.RenderControl(hw)
        If Request("dest") = "word" Then
            Response.ContentType = "application/msword"
            Me.EnableViewState = False
            Response.Write(tw.ToString())
            Response.End()
        End If
        

    End Sub
End Class
