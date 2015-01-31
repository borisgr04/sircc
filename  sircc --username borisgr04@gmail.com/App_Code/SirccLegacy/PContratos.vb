Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel
'Modificado el 28 de febrero Boris Gonzalez
'23 de marzo
' Se arregla el insert para nuevo proceso. faltaba confirmar transacción
<System.ComponentModel.DataObject()> _
Public Class PContratos
    Inherits BDDatos
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
        Me.Tabla = "PContratos"
        Me.Vista = "vPContratos"
    End Sub

    

    ''' <summary>
    ''' Consulta de PContratos por llave primaria
    ''' </summary>
    ''' <param name="Num_PCon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPk(ByVal Num_PCon As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        querystring = "SELECT * FROM VPCONTRATOS where Pro_Sel_Nro=:NUm_Pcon"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetProcRad(ByVal Num_PCon As String) As Integer
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        querystring = "select count(*) Cantidad from gprocesos where pro_sel_nro=:Num_Pcon and estado='RA'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Pcon", Num_PCon)
        'Throw New Exception(vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return CInt(dataTb.Rows(0)("Cantidad").ToString)
    End Function

    ''' <summary>
    ''' Consulta de PContratos por llave primaria para usuario actual,
    ''' </summary>
    ''' <param name="Num_PCon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkE(ByVal Num_PCon As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        querystring = "SELECT * FROM VPCONTRATOS where Pro_Sel_Nro=:NUm_Pcon And UsuEncargado=:Usuario"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Me.AsignarParametroCadena(":Usuario", Me.usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
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

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VPCONTRATOS where Pro_Sel_Nro Like :NUm_Pcon"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":NUm_Pcon", "%" + Num_PCon + "%")
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCDP_PCONTRATOS() As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
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

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
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

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vhusuenc_pcon Where Num_Proc=:Num_Proc Order by fec_reg desc "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


    ''' <summary>
    ''' Procesos DF
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetProcesosDF(ByVal Filtro As String) As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()
        If Not String.IsNullOrEmpty(Filtro) Then
            Dim queryString As String = "SELECT * FROM vGPROCESOS WHERE ESTADO='DF' And " + Filtro + " Order by fec_reg desc "
            Me.CrearComando(queryString)
        Else
            Dim queryString As String = "SELECT * FROM vGPROCESOS WHERE ESTADO='DF' Order by fec_reg desc "
            Me.CrearComando(queryString)
        End If
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetObligaciones() As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
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
    Public Function Insert(ByVal COD_TPRO As String, ByVal PRO_SEL_NRO As String, ByVal OBJ_CON As String, ByVal PRO_CON As String, ByVal PLA_EJE_CON As String, ByVal DEP_CON As String, ByVal DEP_PCON As String, ByVal VIG_CON As Decimal, ByVal TIP_CON As String, ByVal STIP_CON As String, ByVal VAL_CON As Decimal, ByVal VAL_APO_GOB As Decimal, ByVal COD_SEC As String, ByVal TIP_FOR As String, ByVal NRO_PLA_CON As String, ByVal URG_MAN As String, ByVal EST_CONV As String, ByVal APL_GAC As String, ByVal LUG_EJE As String, ByVal TPlazo As String) As String
        'Me.Desconectar()

        Me.Conectar()

        Try
            Me.ComenzarTransaccion()
            querystring = "Insert Into PCONTRATOS (COD_TPRO, PRO_SEL_NRO, OBJ_CON, PRO_CON, PLA_EJE_CON, DEP_CON, DEP_PCON, VIG_CON, TIP_CON, STIP_CON, VAL_CON, VAL_APO_GOB, COD_SEC, TIP_FOR, NRO_PLA_CON,  LUG_EJE, TIPO_PLAZO) Values(:COD_TPRO, :PRO_SEL_NRO,  :OBJ_CON, :PRO_CON, :PLA_EJE_CON, :DEP_CON, :DEP_PCON, :VIG_CON, :TIP_CON, :STIP_CON, :VAL_CON, :VAL_APO_GOB, :COD_SEC, :TIP_FOR, :NRO_PLA_CON, :LUG_EJE, :TPlazo)"

            Me.CrearNumProc(DEP_PCON, COD_TPRO, VIG_CON)

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
            InsertP(COD_TPRO, OBJ_CON, DEP_CON, DEP_PCON, VIG_CON, TIP_CON, STIP_CON, FEC_RECIBIDO, "", 0, "")
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
                           ByVal STIP_CON As String, ByVal FEC_RECIBIDO As Date, ByVal NUM_SOL As String, ByVal VAL_CON As Decimal, IDE_CON As String)


        Me.CrearNumProc(DEP_PCON, COD_TPRO, VIG_CON)
        querystring = "Insert Into PCONTRATOS (COD_TPRO, PRO_SEL_NRO, OBJ_CON, DEP_CON, DEP_PCON, VIG_CON, TIP_CON, STIP_CON, FECHARECIBIDO, NUM_SOL, VAL_CON, VAL_APO_GOB, IDE_CON, IDE_REP,TIPO_PLAZO) Values(:COD_TPRO, :PRO_SEL_NRO,  :OBJ_CON,  :DEP_CON, :DEP_PCON, :VIG_CON, :TIP_CON, :STIP_CON, to_date(:FEC_RECIBIDO,'dd/mm/yyyy'), :NUM_SOL, :VAL_CON, :VAL_APO_GOB, :IDE_CON,:IDE_REP,'D')"
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
        Me.AsignarParametroDecimal(":VAL_CON", VAL_CON)
        'Me.AsignarParametroCadena(":VAL_CON", VAL_CON)

        Me.AsignarParametroDecimal(":VAL_APO_GOB", VAL_CON)
        Me.AsignarParametroCadena(":IDE_CON", IDE_CON)
        Me.AsignarParametroCadena(":IDE_REP", IDE_CON)
        'Me.AsignarParametroCadena(":TIPO_PLAZO", "D")
        'Me.AsignarParametroCadena(":NUMGRUPOS", 1)
        'Throw New Exception(_Comando.CommandText)

        Me.num_reg = Me.EjecutarComando()

        querystring = "UPDATE PCONTRATOS SET NUMGRUPOS=1  WHERE PRO_SEL_NRO=:PRO_SEL_NRO"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":PRO_SEL_NRO", Me.Num_PCon)
        EjecutarComando()

    End Sub
    Private Sub CrearNumProc(ByVal cod_dep As String, ByVal cod_tpro As String, ByVal vig_con As String)
        querystring = "crearnumproc"
       CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("cod_dep", cod_dep)
        AsignarParametroCad("cod_tpro", cod_tpro)
        AsignarParametroCad("cod_dep", vig_con)
        EjecutarComando()
        Me.Num_PCon = preturn.Value.ToString()
    End Sub
    Public Function AnularProc(ByVal Num_Proc As String, ByVal Observacion As String) As String
        Me.Conectar()
        querystring = "GP_ANULAR"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("NUM_PROCE", Num_Proc)
        AsignarParametroCad("OBSER", Observacion)
        EjecutarComando()
        Me.Desconectar()
        Return preturn.Value.ToString()
    End Function
    Public Function EliminarProc(ByVal Num_Proc As String, ByVal Observacion As String) As String
        Me.Conectar()
        querystring = "GP_ELIMINAR"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("NUM_PROCE", Num_Proc)
        AsignarParametroCad("OBSER", Observacion)
        EjecutarComando()
        Me.Desconectar()
        Return preturn.Value.ToString()
    End Function
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
    '''   ''' RESPONSABLE: ERIC MARTINEZ GONZALEZ
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
    ''' <param name="DEP_CON"></param>
    ''' <param name="DEP_PCON"></param>
    ''' <param name="VIG_CON"></param>
    ''' <param name="TIP_CON"></param>
    ''' <param name="STIP_CON"></param>
    ''' <param name="VAL_CON"></param>
    ''' <param name="VAL_APO_GOB"></param>
    ''' <param name="NRO_PLA_CON"></param>
    ''' <param name="APL_GAC"></param>
    ''' <param name="NUMGRUPOS"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Update(ByVal PRO_SEL_NRO_PK As String, ByVal COD_TPRO As String, ByVal PRO_SEL_NRO As String, ByVal OBJ_CON As String, ByVal PRO_CON As String, ByVal DEP_CON As String, ByVal DEP_PCON As String, ByVal VIG_CON As Decimal, ByVal TIP_CON As String, ByVal STIP_CON As String, ByVal VAL_CON As Decimal, ByVal VAL_APO_GOB As Decimal, ByVal NRO_PLA_CON As String, ByVal APL_GAC As String, ByVal NUMGRUPOS As String) As String
        'Me.Desconectar()

        'Me.Conectar()
        Me.Conectar()
        'BDSProvider.BDSProvider._Conexion.Open()

        Try
            Me.ComenzarTransaccion()
            querystring = "Update PCONTRATOS SET COD_TPRO=:COD_TPRO, PRO_SEL_NRO=:PRO_SEL_NRO, OBJ_CON=:OBJ_CON, PRO_CON=:PRO_CON, DEP_CON=:DEP_CON, DEP_PCON=:DEP_PCON, VIG_CON=:VIG_CON, TIP_CON=:TIP_CON, STIP_CON=:STIP_CON, VAL_CON=to_number(:VAL_CON), VAL_APO_GOB=to_number(:VAL_APO_GOB), NRO_PLA_CON=to_number(:NRO_PLA_CON), NUMGRUPOS=to_number(:NUMGRUPOS) WHERE PRO_SEL_NRO=:PRO_SEL_NRO_PK"

            Me.CrearComando(querystring)
            Me.Num_PCon = PRO_SEL_NRO

            Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
            Me.AsignarParametroCadena(":PRO_SEL_NRO", PRO_SEL_NRO)
            Me.AsignarParametroCadena(":OBJ_CON", OBJ_CON)
            Me.AsignarParametroCadena(":PRO_CON", PRO_CON)

            Me.AsignarParametroCadena(":DEP_CON", DEP_CON)
            Me.AsignarParametroCadena(":VIG_CON", VIG_CON)
            Me.AsignarParametroCadena(":TIP_CON", TIP_CON)
            Me.AsignarParametroCadena(":STIP_CON", STIP_CON)
            Me.AsignarParametroDecimal(":VAL_CON", VAL_CON)
            Me.AsignarParametroDecimal(":VAL_APO_GOB", VAL_APO_GOB)

            Me.AsignarParametroCadena(":NRO_PLA_CON", NRO_PLA_CON)
            Me.AsignarParametroCadena(":DEP_PCON", DEP_PCON)

            Me.AsignarParametroCadena(":PRO_SEL_NRO_PK", PRO_SEL_NRO_PK)


            Me.AsignarParametroEntero(":NUMGRUPOS", CInt(NUMGRUPOS))


            'Throw New Exception(Me._Comando.CommandText)

            Me.num_reg = Me.EjecutarComando()
            'Me.Insert_Obligaciones()
            'Me.Insert_CDP()

            'RELACIONAR MUNICIPIOS A PROCESO
            querystring = "DELETE FROM PConMun WHERE Nro_PCon='" + PRO_SEL_NRO + "' "
            Me.CrearComando(querystring)
            EjecutarComando()

            'For i = 0 To NM
            '    querystring = "INSERT INTO PConMun(Cod_Mun,nro_pcon)VALUES('" + MUN(i) + "','" + PRO_SEL_NRO + "') "
            '    Me.CrearComando(querystring)
            '    EjecutarComando()
            'Next i

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




        Return Me.Msg

    End Function



    ''' <summary>
    ''' ASIGANCION DE USUARIOS ENCARGADOS (ABOGADOS A PROCESOS DE CONTRATACION)
    ''' </summary>
    ''' <param name="PRO_SEL_NRO_PK"></param>
    ''' <param name="USUENCARGADO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Asignar_Usuario_Encargado(ByVal PRO_SEL_NRO_PK As String, ByVal USUENCARGADO As String) As String
        Me.Conectar()
        Try
            Asignar_Usuario_EncargadoP(PRO_SEL_NRO_PK, USUENCARGADO)
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        End Try
        Me.Desconectar()
        Return Me.Msg

    End Function

    Public Sub Asignar_Usuario_EncargadoP(ByVal PRO_SEL_NRO_PK As String, ByVal USUENCARGADO As String)
        If USUENCARGADO.Trim.Length = 0 Then
            Throw New Exception("El funcionario no puede esta vacio")
        End If
        querystring = "Update PCONTRATOS SET USUENCARGADO=:USUENCARGADO WHERE PRO_SEL_NRO=:PRO_SEL_NRO_PK"
        Me.CrearComando(querystring)
        Me.Num_PCon = PRO_SEL_NRO_PK
        Me.AsignarParametroCadena(":USUENCARGADO", USUENCARGADO)
        Me.AsignarParametroCadena(":PRO_SEL_NRO_PK", PRO_SEL_NRO_PK)
        Me.num_reg = Me.EjecutarComando()


    End Sub

    Private Sub Insert_Obligaciones()

        Me.CrearComando("DELETE FROM POBLIGACIONES WHERE Num_PCon=:Num_PCon")
        Me.AsignarParametroCadena(":Num_PCon", Me.Num_PCon)
        Me.EjecutarComando()

        'ASOCIAR LOS MUNICIPIOS A LOS CONTRATOS
        For i = 0 To Me.dtOblig.Rows.Count - 1
            querystring = "INSERT INTO POBLIGACIONES(Num_PCon, Ide_Oblig,Des_Oblig)VALUES(:Num_PCon, :Ide_Oblig,:Des_Oblig) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_PCon", Me.Num_PCon)
            Me.AsignarParametroEntero(":Ide_Oblig", i)
            Me.AsignarParametroCadena(":Des_Oblig", Me.dtOblig.Rows(i)("Des_Oblig"))
            Me.EjecutarComando()
        Next i

    End Sub

    Private Sub Insert_CDP()

        Me.CrearComando("DELETE FROM CDP_PCONTRATOS WHERE Num_PCon=:Num_PCon")
        Me.AsignarParametroCadena(":Num_PCon", Me.Num_PCon)
        Me.EjecutarComando()

        'ASOCIAR LOS MUNICIPIOS A LOS CONTRATOS
        For i = 0 To Me.dtCDP.Rows.Count - 1
            querystring = "INSERT INTO CDP_PCONTRATOS(Num_PCon, Nro_Cdp,FEC_CDP,VAL_CDP)VALUES(:Num_PCon, :Nro_Cdp,:FEC_CDP,:VAL_CDP) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_PCon", Me.Num_PCon)
            Me.AsignarParametroEntero(":Nro_Cdp", Me.dtCDP.Rows(i)("Nro_Cdp"))
            Me.AsignarParametroFecha(":FEC_CDP", CDate(Me.dtCDP.Rows(i)("FEC_CDP")))
            Me.AsignarParametroCadena(":VAL_CDP", Me.dtCDP.Rows(i)("VAL_CDP"))

            Me.EjecutarComando()
        Next i

    End Sub

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
    Public Overloads Function ValordelContrato(ByVal Num_PCon As String) As Decimal
        Me.Num_PCon = Num_PCon
        'Me.Conectar()
        querystring = "SELECT VAL_APO_GOB FROM PCONTRATOS where Pro_Sel_Nro=:NUm_Pcon"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        ' Me.Desconectar()
        '.ToString.Replace(Publico.Punto_DecOracle, ",")
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
    Public Function Tramite(ByVal PRO_SEL_NRO_PK As String) As String

        Me.Conectar()
        'BDSProvider.BDSProvider._Conexion.Open()
        'Try
        'Me.ComenzarTransaccion()
        querystring = "Update PCONTRATOS SET ESTADO='TR' WHERE PRO_SEL_NRO=:PRO_SEL_NRO_PK"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":PRO_SEL_NRO_PK", PRO_SEL_NRO_PK)
        'Throw New Exception(Me._Comando.CommandText)
        Me.num_reg = Me.EjecutarComando()
        ' Me.ConfirmarTransaccion()
        Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
        'Catch ex As Exception
        'Me.Msg = "Error:" + ex.Message
        'Me.CancelarTransaccion()

        'End Try

        Me.Desconectar()


        Return Me.Msg

    End Function
    Public Function Definitivo(ByVal PRO_SEL_NRO_PK As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "Update PCONTRATOS SET ESTADO='DF' WHERE PRO_SEL_NRO=:PRO_SEL_NRO_PK"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":PRO_SEL_NRO_PK", PRO_SEL_NRO_PK)
            'Throw New Exception(Me._Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
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
    ''' <summary>
    ''' RESPONSABLE: ERIC YOVANNY MARTINEZ GONZALEZ
    ''' FECHA: 18 MARZO DE 2011
    ''' MODIFICACION: FUNCION QUE SELECCIONA LOS MUNICIPIOS ASOCIADOS A UN PROCESO
    ''' </summary>
    ''' <param name="COD_CON"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPConMun(ByVal COD_CON As String) As DataTable

        querystring = "SELECT MUNICIPIOS.COD_MUN , MUNICIPIOS.NOM_MUN,(SELECT CASE WHEN count(*)=0 THEN '0' ELSE '1' END AS EST FROM PCONMUN WHERE  NRO_PCON=:COD_CON and cod_mun=MUNICIPIOS.cod_mun) EST  FROM MUNICIPIOS "
        CrearComando(querystring)
        AsignarParametroCadena(":COD_CON", COD_CON)

        Return EjecutarConsultaDataTable()

    End Function

    'Private Function _Comando() As Object
    '    Throw New NotImplementedException
    'End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetBySol(ByVal Cod_Sol As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        querystring = "SELECT * FROM VPCONTRATOS where Num_Sol=:Cod_Sol"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class

