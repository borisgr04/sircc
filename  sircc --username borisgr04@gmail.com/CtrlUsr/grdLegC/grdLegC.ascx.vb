Imports System.Data
Partial Class CtrlUsr_grdLegC_grdLegC
    Inherits CtrlUsrComun
    Dim NumCol As Integer = 6

    Property Enabled() As Boolean
        Get
            Return Me.grd.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me.grd.Enabled = value
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
    Property Proceso As String
        Set(ByVal value As String)
            ViewState("Proceso") = value
        End Set
        Get
            Return ViewState("Proceso")
        End Get
    End Property
    Property Grupo As String
        Set(ByVal value As String)
            ViewState("Grupo") = value
        End Set
        Get
            Return ViewState("Grupo")
        End Get
    End Property

    Public Sub Limpiar()
        Me.LlenarGrid()
    End Sub

    Private Function GetRecords() As DataTable
        Dim obj As New DContratos
        Dim dt As DataTable = New DataTable
        dt = obj.GetRecords(Me.Cod_Con)
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
            grd.Rows(0).Cells(0).ColumnSpan = Me.NumCol
            grd.Rows(0).Cells(0).Text = "No hay registros"
        End If
    End Sub

    Protected Sub RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs)

    End Sub


    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound

    End Sub

    Protected Sub RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grd.RowUpdating
        Dim obj As New DContratos
        Dim txtEditFec_Apr_Pol As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtEditFec_Apr_Pol"), TextBox)
        Dim txtEditRes_Apr_Pol As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtEditRes_Apr_Pol"), TextBox)
        Dim CboEditLegalizado As DropDownList = DirectCast(grd.Rows(e.RowIndex).FindControl("CboEditLegalizado"), DropDownList)
        Dim lbEditTipo As Label = DirectCast(grd.Rows(e.RowIndex).FindControl("lbEditTipo"), Label)
        Dim CboExPol As DropDownList = DirectCast(grd.Rows(e.RowIndex).FindControl("CboExPol"), DropDownList)
        Dim Docu As String = Me.grd.DataKeys(e.RowIndex).Values(0).ToString()
        If IsDate(txtEditFec_Apr_Pol.Text) Then
            Me.MsgResult.Text = obj.Update(Docu, CDate(txtEditFec_Apr_Pol.Text), CboEditLegalizado.SelectedValue, lbEditTipo.Text, Me.Proceso, Me.Grupo, CboExPol.SelectedValue, txtEditRes_Apr_Pol.Text)
            MsgBox(MsgResult, obj.lErrorG)
            Me.grd.EditIndex = -1
            LlenarGrid()
        Else
            Me.MsgResult.Text = "Debe seleccionar o escribir una fecha valida."
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub

    Protected Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

    End Sub

    Protected Sub grd_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grd.RowCancelingEdit
        grd.EditIndex = -1
        LlenarGrid()
    End Sub
End Class
