Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
''' <summary>
''' RESPONSABLE: ERIC YOVANNY MARTINEZ GONZALEZ
''' FECHA: 08 DE ABRIL DE 2011
''' </summary>
''' <remarks></remarks>
<System.ComponentModel.DataObject()> _
Public Class GProcesos
    Inherits BDDatos
    Private _Valor_Restante As String
    Property Valor_Restante() As Double
        Get
            Return _Valor_Restante
        End Get
        Set(ByVal value As Double)
            _Valor_Restante = value
        End Set
    End Property
    Private _Num_PCon As String
    Property Num_PCon() As String
        Get
            Return _Num_PCon
        End Get
        Set(ByVal value As String)
            _Num_PCon = value
        End Set
    End Property
    Private _Nro_Con As Integer
    Property Nro_Con() As Integer
        Get
            Return _Nro_Con
        End Get
        Set(ByVal value As Integer)
            _Nro_Con = value
        End Set
    End Property

    Private _dtOblig As DataTable
    Property dtOblig() As DataTable
        Get
            Return _dtOblig
        End Get
        Set(ByVal value As DataTable)
            _dtOblig = value
        End Set
    End Property
    Private _dtCDP As DataTable
    Property dtCDP() As DataTable
        Get
            Return _dtCDP
        End Get
        Set(ByVal value As DataTable)
            _dtCDP = value
        End Set
    End Property
    Public Sub New()
        Me.Tabla = "gprocesos"
        Me.Vista = "vgprocesos"
    End Sub
    ''' <summary>
    ''' Consulta de Contratos por llave primaria
    ''' </summary>
    ''' <param name="Num_PCon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkC(ByVal Num_PCon As String, ByVal Grupo As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        Grupo = IIf(String.IsNullOrEmpty(Grupo), "1", Grupo)
        querystring = "SELECT * FROM VGProcesosC where Pro_Sel_Nro=:NUm_Pcon and Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    ''' <summary>
    ''' Consulta de Contratos por llave primaria
    ''' </summary>
    ''' <param name="Num_PCon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPk(ByVal Num_PCon As String, ByVal Grupo As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        Grupo = IIf(String.IsNullOrEmpty(Grupo), "1", Grupo)
        querystring = "SELECT * FROM VGProcesos where Pro_Sel_Nro=:NUm_Pcon and Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    ''' <summary>
    ''' Consulta de Contratos por llave primaria
    ''' </summary>
    ''' <param name="Num_PCon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkCtr(ByVal Num_PCon As String, ByVal Grupo As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        Grupo = IIf(String.IsNullOrEmpty(Grupo), "1", Grupo)
        querystring = "SELECT * FROM VGProcesosC where Pro_Sel_Nro=:NUm_Pcon and Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPConMun(ByVal COD_CON As String, ByVal GRUPO As String) As DataTable
        Me.Conectar()
        querystring = "SELECT MUNICIPIOS.COD_MUN , MUNICIPIOS.NOM_MUN,(SELECT CASE WHEN count(*)=0 THEN '0' ELSE '1' END AS EST FROM PCONMUN WHERE  NRO_PCON=:COD_CON and cod_mun=MUNICIPIOS.cod_mun and Grupo=:GRUPO) EST  FROM MUNICIPIOS ORDER BY COD_MUN "
        CrearComando(querystring)
        AsignarParametroCadena(":COD_CON", COD_CON)
        AsignarParametroCadena(":GRUPO", GRUPO)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCPorDepNec(ByVal FechaInicial As Date, ByVal FechaFinal As Date, ByVal dep_con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT   nom_tproc, COUNT (*) cantidad, SUM (valor_adicion (numero) + val_apo_gob) valor FROM vcontratosc2 WHERE vig_con = 2010 and ESTADO<>'Anulado' and dep_con='" + dep_con + "' and fec_sus_con between to_date('" + FechaInicial.ToShortDateString + "','dd/mm/yyyy') and to_date('" + FechaFinal.ToShortDateString + "','dd/mm/yyyy')  GROUP BY nom_tproc Order by nom_tproc desc"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetLikeNProc(ByVal Num_PCon As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VGPROCESOS where Pro_Sel_Nro Like :NUm_Pcon "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":NUm_Pcon", "%" + Num_PCon + "%")
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCDP_PCONTRATOS() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM CDP_PCONTRATOS Where Num_Pcon=:Num_Pcon "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Num_Pcon", Me.Num_PCon)
        'Me.AsignarParametroCadena(":Vigencia", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Get Procesos Asignados a Terceros
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxTerceros(ByVal Ide_Ter As String, ByVal Filtro As String) As DataTable
        Me.Conectar()
        If Not String.IsNullOrEmpty(Filtro) Then
            querystring = "SELECT * From vPContratos2 Where UsuEncargado=:UsuEncargado And " + Filtro + " Order by fec_reg "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":UsuEncargado", Ide_Ter)
            'Throw New Exception(querystring)
        Else
            querystring = "SELECT * From vPContratos2 Where UsuEncargado=:UsuEncargado  Order by fec_reg "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":UsuEncargado", Ide_Ter)
        End If
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Get Procesos Asignados a Usuario Actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxUsuario(ByVal Filtro As String) As DataTable
        Return GetxTerceros(Me.usuario, Filtro)
    End Function

    ''' <summary>
    ''' GetvHUsuEncargados-Historial de Usuarios Encargados
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetvHUsuEncargados(ByVal Num_Proc As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vhusuenc_pcon Where Num_Proc=:Num_Proc Order by fec_reg desc "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetObligaciones() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT ide_oblig ,Num_PCon ,Des_Oblig FROM POBLIGACIONES Where Num_Pcon=:Num_Pcon "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Num_Pcon", Me.Num_PCon)
        'Me.AsignarParametroCadena(":Vigencia", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal COD_TPRO As String, ByVal PRO_SEL_NRO As String, ByVal OBJ_CON As String, ByVal PRO_CON As String, ByVal PLA_EJE_CON As String, ByVal DEP_CON As String, ByVal DEP_PCON As String, ByVal VIG_CON As Decimal, ByVal TIP_CON As String, ByVal STIP_CON As String, ByVal VAL_CON As Decimal, ByVal VAL_APO_GOB As Decimal, ByVal COD_SEC As String, ByVal TIP_FOR As String, ByVal NRO_PLA_CON As String, ByVal URG_MAN As String, ByVal EST_CONV As String, ByVal APL_GAC As String, ByVal LUG_EJE As String, ByVal TPlazo As String, ByVal Agotar_Ppto As String, ByVal Considerandos As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "Insert Into PCONTRATOS (COD_TPRO, PRO_SEL_NRO, OBJ_CON, PRO_CON, PLA_EJE_CON, DEP_CON, DEP_PCON, VIG_CON, TIP_CON, STIP_CON, VAL_CON, VAL_APO_GOB, COD_SEC, TIP_FOR, NRO_PLA_CON,  LUG_EJE, TIPO_PLAZO,AGOTAR_PPTO, CONSIDERANDOS) Values(:COD_TPRO, :PRO_SEL_NRO,  :OBJ_CON, :PRO_CON, :PLA_EJE_CON, :DEP_CON, :DEP_PCON, :VIG_CON, :TIP_CON, :STIP_CON, :VAL_CON, :VAL_APO_GOB, :COD_SEC, :TIP_FOR, :NRO_PLA_CON, :LUG_EJE, :TPlazo,:AGOTAR_PPTO, :CONSIDERANDOS)"
            'Me.CrearNumProc(DEP_PCON, COD_TPRO, VIG_CON)
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
            Me.AsignarParametroCadena(":PRO_SEL_NRO", Me.Num_PCon)
            Me.AsignarParametroCadena(":OBJ_CON", OBJ_CON)
            Me.AsignarParametroCadena(":PRO_CON", PRO_CON)
            Me.AsignarParametroCadena(":PLA_EJE_CON", PLA_EJE_CON)
            Me.AsignarParametroCadena(":DEP_CON", DEP_CON)
            Me.AsignarParametroCadena(":VIG_CON", VIG_CON)
            Me.AsignarParametroCadena(":TIP_CON", TIP_CON)
            Me.AsignarParametroCadena(":STIP_CON", STIP_CON)
            Me.AsignarParametroDecimal(":VAL_CON", VAL_CON)
            Me.AsignarParametroDecimal(":VAL_APO_GOB", VAL_APO_GOB)
            Me.AsignarParametroCadena(":COD_SEC", COD_SEC)
            Me.AsignarParametroCadena(":TIP_FOR", TIP_FOR)
            Me.AsignarParametroCadena(":NRO_PLA_CON", NRO_PLA_CON)
            Me.AsignarParametroCadena(":DEP_PCON", DEP_PCON)
            Me.AsignarParametroCadena(":LUG_EJE", LUG_EJE)
            Me.AsignarParametroCadena(":TPlazo", TPlazo)
            '11 JN 2011- BORIS
            Me.AsignarParametroCadena(":AGOTAR_PPTO", Agotar_Ppto)
            Me.AsignarParametroCadena(":CONSIDERANDOS", Considerandos)

            Me.Conectar()
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "] - " + Me.Num_PCon
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Me.Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal COD_TPRO As String, _
                           ByVal OBJ_CON As String, _
                           ByVal DEP_CON As String, ByVal DEP_PCON As String, _
                           ByVal VIG_CON As Decimal, ByVal TIP_CON As String, _
                           ByVal STIP_CON As String, ByVal FEC_RECIBIDO As Date) As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            InsertP(COD_TPRO, OBJ_CON, DEP_CON, DEP_PCON, VIG_CON, TIP_CON, STIP_CON, FEC_RECIBIDO, "")
            ConfirmarTransaccion()
            Me.lErrorG = False
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "] - " + Me.Num_PCon

        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()

        Finally
            Desconectar()
        End Try
        Return Me.Msg

    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Sub InsertP(ByVal COD_TPRO As String, _
                           ByVal OBJ_CON As String, _
                           ByVal DEP_CON As String, ByVal DEP_PCON As String, _
                           ByVal VIG_CON As Decimal, ByVal TIP_CON As String, _
                           ByVal STIP_CON As String, ByVal FEC_RECIBIDO As Date, ByVal NUM_SOL As String)


        'Me.CrearNumProc(DEP_PCON, COD_TPRO, VIG_CON)
        querystring = "Insert Into PCONTRATOS (COD_TPRO, PRO_SEL_NRO, OBJ_CON, DEP_CON, DEP_PCON, VIG_CON, TIP_CON, STIP_CON, FECHARECIBIDO, NUM_SOL) Values(:COD_TPRO, :PRO_SEL_NRO,  :OBJ_CON,  :DEP_CON, :DEP_PCON, :VIG_CON, :TIP_CON, :STIP_CON, to_date(:FEC_RECIBIDO,'dd/mm/yyyy'), :NUM_SOL)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
        Me.AsignarParametroCadena(":PRO_SEL_NRO", Me.Num_PCon)
        Me.AsignarParametroCadena(":OBJ_CON", OBJ_CON)
        Me.AsignarParametroCadena(":DEP_CON", DEP_CON)
        Me.AsignarParametroCadena(":VIG_CON", VIG_CON)
        Me.AsignarParametroCadena(":TIP_CON", TIP_CON)
        Me.AsignarParametroCadena(":STIP_CON", STIP_CON)
        Me.AsignarParametroCadena(":DEP_PCON", DEP_PCON)
        Me.AsignarParametroCadena(":FEC_RECIBIDO", FEC_RECIBIDO.ToShortDateString)
        Me.AsignarParametroCadena(":NUM_SOL", NUM_SOL)
        'Throw New Exception(_Comando.CommandText)
        Me.num_reg = Me.EjecutarComando()
    End Sub
    Private Sub ValResPcon(ByVal Num_Proc As String, ByVal Grupo As String)
        querystring = "Val_Pcon"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("Num_Proc", Num_Proc)
        AsignarParametroCad("Grupo", Grupo)
        EjecutarComando()
        Me._Valor_Restante = Publico.PuntoPorComa(preturn.Value.ToString())
    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCons(ByVal cod_dep As String, ByVal cod_tpro As String, ByVal vig_con As String, Optional ByVal connectar As Boolean = False) As Integer
        If connectar = True Then
            Me.Conectar()
        End If
        Dim queryString As String = "select Nvl(Max(NRO_CON),0)+1 as Nro_Con_New from pcontratos where dep_pcon=:dep_pcon and cod_tpro=:cod_tpro and vig_con=:vig_con"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":dep_pcon", cod_dep)
        Me.AsignarParametroCadena(":cod_tpro", cod_tpro)
        Me.AsignarParametroCadena(":vig_con", vig_con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        If connectar = True Then
            Me.Desconectar()
        End If
        Me.Nro_Con = CInt(dataTb.Rows(0)("Nro_Con_New"))
        Return Me.Nro_Con
    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ GONZALEZ
    ''' FECHA: 28 FEBRERO DE 2011
    ''' MODIFICACION:
    ''' SE AGREGO EL PARAMETRO TPLAZO
    ''' SE CAMBIO EL TIPO DE DATO DEL PARAMETRO PLA_EJE_CON DE DECIMAL
    ''' A STRING.
    ''' RESPONSABLE: ERIC MARTINEZ GONZALEZ
    ''' FECHA: 18 MARZO DE 2011
    ''' MODIFICACION:
    ''' SE AGREGO CODIGO PARA RELACIONAR MUNICIPIOS A PROCESO
    ''' </summary>
    ''' <param name="PRO_SEL_NRO_PK"></param>
    ''' <param name="COD_TPRO"></param>
    ''' <param name="PRO_SEL_NRO"></param>
    ''' <param name="OBJ_CON"></param>
    ''' <param name="PRO_CON"></param>
    ''' <param name="PLA_EJE_CON"></param>
    ''' <param name="DEP_CON"></param>
    ''' <param name="DEP_PCON"></param>
    ''' <param name="VIG_CON"></param>
    ''' <param name="TIP_CON"></param>
    ''' <param name="STIP_CON"></param>
    ''' <param name="VAL_CON"></param>
    ''' <param name="VAL_APO_GOB"></param>
    ''' <param name="COD_SEC"></param>
    ''' <param name="TIP_FOR"></param>
    ''' <param name="NRO_PLA_CON"></param>
    ''' <param name="URG_MAN"></param>
    ''' <param name="EST_CONV"></param>
    ''' <param name="APL_GAC"></param>
    ''' <param name="LUG_EJE"></param>
    ''' <param name="TPlazo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Update(ByVal PRO_SEL_NRO_PK As String, ByVal COD_TPRO As String, ByVal PRO_SEL_NRO As String, ByVal OBJ_CON As String, ByVal PRO_CON As String, ByVal PLA_EJE_CON As String, ByVal DEP_CON As String, ByVal DEP_PCON As String, ByVal VIG_CON As Decimal, ByVal TIP_CON As String, ByVal STIP_CON As String, ByVal VAL_CON As Decimal, ByVal VAL_APO_GOB As Decimal, ByVal COD_SEC As String, ByVal TIP_FOR As String, ByVal NRO_PLA_CON As String, ByVal URG_MAN As String, ByVal EST_CONV As String, ByVal APL_GAC As String, ByVal LUG_EJE As String, ByVal TPlazo As String, ByVal SECTOR As String, ByVal Grupo As String, ByVal Plazo2 As String, ByVal tip_plazo2 As String, ByVal val_sin_iva As Decimal, ByVal Interventoria As String, ByVal Agotar_Ppto As String, ByVal Considerandos As String, ByVal Aportes As String, ByVal Mun() As String, ByVal nm As Integer, ByVal REVISADOPOR As String, ByVal Obs_Proyectos As String, ByVal Obs_CDP As String, ByVal Obs_Polizas As String) As String
        Me.Conectar()
        ValResPcon(PRO_SEL_NRO_PK, Grupo)

        Try
            If Me.Valor_Restante < VAL_CON Then
                Throw New Exception("El valor del Subproceso no puede ser superior al restante del valor del Proceso (" & FormatCurrency(Me.Valor_Restante) & ")")
            Else
                If TPlazo = "D" Then
                    Me.ComenzarTransaccion()
                    querystring = "Update GPROCESOS SET REVISADOPOR=:REVISADOPOR, COD_TPRO=:COD_TPRO, PRO_SEL_NRO=:PRO_SEL_NRO, OBJ_CON=:OBJ_CON, PRO_CON=:PRO_CON, PLA_EJE_CON=To_Number(:PLA_EJE_CON), DEP_CON=:DEP_CON, DEP_PCON=:DEP_PCON, VIG_CON=:VIG_CON, TIP_CON=:TIP_CON, STIP_CON=:STIP_CON, VAL_CON=:VAL_CON, VAL_APO_GOB=:VAL_APO_GOB, TIP_FOR=:TIP_FOR, NRO_PLA_CON=to_number(:NRO_PLA_CON), LUG_EJE=:LUG_EJE, TIPO_PLAZO=:Tplazo, URG_MAN=:URG_MAN, EST_CONV=:EST_CONV, COD_SEC=:SECTOR, VAL_SIN_IVA=:VAL_SIN_IVA, INTERVENTORIA=:INTERVENTORIA, AGOTAR_PPTO=:AGOTAR_PPTO, CONSIDERANDOS=:CONSIDERANDOS, APORTES=:APORTES, Obs_Proyectos=:Obs_Proyectos, Obs_CDP=:Obs_CDP, Obs_Polizas=:Obs_Polizas WHERE PRO_SEL_NRO=:PRO_SEL_NRO_PK AND GRUPO=:GRUPO"
                    Me.CrearComando(querystring)
                    Me.Num_PCon = PRO_SEL_NRO
                    Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
                    Me.AsignarParametroCadena(":REVISADOPOR", REVISADOPOR)
                    Me.AsignarParametroCadena(":PRO_SEL_NRO", PRO_SEL_NRO)
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
                    Me.AsignarParametroCadena(":NRO_PLA_CON", NRO_PLA_CON)
                    Me.AsignarParametroCadena(":DEP_PCON", DEP_PCON)
                    Me.AsignarParametroCadena(":LUG_EJE", LUG_EJE)
                    Me.AsignarParametroCadena(":PRO_SEL_NRO_PK", PRO_SEL_NRO_PK)
                    Me.AsignarParametroCadena(":Tplazo", TPlazo)
                    Me.AsignarParametroCadena(":URG_MAN", URG_MAN)
                    Me.AsignarParametroCadena(":EST_CONV", EST_CONV)
                    Me.AsignarParametroCadena(":SECTOR", SECTOR)
                    Me.AsignarParametroEntero(":GRUPO", CInt(Grupo))
                    Me.AsignarParametroDecimal(":VAL_SIN_IVA", val_sin_iva)
                    Me.AsignarParametroCadena(":INTERVENTORIA", Interventoria)
                    '-------
                    '11 JN 2011- BORIS
                    Me.AsignarParametroCadena(":AGOTAR_PPTO", Agotar_Ppto)
                    Me.AsignarParametroCLOB(":CONSIDERANDOS", Considerandos)
                    Me.AsignarParametroCLOB(":Aportes", Aportes)
                    Me.AsignarParametroCLOB(":Obs_Proyectos", Obs_Proyectos)
                    Me.AsignarParametroCLOB(":Obs_CDP", Obs_CDP)
                    Me.AsignarParametroCLOB(":Obs_Polizas", Obs_Polizas)
                    '18 Jn 2011 BORIS

                    'Me.AsignarParametroEntero(":PLA_EJE_CON", CInt(Plazo2))
                    'Throw New Exception(Me.vComando.CommandText)
                    Me.num_reg = Me.EjecutarComando()
                    'RELACIONAR MUNICIPIOS A PROCESO
                    querystring = "DELETE FROM PConMun WHERE Nro_PCon='" + PRO_SEL_NRO + "' and Grupo=" + Grupo
                    Me.CrearComando(querystring)
                    EjecutarComando()

                    For i = 0 To nm
                        querystring = "INSERT INTO PConMun(Cod_Mun,nro_pcon, Grupo)VALUES('" + Mun(i) + "','" + PRO_SEL_NRO + "'," + Grupo + ") "
                        Me.CrearComando(querystring)
                        EjecutarComando()
                    Next i
                    Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                Else
                    Me.ComenzarTransaccion()
                    querystring = "Update GPROCESOS SET COD_TPRO=:COD_TPRO, PRO_SEL_NRO=:PRO_SEL_NRO, OBJ_CON=:OBJ_CON, PRO_CON=:PRO_CON, PLA_EJE_CON=to_number(:PLA_EJE_CON), DEP_CON=:DEP_CON, DEP_PCON=:DEP_PCON, VIG_CON=:VIG_CON, TIP_CON=:TIP_CON, STIP_CON=:STIP_CON, VAL_CON=:VAL_CON, VAL_APO_GOB=:VAL_APO_GOB, TIP_FOR=:TIP_FOR, NRO_PLA_CON=to_number(:NRO_PLA_CON), LUG_EJE=:LUG_EJE, TIPO_PLAZO=:Tplazo, URG_MAN=:URG_MAN, EST_CONV=:EST_CONV, COD_SEC=:SECTOR, VAL_SIN_IVA=:VAL_SIN_IVA, PLAZO2_EJE_CON=:PLAZO2, TIPO_PLAZO2=:Tplazo2, INTERVENTORIA=:INTERVENTORIA, AGOTAR_PPTO=:AGOTAR_PPTO, CONSIDERANDOS=:CONSIDERANDOS, APORTES=:APORTES, obs_proyectos=:Obs_Proyectos, Obs_CDP=:Obs_CDP, Obs_Polizas=:Obs_Polizas WHERE PRO_SEL_NRO=:PRO_SEL_NRO_PK AND GRUPO=:GRUPO"
                    Me.CrearComando(querystring)
                    Me.Num_PCon = PRO_SEL_NRO
                    Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
                    Me.AsignarParametroCadena(":PRO_SEL_NRO", PRO_SEL_NRO)
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
                    Me.AsignarParametroCadena(":NRO_PLA_CON", NRO_PLA_CON)
                    Me.AsignarParametroCadena(":DEP_PCON", DEP_PCON)
                    Me.AsignarParametroCadena(":LUG_EJE", LUG_EJE)
                    Me.AsignarParametroCadena(":PRO_SEL_NRO_PK", PRO_SEL_NRO_PK)
                    Me.AsignarParametroCadena(":Tplazo", TPlazo)
                    Me.AsignarParametroCadena(":URG_MAN", URG_MAN)
                    Me.AsignarParametroCadena(":EST_CONV", EST_CONV)
                    Me.AsignarParametroCadena(":SECTOR", SECTOR)
                    Me.AsignarParametroEntero(":GRUPO", CInt(Grupo))
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
                    querystring = "DELETE FROM PConMun WHERE Nro_PCon='" + PRO_SEL_NRO + "' and Grupo=" + Grupo
                    Me.CrearComando(querystring)
                    EjecutarComando()

                    For i = 0 To nm
                        querystring = "INSERT INTO PConMun(Cod_Mun,nro_pcon, Grupo)VALUES('" + Mun(i) + "','" + PRO_SEL_NRO + "'," + Grupo + ") "
                        Me.CrearComando(querystring)
                        EjecutarComando()
                    Next i
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


    '<asp:TextBox onblur="Sys.WebForms.PageRequestManager.getInstance()._doPostBack('Button1', '');" />
    ''' <summary>
    ''' MODIFICADO;: BORIS, SE QUITA LA CONEXIÓN, REQUIERE ABRIR CONEXIÓN
    ''' FEC 27 DE MARZO
    ''' RESPONSABLE: ERIC MARTINEZ GONZALEZ
    ''' FECHA: 28 FEBRERO DE 2011
    ''' MODIFICACION: FUNCION PARA CONSULTAR EL VALOR DE UN CONTRATO
    ''' </summary>
    ''' <param name="Num_PCon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function ValorGproceso(ByVal Num_PCon As String, ByVal Grupo As String) As Decimal
        Me.Num_PCon = Num_PCon
        querystring = "SELECT VAL_APO_GOB FROM GPROCESOS where Pro_Sel_Nro=:NUm_Pcon and Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Return CDec(dataTb.Rows(0).Item(0))
    End Function
    ''' <summary>
    ''' RESPONSABLE ERIC MARTINEZ
    ''' FECHA. 28 FEBRERO 2011
    ''' MODIFICACION:
    ''' FUNCION PARA CAMBIAREL ESTADO DE LA SOLICITUD
    ''' </summary>
    ''' <param name="PRO_SEL_NRO_PK"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Tramite(ByVal PRO_SEL_NRO_PK As String, ByVal Grupo As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "Update GPROCESOS SET ESTADO='TR' WHERE PRO_SEL_NRO=:PRO_SEL_NRO_PK AND GRUPO=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":PRO_SEL_NRO_PK", PRO_SEL_NRO_PK)
            Me.AsignarParametroCadena(":Grupo", Grupo)
            'Throw New Exception(Me._Comando.CommandText)
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
    Public Function Definitivo(ByVal PRO_SEL_NRO_PK As String, ByVal Grupo As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "Update GPROCESOS SET ESTADO='DF' WHERE PRO_SEL_NRO=:PRO_SEL_NRO_PK AND GRUPO=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":PRO_SEL_NRO_PK", PRO_SEL_NRO_PK)
            Me.AsignarParametroCadena(":Grupo", Grupo)
            'Throw New Exception(Me.vComando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = "Se Validaron de Forma Correcta los datos del Contrato, Puede Generar la Minuta " + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Me.Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function ValorApoProp(ByVal Num_PCon As String, ByVal Grupo As String) As Decimal
        Me.Num_PCon = Num_PCon
        'Me.Conectar()
        querystring = "SELECT VAL_APO_GOB FROM GPROCESOS where Pro_Sel_Nro=:NUm_Pcon and Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Return CDec(dataTb.Rows(0).Item(0))
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function ValordelContrato(ByVal Num_PCon As String, ByVal Grupo As String) As Decimal
        Me.Num_PCon = Num_PCon
        'Me.Conectar()
        querystring = "SELECT VAL_CON FROM GPROCESOS where Pro_Sel_Nro=:NUm_Pcon and Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Return CDec(dataTb.Rows(0).Item(0))
    End Function
End Class
