Imports System.Data
Partial Class CtrlUsr_grdCDP_grdCDP
    Inherits CtrlUsrComun

    Const NumCol As Integer = 3
#Region "Eventos"
    Public Event SelClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent SelClicked(sender, New EventArgs())
    End Sub

#End Region
#Region "Prpiedades"

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

    Property Num_Proc As String
        Set(ByVal value As String)
            ViewState("Num_Proc") = value
        End Set
        Get
            Return ViewState("Num_Proc")
        End Get
    End Property

#End Region


    Private obj As New CDP_PContratos

    Public Sub Limpiar()
        Me.Tabla_Vacia = True
        Me.Tabla = GetRecords()
        Me.LlenarGrid()
    End Sub

    Private Function GetRecords() As DataTable
        Dim dt As DataTable = New DataTable
        dt = obj.GetRecords(Me.Num_Proc)
        Return dt
    End Function

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
            Dim txtNewVal_Cdp As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewVal_Cdp"), TextBox)
            'Me.MsgResult.Text = Me.Num_Proc
            If IsNumeric(txtNewNro_Cdp.Text) And IsDate(txtNewFec_Cdp.Text) And IsNumeric(txtNewVal_Cdp.Text) Then
                Me.MsgResult.Text = obj.Insert(Me.Num_Proc, txtNewNro_Cdp.Text, CDate(txtNewFec_Cdp.Text), CDec(txtNewVal_Cdp.Text.Replace(".", ",")))
                MsgBox(MsgResult, obj.lErrorG)
                LlenarGrid()
                OnClick(sender)
            Else
                Me.MsgResult.Text = "Error: Verifique que los datos son correctos y que no hay campos vacios."
            End If
            MsgBox(MsgResult, obj.lErrorG)
        End If
    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grd.RowDeleting
        Me.MsgResult.Text = obj.Delete(Me.grd.DataKeys(e.RowIndex).Values(0).ToString(), Me.Num_Proc)
        MsgBox(MsgResult, obj.lErrorG)
        grd.EditIndex = -1
        OnClick(sender)
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
End Class
