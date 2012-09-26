Imports System.Data
Partial Class Reportes_Parametrizado_Default
    Inherits PaginaComun

    Dim Generar As Boolean = False
    Protected Sub Generar_Reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Generar_Reporte.Click
        MsgResult.Text = ""
        MsgBoxLimpiar(MsgResult)
        Generar = False
        Dim cSql As String = Sql()
        If Generar Then
            If Me.rdGroup.SelectedValue = "Pol_Con" Then
                Response.Redirect("ReportPPol.aspx?sql=" + Server.UrlEncode(cSql) & "&tit=" + Server.UrlEncode("") & "&Rpte=" + Server.UrlEncode(Me.rdGroup.SelectedValue))
            Else
                Response.Redirect("ReportP.aspx?sql=" + Server.UrlEncode(cSql) & "&tit=" + Server.UrlEncode("") & "&Rpte=" + Server.UrlEncode(Me.rdGroup.SelectedValue))
            End If
        End If
    End Sub

    Protected Function Sql() As String
        Dim strsql As String
        Dim obj As New Contratos()
        Dim cFiltro As String = ""
        Generar = True
        If (ChkNum.Checked = True) Then
            If (Me.TxtNCon.Text.Length <> 10) Then
                chkTip.Checked = True
                Me.TxtNCon.Text = obj.GetCodigo(Me.CboTip.SelectedValue, Me.TxtNCon.Text, Me.Vigencia_Cookie)
            End If
            Util.AddFiltro(cFiltro, "numero Like '" + TxtNCon.Text + "'")
        End If

        If (chkTip.Checked = True) Then
            Util.AddFiltro(cFiltro, "tip_con='" + CboTip.Text + "'")
        End If
        If (ChkDep.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_con='" + CboDep.Text + "'")
        End If
        If (ChkFecSus.Checked = True) Then
            Util.AddFiltro(cFiltro, "FEC_SUS_CON BETWEEN TO_DATE('" + CDate(TxtFecSus1.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecSus2.Text).ToShortDateString + "','dd/mm/yyyy')")
        End If
        If (ChkFecR.Checked = True) Then
            Util.AddFiltro(cFiltro, "to_date(to_char(fec_reg,'dd/mm/yyyy'),'dd/mm/yyyy') BETWEEN TO_DATE('" + CDate(TxtFecReg1.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecReg2.Text).ToShortDateString + "','dd/mm/yyyy')")
        End If

        If (ChkEst.Checked = True) Then
            Util.AddFiltro(cFiltro, "est_con='" + CboEst.Text + "'")
        End If
        If (ChkStip.Checked = True) Then
            Util.AddFiltro(cFiltro, "stip_con='" + cboStip.Text + "'")
        End If
        If (ChkCon.Checked = True) Then
            Util.AddFiltro(cFiltro, "ide_con='" + TxtIde.Text + "'")
        End If
        'Contratista
        'If (ChkInt.Checked = True) Then
        'Util.AddFiltro(cFiltro, "ide_con='" + TxtIdeInt.Text + "'")
        'End If
      
        If (ChkSec.Checked = True) Then
            Util.AddFiltro(cFiltro, "cod_sec='" + Cbosec.Text + "'")
        End If
        If (ChkProy.Checked = True) Then
            Util.AddFiltro(cFiltro, "pro_con='" + Proyecto.Text + "'")
        End If
        If (ChkProy_C.Checked = True) Then
            Util.AddFiltro(cFiltro, "pro_con is not null")
        End If
        If (ChkPla.Checked = True) Then
            Util.AddFiltro(cFiltro, "nro_pla_con='" + txtPla.Text + "'")
        End If
        If (ChkValC.Checked = True) Then
            Util.AddFiltro(cFiltro, "val_con BETWEEN " + TxtValC1.Text + " And " + TxtValC2.Text)
        End If
        If (ChkObj.Checked = True) Then
            Util.AddFiltro(cFiltro, "OBJ_CON LIKE '" + UCase(TxtObj.Text) + "'")
        End If
        If (Me.ChkProc.Checked = True) Then
            Util.AddFiltro(cFiltro, "cod_tpro = '" + Me.CboTproc.SelectedValue + "'")
        End If
        If (Me.ChkPDep.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_pcon = '" + Me.CboDepP.SelectedValue + "'")
        End If
        If (Me.ChkInt.Checked = True) Then
            Util.AddFiltro(cFiltro, "IDE_INT = '" + Me.TxtIdeInt.Text + "'")
        End If
        If (Me.ChkAnul.Checked = False) Then
            Util.AddFiltro(cFiltro, "EST_CON <> '07'")
        End If

        '----- 
        If (ChkRubros.Checked = True) Then
            ' Util.AddFiltro(cFiltro, "cod_rub LIKE '" + UCase(TxtRub.Text) + "%'")
            Util.AddFiltro(cFiltro, "NUMERO IN (SELECT DISTINCT NUMERO FROM VCONTRATOS_RUBROS WHERE COD_RUB LIKE '" + UCase(TxtRub.Text) + "')")
        End If

        '----- 
        If (ChkRecurso.Checked = True) Then
            ChkVig.Checked = True
            Util.AddFiltro(cFiltro, "NUMERO IN (SELECT DISTINCT COD_CON FROM vRubros_Contratos01 WHERE  COD_RECURSO IN (" + Util.FormatCVS(TxtRecurso.Text) + ") and vigencia='" + TxtVig.Text + "')")
        End If

        If (ChkVig.Checked = True) Then
            Util.AddFiltro(cFiltro, "vig_con='" + TxtVig.Text + "'")
        End If

        If (ChkCDP.Checked = True) Then
            If Not (String.IsNullOrEmpty(TxtNroCdp.Text)) And Not (String.IsNullOrEmpty(TxtVigCDP.Text)) Then
                Util.AddFiltro(cFiltro, "NUMERO IN (select Cod_Con from cdp_contratos where nro_cdp In (" + Util.FormatCVS(TxtNroCdp.Text) + ") AND to_char(fec_cdp,'yyyy')=" + TxtVigCDP.Text + ")")
            Else
                MsgResult.Text = "Cuando Desee Filtrar por CDP, debe digitar el numero de Cdp y La Vigencia del CDP"
                MsgBoxAlert(MsgResult, True)
                Generar = False
            End If
        End If

        If (ChkRP.Checked = True) Then
            If Not (String.IsNullOrEmpty(TxtNroRP.Text)) And Not (String.IsNullOrEmpty(TxtVigRP.Text)) Then
                Util.AddFiltro(cFiltro, "NUMERO IN (select Cod_Con from rp_contratos where nro_rp In (" + Util.FormatCVS(TxtNroRP.Text) + ") AND to_char(fec_rp,'yyyy')=" + TxtVigRP.Text + ")")
            Else
                MsgResult.Text = "Cuando Desee Filtrar por RP, debe digitar el numero de RP y La Vigencia del RP"
                MsgBoxAlert(MsgResult, True)
                Generar = False
            End If
        End If


        If cFiltro <> String.Empty Then
            cFiltro = "Where " + cFiltro
        End If
        'strSql = "SELECT *  FROM VCONTRATOS_RUBROS2  " + cFiltro + " Order by Numero"
        'strSql = "SELECT *  FROM VCONTRATOSC2  " + cFiltro + " Order by Numero"
        'strSql = "SELECT * FROM vcontratosc2 c  LEFT JOIN (SELECT   cod_con, COUNT (*) nro_adi, Nvl(SUM (Nvl(pla_eje_adi,0)),0) pla_adi,Nvl(SUM(Nvl(val_adi,0)),0) val_adi FROM adiciones GROUP BY cod_con) a ON c.numero = a.cod_con " + cFiltro + " ORDER BY numero"
        If Me.rdGroup.SelectedValue = "Pol_Con" Then
            strsql = "SELECT c.*,Cant_Adicion(c.numero) nro_adi,Plazo_Adicion(c.numero) Pla_Adi,Valor_Adicion(c.numero) Val_Adi FROM vcontratos_Sinc_p_pol c  " + cFiltro + " ORDER BY numero, cod_pol"
            strsql = "SELECT c.* FROM vcontratos_Sinc_p_pol c  " + cFiltro + " ORDER BY numero, cod_pol"
        Else
            strsql = "SELECT c.* FROM vcontratos_Sinc_p c  " + cFiltro + " ORDER BY numero"
        End If


        Return strsql
    End Function

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TxtVig.Text = Vigencia_Cookie
            Me.ChkVig.Checked = True
        End If
    End Sub

    Protected Sub BtnBCon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBCon.Click
        VerModalPopup("CON")
    End Sub

    Protected Sub ConsultaTerS1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConsultaTerS1.SelClicked
        If ConsultaTerS1.tipoter = "CON" Then
            TxtIde.Text = ConsultaTerS1.Ide_Ter
            BuscarInt()
        ElseIf ConsultaTerS1.TipoTer = "INT" Then
            TxtIdeInt.Text = ConsultaTerS1.Ide_Ter
            BuscarCon()
        End If
        TxtIde.Text = ConsultaTerS1.Ide_Ter
        'BuscarContratista()
        ModalPopup.Hide()
    End Sub

    Sub VerModalPopup(ByVal Tipo As String)
        ConsultaTerS1.TipoTer = Tipo
        Me.ModalPopup.Show()
    End Sub

    Protected Sub BtnBInt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBInt.Click
        VerModalPopup("INT")
    End Sub

    Sub BuscarInt()
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.TxtIde.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNom.Text = dt.Rows(0)("Nom_Ter").ToString()
            'Me.MsgResult.Text = ""
        Else
            'Me.MsgResult.Text = "No encontro el Tercero"
            'MsgBox(MsgResult, False)
            'VerModalPopup("RLC")
        End If
    End Sub

    Sub BuscarCon()
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.TxtIdeInt.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNomInt.Text = dt.Rows(0)("Nom_Ter").ToString()
            'Me.MsgResult.Text = ""
        Else
            'Me.MsgResult.Text = "No encontro el Tercero"
            'MsgBox(MsgResult, False)
            'VerModalPopup("RLC")
        End If
    End Sub
End Class
