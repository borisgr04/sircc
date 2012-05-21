
Partial Class Reportes_ParametrizadoR_ReportI
    Inherits PaginaComun
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'report()

        Dim Sql As String = Request.QueryString("Sql")
        If Membership.GetUser.UserName.ToUpper = "ADMIN" Then
            Me.TxtSql.Visible = True
        Else
            Me.TxtSql.Visible = False
        End If
        Me.TxtSql.Text = Sql
    End Sub

    'Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    'ObjRptContratos.DataBind()
    '    ReportViewer1.LocalReport.Refresh()
    'End Sub
End Class
