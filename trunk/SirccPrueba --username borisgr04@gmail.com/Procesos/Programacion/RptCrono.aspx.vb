
Partial Class Procesos_Programacion_RptCrono
    Inherits PaginaComun


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.HdNum_Proc.Value = Request("Num_Proc")
        Me.ReportViewer1.LocalReport.DisplayName = Me.HdNum_Proc.Value
        Me.ReportViewer1.LocalReport.Refresh()
        Me.UpdPCon.Update()

    End Sub
End Class
