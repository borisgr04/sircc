
Partial Class Reportes_PanelProcesos_PanelReporteE
    Inherits System.Web.UI.Page

    Protected Sub BtnActualizar_Click(sender As Object, e As System.EventArgs) Handles BtnActualizar.Click
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TxtEnc.Text = Usuarios.UserName
        End If

    End Sub
End Class
