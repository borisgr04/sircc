Imports System.Data
Imports System.IO
Imports System.Web.Services
Imports System.Web.Script.Services
Imports Microsoft.Reporting.WebForms

Partial Class Informes4_SIAF20_SiaF20
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub



    Protected Sub BtnGenRpt_Click(sender As Object, e As System.EventArgs) Handles BtnGenRpt.Click
        ObjF20_1a.SelectMethod = "getF20_1a"
        ReportViewer1.LocalReport.ReportPath = "Informes4\SIAF20\RptF20_1a.rdlc"
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub BtnF20_1B_Click(sender As Object, e As System.EventArgs) Handles BtnF20_1B.Click
        ObjF20_1a.SelectMethod = "getF20_1b"
        ReportViewer1.LocalReport.ReportPath = "Informes4\SIAF20\RptF20_1b.rdlc"
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub BtnF20_1C_Click(sender As Object, e As System.EventArgs) Handles BtnF20_1C.Click
        ObjF20_1a.SelectMethod = "getF20_1c"
        ReportViewer1.LocalReport.ReportPath = "Informes4\SIAF20\RptF20_1c.rdlc"
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class
