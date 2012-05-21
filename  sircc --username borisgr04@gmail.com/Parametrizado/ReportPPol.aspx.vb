Imports System.Configuration
Imports System.Data
Imports Microsoft.Reporting.WebForms

Partial Class Reportes_ParametrizadoPol_report
    Inherits PaginaComun

    Dim cSql As String
    Dim Fuente_de_datos As String = "Contratos_VCONTRATOSC_A"
    'Con_CDP
    Dim Tabla As String = "VCONTRATOSC_A"
    '"Contratos_CTRL_ENTIDAD"
    Dim Fuente_de_Datos_Entidad As String = "Contratos_CTRL_ENTIDAD"
    '"RptContratosC.rdlc"
    Dim rutaReport As String = "Rpt/RptConsTCtxDep.rdlc"

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
    ''
    Public Sub report()
        Dim ds As New DataSet(Fuente_de_datos)
        Dim obj As New Contratos()
        Dim dt, dt2 As New DataTable(Tabla)
        Const _SEP_ As String = ";"
        If CBool(Request.QueryString("Rpte")) Then
            rutaReport = "Rpt/RptConsTCtxDep.rdlc"
            ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia"
        Else
            rutaReport = "Rpt/RptConsTCt.rdlc"
            ReportViewer1.LocalReport.DisplayName = "Reporte x Consecutivo"
        End If
        ReportViewer1.LocalReport.ReportPath = rutaReport


        Dim Parm(0) As ReportParameter
        Parm(0) = New ReportParameter("TITULO1", Request.QueryString("tit"))
        ReportViewer1.LocalReport.SetParameters(Parm)
        Dim Sql As String = Request.QueryString("Sql")



        'Dim txtSql As New TextBox
        'txtSql = Me.PreviousPage.FindControl("TextBox1")

        Dim consultas As String
        'consultas = txtSql.Text
        consultas = Server.UrlDecode(Sql)
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
            dr("fec_sus_con") = row("fec_sus_con").ToString
            dr("val_con") = CDec(row("val_con"))
            dr("est_con") = row("est_con")
            dr("dep_con") = row("dep_con")
            dr("tip_con") = row("tip_con")
            dr("stip_con") = row("stip_con")
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
            dr("num_proc") = row("pro_sel_nro")
            dr("nro_adi") = row("nro_adi")
            dr("val_adi") = row("val_adi")
            dr("pla_adi") = row("pla_adi")

            ''---- MODIFIACO EL 22 D ABRIL DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("fec_apr_pol") = row("FEC_APR_POL")
            dr("exo_obs") = row("EXO_OBS")
            dr("exo_imp") = row("EXO_IMP")
            dr("est_conv") = row("EST_CONV")
            dr("urg_man") = row("URG_MAN")
            dr("nro_con") = row("NRO_CON")
            ''---- MODIFIACO EL 2 D SEPT DEL 2010
            '' BORIS ARTURO GONZALEZ

            dr("dependenciap") = row("DEPENDENCIAP")
            dr("dep_pcon") = row("DEP_PCON")
            'INTERVENTOS - 6 DE OCTUBRE DE 2010
            dr("ide_int") = row("IDE_INT")
            dr("nom_ter") = row("NOM_TER")
            'Valor Aportes Propios
            dr("val_prop") = CDec(row("VAL_APO_GOB"))


            dr("FechaInicio") = (row("FechaInicio"))

            dr("FechaFinal") = Sumar_Plazo((row("FechaInicio")), (Plazo(row("pla_adi")) + Plazo(row("pla_eje_con"))))
            dr("FechaLiq") = (row("FechaLiq"))
            'Beneficiados - 28 de Octubre 2010
            dr("Beneficiados") = (row("Beneficiados"))

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
            dr("nro_cdp") = strCDP
            dr("fec_cdp") = strFec_CDP

            'CONSULTAR(RP)
            Dim objrp As New RP_Contratos
            Dim dtRP As New DataTable
            dtRP = objrp.GetRecords(row("numero"))
            Dim strRP As String = ""
            Dim strFec_RP As String = ""
            For Each rowRP As DataRow In dtRP.Rows
                strRP = strRP + IIf(strRP.Length = 0, rowRP("nro_rp"), _SEP_ + rowRP("nro_rp"))
                strFec_RP = strFec_RP + IIf(strFec_RP.Length = 0, CStr(rowRP("fec_rp")), _SEP_ + CStr(rowRP("fec_rp")))
            Next
            dr("nro_Rp") = strRP
            dr("fec_Rp") = strFec_RP

            'CONSULTAR(RUBROS)
            'Dim dtRub As New DataTable
            'dtRub = obj.GetRubrosByIde(row("numero"))
            Dim strRub As String = ""
            Dim strFec_Rub As String = ""
            'For Each rowRub As DataRow In dtRub.Rows
            '    strRub = strRub + IIf(strRub.Length = 0, rowRub("cod_rub"), _SEP_ + rowRub("cod_rub"))
            '    strFec_Rub = strFec_Rub + IIf(strFec_Rub.Length = 0, CStr(rowRub("des_rub")), _SEP_ + CStr(rowRub("des_rub")))
            'Next
            dr("cod_rub") = strRub
            dr("des_rub") = strFec_Rub

            dt2.Rows.Add(dr)
        Next
        ds.Tables.Add(dt2)
        '--------------------
        Dim objE As Entidad = New Entidad()
        Dim dsEnt As DataTable = objE.GetRecords()

        Dim rds As New ReportDataSource
        ' OJO AQUI : en la linea de abajo, deber reemplazar DataSet y DataTable por los que existen Actualmente en el diseñador de informes
        rds.Name = Fuente_de_datos
        '// myDS es el nombre de un dataset que creaste aparte y lo relacionas aqui.
        rds.Value = ds.Tables(0)
        'rds.DataSourceId = "Con_CDP"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        'ReportViewer1.LocalReport.Refresh()
        '-----------------------------
        Dim rds2 As New ReportDataSource
        ' OJO AQUI : en la linea de abajo, deber reemplazar DataSet y DataTable por los que existen Actualmente en el diseñador de informes
        rds2.Name = Fuente_de_Datos_Entidad
        '// myDS es el nombre de un dataset que creaste aparte y lo relacionas aqui.
        rds2.Value = dsEnt
        'rds.DataSourceId = "Con_CDP"
        'ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        ReportViewer1.LocalReport.Refresh()

    End Sub

    Protected Function CreateDSContratos() As DataTable

        Dim dt As DataTable = New DataTable()
        Dim dtc As DataColumn = New DataColumn()
        dtc.DataType = System.Type.GetType("System.String")
        dtc.ColumnName = "numero"
        dt.Columns.Add(dtc)
        dt.Columns.Add("contratista", System.Type.GetType("System.String"))
        dt.Columns.Add("ide_con", System.Type.GetType("System.String"))
        dt.Columns.Add("obj_con", System.Type.GetType("System.String"))
        dt.Columns.Add("dependencia", System.Type.GetType("System.String"))
        dt.Columns.Add("tipo", System.Type.GetType("System.String"))
        dt.Columns.Add("estado", System.Type.GetType("System.String"))
        dt.Columns.Add("fec_sus_con", System.Type.GetType("System.String"))
        dt.Columns.Add("pla_eje_con", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("val_con", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("est_con", System.Type.GetType("System.String"))
        dt.Columns.Add("pro_con", System.Type.GetType("System.String"))
        dt.Columns.Add("dep_con", System.Type.GetType("System.String"))
        dt.Columns.Add("tip_con", System.Type.GetType("System.String"))
        dt.Columns.Add("stip_con", System.Type.GetType("System.String"))
        dt.Columns.Add("cod_sec", System.Type.GetType("System.String"))
        dt.Columns.Add("rep_legal", System.Type.GetType("System.String"))
        dt.Columns.Add("tip_for", System.Type.GetType("System.String"))
        dt.Columns.Add("otr_cns", System.Type.GetType("System.String"))
        dt.Columns.Add("nro_pla_con", System.Type.GetType("System.String"))
        dt.Columns.Add("cod_tproc", System.Type.GetType("System.String"))
        dt.Columns.Add("ide_rep", System.Type.GetType("System.String"))
        dt.Columns.Add("nom_stip", System.Type.GetType("System.String"))
        dt.Columns.Add("nom_est", System.Type.GetType("System.String"))
        dt.Columns.Add("nro_cdp", System.Type.GetType("System.String"))
        dt.Columns.Add("fec_cdp", System.Type.GetType("System.String"))
        dt.Columns.Add("nro_rp", System.Type.GetType("System.String"))
        dt.Columns.Add("fec_rp", System.Type.GetType("System.String"))
        dt.Columns.Add("cod_rub", System.Type.GetType("System.String"))
        dt.Columns.Add("des_rub", System.Type.GetType("System.String"))
        dt.Columns.Add("des_gasto", System.Type.GetType("System.String"))
        dt.Columns.Add("nom_tproc", System.Type.GetType("System.String"))

        dt.Columns.Add("num_proc", System.Type.GetType("System.String"))
        dt.Columns.Add("nro_adi", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("val_adi", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("pla_adi", System.Type.GetType("System.Decimal"))

        ''---- MODIFIACO EL 22 D ABRIL DEL 2010 4:29 P.M. DEL 2010
        '' BORIS ARTURO GONZALEZ

        dt.Columns.Add("FEC_APR_POL", System.Type.GetType("System.String"))
        dt.Columns.Add("EXO_OBS", System.Type.GetType("System.String"))
        dt.Columns.Add("EXO_IMP", System.Type.GetType("System.String"))
        dt.Columns.Add("EST_CONV", System.Type.GetType("System.String"))
        dt.Columns.Add("URG_MAN", System.Type.GetType("System.String"))
        dt.Columns.Add("NRO_CON", System.Type.GetType("System.String"))


        'SE AGREGA DEPENDENCIA DEL PROCESO CONTRACTUAL.
        ' MODIFICADO 
        dt.Columns.Add("DEP_PCON", System.Type.GetType("System.String")) 'Fecha 31 de Agosto 2010, se agrega campo. Ing Boris González.
        dt.Columns.Add("DEPENDENCIAP", System.Type.GetType("System.String")) 'Fecha 2 de Sept 2010, se agrega campo. Ing Boris González.

        '06 de Octubre de 2010
        dt.Columns.Add("IDE_INT", System.Type.GetType("System.String")) 'se agrega campo. Ing Boris González.
        dt.Columns.Add("NOM_TER", System.Type.GetType("System.String")) 'se agrega campo. Ing Boris González.
        dt.Columns.Add("VAL_PROP", System.Type.GetType("System.Decimal")) 'se agrega campo. Ing Boris González.

        dt.Columns.Add("FechaInicio", System.Type.GetType("System.String"))
        dt.Columns.Add("FechaFinal", System.Type.GetType("System.String"))
        dt.Columns.Add("FechaLiq", System.Type.GetType("System.String"))

        '28 de Octubre de 2010
        dt.Columns.Add("Beneficiados", System.Type.GetType("System.String"))

        Dim keys(0) As DataColumn
        keys(0) = dtc
        dt.PrimaryKey = keys
        dt.AcceptChanges()
        Return dt

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'report()

        Dim Sql As String = Request.QueryString("Sql")
        If Membership.GetUser.UserName.ToUpper = "ADMIN" Then
            Me.TxtSql.Visible = True
        Else
            Me.TxtSql.Visible = False
        End If
        Me.TxtSql.Text = Sql

        Select Case Request.QueryString("Rpte")
            Case "Dep_Nec"
                rutaReport = "Rpt\RptConsTCt2011xDep.rdlc"
                ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia"
            Case "Dep_Del"
                rutaReport = "Rpt\RptConsTCt2011xDepE.rdlc"
                ReportViewer1.LocalReport.DisplayName = "Reporte x Proyecto"
            Case "Pro_Con"
                rutaReport = "Rpt\RptConsTCt2011xPro.rdlc"
                ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia Delegada"
            Case "Pol_Con"
                rutaReport = "Rpt\RptConsTCt2011Pol.rdlc"
                ReportViewer1.LocalReport.DisplayName = "Reporte x Polizas"
            Case Else
                rutaReport = "Rpt\RptConsTCt2011.rdlc"
                ReportViewer1.LocalReport.DisplayName = "Reporte General"

        End Select

        ReportViewer1.LocalReport.ReportPath = rutaReport
        ReportViewer1.LocalReport.Refresh()

    End Sub

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
End Class
