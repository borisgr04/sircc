Imports System.Data
Partial Class CtrlUsr_grdAdiC_grdAdiC
    Inherits CtrlUsrComun
    Dim NumCol As Integer = 6


#Region "Eventos del control"
    Dim Total As Integer
    Dim PlazoT As Integer

    Public Event RadClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent RadClicked(sender, New EventArgs())
    End Sub
#End Region

    Property Enabled() As Boolean
        Get
            Return Me.grd.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me.grd.Enabled = value
        End Set
    End Property


    Private obj As New Adiciones

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

    Private Function GetRecords() As DataTable
        Dim dt As DataTable = New DataTable
        dt = obj.GetRecordsUlt(Me.Cod_Con)
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
        dtTAdiciones.DataSource = obj.GetConsolidado(Me.Cod_Con)
        dtTAdiciones.DataBind()
        'If dtCustomer.Rows.Count < 1 Then
        '    dtCustomer.Rows.Clear()
        '    dtCustomer.Rows.Add(dtCustomer.NewRow())
        '    grd.DataSource = dtCustomer
        '    grd.DataBind()
        '    grd.Rows(0).Cells.Clear()
        '    grd.Rows(0).Cells.Add(New TableCell())
        '    grd.Rows(0).Cells(0).ColumnSpan = Me.NumCol
        '    grd.Rows(0).Cells(0).Text = "No hay registros"
        'End If
    End Sub

    Protected Sub RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs)

    End Sub

    Protected Sub RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grd.RowCommand
        Dim obj As New Adiciones
        Me.Oper = e.CommandName





        If Oper = "eliminar" Then
            Dim nro_adi As String = Cod_Con + "-" + e.CommandArgument.PadLeft(2, "0")
            MsgResult.Text = obj.Delete(nro_adi) + nro_adi
            MsgBox(MsgResult, obj.lErrorG)
            LlenarGrid()
        End If



    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If

        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.Total = 0
                Me.PlazoT = 0
            Case DataControlRowType.DataRow
                Me.Total += CDec(DataBinder.Eval(e.Row.DataItem, "VAL_ADI"))
                Me.PlazoT += CDec(DataBinder.Eval(e.Row.DataItem, "PLA_EJE_ADI"))
                'Me.TCan += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(4).Text = FormatCurrency(Me.Total.ToString)
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
                e.Row.Cells(3).Text = FormatNumber(Me.PlazoT.ToString)
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grd.RowDeleting
        'Nro_Imp,Nro_Imp,Cod_Sop
        Dim Nro_imp As String = Me.grd.DataKeys(e.RowIndex).Values(0).ToString()
        Dim Cod_Sop As String = Me.grd.DataKeys(e.RowIndex).Values(1).ToString()
        'Me.MsgResult.Text = obj.Delete(Me.Cod_Con, Nro_imp, Cod_Sop)
        If obj.lErrorG = True Then
            Me.MsgResult.Font.Bold = True
        Else
            Me.MsgResult.Font.Bold = False
            grd.EditIndex = -1
            LlenarGrid()
        End If


    End Sub

    Protected Sub RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grd.RowUpdating
        'Dim txtEditFec_Apr_Pol As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtEditFec_Apr_Pol"), TextBox)
        'Dim CboEditLegalizado As DropDownList = DirectCast(grd.Rows(e.RowIndex).FindControl("CboEditLegalizado"), DropDownList)
        'Dim lbEditTipo As Label = DirectCast(grd.Rows(e.RowIndex).FindControl("lbEditTipo"), Label)
        'Dim Docu As String = Me.grd.DataKeys(e.RowIndex).Values(0).ToString()
        'Me.MsgResult.Text = obj.Update(Docu, CDate(txtEditFec_Apr_Pol.Text), CboEditLegalizado.SelectedValue, lbEditTipo.Text)
        'Me.grd.EditIndex = -1
        'LlenarGrid()
        Dim CboeditTipAdi As DropDownList = DirectCast(grd.FooterRow.FindControl("CboeditTipAdi"), DropDownList)
        Dim txteditVal_Adi As TextBox = DirectCast(grd.FooterRow.FindControl("txteditVal_Adi"), TextBox)
        Dim txteditPla_Eje_Adi As TextBox = DirectCast(grd.FooterRow.FindControl("txteditPla_Eje_Adi"), TextBox)
        Dim txteditFec_Sus_Adi As TextBox = DirectCast(grd.FooterRow.FindControl("txteditFec_Sus_Adi"), TextBox)
        'Me.MsgResult.Text = obj.Insert(Me.Cod_Con, CDate(txtnewFec_Sus_Adi.Text), CInt(txtnewPla_Eje_Adi.Text), CDec(txtnewVal_Adi.Text), CbonewTipAdi.SelectedValue, Vigencia_Cookie)
        If obj.lErrorG = True Then
            Me.MsgResult.Font.Bold = True
        Else
            Me.LbNro_Adi.Text = obj.Nro_Adi
            Me.MsgResult.Font.Bold = False
            grd.EditIndex = -1
            LlenarGrid()
        End If
    End Sub

    Protected Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

    End Sub

    Protected Sub grd_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grd.RowCancelingEdit
        grd.EditIndex = -1
        LlenarGrid()
    End Sub

  

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Me.TxtPla.Text = 0
        Me.TxtVal.Text = 0
        Me.TxtPla.Enabled = True
        Me.TxtVal.Enabled = True
        Select Case Me.DropDownList1.SelectedValue
            Case 2
                Me.TxtPla.Enabled = False
            Case 3
                Me.TxtVal.Enabled = False
        End Select
    End Sub

    Sub Radicar()
        If Not IsDate(Me.TxtFec.Text) Then
            Me.MsgResult.Text = "Fecha No Válida"
            MsgBoxAlert(MsgResult, True)
            Return
        End If
        Select Case Me.DropDownList1.SelectedValue
            Case 1
                'Me.TxtPla.Enabled = False
                If (CDec(TxtVal.Text) = 0) Or (CDec(TxtVal.Text) = 0) Then
                    Me.MsgResult.Text = "Ni el Valor de la Adición ni El Plazo  pueden ser Cero. Verifique los datos."
                    MsgBoxAlert(MsgResult, True)
                    Return
                End If
            Case 2
                'Me.TxtPla.Enabled = False
                If CDec(TxtVal.Text) = 0 Then
                    Me.MsgResult.Text = "El Valor de la Adición, no puede ser Cero. Verifique los datos."
                    MsgBoxAlert(MsgResult, True)
                    Return
                End If
            Case 3
                'Me.TxtVal.Enabled = False
                If CDec(TxtPla.Text) = 0 Then
                    Me.MsgResult.Text = "El Plazo de la Adición, no puede ser Cero. Verifique los datos."
                    MsgBoxAlert(MsgResult, True)
                    Return
                End If
        End Select



        Me.MsgResult.Text = obj.Insert(Me.Cod_Con, CDate(Me.TxtFec.Text), CInt(TxtPla.Text), Publico.PuntoPorComa(TxtVal.Text), DropDownList1.SelectedValue, Vigencia_Cookie, TxtObs.Text)
        If Not obj.lErrorG = True Then
            Me.LbNro_Adi.Text = obj.Nro_Adi
            Me.MsgResult.Font.Bold = False
            Me.TxtVal.Text = 0
            Me.TxtPla.Text = 0
            Me.TxtFec.Text = ""
            grd.EditIndex = -1
            LlenarGrid()
        End If
        MsgBox(MsgResult, obj.lErrorG)

    End Sub
    Protected Sub BtnGuardar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardar.Click
        Radicar()
        OnClick(sender)
    End Sub
End Class
