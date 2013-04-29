Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel
Public Class Modificaciones
    Inherits BDDatos
    Private _ResPRad As String
    Property ResPRad() As String
        Get
            Return _ResPRad
        End Get
        Set(ByVal value As String)
            _ResPRad = value
        End Set
    End Property
    Private _Valor_Restante As String
    Property Valor_Restante() As Double
        Get
            Return _Valor_Restante
        End Get
        Set(ByVal value As Double)
            _Valor_Restante = value
        End Set
    End Property
    Sub New()
        Me.Tabla = "MOD_CONTRATOS"
        Me.Vista = "VMOD_CONTRATOS"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPK(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * from " + Vista + " Where Num_Sol_Adi=:Num_Sol_Adi"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
    Public Function Aceptar_Solicitud(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String) As String
        Me.Conectar()
        Me.querystring = "ACEPTAR_MOD_CONTRATO"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim PReturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("Cod_Con", Cod_Con)
        AsignarParametroCad("Num_Sol_Adi", Num_Sol_Adi)
        EjecutarComando()
        Return PReturn.Value.ToString
    End Function
    Public Function GetNumSol(ByVal Cod_Con As String) As Integer
        Me.Conectar()
        Me.querystring = "select count(*) Solicitudes from vsoladihrev where concepto='P' and cod_con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return CInt(dt.Rows(0)("Solicitudes").ToString)
    End Function
    Public Function GetNumSolProc(ByVal Cod_Con As String) As Integer
        Me.Conectar()
        Me.querystring = "select count(*) Modificaciones from mod_contratos where mod_estado<>'RA' and Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return CInt(dt.Rows(0)("Modificaciones").ToString)
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPConMun(ByVal NUM_SOL_ADI As String) As DataTable
        Me.Conectar()
        querystring = "SELECT MUNICIPIOS.COD_MUN , MUNICIPIOS.NOM_MUN,(SELECT CASE WHEN count(*)=0 THEN '0' ELSE '1' END AS EST FROM MOD_CONMUN WHERE  NUM_SOL_ADI=:NUM_SOL_ADI and cod_mun=MUNICIPIOS.cod_mun) EST  FROM MUNICIPIOS "
        CrearComando(querystring)
        AsignarParametroCadena(":NUM_SOL_ADI", NUM_SOL_ADI)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
    Public Function Update(ByVal NUM_SOL_ADI As String, ByVal COD_TPRO As String, ByVal OBJ_CON As String, ByVal PRO_CON As String, ByVal PLA_EJE_CON As String, ByVal DEP_CON As String, ByVal DEP_PCON As String, ByVal VIG_CON As Decimal, ByVal TIP_CON As String, ByVal STIP_CON As String, ByVal VAL_CON As Decimal, ByVal VAL_APO_GOB As Decimal, ByVal COD_SEC As String, ByVal TIP_FOR As String, ByVal NRO_PLA_CON As String, ByVal URG_MAN As String, ByVal EST_CONV As String, ByVal APL_GAC As String, ByVal LUG_EJE As String, ByVal TPlazo As String, ByVal SECTOR As String, ByVal COD_CON As String, ByVal Plazo2 As String, ByVal tip_plazo2 As String, ByVal val_sin_iva As Decimal, ByVal Interventoria As String, ByVal Agotar_Ppto As String, ByVal Considerandos As String, ByVal Aportes As String, ByVal Mun() As String, ByVal nm As Integer, ByVal REVISADOPOR As String, ByVal Obs_Proyectos As String, ByVal Obs_CDP As String, ByVal Obs_Polizas As String) As String
        Me.Conectar()
        Try
            If TPlazo = "D" Then
                Me.ComenzarTransaccion()
                querystring = "Update MOD_CONTRATOS SET REVISADOPOR=:REVISADOPOR, COD_TPRO=:COD_TPRO, OBJ_CON=:OBJ_CON, PRO_CON=:PRO_CON, PLA_EJE_CON=To_Number(:PLA_EJE_CON), DEP_CON=:DEP_CON, DEP_PCON=:DEP_PCON, VIG_CON=:VIG_CON, TIP_CON=:TIP_CON, STIP_CON=:STIP_CON, VAL_CON=:VAL_CON, VAL_APO_GOB=:VAL_APO_GOB, TIP_FOR=:TIP_FOR, LUG_EJE=:LUG_EJE, TIPO_PLAZO=:Tplazo, URG_MAN=:URG_MAN, EST_CONV=:EST_CONV, COD_SEC=:SECTOR, VAL_SIN_IVA=:VAL_SIN_IVA, INTERVENTORIA=:INTERVENTORIA, AGOTAR_PPTO=:AGOTAR_PPTO, CONSIDERANDOS=:CONSIDERANDOS,APORTES=:APORTES, Obs_Proyectos=:Obs_Proyectos, Obs_CDP=:Obs_CDP, Obs_Poliza=:Obs_Polizas WHERE NUM_SOL_ADI=:NUM_SOL_ADI AND COD_CON=:COD_CON"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
                Me.AsignarParametroCadena(":REVISADOPOR", REVISADOPOR)
                Me.AsignarParametroCadena(":OBJ_CON", OBJ_CON)
                Me.AsignarParametroCadena(":PRO_CON", PRO_CON)
                Me.AsignarParametroEntero(":PLA_EJE_CON", CInt(PLA_EJE_CON))
                Me.AsignarParametroCadena(":DEP_CON", DEP_CON)
                Me.AsignarParametroCadena(":VIG_CON", VIG_CON)
                Me.AsignarParametroCadena(":TIP_CON", TIP_CON)
                Me.AsignarParametroCadena(":STIP_CON", STIP_CON)
                Me.AsignarParametroDecimal(":VAL_CON", VAL_CON)
                Me.AsignarParametroDecimal(":VAL_APO_GOB", VAL_APO_GOB)
                Me.AsignarParametroCadena(":TIP_FOR", TIP_FOR)
                Me.AsignarParametroCadena(":DEP_PCON", DEP_PCON)
                Me.AsignarParametroCadena(":LUG_EJE", LUG_EJE)
                Me.AsignarParametroCadena(":NUM_SOL_ADI", NUM_SOL_ADI)
                Me.AsignarParametroCadena(":Tplazo", TPlazo)
                Me.AsignarParametroCadena(":URG_MAN", URG_MAN)
                Me.AsignarParametroCadena(":EST_CONV", EST_CONV)
                Me.AsignarParametroCadena(":SECTOR", SECTOR)
                Me.AsignarParametroCadena(":COD_CON", COD_CON)
                Me.AsignarParametroDecimal(":VAL_SIN_IVA", val_sin_iva)
                Me.AsignarParametroCadena(":INTERVENTORIA", Interventoria)
                '-------
                '11 JN 2011- BORIS
                Me.AsignarParametroCadena(":AGOTAR_PPTO", Agotar_Ppto)
                Me.AsignarParametroCLOB(":CONSIDERANDOS", Considerandos)
                '18 Jn 2011 BORIS
                Me.AsignarParametroCLOB(":Aportes", Aportes)
                Me.AsignarParametroCLOB(":Obs_Proyectos", Obs_Proyectos)
                Me.AsignarParametroCLOB(":Obs_CDP", Obs_CDP)
                Me.AsignarParametroCLOB(":Obs_Polizas", Obs_Polizas)
                'Me.AsignarParametroEntero(":PLA_EJE_CON", CInt(Plazo2))
                'Throw New Exception(Me.vComando.CommandText)
                Me.num_reg = Me.EjecutarComando()
                'RELACIONAR MUNICIPIOS A PROCESO
                querystring = "DELETE FROM Mod_ConMun WHERE NUM_SOL_ADI='" + NUM_SOL_ADI + "' and NRO_CON=" + COD_CON
                Me.CrearComando(querystring)
                EjecutarComando()

                For i = 0 To nm
                    querystring = "INSERT INTO Mod_ConMun(Num_Sol_Adi,Cod_Mun, Nro_Con)VALUES('" + NUM_SOL_ADI + "','" + Mun(i) + "'," + COD_CON + ") "
                    Me.CrearComando(querystring)
                    EjecutarComando()
                Next i
                Me.ConfirmarTransaccion()
                Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                Me.lErrorG = False
            Else
                Me.ComenzarTransaccion()
                querystring = "Update MOD_CONTRATOS SET REVISADOPOR=:REVISADOPOR, COD_TPRO=:COD_TPRO, OBJ_CON=:OBJ_CON, PRO_CON=:PRO_CON, PLA_EJE_CON=to_number(:PLA_EJE_CON), DEP_CON=:DEP_CON, DEP_PCON=:DEP_PCON, VIG_CON=:VIG_CON, TIP_CON=:TIP_CON, STIP_CON=:STIP_CON, VAL_CON=:VAL_CON, VAL_APO_GOB=:VAL_APO_GOB, TIP_FOR=:TIP_FOR, LUG_EJE=:LUG_EJE, TIPO_PLAZO=:Tplazo, URG_MAN=:URG_MAN, EST_CONV=:EST_CONV, COD_SEC=:SECTOR, VAL_SIN_IVA=:VAL_SIN_IVA, PLAZO2_EJE_CON=:PLAZO2, TIPO_PLAZO2=:Tplazo2, INTERVENTORIA=:INTERVENTORIA, AGOTAR_PPTO=:AGOTAR_PPTO, CONSIDERANDOS=:CONSIDERANDOS, APORTES=:APORTES, obs_proyectos=:Obs_Proyectos, Obs_CDP=:Obs_CDP, Obs_Poliza=:Obs_Polizas WHERE NUM_SOL_ADI=:NUM_SOL_ADI AND COD_CON=:COD_CON"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
                Me.AsignarParametroCadena(":REVISADOPOR", REVISADOPOR)
                Me.AsignarParametroCadena(":OBJ_CON", OBJ_CON)
                Me.AsignarParametroCadena(":PRO_CON", PRO_CON)
                Me.AsignarParametroEntero(":PLA_EJE_CON", CInt(PLA_EJE_CON))
                Me.AsignarParametroCadena(":DEP_CON", DEP_CON)
                Me.AsignarParametroCadena(":VIG_CON", VIG_CON)
                Me.AsignarParametroCadena(":TIP_CON", TIP_CON)
                Me.AsignarParametroCadena(":STIP_CON", STIP_CON)
                Me.AsignarParametroDecimal(":VAL_CON", VAL_CON)
                Me.AsignarParametroDecimal(":VAL_APO_GOB", VAL_APO_GOB)
                Me.AsignarParametroCadena(":TIP_FOR", TIP_FOR)
                Me.AsignarParametroCadena(":DEP_PCON", DEP_PCON)
                Me.AsignarParametroCadena(":LUG_EJE", LUG_EJE)
                Me.AsignarParametroCadena(":NUM_SOL_ADI", NUM_SOL_ADI)
                Me.AsignarParametroCadena(":Tplazo", TPlazo)
                Me.AsignarParametroCadena(":URG_MAN", URG_MAN)
                Me.AsignarParametroCadena(":EST_CONV", EST_CONV)
                Me.AsignarParametroCadena(":SECTOR", SECTOR)
                Me.AsignarParametroCadena(":COD_CON", COD_CON)
                Me.AsignarParametroDecimal(":VAL_SIN_IVA", val_sin_iva)
                Me.AsignarParametroEntero(":PLAZO2", CInt(Plazo2))
                Me.AsignarParametroCadena(":Tplazo2", tip_plazo2)
                Me.AsignarParametroCadena(":INTERVENTORIA", Interventoria)
                '11 JN 2011- BORIS
                Me.AsignarParametroCadena(":AGOTAR_PPTO", Agotar_Ppto)
                Me.AsignarParametroCLOB(":CONSIDERANDOS", Considerandos)
                '18 Jn 2011 BORIS
                Me.AsignarParametroCLOB(":APORTES", Aportes)
                Me.AsignarParametroCLOB(":Obs_Proyectos", Obs_Proyectos)
                Me.AsignarParametroCLOB(":Obs_CDP", Obs_CDP)
                Me.AsignarParametroCLOB(":Obs_Polizas", Obs_Polizas)
                'Throw New Exception(Me.vComando.CommandText)
                Me.num_reg = Me.EjecutarComando()
                'RELACIONAR MUNICIPIOS A PROCESO
                querystring = "DELETE FROM Mod_ConMun WHERE NUM_SOL_ADI='" + NUM_SOL_ADI + "' and Nro_Con=" + COD_CON
                Me.CrearComando(querystring)
                EjecutarComando()

                For i = 0 To nm
                    querystring = "INSERT INTO Mod_ConMun(Num_Sol_Adi,Cod_Mun, Nro_Con)VALUES('" + NUM_SOL_ADI + "','" + Mun(i) + "'," + COD_CON + ") "
                    Me.CrearComando(querystring)
                    EjecutarComando()
                Next i
                Me.ConfirmarTransaccion()
                Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                Me.lErrorG = False
            End If
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Me.Msg
    End Function
    Public Function Validar(ByVal Num_Sol_Adi As String, ByVal Cod_Con As String) As String
        Me.Conectar()
        Dim SqlUpdate As String = "UPDATE Contratos SET "
        Me.querystring = "select NRO_CON, IDE_CON, OBJ_CON, PRO_CON, " & _
                         "FEC_SUS_CON, PLA_EJE_CON, DEP_CON, VIG_CON, TIP_CON," & _
                         "STIP_CON, EST_CON, VAL_CON, DOC_CON, COD_CON," & _
                         "CAN_ADI, VAL_ADI, COD_SEC, TIP_FOR, OTR_CNS, " & _
                         "COD_TPRO, NRO_PLA_CON, IDE_REP, USUARIO, FEC_REG, " & _
                         "OBS_DOC_CON, URG_MAN, EST_CONV, FEC_APR_POL, EXO_IMP, " & _
                         "EXO_OBS, PRO_SEL_NRO, DEP_PCON, VAL_APO_GOB, COD_CON0, " & _
                         "FEC_ULT_MOD, USER_ACT, LEGALIZADO, PER_APO, ANTICIPO, " & _
                         "NEMPLEOS, AGOTAR_PPTO, LUG_EJE, NUM_PROC, TIPO_PLAZO, " & _
                         "TIP_RADICACION, GRUPO, ENCARGADO, PLAZO2_EJE_CON, " & _
                         "TIPO_PLAZO2, VAL_SIN_IVA, INTERVENTORIA, CONSIDERANDOS, APORTES, OBS_POLIZA, OBS_CDP, OBS_PROYECTOS, REVISADOPOR from contratos Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dtcon As DataTable = EjecutarConsultaDataTable()

        'TRAER DATOS DE LA MODIFICACION
        Me.querystring = "select NRO_CON, IDE_CON, OBJ_CON, PRO_CON, " & _
                         "FEC_SUS_CON, PLA_EJE_CON, DEP_CON, VIG_CON, TIP_CON," & _
                         "STIP_CON, EST_CON, VAL_CON, DOC_CON, COD_CON," & _
                         "CAN_ADI, VAL_ADI, COD_SEC, TIP_FOR, OTR_CNS, " & _
                         "COD_TPRO, NRO_PLA_CON, IDE_REP, USUARIO, FEC_REG, " & _
                         "OBS_DOC_CON, URG_MAN, EST_CONV, FEC_APR_POL, EXO_IMP, " & _
                         "EXO_OBS, PRO_SEL_NRO, DEP_PCON, VAL_APO_GOB, COD_CON0, " & _
                         "FEC_ULT_MOD, USER_ACT, LEGALIZADO, PER_APO, ANTICIPO, " & _
                         "NEMPLEOS, AGOTAR_PPTO, LUG_EJE, NUM_PROC, TIPO_PLAZO, " & _
                         "TIP_RADICACION, GRUPO, ENCARGADO, PLAZO2_EJE_CON, " & _
                         "TIPO_PLAZO2, VAL_SIN_IVA, INTERVENTORIA, CONSIDERANDOS, APORTES, OBS_POLIZA, OBS_CDP, OBS_PROYECTOS, REVISADOPOR from mod_contratos Where Cod_Con=:Cod_Con And Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dtModcon As DataTable = EjecutarConsultaDataTable()
        ComenzarTransaccion()
        Try
            For i As Integer = 0 To dtcon.Columns.Count - 1
                If dtcon.Rows(0).Item(i).ToString <> dtModcon.Rows(0).Item(i).ToString Then
                    If dtModcon.Columns(i).ColumnName = "PLA_EJE_CON" Or dtModcon.Columns(i).ColumnName = "VAL_CON" Or dtModcon.Columns(i).ColumnName = "VAL_APO_GOB" Or dtModcon.Columns(i).ColumnName = "NEMPLEOS" Or dtModcon.Columns(i).ColumnName = "PLAZO2_EJE_CON" Or dtModcon.Columns(i).ColumnName = "VAL_SIN_IVA" Then
                        SqlUpdate += dtModcon.Columns(i).ColumnName & "=" & dtModcon.Rows(0).Item(i).ToString.Replace(",", ".") & ","
                    Else
                        SqlUpdate += dtModcon.Columns(i).ColumnName & "=''" & dtModcon.Rows(0).Item(i).ToString & "'',"
                    End If
                    querystring = "INSERT INTO MIN_MOD_CONTRATO(Num_Sol_Adi,Campo, Valor_Nuevo, Valor_Anterior)VALUES('" + Num_Sol_Adi + "','" + dtModcon.Columns(i).ColumnName + "','" + dtModcon.Rows(0).Item(i).ToString + "','" + dtcon.Rows(0).Item(i).ToString + "')"
                    Me.CrearComando(querystring)
                    EjecutarComando()
                End If
            Next
            Dim j As Integer = SqlUpdate.Length - 1
            Dim sqlu As String = SqlUpdate.Remove(j, 1)
            SqlUpdate = sqlu & " Where COD_CON=" & Cod_Con
            querystring = "UPDATE MOD_CONTRATOS SET MOD_ESTADO='DF', SQL_UPDATE='" & SqlUpdate & "' WHERE NUM_SOL_ADI=" & Num_Sol_Adi
            Me.CrearComando(querystring)
            EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = "La validación se realizo con exito. Puede Radicar la Modificacion."
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Validar(ByVal Num_Sol_Adi As String, ByVal Cod_Con As String, ByVal Num_Proc As String) As String
        Me.Conectar()
        Dim SqlUpdate As String = "UPDATE Contratos SET "
        Me.querystring = "select NRO_CON, IDE_CON, OBJ_CON, PRO_CON, " & _
                         "FEC_SUS_CON, PLA_EJE_CON, DEP_CON, VIG_CON, TIP_CON," & _
                         "STIP_CON, EST_CON, VAL_CON, DOC_CON, COD_CON," & _
                         "CAN_ADI, VAL_ADI, COD_SEC, TIP_FOR, OTR_CNS, " & _
                         "COD_TPRO, NRO_PLA_CON, IDE_REP, USUARIO, FEC_REG, " & _
                         "OBS_DOC_CON, URG_MAN, EST_CONV, FEC_APR_POL, EXO_IMP, " & _
                         "EXO_OBS, PRO_SEL_NRO, DEP_PCON, VAL_APO_GOB, COD_CON0, " & _
                         "FEC_ULT_MOD, USER_ACT, LEGALIZADO, PER_APO, ANTICIPO, " & _
                         "NEMPLEOS, AGOTAR_PPTO, LUG_EJE, NUM_PROC, TIPO_PLAZO, " & _
                         "TIP_RADICACION, GRUPO, ENCARGADO, PLAZO2_EJE_CON, " & _
                         "TIPO_PLAZO2, VAL_SIN_IVA, INTERVENTORIA, CONSIDERANDOS, APORTES from contratos Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dtcon As DataTable = EjecutarConsultaDataTable()

        'TRAER DATOS DE LA MODIFICACION
        Me.querystring = "select NRO_CON, IDE_CON, OBJ_CON, PRO_CON, " & _
                         "FEC_SUS_CON, PLA_EJE_CON, DEP_CON, VIG_CON, TIP_CON," & _
                         "STIP_CON, EST_CON, VAL_CON, DOC_CON, COD_CON," & _
                         "CAN_ADI, VAL_ADI, COD_SEC, TIP_FOR, OTR_CNS, " & _
                         "COD_TPRO, NRO_PLA_CON, IDE_REP, USUARIO, FEC_REG, " & _
                         "OBS_DOC_CON, URG_MAN, EST_CONV, FEC_APR_POL, EXO_IMP, " & _
                         "EXO_OBS, PRO_SEL_NRO, DEP_PCON, VAL_APO_GOB, COD_CON0, " & _
                         "FEC_ULT_MOD, USER_ACT, LEGALIZADO, PER_APO, ANTICIPO, " & _
                         "NEMPLEOS, AGOTAR_PPTO, LUG_EJE, NUM_PROC, TIPO_PLAZO, " & _
                         "TIP_RADICACION, GRUPO, ENCARGADO, PLAZO2_EJE_CON, " & _
                         "TIPO_PLAZO2, VAL_SIN_IVA, INTERVENTORIA, CONSIDERANDOS, APORTES from mod_contratos Where Cod_Con=:Cod_Con And Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dtModcon As DataTable = EjecutarConsultaDataTable()
        ComenzarTransaccion()
        Dim npla As Integer = 0
        Try
            For i As Integer = 0 To dtcon.Columns.Count - 1
                If dtcon.Rows(0).Item(i).ToString <> dtModcon.Rows(0).Item(i).ToString Then
                    If dtModcon.Columns(i).ColumnName = "PLA_EJE_CON" Or dtModcon.Columns(i).ColumnName = "VAL_CON" Or dtModcon.Columns(i).ColumnName = "VAL_APO_GOB" Or dtModcon.Columns(i).ColumnName = "NEMPLEOS" Or dtModcon.Columns(i).ColumnName = "PLAZO2_EJE_CON" Or dtModcon.Columns(i).ColumnName = "VAL_SIN_IVA" Then
                        SqlUpdate += dtModcon.Columns(i).ColumnName & "=" & dtModcon.Rows(0).Item(i).ToString & ","
                    Else
                        SqlUpdate += dtModcon.Columns(i).ColumnName & "=''" & dtModcon.Rows(0).Item(i).ToString & "'',"
                    End If
                    If dtModcon.Columns(i).ColumnName = "PLA_EJE_CON" Or dtModcon.Columns(i).ColumnName = "PLAZO2_EJE_CON" Or dtModcon.Columns(i).ColumnName = "TIPO_PLAZO" Or dtModcon.Columns(i).ColumnName = "TIPO_PLAZO2" Then
                        If dtModcon.Rows(0)("TIPO_PLAZO").ToString = "D" And dtModcon.Rows(0)("TIPO_PLAZO2").ToString = "" And npla = 0 Then
                            querystring = "INSERT INTO MIN_MOD_CONTRATO(Num_Sol_Adi,Campo, Valor_Nuevo, Valor_Anterior)VALUES('" + Num_Sol_Adi + "','" + "PLAZO" + "','" + dtModcon.Rows(0)("PLA_EJE_CON").ToString + " DIAS','" + dtcon.Rows(0)("PLA_EJE_CON").ToString + " " + dtcon.Rows(0)("TIPO_PLAZO").ToString + " Y " + dtcon.Rows(0)("PLAZO2_EJE_CON").ToString + dtcon.Rows(0)("TIPO_PLAZO2").ToString + "')"
                            Me.CrearComando(querystring)
                            EjecutarComando()
                            npla += 1
                        ElseIf dtModcon.Rows(0)("TIPO_PLAZO").ToString = "M" And dtModcon.Rows(0)("TIPO_PLAZO2").ToString = "D" And npla = 0 Then
                            querystring = "INSERT INTO MIN_MOD_CONTRATO(Num_Sol_Adi,Campo, Valor_Nuevo, Valor_Anterior)VALUES('" + Num_Sol_Adi + "','" + "PLAZO" + "','" + dtModcon.Rows(0)("PLA_EJE_CON").ToString + " MESES y " + dtModcon.Rows(0)("PLAZO2_EJE_CON").ToString + " DIAS','" + dtcon.Rows(0)("PLA_EJE_CON").ToString + " " + dtcon.Rows(0)("TIPO_PLAZO").ToString + " Y " + dtcon.Rows(0)("PLAZO2_EJE_CON").ToString + dtcon.Rows(0)("TIPO_PLAZO2").ToString + "')"
                            Me.CrearComando(querystring)
                            EjecutarComando()
                            npla += 1
                        ElseIf dtModcon.Rows(0)("TIPO_PLAZO").ToString = "A" And dtModcon.Rows(0)("TIPO_PLAZO2").ToString = "M" And npla = 0 Then
                            querystring = "INSERT INTO MIN_MOD_CONTRATO(Num_Sol_Adi,Campo, Valor_Nuevo, Valor_Anterior)VALUES('" + Num_Sol_Adi + "','" + "PLAZO" + "','" + dtModcon.Rows(0)("PLA_EJE_CON").ToString + " AÑOS y " + dtModcon.Rows(0)("PLAZO2_EJE_CON").ToString + " MESES','" + dtcon.Rows(0)("PLA_EJE_CON").ToString + " " + dtcon.Rows(0)("TIPO_PLAZO").ToString + " Y " + dtcon.Rows(0)("PLAZO2_EJE_CON").ToString + dtcon.Rows(0)("TIPO_PLAZO2").ToString + "')"
                            Me.CrearComando(querystring)
                            EjecutarComando()
                            npla += 1
                        ElseIf dtModcon.Rows(0)("TIPO_PLAZO").ToString = "A" And dtModcon.Rows(0)("TIPO_PLAZO2").ToString = "D" And npla = 0 Then
                            querystring = "INSERT INTO MIN_MOD_CONTRATO(Num_Sol_Adi,Campo, Valor_Nuevo, Valor_Anterior)VALUES('" + Num_Sol_Adi + "','" + "PLAZO" + "','" + dtModcon.Rows(0)("PLA_EJE_CON").ToString + " AÑOS y " + dtModcon.Rows(0)("PLAZO2_EJE_CON").ToString + " DIAS','" + dtcon.Rows(0)("PLA_EJE_CON").ToString + " " + dtcon.Rows(0)("TIPO_PLAZO").ToString + " Y " + dtcon.Rows(0)("PLAZO2_EJE_CON").ToString + dtcon.Rows(0)("TIPO_PLAZO2").ToStringg + "')"
                            Me.CrearComando(querystring)
                            EjecutarComando()
                            npla += 1
                        End If
                    Else
                        querystring = "INSERT INTO MIN_MOD_CONTRATO(Num_Sol_Adi,Campo, Valor_Nuevo, Valor_Anterior)VALUES('" + Num_Sol_Adi + "','" + dtModcon.Columns(i).ColumnName + "','" + dtModcon.Rows(0).Item(i).ToString + "','" + dtcon.Rows(0).Item(i).ToString + "')"
                        Me.CrearComando(querystring)
                        EjecutarComando()
                    End If

                End If
            Next
            Dim j As Integer = SqlUpdate.Length - 1
            Dim sqlu As String = SqlUpdate.Remove(j, 1)
            SqlUpdate = sqlu & " Where COD_CON=" & Cod_Con
            querystring = "UPDATE MOD_CONTRATOS SET MOD_ESTADO='DF', SQL_UPDATE='" & SqlUpdate & "' WHERE NUM_SOL_ADI=" & Num_Sol_Adi
            Me.CrearComando(querystring)
            EjecutarComando()
            '------------------------------------VALIDACION DE MODIFICACION A PROPONENTES------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Me.querystring = "SELECT IDE_PROP, NUM_PROC, " & _
                             "FEC_MOD, USBD_MOD, USAP_MOD, VAL_PROP, FEC_PROP, " & _
                             "ADJUDICADO, FECHA_ADJUDICACION, OBSERVACION_ADJUDICACION, APE1_PROP, DIR_PROP, " & _
                             "TEL_PROP, EMAIL_PROP, APE2_PROP, NOM1_PROP, NOM2_PROP, " & _
                             "TIP_IDE, EXP_IDE, DV_TER, RAZON_SOCIAL, ORD_GAS, " & _
                             "CAR_FUN, DOC_DEL, FEC_DEL, TIPO, ESTADO, " & _
                             "OBSERVACION, NUM_FOLIO, ID_REP_LEGAL, NOM_REP_LEGAL, COD_AUX, " & _
                             "MUNICIPIO, GRUPO, NUMPOLIZA, FECHA_INICIAL, FECHA_FINAL, " & _
                             "ASEGURADORA, NOM_POLIZA, VALOR_POLIZA, DENOMINACION, APORTES, " & _
                             "NOM_TIPPROP, TDOC_NOM FROM VGPPROPONENTES WHERE Num_Proc=:Num_Proc"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
            Dim dtprop As DataTable = EjecutarConsultaDataTable()
            '-------------------traer datos de modificacion de proponentes--------------------------------------------------------------------------------------------------------------------------------------------------
            Me.querystring = "SELECT IDE_PROP, NUM_PROC, " & _
                             "FEC_MOD, USBD_MOD, USAP_MOD, VAL_PROP, FEC_PROP, " & _
                             "ADJUDICADO, FECHA_ADJUDICACION, OBSERVACION_ADJUDICACION, APE1_PROP, DIR_PROP, " & _
                             "TEL_PROP, EMAIL_PROP, APE2_PROP, NOM1_PROP, NOM2_PROP, " & _
                             "TIP_IDE, EXP_IDE, DV_TER, RAZON_SOCIAL, ORD_GAS, " & _
                             "CAR_FUN, DOC_DEL, FEC_DEL, TIPO, ESTADO, " & _
                             "OBSERVACION, NUM_FOLIO, ID_REP_LEGAL, NOM_REP_LEGAL, COD_AUX, " & _
                             "MUNICIPIO, GRUPO, NUMPOLIZA, FECHA_INICIAL, FECHA_FINAL, " & _
                             "ASEGURADORA, NOM_POLIZA, VALOR_POLIZA, DENOMINACION, APORTES, " & _
                             "NOM_TIPPROP, TDOC_NOM FROM VMOD_PROPONENTES WHERE NUM_SOL_ADI=:Num_Sol_Adi"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Dim dtmprop As DataTable = EjecutarConsultaDataTable()
            '------------------------------------------------------COMPARAR LAS DOS DATATABLE PARA ENCONTRAR POSIBLES MODIFICACIONES-------------------------------------------------------------------------------------------------------------------
            Dim sqlUdpProp As String = "UPDATE GPPROPONENTES SET "
            Dim PKProp As String
            If dtmprop.Rows.Count <> 0 Then
                For n As Integer = 0 To dtmprop.Rows.Count - 1
                    PKProp = dtprop.Rows(n)("Ide_Prop").ToString
                    For m As Integer = 0 To dtprop.Columns.Count - 1
                        If dtmprop.Rows(n).Item(m).ToString <> dtprop.Rows(n).Item(m).ToString And dtmprop.Columns(m).ColumnName <> "FEC_MOD" Then
                            sqlUdpProp += dtmprop.Columns(m).ColumnName & "=''" & dtmprop.Rows(n).Item(m).ToString & "'',"
                        End If
                    Next
                    Dim p As Integer = sqlUdpProp.Length - 1
                    Dim sqlu1 As String = sqlUdpProp.Remove(p, 1)
                    sqlUdpProp = sqlu1 & " Where Num_Proc=''" & Num_Proc & "'' And Ide_Prop=''" & PKProp & "''"
                    Me.querystring = "UPDATE MOD_PROPONENTES SET SQL_UPDATE='" & sqlUdpProp & "' WHERE NUM_SOL_ADI=" & Num_Sol_Adi & " And Ide_Prop=" & PKProp
                    CrearComando(querystring)
                    EjecutarComando()
                Next
            End If
            'Throw New Exception(Me.querystring)
            Me.ConfirmarTransaccion()
            Me.Msg = "La validación se realizo con exito. Puede Radicar la Modificacion."
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Function Radicar(ByVal Num_Sol_Adi As String, ByVal Fec_Sus_Adi As Date) As String
        Dim vig As New Vigencias
        Dim Cod_Con As String
        Me.Conectar()
        vig.Conexion = Me.Conexion
        Dim Vigencia As String = vig.GetVigenciaA()
        Me.querystring = "select * from mod_contratos where Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Cod_Con = dt.Rows(0)("Cod_Con").ToString
        ComenzarTransaccion()
        Try
            Me.querystring = dt.Rows(0)("SQL_UPDATE").ToString.Replace("|", "'")
            Me.CrearComando(querystring)
            EjecutarComando()
            If dt.Rows(0)("Tip_Adi").ToString = 1 Then
                Me.querystring = "INSERT INTO ADICIONES(NRO_ADI, FEC_SUS_ADI, PLA_EJE_ADI, VIG_ADI, VAL_ADI, COD_CON, TIPO_PLAZO1_ADI, PLAZO2_ADI, TIPO_PLAZO2_ADI, VAL_APO_GOB_ADI, VAL_SIN_IVA_ADI)VALUES(:NRO_ADI, :FEC_SUS_ADI, :PLA_EJE_ADI, :VIG_ADI, :VAL_ADI, :COD_CON, :TIPO_PLAZO1_ADI, :PLAZO2_ADI, :TIPO_PLAZO2_ADI, :VAL_APO_GOB_ADI, :VAL_SIN_IVA_ADI)"
                AsignarParametroCadena(":NRO_ADI", Cod_Con & "-" & Num_Sol_Adi.PadLeft(2, "0"))
                AsignarParametroFecha(":FEC_SUS_ADI", Fec_Sus_Adi)
                AsignarParametroEntero(":PLA_EJE_ADI", CInt(dt.Rows(0)("Plazo1_Adi").ToString))
                AsignarParametroCadena(":VIG_ADI", Vigencia)
                AsignarParametroDecimal(":VAL_ADI", dt.Rows(0)("Val_Con_Adi").ToString)
                AsignarParametroCadena(":COD_CON", Cod_Con)
                AsignarParametroCadena(":TIPO_PLAZO1_ADI", dt.Rows(0)("TIPO_PLAZO1_ADI").ToString)
                AsignarParametroEntero(":PLAZO2_ADI", dt.Rows(0)("PLAZO2_ADI").ToString)
                AsignarParametroCadena(":TIPO_PLAZO2_ADI", dt.Rows(0)("TIPO_PLAZO2_ADI").ToString)
                AsignarParametroDecimal(":VAL_APO_GOB_ADI", dt.Rows(0)("VAL_APO_GOB_ADI").ToString)
                AsignarParametroDecimal(":VAL_SIN_IVA_ADI", dt.Rows(0)("VAL_SIN_IVA_ADI").ToString)
                EjecutarComando()
            End If
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function AdicionarValPlazo(ByVal Num_Sol_Adi As String, ByVal Tip_Adi As String, ByVal PLA_EJE_CON As Integer, ByVal TPlazo As String, ByVal VAL_CON As Decimal, ByVal VAL_APO_GOB As Decimal, ByVal val_sin_iva As Decimal, ByVal Plazo2 As Integer, ByVal tip_plazo2 As String) As String
        Me.Conectar()
        Try
            If Tip_Adi = 1 Then
                If TPlazo = "D" Then
                    Me.ComenzarTransaccion()
                    Me.querystring = "UPDATE MOD_CONTRATOS SET PLAZO1_ADI=:PLAZO1_ADI, TIPO_PLAZO1_ADI=:TIPO_PLAZO1_ADI, VAL_CON_ADI=:VAL_CON_ADI, VAL_APO_GOB_ADI=:VAL_APO_GOB_ADI, VAL_SIN_IVA_ADI=:VAL_SIN_IVA_ADI WHERE NUM_SOL_ADI=:NUM_SOL_ADI"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroEntero(":PLAZO1_ADI", CInt(PLA_EJE_CON))
                    Me.AsignarParametroDecimal(":VAL_APO_GOB_ADI", VAL_APO_GOB)
                    Me.AsignarParametroCadena(":NUM_SOL_ADI", Num_Sol_Adi)
                    Me.AsignarParametroCadena(":TIPO_PLAZO1_ADI", TPlazo)
                    Me.AsignarParametroDecimal(":VAL_SIN_IVA_ADI", val_sin_iva)
                    Me.AsignarParametroDecimal(":VAL_CON_ADI", VAL_CON)
                    ' Throw New Exception(vComando.CommandText)
                    Me.num_reg = EjecutarComando()
                    Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                Else
                    Me.ComenzarTransaccion()
                    Me.querystring = "UPDATE MOD_CONTRATOS SET PLAZO1_ADI=:PLAZO1_ADI, TIPO_PLAZO1_ADI=:TIPO_PLAZO1_ADI, PLAZO2_ADI=:PLAZO2_ADI, TIPO_PLAZO2_ADI=:TIPO_PLAZO2_ADI, VAL_CON_ADI=:VAL_CON_ADI, VAL_APO_GOB_ADI=:VAL_APO_GOB_ADI, VAL_SIN_IVA_ADI=:VAL_SIN_IVA_ADI WHERE NUM_SOL_ADI=:NUM_SOL_ADI"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroEntero(":PLAZO1_ADI", CInt(PLA_EJE_CON))
                    Me.AsignarParametroDecimal(":VAL_APO_GOB_ADI", VAL_APO_GOB)
                    Me.AsignarParametroCadena(":NUM_SOL_ADI", Num_Sol_Adi)
                    Me.AsignarParametroCadena(":TIPO_PLAZO1_ADI", TPlazo)
                    Me.AsignarParametroDecimal(":VAL_SIN_IVA_ADI", val_sin_iva)
                    Me.AsignarParametroEntero(":PLAZO2_ADI", CInt(Plazo2))
                    Me.AsignarParametroCadena(":TIPO_PLAZO2_ADI", tip_plazo2)
                    AsignarParametroDecimal(":VAL_CON_ADI", VAL_CON)
                    ' Throw New Exception(vComando.CommandText)
                    Me.num_reg = EjecutarComando()
                    Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                End If
            ElseIf Tip_Adi = 2 Then
                Me.ComenzarTransaccion()
                Me.querystring = "UPDATE MOD_CONTRATOS SET VAL_CON_ADI=:VAL_CON_ADI, VAL_APO_GOB_ADI=:VAL_APO_GOB_ADI, VAL_SIN_IVA_ADI=:VAL_SIN_IVA_ADI WHERE NUM_SOL_ADI=:NUM_SOL_ADI"
                Me.CrearComando(querystring)
                Me.AsignarParametroDecimal(":VAL_APO_GOB_ADI", VAL_APO_GOB)
                Me.AsignarParametroCadena(":NUM_SOL_ADI", Num_Sol_Adi)
                Me.AsignarParametroDecimal(":VAL_SIN_IVA_ADI", val_sin_iva)
                AsignarParametroDecimal(":VAL_CON_ADI", VAL_CON)
                'Throw New Exception(vComando.CommandText)
                Me.num_reg = EjecutarComando()
                Me.ConfirmarTransaccion()
                Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                Me.lErrorG = False
            Else
                If TPlazo = "D" Then
                    Me.ComenzarTransaccion()
                    Me.querystring = "UPDATE MOD_CONTRATOS SET PLAZO1_ADI=:PLAZO1_ADI, TIPO_PLAZO1_ADI=:TIPO_PLAZO1_ADI WHERE NUM_SOL_ADI=:NUM_SOL_ADI"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroEntero(":PLAZO1_ADI", CInt(PLA_EJE_CON))
                    Me.AsignarParametroCadena(":NUM_SOL_ADI", Num_Sol_Adi)
                    Me.AsignarParametroCadena(":TIPO_PLAZO1_ADI", TPlazo)
                    'Throw New Exception(vComando.CommandText)
                    Me.num_reg = EjecutarComando()
                    Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                Else
                    Me.ComenzarTransaccion()
                    Me.querystring = "UPDATE MOD_CONTRATOS SET PLAZO1_ADI=:PLAZO1_ADI, TIPO_PLAZO1_ADI=:TIPO_PLAZO1_ADI, PLAZO2_ADI=:PLAZO2_ADI, TIPO_PLAZO2_ADI=:TIPO_PLAZO2_ADI WHERE NUM_SOL_ADI=:NUM_SOL_ADI"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroEntero(":PLAZO1_ADI", CInt(PLA_EJE_CON))
                    Me.AsignarParametroCadena(":NUM_SOL_ADI", Num_Sol_Adi)
                    Me.AsignarParametroCadena(":TIPO_PLAZO1_ADI", TPlazo)
                    Me.AsignarParametroEntero(":PLAZO2_ADI", CInt(Plazo2))
                    Me.AsignarParametroCadena(":TIPO_PLAZO2_ADI", tip_plazo2)
                    'Throw New Exception(vComando.CommandText)
                    Me.num_reg = EjecutarComando()
                    Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                End If
            End If
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Me.Msg
    End Function
#Region "Modificacion de Pagos..."
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMod_FP(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * from VMOD_CFORMA_PAGOMIN Where Num_Sol_Adi=:Num_Sol_Adi"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
    Public Function Tras_FP(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String, ByVal Crear As String) As String
        Me.Conectar()
        Me.querystring = "TRASLADAR_MOD_FP"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim PReturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("Cod_Con", Cod_Con)
        AsignarParametroCad("Num_Sol_Adi", Num_Sol_Adi)
        AsignarParametroCad("Crear", Crear)
        EjecutarComando()
        If PReturn.Value.ToString = "1" Then
            Return "Puede modificar la forma de pago"
        ElseIf PReturn.Value.ToString = "2" Then
            Return "La forma de pago no será modificada"
        Else
            Return "Se produjo error..." & PReturn.Value.ToString
        End If
    End Function
    Public Function InsertPago(ByVal Num_Sol_Adi As String, ByVal Fec_Pago As Date, ByVal Tipo_pago As String, ByVal Val_Pago As Decimal, ByVal Condicion_Pago As String, ByVal CalPorcentaje As Boolean, ByVal Cod_Con As String, ByVal PagaGober As String) As String
        Dim val_pa As Decimal
        Dim porcentaje As Decimal
        Me.Conectar()
        Me.ComenzarTransaccion()
        Dim Val_Tot_Con As Decimal = Me.ValordelContrato(Num_Sol_Adi, Cod_Con)
        Dim Val_Apo_Prop As Decimal = Me.ValorApoProp(Num_Sol_Adi, Cod_Con)
        Dim Val_FormaPago = Valor_Programado(Num_Sol_Adi)
        Me.Valor_Restante = Val_Apo_Prop - Val_FormaPago

        If CalPorcentaje Then
            porcentaje = CDec(Val_Pago) / 100
            val_pa = Val_Tot_Con * porcentaje
            porcentaje = Math.Round(porcentaje, 4)
        Else
            val_pa = Val_Pago
            porcentaje = ((val_pa) / (Val_Tot_Con))
            porcentaje = Math.Round(porcentaje, 4)
        End If
        Try
            If Me.Valor_Restante < CDbl(val_pa) And PagaGober = "1" Then
                Throw New Exception("El valor del Pago no puede ser superior al restante del valor del contrato (" & FormatCurrency(Me.Valor_Restante) & ")")
            ElseIf Me.Valor_Restante = 0 And PagaGober = "1" Then
                Throw New Exception("Los pagos han cubierto la totalidad del contrato")
            Else
                querystring = "INSERT INTO MOD_CFORMA_PAGO(Num_Sol_Adi, Fecha_Pago, Tipo_pago, Valor_Pago, Porcentaje, Condicion_Pago, Cod_Con, Paga_Gober)VALUES(:Num_Sol_Adi, to_date(:Fec_Pago, 'dd/mm/yyyy'), :Tipo_pago, :Val_Pago, :Porcentaje, :Condicion_Pago, :Cod_Con, :Paga_Gober) "
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
                Me.AsignarParametroCadena(":Fec_Pago", Fec_Pago.ToShortDateString)
                Me.AsignarParametroCadena(":Tipo_pago", Tipo_pago)
                Me.AsignarParametroDecimal(":Val_Pago", val_pa)
                Me.AsignarParametroDecimal(":Porcentaje", porcentaje)
                Me.AsignarParametroCadena(":Condicion_Pago", Condicion_Pago)
                Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
                Me.AsignarParametroCadena(":Paga_Gober", PagaGober)
                'Throw New Exception(vComando.CommandText)
                Me.num_reg = Me.EjecutarComando()
                Me.ConfirmarTransaccion()
                Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                Me.lErrorG = False
            End If
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Private Function Valor_Programado(ByVal Num_Sol_Adi As String) As Decimal
        querystring = "SELECT NVL(SUM(VALOR_PAGO),0) Valor_Prog FROM mod_cforma_pago WHERE Num_Sol_Adi=:Num_Sol_Adi and Paga_Gober='1'"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Return CDec(dt.Rows(0)("Valor_Prog"))
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function ValordelContrato(ByVal Num_Sol_Adi As String, ByVal Cod_Con As String) As Decimal
        querystring = "SELECT (VAL_CON + VAL_CON_ADI) FROM MOD_CONTRATOS where Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        querystring = "select nvl(sum(val_adi),0) Val_Adicion from adiciones where cod_con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Return CDec(dataTb.Rows(0).Item(0)) + CDec(dt.Rows(0).Item(0))
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function ValordelContrato1(ByVal Num_Sol_Adi As String, ByVal Cod_Con As String) As Decimal
        Me.Conectar()
        querystring = "SELECT (VAL_CON + VAL_CON_ADI) FROM MOD_CONTRATOS where Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        querystring = "select nvl(sum(val_adi),0) Val_Adicion from adiciones where cod_con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return CDec(dataTb.Rows(0).Item(0)) + CDec(dt.Rows(0).Item(0))
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function ValorApoProp(ByVal Num_Sol_Adi As String, ByVal Cod_Con As String) As Decimal
        'Me.Conectar()
        querystring = "SELECT (VAL_APO_GOB + VAL_APO_GOB_ADI) FROM MOD_CONTRATOS where Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        querystring = "select nvl(sum(val_apo_gob_adi),0) From adiciones where cod_con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dt As DataTable = Me.EjecutarConsultaDataTable()
        Return CDec(dataTb.Rows(0).Item(0)) + CDec(dt.Rows(0).Item(0))
    End Function
    Public Function UpdatePago(ByVal Id_Pago As String, ByVal Num_Sol_Adi As String, ByVal Fec_Pago As Date, ByVal Tipo_pago As String, ByVal Val_Pago As Decimal, ByVal Condicion_Pago As String, ByVal CalPorcentaje As Boolean, ByVal Cod_Con As String, ByVal PagaGober As String) As String
        Dim dt As New DataTable
        Dim val_pa As Decimal
        Dim porcentaje As Decimal
        Me.Conectar()
        Me.ComenzarTransaccion()
        Try
            Delete_D(Id_Pago, Num_Sol_Adi)
            Dim Val_Apo_Prop As Decimal = Me.ValorApoProp(Num_Sol_Adi, Cod_Con)
            Dim Val_Tot_Con As Decimal = Me.ValordelContrato(Num_Sol_Adi, Cod_Con)
            Dim Val_FormaPago = Valor_Programado(Num_Sol_Adi)
            Me.Valor_Restante = Val_Apo_Prop - Val_FormaPago

            If CalPorcentaje Then
                porcentaje = Val_Pago / 100
                val_pa = Val_Tot_Con * porcentaje
                porcentaje = Math.Round(porcentaje, 4)
            Else
                val_pa = Val_Pago
                porcentaje = ((val_pa) / (Val_Tot_Con))
                porcentaje = Math.Round(porcentaje, 4)
            End If

            If Me.Valor_Restante < CDbl(val_pa) And PagaGober = "1" Then
                Throw New Exception("El valor del Pago no puede ser superior al restante del valor del contrato (" & FormatCurrency(Me.Valor_Restante) & ")")
            ElseIf Me.Valor_Restante = 0 And PagaGober = "1" Then
                Throw New Exception("Los pagos han cubierto la totalidad del contrato")
            Else
                querystring = "INSERT INTO MOD_CFORMA_PAGO(Num_Sol_Adi, Fecha_Pago, Tipo_pago, Valor_Pago, Porcentaje, Condicion_Pago, Cod_Con)VALUES(:Num_Sol_Adi, to_date(:Fec_Pago, 'dd/mm/yyyy'), :Tipo_pago, :Val_Pago, :Porcentaje, :Condicion_Pago, :Cod_Con) "
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
                Me.AsignarParametroCadena(":Fec_Pago", Fec_Pago.ToShortDateString)
                Me.AsignarParametroCadena(":Tipo_pago", Tipo_pago)
                Me.AsignarParametroDecimal(":Val_Pago", val_pa)
                Me.AsignarParametroDecimal(":Porcentaje", porcentaje)
                Me.AsignarParametroCadena(":Condicion_Pago", Condicion_Pago)
                Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
                'Throw New Exception(vComando.CommandText)
                Me.num_reg = Me.EjecutarComando()
                Me.ConfirmarTransaccion()
                Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                Me.lErrorG = False
            End If
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Private Function Delete_D(ByVal Id As String, ByVal Num_Sol_Adi As String) As String
        querystring = "DELETE FROM MOD_CFORMA_PAGO WHERE Num_Sol_Adi=:Num_Sol_Adi AND Id=:Id"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Id", Id)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Me.num_reg = Me.EjecutarComando()
        Return Msg
    End Function
    Public Function DeletePago(ByVal Id As String, ByVal Num_Sol_Adi As String) As String
        Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM MOD_CFORMA_PAGO WHERE Num_Sol_Adi=:Num_Sol_Adi AND Id=:Id"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Id", Id)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function GetPagobyPk(ByVal Id As String, ByVal Num_Sol_Adi As String) As DataTable
        Conectar()
        querystring = "SELECT * FROM MOD_CFORMA_PAGO WHERE Num_Sol_Adi=:Num_Sol_Adi AND Id=:Id"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Id", Id)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
#End Region

#Region "Modificacion de Obligaciones"
    Public Function Tras_Oblig(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String, ByVal Crear As String) As String
        Me.Conectar()
        Me.querystring = "TRASLADAR_MOD_OBLIG"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim PReturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("Cod_Con", Cod_Con)
        AsignarParametroCad("Num_Sol_Adi", Num_Sol_Adi)
        AsignarParametroCad("Crear", Crear)
        EjecutarComando()
        Return PReturn.Value.ToString
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMod_Oblig(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * from mod_cobligaciones Where Num_Sol_Adi=:Num_Sol_Adi"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function

    Public Function InsertObligaciones(ByVal Num_Sol_Adi As String, ByVal Des_Oblig As String, ByVal Cod_Con As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO MOD_COBLIGACIONES(Num_Sol_Adi, Des_Oblig, Cod_Con)VALUES(:Num_Sol_Adi, :Des_Oblig, :Cod_Con) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCLOB(":Des_Oblig", Des_Oblig)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.num_reg = Me.EjecutarComando()

            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try

        Return Msg
    End Function

    Public Function DeleteObligaciones(ByVal Ide_Oblig As String, ByVal Num_Sol_Adi As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM MOD_COBLIGACIONES WHERE Num_Sol_Adi=:Num_Sol_Adi AND Ide_Oblig =:Ide_Oblig"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Ide_Oblig", Ide_Oblig)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Function UpdateObligaciones(ByVal Num_Sol_Adi As String, ByVal Des_Oblig As String, ByVal Ide_Oblig As Integer) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = " UPDATE MOD_COBLIGACIONES SET Des_Oblig=:Des_Oblig WHERE Num_Sol_Adi=:Num_Sol_Adi AND Ide_Oblig =:Ide_Oblig"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Des_Oblig", Des_Oblig)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Ide_Oblig", Ide_Oblig)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            'Me.Msg = Me._Comando.CommandText
            Me.Desconectar()
        End Try
        Return Msg
    End Function
#End Region

#Region "Modificacion de Proyectos"
    Public Function Tras_Cproy(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String, ByVal Crear As String) As String
        Me.Conectar()
        Me.querystring = "TRASLADAR_MOD_CPROYECTOS"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim PReturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("Cod_Con", Cod_Con)
        AsignarParametroCad("Num_Sol_Adi", Num_Sol_Adi)
        AsignarParametroCad("Crear", Crear)
        EjecutarComando()
        Return PReturn.Value.ToString
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMod_CProyectos(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * from vmod_CProyectos Where Num_Sol_Adi=:Num_Sol_Adi"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetProyectosbyPk(ByVal Proyecto As String, ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vmod_cproyectos Where Proyecto=:Proyecto And Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Proyecto", Proyecto)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function InsertProy(ByVal Proyecto As String, ByVal Num_Sol_Adi As String, ByVal Cod_Con As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO mod_cproyectos(Num_Sol_Adi, Proyecto, Cod_Con)VALUES(:Num_Sol_Adi, :Proyecto, :Cod_Con) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Proyecto", Proyecto)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function DeleteProy(ByVal Proyecto As String, ByVal Num_Sol_Adi As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM mod_cproyectos WHERE Num_Sol_Adi=:Num_Sol_Adi AND Proyecto=:Proyecto"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Proyecto", Proyecto)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
#End Region

#Region "CDP..."
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMod_CDP(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * from mod_CDP_Contratos Where Num_Sol_Adi=:Num_Sol_Adi"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCDPbyPk(ByVal Num_Sol_Adi As String, ByVal Nro_Cdp As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM mod_cdp_contratos Where Num_Sol_Adi=:Num_Sol_Adi And Nro_Cdp=:Nro_Cdp"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Me.AsignarParametroCadena(":Nro_Cdp", Nro_Cdp)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsCDP(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM mod_cdp_contratos Where Num_Sol_Adi=:Num_Sol_Adi"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function InsertCDP(ByVal Num_Sol_Adi As String, ByVal Nro_Cdp As String, ByVal Fec_Cdp As Date, ByVal val_cdp As Decimal, ByVal Cod_Con As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO mod_cdp_contratos(Num_Sol_Adi, Nro_Cdp,FEC_CDP,VAL_CDP, Cod_Con)VALUES(:Num_Sol_Adi, :Nro_Cdp,:FEC_CDP,:VAL_CDP, :Cod_Con) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroEntero(":Nro_Cdp", Nro_Cdp)
            Me.AsignarParametroFecha(":FEC_CDP", Fec_Cdp)
            Me.AsignarParametroDecimal(":VAL_CDP", val_cdp)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.num_reg = Me.EjecutarComando()
            'SincronizarValor(Num_Pcon, Nro_Cdp, Grupo)
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Sub SincronizarValor(ByVal Num_Sol_Adi As String, ByVal Nro_Cdp As String)
        querystring = "Update mod_cdp_contratos c Set Val_Cdp =(Select Nvl(Sum(Valor),0) From Rubros_RContratos Where Num_Sol_Adi=c.Num_Sol_Adi And Nro_Cdp=c.Nro_Cdp) Where c.Num_Sol_Adi=:Num_Sol_Adi And c.Nro_Cdp =:Nro_Cdp"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Me.AsignarParametroEntero(":Nro_Cdp", Nro_Cdp)
        Me.num_reg = Me.EjecutarComando()
    End Sub

    Public Function DeleteCDP(ByVal Nro_Cdp As String, ByVal Num_Sol_Adi As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM mod_cdp_contratos WHERE Num_Sol_Adi=:Num_Sol_Adi AND Nro_Cdp=:Nro_Cdp"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Nro_Cdp", Nro_Cdp)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Tras_CDP(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String, ByVal Crear As String) As String
        Me.Conectar()
        Me.querystring = "TRASLADAR_MOD_CDP_CONTRATOS"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim PReturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("Cod_Con", Cod_Con)
        AsignarParametroCad("Num_Sol_Adi", Num_Sol_Adi)
        AsignarParametroCad("Crear", Crear)
        EjecutarComando()
        Return PReturn.Value.ToString
    End Function
#End Region

#Region "Rubros"
    Public Function InsertRubro(ByVal Cod_Rub As String, ByVal Num_Sol_Adi As String, ByVal Valor As String, ByVal Nro_RP As String, ByVal Cod_Con As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO MOD_RUBROS_CONTRATOS(Cod_Rub, Num_Sol_Adi, Valor, Nro_Cdp, Cod_Con)VALUES(:Cod_Rub, :Num_Sol_Adi, :Valor, :Nro_Cdp, :Cod_Con) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Rub", Cod_Rub)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Valor", Valor)
            Me.AsignarParametroCadena(":Nro_Cdp", Nro_RP)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function DeleteRubro(ByVal Cod_Rub As String, ByVal Num_Sol_Adi As String) As String
        Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM MOD_RUBROS_CONTRATOS WHERE Num_Sol_Adi=:Num_Sol_Adi AND Cod_Rub=:Cod_Rub"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Rub", Cod_Rub)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Tras_Rubros(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String, ByVal Crear As String) As String
        Me.Conectar()
        Me.querystring = "TRASLADAR_MOD_RC"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim PReturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("Cod_Con", Cod_Con)
        AsignarParametroCad("Num_Sol_Adi", Num_Sol_Adi)
        AsignarParametroCad("Crear", Crear)
        EjecutarComando()
        Return PReturn.Value.ToString
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMod_RC(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * from VMOD_RUBROS_CONTRATOS Where Num_Sol_Adi=:Num_Sol_Adi"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
#End Region

#Region "Polizas..."
    Public Function Tras_Polizas(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String, ByVal Crear As String) As String
        Me.Conectar()
        Me.querystring = "TRASLADAR_MOD_POL"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim PReturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("Cod_Con", Cod_Con)
        AsignarParametroCad("Num_Sol_Adi", Num_Sol_Adi)
        AsignarParametroCad("Crear", Crear)
        EjecutarComando()
        Return PReturn.Value.ToString
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMod_Pol(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * from VMOD_CON_POLIZAS Where Num_Sol_Adi=:Num_Sol_Adi"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPolbyPK(ByVal Num_Proc As String, ByVal Cod_Pol As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VGPPolizas Where Num_Proc=:Num_Proc and Cod_Pol=:Cod_Pol and Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function InsertPol(ByVal Cod_Pol As String, ByVal Num_Sol_Adi As String, ByVal por_SMMLV As String, ByVal Cal_Apartirde As String, ByVal Vigencia As String, ByVal Apartirde As String, ByVal Tipo As String, ByVal Cod_Con As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Mod_Con_Polizas(Num_Sol_Adi, Cod_Pol, por_SMMLV, Cal_Apartirde, Vigencia, Apartirde, Tipo, Cod_Con)VALUES(:Num_Sol_Adi, :Cod_Pol, :por_SMMLV, :Cal_Apartirde, :Vigencia, :Apartirde,:Tipo, :Cod_Con)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
            Me.AsignarParametroCadena(":por_SMMLV", por_SMMLV)
            Me.AsignarParametroCadena(":Cal_Apartirde", Cal_Apartirde)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
            Me.AsignarParametroCadena(":Apartirde", Apartirde)
            Me.AsignarParametroCadena(":Tipo", Tipo)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            'Throw New Exception(_Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function DeletePol(ByVal Cod_Pol As String, ByVal Num_Sol_Adi As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Mod_Con_Polizas WHERE Num_Sol_Adi=:Num_Sol_Adi AND Cod_Pol=:Cod_Pol"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Sub Mod_Radicar(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String, ByVal Fec_Sus As Date, ByVal obser As String)
        Me.Conectar()
        Me.querystring = "MOD_RADICACION"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(1000)
        AsignarParametroCad("Cod_Contrato", Cod_Con)
        AsignarParametroCad("Num_Adicion", Num_Sol_Adi)
        AsignarParametroCad("Fec_Rad", Fec_Sus.ToShortDateString)
        AsignarParametroCad("Observacion", obser)
        EjecutarComando()
        Me.ResPRad = preturn.Value.ToString().Replace(Publico.NoPunto_Dec, Publico.Punto_Dec)
        Me.Desconectar()
    End Sub
    Public Function Restante(ByVal Cod_Con As String, ByVal Vigencia As String) As String
        Me.Conectar()
        Me.querystring = "MAXVALADI"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(100)
        AsignarParametroCad("Cod_Contrato", Cod_Con)
        AsignarParametroCad("Vigencia", Vigencia)
        EjecutarComando()
        Me.Desconectar()
        Return preturn.Value.ToString.Replace(",", ".")
    End Function
    Public Function Revertir(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "Delete From MIN_MOD_CONTRATO Where Num_Sol_Adi=:Num_Sol_Adi"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            'Throw New Exception(Me._Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            querystring = "Update Mod_Contratos Set Mod_Estado='TR' Where Cod_Con=:Cod_Con and Num_Sol_Adi=:Num_Sol_Adi"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            lErrorG = True
        End Try
        Me.Desconectar()
        Return Me.Msg
    End Function
    Public Function Anular(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "Delete From MIN_MOD_CONTRATO Where Num_Sol_Adi=:Num_Sol_Adi"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            'Throw New Exception(Me._Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            querystring = "Update Mod_Contratos Set Mod_Estado='AN' Where Cod_Con=:Cod_Con and Num_Sol_Adi=:Num_Sol_Adi"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            lErrorG = True
        End Try
        Me.Desconectar()
        Return Me.Msg
    End Function
#End Region

#Region "Contratista..."
    Public Function Tras_Proponentes(ByVal Cod_Con As String, ByVal Num_Sol_Adi As String, ByVal Crear As String) As String
        Me.Conectar()
        Me.querystring = "TRASLADAR_CONTRATISTAS"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim PReturn As DbParameter = AsignarParametroReturn(2000)
        AsignarParametroCad("Cod_Con", Cod_Con)
        AsignarParametroCad("Num_Sol_Adi", Num_Sol_Adi)
        AsignarParametroCad("Crear", Crear)
        EjecutarComando()
        Return PReturn.Value.ToString
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMod_Prop(ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * from VMOD_PROPONENTES Where Num_Sol_Adi=:Num_Sol_Adi"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        'Throw New Exception(vComando.CommandText)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPropbyPK(ByVal Nit As String, ByVal Num_Sol_Adi As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * from VMOD_PROPONENTES Where Num_Sol_Adi=:Num_Sol_Adi And Ide_Prop=:Ide_Prop"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
        AsignarParametroCadena(":Ide_Prop", Nit)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
    Public Function InsertProp(ByVal Cod_Pol As String, ByVal Num_Sol_Adi As String, ByVal por_SMMLV As String, ByVal Cal_Apartirde As String, ByVal Vigencia As String, ByVal Apartirde As String, ByVal Tipo As String, ByVal Cod_Con As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Mod_Con_Polizas(Num_Sol_Adi, Cod_Pol, por_SMMLV, Cal_Apartirde, Vigencia, Apartirde, Tipo, Cod_Con)VALUES(:Num_Sol_Adi, :Cod_Pol, :por_SMMLV, :Cal_Apartirde, :Vigencia, :Apartirde,:Tipo, :Cod_Con)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
            Me.AsignarParametroCadena(":por_SMMLV", por_SMMLV)
            Me.AsignarParametroCadena(":Cal_Apartirde", Cal_Apartirde)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
            Me.AsignarParametroCadena(":Apartirde", Apartirde)
            Me.AsignarParametroCadena(":Tipo", Tipo)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            'Throw New Exception(_Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function DeleteProp(ByVal Cod_Pol As String, ByVal Num_Sol_Adi As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Mod_Con_Polizas WHERE Num_Sol_Adi=:Num_Sol_Adi AND Cod_Pol=:Cod_Pol"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function UpdateProp(ByVal Ide_Prop_PK As String, ByVal Ide_Prop As String, ByVal Num_Sol_Adi As String, ByVal fec_prop As Date, ByVal val_prop As Decimal, _
                            ByVal Ape1_Prop As String, ByVal Dir_Prop As String, ByVal Tel_Prop As String, ByVal Email_Prop As String, ByVal Ape2_Prop As String, ByVal Nom1_Prop As String, _
                             ByVal Nom2_Prop As String, ByVal Razon_Social As String, ByVal Tip_Ide As String, ByVal Exp_Ide As String, ByVal Estado As String, ByVal Observacion As String, ByVal Num_Folio As Integer, ByVal dver As String, ByVal id_rep_leg As String, ByVal nom_rep_leg As String, ByVal Municipio As String, ByVal Denominacion As String, ByVal Aportes As String, _
                             ByVal Num_Poliza As String, ByVal Fecha_inicial As String, ByVal Fecha_Final As String, ByVal Aseguradora As String, ByVal Valor_Poliza As Decimal) As String
        Me.Conectar()
        Try
            'Me.ComenzarTransaccion()
            querystring = "UPDATE Mod_Proponentes SET Ide_Prop=:Ide_Prop, fec_Prop=:fec_Prop, Val_Prop=:Val_Prop, Ape1_Prop=:Ape1_Prop, Dir_Prop=:Dir_Prop, Tel_Prop=:Tel_Prop, Email_Prop=:Email_Prop," & _
            " Ape2_Prop=:Ape2_Prop, Id_Rep_Legal=:Id_Rep_Leg, Nom_Rep_Legal=:Nom_Rep_Leg, Municipio=:Municipio, Nom1_Prop=:Nom1_Prop, Nom2_Prop=:Nom2_Prop, Tip_Ide=:Tip_Ide, Exp_Ide=:Exp_Ide, Razon_Social=:Razon_Social, Estado=:Estado, Observacion=:Observacion, Num_Folio=:Num_Folio, dv_ter=:dv_ter,Denominacion=:Denominacion, Aportes=:Aportes, NumPoliza=:Num_Poliza, Fecha_Inicial=:Fecha_Inicial, Fecha_Final=:Fecha_Final, Aseguradora=:Aseguradora, Valor_Poliza=:Valor_Poliza WHERE Num_Sol_Adi=:Num_Sol_Adi AND IDE_PROP=:Ide_Prop_PK"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Sol_Adi", Num_Sol_Adi)
            Me.AsignarParametroCadena(":Ide_Prop", Ide_Prop)
            Me.AsignarParametroFecha(":fec_Prop", fec_prop)
            Me.AsignarParametroDecimal(":Val_Prop", val_prop)
            Me.AsignarParametroCadena(":Ape1_Prop", Ape1_Prop)
            Me.AsignarParametroCadena(":Dir_Prop", Dir_Prop)
            Me.AsignarParametroCadena(":Tel_Prop", Tel_Prop)
            Me.AsignarParametroCadena(":Email_Prop", Email_Prop)
            Me.AsignarParametroCadena(":Ape2_Prop", Ape2_Prop)
            Me.AsignarParametroCadena(":Nom1_Prop", Nom1_Prop)
            Me.AsignarParametroCadena(":Nom2_Prop", Nom2_Prop)
            Me.AsignarParametroCadena(":Tip_Ide", Tip_Ide)
            Me.AsignarParametroCadena(":Exp_Ide", Exp_Ide)
            Me.AsignarParametroCadena(":Razon_Social", Razon_Social)
            Me.AsignarParametroCadena(":Estado", Estado)
            Me.AsignarParametroCadena(":Observacion", Observacion)
            Me.AsignarParametroInt(":Num_Folio", Num_Folio)
            Me.AsignarParametroCadena(":Ide_Prop_PK", Ide_Prop_PK)
            dver = IIf(Tip_Ide = "NI", Util.ValidarDigitoVerificacion(Ide_Prop), "")
            Me.AsignarParametroCadena(":dv_ter", dver)
            Me.AsignarParametroCadena(":Id_Rep_Leg", id_rep_leg)
            Me.AsignarParametroCadena(":Nom_Rep_Leg", nom_rep_leg)
            Me.AsignarParametroCadena(":Municipio", Municipio)
            Me.AsignarParametroCadena(":Denominacion", Denominacion)
            Me.AsignarParametroCLOB(":Aportes", Aportes)
            If Num_Poliza = "" Then
                Me.AsignarParametroNulo(":Num_Poliza")
            Else
                Me.AsignarParametroCadena(":Num_Poliza", Num_Poliza)
            End If
            If Fecha_inicial = "" Then
                Me.AsignarParametroNulo(":Fecha_Inicial")
            Else
                Me.AsignarParametroFecha(":Fecha_Inicial", CDate(Fecha_inicial).ToShortDateString)
            End If
            If Fecha_Final = "" Then
                Me.AsignarParametroNulo(":Fecha_Final")
            Else
                Me.AsignarParametroFecha(":Fecha_Final", CDate(Fecha_Final).ToShortDateString)
            End If
            If Aseguradora = "" Then
                Me.AsignarParametroNulo(":Aseguradora")
            Else
                Me.AsignarParametroCadena(":Aseguradora", Aseguradora)
            End If
            If Valor_Poliza = 0 Then
                Me.AsignarParametroNulo(":Valor_Poliza")
            Else
                Me.AsignarParametroDecimal(":Valor_Poliza", Valor_Poliza)
            End If
            'Throw New Exception(Me._Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            'Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            'Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
#End Region
End Class
