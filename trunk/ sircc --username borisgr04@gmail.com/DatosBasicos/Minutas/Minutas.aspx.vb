﻿Imports system.Data
Partial Class DatosBasicos_Minutas_Minutas
    Inherits PaginaComun
    Dim Obj As CMinutas = New CMinutas

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            FillCustomerInGrid()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If

        Me.DropDownList1.Items.Add("Procesos")
        


    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Oper
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."

                Me.Habilitar(True)
                Limpiar()

                Me.ModalPopupTer.Show()
                'Me.TxtCodNew.ReadOnly = True
                Me.SetFocus(Me.txtnombNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    Me.TxtcodiNew.Text = tb.Rows(0)("CMIN_CODI").ToString
                    Me.txtnombNew.Text = tb.Rows(0)("CMIN_NOMB").ToString
                    'Me.txtdatoNew.Text = tb.Rows(0)("CMIN_DATO").ToString
                    'Me.txtbodyNew.Text = tb.Rows(0)("CMIN_BODY").ToString
                    Me.Editor1.Content = tb.Rows(0)("CMIN_ENCA").ToString
                    Me.txtcampNew.Text = tb.Rows(0)("CMIN_CAMP").ToString
                    Me.txtvistaNew.Text = tb.Rows(0)("CMIN_VISTA").ToString
                    Me.HdPk1.Value = tb.Rows(0)("CMIN_CODI").ToString
                    Habilitar(True)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtcodiNew.Text + "]"
            Case "Plantilla"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                Me.MultiView1.ActiveViewIndex = 1
                Me.Editor1.Content = tb.Rows(0)("CMIN_BODY")
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    'Me.TxtcodiNew.Text = tb.Rows(0)("CORR_CODI").ToString
                    'Me.txtnombNew.Text = tb.Rows(0)("CORR_NOMB").ToString
                    'Me.txtdatoNew.Text = tb.Rows(0)("CORR_DATO").ToString
                    'Me.txtbodyNew.Text = tb.Rows(0)("CORR_BODY").ToString
                    'Me.txtcampNew.Text = tb.Rows(0)("CORR_CAMP").ToString
                    'Me.txtvistaNew.Text = tb.Rows(0)("CORR_VISTA").ToString
                    'Me.HdPk1.Value = tb.Rows(0)("CORR_CODI").ToString
                    Habilitar(False)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0




        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtcodiNew.Enabled = b
        Me.txtnombNew.Enabled = b
        Me.txtdatoNew.Enabled = b
        'Me.txtbodyNew.Enabled = b
        Me.txtcampNew.Enabled = b
        Me.txtvistaNew.Enabled = b
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

        Select Case Oper
            Case "Nuevo"
                '    Me.MsgResult.Text = Obj.Insert(Me.TxtcodiNew.Text, Me.txtnombNew.Text, Me.txtdatoNew.Text, Me.txtbodyNew.Text, Me.txtcampNew.Text, Me.txtvistaNew.Text)
            Case "Editar"
                '   Me.MsgResult.Text = Obj.Update(Me.HdPk1.Value, Me.TxtcodiNew.Text, Me.txtnombNew.Text, Me.txtdatoNew.Text, Me.txtbodyNew.Text, Me.txtcampNew.Text, Me.txtvistaNew.Text)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If



    End Sub

    Protected Sub Limpiar()
        Me.TxtcodiNew.Text = ""
        Me.txtnombNew.Text = ""
        Me.txtdatoNew.Text = ""
        'Me.txtbodyNew.Text = ""
        Me.txtcampNew.Text = ""
        Me.txtvistaNew.Text = ""

        'Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub



    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub


    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.MsgResult.Text = Obj.Delete(Me.TxtcodiNew.Text)
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
    End Sub

    Protected Sub GridView1_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub BtnCan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCan.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub BtnGuardarM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardarM.Click
        MsgResult.Text = Obj.UpdateMinuta(Me.GridView1.SelectedValue, Me.Editor1.Content)
        Me.MsgBox(MsgResult, Obj.lErrorG)
    End Sub
    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub
End Class
