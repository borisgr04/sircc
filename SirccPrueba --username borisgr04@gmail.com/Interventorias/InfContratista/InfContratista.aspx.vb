Imports System.Data
Imports Telerik.Web.UI

Partial Class Interventorias_InfContratista_InfContratista
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
        MsgBoxLimpiar(MsgResult2)
        Habilitar("New")
        MostrarControlesDetallados()
    End Sub

    'Sub Habilitar(ByVal v As Boolean)
    '    'txtFecDoc.Enabled = v
    '    'TxtFecFin.Enabled = v
    '    'txtObs.Enabled = v
    '    'TxtNoDocumento.Enabled = False

    '    'IBtnGuardar.Enabled = v
    '    'IBtnGuardar.CssClass = cssEnabled(v)


    'End Sub



    'Sub EnableValidar(ByVal v As Boolean)
    '    Me.IBtnValidar.Enabled = v
    '    Me.LbValidar.Enabled = v
    '    Me.IBtnValidar.CssClass = cssEnabled(v)
    'End Sub
    'Sub EnableRevertir(ByVal v As Boolean)
    '    Me.IBtnRevertir.Enabled = v
    '    Me.LbRevertir.Enabled = v
    '    Me.IBtnRevertir.CssClass = cssEnabled(v)
    '    Me.lBtnGenerar.Enabled = v
    '    Me.lBtnGenerar.CssClass = cssEnabled(v)
    'End Sub

    Protected Sub mostrarDatos()
        'EnableRevertir(False)
        'EnableValidar(False)
        grdInformes.DataBind()
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

    Protected Sub grdInformes_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdInformes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdInformes_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdInformes.RowEditing
        grdInformes.EditIndex = e.NewEditIndex
        '        FillCustomerInGrid()
    End Sub

    Sub Mostrar(Num_Inf As String)

        Dim Obj As New InfContratista
        Try
            If Obj.GetbyPk(Me.hdCodCon.Value, Num_Inf) Then
                TxtFecInf.Text = Obj.Fec_Inf
                TxtFecIni.Text = Obj.Fec_Ini
                TxtFecFin.Text = Obj.Fec_Fin
                TxtAnexo.Text = Obj.Can_Hoj
                TxtNInf.Text = Num_Inf
                TxtDesInf.Text = Obj.Des_Inf
            End If
            Me.Pk1 = Num_Inf
            MostrarControlesDetallados()
            Habilitar("Ver")
            MsgBoxLimpiar(MsgResult2)
        Catch ex As Exception
            MsgResult2.Text = ex.Message
            MsgBox(MsgResult2, True)
        End Try

    End Sub
    Sub Editar(Num_Inf As String)

        Dim Obj As New InfContratista
        Try
            If Obj.GetbyPk(Me.hdCodCon.Value, Num_Inf) Then
                TxtFecInf.Text = Obj.Fec_Inf
                TxtFecIni.Text = Obj.Fec_Ini
                TxtFecFin.Text = Obj.Fec_Fin
                TxtAnexo.Text = Obj.Can_Hoj
                TxtNInf.Text = Num_Inf
                TxtDesInf.Text = Obj.Des_Inf
            End If
            Me.Pk1 = Num_Inf
            MostrarControlesDetallados()
            Habilitar("Edit")
            MsgBoxLimpiar(MsgResult2)
        Catch ex As Exception
            MsgResult2.Text = ex.Message
            MsgBox(MsgResult2, True)
        End Try

    End Sub
    Protected Sub grdInformes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdInformes.RowCommand
        Me.Oper = e.CommandName
        Select Case Me.Oper
            Case "Nuevo"
                Nuevo()
            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.grdInformes.SelectedIndex = index
                Dim num_inf As String = grdInformes.DataKeys(index).Values(0).ToString()
                Editar(num_inf)
            Case "Eliminar"
                Dim Obj As New InfContratista
                Me.SubT.Text = "Anulando..."
                MsgResult2.Text = Obj.Anular(Me.hdCodCon.Value, e.CommandArgument)
                MsgBox(MsgResult2, Obj.lErrorG)
            Case "Descargar"
                'ExportGridView(grdInformes, "Export de Informes del Contratista")
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.grdInformes.SelectedIndex = index
                Dim num_inf As String = grdInformes.DataKeys(index).Values(0).ToString()
                Dim Url As String = "/ashx/verSopInfCon.ashx?Cod_Con=" + hdCodCon.Value + "&Num_Inf=" + num_inf
                Redireccionar_Pagina(Url)
        End Select
        grdSoporte.DataBind()
        grdInformes.DataBind()

    End Sub
    Protected Sub Habilitar(ByVal opcion As String)
        Dim b As Boolean
        b = True
        TxtNInf.Enabled = False
        If opcion = "Edit" Then
            TxtDesInf.Enabled = b
            TxtFecFin.Enabled = b
            TxtFecIni.Enabled = b
            TxtFecInf.Enabled = b
            Me.IBtnGuardar.Enabled = b
            Me.RUploadAnexos.Enabled = b
            TxtAnexo.Enabled = b
            grdSoporte.Enabled = b
            TxtDesInf.Focus()
            'Me.txtvalor.Focus()
        ElseIf (opcion = "New") Then
            TxtDesInf.Enabled = b
            TxtFecFin.Enabled = b
            TxtFecIni.Enabled = b
            TxtFecInf.Enabled = b
            TxtAnexo.Enabled = b
            'Me.BtnEliminarPinv.Enabled = Not b
            Me.IBtnGuardar.Enabled = b
            Me.RUploadAnexos.Enabled = b
            'Me.CboPlanAnticipo.Focus()
            grdSoporte.Enabled = b
            '
        ElseIf (opcion = "Ver") Then
            TxtDesInf.Enabled = Not b
            TxtFecFin.Enabled = Not b
            TxtFecIni.Enabled = Not b
            TxtFecInf.Enabled = Not b
            TxtAnexo.Enabled = Not b
            'Me.BtnEliminarPinv.Enabled = b
            Me.IBtnGuardar.Enabled = Not b
            Me.RUploadAnexos.Enabled = Not b
            grdSoporte.Enabled = Not b
            'Me.BtnEliminarPinv.Focus()

        End If



    End Sub

    Protected Sub Limpiar()
        TxtNInf.Text = 0
        TxtAnexo.Text = ""
        TxtDesInf.Text = "Escriba una sintesis del informe"
        TxtFecInf.Text = Date.Today.ToShortDateString
        TxtFecIni.Text = ""
        TxtFecFin.Text = ""
    End Sub



    Protected Sub Guardar()
        Dim Obj As New InfContratista
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
            Obj.Fec_Inf = TxtFecInf.Text
            Obj.Fec_Ini = TxtFecIni.Text
            Obj.Fec_Fin = TxtFecFin.Text
            Obj.Cod_Con = hdCodCon.Value
            Obj.Can_Hoj = TxtAnexo.Text
            Obj.Des_Inf = TxtDesInf.Text

            If Obj.Fec_Fin < Obj.Fec_Ini Then
                MsgResult2.Text = "La Fecha Final del Periodo debe ser superior o igual a la Fecha Inicial"
                TxtFecFin.Focus()
                MsgBoxAlert(MsgResult2, True)
                Return
            End If

            If Obj.Fec_Inf < Obj.Fec_Fin Then
                MsgResult2.Text = "La Fecha del Informe debe ser Superior o igual a la Fecha Final"
                TxtFecInf.Focus()
                MsgBoxAlert(MsgResult2, True)
                Return
            End If

            If Oper = "Editar" Then
                Obj.Num_Inf = TxtNInf.Text
            Else 'osea nuevo
                If CInt(TxtAnexo.Text) > 0 And cantArc = 0 Then
                    MsgResult2.Text = "Debe Subir Al  menos un Documento de Soporte"
                    MsgBoxAlert(MsgResult2, True)

                    Return
                End If
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
                MsgResult2.Text = Obj.Update(Me.hdCodCon.Value, TxtNInf.Text)

        End Select
        MsgBox(MsgResult2, Obj.lErrorG)
        
        If Not Obj.lErrorG Then
            If Oper = "Nuevo" Then
                TxtNInf.Text = Obj.Num_Inf
                Me.Oper = "Editar"
            End If
            grdSoporte.DataBind()
            grdInformes.DataBind()
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
        If Not String.IsNullOrEmpty(TxtNInf.Text) Or TxtNInf.Text <> "0" Then
            MsgResult2.Text = " No es posible editar un registro en blanco"
        Else
            Editar(TxtNInf.Text)
        End If

    End Sub

    Protected Sub grdSoporte_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSoporte.RowCommand
        Me.Oper = e.CommandName
        Select Case Me.Oper
            Case "Eliminar"
                Dim Obj As New InfContratista
                Me.SubT.Text = "Anulando..."
                MsgResult2.Text = Obj.AnularSoporte(Me.hdCodCon.Value, TxtNInf.Text, e.CommandArgument)
                MsgBox(MsgResult2, Obj.lErrorG)
                grdSoporte.DataBind()
            Case "Descargar"
                grdSoporte.SelectedIndex = CInt(e.CommandArgument)

                Dim Url As String = "/ashx/verSopInfCon.ashx?Cod_Con=" + hdCodCon.Value + "&Num_Inf=" + TxtNInf.Text + "&ID=" + grdSoporte.SelectedValue.ToString
                Redireccionar_Pagina(Url)
        End Select
    End Sub

    Protected Sub grdInformes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdInformes.SelectedIndexChanged
        Mostrar(grdInformes.SelectedValue)

    End Sub
End Class
