Imports System.Data
Partial Class Consultas_HrevSol
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub TxtCodSol_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodSol.TextChanged
        Dim obj As New PSolicitudes
        Dim dt As DataTable = obj.GetByPk(UCase(Me.TxtCodSol.Text))
        If dt.Rows.Count > 0 Then
            ReportViewer1.LocalReport.Refresh()
        Else

        End If

    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Me.ModalPopupSolicitudes.Show()
    End Sub

    'Protected Sub ConPSolicitudesPK1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPSolicitudesPK1.SelClicked
    '    Me.TxtCodSol.Text = ConPSolicitudesPK1.Cod_Sol
    '    Me.ReportViewer1.LocalReport.Refresh()
    '    Me.ModalPopupSolicitudes.Hide()
    'End Sub
End Class
