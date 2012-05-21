Partial Class Publico_mail
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Text = Mail.EnviarAuto("Prueba de envio Mensaje" + Now.ToLongTimeString, "Hola... envio de correo")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label2.Text = Mail.Enviar("informatica@gobcesar.gov.co", Me.TextBox1.Text, "Prueba de envio", "Preuba")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label3.Text = Util.FormatCVS(TextBox2.Text)

    End Sub



    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Dim x As ddd
    End Sub
End Class
