Imports System.Data
Partial Class CtrlUsr_grdIntC_grdIntC
    Inherits CtrlUsrComun
    Dim NumCol As Integer = 6
    Dim obj As New CtrLegalizacionInt
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
       
    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound

    End Sub

    Protected Sub RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grd.RowDeleting

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

        Dim TxtObs_Int As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtEditObs_Int"), TextBox)
        Dim cboEst_Int As DropDownList = DirectCast(grd.Rows(e.RowIndex).FindControl("CboEditEst_int"), DropDownList)



        Dim ie As New EInterventores_Contrato

        ie.Cod_Con = Me.Cod_Con
        ie.Ide_Int = Me.grd.DataKeys(e.RowIndex).Values(0).ToString()
        ie.Obs_Int = TxtObs_Int.Text
        ie.Est_Int = cboEst_Int.SelectedValue


        Me.MsgResult.Text = obj.Update(ie)
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
        Me.MsgResult.Text = obj.Insert(Me.Cod_Con, txtIde.Text, "AC", txtNewObs_Int.Text, CboNewTip_Int.SelectedValue, txtCodCon.Text)
        If obj.lErrorG = True Then
            Me.MsgResult.Font.Bold = True
        Else
            Me.MsgResult.Font.Bold = False
            grd.EditIndex = -1
            LlenarGrid()
            txtIde.Text = ""
            txtNom.Text = ""
            txtCodCon.Text = ""
            txtNewObs_Int.Text = "."
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

    Protected Sub CboNewTip_Int_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CboNewTip_Int.SelectedIndexChanged
        Dim s As Boolean = CboNewTip_Int.SelectedValue = "I"
        Panel1.Visible = s
        txtIde.Enabled = Not s
        txtNom.Enabled = Not s
        BtnBuscar.Enabled = Not s
        



    End Sub

    Protected Sub txtCodCon_TextChanged(sender As Object, e As System.EventArgs) Handles txtCodCon.TextChanged
        Dim c As New EContratos
        Dim s As Boolean = (CboNewTip_Int.SelectedValue = "I")
        If s Then
            c = obj.getContrato(Me.txtCodCon.Text)
            If Not c Is Nothing Then
                txtIde.Text = c.Ide_Con
                txtNom.Text = c.Nom_Ter
            Else
                txtIde.Text = ""
                txtNom.Text = ""
            End If
            
        Else
            txtIde.Text = ""
            txtNom.Text = ""
            txtNewObs_Int.Text = "."
        End If
    End Sub
End Class
