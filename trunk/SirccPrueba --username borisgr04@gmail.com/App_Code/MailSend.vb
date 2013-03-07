Imports System.Collections
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.ComponentModel

Public Class MailSend
    Shared msg As String
    Public Shared Campo_Email As String
    Public Shared Fila As Integer
    Public Shared Cancelar As Boolean
    Public Shared msgEstado As String

    Public Shared Port As String
    Public Shared Host As String
    Public Shared UserName As String
    Public Shared BCC As String = ""
    Public Shared CC As String = ""
    Public Shared TimeOut As Long = 100000000
    Public Shared Nombre_Mostrar As String = ""
    Public Shared IsBodyHtml As Boolean = True
    Public Shared PassWord As String
    Public Shared EnableSsl As Boolean
    Public Shared Prioridad As MailPriority
    Public Shared sLema As String
    Public Shared Ruta_Logo As String = "logo.jpg"
    Public Shared lErrorG As Boolean
    Public Shared MsgResult As String

    Public Shared Function MailEnviar(ByVal Para As String, ByVal Asunto As String, ByVal Body_Mensaje As String, ByVal Adjuntos() As String) As String

        Dim _mail As New System.Net.Mail.MailMessage()
        _mail.[To].Add(Para)
        '_mail.Bcc.Add(UserName)
        For i As Integer = 0 To Adjuntos.Length - 1
            _mail.Attachments.Add(New Attachment(Adjuntos(i)))
        Next i
        _mail.From = New MailAddress(UserName, Nombre_Mostrar, System.Text.Encoding.UTF8)
        _mail.Subject = Asunto

        If Not String.IsNullOrEmpty(BCC) Then
            _mail.Bcc.Add(BCC)
        End If

        If Not String.IsNullOrEmpty(CC) Then
            _mail.Bcc.Add(CC)
        End If

        '_mail.SubjectEncoding = System.Text.Encoding.UTF8
        _mail.Body = Body_Mensaje
        '_mail.BodyEncoding = System.Text.Encoding.UTF8
        _mail.IsBodyHtml = IsBodyHtml
        _mail.Priority = Prioridad

        Dim MsgHTML As String = "<Table >"

        MsgHTML += "<tr><td>" + Body_Mensaje + "</td></tr>" 'Texto
        MsgHTML += "<tr><td>" + sLema + "</td></tr>" ' Firma o Lema
        MsgHTML += "<tr><td><img src=cid:companylogo></td></tr>" 'Logo
        MsgHTML += "<tr><td> Fecha:" + Now.ToLongDateString + "  " + Now.ToLongTimeString + " </td></tr>" 'Fecha
        MsgHTML += "</table>"

        Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(Body_Mensaje + vbCrLf + sLema, Nothing, "text/plain")
        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(MsgHTML, Nothing, "text/html")

        Dim logo As LinkedResource = New LinkedResource(ConfigurationManager.AppSettings("IMG_RPT") + "\Img_gob.jpg")
        logo.ContentId = "companylogo"
        htmlView.LinkedResources.Add(logo)

        'add the views
        _mail.AlternateViews.Add(plainView)
        _mail.AlternateViews.Add(htmlView)


        'Esta parte es la que cambia con respecto a un servidor SMTP/POP3
        Dim _smtp As New SmtpClient()
        _smtp.Credentials = New System.Net.NetworkCredential(UserName, PassWord)
        _smtp.Port = Port
        _smtp.Host = Host
        _smtp.EnableSsl = EnableSsl
        _smtp.Timeout = TimeOut
        'Try
        _smtp.Send(_mail)
        MsgResult = "Se Envio mensaje a :" + Para
        lErrorG = False
        'Catch ex As System.Net.Mail.SmtpException
        'MsgResult = ex.Message
        lErrorG = True
        'End Try
        Return MsgResult
    End Function

    Public Shared Function GetDominio(ByVal Direccion As String) As String
        Dim s As String = Direccion
        Return s.Substring(s.LastIndexOf("@"))
    End Function

    Public Shared Function GMailEnviar(ByVal Para As String, ByVal Asunto As String, ByVal Body_Mensaje As String) As String
        Dim MsgResult As String
        Dim _mail As New System.Net.Mail.MailMessage()
        _mail.[To].Add(Para)
        _mail.From = New MailAddress("borisgr04@gmail.com", "B&A Systems", System.Text.Encoding.UTF8)
        _mail.Subject = Asunto
        _mail.SubjectEncoding = System.Text.Encoding.UTF8
        _mail.Body = Body_Mensaje
        _mail.BodyEncoding = System.Text.Encoding.UTF8
        _mail.IsBodyHtml = True
        'Esta parte es la que cambia con respecto a un servidor SMTP/POP3
        Dim _smtp As New SmtpClient()
        _smtp.Credentials = New System.Net.NetworkCredential("borisgr04@gmail.com", "anyamiyeth")
        _smtp.Port = 587
        _smtp.Host = "smtp.gmail.com"
        _smtp.EnableSsl = True
        'Esto es para que vaya a través de SSL que es obligatorio con GMail
        Try
            _smtp.Send(_mail)
            MsgResult = "Se envio el Correo"
        Catch ex As System.Net.Mail.SmtpException
            MsgResult = ex.Message
        End Try
        Return MsgResult
    End Function
    Public Shared Function HotMailEnviar(ByVal Para As String, ByVal Asunto As String, ByVal Body_Mensaje As String) As String
        Dim MsgResult As String
        Dim _mail As New System.Net.Mail.MailMessage()
        _mail.[To].Add(Para)
        _mail.From = New MailAddress("borisgr04@hotmail.com", "B&A Systems", System.Text.Encoding.UTF8)
        _mail.Subject = Asunto
        _mail.SubjectEncoding = System.Text.Encoding.UTF8
        _mail.Body = Body_Mensaje
        _mail.BodyEncoding = System.Text.Encoding.UTF8
        _mail.IsBodyHtml = True
        'Esta parte es la que cambia con respecto a un servidor SMTP/POP3
        Dim _smtp As New SmtpClient()
        _smtp.Credentials = New System.Net.NetworkCredential("borisgr04@hotmail.com", "anyamiyeth")
        _smtp.Port = 25
        _smtp.Host = "smtp.live.com"
        _smtp.EnableSsl = True
        'Esto es para que vaya a través de SSL que es obligatorio con GMail
        Try
            _smtp.Send(_mail)
            MsgResult = "Se envio el Correo"
        Catch ex As System.Net.Mail.SmtpException
            MsgResult = ex.Message
        End Try
        Return MsgResult
    End Function


End Class


