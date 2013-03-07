
Partial Class Seguridad_Perfiles_ModPerfil
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarElementos("")
        End If
        Me.SetTitulo()


    End Sub

    Protected Sub CargarElementos(ByVal Perfil As String)

        Dim obj As New DBMenu
        Me.msgResult.Text = Perfil
        obj.cargarElementos(Me.Tvw, Perfil, Me.CboMod.SelectedValue)

    End Sub

    Protected Sub Guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim obj As New DBMenu
        MsgBoxLimpiar(msgResult)
        msgResult.Text = obj.ActualizarPerfil(Tvw, Me.GridView1.SelectedValue.ToString(), CboMod.SelectedValue)
        MsgBox(msgResult, obj.lErrorG)

    End Sub
    Protected Sub Actualizar()

        Me.lbPerfil.Text = Me.GridView1.SelectedValue.ToString()
        Me.CargarElementos(Me.GridView1.SelectedValue.ToString())

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Actualizar()

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim obj As New DBMenu

        MsgBoxLimpiar(msgResult)
        If Me.GridView1.SelectedIndex >= 0 Then
            msgResult.Text = obj.AsigPerfilUser(Me.GridView1.SelectedValue.ToString(), Me.TextBox1.Text)
        Else
            msgResult.Text = "Seleccione un Perfil"
        End If
        Me.MsgBox(Me.msgResult, obj.lErrorG)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim obj As New DBMenu
        MsgBoxLimpiar(msgResult)
        msgResult.Text = obj.DAsigPerfilUser(Me.GridView1.SelectedValue.ToString(), Me.TextBox1.Text)
        Me.MsgBox(msgResult, obj.lErrorG)

    End Sub

    

    Protected Sub BtnElimPerfil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnElimPerfil.Click
        Dim obj As New DBMenu
        MsgBoxLimpiar(msgResult)
        msgResult.Text = obj.Delete(Me.GridView1.SelectedValue.ToString())
        Me.MsgBox(msgResult, obj.lErrorG)
        Me.GridView1.DataBind()

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        
        If e.CommandName = "Editar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' Get the last name of the selected author from the appropriate
            ' cell in the GridView control.
            Dim selectedRow As GridViewRow = GridView1.Rows(index)
            Dim contactCell As TableCell = selectedRow.Cells(1)
            Dim contact As String = contactCell.Text

            ' Display the selected author.
            Me.lbPerfil.Text = "Perfil Seleccionado:[ " & contact & "]."

            'Actualizar()

            Me.GridView1.SelectedIndex = index
            Me.lbPerfil.Text = Me.GridView1.SelectedValue.ToString()
            Me.CargarElementos(Me.GridView1.SelectedValue.ToString())
            MultiView1.ActiveViewIndex = 0
        ElseIf e.CommandName = "Asignar_Usuarios" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' Get the last name of the selected author from the appropriate
            ' cell in the GridView control.
            Dim selectedRow As GridViewRow = GridView1.Rows(index)
            Dim contactCell As TableCell = selectedRow.Cells(1)
            Dim contact As String = contactCell.Text

            ' Display the selected author.
            Me.lbPerfil.Text = "Perfil Seleccionado:[ " & contact & "]."

            'Actualizar()

            Me.GridView1.SelectedIndex = index
            Me.lbPerfil.Text = Me.GridView1.SelectedValue.ToString()
            Me.CargarElementos(Me.GridView1.SelectedValue.ToString())
            MultiView1.ActiveViewIndex = 1
        End If


    End Sub

    Protected Sub ScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ScriptManager1.AsyncPostBackErrorMessage = "SIRCC:" + e.Exception.InnerException.Message + e.Exception.InnerException.Source
        End If
    End Sub

    Protected Sub CboMod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMod.SelectedIndexChanged
        CargarElementos(Me.GridView1.SelectedValue)
    End Sub
End Class
