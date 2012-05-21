Imports System.Data
Partial Class Consultas_HrevSolEnc
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Response.Cache.SetAllowResponseInBrowserHistory(False)
        Response.Cache.SetNoStore()
        If Not Page.IsPostBack Then
            Me.TxtCodSol.Text = ""
            Me.ValFiltro.Value = Me.TxtCodSol.Text
        End If
    End Sub

    Protected Sub TxtCodSol_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodSol.TextChanged
        Dim obj As New PSolicitudes
        Dim dt As DataTable = obj.GetByPkAbog(UCase(TxtCodSol.Text))
        If dt.Rows.Count > 0 Then
            Me.ValFiltro.Value = UCase(TxtCodSol.Text)
            ReportViewer1.LocalReport.Refresh()
            MsgResult.Text = ""
            MsgResult.CssClass = ""
        Else
            Me.ValFiltro.Value = ""
            ReportViewer1.LocalReport.Refresh()
            Me.MsgResult.Text = "La SOLICITUD " & UCase(TxtCodSol.Text) & " no se encuentra o no está asignada a usted"
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Me.ModalPopupSolicitudes.Show()
    End Sub

    Protected Sub ConPSolicitudes1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPSolicitudes1.SelClicked
        Me.TxtCodSol.Text = Me.ConPSolicitudes1.Cod_Sol
        UpdatePanel1.Update()
        TxtCodSol_TextChanged(Nothing, Nothing)
        Me.ModalPopupSolicitudes.Hide()
        'Me.ReportViewer1.LocalReport.Refresh()
    End Sub
End Class
