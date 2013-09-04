Imports System.Data
Imports System.IO
Imports System.Web.Services
Imports System.Web.Script.Services
Imports Microsoft.Reporting.WebForms

Partial Class Informes4_SIAF20_SiaF20
    Inherits PaginaComun


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Now.Month = "03" Then
                TxtFecIni.Text = "01/01/" + Vigencia_Cookie
                TxtFecFin.Text = "01/02/" + Vigencia_Cookie
            End If
            If Now.Month = "05" Then
                TxtFecIni.Text = "01/03/" + Vigencia_Cookie
                TxtFecFin.Text = "01/04/" + Vigencia_Cookie
            End If
            If Now.Month = "07" Then
                TxtFecIni.Text = "01/05/" + Vigencia_Cookie
                TxtFecFin.Text = "01/06/" + Vigencia_Cookie
            End If
            If Now.Month = "09" Then
                TxtFecIni.Text = "01/07/" + Vigencia_Cookie
                TxtFecFin.Text = "01/08/" + Vigencia_Cookie
            End If
            If Now.Month = "11" Then
                TxtFecIni.Text = "01/09/" + Vigencia_Cookie
                TxtFecFin.Text = "01/10/" + Vigencia_Cookie
            End If
            If Now.Month = "01" Then
                TxtFecIni.Text = "01/11/" + Vigencia_Cookie
                TxtFecFin.Text = "01/12/" + Vigencia_Cookie
            End If
            
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
