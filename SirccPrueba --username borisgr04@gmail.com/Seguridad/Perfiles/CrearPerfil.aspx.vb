
Partial Class Seguridad_Perfiles_crearPerfil
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarElementos()
        End If
        Me.SetTitulo()

    End Sub
    Protected Sub CargarElementos()
        Dim objM As New DBMenu()
        objM.cargarElementos(Me.Tvw, "", Me.CboMod.SelectedValue)
    End Sub

    Protected Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles BtnAgregar.Click 'Handles BtnAgregar.Click
        Dim obj As New DBMenu
        Me.msgResult.Visible = True
        msgResult.Text = "PRUEBA"
        msgResult.Text = obj.AgregarPerfil(Me.Tvw, TxtNomPer.Text, Me.CboMod.SelectedValue)
        Me.MsgBox(Me.msgResult, obj.lErrorG)
    End Sub


    Protected Sub CboMod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMod.SelectedIndexChanged
        CargarElementos()
    End Sub

    Protected Sub BtnAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAct.Click
        CargarElementos()
    End Sub
End Class
