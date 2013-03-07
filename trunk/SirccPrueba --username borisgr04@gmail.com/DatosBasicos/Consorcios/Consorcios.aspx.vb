Imports System.Data
Partial Class DatosBasicos_CSUT_Default
    Inherits PaginaComun
    Dim Obj As Consorcios = New Consorcios

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

    End Sub
    Sub BuscarCSUT()
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.TxtNitCSUT.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNomCSUT.Text = dt.Rows(0)("Nom_Ter").ToString()
        Else
            '            Me.MsgResult.Text = "No encontro el Tercero"
        End If
    End Sub
    Sub BuscarMiembro()
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.txtIde.Text)
        If dt.Rows.Count > 0 Then
            Me.txtNomTer.Text = dt.Rows(0)("Nom_Ter").ToString()
        Else
            '            Me.MsgResult.Text = "No encontro el Tercero"
        End If
    End Sub

    Protected Sub txtIde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIde.TextChanged
        BuscarMiembro()
    End Sub

    Protected Sub TxtNitCSUT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNitCSUT.TextChanged
        BuscarCSUT()
    End Sub

    Protected Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        
        Me.MsgResult.Text = Obj.Insert(TxtNitCSUT.Text, txtIde.Text, CmbEst.SelectedValue, TxtPP.Text)
        Me.GridView1.DataBind()
        Me.MsgBox(MsgResult, Obj.lErrorG)
        If Obj.lErrorG = False Then
            'Me.Limpiar()
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
            Case "Editar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetbyUK(TxtNitCSUT.Text, GridView1.DataKeys(index).Values(0).ToString())
                If tb.Rows.Count > 0 Then
                    Me.Txt_Id.Text = tb.Rows(0)("Id_Miembro").ToString
                    Me.Txt_nom.Text = tb.Rows(0)("Nom_Miembro").ToString
                    Me.CmbEstado.Text = tb.Rows(0)("Estado").ToString
                    Me.TxtPp_m.Text = tb.Rows(0)("Porc_Part").ToString
                    Me.Pk1 = tb.Rows(0)("Id_Miembro").ToString
                    Habilitar(True)
                    Me.ModalPopupExtender3.Show()
                End If

                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.txtIde.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                'Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Dim tb As DataTable = Obj.GetbyUK(TxtNitCSUT.Text, GridView1.DataKeys(index).Values(0).ToString())
                If tb.Rows.Count > 0 Then
                    Me.Txt_Id.Text = tb.Rows(0)("Id_Miembro").ToString
                    Me.Txt_nom.Text = tb.Rows(0)("Nom_Miembro").ToString
                    Me.CmbEstado.Text = tb.Rows(0)("Estado").ToString
                    Me.TxtPp_m.Text = tb.Rows(0)("Porc_Part").ToString
                    Me.Pk1 = tb.Rows(0)("Id_Miembro").ToString
                    Habilitar(False)
                    Me.ModalPopupExtender3.Show()
                End If
                Me.ModalPopupExtender3.Show()
                'MultiView1.ActiveViewIndex = 0
        End Select

    End Sub
    Protected Sub Habilitar(ByVal b As Boolean)
        Me.Txt_Id.Enabled = False
        Me.Txt_nom.Enabled = False
        Me.CmbEstado.Enabled = b
        Me.Btn_Guardar.Enabled = b
        Me.Btn_Eliminar.Enabled = Not b
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Btn_Guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Update(TxtNitCSUT.Text, Txt_Id.Text, CmbEstado.SelectedValue, TxtPp_m.Text)
        Me.GridView1.DataBind()
        Me.MsgBox(MsgResult, Obj.lErrorG)
        If Obj.lErrorG = False Then
            'Me.Limpiar()
        End If
    End Sub

    Protected Sub Btn_Eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Delete(TxtNitCSUT.Text, Txt_Id.Text)
        Me.GridView1.DataBind()
        Me.MsgBox(MsgResult, Obj.lErrorG)
        If Obj.lErrorG = False Then
            'Me.Limpiar()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub
End Class
