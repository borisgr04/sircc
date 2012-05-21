Imports System.Data
Partial Class DatosBasicos_PCons_Proc_Default
    Inherits PaginaComun

    Dim Obj As New Cons_Proc
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        Me.GridView1.DataBind()
        If Not IsPostBack Then
            Me.GridView1.DataBind()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
            Case "Exportar"
                GridView2.DataSource = Obj.GetRecordsDB
                GridView2.DataBind()
                ExportGridView(GridView2, "CONSECUTIVOS PROCESOS-SIRCC")
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

                Dim tb As DataTable = Obj.GetbyPKDB(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(1).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(2).ToString)
                If tb.Rows.Count > 0 Then
                    Me.CboFilVig.SelectedValue = tb.Rows(0)("Vigencia").ToString
                    Me.CboTact.SelectedValue = tb.Rows(0)("Tip_Proc").ToString
                    Me.CboTproc.SelectedValue = tb.Rows(0)("Dep_Del").ToString
                    Me.TxtValIni.Text = tb.Rows(0)("Inicial").ToString
                    Me.TxtValSig.Text = tb.Rows(0)("Siguiente").ToString
                    'Me.Pk1 = tb.Rows(0)("Cod_Eta").ToString
                    Habilitar(True)
                    Me.ModalPopupTer.Show()
                End If

                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                'Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Dim tb As DataTable = Obj.GetbyPKDB(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(1).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(2).ToString)
                If tb.Rows.Count > 0 Then
                    Me.CboFilVig.SelectedValue = tb.Rows(0)("Vigencia").ToString
                    Me.CboTact.SelectedValue = tb.Rows(0)("Tip_Proc").ToString
                    Me.CboTproc.SelectedValue = tb.Rows(0)("Dep_Del").ToString
                    Me.TxtValIni.Text = tb.Rows(0)("Inicial").ToString
                    Me.TxtValSig.Text = tb.Rows(0)("Siguiente").ToString
                    'Me.Pk1 = tb.Rows(0)("Cod_Eta").ToString
                    Me.ModalPopupTer.Show()
                    Habilitar(False)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0




        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtValSig.Enabled = b
        Me.CboTproc.Enabled = b
        Me.CboTact.Enabled = b
        Me.TxtValIni.Enabled = b
        Me.CboFilVig.Enabled = b
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
                Me.MsgResult.Text = Obj.Insert(Me.CboFilVig.SelectedValue, Me.CboTproc.SelectedValue, Me.CboTact.SelectedValue, Me.TxtValIni.Text, Me.TxtValSig.Text)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(1).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(2).ToString, Me.CboFilVig.SelectedValue, Me.CboTproc.SelectedValue, Me.CboTact.SelectedValue, Me.TxtValIni.Text, Me.TxtValSig.Text)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If
    End Sub

    Protected Sub Limpiar()
        Me.TxtValSig.Text = ""
        Me.TxtValIni.Text = ""
        Me.CboTact.SelectedIndex = 0
        Me.CboTproc.SelectedIndex = 0
        CboFilVig.SelectedIndex = 0
        'Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub

    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Delete(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(1).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(2).ToString)
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

    Protected Sub CboFilVig0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboFilVig0.SelectedIndexChanged
        Me.GridView1.DataBind()
    End Sub
End Class
