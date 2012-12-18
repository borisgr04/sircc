Imports System.Web.Services
Imports System.Data
Imports System.Web.Script.Services
Imports System.Linq
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


    Sub Buscar()
        'CboMod.DataBind()
        If Not String.IsNullOrEmpty(LbUsuarios.Text) Then
            Dim u As MembershipUser = Membership.GetUser(LbUsuarios.Text)
            If Not (u Is Nothing) Then
                'PopulateRoleList(TxtUserName.Text)
                obj.GetRecords(LbUsuarios.Text)
                Dim objM As New DBMenu
                objM.GetOpcionesPorUser(Me.Tvw, LbUsuarios.Text, CboMod.SelectedValue)
            End If
        End If
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Opcion = "Administración de Roles"
        Me.SetTitulo()

        If Not Page.IsPostBack Then

            If Not String.IsNullOrEmpty(Request("username")) Then
                TxtUserName.Text = Request("username")
                Buscar()
            End If


        End If

    End Sub


    Sub Guardar()
        Dim obj As New DBMenu
        Me.MsgResult.Text = obj.AsigPermisosAUser(Me.Tvw, Me.GridView1.SelectedValue)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
    End Sub

    Protected Function Logico(ByVal valor As Integer) As String
        Return (valor = 1)
    End Function

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Me.TxtUserName.Text = Me.GridView1.SelectedValue
        If Not String.IsNullOrEmpty(GridView1.SelectedValue.ToString()) Then
            MultiView1.ActiveViewIndex = 1
            Me.CboMod.DataBind()
            MsgBoxLimpiar(Me.MsgResult)
            LbUsuarios.Text = Me.GridView1.SelectedValue '+ " - " + GridView1.SelectedRow.Cells(1).Text
            Buscar()

        End If
        
    End Sub

    Protected Sub CboMod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMod.SelectedIndexChanged
        Buscar()
    End Sub

    Sub GRoles()
        Dim mn As New DBMenu
        mn.GenerarRoles()
        msgResult2.Text = "Se generarón los Roles"
        MsgBox(msgResult2, False)

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        Select Case e.CommandName
            Case "activar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Dim User As String = GridView1.SelectedValue

                Membership.GetUser(User).IsApproved = Not Membership.GetUser(User).IsApproved
                Me.MsgResult.Text = "Cambio estado de usuario " + User
                MsgBox(MsgResult, False)
            Case "desbloquear"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Dim User As String = GridView1.SelectedValue

                Dim r As Boolean = Usuarios.Desbloquear(User)
                Me.MsgResult.Text = "Desbloqueo a usuario " + User
                MsgBox(MsgResult, r)
            Case "AdminDesktop"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Dim User As String = GridView1.SelectedValue

                Dim objter As New Terceros
                MsgResult.Text = objter.AdminDesktop(User)
                MsgBox(MsgResult, objter.lErrorG)
        End Select
        Me.GridView1.DataBind()


    End Sub


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        'Buscar()
    End Sub


    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Shared Function ObtieneNombres(ByVal prefixText As String) As String() 'As List(Of Terc)
        Dim obj As New Terceros
        Dim lerrorg As Boolean = False
        Dim datat As New DataTable
        datat = obj.GetRecords(prefixText)
        Dim items As List(Of String) = New List(Of String)
        'Dim items As List(Of Terc) = New List(Of Terc)
        Dim i As Integer
        Dim Sal As String

        If datat.Rows.Count > 0 Then

            For i = 0 To datat.Rows.Count - 1
                'Dim Sal As New Terc
                'Sal.Nit = datat.Rows(i).Item("Ide_Ter").ToString()
                'Sal.Nom = datat.Rows(i).Item("Nom_Ter").ToString()
                Sal = datat.Rows(i).Item("Nom_Ter").ToString()
                items.Add(Sal)
            Next i
        Else
            items.Clear()
        End If
        Return items.ToArray
    End Function


    Private Sub volver()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCancelar.Click
        volver()
    End Sub

    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Guardar()
    End Sub

    Protected Sub IBtnRoles_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnRoles.Click
        GRoles()
    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + "Ajax"
        End If

    End Sub

End Class


