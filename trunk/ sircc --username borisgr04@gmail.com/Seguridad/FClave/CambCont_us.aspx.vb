Imports Microsoft.VisualBasic
Imports oracle.DataAccess.Client
Imports oracle.DataAccess.Types
Imports System.Data
Imports System.ComponentModel
Partial Class Seguridad_Usuarios_Cam_CambCont_us
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
    End Sub

    Protected Sub BTfor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTfor.Click
        If Me.Tcont.Text = Me.Tconf.Text Then
            Dim obj As Usuarios = New Usuarios
            Me.MsgResult.Text = obj.Forzar_Cambio_Clave(Me.Tus.Text, Me.Tcont.Text)
            Me.MsgBox(Me.MsgResult, obj.lErrorG)
        Else
            Me.MsgResult.Text = "La Nueva contraseña y la confirmación de la contraseña no coinciden"
            Me.MsgBox(Me.MsgResult, True)
        End If
    End Sub

  
End Class
