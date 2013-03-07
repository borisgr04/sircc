Imports System.Data
Partial Class CtrlUsr_grdIntC_grdIntC
    Inherits CtrlUsrComun
    Dim NumCol As Integer = 6

    Property Enabled() As Boolean
        Get
            Return Me.grd.Enabled
        End Get
        Set(ByVal value As Boolean)
            habilitar(value)
        End Set
    End Property




    Property Cod_Con As String
        Set(ByVal value As String)
            ViewState("Cod_Con") = value
        End Set
        Get
            Return ViewState("Cod_Con")
        End Get
    End Property

    Public Sub Limpiar()
        Me.LlenarGrid()
    End Sub
    Public Function habilitar(ByVal valor As Boolean) As Boolean
        Me.txtIde.Enabled = valor
        Me.txtNewObs_Int.Enabled = valor
        Me.txtNom.Enabled = valor
        Me.CboNewTip_Int.Enabled = valor
        Me.BtnAgregar.Enabled = valor
        Me.BtnBuscar.Enabled = valor
        grd.Enabled = valor
        Return valor
    End Function
    Private Function GetRecords() As DataTable
        Dim obj As New Interventores_Contrato
        Dim dt As DataTable = New DataTable
        dt = obj.GetRecords(Me.Cod_Con)
        Return dt
    End Function

    'Private Function Create_Table() As DataTable
    '    Dim dt As DataTable = New DataTable
    '    Dim column As DataColumn = New DataColumn
    '    dt.Columns.Add("Nro_Cdp", Type.GetType("System.Int32"))
    '    dt.Columns.Add("Fec_Cdp", Type.GetType("System.DateTime"))
    '    dt.Columns.Add("Val_Cdp", Type.GetType("System.Decimal"))
    '    dt.AcceptChanges()
    '    Me.Tabla_Vacia = True
    '    Return dt
    'End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Limpiar()
        End If
    End Sub

    Protected Sub RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grd.RowEditing
        grd.EditIndex = e.NewEditIndex
        LlenarGrid()
    End Sub

    Public Sub LlenarGrid()
        Dim dtCustomer As DataTable = Me.GetRecords()
        grd.DataSource = dtCustomer
        grd.DataBind()
        If dtCustomer.Rows.Count < 1 Then
            dtCustomer.Rows.Clear()
            dtCustomer.Rows.Add(dtCustomer.NewRow())
            grd.DataSource = dtCustomer
            grd.DataBind()
            grd.Rows(0).Cells.Clear()
            grd.Rows(0).Cells.Add(New TableCell())
            grd.Rows(0).Cells(0).ColumnSpan = Me.NumCol
            grd.Rows(0).Cells(0).Text = "No hay registros"
        End If
    End Sub

    Protected Sub RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs)

    End Sub

    Protected Sub RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grd.RowCommand
        'If e.CommandName.Equals("AddNew") Then
        '    Dim txtNewIde_Int As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewIde_Int"), TextBox)
        '    Dim TxtnewObs_Int As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewObs_Int"), TextBox)
        '    Dim cboNewEst_Int As DropDownList = DirectCast(grd.FooterRow.FindControl("CboNewEst_Int"), DropDownList)
        '    Dim CboNewTip_Int As DropDownList = DirectCast(grd.FooterRow.FindControl("CboNewTip_Int"), DropDownList)
        '    Me.MsgResult.Text = obj.Insert(Me.Cod_Con, txtNewIde_Int.Text, cboNewEst_Int.SelectedValue, TxtnewObs_Int.Text, CboNewTip_Int.SelectedValue)
        '    If obj.lErrorG = True Then
        '        Me.MsgResult.Font.Bold = True
        '    Else
        '        Me.MsgResult.Font.Bold = False
        '        grd.EditIndex = -1
        '        LlenarGrid()
        '    End If


        'End If
    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound

    End Sub

    Protected Sub RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grd.RowDeleting
        Dim obj As New Interventores_Contrato
        Dim Ide_Int As String = Me.grd.DataKeys(e.RowIndex).Values(0).ToString()

        Me.MsgResult.Text = obj.Delete(Me.Cod_Con, Ide_Int)
        If obj.lErrorG = True Then
            Me.MsgResult.Font.Bold = True
        Else
            Me.MsgResult.Font.Bold = False
            grd.EditIndex = -1
            LlenarGrid()
        End If
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        
    End Sub

    Protected Sub RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grd.RowUpdating
        Dim obj As New Interventores_Contrato
        Dim TxtEditObs_Int As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtEditObs_Int"), TextBox)
        Dim cboEditEst_Int As DropDownList = DirectCast(grd.Rows(e.RowIndex).FindControl("CboEditEst_int"), DropDownList)
        Dim CboEditTip_Int As DropDownList = DirectCast(grd.Rows(e.RowIndex).FindControl("CboEditTip_Int"), DropDownList)
        Dim Ide_Int_Old As String = Me.grd.DataKeys(e.RowIndex).Values(0).ToString()

        Dim x As String = TxtEditObs_Int.Text
        Dim y As String = cboEditEst_Int.Text
        Dim z As String = CboEditTip_Int.Text
        Me.MsgResult.Text = obj.Update(Me.Cod_Con, Ide_Int_Old, cboEditEst_Int.Text, TxtEditObs_Int.Text, CboEditTip_Int.SelectedValue)
        If obj.lErrorG = True Then
            Me.MsgResult.Font.Bold = True
        Else
            Me.MsgResult.Font.Bold = False
            grd.EditIndex = -1
            LlenarGrid()
        End If


        Me.MsgBox(Me.MsgResult, obj.lErrorG)
    End Sub

    Protected Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

    End Sub

    Protected Sub grd_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grd.RowCancelingEdit
        grd.EditIndex = -1
        LlenarGrid()
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.ModalPopup.Show()
    End Sub



    Protected Sub txtIde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIde.TextChanged
        buscar()
    End Sub

    Sub buscar()
        Dim obj As New Terceros
        Dim dt As DataTable = obj.GetByIde(Me.txtIde.Text)
        If dt.Rows.Count > 0 Then
            Me.txtNom.Text = dt.Rows(0)("Nom_Ter").ToString
        End If
    End Sub

    Protected Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim obj As New Interventores_Contrato
        Me.MsgResult.Text = obj.Insert(Me.Cod_Con, txtIde.Text, "AC", txtNewObs_Int.Text, CboNewTip_Int.SelectedValue)
        If obj.lErrorG = True Then
            Me.MsgResult.Font.Bold = True
        Else
            Me.MsgResult.Font.Bold = False
            grd.EditIndex = -1
            LlenarGrid()
        End If

        Me.MsgBox(Me.MsgResult, obj.lErrorG)
    End Sub

    Protected Sub AdmTercero1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdmTercero1.SelClicked
        Me.txtIde.Text = AdmTercero1.Nit
        Me.ModalPopup.Hide()
        buscar()
        Me.UpdatePanel4.Update()

        'Me.txtNom.Text = AdmTercero1.no
    End Sub
End Class
