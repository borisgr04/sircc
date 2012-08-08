﻿Imports System.Data
Partial Class CtrlUsr_grdOblig_grdOblig
    Inherits CtrlUsrComun
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

    Private obj As New PObligaciones

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
            Dim txtNewOblig As TextBox = DirectCast(grd.FooterRow.FindControl("txtNewOblig"), TextBox)
            If txtNewOblig.Text = "" Then
                Me.MsgResult.Text = "No puede agregar un dato en en blanco"
                MsgBoxAlert(MsgResult, obj.lErrorG)
            Else
                Me.MsgResult.Text = obj.Insert(Me.Num_Proc, txtNewOblig.Text)
                MsgBox(MsgResult, obj.lErrorG)
                LlenarGrid()
            End If
        End If
    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound

    End Sub

    Protected Sub RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grd.RowDeleting
        'customer.Delete(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString()));
        'Me.Label1.Text = Me.grd.DataKeys(e.RowIndex).Values(0).ToString()
        Me.MsgResult.Text = obj.Delete(Me.grd.DataKeys(e.RowIndex).Values(0).ToString(), Me.Num_Proc)
        MsgBox(MsgResult, obj.lErrorG)

        LlenarGrid()
    End Sub

    Protected Sub RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grd.RowUpdating

        Dim txtOblig As TextBox = DirectCast(grd.Rows(e.RowIndex).FindControl("txtOblig"), TextBox)
        If txtOblig.Text = "" Then
            Me.MsgResult.Text = "No digitado ninguna obligación"
            MsgBoxAlert(MsgResult, obj.lErrorG)
        Else
            Me.MsgResult.Text = obj.Update(Me.Num_Proc, txtOblig.Text, Me.grd.DataKeys(e.RowIndex).Values(0).ToString())
            MsgBox(MsgResult, obj.lErrorG)
            If Not obj.lErrorG Then
                grd.EditIndex = -1
            End If
            LlenarGrid()
        End If
        

    End Sub

    Protected Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectedIndexChanged

    End Sub

    Protected Sub grd_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grd.RowCancelingEdit
        grd.EditIndex = -1
        LlenarGrid()
    End Sub
End Class