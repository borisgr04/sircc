Imports System.Data
Imports Telerik.Web.UI

Partial Class CtrlUsr_grdCDPC_grdCDPC
    Inherits CtrlUsrComun
    Const NumCol As Integer = 3
    Property Tabla_Vacia() As Boolean
        Get
            Return ViewState("_tVaciaCDP")
        End Get
        Set(ByVal value As Boolean)
            ViewState("_tVaciaCDP") = value
        End Set
    End Property
    Property Tabla() As DataTable
        Get
            Return ViewState("_tCDP")
        End Get
        Set(ByVal value As DataTable)
            ViewState("_tCDP") = value
            LlenarGrid()
        End Set
    End Property

    Property Enabled() As Boolean
        Get
            Return Me.grd.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me.grd.Enabled = value
        End Set
    End Property


    Private obj As New CDP_Contratos

    Property Cod_Con As String
        Set(ByVal value As String)
            ViewState("Cod_Con") = value
        End Set
        Get
            Return ViewState("Cod_Con")
        End Get
    End Property

    Public Sub Limpiar()
        Me.Tabla_Vacia = True
        Me.Tabla = GetRecords()
        Me.LlenarGrid()
    End Sub

    Private Function GetRecords() As DataTable
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
            grd.Rows(0).Cells(0).ColumnSpan = 4
            grd.Rows(0).Cells(0).Text = "No hay registros"
        End If
    End Sub

    Protected Sub RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs)

    End Sub

    Protected Sub RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grd.RowCommand
        If e.CommandName.Equals("AddNew") Then
            Dim txtNewNro_Cdp As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewNro_Cdp"), TextBox)
            Dim txtNewFec_Cdp As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewFec_Cdp"), TextBox)
            Dim txtNewVal_Cdp As RadNumericTextBox = DirectCast(grd.FooterRow.FindControl("txtNewVal_Cdp"), RadNumericTextBox)
            'Me.MsgResult.Text = Me.Cod_Con
            Me.MsgResult.Text = obj.Insert(Me.Cod_Con, txtNewNro_Cdp.Text, CDate(txtNewFec_Cdp.Text), Me.valor_dec(txtNewVal_Cdp.Text))
            MsgBox(MsgResult, obj.lErrorG)
            LlenarGrid()
        End If
    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound

    End Sub

    Protected Sub RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grd.RowDeleting
        'customer.Delete(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString()));
        Me.MsgResult.Text = obj.Delete(Me.Cod_Con, Me.grd.DataKeys(e.RowIndex).Values(0).ToString())

        grd.EditIndex = -1
        MsgBox(MsgResult, obj.lErrorG)

        LlenarGrid()
    End Sub

    Protected Sub RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grd.RowUpdating
        'Dim txtNro_Cdp As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtNro_Cdp"), TextBox)
        'Dim txtFec_CDP As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtFec_Cdp"), TextBox)
        'Dim txtVal_CDP As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtVal_Cdp"), TextBox)
        'Dim dt As DataTable = Me.Tabla
        ''dtrow("item") = "a"
        'dt.Rows.Item(e.RowIndex)("Nro_Cdp") = txtNro_Cdp.Text
        'dt.Rows.Item(e.RowIndex)("Fec_Cdp") = txtFec_CDP.Text
        'dt.Rows.Item(e.RowIndex)("Val_Cdp") = txtVal_CDP.Text
        'dt.AcceptChanges()
        'Me.Tabla = dt
        'grd.EditIndex = -1
        'LlenarGrid()
    End Sub

    Protected Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

    End Sub

    Protected Sub grd_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grd.RowCancelingEdit
        grd.EditIndex = -1
        LlenarGrid()
    End Sub
    Private Function valor_dec(ByVal v As String) As Decimal
        Return v.Replace(".", ",")
    End Function

End Class
