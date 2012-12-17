Imports System.Data
Imports System.IO
Partial Class Procesos_GProcesosN_ItemObjeto
    Inherits PaginaComun


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            FillCustomerInGrid()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
    End Sub


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Me.DetPContrato1.CodigoPContrato = Request("Num_Proc")
            Me.DetPContrato1.Grupo = Request("Grupo")
            Me.DetPContrato1.Buscar(Request("Grupo"))
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub grdInformes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdInformes.RowCommand
        Dim Obj As New PObjetos_Items
        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1
        Me.IBtnEliminar.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Select Case Me.Oper
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."
                Me.Habilitar(True)

                Limpiar()
                Me.ModalPopupTer.Show()
                Me.TxtIde.Enabled = True
                Me.SetFocus(Me.TxtDes.Text)
            Case "Editar"

                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.grdInformes.SelectedIndex = index
                If Obj.GetbyPk(Me.DetPContrato1.CodigoPContrato, Me.DetPContrato1.Grupo, grdInformes.DataKeys(index).Values(0).ToString()) Then
                    Try
                        Me.TxtIde.Text = Obj.Id_Item
                        TxtDes.Text = Obj.Desc_Item
                        TxtCan.Text = Obj.Can_Item
                        CboUnidad.SelectedValue = Obj.Uni_Item
                        TxtValUni.Text = Obj.Val_Uni_Item
                        TxtIva.Text = Obj.Iva_Item
                        Me.ModalPopupTer.Show()
                        Habilitar(True)
                    Catch ex As Exception
                        MsgResult.Text = ex.Message
                        MsgBox(MsgResult, True)
                    End Try
                End If
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtIde.Text + "]"
            Case "Eliminar"
                Me.IBtnEliminar.Enabled = True
                Me.IBtnGuardar.Enabled = False
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.grdInformes.SelectedIndex = index
                Pk1 = grdInformes.DataKeys(index).Values(0).ToString()

                If Obj.GetbyPk(Me.DetPContrato1.CodigoPContrato, Me.DetPContrato1.Grupo, grdInformes.DataKeys(index).Values(0).ToString()) Then
                    Try
                        Me.TxtIde.Text = Obj.Id_Item
                        TxtDes.Text = Obj.Desc_Item
                        TxtCan.Text = Obj.Can_Item
                        CboUnidad.SelectedValue = Obj.Uni_Item
                        TxtValUni.Text = Obj.Val_Uni_Item
                        TxtIva.Text = Obj.Iva_Item
                        Me.ModalPopupTer.Show()
                        Habilitar(False)
                    Catch ex As Exception
                        MsgResult.Text = ex.Message
                        MsgBox(MsgResult, True)
                    End Try
                End If
                Me.ModalPopupTer.Show()
        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtIde.Enabled = False
        Me.TxtDes.Enabled = b
        Me.TxtCan.Enabled = b
        Me.TxtIva.Enabled = b
        Me.TxtValUni.Enabled = b
        Me.CboUnidad.Enabled = b
        Me.IBtnGuardar.Enabled = b
        Me.IBtnEliminar.Enabled = Not b

    End Sub

    Protected Sub grdInformes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdInformes.PreRender

    End Sub
    Protected Sub grdInformes_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdInformes.RowEditing
        grdInformes.EditIndex = e.NewEditIndex
        FillCustomerInGrid()
    End Sub
    Private Sub FillCustomerInGrid()
        Me.grdInformes.DataBind()

    End Sub
    Sub Guardar()
        Dim Obj As New PObjetos_Items
        Try
            Obj.num_gproc = Me.DetPContrato1.CodigoPContrato
            Obj.grupo = Me.DetPContrato1.Grupo
            If Not String.IsNullOrEmpty(Me.TxtIde.Text) Then
                Obj.Id_Item = Me.TxtIde.Text
            End If
            Obj.Desc_Item = TxtDes.Text
            Obj.Can_Item = TxtCan.Text
            Obj.Uni_Item = CboUnidad.SelectedValue
            Obj.Val_Uni_Item = TxtValUni.Text
            Obj.Iva_Item = TxtIva.Text
        Catch ex As Exception
            MsgResult.Text = "Envio de Datos:" + ex.Message
            MsgBox(MsgResult, True)
            Return
        End Try

        Select Case Me.Oper
            Case "Nuevo"
                MsgResult.Text = Obj.Insert()
            Case "Editar"
                MsgResult.Text = Obj.Update()
        End Select
        MsgBox(MsgResult, Obj.lErrorG)
        If Not Obj.lErrorG Then
            Me.Limpiar()
            FillCustomerInGrid()
        End If
    End Sub
  

    Protected Sub Limpiar()
        
        Me.TxtIde.Text = ""
        Me.TxtDes.Text = ""
        Me.TxtCan.Text = ""
        Me.TxtIva.Text = ""
        Me.TxtValUni.Text = ""
        'Me.CboUnidad.SelectedValue

    End Sub

    Protected Sub grdInformes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdInformes.SelectedIndexChanged

        'MsgBoxLimpiar(Me.MsgResult)

    End Sub


    Sub Eliminar()
        Dim Obj As New PObjetos_Items
        Try
            Obj.num_gproc = Me.DetPContrato1.CodigoPContrato
            Obj.grupo = Me.DetPContrato1.Grupo
            If Not String.IsNullOrEmpty(Me.TxtIde.Text) Then
                Obj.Id_Item = Me.TxtIde.Text
            End If
        Catch ex As Exception
            MsgResult.Text = "Envio de Datos:" + ex.Message
            MsgBox(MsgResult, True)
            Return
        End Try
        Me.MsgResult.Text = Obj.Delete()
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
    End Sub

    Protected Sub grdInformes_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdInformes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub IbtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Me.ModalPopupTer.Show()

    End Sub

    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Guardar()
    End Sub

    Protected Sub IBtnEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnEliminar.Click
        Eliminar()
    End Sub

  
    Protected Sub IbtnNuevo_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnNuevo.Click
        Me.Oper = "Nuevo"
        Me.ModalPopupTer.Show()
    End Sub
End Class
