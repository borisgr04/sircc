Imports System.Data
Partial Class Seguridad_RegUsuarios
    Inherits PaginaComun

    
    Sub guardar()
        Dim Obj As New Usuarios()
        Me.msgResult.Text = Obj.Insertar(Me.TxtUsername.Text, Me.TxtClave.Text)
        'Me.MsgModalPanel.Text = Me.LbRpt.Text
        MsgBox(Me.msgResult, Obj.lErrorG)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = Me.Titulo() + "Registro de Usuarios"
        Me.TxtUsername.Attributes.Add("OnBlur", "javascript:ValidarUser();")
    End Sub



    Protected Sub BtnBuscarUser_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Usuarios.IsUser(Me.TxtUsername.Text) Then
            Me.msgResult.Text = "InValido Usuario Existe"

        Else
            Me.msgResult.Text = "No existe"
        End If

    End Sub

    Sub Validar_Usuario(ByVal sender As Object, ByVal value As ServerValidateEventArgs)
        Dim t As New Terceros
        value.IsValid = (t.GetByIde(Me.TxtUsername.Text).Rows.Count() > 0)
        If value.IsValid = True Then
            value.IsValid = Usuarios.IsUser(Me.TxtUsername.Text)
        End If
        BtnGuardar.Enabled = value.IsValid
    End Sub

    
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ModalPopupTer.Show()

    End Sub

    Protected Sub TxtUsername_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUsername.TextChanged

        Dim Obj As New Terceros
        Dim dt As DataTable = Obj.GetByIde(Me.TxtUsername.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtRazSoc.Text = dt.Rows(0)("Nom_Ter").ToString
            BtnGuardar.Enabled = True
        Else
            Me.msgResult.Text = "El usuario debe estar registrado como Tercero"
            MsgBox(Me.msgResult, True)
            BtnGuardar.Enabled = False

        End If


        '
    End Sub

    Protected Sub IBtnAuto_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAuto.Click
        Response.Redirect("../Roles/Admin.aspx?Username=" + TxtUsername.Text)
    End Sub

  

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardar.Click
        guardar()
    End Sub
End Class
