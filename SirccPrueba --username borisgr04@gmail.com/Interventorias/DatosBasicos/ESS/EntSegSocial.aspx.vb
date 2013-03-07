Imports System.Data
Imports System.IO
Partial Class DatosBasicos_interventorias_EntSegSocial
    Inherits PaginaComun


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        Dim Ide_Con As String
        Ide_Con = CType(Session("Clave"), String)


        If Not IsPostBack Then
            FillCustomerInGrid()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub grdInformes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdInformes.RowCommand
        Dim Obj As New EntSegSocial

        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."

                Me.Habilitar(True)
                Limpiar()

                Me.ModalPopupTer.Show()
                'Me.TxtCodNew.ReadOnly = True

                Me.SetFocus(Me.TxtCod)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.grdInformes.SelectedIndex = index


                If Obj.GetbyPk(grdInformes.DataKeys(index).Values(0).ToString()) Then

                    Try
                        ' CboVig.Text = Obj.Vigencia
                        TxtCod.Text = Obj.Codigo
                        TxtInf.Text = Obj.Descripcion
                        'TxtDes.Text = Obj.Descripcion
                        'TxtFecIni.Text = Obj.FechaI
                        'TxtFecFin.Text = Obj.FechaF
                        'TxtRec.Text = Obj.Recordatorio
                        'TxtDest.Text = Obj.Destinatario
                        CboEstado.Text = Obj.Estado
                        cboTipoEnt.Text = Obj.Tipo
                        Me.Pk1 = Obj.Codigo
                        Me.ModalPopupTer.Show()
                        Habilitar(True)
                    Catch ex As Exception
                        MsgResult.Text = ex.Message
                        MsgBox(MsgResult, True)
                    End Try


                End If

                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtCod.Text + "]"

            Case "Eliminar"
                Me.SubT.Text = "Eliminando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.grdInformes.SelectedIndex = index
                Pk1 = grdInformes.DataKeys(index).Values(0).ToString()
                If Obj.GetbyPk(grdInformes.DataKeys(index).Values(0).ToString()) Then
                    Try

                        TxtCod.Text = Obj.Codigo
                        TxtInf.Text = Obj.Descripcion

                        CboEstado.Text = Obj.Estado
                        cboTipoEnt.Text = Obj.Tipo
                        Me.Pk1 = Obj.Codigo
                        Me.ModalPopupTer.Show()
                        Habilitar(False)
                    Catch ex As Exception
                        MsgResult.Text = ex.Message
                        MsgBox(MsgResult, True)
                    End Try


                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0
            Case "Exportar"
                'grdInformes.DataSource = Obj.GetRecords
                'grdInformes.DataBind()
                ExportGridView(grdInformes, "Registro de Alertas Informes")
        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
         
        Me.TxtCod.Enabled = b
        Me.BtnEliminar.Enabled = Not b
        Me.BtnGuardar.Enabled = b
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

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Guardar()

    End Sub

    Protected Sub Limpiar()
        'CboVig.Text = ""
        TxtCod.Text = ""
        TxtInf.Text = ""
        'TxtDes.Text = ""
        'TxtDest.Text = ""
        'TxtFecIni.Text = ""
        'TxtFecFin.Text = ""
        'CboTipRec.Text = ""
        'TxtRec.Text = ""
        'TxtDes.Text = ""

    End Sub

    Protected Sub grdInformes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdInformes.SelectedIndexChanged

        Me.MsgBoxLimpiar(MsgResult)
    End Sub

    'Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim Obj As New Alertas
    '    'Me.MsgResult.Text = Obj.Delete(Me.TxtCodNew.Text)
    '    Me.MsgBox(MsgResult, Obj.lErrorG)
    '    FillCustomerInGrid()
    'End Sub

    Protected Sub grdInformes_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdInformes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Nuevo()

    End Sub

    Protected Sub BtnEliminar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim Obj As New EntSegSocial
        Me.MsgResult.Text = Obj.Delete(Me.TxtCod.Text)
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
    End Sub

    Private Sub Guardar()
        Dim Obj As New EntSegSocial
        Try
            Obj.Codigo = Me.TxtCod.Text
            Obj.Descripcion = Me.TxtInf.Text
            Obj.Estado = CboEstado.SelectedValue
            Obj.Tipo = Me.cboTipoEnt.SelectedValue

        Catch ex As Exception
            MsgResult.Text = ex.Message
            MsgBox(MsgResult, True)
            Return
        End Try

        Select Case Me.Oper
            Case "Nuevo"
                MsgResult.Text = Obj.Insert()
            Case "Editar"
                MsgResult.Text = Obj.Update(Pk1)
        End Select
        MsgBox(MsgResult, Obj.lErrorG)
        If Not Obj.lErrorG Then
            Me.Limpiar()
            FillCustomerInGrid()
        End If
    End Sub

    Private Sub Nuevo()
        Me.Oper = "Nuevo"
        Me.ModalPopupTer.Show()

        Me.SubT.Text = "Nuevo..."

        Me.Habilitar(True)
        Limpiar()

        Me.ModalPopupTer.Show()
        'Me.TxtCodNew.ReadOnly = True

        Me.SetFocus(Me.TxtCod)
    End Sub
   
    
    
   
End Class
