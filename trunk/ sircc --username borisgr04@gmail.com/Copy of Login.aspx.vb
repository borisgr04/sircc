
Partial Class Login
    Inherits PaginaComun
    Dim Vig As New Vigencias

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Page.SetFocus(TxtUsername)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not IsPostBack Then
            'Context.Request.Browser.Adapters.Clear()
            'Me.CmbVigencia.SelectedValue = Vig.GetActiva()
        End If


    End Sub

    Protected Sub cmdEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        'System.Threading.Thread.Sleep(10000)
        'If Me.TxtUsername.Text = "ADMIN" And Me.TxtClave.Text = "1234567890@" Then
        Dim u As String = Me.TxtUsername.Text.Trim
        Dim c As String = Me.TxtClave.Text.Trim

        'If Membership.ValidateUser(u, c) = True Then
        If Usuarios.Validar_Usuarios(u, c) Then
            Me.msgResult.Text = "Acceso Permitido :" + Now.ToLongTimeString
            Me.msgResult.ForeColor = Drawing.Color.Green
            'Me.MsgModalPanel.Text = "Acceso Permitido :" + Now.ToLongTimeString
            'Me.MsgModalPanel.ForeColor = Drawing.Color.Black
            'Me.ImgRst.ImageUrl = "~/images/Ok.gif"
            'Me.ModalPopup.Show()
            'Almacenar Vigencia Seleccionada

            Dim aCookie As New HttpCookie(Publico.Cookie)
            aCookie.Values("Vigencia") = UCase(Me.CmbVigencia.SelectedValue)
            aCookie.Values("Modulo") = UCase(Me.CboMod.SelectedValue)
            aCookie.Values("NModulo") = UCase(Me.CboMod.SelectedItem.Text)
            Response.Cookies.Add(aCookie)
            'Profile.Modulo = 
            FormsAuthentication.RedirectFromLoginPage(Me.TxtUsername.Text, False)
        Else
            'Me.MsgModalPanel.Text = "Acceso Denegado : Usuario o Contreña Inválidas"
            'Me.MsgModalPanel.ForeColor = Drawing.Color.Black
            'Me.MsgModalPanel.Font.Bold = False
            'Me.ImgRst.ImageUrl = "~/images/Error.gif"
            'Me.ModalPopup.Show()
            Me.msgResult.Text = "Acceso Denegado : Usuario o Contreña Inválidas"
            Me.msgResult.ForeColor = Drawing.Color.Red
        End If



    End Sub

End Class
