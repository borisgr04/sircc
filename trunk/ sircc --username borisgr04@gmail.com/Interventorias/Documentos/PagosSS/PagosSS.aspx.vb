Imports System.Data
Imports Telerik.Web.UI

Partial Class Interventorias_PagosSS_PagosSS
    Inherits PaginaComun

    Public Shared Rutas As New List(Of ArchivosT)()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdCodCon.Value = Request("Cod_Con")
            Me.Oper = Request("Oper")
            Me.NoID = Request("NoID")
            mostrarDatos()
            Habilitar("Ver")

            'Me.lBtnGenerar.Enabled = True
            'Me.lBtnGenerar.CssClass = ""
        End If

    End Sub

    Sub Nuevo()
        Me.Oper = "Nuevo"
        Me.SubT.Text = "Nuevo..."
        'MsgResult2.Text = " Agregar Nuevo Informe del Contratista"
        'MsgBoxInfo(MsgResult2, False)
        Limpiar()
        MsgBoxLimpiar(MsgResult2)
        Habilitar("New")

        MostrarControlesDetallados()
    End Sub

    Protected Sub mostrarDatos()
        'EnableRevertir(False)
        'EnableValidar(False)
        grd.DataBind()
        Dim v As New InfContratista
        'Me.Panel1.Visible = False
        Dim dt As DataTable = v.GetByPkS(hdCodCon.Value)
        DtPCon.DataSource = dt
        DtPCon.DataBind()
        If dt.Rows.Count > 0 Then
            hdEstInicial.Value = dt.Rows(0)("Est_Con").ToString
        End If
        UpdatePanel1.Update()
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub grdInformes_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdInformes_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grd.RowEditing
        grd.EditIndex = e.NewEditIndex
        '        FillCustomerInGrid()
    End Sub

    Sub Mostrar(Id As String)

        Dim Obj As New PagoSS
        Try
            If Obj.GetbyPk(Me.hdCodCon.Value, Id) Then
                TxtId.Text = Id
                TxtObs.Text = Obj.Obs
                txtPeriodo.SelectedDate = Obj.Mes_Pag + "/" + Obj.Year_Pag
                txtPlanillaN.Text = Obj.PlanillaN
                TxtValApor.Text = Obj.Val_Apo
                cboTipoAporte.SelectedValue = Obj.Cod_Tip_ESS
                CboTipPla.SelectedValue = Obj.Tip_Pla
            End If
            Me.Pk1 = Id
            MostrarControlesDetallados()
            Habilitar("Ver")
            MsgBoxLimpiar(MsgResult2)
        Catch ex As Exception
            MsgResult2.Text = ex.Message
            MsgBox(MsgResult2, True)
        End Try

    End Sub
    Sub Editar(Id As String)

        Dim Obj As New PagoSS
        Try
            If Obj.GetbyPk(Me.hdCodCon.Value, Id) Then
                TxtId.Text = Id
                TxtObs.Text = Obj.Obs
                txtPeriodo.SelectedDate = Obj.Mes_Pag + "/" + Obj.Year_Pag
                txtPlanillaN.Text = Obj.PlanillaN
                TxtValApor.Text = Obj.Val_Apo
                cboTipoAporte.SelectedValue = Obj.Cod_Tip_ESS
                CboTipPla.SelectedValue = Obj.Tip_Pla
            End If
            Me.Pk1 = Id
            Me.Pk2 = hdCodCon.Value
            MostrarControlesDetallados()
            Habilitar("Edit")
            MsgBoxLimpiar(MsgResult2)
        Catch ex As Exception
            MsgResult2.Text = ex.Message
            MsgBox(MsgResult2, True)
        End Try

    End Sub
    Protected Sub grdInformes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grd.RowCommand
        Me.Oper = e.CommandName

        Select Case Me.Oper
            Case "Nuevo"
                Nuevo()
            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.grd.SelectedIndex = index
                Dim id As String = grd.DataKeys(index).Values(0).ToString()
                Editar(id)
            Case "Eliminar"
                Dim Obj As New PagoSS
                Me.SubT.Text = "Anulando..."
                MsgResult2.Text = Obj.Anular(Me.hdCodCon.Value, e.CommandArgument)
                MsgBox(MsgResult2, Obj.lErrorG)
                'Case "Descargar"
                '    'ExportGridView(grdInformes, "Export de Informes del Contratista")
                '    Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                '    Me.grd.SelectedIndex = index
                '    Dim num_inf As String = grd.DataKeys(index).Values(0).ToString()
                '    Dim Url As String = "/ashx/verSopInfCon.ashx?Cod_Con=" + hdCodCon.Value + "&Num_Inf=" + num_inf
                '    Redireccionar_Pagina(Url)
        End Select
        grdSoporte.DataBind()
        grd.DataBind()

    End Sub
    Protected Sub Habilitar(ByVal opcion As String)
        Dim b As Boolean
        b = True
        TxtId.Enabled = False
        If opcion = "Edit" Then
            TxtObs.Enabled = b
            CboTipPla.Enabled = b
            txtPeriodo.Enabled = b
            TxtValApor.Enabled = b
            cboTipoAporte.Enabled = b
            txtPlanillaN.Enabled = b
            Me.IBtnGuardar.Enabled = b
            Me.RUploadAnexos.Enabled = b
            grdSoporte.Enabled = b
            TxtValApor.Focus()
            'Me.txtvalor.Focus()
        ElseIf (opcion = "New") Then
            TxtObs.Enabled = b
            CboTipPla.Enabled = b
            txtPeriodo.Enabled = b
            TxtValApor.Enabled = b
            cboTipoAporte.Enabled = b
            txtPlanillaN.Enabled = b
            Me.IBtnGuardar.Enabled = b
            Me.RUploadAnexos.Enabled = b  'Me.BtnEliminarPinv.Enabled = Not b
            grdSoporte.Enabled = b
            '
        ElseIf (opcion = "Ver") Then
            TxtObs.Enabled = Not b
            CboTipPla.Enabled = Not b
            txtPeriodo.Enabled = Not b
            TxtValApor.Enabled = Not b
            cboTipoAporte.Enabled = Not b
            txtPlanillaN.Enabled = Not b
            Me.IBtnGuardar.Enabled = Not b
            Me.RUploadAnexos.Enabled = Not b
            grdSoporte.Enabled = Not b
            'Me.BtnEliminarPinv.Focus()

        End If



    End Sub

    Protected Sub Limpiar()
        TxtId.Text = 0
        TxtValApor.Text = ""
        TxtObs.Text = "Escriba una sintesis del informe"
        cboTipoAporte.SelectedIndex = -1
        CboTipPla.SelectedIndex = -1
        TxtId.Text = ""
        TxtObs.Text = ""
        TxtValApor.Text = 0
        'txtPlanillaN.Text=""

    End Sub



    Protected Sub Guardar()
        Dim Obj As New PagoSS
        Try
            Dim lstAdj As New List(Of ArchivosT)()
            Dim cantArc As Integer = RUploadAnexos.UploadedFiles.Count
            For Each file As UploadedFile In RUploadAnexos.UploadedFiles
                Dim item As New ArchivosT
                Dim fileData As Byte() = New Byte(file.InputStream.Length - 1) {}
                file.InputStream.Read(fileData, 0, CInt(file.InputStream.Length))
                item.SoporteB = fileData
                item.Content = file.ContentType
                item.Icono = Util.Icono(file.ContentType)
                item.NomArchivo = file.FileName
                lstAdj.Add(item)
                'MsgResult2.Text += file.FileName + "<br>"
                'Exit Sub
            Next
            Obj.lstAdj = lstAdj
            Obj.Cod_Tip_ESS = cboTipoAporte.SelectedValue
            Obj.Cod_Con = hdCodCon.Value
            Obj.Mes_Pag = String.Format("{0:MMMM}", txtPeriodo.SelectedDate)
            Obj.Year_Pag = String.Format("{0:yyyy}", txtPeriodo.SelectedDate)
            Obj.Tip_Pla = CboTipPla.SelectedValue
            Obj.PlanillaN = txtPlanillaN.Text
            Obj.Val_Apo = TxtValApor.Text
            Obj.Obs = TxtObs.Text
            If Oper = "Editar" Then
                Obj.Id = TxtId.Text
            End If
            MsgBoxAlert(MsgResult2, Obj.lErrorG)
        Catch ex As Exception
            MsgResult2.Text = "Error en Validación:" + ex.Message
            MsgBox(MsgResult2, True)
            Return
        End Try
        Select Case Me.Oper
            Case "Nuevo"
                MsgResult2.Text = Obj.Insert()
            Case "Editar"
                MsgResult2.Text = Obj.Update(Me.hdCodCon.Value, TxtId.Text)
        End Select
        MsgBox(MsgResult2, Obj.lErrorG)

        If Not Obj.lErrorG Then
            If Oper = "Nuevo" Then
                TxtId.Text = Obj.Id
                Me.Oper = "Editar"
            End If
            grdSoporte.DataBind()
            grd.DataBind()
        End If

    End Sub

    Private Sub MostrarControlesDetallados()
        mostrarTab(1)
    End Sub

    Protected Sub IBtnGuardar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Guardar()
    End Sub

    Protected Sub IBtnCancelar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnCancelar.Click
        Cancelar()
    End Sub
    Sub Cancelar()
        Limpiar()
        MostrarHistorico()
    End Sub
    Private Sub MostrarHistorico()
        mostrarTab(0)
    End Sub

    Sub mostrarTab(id As Integer)
        RadTabStrip1.SelectedIndex = id
        Me.RadTabStrip1.SelectedIndex = id
        Me.RadMultiPage1.SelectedIndex = id
        grdSoporte.DataBind()
    End Sub

    Protected Sub IBtnNuevo_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        Nuevo()
    End Sub

    Protected Sub IBtnEditar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnEditar.Click
        If Not String.IsNullOrEmpty(TxtId.Text) Or TxtId.Text <> "0" Then
            MsgResult2.Text = " No es posible editar un registro en blanco"
        Else
            Editar(TxtId.Text)
        End If

    End Sub

    Protected Sub grdSoporte_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSoporte.RowCommand
        Me.Oper = e.CommandName
        Select Case Me.Oper
            Case "Eliminar"
                Dim Obj As New InfContratista
                Me.SubT.Text = "Anulando..."
                MsgResult2.Text = Obj.AnularSoporte(Me.hdCodCon.Value, TxtId.Text, e.CommandArgument)
                MsgBox(MsgResult2, Obj.lErrorG)
                grdSoporte.DataBind()
            Case "Descargar"
                grdSoporte.SelectedIndex = CInt(e.CommandArgument)

                Dim Url As String = "/ashx/verSopInfCon.ashx?Cod_Con=" + hdCodCon.Value + "&Num_Inf=" + TxtId.Text + "&ID=" + grdSoporte.SelectedValue.ToString
                Redireccionar_Pagina(Url)
        End Select
    End Sub

    Protected Sub grdInformes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grd.SelectedIndexChanged
        Mostrar(grd.SelectedValue)

    End Sub

    Protected Sub lnkBtn_Click(sender As Object, e As System.EventArgs) Handles lnkBtn.Click
        mostrarTab(1)
    End Sub

    Protected Sub IbtnVolver_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IbtnVolver.Click
        Dim ruta As String = RutasPag.GetInstance.GetRuta(Request("Origen")) ' Seguridad Social
        Redireccionar_Pagina(ruta + "?Cod_Con=" + hdCodCon.Value + "&NoID=" + Request("NoID") + "&Oper=Editar")
    End Sub
End Class
