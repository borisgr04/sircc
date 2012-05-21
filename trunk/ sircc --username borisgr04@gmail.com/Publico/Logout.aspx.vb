Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System.Data
Partial Class Publico_Logout
    Inherits PaginaComun
    Dim objt As Terceros = New Terceros
    Dim dt As DataTable
    Dim msg As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Tit.Text = AppAlias
        Me.Title = Me.Tit.Text
        FormsAuthentication.SignOut()
        Context.User = Nothing
        Session.Abandon()
        Session.Clear()
    End Sub

End Class
