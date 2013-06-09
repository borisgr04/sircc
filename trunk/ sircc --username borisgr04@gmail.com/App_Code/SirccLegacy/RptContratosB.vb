'MODIFICADO POR ERICK-----------PARA IMPLEMENTAR FM20
' FUNCION GenerarReportF20


Imports Microsoft.VisualBasic
Imports System.Data.Common
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class RptContratosB
    Inherits BDDatos
    Dim _Caractar_Fecha As String = "-"
    Dim _Vacio_Contraloria As String = "ND"
    Public rptSql As String

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GenerarReportB(ByVal Sql As String) As DataTable
        Dim ds As New DataSet()
        Dim obj As New Contratos()
        Dim dt, dt2 As New DataTable()
        dt = obj.GetSql(Sql)
        Return dt
        'dt2 = Me.CreateDSContratos()
        'For Each row As DataRow In dt.Rows
        '    Dim dr As DataRow
        '    dr = dt2.NewRow()
        '    dr("NUMERO") = row("numero")
        '    'dr("des_gasto") = row("des_gasto")
        '    dr("CONTRATISTA") = row("contratista")
        '    dr("OBJ_CON") = row("obj_con")
        '    dr("IDE_CON") = row("ide_con")
        '    dr("DEPENDENCIA") = row("dependencia")
        '    dr("TIPO") = row("tipo")

        '    dr("ESTADO") = row("estado")
        '    dr("FEC_SUS_CON") = row("fec_sus_con").ToString
        '    dr("VAL_CON") = CDec(row("val_con"))
        '    dr("EST_CON") = row("est_con")
        '    dr("DEP_CON") = row("dep_con")
        '    dr("TIP_CON") = row("tip_con")
        '    dr("STIP_CON") = row("stip_con")
        '    dr("COD_SEC") = row("cod_sec")
        '    dr("REP_LEGAL") = row("rep_legal")
        '    dr("TIP_FOR") = row("tip_for")
        '    dr("OTR_CNS") = row("otr_cns")
        '    dr("PLA_EJE_CON") = row("pla_eje_con")
        '    dr("IDE_REP") = row("ide_rep")
        '    dr("NOM_STIP") = row("nom_stip")
        '    dr("NOM_EST") = row("nom_est")
        '    dr("PRO_CON") = row("pro_con")
        '    dr("NOM_TPROC") = row("nom_tproc")
        '    dr("NUM_PROC") = row("PRO_SEL_NRO")
        '    dr("PRO_SEL_NRO") = row("PRO_SEL_NRO")
        '    dr("NRO_ADI") = row("nro_adi")
        '    dr("VAL_ADI") = row("val_adi")
        '    dr("PLA_ADI") = row("pla_adi")

        '    ''---- MODIFIACO EL 22 D ABRIL DEL 2010
        '    '' BORIS ARTURO GONZALEZ

        '    dr("FEC_APR_POL") = row("FEC_APR_POL")
        '    dr("EXO_OBS") = row("EXO_OBS")
        '    dr("EXO_IMP") = row("EXO_IMP")
        '    dr("EST_CONV") = row("EST_CONV")
        '    dr("URG_MAN") = row("URG_MAN")
        '    dr("NRO_CON") = row("NRO_CON")
        '    ''---- MODIFIACO EL 2 D SEPT DEL 2010
        '    '' BORIS ARTURO GONZALEZ

        '    dr("DEPENDENCIAP") = row("DEPENDENCIAP")
        '    dr("DEP_PCON") = row("DEP_PCON")
        '    dr("NOM_INT") = row("Nom_Interventor")
        '    dr("IDE_INT") = row("Id_Interventor")
        '    dr("TIP_INT") = row("Tip_Vin_Int")
        '    dr("VAL_PROP") = CDec(row("VAL_APO_GOB"))
        '    dr("FECHAINICIO") = (row("FechaInicio"))

        '    dr("FECHAFINAL") = Sumar_Plazo((row("FechaInicio")), (Plazo(row("pla_adi")) + Plazo(row("pla_eje_con"))))
        '    dr("FECHALIQ") = (row("FechaLiq"))
        '    dr("BENEFICIADOS") = (row("Beneficiados"))
        '    dr("NOMBRE_PROYECTO") = row("NOMBRE_PROYECTO")

        '    dt2.Rows.Add(dr)
        'Next
        'ds.Tables.Add(dt2)

        '-----------------------------
        'Return dt2

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GenerarReport(ByVal Sql As String) As DataTable
        Dim ds As New DataSet()
        Dim obj As New Contratos()
        Dim dt, dt2 As New DataTable()
        Const _SEP_ As String = ";"

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
            dr("NOM_INT") = row("Nom_Interventor")
            dr("IDE_INT") = row("Id_Interventor")
            dr("TIP_INT") = row("Tip_Vin_Int")
            dr("VAL_PROP") = CDec(row("VAL_APO_GOB"))
            dr("FECHAINICIO") = (row("FechaInicio"))

            dr("FECHAFINAL") = Sumar_Plazo((row("FechaInicio")), (Plazo(row("pla_adi")) + Plazo(row("pla_eje_con"))))
            dr("FECHALIQ") = (row("FechaLiq"))
            dr("BENEFICIADOS") = (row("Beneficiados"))
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
    Public Function GenerarReportG(ByVal cSql As String) As System.Data.DataTable
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
