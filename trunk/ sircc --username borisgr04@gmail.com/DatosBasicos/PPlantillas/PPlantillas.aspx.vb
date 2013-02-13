Imports System.Data
Partial Class DatosBasicos_PPlantillas_PPlantillas
    Inherits PaginaComun


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        Me.GridView1.DataBind()
        Dim curObj As ScriptManager = ScriptManager.GetCurrent(Page)
        If curObj IsNot Nothing Then
            curObj.RegisterPostBackControl(Me.BtnGuardar)
        End If
        If Not IsPostBack Then
            Me.GridView1.DataBind()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Dim Obj As New PPlantillas
        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."

                Me.Habilitar(True)
                Limpiar()

                Me.ModalPopupTer.Show()
                'Me.TxtCodNew.ReadOnly = True
                'Me.SetFocus(Me.TxtCodNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                Dim tb As DataTable = Obj.GetbyPK(Pk1)
                If tb.Rows.Count > 0 Then
                    Try
                        Habilitar(True)
                        Me.TxtCod.Text = tb.Rows(0)("IDE_PLA")
                        Me.TxtNom.Text = tb.Rows(0)("NOM_PLA")
                        Me.CboExt.Text = tb.Rows(0)("Ext")
                        Me.CboEst.Text = tb.Rows(0)("Est_Pla")
                        Me.CboTipPla.SelectedValue = tb.Rows(0)("Tip_Pla")
                        If Not (tb.Rows(0)("Cod_Stip") Is DBNull.Value) Then
                            Me.CboSTip.Text = tb.Rows(0)("Cod_Stip")
                        End If
                        Pk1 = tb.Rows(0)("IDE_PLA").ToString
                        Habilitar(True)
                    Catch ex As Exception
                        MsgResult.Text = ex.Message
                        MsgBox(MsgResult, True)
                    End Try

                End If
                Me.ModalPopupTer.Show()
                'Me.MsgResult.Text = "Editando: Código [" + "]"
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                Habilitar(False)
                Dim tb As DataTable = Obj.GetbyPK(Pk1)
                Try
                    Me.TxtCod.Text = tb.Rows(0)("IDE_PLA")
                    Me.TxtNom.Text = tb.Rows(0)("NOM_PLA")
                    Me.CboExt.Text = tb.Rows(0)("Ext")
                    Me.CboEst.Text = tb.Rows(0)("Est_Pla")
                    Me.CboTipPla.SelectedValue = tb.Rows(0)("Tip_Pla")
                    If Not (tb.Rows(0)("Cod_Stip") Is DBNull.Value) Then
                        Me.CboSTip.Text = tb.Rows(0)("Cod_Stip")
                    End If
                    Pk1 = tb.Rows(0)("IDE_PLA").ToString

                Catch ex As Exception
                    MsgResult.Text = ex.Message
                    MsgBox(MsgResult, True)
                End Try
                Me.ModalPopupTer.Show()
        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        
        TxtCod.Enabled = False
        CboTipPla.Enabled = b
        CboEst.Enabled = b
        CboSTip.Enabled = b

        TxtNom.Enabled = b

        Me.BtnGuardar.Enabled = b
        Me.BtnEliminar.Enabled = Not b
    End Sub

    Protected Sub GridView1_RowCommand1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "download" Then
            Dim index As Integer = CInt(e.CommandArgument)
            GridView1.SelectedIndex = index
            Redireccionar_Pagina(String.Format("/ashx/verPPlantilla.ashx?Ide_Pla={0}", GridView1.SelectedValue))
        End If
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        FillCustomerInGrid()
    End Sub
    Private Sub FillCustomerInGrid()
        Me.GridView1.DataBind()
     
    End Sub

    
    Sub Guardar()
        Dim Obj As New PPlantillas
        Select Case Me.Oper
            Case "Nuevo"
                MsgResult.Text = Obj.Insert(CboTipPla.SelectedValue, TxtNom.Text, FileUpload1, CboExt.SelectedValue, CboSTip.SelectedValue, CboEst.SelectedValue, "")
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Pk1, CboTipPla.Text, TxtNom.Text, FileUpload1, CboExt.Text, CboSTip.Text, CboEst.Text)
        End Select
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
            Me.Oper = ""
        End If
    End Sub

    Protected Sub Limpiar()
        Me.TxtCod.Text = ""
        Me.TxtNom.Text = ""
        CboTipPla.SelectedIndex = 0
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        MsgBoxLimpiar(MsgResult)
    End Sub

    Protected Sub GridView1_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If

    End Sub
    
    Protected Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNuevo.Click
        Me.Oper = "Nuevo"
        Habilitar(True)
        MsgBoxLimpiar(MsgResult)
        Me.ModalPopupTer.Show()
    End Sub
   

    Protected Sub CboTipPla_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTipPla.SelectedIndexChanged
        If CboTipPla.Text = "03" Then
            CboSTip.Enabled = False
        Else
            CboSTip.Enabled = True
        End If
    End Sub

    Protected Sub BtnGuardar_Click1(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardar.Click
        Guardar()
    End Sub

    Protected Sub BtnEliminar_Click1(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnEliminar.Click
        Eliminar()
    End Sub

    Sub Eliminar()
        Dim Obj As New PPlantillas
        MsgResult.Text = Obj.Delete(Pk1)
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
    End Sub

    Protected Sub BtnCancelar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnCancelar.Click

    End Sub
End Class
