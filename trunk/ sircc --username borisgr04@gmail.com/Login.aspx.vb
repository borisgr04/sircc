
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub cmdEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        Enviar()
    End Sub

    Sub Enviar()
        Dim u As String = Me.TxtUsername.Text.Trim
        Dim c As String = Me.TxtClave.Text.Trim
        'If Membership.ValidateUser(u, c) = True Then
        If Usuarios.Validar_Usuarios(u, c) Then
            Me.msgResult.Text = "Acceso Permitido :" + Now.ToLongTimeString
            Me.msgResult.ForeColor = Drawing.Color.Green


            Dim aCookie As New HttpCookie(Publico.Cookie)
            aCookie.Values("Vigencia") = UCase(Me.CmbVigencia.SelectedValue)
            aCookie.Values("Modulo") = UCase(Me.CboMod.SelectedValue)
            aCookie.Values("NModulo") = UCase(Me.CboMod.SelectedItem.Text)
            Session("username") = Me.TxtUsername.Text
            Session("vigencia") = UCase(Me.CmbVigencia.SelectedValue)
            Response.Cookies.Add(aCookie)
            'Profile.Modulo = 
            FormsAuthentication.RedirectFromLoginPage(Me.TxtUsername.Text, False)
        Else

            Me.msgResult.Text = "Acceso Denegado : Usuario o Contreña Inválidas"
            Me.msgResult.ForeColor = Drawing.Color.Red
        End If




    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Page.SetFocus(TxtUsername)

    End Sub
End Class
