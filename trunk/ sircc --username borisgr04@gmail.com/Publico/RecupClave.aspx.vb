Imports System.Data
Partial Class Publico_RecupClave
    Inherits System.Web.UI.Page
    Dim objt As Terceros = New Terceros
    Dim dt As DataTable
    Dim msg As String

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.LMSgBox.Text = Membership.GetUser(Me.TxtUser.Text).ResetPassword
        'Exit Sub
        Try
            Dim u As String = Me.TxtUser.Text
            dt = objt.GetByUser(u)
            If dt.Rows.Count > 0 Then
                Dim rst As String = Membership.GetUser(u).ResetPassword
                Dim MsgMail As NotEmail = New NotEmail
                Dim cEmail As String = dt.Rows(0)("ema_ter").ToString
                'cEmail = "borisgr04@hotmail.com"
                'Dim cuerpo As String = String.Format("Usuario <b>{0}</b> <br>Contrase�a <b>{1}</b>", u, rst)
                Dim Cuerpo As String = Me.Cargar_Plantilla(u, rst)
                msg = MsgMail.EnviarNotificacion(cEmail, ConfigurationManager.AppSettings("NOMAPP") + Me.Tit.Text, Cuerpo)
                Me.LMSgBox.Text = "El Sistema envi� nueva contrase�a de forma autom�tico, a su Correo Electr�nico de Notificaciones"
                'Me.LMSgBox.CssClass = "Ok"
                'Membership.GetUser(u).ChangePassword(rst, Me.Tcont.Text)
            Else
                Me.LMSgBox.Text = "Usuario no registrado en el Sistema"
                'Me.LMSgBox.CssClass = "NotOk"
            End If
        Catch ex As Exception
            Me.LMSgBox.Text = "Error :" + ex.Message
            'Me.LMSgBox.CssClass = "NotOK"
        Finally

        End Try
    End Sub

    Public Function Cargar_Plantilla(ByVal u As String, ByVal rst As String) As String
        'Dim obj As CorreosE = New CorreosE
        'Dim dtc As DataTable = obj.GetPorNom("resclave")
        'Dim m As String = ""
        'If dtc.Rows.Count > 0 Then
        '    m = dtc.Rows(0)("Corr_Body").ToString
        '    m = m.Replace("{fecha}", Now.ToLongDateString)
        '    m = m.Replace("{agente}", dt.Rows(0)("ter_nom").ToString)
        '    m = m.Replace("{usuario}", u)
        '    m = m.Replace("{password}", rst)
        '    m = m.Replace("{fechahora}", CStr(Now))
        'End If
        Return ""
    End Function




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = Me.Tit.Text
    End Sub

End Class
