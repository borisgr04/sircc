﻿Imports System.Data
Partial Class SolicitudesAdi_Revision_Default
    Inherits PaginaComun
    Dim obj As New Sol_Adiciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString.Count > 0 Then
                DetContratoAdi1.IdSolAdi = Request("Num_Sol")
                DetContratoAdi1.Cod_Con = Request("Cod_Con")
                DetContratoAdi1.Buscar2()
                DetPSolicitudes1_OnAceptarClicked(Nothing, Nothing)
            End If
        End If
    End Sub
    Protected Sub DetPSolicitudes1_OnAceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContratoAdi1.AceptarClicked
        If Me.DetContratoAdi1.Encontrado = True Then
            Me.Panel4.Visible = True
            Me.TxtFechaRevision.Text = Today.ToShortDateString
            MsgBoxLimpiar(MsgResult)
            Me.TxtObs.Text = ""
            Dim dt As DataTable
            dt = obj.GetByPkAbog(Me.DetContratoAdi1.IdSolAdi)
            If dt.Rows(0)("Concepto").ToString = "A" Or dt.Rows(0)("Concepto").ToString = "R" Then
                Habilitar(False)
            Else
                Habilitar(True)
            End If
            Pk1 = dt.Rows(0)("id_hrev").ToString
        Else
            Me.Panel4.Visible = False
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        If CboConcepto.SelectedValue = "R" And String.IsNullOrEmpty(TxtObs.Text) Then
            MsgResult.Text = "Cuando el Concepto emitido es 'RECHAZADO', debe escribir una Observación, la cual se notificará via Correo Electrónico a la dependencia que envia la Solicitud"
            MsgBoxAlert(MsgResult, True)
            Return
        End If
        MsgResult.Text = obj.Revision(Me.DetContratoAdi1.IdSolAdi, Me.TxtFechaRevision.Text, Me.TxtObs.Text, Me.CboConcepto.SelectedValue, Pk1, DetContratoAdi1.Cod_Con)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        If Not obj.lErrorG Then
            Me.GridView1.DataBind()
            limpiar()
            Habilitar(False)
        End If
    End Sub
    Sub Habilitar(ByVal b As Boolean)
        Me.IBtnGuardar.Enabled = b
        'Me.TxtFechaRevision.Enabled = b
        Me.TxtObs.Enabled = b
        Me.CboConcepto.Enabled = b
    End Sub
    Sub limpiar()
        Me.TxtObs.Text = ""
        Me.TxtFechaRevision.Text = Today.ToShortDateString
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        MsgBoxLimpiar(MsgResult)
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.GridView1.SelectedIndex = index
        Dim nr As New NotificacionesEmail
        MsgResult.Text = nr.Notificar_RevisionSol(GridView1.SelectedDataKey(0).ToString(), GridView1.SelectedDataKey(1).ToString())
        MsgBox(MsgResult, nr.lErrorG)
    End Sub


    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If
    End Sub
End Class

