
Partial Class Publico_i
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim u As String = Request("usrsircc")
        Dim c As String = Request("pwdsircc")

        If Usuarios.Validar_Usuarios(u, c) Then
            Dim aCookie As New HttpCookie(Publico.Cookie)
            aCookie.Values("Vigencia") = UCase("2012")
            aCookie.Values("Modulo") = UCase("PREC")
            aCookie.Values("NModulo") = UCase("")
            Response.Cookies.Add(aCookie)
            'Profile.Modulo = 
            FormsAuthentication.RedirectFromLoginPage(u, False)


        End If
    End Sub
End Class
