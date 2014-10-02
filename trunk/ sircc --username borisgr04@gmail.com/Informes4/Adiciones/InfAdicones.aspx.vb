Imports System.Data
Imports System.IO
Imports System.Web.Services
Imports System.Web.Script.Services
Imports Microsoft.Reporting.WebForms
Partial Class Informes4_Adiciones_InfAdicones
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


End Class
