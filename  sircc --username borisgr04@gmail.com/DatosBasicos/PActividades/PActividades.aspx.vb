Imports System.Data
Partial Class DatosBasicos_PActividades_Default
    Inherits PaginaComun

    Dim Obj As New PActividades
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        Me.CboFilVig.Enabled = Chk_Vig.Checked
        Me.CboFilTproc.Enabled = Chk_Tproc.Checked
        If Not IsPostBack Then
            FillCustomerInGrid()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Me.Oper = e.CommandName
        Select Case Me.Oper
            Case "Exportar"
                GridView2.DataSource = Obj.GetRecordsDB
                GridView2.DataBind()
                ExportGridView(GridView2, "ACTIVIDADES-SIRCC")
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."

                Me.Habilitar(True)
                Limpiar()

                Me.ModalPopupTer.Show()
                Me.SetFocus(Me.TxtCodNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetbyPKDB(Me.CboFilVig.SelectedValue, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(1).ToString)
                If tb.Rows.Count > 0 Then
                    Me.TxtCodNew.Text = tb.Rows(0)("Cod_Act").ToString
                    Me.TxtNomNew.Text = tb.Rows(0)("Nom_Act").ToString
                    Me.CboTproc.SelectedValue = tb.Rows(0)("Cod_Tpro").ToString
                    Me.CboVig.SelectedValue = tb.Rows(0)("Vigencia").ToString
                    Me.CboTact.SelectedValue = tb.Rows(0)("Est_Proc").ToString
                    Me.TxtOrden.Text = tb.Rows(0)("Orden").ToString
                    Me.CboEstado.SelectedValue = tb.Rows(0)("Estado").ToString
                    Me.CboObligatorio.SelectedValue = tb.Rows(0)("Obligatorio").ToString
                    Me.CboOcupado.SelectedValue = tb.Rows(0)("Ocupado").ToString
                    Me.Cbodia_nohabil.SelectedValue = tb.Rows(0)("dia_nohabil").ToString
                    Me.CboNotificar.SelectedValue = tb.Rows(0)("Notificar").ToString
                    'Se agrego el 9 de abril 2011
                    Me.CboMFI.SelectedValue = tb.Rows(0)("MFECINI").ToString
                    Me.CboMHI.SelectedValue = tb.Rows(0)("MHORINI").ToString
                    Me.CboMFF.SelectedValue = tb.Rows(0)("MFECFIN").ToString
                    Me.CboMHF.SelectedValue = tb.Rows(0)("MHORFIN").ToString
                    Me.TxtUbi.Text = tb.Rows(0)("Ubicacion").ToString

                    Habilitar(True)
                    Me.ModalPopupTer.Show()
                    UpdatePanel2.Update()
                End If
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtCodNew.Text + "]"
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                Dim tb As DataTable = Obj.GetbyPKDB(Me.CboFilVig.SelectedValue, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(1).ToString)
                If tb.Rows.Count > 0 Then
                    Me.TxtCodNew.Text = tb.Rows(0)("Cod_Act").ToString
                    Me.TxtNomNew.Text = tb.Rows(0)("Nom_Act").ToString
                    Me.CboTproc.SelectedValue = tb.Rows(0)("Cod_Tpro").ToString
                    Me.CboVig.SelectedValue = tb.Rows(0)("Vigencia").ToString
                    Me.CboTact.SelectedValue = tb.Rows(0)("Est_Proc").ToString
                    Me.TxtOrden.Text = tb.Rows(0)("Orden").ToString
                    Me.CboEstado.SelectedValue = tb.Rows(0)("Estado").ToString
                    Me.CboObligatorio.SelectedValue = tb.Rows(0)("Obligatorio").ToString
                    Me.CboOcupado.SelectedValue = tb.Rows(0)("Ocupado").ToString
                    Me.Cbodia_nohabil.SelectedValue = tb.Rows(0)("dia_nohabil").ToString
                    Me.CboNotificar.SelectedValue = tb.Rows(0)("Notificar").ToString

                    'Se agrego el 9 de abril 2011
                    Me.CboMFI.SelectedValue = tb.Rows(0)("MFECINI").ToString
                    Me.CboMHI.SelectedValue = tb.Rows(0)("MHORINI").ToString
                    Me.CboMFF.SelectedValue = tb.Rows(0)("MFECFIN").ToString
                    Me.CboMHF.SelectedValue = tb.Rows(0)("MHORFIN").ToString
                    Me.TxtUbi.Text = tb.Rows(0)("Ubicacion").ToString

                    Me.ModalPopupTer.Show()
                    Habilitar(False)
                End If
                Me.ModalPopupTer.Show()
                UpdatePanel2.Update()
        End Select
    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtCodNew.Enabled = b
        Me.TxtNomNew.Enabled = b
        Me.CboTproc.Enabled = b
        Me.CboTact.Enabled = b
        Me.TxtOrden.Enabled = b
        Me.CboVig.Enabled = b
        Me.CboEstado.Enabled = b
        Me.CboOcupado.Enabled = b
        Me.CboObligatorio.Enabled = b
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
                Me.MsgResult.Text = Obj.Insert(Me.TxtCodNew.Text, TxtNomNew.Text, CboTproc.SelectedValue, Me.CboVig.SelectedValue, Me.CboTact.SelectedValue, TxtOrden.Text, CboOcupado.SelectedValue, CboEstado.SelectedValue, CboObligatorio.SelectedValue, Me.Cbodia_nohabil.SelectedValue, Me.CboNotificar.SelectedValue, CboMFI.SelectedValue, CboMHI.SelectedValue, CboMFF.SelectedValue, CboMHF.SelectedValue, Me.TxtUbi.Text)

            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(1).ToString, Me.TxtCodNew.Text, Me.TxtNomNew.Text, Me.CboTproc.SelectedValue, Me.CboVig.SelectedValue, Me.CboTact.SelectedValue, Me.TxtOrden.Text, Me.CboOcupado.SelectedValue, Me.CboEstado.SelectedValue, Me.CboObligatorio.SelectedValue, Me.Cbodia_nohabil.SelectedValue, Me.CboNotificar.SelectedValue, CboMFI.SelectedValue, CboMHI.SelectedValue, CboMFF.SelectedValue, CboMHF.SelectedValue, Me.TxtUbi.Text)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            ' Me.Limpiar()
        End If
    End Sub

    Protected Sub Limpiar()
        Me.TxtCodNew.Text = ""
        Me.TxtNomNew.Text = ""
        Me.CboVig.SelectedIndex = 0
        Me.TxtOrden.Text = ""
        Me.CboTact.SelectedIndex = 0
        Me.CboTproc.SelectedIndex = 0
        'Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub

    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Delete(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(1).ToString)
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

    Protected Sub Chk_Vig_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_Vig.CheckedChanged
        Me.CboFilVig.Enabled = Chk_Vig.Checked
        Me.GridView1.DataBind()

    End Sub

    Protected Sub Chk_Tproc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_Tproc.CheckedChanged
        Me.CboFilTproc.Enabled = Chk_Tproc.Checked
        Me.GridView1.DataBind()
    End Sub

    Protected Sub LnkNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkNuevo.Click
        Me.Oper = "Nuevo"
        Me.SubT.Text = "Nuevo..."

        Me.Habilitar(True)
        Limpiar()

        Me.ModalPopupTer.Show()
        Me.SetFocus(Me.TxtCodNew)

    End Sub
End Class
