Imports System.Data
Imports System.IO

Partial Class Procesos_NuevaSolicitud_Default
    Inherits PaginaComun
    Dim obj As PSolicitudes = New PSolicitudes
    'Protected Sub IBtnGuardar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
    '    Guardar()
    'End Sub

   
    Public Sub Guardar()
        Dim sval As String = ""
        Dim sw As Boolean = False
        If String.IsNullOrEmpty(TxtObj.Text) Then
            sval = "Digite un Valor a Pagar"
            sw = True
           
        End If
        'If Me.CboDepP.SelectedIndex = 0 Then
        '    sval = IIf(sval <> "", sval + "<br/>", "") + "Seleccione la Dependencia a Cargo del Proceso"
        '    sw = True

        'End If
        If Me.cboDep.SelectedIndex = 0 Then
            sval = IIf(sval <> "", sval + "<br/>", "") + "Seleccione la Dependencia que Origina la Necesidad"
            sw = True
          
        End If
        If Me.CboTproc.SelectedValue = "TP00" Then
            sval = IIf(sval <> "", sval + "<br/>", "") + "Seleccione la Modalidad de Contratación"
            sw = True

        End If
        If sw = True Then
            MsgResult.Text = sval
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        obj = New PSolicitudes

        Select Case Me.Oper
            Case "nuevo"
                Me.MsgResult.Text = obj.Insert(Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, Me.Vigencia, Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, Me.CboTproc.SelectedValue, Me.TxtObj.Text, Me.TxtFechaRecibido.Text, Me.TxtNPla.Text, Publico.PuntoPorComa(Me.TxtPpto.Text), Me.TxtIde.Text)
            Case "editar"
                Me.MsgResult.Text = obj.Update(Me.Pk1, Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, Me.Vigencia, Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, Me.CboTproc.SelectedValue, Me.TxtObj.Text, Me.TxtFechaRecibido.Text, Me.TxtNPla.Text, Publico.PuntoPorComa(Me.TxtPpto.Text), Me.TxtIde.Text)
        End Select
        Me.LbEstado.Text = Me.Oper + " " + obj.Num_PSol
        If Not obj.lErrorG Then ' Si no hubo error deshabilito todo
            If Me.Oper = "nuevo" Then
                LimpiarDespGuardar()
            End If

            Me.TxtNprocA.Text = obj.Num_PSol
            Me.Habilitar(False)
            Me.IBtnCancelar.Enabled = False
            Me.IBtnNuevo.Enabled = True
            Me.IBtnGuardar.Enabled = False
            Me.IBtnAbrir.Enabled = True
            Me.IBtnEditar.Enabled = True
            Me.TxtNProc.Text = obj.Num_PSol
        End If
        Me.MsgBox(Me.MsgResult, obj.lErrorG)

    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TxtPpto.Attributes.Add("onblur", "javascript:Presupuesto();")
            Cancelar()
            If Not String.IsNullOrEmpty(Request("Cod_Sol")) Then
                TxtNprocA.Text = Request("Cod_Sol")
                Abrir()
            End If
            
        End If

    End Sub
    Protected Sub IBtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnNuevo.Click
        Nuevo()
    End Sub
    Private Sub Nuevo()
        Me.Habilitar(True)
        Me.Limpiar()
        'Me.TxtNProc.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.IBtnCancelar.Enabled = True
        Me.IBtnEditar.Enabled = False
        Me.LbEstado.Text = "PENDIENTE"
        Me.LbEncargado.Text = "POR ASIGNAR"
        Me.Oper = "nuevo"
    End Sub

    Private Sub Habilitar(ByVal Valor As Boolean)
        Me.TxtNPla.Enabled = Valor
        'Me.TxtNProc.Enabled = Valor
        Me.TxtObj.Enabled = Valor
        Me.TxtPpto.Enabled = Valor
        Me.cboDep.Enabled = Valor
        Me.CboDepP.Enabled = Valor

        Me.cboStip.Enabled = Valor
        Me.CboTip.Enabled = Valor
        Me.CboTproc.Enabled = Valor
        Me.TxtFechaRecibido.Enabled = Valor
        Me.TxtIde.Enabled = Valor

    End Sub

    Private Sub Limpiar()
        Me.TxtNPla.Text = ""
        Me.TxtNProc.Text = ""
        Me.TxtObj.Text = ""
        TxtNprocA.Text = ""
        Me.TxtFechaRecibido.Text = Today.ToString("dd/MM/yyyy")
        Me.cboDep.SelectedIndex = -1
        Me.CboDepP.SelectedIndex = -1

        Me.cboStip.SelectedIndex = -1
        Me.CboTip.SelectedIndex = -1
        Me.CboTproc.SelectedIndex = -1

        Me.TxtPpto.Text = 0

        Me.MsgResult.CssClass = ""
        Me.MsgResult.Text = ""
        Me.LbEncargado.Text = "SIN ASIGNAR"
        Me.LbEstado.Text = "PENDIENTE"
        TxtIde.Text = ""
        TxtNom.Text = ""
    End Sub
    Private Sub LimpiarDespGuardar()
        Me.TxtNPla.Text = ""
        Me.TxtNProc.Text = ""
        Me.TxtObj.Text = ""
        'TxtNprocA.Text = ""
        Me.TxtFechaRecibido.Text = Today.ToString("dd/MM/yyyy")
        Me.cboDep.SelectedIndex = -1
        Me.CboDepP.SelectedIndex = -1

        Me.cboStip.SelectedIndex = -1
        Me.CboTip.SelectedIndex = -1
        Me.CboTproc.SelectedIndex = -1

        Me.TxtPpto.Text = 0
        TxtIde.Text = ""
        TxtNom.Text = ""
        ' Me.MsgResult.CssClass = ""
        'Me.MsgResult.Text = ""
        'Me.LbEncargado.Text = "SIN ASIGNAR"
        'Me.LbEstado.Text = "PENDIENTE"

    End Sub

    Protected Sub IBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnCancelar.Click
        Cancelar()
    End Sub

    Public Sub Cancelar()
        Me.Limpiar()
        Me.IBtnNuevo.Enabled = True
        Me.IBtnAbrir.Enabled = True
        Me.IBtnGuardar.Enabled = False
        Me.IBtnCancelar.Enabled = False
        Me.IBtnEditar.Enabled = False
        Me.Habilitar(False)
        Me.Oper = ""
    End Sub

    
    Public Sub Editar()
        Habilitar(True)
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Me.CboDepP.Enabled = False
        Me.TxtFechaRecibido.Enabled = False
        Me.IBtnEditar.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnCancelar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.Oper = "editar"

    End Sub
    Public Sub Abrir()
        Me.TxtNprocA.Text = UCase(Me.TxtNprocA.Text)
        Dim dt As DataTable = obj.GetByPk(Me.TxtNprocA.Text)
        If dt.Rows.Count > 0 Then
            Me.MsgResult.Text = ""
            Me.MsgResult.CssClass = ""
            'Me.TxtLugEje.Text=
            'Me.TxtNPla.Text = dt.Rows(0)("NRO_PLA_CON").ToString
            Me.TxtNProc.Text = dt.Rows(0)("Cod_Sol").ToString
            Me.Pk1 = dt.Rows(0)("Cod_Sol").ToString
            Me.TxtObj.Text = dt.Rows(0)("obj_Sol").ToString
            'Me.LbEstado.Text = dt.Rows(0)("nom_est").ToString
            Me.LbEncargado.Text = dt.Rows(0)("Encargado").ToString
            Me.TxtFechaRecibido.Text = CDate(dt.Rows(0)("FECHA_RECIBIDO").ToString).ToShortDateString
            Me.cboDep.SelectedValue = dt.Rows(0)("DEP_SOL").ToString
            Me.CboDepP.SelectedValue = dt.Rows(0)("DEP_PSOL").ToString
            Me.CboTproc.SelectedValue = dt.Rows(0)("COD_TPRO").ToString
            Me.CboTip.SelectedValue = dt.Rows(0)("TIP_CON").ToString
            Me.cboStip.DataBind()
            Me.cboStip.SelectedValue = dt.Rows(0)("STIP_CON").ToString
            Me.TxtNPla.Text = dt.Rows(0)("NUM_PLA").ToString
            Me.TxtPpto.Text = dt.Rows(0)("VAL_CON").ToString
            Me.TxtIde.Text = dt.Rows(0)("IDE_CON").ToString
            BuscarContratista()
            'Me.grdCDP1.Enabled = Valor

            Me.Habilitar(False)
            Me.IBtnAbrir.Enabled = True
            Me.IBtnEditar.Enabled = False
            If dt.Rows(0)("Concepto").ToString = "R" Then
                Me.IBtnEditar.Enabled = True
                Me.LbEstado.Text = "RECHAZADA"
                Me.BtnReabrir.Enabled = True
            ElseIf dt.Rows(0)("Concepto").ToString = "A" Then
                Me.LbEstado.Text = "ACEPTADA"
                Me.BtnReabrir.Enabled = False
            Else
                If dt.Rows(0)("Id_Abog_Enc").ToString = "" Then
                    Me.MsgResult.Text = "No se ha asignado Encargado a la Solicitud"
                    MsgBoxAlert(Me.MsgResult, True)
                    Me.IBtnEditar.Enabled = True
                Else
                    Me.MsgResult.Text = "La Solcitud ya esta Asignada. No puede modificarla."
                    MsgBoxAlert(Me.MsgResult, True)
                End If
                Me.LbEstado.Text = "PENDIENTE"
                Me.BtnReabrir.Enabled = False
            End If

            Me.IBtnGuardar.Enabled = False
            Me.IBtnCancelar.Enabled = True
        Else
            Me.MsgResult.Text = "No se Encontró la Solictud registrada en el Sistema."
            MsgBox(Me.MsgResult, True)
        End If
    End Sub
    'Sub verminuta()
    '    Dim pdf As VerMinuta = New VerMinuta()
    '    Response.Buffer = True
    '    Response.ContentType = "application/pdf"
    '    Response.AddHeader("Content-Disposition", "inline")
    '    Dim MemStream As MemoryStream = New MemoryStream()
    '    MemStream = pdf.GenerarPDF(Me.TxtNprocA.Text)
    '    If MemStream Is Nothing Then
    '        Response.Write("No Data is available for output")
    '    Else
    '        Response.OutputStream.Write(MemStream.GetBuffer(), 0, MemStream.GetBuffer().Length)
    '        Response.OutputStream.Flush()
    '        Response.OutputStream.Close()
    '        MemStream.Close()
    '    End If
    'End Sub

    Protected Sub IBtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        Nuevo()
        Me.IBtnEditar.Enabled = False
    End Sub
    Protected Sub BtnAbrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAbrir.Click
        Abrir()
    End Sub

    Protected Sub TxtNprocA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNprocA.TextChanged
        Abrir()
    End Sub

  
    Sub buscar()
        Me.ModalPopupSolicitudes.Show()
    End Sub
    
    Protected Sub ConPSolicitudesPK1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPSolicitudesPK1.SelClicked
        Me.TxtNprocA.Text = Me.ConPSolicitudesPK1.Cod_Sol
        Abrir()
        Me.ModalPopupSolicitudes.Hide()
        Me.UpdSol.Update()
    End Sub

    Sub ReAbrirSol()
        Me.IBtnGuardar.Enabled = False
        Me.IBtnCancelar.Enabled = True
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Me.Txt_FecRec.Text = Today.ToShortDateString
        Txt_FecRec.Enabled = True
        UpdFecReAbrir.Update()
        Me.ModalPopupExtender3.Show()
    End Sub

    Protected Sub BtnReabrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnReabrir.Click
        ReAbrirSol()

    End Sub

    Protected Sub Btn_Guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = obj.InsertHREV(Me.TxtNProc.Text, Me.Txt_FecRec.Text, Me.Txt_ObsRec.Text)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        Me.ModalPopupExtender3.Hide()
        If obj.lErrorG = False Then
            LbEstado.Text = "PENDIENTE"
            Me.IBtnEditar.Enabled = True
            UpdSol.Update()
        End If


    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + "Ajax"
        End If
    End Sub

    Protected Sub BtnEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnEditar.Click
        Editar()
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MsgBoxLimpiar(MsgResult)
        Desactivar_Timer(Timer1)
    End Sub
    Protected Overloads Sub MsgBox(ByVal msg As Label, ByVal lError As Boolean)
        Activar_Timer(Timer1, lError)
        MyBase.MsgBox(msg, lError)
    End Sub
    Protected Overloads Sub MsgBoxAlert(ByVal msg As Label, ByVal lError As Boolean)
        Activar_Timer(Timer1, lError)
        MyBase.MsgBoxAlert(msg, lError)
    End Sub

    Protected Sub LnkAsig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkAsig.Click
        Asignar()
    End Sub
    Sub Asignar()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Cod_Sol") = TxtNProc.Text
        Redireccionar_Pagina("/Solicitudes/Asignaciones/Asignaciones.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))

    End Sub
  

    Protected Sub BtnAsig0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAsig0.Click
        Asignar()
    End Sub


    Protected Sub IBtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnBuscar.Click
        buscar()
    End Sub

    Protected Sub BtnAnulacion_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnAnulacion.Click
        Redireccionar_Pagina("/Solicitudes/Anulacion/Anulacion.aspx?cod_sol=" + TxtNProc.Text)
    End Sub
    Sub BuscarContratista()
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.TxtIde.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNom.Text = dt.Rows(0)("Nom_Ter").ToString()

            Me.MsgResult.Text = ""
        Else
            Me.MsgResult.Text = "No encontro el Tercero"
            MsgBox(MsgResult, False)
            VerModalPopup("CON")
        End If
    End Sub
    Protected Sub BtnBCon_Click(sender As Object, e As System.EventArgs) Handles BtnBCon.Click
        VerModalPopup("CON")
    End Sub
    Sub VerModalPopup(ByVal Tipo As String)
        AdmTercero1.tipoter = Tipo
        Me.ModalPopup.Show()
    End Sub
    Protected Sub AdmTercero1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdmTercero1.SelClicked

        TxtIde.Text = AdmTercero1.Nit
        TxtNom.Text = AdmTercero1.Nom_Ter
        'BuscarContratista()
        ModalPopup.Hide()
        Me.UpdSol.Update()
    End Sub

    Protected Sub TxtIde_TextChanged(sender As Object, e As System.EventArgs) Handles TxtIde.TextChanged
        BuscarContratista()
    End Sub

   
    Protected Sub IBtnGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBtnGuardar.Click
        Guardar()
    End Sub
End Class
