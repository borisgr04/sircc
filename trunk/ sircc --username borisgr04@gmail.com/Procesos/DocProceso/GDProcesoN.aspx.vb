Imports System.Data

Partial Class Procesos_DocProceso_GDocProceso
    Inherits PaginaComun

    Protected Sub btnGenerarDoc_Click(sender As Object, e As EventArgs) Handles btnGenerarDoc.Click

        Dim pcont As New GProcesos
        Dim dt As DataTable
        Dim NumProc As String = TxtNprocA.Text
        Dim Grupo As String = CboGrupos.SelectedValue
        dt = pcont.GetByPk(NumProc, Grupo)
        Dim est As String = dt.Rows(0).Item("Estado").ToString
        If dt.Rows.Count > 0 Then
            Dim GM As New GDocumentos
            GM.operacion = GDocumentos.eoperacion.Generar
            GM.Num_Proc = NumProc
            GM.Grupo = Grupo
            GM.cTip_Doc = cboTipDoc.SelectedValue
            GM.Ide_Pla = Me.CboPlantilla.SelectedValue
            GM.GenerarMinuta()
            Me.TxtLog.Text = GM.Ultimo_Msg.Replace("<br>", vbCrLf)
            GrdMin.DataBind()
            'End If
        Else
            Me.MsgResult.Text = "No encuentra datos del Contrato."

        End If
    End Sub

    Protected Sub GrdMin_Ppol_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdMin.RowCommand


        'Select Case e.CommandName
        '    Case "Inhabilitar"
        '        If Estado <> "RA" Then
        '            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        '            Me.GrdMin.SelectedIndex = index
        '            Dim objMin As New PGContratosM
        '            LbMinuta.Text = objMin.Anular(Me.TxtNprocA.Text, Me.CboGrupos.SelectedValue, Me.GrdMin.DataKeys(index).Values(0).ToString)
        '            MsgBox(LbMinuta, objMin.lErrorG)
        '            GrdMin.DataBind()
        '            UpdMin.Update()
        '        Else
        '            LbMinuta.Text = "El Contrato ya esta Radicado, No se puede Anular la Minuta"
        '            MsgBoxAlert(LbMinuta, True)

        '        End If

        '    Case "pdf"
        Redireccionar_Pagina("/ashx/VerMinutaPDF.ashx?Num_Proc=" + Me.TxtNprocA.Text + "&Grupo=" + Me.CboGrupos.SelectedValue)

        'End Select
    End Sub

    Protected Sub GrdMin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdMin.SelectedIndexChanged
        If Me.TxtNprocA.Text <> "" Then
            Redireccionar_Pagina("/ashx/VerMinuta.ashx?Num_Proc=" + Me.TxtNprocA.Text + "&Grupo=" + Me.CboGrupos.SelectedValue + "&ID=" + GrdMin.SelectedValue.ToString)
        Else
            MsgResult.Text = "Debe presionar el botón abrir"
            MsgBoxAlert(MsgResult, True)
        End If

    End Sub
End Class
