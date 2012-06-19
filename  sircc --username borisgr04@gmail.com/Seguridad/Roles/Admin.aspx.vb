Partial Class Seguridad_Roles_Admin
    Inherits PaginaComun
    Dim obj As Usuarios = New Usuarios

    Sub PopulateRoleList(ByVal userName As String)

        ' RoleList.Items.Clear()

        Dim roleNames() As String
        Dim roleName As String

        roleNames = Roles.GetAllRoles()

        For Each roleName In roleNames

            Dim roleListItem As New ListItem
            roleListItem.Text = roleName
            roleListItem.Selected = Roles.IsUserInRole(userName, roleName)

            'RoleList.Items.Add(roleListItem)

        Next

    End Sub

    Sub LookupBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LookupBtn.Click

        Buscar()

    End Sub

    Sub Buscar()
        Dim u As MembershipUser = Membership.GetUser(Me.TxtUserName.Text)
        If Not (u Is Nothing) Then
            PopulateRoleList(TxtUserName.Text)
            obj.GetRecords(TxtUserName.Text)
            Dim objM As New DBMenu
            objM.GetOpcionesPorUser(Me.Tvw, TxtUserName.Text, CboMod.SelectedValue)
            '        Me.MultiView1.ActiveViewIndex = 0
            Me.btnAct.Visible = True
        Else
            Me.btnAct.Visible = False
        End If
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = "Administraci�n de Roles"
        Me.SetTitulo()
        Me.btnAct.Visible = False

    End Sub


    Protected Sub btnAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAct.Click
        Dim obj As New DBMenu
        Me.MsgResult.Text = obj.AsigPermisosAUser(Me.Tvw, Me.TxtUserName.Text)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
    End Sub

    Protected Function Logico(ByVal valor As Integer) As String
        Return (valor = 1)
    End Function



    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.TxtUserName.Text = Me.GridView1.SelectedValue
    End Sub

    Protected Sub CboMod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMod.SelectedIndexChanged
        Buscar()
    End Sub

    Protected Sub BtnCargarRoles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCargarRoles.Click

        Dim mn As New DBMenu
        mn.GenerarRoles()
        MsgResult.Text = "Se generar�n los Roles"
        MsgBox(MsgResult, False)

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.GridView1.SelectedIndex = index
        Dim User As String = GridView1.SelectedValue
        Select Case e.CommandName
            Case "activar"
                Membership.GetUser(User).IsApproved = Not Membership.GetUser(User).IsApproved
                Me.MsgResult.Text = "Cambio estado de usuario " + User
                MsgBox(MsgResult, False)
            Case "desbloquear"
                Dim r As Boolean = Usuarios.Desbloquear(User)
                Me.MsgResult.Text = "Desbloqueo a usuario " + User
                MsgBox(MsgResult, r)
            Case "AdminDesktop"
                Dim objter As New Terceros
                MsgResult.Text = objter.AdminDesktop(User)
                MsgBox(MsgResult, objter.lErrorG)
        End Select
        Me.GridView1.DataBind()
    End Sub

    
End Class


