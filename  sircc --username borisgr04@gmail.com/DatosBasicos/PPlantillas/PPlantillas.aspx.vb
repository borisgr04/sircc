Imports System.Data
Partial Class DatosBasicos_PPlantillas_PPlantillas
    Inherits PaginaComun

    Dim Obj As New PPlantillas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        Me.GridView1.DataBind()
        Dim curObj As ScriptManager = ScriptManager.GetCurrent(Page)
        If curObj IsNot Nothing Then
            curObj.RegisterPostBackControl(Me.BtnGuardar)
        End If
        If Not IsPostBack Then
            Me.GridView1.DataBind()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."

                Me.Habilitar(True)
                Limpiar()

                Me.ModalPopupTer.Show()
                'Me.TxtCodNew.ReadOnly = True
                'Me.SetFocus(Me.TxtCodNew)

            Case "Editar"
                'Me.SubT.Text = "Editando..."
                'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                'Me.GridView1.SelectedIndex = index

                'Dim tb As DataTable = Obj.GetbyPK(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString)
                'If tb.Rows.Count > 0 Then
                '    Me.TxtCod.Text = tb.Rows(0)("Cod_Est").ToString
                '    Me.TxtNom.Text = tb.Rows(0)("Nom_est").ToString
                '    ' Me.TxtColor.Text = tb.Rows(0)("Color").ToString
                '    Habilitar(True)
                '    Me.ModalPopupTer.Show()
                'End If
                'Me.MsgResult.Text = "Editando: Código [" + "]"
            Case "Eliminar"
                'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                'Me.GridView1.SelectedIndex = index
                'Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                'Dim tb As DataTable = Obj.GetbyPK(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString)
                'If tb.Rows.Count > 0 Then
                '    Me.TxtCod.Text = tb.Rows(0)("Cod_Est").ToString
                '    Me.TxtNom.Text = tb.Rows(0)("Nom_est").ToString
                '    ' Me.TxtColor.Text = tb.Rows(0)("Color").ToString
                '    Me.ModalPopupTer.Show()
                '    Habilitar(False)
                'End If
                'Me.ModalPopupTer.Show()
        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        'Me.TxtValSig.Enabled = b
        'Me.CboTproc.Enabled = b
        'Me.CboTact.Enabled = b
        'Me.TxtColor.Enabled = b
        'Me.CboFilVig.Enabled = b
        TxtCod.Enabled = False
        CboTipPla.Enabled = b
        CboEst.Enabled = b
        CboTproc.Enabled = b

        TxtNom.Enabled = b

        Me.BtnGuardar.Enabled = b
        Me.BtnEliminar.Enabled = Not b
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        FillCustomerInGrid()
    End Sub
    Private Sub FillCustomerInGrid()
        Me.GridView1.DataBind()
        'Dim cl As String = Me.CboImpto.SelectedValue
        'If Left(Me.CboImpto.SelectedValue, 2) <> Me.CmbClase.SelectedValue Then
        ' Me.CboImpto.SelectedIndex = 0
        ' cl = ""
        'End If
        'Dim dtCustomer As DataTable = Obj.GetByImpuesto(cl)
        'If (dtCustomer.Rows.Count > 0) Then
        ' GridView1.DataSource = dtCustomer
        'GridView1.DataBind()
        'Else
        'dtCustomer.Rows.Add(dtCustomer.NewRow())
        'GridView1.DataSource = dtCustomer
        'GridView1.DataBind()
        'Dim TotalColumns As Integer = GridView1.Rows(0).Cells.Count
        'GridView1.Rows(0).Cells.Clear()
        'GridView1.Rows(0).Cells.Add(New TableCell())
        ' GridView1.Rows(0).Cells(0).ColumnSpan = TotalColumns
        'GridView1.Rows(0).Cells(0).Text = "No se encontraron Registro"
        'End If
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Select Case Me.Oper
            Case "Nuevo"
                MsgResult.Text = Obj.Insert(CboTipPla.SelectedValue, TxtNom.Text, FileUpload1, CboExt.SelectedValue, CboTproc.SelectedValue, CboEst.SelectedValue, TxtCod.Text)
                'Case "Editar"
                '    If FileUpload1.HasFile Then
                '        Dim tb As DataTable = Obj.GetbyPK(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString)
                '        If tb.Rows(0).Item("Imagen").ToString = "" Then
                '            SubirAchivo(FileUpload1.PostedFile)
                '        Else
                '            EliminarImagen(tb.Rows(0).Item("Imagen").ToString)
                '            SubirAchivo(FileUpload1.PostedFile)
                '        End If
                '    Else
                '        ' Me.MsgResult.Text = Obj.Update(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.TxtCod.Text, Me.TxtNom.Text, "", Me.TxtColor.Text)
                '    End If
        End Select
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If
    End Sub

    Protected Sub Limpiar()
        Me.TxtCod.Text = ""
        Me.TxtNom.Text = ""
        CboTipPla.SelectedIndex = 0
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        MsgBoxLimpiar(MsgResult)
    End Sub

    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim tb As DataTable = Obj.GetbyPK(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString)
        'If tb.Rows(0).Item("Imagen").ToString = "" Then
        '    'Me.MsgResult.Text = Obj.Delete(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString)
        '    Me.MsgBox(MsgResult, Obj.lErrorG)
        '    FillCustomerInGrid()
        'Else
        '    EliminarImagen(tb.Rows(0).Item("Imagen").ToString)
        'End If
    End Sub

    Protected Sub GridView1_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If

    End Sub
    'Sub SubirAchivo(ByVal Archivo As HttpPostedFile)
    '    Try
    '        Dim savePath As String = "~/Docs/imgpact/"
    '        Dim fileName As String = FileUpload1.FileName
    '        Dim pathToCheck As String = Server.MapPath(savePath + fileName)
    '        Dim tempfileName As String = ""
    '        If Me.FileUpload1.PostedFile.ContentType = "image/pjpeg" Or Me.FileUpload1.PostedFile.ContentType = "image/gif" Or Me.FileUpload1.PostedFile.ContentType = "image/x-png" Then
    '            If (System.IO.File.Exists(pathToCheck)) Then
    '                Dim counter As Integer = 2
    '                While (System.IO.File.Exists(pathToCheck))
    '                    tempfileName = counter.ToString() + fileName
    '                    pathToCheck = savePath + tempfileName
    '                    counter = counter + 1
    '                End While
    '                fileName = tempfileName
    '            End If
    '            savePath += fileName
    '            FileUpload1.SaveAs(Server.MapPath(savePath))
    '            Select Case Me.Oper
    '                Case "Nuevo"
    '                    'Me.MsgResult.Text = Obj.Insert(Me.TxtCod.Text, Me.TxtNom.Text, "~/Docs/imgpact/" + FileUpload1.FileName, Me.TxtColor.Text)
    '                Case "Editar"
    '                    ' Me.MsgResult.Text = Obj.Update(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString, Me.TxtCod.Text, Me.TxtNom.Text, "~/Docs/imgpact/" + FileUpload1.FileName, Me.TxtColor.Text)
    '            End Select
    '        Else
    '            Throw New Exception("Esta intentando subir un archivo que no corresponde a una imagen")
    '        End If
    '    Catch ex As Exception
    '        MsgResult.Text = "Error al subir el archivo. " + ex.Message
    '        MsgBox(Me.MsgResult, True)
    '    End Try
    'End Sub

    Protected Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNuevo.Click
        Me.Oper = "Nuevo"
        MsgBoxLimpiar(MsgResult)
        Me.ModalPopupTer.Show()
    End Sub
    'Sub EliminarImagen(ByVal Archivo As String)
    '    Try
    '        Dim FileToDelete As String
    '        FileToDelete = Server.MapPath(Archivo)
    '        If System.IO.File.Exists(FileToDelete) = True Then
    '            System.IO.File.Delete(FileToDelete)
    '            Select Case Me.Oper
    '                Case "Eliminar"
    '                    Me.MsgResult.Text = Obj.Delete(Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values(0).ToString)
    '                    Me.MsgBox(MsgResult, Obj.lErrorG)
    '                    FillCustomerInGrid()
    '            End Select
    '        End If
    '    Catch ex As Exception
    '        Me.MsgResult.Text = "Error al Borrar La Imagen"
    '        MsgBox(Me.MsgResult, True)
    '    End Try
    'End Sub
End Class
