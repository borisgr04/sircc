Imports System.Data
Partial Class Modificaciones_Solicitud_Solicitud
    Inherits PaginaComun
    Dim obj As New Sol_Adiciones
    Dim objMod As New Modificaciones
    Protected Sub IBtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        If objMod.GetNumSol(DetContrato1.Cod_Con) > 0 Then
            MsgResult.Text = "Debe Completar las Solicitudes Pendientes Antes de Iniciar una Nueva."
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        If objMod.GetNumSolProc(DetContrato1.Cod_Con) Then
            MsgResult.Text = "Debe Radicar o Anular la Modificacion Actual Antes de Solicitar una Nueva"
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        If DetContrato1.Encontrado And DetContrato1.TipRadicacion = "A" Then
            Nuevo()
        Else
            MsgResult.Text = "No se ha Seleccionado Ningún Contrato o Éste no es de Radicación Automatica."
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub
    Sub habilitar(ByVal val As Boolean)
        Me.CboTipMod.Enabled = val
        Me.TxtFechaRecibido.Enabled = val
        Me.TxtObservacion.Enabled = val
    End Sub
    Sub limpiar()
        Me.TxtFechaRecibido.Text = ""
        Me.TxtObservacion.Text = ""
        TxtNProc.Text = ""
    End Sub

    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Select Case Me.oper
            Case "Nuevo"
                MsgResult.Text = obj.Insert(DetContrato1.Cod_Con, CboTipMod.SelectedValue, TxtFechaRecibido.Text, TxtObservacion.Text)
                MsgBox(MsgResult, obj.lErrorG)
                If obj.lErrorG = False Then
                    Me.TxtNProc.Text = obj.Id
                End If
                CboNumSol.DataBind()
            Case "Editar"
                MsgResult.Text = obj.Update(Pk1, DetContrato1.Cod_Con, CboTipMod.SelectedValue, TxtFechaRecibido.Text, TxtObservacion.Text)
                MsgBox(MsgResult, obj.lErrorG)
                CboNumSol.DataBind()
        End Select
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Cancelar()
        End If
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

    Protected Sub DetContrato1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContrato1.AceptarClicked
        MsgBoxLimpiar(MsgResult)
        If DetContrato1.TipRadicacion <> "A" Then
            MsgResult.Text = "Esta Opción es solo para contratos de Radicación Automatica."
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub
    Sub abrir()
        Dim dt As DataTable = obj.GetByPk(CboNumSol.SelectedValue)
        Me.TxtFechaRecibido.Text = CDate(dt.Rows(0)("Fecha_Recibido").ToString).ToShortDateString
        Me.TxtObservacion.Text = dt.Rows(0)("Obser").ToString
        Me.CboTipMod.SelectedValue = dt.Rows(0)("Tip_Adi").ToString
        Me.LblEncargado.Text = dt.Rows(0)("Encargado").ToString
        Me.LblEstado.Text = dt.Rows(0)("Est_Concepto").ToString
        If dt.Rows(0)("Est_Concepto").ToString = "RECHAZADO" Then
            Me.BtnReabrir.Enabled = True
        End If
        If dt.Rows(0)("Id_Abog_Enc").ToString = "" Then
            Me.MsgResult.Text = "No se ha asignado Encargado a la Solicitud"
            MsgBoxAlert(Me.MsgResult, True)
            Me.IBtnEditar.Enabled = True
        Else
            Me.MsgResult.Text = "La Solcitud ya esta Asignada. No puede modificarla."
            MsgBoxAlert(Me.MsgResult, True)
            Me.IBtnEditar.Enabled = False
        End If
        Me.IBtnCancelar.Enabled = True
        Pk1 = Me.CboNumSol.SelectedValue
    End Sub

    Protected Sub IBtnAbrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAbrir.Click
        Cancelar()
        abrir()
    End Sub

    Protected Sub IBtnEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnEditar.Click
        Editar()
    End Sub

    Protected Sub IBtnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnCancelar.Click
        Cancelar()
    End Sub
    Public Sub Editar()
        Habilitar(True)
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Me.TxtFechaRecibido.Enabled = False
        Me.IBtnEditar.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnCancelar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.Oper = "Editar"
    End Sub
    Private Sub Nuevo()
        Me.Habilitar(True)
        Me.Limpiar()
        'Me.TxtNProc.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.IBtnCancelar.Enabled = True
        Me.IBtnEditar.Enabled = False
        Me.Oper = "Nuevo"
    End Sub

    Protected Sub BtnReabrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnReabrir.Click
        Me.IBtnGuardar.Enabled = False
        Me.IBtnCancelar.Enabled = True
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Me.Txt_FecRec.Text = Today.ToShortDateString
        Txt_FecRec.Enabled = True
        UpdFecReAbrir.Update()
        Me.ModalPopupExtender3.Show()
    End Sub

    Protected Sub Btn_Guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        Me.MsgResult.Text = obj.InsertHREV(CboNumSol.SelectedValue, Me.Txt_FecRec.Text, Me.Txt_ObsRec.Text)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        Me.ModalPopupExtender3.Hide()
        If obj.lErrorG = False Then
            LblEstado.Text = "PENDIENTE"
            Me.IBtnEditar.Enabled = True
            'UpdSol.Update()
        End If
    End Sub

    Protected Sub BtnAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAsignar.Click
        If Me.TxtNProc.Text = "" Then
            MsgResult.Text = "Debe haber una solicitud seleccionada."
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        Redireccionar_Pagina("/Modificaciones/Asignar/Asignaciones.aspx?Num_Sol=" + Me.TxtNProc.Text + "&Cod_Con=" + Me.DetContrato1.Cod_Con)
    End Sub
End Class
