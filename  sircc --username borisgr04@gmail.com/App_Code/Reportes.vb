'MODIFICADO POR ERICK-----------PARA IMPLEMENTAR FM20
' FUNCION GenerarReportF20


Imports Microsoft.VisualBasic
Imports System.Data.Common
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Reportes
    Inherits BDDatos
    Dim _Caractar_Fecha As String = "-"
    Dim _Vacio_Contraloria As String = "ND"
    Public rptSql As String
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GenerarReportF19No(ByVal RSql As String) As DataTable
        Dim ds As New DataSet()
        Dim obj As New Contratos()
        Dim dt, dt2 As New DataTable()
        Const _SEP_ As String = ";"
        'If CBool(Request.QueryString("Rpte")) Then
        'rutaReport = "Rpt/RptConsTCtxDep.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia"
        'Else
        'rutaReport = "Rpt/RptConsTCt.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Consecutivo"
        'End If
        'ReportViewer1.LocalReport.ReportPath = rutaReport
        'Dim Parm(0) As ReportParameter
        'Parm(0) = New ReportParameter("TITULO1", Request.QueryString("tit"))
        'ReportViewer1.LocalReport.SetParameters(Parm)
        'Dim Sql As String = Request.QueryString("Sql")
        'Dim txtSql As New TextBox
        'txtSql = Me.PreviousPage.FindControl("TextBox1")
        Dim consultas As String
        'consultas = txtSql.Text
        If Not IsArray(RSql) Then
            consultas = "SELECT c.*,Cant_Adicion(c.numero) nro_adi,Plazo_Adicion(c.numero) Pla_Adi,Valor_Adicion(c.numero) Val_Adi FROM VCONTRATOS_SINC c  ORDER BY numero"
        Else
            consultas = "SELECT c.*,Cant_Adicion(c.numero) nro_adi,Plazo_Adicion(c.numero) Pla_Adi,Valor_Adicion(c.numero) Val_Adi FROM VCONTRATOS_SINC c  Where " + RSql + " ORDER BY numero"
        End If

        dt = obj.GetSql(consultas)
        dt2 = Me.CreateDSContratos()
        For Each row As DataRow In dt.Rows
            Dim dr As DataRow
            dr = dt2.NewRow()
            dr("NUMERO") = row("numero")
            'dr("des_gasto") = row("des_gasto")
            dr("CONTRATISTA") = row("contratista")
            dr("OBJ_CON") = row("obj_con")
            dr("IDE_CON") = row("ide_con")
            dr("DEPENDENCIA") = row("dependencia")
            dr("TIPO") = row("tipo")

            dr("ESTADO") = row("estado")
            dr("FEC_SUS_CON") = row("fec_sus_con").ToString
            dr("VAL_CON") = CDec(row("val_con"))
            dr("EST_CON") = row("est_con")
            dr("DEP_CON") = row("dep_con")
            dr("TIP_CON") = row("tip_con")
            dr("STIP_CON") = row("stip_con")
            dr("COD_SEC") = row("cod_sec")
            dr("REP_LEGAL") = row("rep_legal")
            dr("TIP_FOR") = row("tip_for")
            dr("OTR_CNS") = row("otr_cns")
            dr("PLA_EJE_CON") = row("pla_eje_con")
            dr("IDE_REP") = row("ide_rep")
            dr("NOM_STIP") = row("nom_stip")
            dr("NOM_EST") = row("nom_est")
            dr("PRO_CON") = row("pro_con")
            dr("NOM_TPROC") = row("nom_tproc")
            dr("NUM_PROC") = row("PRO_SEL_NRO")
            dr("PRO_SEL_NRO") = row("PRO_SEL_NRO")
            dr("NRO_ADI") = row("nro_adi")
            dr("VAL_ADI") = row("val_adi")
            dr("PLA_ADI") = row("pla_adi")

            ''---- MODIFIACO EL 22 D ABRIL DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("FEC_APR_POL") = row("FEC_APR_POL")
            dr("EXO_OBS") = row("EXO_OBS")
            dr("EXO_IMP") = row("EXO_IMP")
            dr("EST_CONV") = row("EST_CONV")
            dr("URG_MAN") = row("URG_MAN")
            dr("NRO_CON") = row("NRO_CON")
            ''---- MODIFIACO EL 2 D SEPT DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("DEPENDENCIAP") = row("DEPENDENCIAP")
            dr("DEP_PCON") = row("DEP_PCON")
            'INTERVENTOS - 6 DE OCTUBRE DE 2010
            dr("IDE_INT") = row("IDE_INT")
            dr("NOM_TER") = row("NOM_TER")
            'Valor Aportes Propios
            dr("VAL_PROP") = CDec(row("VAL_APO_GOB"))
            dr("SECTOR") = row("SECTOR")

            dr("FECHAINICIO") = (row("FechaInicio"))

            dr("FECHAFINAL") = Sumar_Plazo((row("FechaInicio")), (Plazo(row("pla_adi")) + Plazo(row("pla_eje_con"))))
            dr("FECHALIQ") = (row("FechaLiq"))
            'Beneficiados - 28 de Octubre 2010
            dr("BENEFICIADOS") = (row("Beneficiados"))
            '18 de febrero 2011
            'dr("VALOR_PAGADO") = (row("VALOR_PAGADO"))
            '07 Junio 2011
            'dr("NOMBRE_PROYECTO") = (row("NOMBRE_PROYECTO"))

            'CONSULTAR(CDP)
            Dim objcdp As New CDP_Contratos
            Dim dtCDP As New DataTable
            dtCDP = objcdp.GetRecords(row("numero"))
            Dim strCDP As String = ""
            Dim strFec_CDP As String = ""
            Dim strVal_CDP As String = ""
            For Each rowCDP As DataRow In dtCDP.Rows
                strCDP = strCDP + IIf(strCDP.Length = 0, rowCDP("nro_cdp"), _SEP_ + rowCDP("nro_cdp"))
                strFec_CDP = strFec_CDP + IIf(strFec_CDP.Length = 0, CStr(rowCDP("fec_cdp")), _SEP_ + CStr(rowCDP("fec_cdp")))
                If Not IsDBNull(rowCDP("Val_cdp")) Then
                    strVal_CDP = strVal_CDP + IIf(strVal_CDP.Length = 0, CStr(rowCDP("Val_cdp")), _SEP_ + CStr(rowCDP("Val_cdp")))
                End If

            Next
            dr("NRO_CDP") = strCDP
            dr("FEC_CDP") = strFec_CDP
            dr("VAL_CDP") = strVal_CDP
            'CONSULTAR(RP)
            Dim objrp As New RP_Contratos
            Dim dtRP As New DataTable
            dtRP = objrp.GetRecords(row("NUMERO"))
            Dim strRP As String = ""
            Dim strFec_RP As String = ""
            Dim strVal_RP As String = ""
            For Each rowRP As DataRow In dtRP.Rows
                strRP = strRP + IIf(strRP.Length = 0, rowRP("nro_rp"), _SEP_ + rowRP("nro_rp"))
                strFec_RP = strFec_RP + IIf(strFec_RP.Length = 0, CStr(rowRP("fec_rp")), _SEP_ + CStr(rowRP("fec_rp")))
                If Not IsDBNull(rowRP("Val_Rp")) Then
                    strVal_RP = strVal_RP + IIf(strVal_RP.Length = 0, CStr(rowRP("Val_Rp")), _SEP_ + CStr(rowRP("Val_Rp")))
                End If
            Next
            dr("NRO_RP") = strRP
            dr("FEC_RP") = strFec_RP
            dr("VAL_RP") = strVal_RP
            'CONSULTAR(RUBROS)
            Dim objrc As New Rubros_Contratos
            Dim dtrub As New DataTable
            dtrub = objrc.GetRecords(row("NUMERO"))
            Dim strRub As String = ""
            Dim strFec_Rub As String = ""
            For Each rowRub As DataRow In dtrub.Rows
                strRub = strRub + IIf(strRub.Length = 0, rowRub("cod_rub"), _SEP_ + rowRub("cod_rub"))
                strFec_Rub = strFec_Rub + IIf(strFec_Rub.Length = 0, CStr(rowRub("nom_rub").ToString), _SEP_ + CStr(rowRub("nom_rub").ToString))
            Next
            dr("COD_RUB") = strRub
            dr("DES_RUB") = strFec_Rub

            dt2.Rows.Add(dr)
        Next
        ds.Tables.Add(dt2)
        '--------------------
        ' Dim objE As Entidad = New Entidad()
        'Dim dsEnt As DataTable = objE.GetRecords()


        '-----------------------------
        Return dt2

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GenerarReportF20(ByVal RSql As String) As DataTable
        Dim ds As New DataSet()
        Dim obj As New Contratos()
        Dim dt, dt2 As New DataTable()
        Const _SEP_ As String = ";"
        'If CBool(Request.QueryString("Rpte")) Then
        'rutaReport = "Rpt/RptConsTCtxDep.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia"
        'Else
        'rutaReport = "Rpt/RptConsTCt.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Consecutivo"
        'End If
        'ReportViewer1.LocalReport.ReportPath = rutaReport
        'Dim Parm(0) As ReportParameter
        'Parm(0) = New ReportParameter("TITULO1", Request.QueryString("tit"))
        'ReportViewer1.LocalReport.SetParameters(Parm)
        'Dim Sql As String = Request.QueryString("Sql")
        'Dim txtSql As New TextBox
        'txtSql = Me.PreviousPage.FindControl("TextBox1")
        Dim consultas As String
        'consultas = txtSql.Text
        If RSql = "" Then
            'consultas = "Select Numero, pro_ctr_f20_1a MODALIDAD_DE_SELECCION,sti_ctr_f20_1a CLASE,OBJ_CON OBJETO,VAL_CON VALOR_CONTRATO,IDE_CON IDENTIFICACION_CONTRATISTA,CONTRATISTA NOMBRE_CONTRATISTA, FEC_SUS_CON FECHA_FIRMA,IDE_INT IDENTIFICADOR_INTERVENTOR, NOM_TER NOMBRE_COMPLETO_INTERVENTOR,'' TIPO_VINCULACION,'DIAS' UNIDAD_DE_EJECUCIÓN, PLA_EJE_CON NUMERO_UNIDADES_EJECUCIÓN,to_char(FEC_APR_POL,'yyyy/mm/dd') FECHA_APROBACIÓN_POLIZA,NVL(to_char(FECHAINICIO,'yyyy/mm/dd'),'ND')  FECHA_INICIACION,NVL(to_char(FECHAFINAL,'yyyy/mm/dd'),'ND') FECHA_TERMINACION, NVL(to_char(FECHALIQ,'yyyy/mm/dd'),'ND') FECHA_ACTA_LIQUIDACION From( "
            consultas = "SELECT c.* FROM vcontratos_sinc_p c Where 1<>0  ORDER BY numero"
            'consultas += ")"
        Else
            'consultas = "Select Numero, pro_ctr_f20_1a MODALIDAD_DE_SELECCION,sti_ctr_f20_1a CLASE,OBJ_CON OBJETO,VAL_CON VALOR_CONTRATO,IDE_CON IDENTIFICACION_CONTRATISTA,CONTRATISTA NOMBRE_CONTRATISTA, FEC_SUS_CON FECHA_FIRMA,IDE_INT IDENTIFICADOR_INTERVENTOR, NOM_TER NOMBRE_COMPLETO_INTERVENTOR,'' TIPO_VINCULACION,'DIAS' UNIDAD_DE_EJECUCIÓN, PLA_EJE_CON NUMERO_UNIDADES_EJECUCIÓN,to_char(FEC_APR_POL,'yyyy/mm/dd') FECHA_APROBACIÓN_POLIZA,NVL(to_char(FECHAINICIO,'yyyy/mm/dd'),'ND')  FECHA_INICIACION,NVL(to_char(FECHAFINAL,'yyyy/mm/dd'),'ND') FECHA_TERMINACION, NVL(to_char(FECHALIQ,'yyyy/mm/dd'),'ND') FECHA_ACTA_LIQUIDACION From( "
            consultas = "SELECT c.* FROM vcontratos_sinc_p c  Where " + RSql + " ORDER BY numero"
            'Throw New Exception(consultas)
            'consultas = "SELECT c.* FROM vcontratos_sinc c  Where Vig_Con= '2011' ORDER BY numero"

            'consultas += ")"
        End If
        'consultas = "SELECT c.* FROM vcontratos_sinc c  Where Vig_Con= '2011' ORDER BY numero"

        rptSql = consultas

        dt = obj.GetSql(consultas)

        dt2 = Me.CreateDSContratos()

        For Each row As DataRow In dt.Rows
            Dim dr As DataRow
            dr = dt2.NewRow()
            dr("numero") = row("numero")
            'dr("des_gasto") = row("des_gasto")
            dr("contratista") = row("contratista")
            dr("obj_con") = row("obj_con")
            dr("ide_con") = row("ide_con")
            dr("dependencia") = row("dependencia")
            dr("tipo") = row("tipo")
            dr("estado") = row("estado")
            dr("fec_sus_con") = Formato_Fecha(row("fec_sus_con"))
            dr("val_con") = CDec(row("val_con"))
            dr("est_con") = row("est_con")
            dr("dep_con") = row("dep_con")
            dr("tip_con") = row("tip_con")
            dr("stip_con") = row("stip_con")
            'dr("stip_con") = row("sti_ctr_f20_1a")
            dr("cod_sec") = row("cod_sec")
            dr("rep_legal") = row("rep_legal")
            dr("tip_for") = row("tip_for")
            dr("otr_cns") = row("otr_cns")
            dr("pla_eje_con") = row("pla_eje_con")
            dr("ide_rep") = row("ide_rep")
            dr("nom_stip") = row("nom_stip")
            dr("nom_est") = row("nom_est")
            dr("pro_con") = row("pro_con")
            dr("nom_tproc") = row("nom_tproc")
            'dr("nom_tproc") = row("pro_ctr_f20_1a")

            dr("NUM_PROC") = row("PRO_SEL_NRO")
            dr("NRO_ADI") = row("nro_adi")
            dr("VAL_ADI") = row("val_adi")
            dr("PLA_ADI") = row("pla_adi")

            'MODIFICADO POR ERICK-----------DEBE HABILITARSE
            dr("NOM_INT") = row("Nom_Interventor")
            dr("IDE_INT") = row("Id_Interventor")
            'dr("ID_INT") = row("Id_Interventor")
            dr("TIP_INT") = row("Tip_Vin_Int")

            ''---- MODIFIACO EL 22 D ABRIL DEL 2010
            '' BORIS ARTURO GONZALEZ


            'dr("FEC_APR_POL") = Format(CStr(IIf(row("FEC_APR_POL")  DBNull.Value, "", row("FEC_APR_POL"))), "yyyy/M/d") 'row("FEC_APR_POL")
            dr("FEC_APR_POL") = Formato_Fecha(row("FEC_APR_POL"))

            dr("EXO_OBS") = row("EXO_OBS")
            dr("EXO_IMP") = row("EXO_IMP")
            dr("EST_CONV") = row("EST_CONV")
            dr("URG_MAN") = row("URG_MAN")
            dr("NRO_CON") = row("NRO_CON")
            ''---- MODIFIACO EL 2 D SEPT DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("DEPENDENCIAP") = row("DEPENDENCIAP")
            dr("DEP_PCON") = row("DEP_PCON")
            dr("FECHAINICIO") = Formato_Fecha(row("FechaInicio"))

            dr("FECHAFINAL") = Formato_Fecha(row("FechaFinal"))
            dr("FECHALIQ") = Formato_Fecha(row("FechaLiq"))
            'dr("ValorPago") = row("ValorPago")
            dr("SECTOR") = row("Sector") ' Modificado 18 de Enero de 2011,  Boris G

            dr("PRO_CTR_F20_1A") = row("PRO_CTR_F20_1A") ' Modificado 22 de Enero de 2011,  Boris G
            dr("STI_CTR_F20_1A") = row("STI_CTR_F20_1A") ' Modificado 22 de Enero de 2011,  Boris G
            'dr("P_ANTICIPO") = row("P_ANTICIPO")

            'dt.Columns.Add("FechaAdicion", System.Type.GetType("System.String"))
            'dt.Columns.Add("ValorPago", System.Type.GetType("System.String"))

            'CONSULTAR(CDP)
            Dim objCDP As New CDP_Contratos
            Dim dtCDP As New DataTable
            dtCDP = objCDP.GetRecords(row("numero"))
            Dim strCDP As String = ""
            Dim strFec_CDP As String = ""
            Dim Val_cdp As Decimal = 0
            Dim i As Integer = 0
            For Each rowCDP As DataRow In dtCDP.Rows
                strCDP = strCDP + IIf(strCDP.Length = 0, rowCDP("nro_cdp"), _SEP_ + rowCDP("nro_cdp"))
                'strFec_CDP = strFec_CDP + IIf(strFec_CDP.Length = 0, Formato_Fecha(rowCDP("fec_cdp")), _SEP_ + Formato_Fecha(rowCDP("fec_cdp")))
                Val_cdp = Val_cdp + IIf(rowCDP("val_cdp") Is DBNull.Value, 0, rowCDP("val_cdp"))
                i = i + 1
                If i = 1 Then
                    strFec_CDP = Formato_Fecha(rowCDP("fec_cdp"))
                End If
            Next

            dr("nro_cdp") = IIf(i > 1, "(" + strCDP + ")", strCDP)
            dr("fec_cdp") = strFec_CDP
            'Modificado Para La Contraloria
            dr("val_cdp") = Val_cdp

            'CONSULTAR(RP)
            Dim objrp As New RP_Contratos
            Dim dtRP As New DataTable
            dtRP = objrp.GetRecords(row("numero"))
            Dim strRP As String = ""
            Dim strFec_RP As String = ""
            Dim Val_rp As Decimal = 0
            i = 0
            For Each rowRP As DataRow In dtRP.Rows
                strRP = strRP + IIf(strRP.Length = 0, rowRP("nro_rp"), _SEP_ + rowRP("nro_rp"))
                'strFec_RP = strFec_RP + IIf(strFec_RP.Length = 0, Formato_Fecha(rowRP("fec_rp")), _SEP_ + Formato_Fecha(rowRP("fec_rp")))
                Val_rp = Val_rp + IIf(rowRP("val_rp") Is DBNull.Value, 0, rowRP("val_rp"))
                i = i + 1
                If i = 1 Then
                    strFec_RP = Formato_Fecha(rowRP("fec_rp"))
                End If
            Next
            dr("nro_Rp") = IIf(i > 1, "(" + strRP + ")", strRP)
            dr("fec_Rp") = strFec_RP
            'Modificado Para La Contraloria
            dr("val_Rp") = Val_rp

            'CONSULTAR(RUBROS)
            Dim objrub As New Rubros_Contratos
            Dim dtRub As New DataTable
            dtRub = objrub.GetRecords(row("numero"))
            Dim strRub As String = ""
            Dim strFec_Rub As String = ""
            i = 0
            For Each rowRub As DataRow In dtRub.Rows
                strRub = strRub + IIf(strRub.Length = 0, rowRub("cod_rub"), _SEP_ + rowRub("cod_rub"))
                'strFec_Rub = strFec_Rub + IIf(strFec_Rub.Length = 0, CStr(rowRub("des_rub")), _SEP_ + CStr(rowRub("des_rub")))
                i = 1 + 1
                If i = 1 Then
                    'Exit For
                    strFec_CDP = Formato_Fecha(rowRub("fec_rp"))
                End If
            Next
            dr("cod_rub") = IIf(i > 1, "(" + strRub + ")", strRub)
            dr("des_rub") = strFec_Rub

            'CONSULTAR(RUBROS)
            Dim objAdi As New Adiciones
            Dim dtAdi As New DataTable
            dtAdi = objAdi.GetRecords(row("numero"))
            Dim FAdi As String = "ND"
            Dim val_adi As Decimal = 0
            Dim pla_adi As Decimal = 0

            For Each rowAdi As DataRow In dtAdi.Rows
                'dt.Columns.Add("FechaAdicion", System.Type.GetType("System.String"))

                val_adi = val_adi + rowAdi("val_adi")
                pla_adi = pla_adi + rowAdi("pla_EJE_adi")
                'strRub = strRub + IIf(strRub.Length = 0, rowRub("cod_rub"), _SEP_ + rowRub("cod_rub"))
                'strFec_Rub = strFec_Rub + IIf(strFec_Rub.Length = 0, CStr(rowRub("des_rub")), _SEP_ + CStr(rowRub("des_rub")))
                i = i + 1
                If i = 1 Then
                    'Exit For
                    FAdi = Formato_Fecha(rowAdi("fec_sus_adi"))
                End If
            Next
            dr("val_adi") = val_adi
            dr("pla_adi") = IIf(pla_adi = 0, "ND", pla_adi.ToString)
            dr("FECHAADICION") = FAdi


            dt2.Rows.Add(dr)
        Next

        'Throw New Exception("Ejecuto Consulta")

        ds.Tables.Add(dt2)
        Return dt2
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GenerarReportF19(ByVal RSql As String) As DataTable
        Dim ds As New DataSet()
        Dim obj As New Contratos()
        Dim dt, dt2 As New DataTable()
        Const _SEP_ As String = ";"
        'If CBool(Request.QueryString("Rpte")) Then
        'rutaReport = "Rpt/RptConsTCtxDep.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia"
        'Else
        'rutaReport = "Rpt/RptConsTCt.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Consecutivo"
        'End If
        'ReportViewer1.LocalReport.ReportPath = rutaReport
        'Dim Parm(0) As ReportParameter
        'Parm(0) = New ReportParameter("TITULO1", Request.QueryString("tit"))
        'ReportViewer1.LocalReport.SetParameters(Parm)
        'Dim Sql As String = Request.QueryString("Sql")
        'Dim txtSql As New TextBox
        'txtSql = Me.PreviousPage.FindControl("TextBox1")
        Dim consultas As String
        'consultas = txtSql.Text
        If RSql = "" Then
            'consultas = "Select Numero, pro_ctr_f20_1a MODALIDAD_DE_SELECCION,sti_ctr_f20_1a CLASE,OBJ_CON OBJETO,VAL_CON VALOR_CONTRATO,IDE_CON IDENTIFICACION_CONTRATISTA,CONTRATISTA NOMBRE_CONTRATISTA, FEC_SUS_CON FECHA_FIRMA,IDE_INT IDENTIFICADOR_INTERVENTOR, NOM_TER NOMBRE_COMPLETO_INTERVENTOR,'' TIPO_VINCULACION,'DIAS' UNIDAD_DE_EJECUCIÓN, PLA_EJE_CON NUMERO_UNIDADES_EJECUCIÓN,to_char(FEC_APR_POL,'yyyy/mm/dd') FECHA_APROBACIÓN_POLIZA,NVL(to_char(FECHAINICIO,'yyyy/mm/dd'),'ND')  FECHA_INICIACION,NVL(to_char(FECHAFINAL,'yyyy/mm/dd'),'ND') FECHA_TERMINACION, NVL(to_char(FECHALIQ,'yyyy/mm/dd'),'ND') FECHA_ACTA_LIQUIDACION From( "
            consultas = "SELECT c.* FROM vcontratos_sinc c Where 1<>0  ORDER BY numero"
            'consultas += ")"
        Else
            'consultas = "Select Numero, pro_ctr_f20_1a MODALIDAD_DE_SELECCION,sti_ctr_f20_1a CLASE,OBJ_CON OBJETO,VAL_CON VALOR_CONTRATO,IDE_CON IDENTIFICACION_CONTRATISTA,CONTRATISTA NOMBRE_CONTRATISTA, FEC_SUS_CON FECHA_FIRMA,IDE_INT IDENTIFICADOR_INTERVENTOR, NOM_TER NOMBRE_COMPLETO_INTERVENTOR,'' TIPO_VINCULACION,'DIAS' UNIDAD_DE_EJECUCIÓN, PLA_EJE_CON NUMERO_UNIDADES_EJECUCIÓN,to_char(FEC_APR_POL,'yyyy/mm/dd') FECHA_APROBACIÓN_POLIZA,NVL(to_char(FECHAINICIO,'yyyy/mm/dd'),'ND')  FECHA_INICIACION,NVL(to_char(FECHAFINAL,'yyyy/mm/dd'),'ND') FECHA_TERMINACION, NVL(to_char(FECHALIQ,'yyyy/mm/dd'),'ND') FECHA_ACTA_LIQUIDACION From( "
            consultas = "SELECT c.* FROM vcontratos_sinc c  Where " + RSql + " ORDER BY numero"
            'consultas = "SELECT c.* FROM vcontratos_sinc c  Where Vig_Con= '2011' ORDER BY numero"

            'consultas += ")"
        End If
        'consultas = "SELECT c.* FROM vcontratos_sinc c  Where Vig_Con= '2011' ORDER BY numero"

        rptSql = consultas

        dt = obj.GetSql(consultas)

        dt2 = Me.CreateDSContratos()

        For Each row As DataRow In dt.Rows
            Dim dr As DataRow
            dr = dt2.NewRow()
            dr("numero") = row("numero")
            'dr("des_gasto") = row("des_gasto")
            dr("contratista") = row("contratista")
            dr("obj_con") = row("obj_con")
            dr("ide_con") = row("ide_con")
            dr("dependencia") = row("dependencia")
            dr("tipo") = row("tipo")
            dr("estado") = row("estado")
            dr("fec_sus_con") = Formato_Fecha(row("fec_sus_con"))
            dr("val_con") = CDec(row("val_con"))
            dr("est_con") = row("est_con")
            dr("dep_con") = row("dep_con")
            dr("tip_con") = row("tip_con")
            dr("stip_con") = row("stip_con")
            'dr("stip_con") = row("sti_ctr_f20_1a")
            dr("cod_sec") = row("cod_sec")
            dr("rep_legal") = row("rep_legal")
            dr("tip_for") = row("tip_for")
            dr("otr_cns") = row("otr_cns")
            dr("pla_eje_con") = row("pla_eje_con")
            dr("ide_rep") = row("ide_rep")
            dr("nom_stip") = row("nom_stip")
            dr("nom_est") = row("nom_est")
            dr("pro_con") = row("pro_con")
            dr("nom_tproc") = row("nom_tproc")
            'dr("nom_tproc") = row("pro_ctr_f20_1a")

            dr("NUM_PROC") = row("PRO_SEL_NRO")
            dr("NRO_ADI") = row("nro_adi")
            dr("VAL_ADI") = row("val_adi")
            dr("PLA_ADI") = row("pla_adi")

            'MODIFICADO POR ERICK-----------DEBE HABILITARSE
            dr("NOM_INT") = row("Nom_Interventor")
            'dr("ID_INT") = row("Id_Interventor")
            dr("IDE_INT") = row("Id_Interventor")
            dr("TIP_INT") = row("Tip_Vin_Int")

            ''---- MODIFIACO EL 22 D ABRIL DEL 2010
            '' BORIS ARTURO GONZALEZ


            'dr("FEC_APR_POL") = Format(CStr(IIf(row("FEC_APR_POL")  DBNull.Value, "", row("FEC_APR_POL"))), "yyyy/M/d") 'row("FEC_APR_POL")
            dr("FEC_APR_POL") = Formato_Fecha(row("FEC_APR_POL"))

            dr("EXO_OBS") = row("EXO_OBS")
            dr("EXO_IMP") = row("EXO_IMP")
            dr("EST_CONV") = row("EST_CONV")
            dr("URG_MAN") = row("URG_MAN")
            dr("NRO_CON") = row("NRO_CON")
            ''---- MODIFIACO EL 2 D SEPT DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("DEPENDENCIAP") = row("DEPENDENCIAP")
            dr("DEP_PCON") = row("DEP_PCON")
            dr("LUG_EJE") = row("LUG_EJE")
            dr("fechaInicio") = Formato_Fecha(row("FechaInicio"))

            dr("FechaFinal") = Formato_Fecha(row("FechaFinal"))
            dr("FechaLiq") = Formato_Fecha(row("FechaLiq"))
            'dr("ValorPago") = row("ValorPago")
            dr("Sector") = row("Sector") ' Modificado 18 de Enero de 2011,  Boris G

            dr("PRO_CTR_F20_1A") = row("PRO_CTR_F20_1A") ' Modificado 22 de Enero de 2011,  Boris G
            dr("STI_CTR_F20_1A") = row("STI_CTR_F20_1A") ' Modificado 22 de Enero de 2011,  Boris G
            dr("P_ANTICIPO") = row("P_ANTICIPO")
            dr("PORCEJECUCION") = row("PORCEJECUCION")

            'dt.Columns.Add("FechaAdicion", System.Type.GetType("System.String"))
            'dt.Columns.Add("ValorPago", System.Type.GetType("System.String"))

            'CONSULTAR(CDP)
            Dim objCDP As New CDP_Contratos
            Dim dtCDP As New DataTable
            dtCDP = objCDP.GetRecords(row("numero"))
            Dim strCDP As String = ""
            Dim strFec_CDP As String = ""
            Dim Val_cdp As Decimal = 0
            Dim i As Integer = 0
            For Each rowCDP As DataRow In dtCDP.Rows
                strCDP = strCDP + IIf(strCDP.Length = 0, rowCDP("nro_cdp"), _SEP_ + rowCDP("nro_cdp"))
                'strFec_CDP = strFec_CDP + IIf(strFec_CDP.Length = 0, Formato_Fecha(rowCDP("fec_cdp")), _SEP_ + Formato_Fecha(rowCDP("fec_cdp")))
                Val_cdp = Val_cdp + IIf(rowCDP("val_cdp") Is DBNull.Value, 0, rowCDP("val_cdp"))
                i = i + 1
                If i = 1 Then
                    strFec_CDP = Formato_Fecha(rowCDP("fec_cdp"))
                End If
            Next

            dr("nro_cdp") = IIf(i > 1, "(" + strCDP + ")", strCDP)
            dr("fec_cdp") = strFec_CDP
            'Modificado Para La Contraloria
            dr("val_cdp") = Val_cdp

            'CONSULTAR(RP)
            Dim objrp As New RP_Contratos
            Dim dtRP As New DataTable
            dtRP = objrp.GetRecords(row("numero"))
            Dim strRP As String = ""
            Dim strFec_RP As String = ""
            Dim Val_rp As Decimal = 0
            i = 0
            For Each rowRP As DataRow In dtRP.Rows
                strRP = strRP + IIf(strRP.Length = 0, rowRP("nro_rp"), _SEP_ + rowRP("nro_rp"))
                'strFec_RP = strFec_RP + IIf(strFec_RP.Length = 0, Formato_Fecha(rowRP("fec_rp")), _SEP_ + Formato_Fecha(rowRP("fec_rp")))
                Val_rp = Val_rp + IIf(rowRP("val_rp") Is DBNull.Value, 0, rowRP("val_rp"))
                i = i + 1
                If i = 1 Then
                    strFec_RP = Formato_Fecha(rowRP("fec_rp"))
                End If
            Next
            dr("nro_Rp") = IIf(i > 1, "(" + strRP + ")", strRP)
            dr("fec_Rp") = strFec_RP
            'Modificado Para La Contraloria
            dr("val_Rp") = Val_rp

            'CONSULTAR(RUBROS)
            Dim objrub As New Rubros_Contratos
            Dim dtRub As New DataTable
            dtRub = objrub.GetRecords(row("numero"))
            Dim strRub As String = ""
            Dim strFec_Rub As String = ""
            i = 0
            For Each rowRub As DataRow In dtRub.Rows
                strRub = strRub + IIf(strRub.Length = 0, rowRub("cod_rub"), _SEP_ + rowRub("cod_rub"))
                'strFec_Rub = strFec_Rub + IIf(strFec_Rub.Length = 0, CStr(rowRub("des_rub")), _SEP_ + CStr(rowRub("des_rub")))
                i = 1 + 1
                If i = 1 Then
                    'Exit For
                    strFec_CDP = Formato_Fecha(rowRub("fec_rp"))
                End If
            Next
            dr("cod_rub") = IIf(i > 1, "(" + strRub + ")", strRub)
            dr("des_rub") = strFec_Rub

            'CONSULTAR(RUBROS)
            Dim objAdi As New Adiciones
            Dim dtAdi As New DataTable
            dtAdi = objAdi.GetRecords(row("numero"))
            Dim FAdi As String = "ND"
            Dim val_adi As Decimal = 0
            Dim pla_adi As Decimal = 0

            For Each rowAdi As DataRow In dtAdi.Rows
                'dt.Columns.Add("FechaAdicion", System.Type.GetType("System.String"))

                val_adi = val_adi + rowAdi("val_adi")
                pla_adi = pla_adi + rowAdi("pla_EJE_adi")
                'strRub = strRub + IIf(strRub.Length = 0, rowRub("cod_rub"), _SEP_ + rowRub("cod_rub"))
                'strFec_Rub = strFec_Rub + IIf(strFec_Rub.Length = 0, CStr(rowRub("des_rub")), _SEP_ + CStr(rowRub("des_rub")))
                i = i + 1
                If i = 1 Then
                    'Exit For
                    FAdi = Formato_Fecha(rowAdi("fec_sus_adi"))
                End If
            Next
            dr("val_adi") = val_adi
            dr("pla_adi") = IIf(pla_adi = 0, "ND", pla_adi.ToString)
            dr("FECHAADICION") = FAdi


            dt2.Rows.Add(dr)
        Next

        'Throw New Exception("Ejecuto Consulta")

        ds.Tables.Add(dt2)
        Return dt2
    End Function
    Protected Function Formato_Fecha(ByVal fecha As Object) As String
        'Format(f, "yyyy/M/d")
        Dim f As Date
        If Not (fecha Is DBNull.Value) Then
            f = CDate(fecha)
            Return f.Year.ToString + _Caractar_Fecha + f.Month.ToString.PadLeft(2, "0") + _Caractar_Fecha + f.Day.ToString.PadLeft(2, "0")
        Else
            Return _Vacio_Contraloria
        End If
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GenerarReport() As DataTable
        Dim cfiltro As String = "Where Vig_Con=2011"
        Return GenerarReport("SELECT c.*,Cant_Adicion(c.numero) nro_adi,Plazo_Adicion(c.numero) Pla_Adi,Valor_Adicion(c.numero) Val_Adi FROM vcontratos_Sinc c  " + cfiltro + " ORDER BY numero")
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GenerarReport(ByVal Sql As String) As DataTable
        Dim ds As New DataSet()
        Dim obj As New Contratos()
        Dim dt, dt2 As New DataTable()
        Const _SEP_ As String = ";"
        'If CBool(Request.QueryString("Rpte")) Then
        'rutaReport = "Rpt/RptConsTCtxDep.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia"
        'Else
        'rutaReport = "Rpt/RptConsTCt.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Consecutivo"
        'End If
        'ReportViewer1.LocalReport.ReportPath = rutaReport
        'Dim Parm(0) As ReportParameter
        'Parm(0) = New ReportParameter("TITULO1", Request.QueryString("tit"))
        'ReportViewer1.LocalReport.SetParameters(Parm)
        'Dim Sql As String = Request.QueryString("Sql")
        'Dim txtSql As New TextBox
        'txtSql = Me.PreviousPage.FindControl("TextBox1")
        Dim consultas As String
        'consultas = txtSql.Text
        consultas = Sql
        dt = obj.GetSql(consultas)
        dt2 = Me.CreateDSContratos()
        For Each row As DataRow In dt.Rows
            Dim dr As DataRow
            dr = dt2.NewRow()
            dr("NUMERO") = row("numero")
            'dr("des_gasto") = row("des_gasto")
            dr("CONTRATISTA") = row("contratista")
            dr("OBJ_CON") = row("obj_con")
            dr("IDE_CON") = row("ide_con")
            dr("DEPENDENCIA") = row("dependencia")
            dr("TIPO") = row("tipo")

            dr("ESTADO") = row("estado")
            dr("FEC_SUS_CON") = row("fec_sus_con").ToString
            dr("VAL_CON") = CDec(row("val_con"))
            dr("EST_CON") = row("est_con")
            dr("DEP_CON") = row("dep_con")
            dr("TIP_CON") = row("tip_con")
            dr("STIP_CON") = row("stip_con")
            dr("COD_SEC") = row("cod_sec")
            dr("REP_LEGAL") = row("rep_legal")
            dr("TIP_FOR") = row("tip_for")
            dr("OTR_CNS") = row("otr_cns")
            dr("PLA_EJE_CON") = row("pla_eje_con")
            dr("IDE_REP") = row("ide_rep")
            dr("NOM_STIP") = row("nom_stip")
            dr("NOM_EST") = row("nom_est")
            dr("PRO_CON") = row("pro_con")
            dr("NOM_TPROC") = row("nom_tproc")
            dr("NUM_PROC") = row("PRO_SEL_NRO")
            dr("PRO_SEL_NRO") = row("PRO_SEL_NRO")
            dr("NRO_ADI") = row("nro_adi")
            dr("VAL_ADI") = row("val_adi")
            dr("PLA_ADI") = row("pla_adi")

            ''---- MODIFIACO EL 22 D ABRIL DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("FEC_APR_POL") = row("FEC_APR_POL")
            dr("EXO_OBS") = row("EXO_OBS")
            dr("EXO_IMP") = row("EXO_IMP")
            dr("EST_CONV") = row("EST_CONV")
            dr("URG_MAN") = row("URG_MAN")
            dr("NRO_CON") = row("NRO_CON")
            ''---- MODIFIACO EL 2 D SEPT DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("DEPENDENCIAP") = row("DEPENDENCIAP")
            dr("DEP_PCON") = row("DEP_PCON")
            'INTERVENTOS - 6 DE OCTUBRE DE 2010
            'dr("IDE_INT") = row("ID_INTERVENTOR")
            'dr("NOM_TER") = row("NOM_TER")
            'dr("NOM_INT") = row("NOM_INTERVENTOR")
            ''modificado x
            dr("NOM_INT") = row("Nom_Interventor")
            dr("IDE_INT") = row("Id_Interventor")
            'dr("ID_INT") = row("Id_Interventor")
            dr("TIP_INT") = row("Tip_Vin_Int")
            'Valor Aportes Propios
            dr("VAL_PROP") = CDec(row("VAL_APO_GOB"))


            dr("FECHAINICIO") = (row("FechaInicio"))

            dr("FECHAFINAL") = Sumar_Plazo((row("FechaInicio")), (Plazo(row("pla_adi")) + Plazo(row("pla_eje_con"))))
            dr("FECHALIQ") = (row("FechaLiq"))
            'Beneficiados - 28 de Octubre 2010
            dr("BENEFICIADOS") = (row("Beneficiados"))
            '18 de febrero 2011 - solo para el dia x analizar para implementarlo para el 2011
            'dr("VALOR_PAGADO") = (row("VALOR_PAGADO"))

            '07 de junio de 2011
            dr("NOMBRE_PROYECTO") = row("NOMBRE_PROYECTO")

            'CONSULTAR(CDP)
            Dim objcdp As New CDP_Contratos
            Dim dtCDP As New DataTable
            dtCDP = objcdp.GetRecords(row("numero"))
            Dim strCDP As String = ""
            Dim strFec_CDP As String = ""
            For Each rowCDP As DataRow In dtCDP.Rows
                strCDP = strCDP + IIf(strCDP.Length = 0, rowCDP("nro_cdp"), _SEP_ + rowCDP("nro_cdp"))
                strFec_CDP = strFec_CDP + IIf(strFec_CDP.Length = 0, CStr(rowCDP("fec_cdp")), _SEP_ + CStr(rowCDP("fec_cdp")))
            Next
            dr("NRO_CDP") = strCDP
            dr("FEC_CDP") = strFec_CDP

            'CONSULTAR(RP)
            Dim objrp As New RP_Contratos
            Dim dtRP As New DataTable
            dtRP = objrp.GetRecords(row("NUMERO"))
            Dim strRP As String = ""
            Dim strFec_RP As String = ""
            For Each rowRP As DataRow In dtRP.Rows
                strRP = strRP + IIf(strRP.Length = 0, rowRP("nro_rp"), _SEP_ + rowRP("nro_rp"))
                strFec_RP = strFec_RP + IIf(strFec_RP.Length = 0, CStr(rowRP("fec_rp")), _SEP_ + CStr(rowRP("fec_rp")))
            Next
            dr("NRO_RP") = strRP
            dr("FEC_RP") = strFec_RP

            'CONSULTAR(RUBROS)
            Dim objrc As New Rubros_Contratos
            Dim dtrub As New DataTable
            dtrub = objrc.GetRecords(row("NUMERO"))
            Dim strRub As String = ""
            Dim strFec_Rub As String = ""
            For Each rowRub As DataRow In dtrub.Rows
                strRub = strRub + IIf(strRub.Length = 0, rowRub("cod_rub"), _SEP_ + rowRub("cod_rub"))
                strFec_Rub = strFec_Rub + IIf(strFec_Rub.Length = 0, CStr(rowRub("nom_rub").ToString), _SEP_ + CStr(rowRub("nom_rub").ToString))
            Next
            dr("COD_RUB") = strRub
            dr("DES_RUB") = strFec_Rub

            dt2.Rows.Add(dr)
        Next
        ds.Tables.Add(dt2)
        '--------------------
        ' Dim objE As Entidad = New Entidad()
        'Dim dsEnt As DataTable = objE.GetRecords()


        '-----------------------------
        Return dt2

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GenerarReportPol(ByVal Sql As String) As DataTable
        Dim ds As New DataSet()
        Dim obj As New Contratos()
        Dim dt, dt2 As New DataTable()
        Const _SEP_ As String = ";"
        'If CBool(Request.QueryString("Rpte")) Then
        'rutaReport = "Rpt/RptConsTCtxDep.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia"
        'Else
        'rutaReport = "Rpt/RptConsTCt.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Consecutivo"
        'End If
        'ReportViewer1.LocalReport.ReportPath = rutaReport
        'Dim Parm(0) As ReportParameter
        'Parm(0) = New ReportParameter("TITULO1", Request.QueryString("tit"))
        'ReportViewer1.LocalReport.SetParameters(Parm)
        'Dim Sql As String = Request.QueryString("Sql")
        'Dim txtSql As New TextBox
        'txtSql = Me.PreviousPage.FindControl("TextBox1")
        Dim consultas As String
        'consultas = txtSql.Text
        consultas = Sql
        'Throw New Exception(consultas)
        dt = obj.GetSql(consultas)
        dt2 = Me.CreateDSContratos()
        For Each row As DataRow In dt.Rows
            Dim dr As DataRow
            dr = dt2.NewRow()
            dr("NUMERO") = row("numero")
            'dr("des_gasto") = row("des_gasto")
            dr("CONTRATISTA") = row("contratista")
            dr("OBJ_CON") = row("obj_con")
            dr("IDE_CON") = row("ide_con")
            dr("DEPENDENCIA") = row("dependencia")
            dr("TIPO") = row("tipo")

            dr("ESTADO") = row("estado")
            dr("FEC_SUS_CON") = row("fec_sus_con").ToString
            dr("VAL_CON") = CDec(row("val_con"))
            dr("EST_CON") = row("est_con")
            dr("DEP_CON") = row("dep_con")
            dr("TIP_CON") = row("tip_con")
            dr("STIP_CON") = row("stip_con")
            dr("COD_SEC") = row("cod_sec")
            dr("REP_LEGAL") = row("rep_legal")
            dr("TIP_FOR") = row("tip_for")
            dr("OTR_CNS") = row("otr_cns")
            dr("PLA_EJE_CON") = row("pla_eje_con")
            dr("IDE_REP") = row("ide_rep")
            dr("NOM_STIP") = row("nom_stip")
            dr("NOM_EST") = row("nom_est")
            dr("PRO_CON") = row("pro_con")
            dr("NOM_TPROC") = row("nom_tproc")
            dr("NUM_PROC") = row("PRO_SEL_NRO")
            dr("PRO_SEL_NRO") = row("PRO_SEL_NRO")
            dr("NRO_ADI") = row("nro_adi")
            dr("VAL_ADI") = row("val_adi")
            dr("PLA_ADI") = row("pla_adi")

            ''---- MODIFIACO EL 22 D ABRIL DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("FEC_APR_POL") = row("FEC_APR_POL")
            dr("EXO_OBS") = row("EXO_OBS")
            dr("EXO_IMP") = row("EXO_IMP")
            dr("EST_CONV") = row("EST_CONV")
            dr("URG_MAN") = row("URG_MAN")
            dr("NRO_CON") = row("NRO_CON")
            ''---- MODIFIACO EL 2 D SEPT DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("DEPENDENCIAP") = row("DEPENDENCIAP")
            dr("DEP_PCON") = row("DEP_PCON")
            'INTERVENTOS - 6 DE OCTUBRE DE 2010
            'dr("IDE_INT") = row("ID_INTERVENTOR")
            'dr("NOM_TER") = row("NOM_INTERVENTOR")
            'MODIFICADO ERIC
            dr("NOM_INT") = row("Nom_Interventor")
            dr("IDE_INT") = row("Id_Interventor")
            'dr("ID_INT") = row("Id_Interventor")
            dr("TIP_INT") = row("Tip_Vin_Int")
            'Valor Aportes Propios

            dr("VAL_PROP") = CDec(row("VAL_APO_GOB"))


            dr("FECHAINICIO") = (row("FechaInicio"))

            dr("FECHAFINAL") = Sumar_Plazo((row("FechaInicio")), (Plazo(row("pla_adi")) + Plazo(row("pla_eje_con"))))
            dr("FECHALIQ") = (row("FechaLiq"))
            'Beneficiados - 28 de Octubre 2010
            dr("BENEFICIADOS") = (row("Beneficiados"))
            '18 de febrero 2011 - solo para el dia x analizar para implementarlo para el 2011
            'dr("VALOR_PAGADO") = (row("VALOR_PAGADO"))

            '07 de junio de 2011
            dr("NOMBRE_PROYECTO") = row("NOMBRE_PROYECTO")
            'Informacion de Polizas
            dr("COD_POL") = row("COD_POL")
            dr("NOM_POL") = row("NOM_POL")
            dr("NOM_ASE") = row("NOM_ASE")
            dr("FEC_POL") = row("FEC_POL")
            dr("NRO_POL") = row("NRO_POL")
            dr("VAL_POL") = row("VAL_POL")
            dr("TIP_POL") = row("TIP_POL")
            'CONSULTAR(CDP)
            Dim objcdp As New CDP_Contratos
            Dim dtCDP As New DataTable
            dtCDP = objcdp.GetRecords(row("numero"))
            Dim strCDP As String = ""
            Dim strFec_CDP As String = ""
            For Each rowCDP As DataRow In dtCDP.Rows
                strCDP = strCDP + IIf(strCDP.Length = 0, rowCDP("nro_cdp"), _SEP_ + rowCDP("nro_cdp"))
                strFec_CDP = strFec_CDP + IIf(strFec_CDP.Length = 0, CStr(rowCDP("fec_cdp")), _SEP_ + CStr(rowCDP("fec_cdp")))
            Next
            dr("NRO_CDP") = strCDP
            dr("FEC_CDP") = strFec_CDP

            'CONSULTAR(RP)
            Dim objrp As New RP_Contratos
            Dim dtRP As New DataTable
            dtRP = objrp.GetRecords(row("NUMERO"))
            Dim strRP As String = ""
            Dim strFec_RP As String = ""
            For Each rowRP As DataRow In dtRP.Rows
                strRP = strRP + IIf(strRP.Length = 0, rowRP("nro_rp"), _SEP_ + rowRP("nro_rp"))
                strFec_RP = strFec_RP + IIf(strFec_RP.Length = 0, CStr(rowRP("fec_rp")), _SEP_ + CStr(rowRP("fec_rp")))
            Next
            dr("NRO_RP") = strRP
            dr("FEC_RP") = strFec_RP

            'CONSULTAR(RUBROS)
            Dim objrc As New Rubros_Contratos
            Dim dtrub As New DataTable
            dtrub = objrc.GetRecords(row("NUMERO"))
            Dim strRub As String = ""
            Dim strFec_Rub As String = ""
            For Each rowRub As DataRow In dtrub.Rows
                strRub = strRub + IIf(strRub.Length = 0, rowRub("cod_rub"), _SEP_ + rowRub("cod_rub"))
                strFec_Rub = strFec_Rub + IIf(strFec_Rub.Length = 0, CStr(rowRub("nom_rub").ToString), _SEP_ + CStr(rowRub("nom_rub").ToString))
            Next
            dr("COD_RUB") = strRub
            dr("DES_RUB") = strFec_Rub

            dt2.Rows.Add(dr)
        Next
        ds.Tables.Add(dt2)
        '--------------------
        ' Dim objE As Entidad = New Entidad()
        'Dim dsEnt As DataTable = objE.GetRecords()


        '-----------------------------
        Return dt2

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GenerarReportRub(ByVal Sql As String) As DataTable
        Dim ds As New DataSet()
        Dim obj As New Contratos()
        Dim dt, dt2 As New DataTable()
        Const _SEP_ As String = ";"
        'If CBool(Request.QueryString("Rpte")) Then
        'rutaReport = "Rpt/RptConsTCtxDep.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia"
        'Else
        'rutaReport = "Rpt/RptConsTCt.rdlc"
        'ReportViewer1.LocalReport.DisplayName = "Reporte x Consecutivo"
        'End If
        'ReportViewer1.LocalReport.ReportPath = rutaReport
        'Dim Parm(0) As ReportParameter
        'Parm(0) = New ReportParameter("TITULO1", Request.QueryString("tit"))
        'ReportViewer1.LocalReport.SetParameters(Parm)
        'Dim Sql As String = Request.QueryString("Sql")
        'Dim txtSql As New TextBox
        'txtSql = Me.PreviousPage.FindControl("TextBox1")
        Dim consultas As String
        'consultas = txtSql.Text
        consultas = Sql
        dt = obj.GetSql(consultas)
        dt2 = Me.CreateDSContratos()
        For Each row As DataRow In dt.Rows
            Dim dr As DataRow
            dr = dt2.NewRow()
            dr("NUMERO") = row("numero")
            'dr("des_gasto") = row("des_gasto")
            dr("CONTRATISTA") = row("contratista")
            dr("OBJ_CON") = row("obj_con")
            dr("IDE_CON") = row("ide_con")
            dr("DEPENDENCIA") = row("dependencia")
            dr("TIPO") = row("tipo")

            dr("ESTADO") = row("estado")
            dr("FEC_SUS_CON") = row("fec_sus_con").ToString
            dr("VAL_CON") = CDec(row("val_con"))
            dr("EST_CON") = row("est_con")
            dr("DEP_CON") = row("dep_con")
            dr("TIP_CON") = row("tip_con")
            dr("STIP_CON") = row("stip_con")
            dr("COD_SEC") = row("cod_sec")
            dr("REP_LEGAL") = row("rep_legal")
            dr("TIP_FOR") = row("tip_for")
            dr("OTR_CNS") = row("otr_cns")
            dr("PLA_EJE_CON") = row("pla_eje_con")
            dr("IDE_REP") = row("ide_rep")
            dr("NOM_STIP") = row("nom_stip")
            dr("NOM_EST") = row("nom_est")
            dr("PRO_CON") = row("pro_con")
            dr("NOM_TPROC") = row("nom_tproc")
            dr("NUM_PROC") = row("PRO_SEL_NRO")
            dr("PRO_SEL_NRO") = row("PRO_SEL_NRO")
            dr("NRO_ADI") = row("nro_adi")
            dr("VAL_ADI") = row("val_adi")
            dr("PLA_ADI") = row("pla_adi")

            ''---- MODIFIACO EL 22 D ABRIL DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("FEC_APR_POL") = row("FEC_APR_POL")
            dr("EXO_OBS") = row("EXO_OBS")
            dr("EXO_IMP") = row("EXO_IMP")
            dr("EST_CONV") = row("EST_CONV")
            dr("URG_MAN") = row("URG_MAN")
            dr("NRO_CON") = row("NRO_CON")
            ''---- MODIFIACO EL 2 D SEPT DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("DEPENDENCIAP") = row("DEPENDENCIAP")
            dr("DEP_PCON") = row("DEP_PCON")
            'INTERVENTOS - 6 DE OCTUBRE DE 2010
            dr("IDE_INT") = row("IDE_INT")
            dr("NOM_TER") = row("NOM_TER")
            'MODIFICADO ERIC/ODIFIACO BORIS
            dr("NOM_INT") = row("Nom_Interventor")
            dr("IDE_INT") = row("Id_Interventor")
            'dr("ID_INT") = row("Id_Interventor")
            dr("TIP_INT") = row("Tip_Vin_Int")
            'Valor Aportes Propios
            dr("VAL_PROP") = CDec(row("VAL_APO_GOB"))


            dr("FECHAINICIO") = (row("FechaInicio"))

            dr("FECHAFINAL") = Sumar_Plazo((row("FechaInicio")), (Plazo(row("pla_adi")) + Plazo(row("pla_eje_con"))))
            dr("FECHALIQ") = (row("FechaLiq"))
            'Beneficiados - 28 de Octubre 2010
            dr("BENEFICIADOS") = (row("Beneficiados"))
            '18 de febrero 2011 - solo para el dia x analizar para implementarlo para el 2011
            'dr("VALOR_PAGADO") = (row("VALOR_PAGADO"))

            '07 de junio de 2011
            dr("NOMBRE_PROYECTO") = row("NOMBRE_PROYECTO")

            'CONSULTAR(CDP)
            Dim objcdp As New CDP_Contratos
            Dim dtCDP As New DataTable
            dtCDP = objcdp.GetRecords(row("numero"))
            Dim strCDP As String = ""
            Dim strFec_CDP As String = ""
            For Each rowCDP As DataRow In dtCDP.Rows
                strCDP = strCDP + IIf(strCDP.Length = 0, rowCDP("nro_cdp"), _SEP_ + rowCDP("nro_cdp"))
                strFec_CDP = strFec_CDP + IIf(strFec_CDP.Length = 0, CStr(rowCDP("fec_cdp")), _SEP_ + CStr(rowCDP("fec_cdp")))
            Next
            dr("NRO_CDP") = strCDP
            dr("FEC_CDP") = strFec_CDP

            'CONSULTAR(RP)
            'Dim objrp As New RP_Contratos
            'Dim dtRP As New DataTable
            'dtRP = objrp.GetRecords(row("NUMERO"))
            'Dim strRP As String = ""
            'Dim strFec_RP As String = ""
            'For Each rowRP As DataRow In dtRP.Rows
            '    strRP = strRP + IIf(strRP.Length = 0, rowRP("nro_rp"), _SEP_ + rowRP("nro_rp"))
            '    strFec_RP = strFec_RP + IIf(strFec_RP.Length = 0, CStr(rowRP("fec_rp")), _SEP_ + CStr(rowRP("fec_rp")))
            'Next
            dr("NRO_RP") = row("NRO_RP")
            dr("FEC_RP") = row("FEC_RP")
            'CONSULTAR(RUBROS)
            'Dim objrc As New Rubros_Contratos
            'Dim dtrub As New DataTable
            'dtrub = objrc.GetRecords(row("NUMERO"))
            'Dim strRub As String = ""
            'Dim strFec_Rub As String = ""
            'For Each rowRub As DataRow In dtrub.Rows
            '    strRub = strRub + IIf(strRub.Length = 0, rowRub("cod_rub"), _SEP_ + rowRub("cod_rub"))
            '    strFec_Rub = strFec_Rub + IIf(strFec_Rub.Length = 0, CStr(rowRub("nom_rub").ToString), _SEP_ + CStr(rowRub("nom_rub").ToString))
            'Next
            dr("COD_RUB") = row("COD_RUB")
            dr("DES_RUB") = row("NOM_RUB")

            dt2.Rows.Add(dr)
        Next
        ds.Tables.Add(dt2)
        '--------------------
        ' Dim objE As Entidad = New Entidad()
        'Dim dsEnt As DataTable = objE.GetRecords()


        '-----------------------------
        Return dt2

    End Function
    Protected Function CreateDSContratos() As DataTable

        Dim dt As DataTable = New DataTable()
        Dim dtc As DataColumn = New DataColumn()
        dtc.DataType = System.Type.GetType("System.String")
        dtc.ColumnName = "NUMERO"
        dt.Columns.Add(dtc)
        dt.Columns.Add("CONTRATISTA", System.Type.GetType("System.String"))
        dt.Columns.Add("IDE_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("OBJ_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("DEPENDENCIA", System.Type.GetType("System.String"))
        dt.Columns.Add("TIPO", System.Type.GetType("System.String"))
        dt.Columns.Add("ESTADO", System.Type.GetType("System.String"))
        dt.Columns.Add("FEC_SUS_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("PLA_EJE_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("VAL_CON", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("EST_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("PRO_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("DEP_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("TIP_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("STIP_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("COD_SEC", System.Type.GetType("System.String"))
        dt.Columns.Add("REP_LEGAL", System.Type.GetType("System.String"))
        dt.Columns.Add("TIP_FOR", System.Type.GetType("System.String"))
        dt.Columns.Add("OTR_CNS", System.Type.GetType("System.String"))
        dt.Columns.Add("NRO_PLA_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("COD_TPROC", System.Type.GetType("System.String"))
        dt.Columns.Add("IDE_REP", System.Type.GetType("System.String"))
        dt.Columns.Add("NOM_STIP", System.Type.GetType("System.String"))
        dt.Columns.Add("NOM_EST", System.Type.GetType("System.String"))
        dt.Columns.Add("NRO_CDP", System.Type.GetType("System.String"))
        dt.Columns.Add("FEC_CDP", System.Type.GetType("System.String"))
        dt.Columns.Add("VAL_CDP", System.Type.GetType("System.String"))
        dt.Columns.Add("NRO_RP", System.Type.GetType("System.String"))
        dt.Columns.Add("VAL_RP", System.Type.GetType("System.String"))
        dt.Columns.Add("FEC_RP", System.Type.GetType("System.String"))
        dt.Columns.Add("COD_RUB", System.Type.GetType("System.String"))
        dt.Columns.Add("DES_RUB", System.Type.GetType("System.String"))
        dt.Columns.Add("DES_GASTO", System.Type.GetType("System.String"))
        dt.Columns.Add("NOM_TPROC", System.Type.GetType("System.String"))

        dt.Columns.Add("NUM_PROC", System.Type.GetType("System.String"))
        dt.Columns.Add("PRO_SEL_NRO", System.Type.GetType("System.String"))
        dt.Columns.Add("NRO_ADI", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("VAL_ADI", System.Type.GetType("System.String"))
        dt.Columns.Add("PLA_ADI", System.Type.GetType("System.String"))

        ''---- MODIFIACO EL 22 D ABRIL DEL 2010 4:29 P.M. DEL 2010
        '' BORIS ARTURO GONZALEZ

        dt.Columns.Add("FEC_APR_POL", System.Type.GetType("System.String"))
        'dt.Columns.Add("CONTRATISTA", System.Type.GetType("System.String"))
        dt.Columns.Add("EXO_OBS", System.Type.GetType("System.String"))
        dt.Columns.Add("EXO_IMP", System.Type.GetType("System.String"))
        dt.Columns.Add("EST_CONV", System.Type.GetType("System.String"))
        dt.Columns.Add("URG_MAN", System.Type.GetType("System.String"))
        dt.Columns.Add("NRO_CON", System.Type.GetType("System.String"))
        dt.Columns.Add("SECTOR", System.Type.GetType("System.String"))

        'SE AGREGA DEPENDENCIA DEL PROCESO CONTRACTUAL.
        ' MODIFICADO 
        dt.Columns.Add("DEP_PCON", System.Type.GetType("System.String")) 'Fecha 31 de Agosto 2010, se agrega campo. Ing Boris González.
        dt.Columns.Add("DEPENDENCIAP", System.Type.GetType("System.String")) 'Fecha 2 de Sept 2010, se agrega campo. Ing Boris González.

        '06 de Octubre de 2010
        dt.Columns.Add("IDE_INT", System.Type.GetType("System.String")) 'se agrega campo. Ing Boris González.
        dt.Columns.Add("LUG_EJE", System.Type.GetType("System.String"))
        dt.Columns.Add("ID_INT", System.Type.GetType("System.String"))
        dt.Columns.Add("NOM_INT", System.Type.GetType("System.String"))
        dt.Columns.Add("TIP_INT", System.Type.GetType("System.String"))
        dt.Columns.Add("NOM_TER", System.Type.GetType("System.String"))
        dt.Columns.Add("VAL_PROP", System.Type.GetType("System.Decimal"))

        dt.Columns.Add("FECHAINICIO", System.Type.GetType("System.String"))
        dt.Columns.Add("FECHAFINAL", System.Type.GetType("System.String"))
        dt.Columns.Add("FECHALIQ", System.Type.GetType("System.String"))
        dt.Columns.Add("FECHAADICION", System.Type.GetType("System.String"))
        '28 de Octubre de 2010
        dt.Columns.Add("BENEFICIADOS", System.Type.GetType("System.String"))
        'Valor Pagado
        dt.Columns.Add("VALOR_PAGADO", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("PORCEJECUCION", System.Type.GetType("System.String"))
        '07 de Junio 2011
        dt.Columns.Add("NOMBRE_PROYECTO", System.Type.GetType("System.String"))
        'Dim keys(0) As DataColumn
        'keys(0) = dtc
        'dt.PrimaryKey = keys
        'dt.AcceptChanges()

        dt.Columns.Add("STI_CTR_F20_1A", System.Type.GetType("System.String"))
        dt.Columns.Add("PRO_CTR_F20_1A", System.Type.GetType("System.String"))

        dt.Columns.Add("COD_POL", System.Type.GetType("System.String"))
        dt.Columns.Add("NOM_POL", System.Type.GetType("System.String"))
        dt.Columns.Add("NOM_ASE", System.Type.GetType("System.String"))
        dt.Columns.Add("FEC_POL", System.Type.GetType("System.String"))
        dt.Columns.Add("NRO_POL", System.Type.GetType("System.String"))
        dt.Columns.Add("VAL_POL", System.Type.GetType("System.String"))
        dt.Columns.Add("TIP_POL", System.Type.GetType("System.String"))
        dt.Columns.Add("P_ANTICIPO", System.Type.GetType("System.String"))
        Return dt

    End Function


    Protected Function Sumar_Plazo(ByVal fecha As Object, ByVal dias As Long) As String
        'Format(f, "yyyy/M/d")
        Dim f As Date
        If Not (fecha Is DBNull.Value) Then
            f = CDate(fecha)
            Return f.AddDays(dias).ToString
        Else
            Return ""
        End If
    End Function

    Protected Function Plazo(ByVal dias As Object) As Long
        If Not (dias Is DBNull.Value) Then
            Return dias
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Genera Tabla a partir de la 
    ''' </summary>
    ''' <param name="cSql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSql(ByVal cSql As String) As System.Data.DataTable
        Dim datat As DataTable

        If Not String.IsNullOrEmpty(cSql) Then
            Conectar()
            CrearComando(cSql)
            datat = EjecutarConsultaDataTable()
            Desconectar()
        Else
            datat = New DataTable
        End If
        Return datat
    End Function

    ''' <summary>
    ''' Genera Tabla a partir de la 
    ''' </summary>
    ''' <param name="cSql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSql(ByVal cSql As String, ByVal fechaRef As Date) As System.Data.DataTable
        Dim datat As DataTable

        If Not String.IsNullOrEmpty(cSql) Then
            Conectar()
            InifechaRef(fechaRef)
            CrearComando(cSql)
            datat = EjecutarConsultaDataTable()
            Desconectar()
        Else
            datat = New DataTable
        End If
        Return datat
    End Function

End Class
