Imports System.Data
Imports System.IO

Partial Class Solicitudes_ModSolicitud_Default
    Inherits PaginaComun
    Dim obj As PSolicitudes = New PSolicitudes


    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnGuardar.Click
        Guardar()
    End Sub
    Public Sub Guardar()
        If Me.cboDep.SelectedIndex = 0 Then
            Me.MsgResult.Text = "Seleccione la Dependencia que Origina la Necesidad"
            MsgBox(MsgResult, True)
            Exit Sub
        End If
        obj = New PSolicitudes
        Select Case Me.Oper
            Case "nuevo"
                Me.MsgResult.Text = obj.Insert(Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, Me.Vigencia, Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, Me.CboTproc.SelectedValue, Me.TxtObj.Text, Me.TxtFechaRecibido.Text, Me.TxtNPla.Text, Publico.PuntoPorComa(Me.TxtPpto.Text), TxtIde.Text)
            Case "editar"
                Me.MsgResult.Text = obj.Update(Me.Pk1, Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, Me.Vigencia, Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, Me.CboTproc.SelectedValue, Me.TxtObj.Text, Me.TxtFechaRecibido.Text, Me.TxtNPla.Text, Publico.PuntoPorComa(Me.TxtPpto.Text), TxtIde.Text)
        End Select
        If obj.lErrorG = False Then
            Me.TxtNprocA.Text = obj.Num_PSol
            Me.MsgBox(Me.MsgResult, obj.lErrorG)
            Me.Habilitar(False)
            Me.IBtnCancelar.Enabled = False
            Me.IBtnGuardar.Enabled = False
            Me.IBtnAbrir.Enabled = True
            Me.TxtNProc.Text = obj.Num_PSol
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TxtPpto.Attributes.Add("onblur", "javascript:Presupuesto();")
            If Request.QueryString.Count > 0 Then
                'querystringSeguro = Me.GetRequest()
                'Me.TxtNprocA.Text = querystringSeguro("Cod_Sol")
                Me.TxtNprocA.Text = Request("Cod_Sol")
                Abrir()
            Else
                Cancelar()
            End If
        End If
    End Sub
    Private Sub Nuevo()
        Me.Habilitar(True)
        Me.Limpiar()
        'Me.TxtNProc.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnCancelar.Enabled = True
        Me.IBtnEditar.Enabled = False
        Me.LbEstado.Text = ""
        Me.LbEncargado.Text = ""
        Me.Oper = "nuevo"
    End Sub

    Private Sub Habilitar(ByVal Valor As Boolean)
        Me.TxtNPla.Enabled = Valor
        'Me.TxtNProc.Enabled = Valor
        Me.TxtObj.Enabled = Valor

        Me.cboDep.Enabled = Valor
        Me.CboDepP.Enabled = Valor

        Me.cboStip.Enabled = Valor
        Me.CboTip.Enabled = Valor
        Me.CboTproc.Enabled = Valor
        Me.TxtPpto.Enabled = Valor
        Me.TxtFechaRecibido.Enabled = Valor
        Me.TxtIde.Enabled = Valor
    End Sub

    Private Sub Limpiar()
        Me.TxtNPla.Text = ""
        Me.TxtNProc.Text = ""
        Me.TxtObj.Text = ""
        TxtNprocA.Text = ""
        Me.TxtPpto.Text = 0
        Me.TxtFechaRecibido.Text = Today.ToString("dd/MM/yyyy")
        Me.cboDep.SelectedIndex = -1
        Me.CboDepP.SelectedIndex = -1

        Me.cboStip.SelectedIndex = -1
        Me.CboTip.SelectedIndex = -1
        Me.CboTproc.SelectedIndex = -1
        Me.LbEncargado.Text = ""
        Me.LbEstado.Text = ""
        Me.MsgResult.CssClass = ""
        Me.MsgResult.Text = ""
        Me.TxtIde.Text = ""
        Me.TxtNom.Text = ""


    End Sub

    Protected Sub IBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnCancelar.Click
        Cancelar()
    End Sub

    Public Sub Cancelar()
        Me.Limpiar()
        Me.IBtnAbrir.Enabled = True
        Me.IBtnGuardar.Enabled = False
        Me.IBtnCancelar.Enabled = False
        Me.IBtnEditar.Enabled = False
        Me.Habilitar(False)
        Me.Oper = ""
    End Sub

    Protected Sub BtnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnEditar.Click
        Editar()

    End Sub
    Public Sub Editar()
        Habilitar(True)
        Me.TxtFechaRecibido.Enabled = False
        Me.IBtnEditar.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnCancelar.Enabled = True
        Me.Oper = "editar"
    End Sub
    Public Sub Abrir()
        If Me.TxtNprocA.Text = "" Then
            Me.MsgResult.Text = "Debe seleccionar o escribir un número de solicitud"
            MsgBox(Me.MsgResult, True)
            Exit Sub
        End If
        Me.TxtNprocA.Text = UCase(Me.TxtNprocA.Text)
        Dim dt As DataTable = obj.GetByPkAbog(Me.TxtNprocA.Text)
        If dt.Rows.Count > 0 Then

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
            TxtIde.Text = dt.Rows(0)("IDE_CON").ToString
            BuscarContratista()
            'Me.grdCDP1.Enabled = Valor

            Me.Habilitar(False)
            Me.IBtnAbrir.Enabled = True
            Me.IBtnEditar.Enabled = False
            If dt.Rows(0)("Concepto").ToString = "R" Then
                Me.IBtnEditar.Enabled = True
                Me.LbEstado.Text = "RECHAZADA"
            ElseIf dt.Rows(0)("Concepto").ToString = "A" Then
                Me.LbEstado.Text = "ACEPTADA"
            Else
                Me.LbEstado.Text = "PENDIENTE"
                Me.IBtnEditar.Enabled = True
            End If

            Me.IBtnGuardar.Enabled = False
            Me.IBtnCancelar.Enabled = True
            Me.MsgResult.Text = ""
            Me.MsgResult.CssClass = ""
        Else
            Me.MsgResult.Text = "No se encontró el registro"
            MsgBox(Me.MsgResult, True)
        End If


    End Sub

    
  

    Protected Sub BtnAbrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAbrir.Click
        Abrir()
    End Sub

    Protected Sub TxtNprocA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNprocA.TextChanged
        Abrir()
    End Sub




    Protected Sub ConPSolicitudesPK1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles conpsolicitudes1.SelClicked
        Me.TxtNprocA.Text = Me.conpsolicitudes1.Cod_Sol
        Abrir()
        Me.ModalPopupSolicitudes.Hide()
    End Sub

    Protected Sub Btn_Guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = obj.InsertHREV(Me.TxtNProc.Text, Me.Txt_FecRec.Text, Me.Txt_ObsRec.Text)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        Me.IBtnEditar.Enabled = True
    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + "Ajax"
        End If
    End Sub

    Protected Sub BtnBuscar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Me.ModalPopupSolicitudes.Show()
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
        'Me.UpdatePanel1.Update()
    End Sub
End Class
