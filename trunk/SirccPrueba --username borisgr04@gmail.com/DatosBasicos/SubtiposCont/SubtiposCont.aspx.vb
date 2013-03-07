Imports System.Data
Partial Class DatosBasicos_SubTiposCont_Default
    Inherits PaginaComun

    Dim Obj As New SubTipos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            FillCustomerInGrid()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
            Case "Exportar"
                GridView2.DataSource = Obj.GetRecordsDB
                GridView2.DataBind()
                ExportGridView(GridView2, "SUBTIPOS DE CONTRTOS - SIRCC")
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."

                Me.Habilitar(True)
                Limpiar()

                Me.ModalPopupTer.Show()
                'Me.TxtCodNew.ReadOnly = True
                Me.SetFocus(Me.TxtCodNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetbyPk(GridView1.DataKeys(index).Values(0).ToString())
                If tb.Rows.Count > 0 Then
                    Me.TxtCodNew.Text = tb.Rows(0)("Cod_Stip").ToString
                    Me.txtNomNew.Text = tb.Rows(0)("Nom_Stip").ToString
                    Me.CboTip.Text = tb.Rows(0)("Cod_Tip").ToString
                    Me.Txt_Cod_Aux.Text = tb.Rows(0)("Cla_Con_Dep").ToString
                    Me.Txt_Cod_For_Con.Text = tb.Rows(0)("Crt_F20_1A").ToString
                    Me.Txt_Cod_Con_Dep.Text = tb.Rows(0)("Cla_Con_Dp").ToString
                    Me.Pk1 = tb.Rows(0)("Cod_Stip").ToString
                    Habilitar(True)
                    Me.CboTip.Enabled = False
                    Me.ModalPopupTer.Show()
                End If

                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtCodNew.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                'Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Dim tb As DataTable = Obj.GetbyPk(GridView1.DataKeys(index).Values(0).ToString())
                If tb.Rows.Count > 0 Then
                    Me.TxtCodNew.Text = tb.Rows(0)("Cod_Stip").ToString
                    Me.txtNomNew.Text = tb.Rows(0)("Nom_Stip").ToString
                    Me.Txt_Cod_Aux.Text = tb.Rows(0)("Cla_Con_Dep").ToString
                    Me.CboTip.Text = tb.Rows(0)("Cod_Tip").ToString
                    'Me.Cb_Tipo.Text = tb.Rows(0)("Est_Tip").ToString
                    Me.Pk1 = tb.Rows(0)("Cod_Stip").ToString
                    Me.ModalPopupTer.Show()
                    Habilitar(False)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0

        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtCodNew.Enabled = b
        Me.txtNomNew.Enabled = b
        Me.CboTip.Enabled = b
        Me.Txt_Cod_Aux.Enabled = b
        Me.Txt_Cod_Con_Dep.Enabled = b
        Me.Txt_Cod_For_Con.Enabled = b
        Me.BtnGuardar.Enabled = b
        Me.BtnEliminar.Enabled = Not b
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        FillCustomerInGrid()
    End Sub
    Private Sub FillCustomerInGrid()
        Me.GridView1.DataBind()
        'Dim cl As String = Me.CboImpto.SelectedValue
        'If Left(Me.CboImpto.SelectedValue, 2) <> Me.CmbClase.SelectedValue Then
        ' Me.CboImpto.SelectedIndex = 0
        ' cl = ""
        'End If
        'Dim dtCustomer As DataTable = Obj.GetByImpuesto(cl)
        'If (dtCustomer.Rows.Count > 0) Then
        ' GridView1.DataSource = dtCustomer
        'GridView1.DataBind()
        'Else
        'dtCustomer.Rows.Add(dtCustomer.NewRow())
        'GridView1.DataSource = dtCustomer
        'GridView1.DataBind()
        'Dim TotalColumns As Integer = GridView1.Rows(0).Cells.Count
        'GridView1.Rows(0).Cells.Clear()
        'GridView1.Rows(0).Cells.Add(New TableCell())
        ' GridView1.Rows(0).Cells(0).ColumnSpan = TotalColumns
        'GridView1.Rows(0).Cells(0).Text = "No se encontraron Registro"
        'End If
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Select Case Me.Oper
            Case "Nuevo"
                Me.MsgResult.Text = Obj.Insert(Me.TxtCodNew.Text, Me.txtNomNew.Text, Me.CboTip.SelectedValue, Me.Txt_Cod_Aux.Text, Me.Txt_Cod_For_Con.Text, Me.Txt_Cod_Con_Dep.Text, Cmb_Estado.SelectedValue)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Pk1, Me.TxtCodNew.Text, Me.txtNomNew.Text, Me.CboTip.SelectedValue, Me.Txt_Cod_Aux.Text, Me.Txt_Cod_For_Con.Text, Me.Txt_Cod_Con_Dep.Text, Cmb_Estado.SelectedValue)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If



    End Sub

    Protected Sub Limpiar()
        Me.TxtCodNew.Text = ""
        Me.txtNomNew.Text = ""
        Me.Txt_Cod_Aux.Text = ""
        Me.Txt_Cod_Con_Dep.Text = ""
        Me.Txt_Cod_For_Con.Text = ""

        'Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub

    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Delete(Me.TxtCodNew.Text)
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
    End Sub

    Protected Sub GridView1_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If

    End Sub

End Class
