
Partial Class Reportes_PanelProcesos_PanelReporte
    Inherits System.Web.UI.Page

    Protected Sub BtnActualizar_Click(sender As Object, e As System.EventArgs) Handles BtnActualizar.Click
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CboEnc.Items.Clear()
            CboEnc.Items.Add(New ListItem("Todos..", ""))
            CboEnc.AppendDataBoundItems = True
            CboEnc.DataSourceID = "ObjTerceros"
            CboEnc.DataBind()

        End If

    End Sub
End Class
