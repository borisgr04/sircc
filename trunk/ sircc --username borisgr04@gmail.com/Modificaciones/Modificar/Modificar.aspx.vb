Imports System.Data
Partial Class Modificaciones_Modificar_Solicitud
    Inherits PaginaComun
    Dim obj As New Sol_Adiciones
    Protected Sub IBtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        If DetContrato1.Encontrado Then
            Nuevo()
        Else
            MsgResult.Text = "Debe seleccionar un contrato"
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
    End Sub

    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Select Case Me.Oper
            Case "Nuevo"
                MsgResult.Text = obj.Insert(DetContrato1.Cod_Con, CboTipMod.SelectedValue, TxtFechaRecibido.Text, TxtObservacion.Text)
                MsgBox(MsgResult, obj.lErrorG)
                If obj.lErrorG = False Then
                    habilitar(False)
                    IBtnEditar.Enabled = True
                    IBtnGuardar.Enabled = False
                End If
                CboNumSol.DataBind()
            Case "Editar"
                MsgResult.Text = obj.Update(Pk1, DetContrato1.Cod_Con, CboTipMod.SelectedValue, TxtFechaRecibido.Text, TxtObservacion.Text)
                MsgBox(MsgResult, obj.lErrorG)
                If obj.lErrorG = False Then
                    habilitar(False)
                    IBtnEditar.Enabled = True
                    IBtnGuardar.Enabled = False
                End If
                CboNumSol.DataBind()
        End Select
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString.Count > 0 Then
                Me.DetContrato1.Cod_Con = Request("Cod_Con")
                CboNumSol.DataBind()
                Me.CboNumSol.SelectedValue = Request("Num_Sol")
                abrir()
            Else
                Cancelar()
            End If
        End If
    End Sub
    Public Sub Cancelar()
        Me.limpiar()
        Me.IBtnNuevo.Enabled = True
        Me.IBtnAbrir.Enabled = True
        Me.IBtnGuardar.Enabled = False
        Me.IBtnCancelar.Enabled = False
        Me.IBtnEditar.Enabled = False
        Me.habilitar(False)
        Me.Oper = ""
    End Sub

    Protected Sub DetContrato1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContrato1.AceptarClicked
        MsgBoxLimpiar(MsgResult)
    End Sub
    Sub abrir()
        Dim dt As DataTable = obj.GetByPkAbog(CboNumSol.SelectedValue)
        Me.TxtFechaRecibido.Text = CDate(dt.Rows(0)("Fecha_Recibido").ToString).ToShortDateString
        Me.TxtObservacion.Text = dt.Rows(0)("Obser").ToString
        Me.CboTipMod.SelectedValue = dt.Rows(0)("Tip_Adi").ToString
        Me.LblEncargado.Text = dt.Rows(0)("Encargado").ToString
        Me.LblEstado.Text = dt.Rows(0)("Est_Concepto").ToString
        If dt.Rows(0)("Est_Concepto").ToString = "RECHAZADO" Or dt.Rows(0)("Est_Concepto").ToString = "ACEPTADO" Then
            MsgResult.Text = "Solo se pueden modificar las solicitudes en estado PENDIENTE"
            MsgBoxAlert(MsgResult, True)
            Me.IBtnEditar.Enabled = False
        Else
            Me.IBtnEditar.Enabled = True
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
        habilitar(True)
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
        Me.habilitar(True)
        Me.limpiar()
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
End Class
