Imports System.Data
Partial Class CtrlUsr_grdPolC_grdPolCN
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

    Dim valor As Boolean
    Private obj As New Polizas_Contrato
    Private pol As New PolizasContratos

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
    Public Function habilitar(ByVal valor As Boolean) As Boolean
        Me.TxtNPol.Enabled = valor
        Me.TxtValP.Enabled = valor
        Me.TxtFlim.Enabled = valor
        Me.CboAseg.Enabled = valor
        Me.CboPol.Enabled = valor
        Me.cboTipPol.Enabled = valor
        Me.BtnGuardar.Enabled = valor
        grd.Enabled = valor
        Return valor
    End Function
    Public Sub llenarCOmbo()
        HiddenField1.Value = Me.Proceso
        HiddenField2.Value = Me.Grupo
    End Sub
    Protected Sub RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs)

    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound

    End Sub

    Protected Sub RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grd.RowDeleting
        'Nro_Imp,Nro_Imp,Cod_Sop
        Dim Id_Pol As String = Me.grd.DataKeys(e.RowIndex).Values(0).ToString()
        Dim Cod_Pol As String = Me.grd.DataKeys(e.RowIndex).Values(1).ToString()
        Me.MsgResult.Text = obj.Delete(Me.Cod_Con, Cod_Pol, Id_Pol)
        If obj.lErrorG = True Then
            Me.MsgResult.Font.Bold = True
        Else
            Me.MsgResult.Font.Bold = False
        End If
        grd.EditIndex = -1

        LlenarGrid()


        Me.MsgBox(Me.MsgResult, obj.lErrorG)
    End Sub

    Protected Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub grd_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grd.RowCancelingEdit
        grd.EditIndex = -1
        LlenarGrid()
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim np As String
        Dim vp As Long
        np = TxtNPol.Text
        vp = Val(TxtValP.Text)
        Dim tp As String = Me.cboTipPol.SelectedValue 'IIf(Me.chkAmp.Checked = True, "A", "I")
        If IsDate(Me.TxtFlim.Text) Or IsDate(Me.TxtFlim2.Text) Then
            If CDate(Me.TxtFlim.Text) < CDate(Me.TxtFlim2.Text) Then
                Me.MsgResult.Text = obj.Insert(Me.Cod_Con, Me.CboPol.Text, Me.CboAseg.Text, np, vp, CDate(Me.TxtFlim.Text), tp, CDate(Me.TxtFlim2.Text))
                Me.LlenarGrid()
                Me.MsgBox(Me.MsgResult, obj.lErrorG)
            Else
                Me.MsgResult.Text = "Fecha de Vencimiento debe ser mayor que la Fecha Inicial"
                Me.MsgBox(Me.MsgResult, True)
            End If
            
        Else
            Me.MsgResult.Text = "Fecha válida"
            Me.MsgBox(Me.MsgResult, True)

        End If



    End Sub

End Class
