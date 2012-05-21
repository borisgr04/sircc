
Partial Class Admin_Email_TestEmail
    Inherits PaginaComun

    Protected Sub BtnEnviarMail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEnviarMail.Click
        Dim nr As New NotificacionesEmail
        MsgResult.Text = nr.Notificar_TestMail(Me.CboDep.SelectedValue)
        MsgBox(MsgResult, nr.lErrorG)
    End Sub

    Protected Sub BtnEnvioAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMailEsp.Click
        MsgResult.Text = NotEmail.EnviarNot(TextBox1.Text, "Prueba de Notificacion" + Now.ToLongTimeString, "Prueba de envio desde SIRCC", New Byte())
        MsgBox(MsgResult, NotEmail.lerrorG)
    End Sub
End Class
