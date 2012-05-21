Imports System.Data
Imports System.Math

Partial Class Reportes_PCronogramasG_Default
    Inherits PaginaComun



    Protected Sub DetPContrato1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetPContrato1.AceptarClicked
       
       

    End Sub
    Protected Sub DetPContrato1_BuscarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetPContrato1.BuscarClicked
        'CalenProgl1.Num_Proc = Me.DetPContrato1.CodigoPContrato
        'CalenProgl1.Est_Crono = Me.DetPContrato1.Est_Crono
        'CalenProgl1.DataBind()
        Me.ModalPopupConP.Show()
    End Sub

    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        Me.DetPContrato1.CodigoPContrato = ConPContratos1.Num_Proc
        Me.ReportViewer1.LocalReport.DisplayName = ConPContratos1.Num_Proc
        Me.ReportViewer1.LocalReport.Refresh()
        Me.ModalPopupConP.Hide()



    End Sub

End Class
