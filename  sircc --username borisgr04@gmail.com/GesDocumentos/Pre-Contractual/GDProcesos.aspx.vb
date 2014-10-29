Imports System.Data
Imports System.IO
'Modificado el 10 de septiembre de 2011- BORIS
' SE AGREGO GENERACION DE MINUTAS A PARTIR DE OTRA PAGINA DE ERCI
Partial Class GesDocumentos_Pre_Contractual_GDProcesos
    Inherits PaginaComun
    Dim obj As GProcesos = New GProcesos

    Protected Sub GrdMin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdMin.SelectedIndexChanged

        If Me.TxtNprocA.Text <> "" Then
            Redireccionar_Pagina("/ashx/VerMinuta.ashx?Num_Proc=" + Me.TxtNprocA.Text + "&Grupo=" + Me.CboGrupos.SelectedValue + "&ID=" + GrdMin.SelectedValue.ToString)
        Else
            LbMinuta.Text = "Debe presionar el botón abrir"
            MsgBoxAlert(LbMinuta, True)
        End If

    End Sub

    Protected Sub BtnGen_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGen.Click
        Dim pcont As New GProcesos
        Dim dt As DataTable
        dt = pcont.GetByPk(TxtNprocA.Text, CboGrupos.SelectedValue)
        Dim est As String = dt.Rows(0).Item("Estado").ToString

        MsgBoxLimpiar(LbMinuta)
        If dt.Rows.Count > 0 Then
            'If est = "TR" Then
            '    Me.MsgResult.Text = "El proceso no se encuentra validado para generar MINUTA"
            '    LbMinuta.Text = Me.MsgResult.Text
            '    MsgBoxAlert(MsgResult, True)
            '    MsgBoxAlert(LbMinuta, True)
            'Else
            Dim GM As New GDocumentos
            GM.operacion = GDocumentos.eoperacion.Generar
            GM.Num_Proc = Me.TxtNprocA.Text
            GM.Grupo = Me.CboGrupos.SelectedValue
            GM.cTip_Doc = cboTipDoc.SelectedValue
            Dim tdoc As New Tip_Doc

            Dim dtDoc As DataTable = tdoc.GetbyPkV(GM.cTip_Doc)
            Dim ESProceso As String = dtDoc.Rows(0)("PROCESO")

            Me.Title = ESProceso

            'Habilitar para mandar vista especifica
            'Dim dtP As DataTable = p.GetbyPK(Me.CboPlantilla.SelectedValue)
            'Dim VistaClave As String
            'VistaClave = dtP.Rows(0)("Clave")
            'GM.Vista = "VGPROCESOSC" 'VistaClave

            If ESProceso = "SI" Then
                Dim proc As New ConGProcesos
                GM.dtDatosCruzas = proc.GetByPkC_Plantillas(GM.Num_Proc, GM.Grupo)
            Else
                ''Asignar una consulta con los datos requeridos ademas se debe asignar el nombre de la vista
                ''GM.dtDatosCruzas = 
                ''GM.Vista = "VGPROCESOSC" 'VistaClave

                Dim ObjCD As New CtrGenDocContratos
                GM.dtDatosCruzas = ObjCD.GetContratos("2014020896")
                GM.Vista = "VCONTRATOS"

            End If

            GM.Fec_Doc = txtFecha.Text
            GM.cNom_Tip_Doc = cboTipDoc.SelectedItem.Text
            Dim p As New PPlantillas



            'Habilitar para generar Minuta
            GM.Ide_Pla = Me.CboPlantilla.SelectedValue
            GM.GenerarMinuta()
            Me.TxtLog.Text = GM.Ultimo_Msg.Replace("<br>", vbCrLf)
            GrdMin.DataBind()
            grdDocP.DataBind()
            'End If
        Else

        End If


    End Sub
    Protected Sub GrdMin_Ppol_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdMin.RowCommand


        Select Case e.CommandName
            Case "Inhabilitar"
                'If Estado <> "RA" Then
                '    Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                '    Me.GrdMin.SelectedIndex = index
                '    Dim objMin As New PGContratosM
                '    LbMinuta.Text = objMin.Anular(Me.TxtNprocA.Text, Me.CboGrupos.SelectedValue, Me.GrdMin.DataKeys(index).Values(0).ToString)
                '    MsgBox(LbMinuta, objMin.lErrorG)
                '    GrdMin.DataBind()
                '    UpdMin.Update()
                'Else
                '    LbMinuta.Text = "El Contrato ya esta Radicado, No se puede Anular la Minuta"
                '    MsgBoxAlert(LbMinuta, True)

                'End If

            Case "pdf"
                Redireccionar_Pagina("/ashx/VerMinutaPDF.ashx?Num_Proc=" + Me.TxtNprocA.Text + "&Grupo=" + Me.CboGrupos.SelectedValue)

        End Select
    End Sub

    Protected Sub ChkLog_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLog.CheckedChanged
        If ChkLog.Checked = True Then
            Me.TxtLog.Visible = True
        Else
            Me.TxtLog.Visible = False
        End If
    End Sub

    Protected Sub grdDocP_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocP.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.grdDocP.SelectedIndex = index

        Select Case e.CommandName
            Case "Inhabilitar"
                Dim obj As New DocPContratos
                LbMinuta.Text = obj.Anular(Me.TxtNprocA.Text, Me.grdDocP.SelectedValue)
                MsgBox(LbMinuta, obj.lErrorG)
                grdDocP.DataBind()
            Case "pdf"
                Redireccionar_Pagina("/ashx/VerPDoc.ashx?tipo=pdf&ID=" + grdDocP.SelectedValue.ToString)
            Case "doc"
                Redireccionar_Pagina("/ashx/VerPDoc.ashx?ID=" + grdDocP.SelectedValue.ToString)
        End Select
    End Sub


    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cboEtapas.SelectedValue = "02"
            cboEtapas.Enabled = False
        End If

    End Sub
End Class
