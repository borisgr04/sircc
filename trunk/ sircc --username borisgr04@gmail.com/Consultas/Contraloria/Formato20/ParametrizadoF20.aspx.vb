﻿Imports System.Data
Partial Class Reportes_ParametrizadoF20_Default
    Inherits PaginaComun

 

    Protected Function genFiltro() As String

        Dim obj As New Contratos()
        Dim cFiltro As String = ""

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
        If cFiltro <> String.Empty Then
            cFiltro = " Where " + cFiltro
        End If
  

        Return cFiltro
    End Function

    Protected Function SqlExcel() As String
        Dim cFiltro As String = genFiltro()
        Dim strSql As String = ""
        Select Case CboVersion.SelectedValue
            Case "1"
                'strSql = "Select Numero, pro_ctr_f20_1a MODALIDAD_DE_SELECCION,sti_ctr_f20_1a CLASE,OBJ_CON OBJETO,VAL_CON VALOR_CONTRATO,IDE_CON IDENTIFICACION_CONTRATISTA,CONTRATISTA NOMBRE_CONTRATISTA, FEC_SUS_CON FECHA_FIRMA,ID_INTERVENTOR IDENTIFICADOR_INTERVENTOR, NOM_INTERVENTOR NOMBRE_COMPLETO_INTERVENTOR,TIP_VIN_INT TIPO_VINCULACION,'DIAS' UNIDAD_DE_EJECUCIÓN, PLA_EJE_CON NUMERO_UNIDADES_EJECUCIÓN,to_char(FEC_APR_POL,'yyyy/mm/dd') FECHA_APROBACIÓN_POLIZA,NVL(to_char(FECHAINICIO,'yyyy/mm/dd'),'ND')  FECHA_INICIACION,NVL(to_char(FECHAFINAL,'yyyy/mm/dd'),'ND') FECHA_TERMINACION, NVL(to_char(FECHALIQ,'yyyy/mm/dd'),'ND') FECHA_ACTA_LIQUIDACION From ( "
                strSql += "Select Numero, pro_ctr_f20_1a MODALIDAD_DE_SELECCION,sti_ctr_f20_1a CLASE,TRIM(OBJ_CON) OBJETO,ROUND(VAL_CON) VALOR_CONTRATO,IDE_CON IDENTIFICACION_CONTRATISTA,TRIM(CONTRATISTA) NOMBRE_CONTRATISTA, FEC_SUS_CON FECHA_FIRMA,NVL(ID_INTERVENTOR,'ND') IDENTIFICADOR_INTERVENTOR,nvl( NOM_INTERVENTOR,'ND') NOMBRE_COMPLETO_INTERVENTOR,TIP_VIN_INT TIPO_VINCULACION,'DIAS' UNIDAD_DE_EJECUCIÓN, PLA_EJE_CON NUMERO_UNIDADES_EJECUCIÓN,to_char(FEC_APR_POL,'yyyy/mm/dd') FECHA_APROBACIÓN_POLIZA,NVL(to_char(FECHAINICIO,'yyyy/mm/dd'),'ND')  FECHA_INICIACION,NVL(to_char(FECHAFINAL,'yyyy/mm/dd'),'ND') FECHA_TERMINACION, NVL(to_char(FECHALIQ,'yyyy/mm/dd'),'ND') FECHA_ACTA_LIQUIDACION FROM("
                strSql += "SELECT * FROM vcontratos_Sinc_p c  " + cFiltro + " ORDER BY numero"
                strSql += ")"
            Case "2"
                'strSql = "SELECT numero, pro_ctr_f20_1a modalidad_de_seleccion, sti_ctr_f20_1a clase,sector tipo_gastos, obj_con objeto, to_char(val_con) valor_contrato,to_char(ide_con) identificacion_contratista, contratista nombre_contratista,NVL (TO_CHAR (fec_sus_con, 'yyyy/mm/dd'), 'ND') fecha_firma, id_interventor identificador_interventor,nom_interventor nombre_completo_interventor,tip_vin_int tipo_vinculacion, pla_eje_con numero_unidades_ejecuciÓn,'DIAS' unidad_de_ejecuciÓn, p_anticipo, to_char(val_adi) val_adicion,pla_adicion_dias pror_nro_unid, 'DIAS' prorr_unidad_ejec,NVL (TO_CHAR (fechainicio, 'yyyy/mm/dd'), 'ND') fecha_iniciacion,NVL (TO_CHAR (fechafinal, 'yyyy/mm/dd'), 'ND') fecha_terminacion,NVL (TO_CHAR (fechaliq, 'yyyy/mm/dd'), 'ND') fecha_acta_liquidacion FROM  ("
                strSql = "SELECT numero, pro_ctr_f20_1a modalidad_de_seleccion, sti_ctr_f20_1a clase,sector tipo_gastos, trim(obj_con) objeto, to_char(round(val_con)) valor_contrato,to_char(ide_con) identificacion_contratista, trim(contratista) nombre_contratista,NVL (TO_CHAR (fec_sus_con, 'yyyy/mm/dd'), 'ND') fecha_firma, NVL(id_interventor,'ND') identificador_interventor,NVL(trim(nom_interventor),'ND') nombre_completo_interventor,NVL(tip_vin_int,'ND') tipo_vinculacion, pla_eje_con numero_unidades_ejecuciÓn,'DIAS' unidad_de_ejecuciÓn, p_anticipo, to_char(val_adi) val_adicion,pla_adicion_dias pror_nro_unid, 'DIAS' prorr_unidad_ejec,NVL (TO_CHAR (fechainicio, 'yyyy/mm/dd'), 'ND') fecha_iniciacion,NVL (TO_CHAR (fechafinal, 'yyyy/mm/dd'), 'ND') fecha_terminacion,NVL (TO_CHAR (fechaliq, 'yyyy/mm/dd'), 'ND') fecha_acta_liquidacion FROM  ( "
                strSql += "SELECT * FROM vcontratos_Sinc_p c  " + cFiltro + " ORDER BY numero"
                strSql += ")"
        End Select
        MsgResult.Text = strSql
        Return strSql
    End Function

    Protected Function SqlExcelF20_1b() As String
        Dim cFiltro As String = genFiltro()
        Dim strSql As String
        strSql = "select c.Ide_Ter Nit_CSUT,t.nom_ter Nom_CSUT,Id_Miembros Nit_Integrante,Nom_Miembro Nom_Integrante from vconsorciosutxc c inner join vterceros t on t.IDE_TER=c.ide_ter where cod_con In ( Select Numero FROM vcontratos_Sinc_p c  " + cFiltro + " )"
        Return strSql
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

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    'Protected Sub BtnExportCSV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExportCSV.Click
    '    ExportarCSV2()
    'End Sub

   

    Sub f201b()
        'ExportarCSV_20b()
        Me.HdSql.Value = SqlExcelF20_1b()
        GridView1.DataBind()
        GridView1.Visible = True
        ExportGridView(GridView1, "Formato_20_1b")
    End Sub

    Sub f201a()
        Me.HdSql.Value = SqlExcel()
        GridView1.DataBind()
        GridView1.Visible = True
        ExportGridView(GridView1, "Formato_20_1a")

    End Sub


    'Protected Sub ExportarCSV_20b()
    '    'Response.Clear()
    '    Response.ClearContent()
    '    Response.Buffer = True
    '    Response.AddHeader("content-disposition", "attachment;filename=Formato20_1a.csv")
    '    Response.Charset = ""
    '    Response.ContentType = "text/csv"
    '    'Me.HdSql.Value = SqlExcel()

    '    Me.HdSql.Value = SqlExcelF20_1b()
    '    GridView1.DataBind()

    '    Dim obj As New Reportes
    '    Dim dt As DataTable = obj.GetSql(Me.HdSql.Value)

    '    Dim sb As New StringBuilder()
    '    Dim k As Integer = 0
    '    While k < dt.Columns.Count
    '        sb.Append(dt.Columns(k).ColumnName + ","c)
    '        System.Math.Max(System.Threading.Interlocked.Increment(k), k - 1)
    '    End While
    '    sb.Append(vbCr & vbLf)
    '    Dim i As Integer = 0
    '    While i < dt.Rows.Count
    '        Dim k2 As Integer = 0
    '        While k2 < dt.Columns.Count
    '            sb.Append(dt.Rows(i)(k2).ToString + ","c)
    '            System.Math.Max(System.Threading.Interlocked.Increment(k2), k2 - 1)
    '        End While
    '        sb.Append(vbCr & vbLf)
    '        System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
    '    End While
    '    Response.Output.Write(sb.ToString())
    '    Response.Flush()
    '    Response.End()
    'End Sub

    'Protected Sub BtnExport4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExportFUT.Click
    '    Dim strSql As String = ""
    '    If TxtVig.Text = "2012" Then
    '        strSql = " Select * From vFUT2012_01 "
    '        strSql += " WHERE numero LIKE '2012%' "
    '        If (ChkFecSus.Checked = True) Then
    '            strSql += " AND FEC_SUS_CON BETWEEN BETWEEN TO_DATE('" + CDate(TxtFecSus1.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecSus2.Text).ToShortDateString + "','dd/mm/yyyy')"
    '        End If
    '        strSql += " And substr(trim(cod_rub),-2) In (Select Recursos from rec_reg WHERE VIGENCIA=2012 AND TIP_REC='REG')"
    '        'strSql += " AND valorxrp > 0"
    '        'strSql += " AND valregalias2012 (nro_rp, cod_rub)>0   "
    '        strSql += " ORDER BY numero"
    '        Me.HdSql.Value = strSql
    '        GridView1.DataBind()
    '        GridView1.Visible = True
    '        ExportGridView(GridView1, "Formato_FUT_Regalias")
    '        'MsgResult.Text = strSql

    '    Else
    '        MsgResult.Text = "No Implementado"
    '    End If


    'End Sub

    Protected Sub BtnF201a_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnF201a.Click
        f201a()
    End Sub

    Protected Sub IBtnF201b_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnF201b.Click
        f201b()
    End Sub
End Class
