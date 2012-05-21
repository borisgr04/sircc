Imports System.Data
Partial Class DatosBasicos_Proyectos_Default
    Inherits PaginaComun

    Dim Obj As New Proyectos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            FillCustomerInGrid()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
        If GridView1.Rows.Count = 0 Then
            IbtnNuevo.Visible = True
        Else
            IbtnNuevo.Visible = False
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
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
                    Me.TxtCodNew.Text = tb.Rows(0)("Vigencia").ToString
                    Me.txt_proy.Text = tb.Rows(0)("Proyecto").ToString
                    Me.txtNomProy.Text = tb.Rows(0)("Nombre_Proyecto").ToString
                    Me.Txt_Fec_Rad.Text = tb.Rows(0)("Fecha_Rad").ToString
                    Me.Txt_comite.Text = tb.Rows(0)("Comite").ToString
                    Me.Txt_Val.Text = tb.Rows(0)("Valor").ToString
                    Me.Cmb_Estado.Text = tb.Rows(0)("Estado").ToString
                    Me.Pk1 = tb.Rows(0)("Proyecto").ToString
                    Habilitar(True)
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
                    Me.TxtCodNew.Text = tb.Rows(0)("Vigencia").ToString
                    Me.txt_proy.Text = tb.Rows(0)("Proyecto").ToString
                    Me.txtNomProy.Text = tb.Rows(0)("Nombre_Proyecto").ToString
                    Me.Txt_Fec_Rad.Text = tb.Rows(0)("Fecha_Rad").ToString
                    Me.Txt_comite.Text = tb.Rows(0)("Comite").ToString
                    Me.Txt_Val.Text = tb.Rows(0)("Valor").ToString
                    Me.Cmb_Estado.Text = tb.Rows(0)("Estado").ToString
                    Me.Pk1 = tb.Rows(0)("Proyecto").ToString
                    Me.ModalPopupTer.Show()
                    Habilitar(False)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0
            Case "Exportar"
                ExportGridView(GridView1, "Proyectos-SIRCC")
        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtCodNew.Enabled = b
        Me.txt_proy.Enabled = b
        Me.txtNomProy.Enabled = b
        Me.Txt_Fec_Rad.Enabled = b
        Me.Txt_Val.Enabled = b
        Me.Txt_comite.Enabled = b
        Me.Cmb_Estado.Enabled = b
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
                Me.MsgResult.Text = Obj.Insert(Me.TxtCodNew.Text, Me.txt_proy.Text, Me.txtNomProy.Text, Me.Txt_Fec_Rad.Text, Me.Txt_comite.Text, Me.Txt_Val.Text, Cmb_Estado.SelectedValue)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Pk1, Me.TxtCodNew.Text, Me.txt_proy.Text, Me.txtNomProy.Text, Me.Txt_Fec_Rad.Text, Me.Txt_comite.Text, Me.Txt_Val.Text, Cmb_Estado.SelectedValue)
        End Select
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If
    End Sub

    Protected Sub Limpiar()
        Me.TxtCodNew.Text = ""
        Me.txt_proy.Text = ""
        Me.Txt_Fec_Rad.Text = ""
        Me.Txt_Val.Text = ""
        Me.Txt_comite.Text = ""

        'Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub

    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Delete(Me.txt_proy.Text)
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

    Protected Sub IbtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnNuevo.Click
        Me.SubT.Text = "Nuevo..."
        Me.Oper = "Nuevo"
        Me.ModalPopupTer.Show()
        Me.Habilitar(True)
        Limpiar()
        'Me.TxtCodNew.ReadOnly = True
        Me.SetFocus(Me.TxtCodNew)
    End Sub
End Class
