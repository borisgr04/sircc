Imports System.Data
Partial Class CtrlUsr_grdRP_grdRP
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

    Private obj As New CtrLegalizacion_RP

    Property Cod_Con As String
        Set(ByVal value As String)
            ViewState("Cod_Con") = value
        End Set
        Get
            Return ViewState("Cod_Con")
        End Get
    End Property

    Public Sub Limpiar()
        'Me.Tabla_Vacia = True
        'Me.Tabla = GetRecords()
        Me.LlenarGrid()
    End Sub

    Private Function GetRecords() As DataTable
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

    Protected Sub RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grd.RowCommand
        If e.CommandName.Equals("AddNew") Then
            Dim txtNewNro_RP As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewNro_Rp"), TextBox)
            Dim txtNewFec_RP As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewFec_Rp"), TextBox)
            Dim txtNewVal_RP As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewVal_Rp"), TextBox)
            Dim cboNewDoc_Sop As DropDownList = DirectCast(grd.FooterRow.FindControl("CboNewDoc_Sop"), DropDownList)
            'Me.MsgResult.Text = Me.Cod_Con
            If Not IsDate(txtNewFec_RP.Text) Then
                Me.MsgResult.Text = "Fecha No Válida"
                Me.MsgBox(Me.MsgResult, True)
                Return
            End If
            Me.MsgResult.Text = obj.Insert(Me.Cod_Con, txtNewNro_RP.Text, CDate(txtNewFec_RP.Text), CDec(txtNewVal_RP.Text), Me.Vigencia_Cookie, cboNewDoc_Sop.SelectedValue)

            If obj.lErrorG = False Then
                LlenarGrid()
            End If

            Me.MsgBox(Me.MsgResult, obj.lErrorG)
        End If
    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound

    End Sub

    Protected Sub RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grd.RowDeleting

        Me.MsgResult.Text = obj.Delete(Me.Cod_Con, Me.grd.DataKeys(e.RowIndex).Values(0).ToString())
        If obj.lErrorG = True Then
            Me.MsgResult.Font.Bold = True
        Else
            Me.MsgResult.Font.Bold = False
        End If
        grd.EditIndex = -1

        LlenarGrid()


        Me.MsgBox(Me.MsgResult, obj.lErrorG)

    End Sub

    Protected Sub RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grd.RowUpdating
   
    End Sub

    Protected Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

    End Sub

    Protected Sub grd_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grd.RowCancelingEdit
        grd.EditIndex = -1
        LlenarGrid()
    End Sub

    End Class
