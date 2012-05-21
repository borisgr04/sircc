Imports System.Data
Partial Class Procesos_Proponentes_Proponente
    Inherits PaginaComun
    Dim obj As PProponentes = New PProponentes

    Protected Sub DetPContrato1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetPContrato1.AceptarClicked
        MsgResult.Text = ""
        MsgResult.CssClass = ""
        If Me.DetPContrato1.Encontrado = True And Me.DetPContrato1.Tramite = False Then
            MsgResult.Text = "El Proceso ha finalizado su TRAMITE y no puede ser modificado"
            MsgBoxAlert(MsgResult, True)
            Me.ImageButton1.Enabled = False
            Me.GridView1.Enabled = False
        ElseIf Me.DetPContrato1.Encontrado = False Then
            MsgResult.Text = "No se encontró el Proceso"
            MsgBoxAlert(MsgResult, True)
        Else
            Me.ImageButton1.Enabled = True
            Me.GridView1.Enabled = True
        End If
    End Sub
    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        Me.DetPContrato1.CodigoPContrato = ConPContratos1.Num_Proc

        Me.CrProponentes1.num_proc = ConPContratos1.Num_Proc

        UpdatePanel1.Update()
        Me.ModalPopupConP.Hide()
    End Sub

    Protected Sub DetPContrato1_BuscarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetPContrato1.BuscarClicked
        Me.ModalPopupConP.Show()
    End Sub




    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Me.Oper = e.CommandName
        Select Case Me.Oper
            Case "Editar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                CrProponentes1.Nit = GridView1.DataKeys(index).Values(0).ToString()
                CrProponentes1.Num_Proc = Me.DetPContrato1.CodigoPContrato
                CrProponentes1.Editar()
                Me.MultiView1.ActiveViewIndex = 1
            Case "AddMiembro"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Dim dt As DataTable = obj.GetbyPk(GridView1.DataKeys(index).Values(0).ToString(), Me.DetPContrato1.CodigoPContrato)
                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                If dt.Rows(0).Item("Tipo").ToString = "PU" Then
                    MsgResult.Text = "Operación no valida para PERSONA UNICA"
                    MsgBoxAlert(MsgResult, True)
                Else
                    Me.TxtNitProp.Text = dt.Rows(0).Item("Ide_Prop").ToString
                    Me.TxtNomProp.Text = dt.Rows(0).Item("Razon_Social").ToString
                    LimpiarMiembros()
                    Me.MultiView1.ActiveViewIndex = 2
                    Me.ImageButton1.Enabled = False
                End If
        End Select
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If Me.DetPContrato1.Encontrado Then
            Me.Oper = "Nuevo"
            CrProponentes1.Num_Proc = Me.DetPContrato1.CodigoPContrato
            CrProponentes1.Nuevo()
            Me.MultiView1.ActiveViewIndex = 1
            MsgResult.Text = ""
            MsgResult.CssClass = ""
        Else
            MsgResult.Text = "No hay ningun proceso seleccionado"
            MsgBox(MsgResult, True)
        End If
    End Sub

    Protected Sub BtnVoler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVoler.Click
        Me.GridView1.DataBind()
        Me.MultiView1.ActiveViewIndex = 0
    End Sub



    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.MsgMiembros.Text = ""
        Me.MsgMiembros.CssClass = ""
        Me.ModalPopup.Show()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.MultiView1.ActiveViewIndex = 0
        Me.MsgMiembros.Text = ""
        Me.MsgMiembros.CssClass = ""
        Me.ImageButton1.Enabled = True
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardar.Click
        Dim Miembro As New Consorcios
        Me.MsgMiembros.Text = Miembro.Insert(Me.Pk1, TxtIdMiembro.Text, CmbEst.SelectedValue)
        Me.GridView2.DataBind()
        LimpiarMiembros()
        Me.MsgBox(MsgMiembros, obj.lErrorG)
    End Sub

    Protected Sub AdmTercero1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdmTercero1.SelClicked
        TxtIdMiembro.Text = Me.AdmTercero1.Nit
        BuscarMiembro()
        Me.ModalPopup.Hide()
    End Sub
    Sub BuscarMiembro()
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.TxtIdMiembro.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNomMiembro.Text = dt.Rows(0)("Nom_Ter").ToString()
            Me.MsgMiembros.Text = ""
        Else
            Me.MsgMiembros.Text = "No se encontro el Tercero"
            MsgBoxAlert(MsgMiembros, False)
            VerModalPopup("RLC")
        End If
    End Sub
    Sub VerModalPopup(ByVal Tipo As String)
        AdmTercero1.tipoter = Tipo
        Me.ModalPopup.Show()
    End Sub

    Sub LimpiarMiembros()
        Me.TxtIdMiembro.Text = ""
        Me.TxtNomMiembro.Text = ""
    End Sub

    Protected Sub TxtIdMiembro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIdMiembro.TextChanged
        BuscarMiembro()
    End Sub
End Class
