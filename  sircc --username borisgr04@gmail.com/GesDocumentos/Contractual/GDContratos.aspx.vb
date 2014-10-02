Imports System.Data
Imports System.IO
'Modificado el 10 de septiembre de 2011- BORIS
' SE AGREGO GENERACION DE MINUTAS A PARTIR DE OTRA PAGINA DE ERCI
Partial Class GesDocumentos_Contractual_GDContratos
    Inherits PaginaComun
    Dim obj As GProcesos = New GProcesos

    'Protected Sub GrdMin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdMin.SelectedIndexChanged

    '    If Me.TxtNprocA.Text <> "" Then
    '        Redireccionar_Pagina("/ashx/VerMinuta.ashx?Num_Proc=" + Me.TxtNprocA.Text + "&Grupo=1" + "&ID=" + GrdMin.SelectedValue.ToString)
    '    Else
    '        LbMinuta.Text = "Debe presionar el botón abrir"
    '        MsgBoxAlert(LbMinuta, True)
    '    End If

    'End Sub

    Protected Sub BtnGen_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGen.Click

        'Dim dt As DataTable
        'dt = pcont.GetByPk(TxtNprocA.Text, CboGrupos.SelectedValue)
        'Dim est As String = dt.Rows(0).Item("Estado").ToString

        MsgBoxLimpiar(LbMinuta)
        'If dt.Rows.Count > 0 Then
        'If est = "TR" Then
        '    Me.MsgResult.Text = "El proceso no se encuentra validado para generar MINUTA"
        '    LbMinuta.Text = Me.MsgResult.Text
        '    MsgBoxAlert(MsgResult, True)
        '    MsgBoxAlert(LbMinuta, True)
        'Else
        'Dim dtDoc As DataTable = tdoc.GetbyPkV(GM.cTip_Doc)
        'Dim ESProceso As String = dtDoc.Rows(0)("PROCESO")

        'Me.Title = ESProceso

        ''Asignar una consulta con los datos requeridos ademas se debe asignar el nombre de la vista
        ''GM.dtDatosCruzas = 
        ''GM.Vista = "VGPROCESOSC" 'VistaClave
        If Not IsDate(txtFecha.Text) Then
            LbMinuta.Text = "La fecha digitada " + Me.txtFecha.Text + " no tiene un formato válido, Escriba una fecha con el formato dd/mm/aaaa."
            MsgBoxAlert(LbMinuta, True)
            LbMinuta.Visible = True
        Else

            Dim pcont As New GProcesos
            Dim GM As New GDocumentos
            GM.operacion = GDocumentos.eoperacion.Generar
            GM.Num_Proc = Me.TxtNprocA.Text
            'GM.Grupo = Me.CboGrupos.SelectedValue
            GM.Fec_Doc = Me.txtFecha.Text
            GM.cTip_Doc = cboTipDoc.SelectedValue
            Dim tdoc As New Tip_Doc
            Dim ObjCD As New CtrGenDocContratos
            Dim dt As DataTable = ObjCD.GetContratos(Me.TxtNprocA.Text)
            If dt.Rows.Count > 0 Then
                Dim cdp As New CDP_Contratos
                Dim rp As New RP_Contratos
                Dim pol As New Polizas_Contrato


                Dim gdTabla As GDTabla
                Dim ft As GDFormatoTabla

                'Por Cada tabla Hacer Esto

                gdTabla = New GDTabla()
                'Crear DataTable Con Informacion de la Tabla
                Dim dtCDP As DataTable = cdp.GetRecordsPlantillas(Me.TxtNprocA.Text)
                gdTabla.Tabla = dtCDP
                gdTabla.Formato = Nothing

                'Por Cada Columna Hacer Esto
                ft = New GDFormatoTabla()
                ft.ANCHO = 10
                ft.NOM_CAM = "NRO_CDP"
                ft.DES_CAM = "N° CDP"
                ft.TIP_DAT = "C"

                'gdTabla.Formato.Add(ft)

                'formato para otroa columan
                ft = New GDFormatoTabla()
                ft.ANCHO = 10
                ft.NOM_CAM = "FEC_CDP"
                ft.DES_CAM = "FECHA CDP"
                ft.TIP_DAT = "D"

                'gdTabla.Formato.Add(ft)

                GM.AddDictionaryTablas("CDP", gdTabla)


                'Por Cada tabla Hacer Esto

                gdTabla = New GDTabla()
                'Crear DataTable Con Informacion de la Tabla
                Dim dtRP As DataTable = rp.GetRecordsPlantillas(Me.TxtNprocA.Text)
                gdTabla.Tabla = dtRP
                gdTabla.Formato = Nothing

                'Por Cada Columna Hacer Esto
                ft = New GDFormatoTabla()
                ft.ANCHO = 10
                ft.NOM_CAM = "NRO_RP"
                ft.DES_CAM = "N° RP"
                ft.TIP_DAT = "C"

                'gdTabla.Formato.Add(ft)

                'formato para otroa columan
                ft = New GDFormatoTabla()
                ft.ANCHO = 10
                ft.NOM_CAM = "FEC_RP"
                ft.DES_CAM = "FECHA RP"
                ft.TIP_DAT = "D"

                'gdTabla.Formato.Add(ft)

                GM.AddDictionaryTablas("RP", gdTabla)


                'Por Cada tabla Hacer Esto
                gdTabla = New GDTabla()
                'Crear DataTable Con Informacion de la Tabla
                Dim dtPol As DataTable = pol.GetRecordsPlantillas(Me.TxtNprocA.Text)
                gdTabla.Tabla = dtPol
                gdTabla.Formato = Nothing

                'Por Cada Columna Hacer Esto
                ft = New GDFormatoTabla()
                ft.ANCHO = 10
                ft.NOM_CAM = "NRO_RP"
                ft.DES_CAM = "N° RP"
                ft.TIP_DAT = "C"

                'gdTabla.Formato.Add(ft)

                'formato para otroa columan
                ft = New GDFormatoTabla()
                ft.ANCHO = 10
                ft.NOM_CAM = "FEC_RP"
                ft.DES_CAM = "FECHA RP"
                ft.TIP_DAT = "D"

                'gdTabla.Formato.Add(ft)
                GM.AddDictionaryTablas("POLIZA", gdTabla)




                GM.dtDatosCruzas = dt
                GM.Vista = "VCONTRATOS"
                GM.Fec_Doc = txtFecha.Text
                GM.cNom_Tip_Doc = cboTipDoc.SelectedItem.Text
                Dim p As New PPlantillas
                'Habilitar para generar Minuta
                GM.Ide_Pla = Me.CboPlantilla.SelectedValue
                GM.GenerarMinuta()
                Me.TxtLog.Text = GM.Ultimo_Msg.Replace("<br>", vbCrLf)
                'GrdMin.DataBind()
                grdDocP.DataBind()
            Else
                LbMinuta.Text = "El contrato no existe"
                MsgBoxAlert(LbMinuta, True)
                LbMinuta.Visible = True
            End If

        End If


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



    Protected Sub grdDocP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDocP.SelectedIndexChanged
        Redireccionar_Pagina("/ashx/VerPDoc.ashx?ID=" + grdDocP.SelectedValue.ToString)
    End Sub

    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cboEtapas.SelectedValue = "04"
            cboEtapas.Enabled = False
        End If

    End Sub
End Class
