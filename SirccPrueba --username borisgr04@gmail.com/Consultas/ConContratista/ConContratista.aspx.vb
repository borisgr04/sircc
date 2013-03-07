Imports Telerik.Web.UI

Partial Class Consultas_ConContratista
    Inherits PaginaComun
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub Header1_SkinChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.SkinChangedEventArgs)
        'Required for dynamic skin changing
        RadGrid4.Rebind()
    End Sub

    Protected Sub RadToolBar1_ButtonClick(ByVal source As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs)

    End Sub

    Protected Function GetFilterIcon() As String
        Return RadAjaxLoadingPanel.GetWebResourceUrl(Page, String.Format("Telerik.Web.UI.Skins.{0}.Grid.Filter.gif"))
    End Function

    Protected Sub RadButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        RadFilter1.FireApplyCommand()
    End Sub
End Class
