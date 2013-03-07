﻿Imports System.Data
Partial Class CtrlUsr_grdOblig_grdProy
    Inherits CtrlUsrComun

#Region "Eventos del control"

    Public Event Guardar As EventHandler

    Public Property Num_Proy() As String
        Get
            Return ViewState("Num_Proy")
        End Get
        Set(ByVal value As String)
            ViewState("Num_Proy") = value
        End Set
    End Property
    Protected Overridable Sub OnClick(ByVal sender As Object)
        If Oper = "Guardar" Then
            RaiseEvent Guardar(sender, New EventArgs())
        End If
    End Sub
#End Region
    Property Tabla_Vacia() As Boolean
        Get
            Return ViewState("_tObligVacia")
        End Get
        Set(ByVal value As Boolean)
            ViewState("_tObligVacia") = value
        End Set
    End Property

    Property Tabla() As DataTable
        Get
            Return DirectCast(ViewState("_tOblig"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            ViewState("_tOblig") = value
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

    Private obj As New PProyectos

    Property Num_Proc As String
        Set(ByVal value As String)
            ViewState("Num_Proc") = value
        End Set
        Get
            Return ViewState("Num_Proc")
        End Get
    End Property

    Public Sub Limpiar()
        Me.Tabla_Vacia = True
        Me.Tabla = GetRecords()
        Me.LlenarGrid()
    End Sub

    Private Function GetRecords() As DataTable
        Dim dt As DataTable = New DataTable
        dt = obj.GetbyNum_Proc(Me.Num_Proc)
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
            Dim txtNewProy As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewProyecto"), TextBox)
            Me.MsgResult.Text = obj.Insert(txtNewProy.Text, Me.Num_Proc)
            LlenarGrid()
        End If

    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound

    End Sub

    Protected Sub RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grd.RowDeleting
        'customer.Delete(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString()));
        'Me.Label1.Text = Me.grd.DataKeys(e.RowIndex).Values(0).ToString()
        Me.MsgResult.Text = obj.Delete(Me.grd.DataKeys(e.RowIndex).Values(0).ToString(), Me.Num_Proc)
        If obj.lErrorG = True Then
            Me.MsgResult.Font.Bold = True
        Else
            Me.MsgResult.Font.Bold = False
        End If
        grd.EditIndex = -1
        LlenarGrid()
    End Sub

    Protected Sub RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grd.RowUpdating
        'Dim txtOblig As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtOblig"), TextBox)
        'Dim dt As DataTable = Me.Tabla
        ''dtrow("item") = "a"
        'dt.Rows.Item(e.RowIndex)("Des_Oblig") = txtOblig.Text
        'dt.AcceptChanges()
        'Me.Tabla = dt
        'grd.EditIndex = -1
        LlenarGrid()
    End Sub

    Protected Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

    End Sub

    Protected Sub grd_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grd.RowCancelingEdit
        grd.EditIndex = -1
        LlenarGrid()
    End Sub

    Protected Sub ConProyectos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConProyectos1.SelClicked
        Me.TxtProyecto.Text = ConProyectos1.Num_Proy
    End Sub

    Protected Sub TxtProyecto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProyecto.TextChanged
        buscar()
    End Sub
    Sub buscar()
        Dim obj As New Proyectos
        Dim dt As DataTable
        dt = obj.GetbyPk(Me.TxtProyecto.Text)
        Me.TxtNomProyecto.Text = dt.Rows(0).Item("Nombre_Proyecto").ToString
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Me.ModalPopupSolicitudes.Show()
    End Sub

    Protected Sub IbtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnGuardar.Click
        Oper = "Guardar"
        Num_Proy = Me.TxtProyecto.Text
        OnClick(sender)
        grd.DataBind()
    End Sub
End Class
