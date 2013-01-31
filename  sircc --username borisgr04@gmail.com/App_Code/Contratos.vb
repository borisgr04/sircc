Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
'Se Agrega Campo Dep_Sup Para Manejar la Dependencia que realiza la Supervisión del Contrato.
'Clase para manejar la Tabla Contratos
'Fecha Creaciòn: 19 dic 2010
'Autor: Boris Gonzalez Rivera
' Se agrega Opcion de Busqueda por Ide
'
<System.ComponentModel.DataObject()> _
Public Class Contratos
    Inherits BDDatos
    Dim Vigencia As String
    Dim Tip_Con As String
    Dim NroCon As String


    ''' <summary>
    ''' Certificado por Contratista
    ''' </summary>
    ''' <param name="Ide_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCertificado(ByVal Ide_Con As String) As DataTable
        Me.Conectar()
        'And Dep_pCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo )
        querystring = "SELECT * FROM vLstContratosl Where Ide_Con=:Ide_Con  Order by Numero"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Ide_Con", Ide_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetObjeto(ByVal Cod_Con As String) As String
        Me.Conectar()
        'And Dep_pCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo )
        querystring = "SELECT Obj_Con FROM Contratos Where Cod_Con=:Cod_Con  "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim c As Object = EjecutarEscalar()
        Me.Desconectar()
        Return c.ToString
    End Function

    ''' <summary>
    ''' Consulta de contratos por llave primaria,
    '''  filtrando por dependencia delegada asociada.
    ''' </summary>
    ''' <param name="Ide_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByIde_Con(ByVal Ide_Con As String) As DataTable
        Me.NroCon = Cod_Con
        Me.Conectar()
        'And Dep_pCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo )
        querystring = "SELECT * FROM VCONTRATOSC_A2_2012 Where Ide_Con=:Ide_Con "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Ide_Con", Ide_Con)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Enum FiltroContratos
        Todos = 0
        DepNec = 1
        DepDel = 2
    End Enum

    Dim FiltroC As FiltroContratos

    Public Function GetFiltro_Contrato() As FiltroContratos
        Me.Conectar()
        querystring = "select filtro_contrato from dual "
        Me.CrearComando(querystring)
        FiltroC = Me.EjecutarEscalar()
        Me.Desconectar()
        Return FiltroC
    End Function


    ReadOnly Property Cod_Con As String
        Get
            Return NroCon
        End Get
    End Property

    ''' <summary>
    ''' Retorna el nombre de la Aplicacíón
    ''' Autor: BGR Fecha. 10 de Enero de 2011
    ''' </summary>
    ''' <remarks>xx</remarks>
    Const Dig_Vigencia As Integer = 4
    '---------------------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Insert en al tabla de Contratos - Número automático de radicación
    ''' </summary>
    ''' <param name="vigencia"></param>
    ''' <param name="ide"></param>
    ''' <param name="obj"></param>
    ''' <param name="pro"></param>
    ''' <param name="fsus"></param>
    ''' <param name="pla"></param>
    ''' <param name="dep"></param>
    ''' <param name="stip"></param>
    ''' <param name="tip"></param>
    ''' <param name="val_con"></param>
    ''' <param name="Mun"></param>
    ''' <param name="nm"></param>
    ''' <param name="cod_sec"></param>
    ''' <param name="tip_for"></param>
    ''' <param name="cc"></param>
    ''' <param name="tip_proc"></param>
    ''' <param name="pla_pre"></param>
    ''' <param name="ide_rep"></param>
    ''' <param name="Urg_man"></param>
    ''' <param name="Est_Conv"></param>
    ''' <param name="Pro_Sel_Nro"></param>
    ''' <param name="dep_pcon"></param>
    ''' <param name="val_apo_gob"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Insert(ByVal vigencia As Integer, ByVal ide As String, ByVal obj As String, ByVal pro As String, ByVal fsus As Date, ByVal pla As Integer, ByVal dep As String, ByVal stip As String, ByVal tip As String, ByVal val_con As Decimal, ByVal Mun() As String, ByVal nm As Integer, ByVal cod_sec As String, ByVal tip_for As String, ByVal cc As String, ByVal tip_proc As String, ByVal pla_pre As String, ByVal ide_rep As String, ByVal Urg_man As Boolean, ByVal Est_Conv As Boolean, ByVal Pro_Sel_Nro As String, ByVal dep_pcon As String, ByVal val_apo_gob As Decimal, ByVal ANTICIPO As Boolean, ByVal NEMPLEOS As Integer, ByVal PER_APO As Boolean, ByVal AGOTAR_PPTO As Boolean, ByVal PLAZO2_EJE_CON As String, ByVal TIPO_PLAZO As String, ByVal TIPO_PLAZO2 As String, Dep_Sup As String) As String
        Dim ncon As New Vigencias()
        Dim año As Integer = vigencia
        Dim nro As Integer = 0
        Dim cpc As String = ""
        ''Consultar ultimo numero consecutivo
        Me.Conectar()
        ncon.Conexion = Me.Conexion
        ncon.GetNroConByIdeVig(tip, año, nro)
        nro = nro + 1
        Me.NroCon = Right(año.ToString, Contratos.Dig_Vigencia) + tip.ToString + Right("0000" + nro.ToString, 4)
        Dim cod_con As String = Me.NroCon
        Msg = InsertP(nro, cod_con, vigencia, ide, obj, pro, fsus, pla, dep, stip, tip, val_con, Mun, nm, cod_sec, tip_for, cc, tip_proc, pla_pre, ide_rep, Urg_man, Est_Conv, Pro_Sel_Nro, dep_pcon, val_apo_gob, ANTICIPO, NEMPLEOS, PER_APO, AGOTAR_PPTO, PLAZO2_EJE_CON, TIPO_PLAZO, TIPO_PLAZO2, Dep_Sup)
        Me.Desconectar()
        Return Msg
    End Function

    'CLASE              : Contratos
    'METODO             : Insert
    'DESCRIPCIÓNl       : Método para insertar COntratos, se agregó el parametro vigencia y num_com del Insert Base
    'FECHA CREACIÓN     : 10 de Octubre de 2010 en SIRCC    'AUTOR              : BORIS G.
    'FECHA MODIFICACION :  10 DE ENERO 2011 - SIRCC 2011    ' AUTOR : BORIS G. 
    ' Modificacion para arreglar la inserción de decimales
    ' SE AGREGA TIPOS DE PLAZO Y PLAZO EJE 2, 23 DE ABRIL D 2012

    Private Function InsertP(ByVal nro As Integer, ByVal cod_con As String, ByVal vigencia As Integer, ByVal ide As String, ByVal obj As String, ByVal pro As String, ByVal fsus As Date, ByVal pla As Integer, ByVal dep As String, ByVal stip As String, ByVal tip As String, ByVal val_con As Decimal, ByVal Mun() As String, ByVal nm As Integer, ByVal cod_sec As String, ByVal tip_for As String, ByVal cc As String, ByVal tip_proc As String, ByVal pla_pre As String, ByVal ide_rep As String, ByVal Urg_man As Boolean, ByVal Est_Conv As Boolean, ByVal Pro_Sel_Nro As String, ByVal dep_pcon As String, ByVal val_apo_gob As Decimal, ByVal ANTICIPO As String, ByVal NEMPLEOS As Integer, ByVal PER_APO As String, ByVal AGOTAR_PPTO As Boolean, ByVal PLAZO2_EJE_CON As String, ByVal TIPO_PLAZO As String, ByVal TIPO_PLAZO2 As String, Dep_Sup As String) As String
        Me.Vigencia = vigencia
        Me.Tip_Con = tip
        Dim gac As String = ""
        Dim fsa As Date

        '--------------Validaciones 
        If Year(fsus) <> vigencia Then
            Msg = "La Fecha de Suscripción no coincide con la vigencia " + fsa.ToShortDateString
            Me.lErrorG = True
            Return Msg
            Exit Function
        End If

        If Me.UltFecSus(fsa) Then
            If fsa > fsus Then
                Msg = "La Ultima Fecha de Suscripción para este Tipo de Contratos es " + fsa.ToShortDateString
                Me.lErrorG = True
                Return Msg
                Exit Function
            End If
        End If

        Dim UM As String = IIf(Urg_man = True, "1", "0")
        Dim EC As String = IIf(Est_Conv = True, "1", "0")

        Dim PerApo As String = IIf(PER_APO = True, "1", "0")
        Dim Pacto_Anticipo As String = IIf(ANTICIPO = True, "1", "0")
        Dim Ag_Ppto As String = IIf(AGOTAR_PPTO = True, "1", "0")


        Dim i As Integer
        Try
            Me.ComenzarTransaccion()
            gac = IIf(gac <> "", gac, " ")
            pla_pre = IIf(pla_pre <> "", pla_pre, " ")

            querystring = "INSERT INTO Contratos (nro_con,ide_con,obj_con,pro_con,FEC_SUS_CON,PLA_EJE_CON,DEP_CON,VIG_CON,STIP_CON,EST_CON,tip_con,val_con,cod_con,cod_sec,tip_for,COD_TPRO,OTR_CNS,IDE_REP,NRO_PLA_CON, Urg_Man, Est_Conv,pro_sel_nro,dep_pcon,val_apo_gob,ANTICIPO,NEMPLEOS,PER_APO,AGOTAR_PPTO,TIPO_PLAZO,TIPO_PLAZO2,PLAZO2_EJE_CON,DEP_SUP) VALUES(:nro_con,:ide_con,:obj_con,:pro_con,:FEC_SUS_CON,:PLA_EJE_CON,:DEP_CON,:VIG_CON,:STIP_CON,:EST_CON,:tip_con,to_number(:val_con),:cod_con,:cod_sec,:tip_for,:COD_TPRO,:OTR_CNS,:IDE_REP,:NRO_PLA_CON,:Urg_Man,:Est_Conv,:pro_sel_nro,:dep_pcon,to_number(:val_apo_gob),:ANTICIPO,:NEMPLEOS,:PER_APO,:AGOTAR_PPTO,:TIPO_PLAZO,:TIPO_PLAZO2,:PLAZO2_EJE_CON,:DEP_SUP)"
            'querystring = "INSERT INTO Contratos (nro_con,ide_con,obj_con,pro_con,FEC_SUS_CON,PLA_EJE_CON,DEP_CON,VIG_CON,STIP_CON,EST_CON,tip_con,val_con,cod_con,cod_sec,tip_for,COD_TPRO,OTR_CNS,IDE_REP,NRO_PLA_CON, Urg_Man, Est_Conv,pro_sel_nro,dep_pcon,val_apo_gob,ANTICIPO,NEMPLEOS,PER_APO,AGOTAR_PPTO) VALUES(:nro_con,:ide_con,:obj_con,:pro_con,:FEC_SUS_CON,:PLA_EJE_CON,:DEP_CON,:VIG_CON,:STIP_CON,:EST_CON,:tip_con,to_number(:val_con),:cod_con,:cod_sec,:tip_for,:COD_TPRO,:OTR_CNS,:IDE_REP,:NRO_PLA_CON,:Urg_Man,:Est_Conv,:pro_sel_nro,:dep_pcon,to_number(:val_apo_gob),:ANTICIPO,:NEMPLEOS,:PER_APO,:AGOTAR_PPTO)"
            Me.CrearComando(querystring)

            Me.AsignarParametroDecimal(":nro_con", nro)
            Me.AsignarParametroCadena(":ide_con", ide)
            Me.AsignarParametroCadena(":obj_con", obj)
            Me.AsignarParametroCadena(":pro_con", pro)
            Me.AsignarParametroFecha(":FEC_SUS_CON", fsus)
            Me.AsignarParametroDecimal(":PLA_EJE_CON", pla)
            Me.AsignarParametroCadena(":DEP_CON", dep)
            Me.AsignarParametroDecimal(":VIG_CON", vigencia)
            Me.AsignarParametroCadena(":STIP_CON", stip)
            Me.AsignarParametroCadena(":EST_CON", "00") 'Radicado
            Me.AsignarParametroCadena(":tip_con", tip)
            'Me.AsignarParametroCadena(":val_con", val_con.ToString.Replace(",", "."))
            Me.AsignarParametroDecimal(":val_con", val_con)
            Me.AsignarParametroCadena(":cod_con", cod_con) 'será quitado
            Me.AsignarParametroCadena(":cod_sec", cod_sec)
            Me.AsignarParametroCadena(":tip_for", tip_for)
            Me.AsignarParametroCadena(":COD_TPRO", tip_proc)
            Me.AsignarParametroCadena(":OTR_CNS", cc) 'será modificado
            Me.AsignarParametroCadena(":IDE_REP", ide_rep)
            Me.AsignarParametroCadena(":NRO_PLA_CON", pla_pre)
            ' Me.AsignarParametroCadena(":usuario", Me.usuario) '---desde bd agregar en triggers
            Me.AsignarParametroCadena(":Urg_Man", UM)
            Me.AsignarParametroCadena(":Est_Conv", EC)
            Me.AsignarParametroCadena(":pro_sel_nro", Pro_Sel_Nro) ',:dep_pcon,:val_apo_gob
            Me.AsignarParametroCadena(":dep_pcon", dep_pcon)
            'Me.AsignarParametroCadena(":val_apo_gob", val_apo_gob.ToString.Replace(",", "."))
            Me.AsignarParametroDecimal(":val_apo_gob", val_apo_gob)
            Me.AsignarParametroCadena(":ANTICIPO", Pacto_Anticipo) '' 25 DE ENERO DE 2011
            Me.AsignarParametroCadena(":NEMPLEOS", NEMPLEOS.ToString.Replace(",", ".")) '' 25 DE ENERO DE 2011
            Me.AsignarParametroCadena(":PER_APO", PerApo) '' 25 DE ENERO DE 2011
            Me.AsignarParametroCadena(":AGOTAR_PPTO", Ag_Ppto) '' 25 DE ENERO DE 2011
            'Throw New Exception(TIPO_PLAZO)
            Me.AsignarParametroCadena(":TIPO_PLAZO", TIPO_PLAZO) ' EL DIA 23 de Abril de 2012, Boris Gonzalez
            Me.AsignarParametroCadena(":TIPO_PLAZO2", TIPO_PLAZO2) ' EL DIA 23 de Abril de 2012, Boris Gonzalez
            Me.AsignarParametroCadena(":PLAZO2_EJE_CON", PLAZO2_EJE_CON) ' EL DIA 23 de Abril de 2012, Boris Gonzalez
            'Agregado por Boris el 27 de Enero de 2012
            Me.AsignarParametroCadena(":DEP_SUP", Dep_Sup) ' EL DIA 23 de Abril de 2012, Boris Gonzalez

            '
            'ANTICIPO,NEMPLEOS,PER_APO
            'Throw New Exception(Me.vComando.CommandText)
            'AGREGAR EL CONTRATO A LA BD
            Me.EjecutarComando()

            querystring = "UPDATE NroConVig Set Nro_Act_con=:Nro_Act_con Where year_vig=:year_vig and cod_tip=:cod_tip"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Nro_Act_con", nro)
            Me.AsignarParametroCadena(":year_vig", vigencia)
            Me.AsignarParametroCadena(":cod_tip", tip)
            'ACTUALIZAR EL NUMERO DE CONSECUTIVO
            Me.EjecutarComando()

            'ASOCIAR LOS MUNICIPIOS A LOS CONTRATOS
            For i = 0 To nm
                querystring = "INSERT INTO ConMun(Cod_Mun,nro_con)VALUES('" + Mun(i) + "','" + Me.NroCon + "') "
                CrearComando(querystring)
                EjecutarComando()
            Next i

            Msg = "Se Agrego un Nuevo Contrato Nº" + Me.NroCon
            'f.InsAud(Me.dbConnection, t, "Contratos", Msg, usuario)
            Me.ConfirmarTransaccion()
            Msg = MsgOk + "<br>" + Msg
            lErrorG = False
        Catch ex As Exception
            Me.CancelarTransaccion()
            Msg = ex.Message
            lErrorG = True
        Finally
            Desconectar()
        End Try

        Return Msg

    End Function
    ''' <summary>
    ''' Consutla de Contratos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Contratos "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Consulta de la Fecha del Ultimo Documento Radicado por Tipo (Contrato o COnvenio)
    ''' Creacion: 10 Enero de 2011 en SIRCC 2011.
    ''' Requiere Iniciar Session Antes
    ''' </summary>
    ''' <param name="ult_fec_sus"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UltFecSus(ByRef ult_fec_sus As Date) As Boolean
        querystring = "SELECT fec_sus_con FROM Contratos Where Tip_Con=:cod_tip And Vig_Con=:VigCon Order By fec_sus_con desc"
        CrearComando(querystring)
        Me.AsignarParametroCadena(":cod_tip", Me.Tip_Con)
        Me.AsignarParametroCadena(":VigCon", Me.Vigencia)
        Dim c As Boolean = False
        Dim datat As DataTable = EjecutarConsultaDataTable()
        If datat.Rows.Count > 0 Then
            ult_fec_sus = CDate(datat.Rows(0)("fec_sus_con").ToString)
            c = True
        End If
        Return c
    End Function

    ''' <summary>
    ''' Consulta de Municipios del Contrato por codigo de contrato
    ''' </summary>
    ''' <param name="cod_con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetConMun(ByVal COD_CON As String) As DataTable
        Conectar()
        querystring = "SELECT MUNICIPIOS.COD_MUN , MUNICIPIOS.NOM_MUN,(SELECT CASE WHEN count(*)=0 THEN '0' ELSE '1' END AS EST FROM CONMUN WHERE  NRO_CON=:COD_CON and cod_mun=MUNICIPIOS.cod_mun) EST  FROM MUNICIPIOS "
        CrearComando(querystring)
        AsignarParametroCadena(":COD_CON", COD_CON)
        Dim datatb As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        Return datatb

    End Function
    ''' <summary>
    ''' Requiere haber abierto conexión. Ing Boris Fecha 5 de febrero de 2011.
    ''' </summary>
    ''' <param name="cod_tip"></param>
    ''' <param name="Vigencia"></param>
    ''' <param name="UltFsus"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function UltId(ByVal cod_tip As String, ByVal Vigencia As String, ByRef UltFsus As Date) As String

        Me.Conectar()

        Dim datat As New DataTable
        querystring = "SELECT cod_con,fec_sus_con FROM Contratos Where Tip_Con=:cod_tip and vig_con=to_number('" + Vigencia.ToString + "') Order By to_number(cod_con) desc"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_tip", cod_tip)
        Dim c As String
        datat = EjecutarConsultaDataTable()
        If datat.Rows.Count > 0 Then
            c = datat.Rows(0)("cod_con").ToString
            UltFsus = datat.Rows(0)("fec_sus_con").ToString
        Else
            c = "Ninguno"
            UltFsus = New Date(Vigencia, "01", "01")
        End If
        Me.Desconectar()
        Return c

    End Function


    Public Function UltFecSus(ByVal cod_tip As String, ByRef ult_fec_sus As Date, ByVal vigencia As String) As Boolean

        Me.Vigencia = vigencia
        Me.Tip_Con = cod_tip
        Return UltFecSus(ult_fec_sus)

    End Function

    ''' <summary>
    ''' Genera número de Contratos, en Formato AAAATTCCCC
    ''' A->Año, T->Tipo 02-Contrato,03-Convenio,C-> Consecutivo
    ''' </summary>
    ''' <param name="tip"></param>
    ''' <param name="nro_con"></param>
    ''' <param name="vigencia"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCodigo(ByVal tip As String, ByVal nro_con As String, ByVal vigencia As String) As String

        Dim ncon As New Vigencias()
        If nro_con.Length < 10 Then
            Return Right(vigencia, Contratos.Dig_Vigencia) + tip.ToString + Right("0000" + nro_con.ToString, 4)
        Else
            Return nro_con
        End If

    End Function


    ''' Clase Update con Parametros
    ''' Fecha Creación:10 de Oct de 2010
    '''  BORIS EL 21 DE MAYO DEL 2011
    ''' MODIFICADO EL 23 ABRIL DEL 2012 X BORIS
    Public Function UpdateP(ByVal cod_con As String, ByVal ide As String, ByVal obj As String, ByVal pro As String, ByVal fsus As Date, ByVal pla As Integer, ByVal dep As String, ByVal stip As String, ByVal tip As String, ByVal val_con As Decimal, ByVal Mun() As String, ByVal nm As Integer, ByVal cod_sec As String, ByVal tip_for As String, ByVal cc As String, ByVal tip_proc As String, ByVal pla_pre As String, ByVal ide_rep As String, ByVal Urg_man As Boolean, ByVal Est_Conv As Boolean, ByVal Pro_Sel_Nro As String, ByVal dep_pcon As String, ByVal val_apo_gob As Decimal, ByVal ANTICIPO As Boolean, ByVal NEMPLEOS As Integer, ByVal PER_APO As Boolean, ByVal Agotar_Ppto As Boolean, ByVal PLAZO2_EJE_CON As String, ByVal TIPO_PLAZO As String, ByVal TIPO_PLAZO2 As String, Dep_Sup As String) As String
        Dim gac As String = ""

        Me.NroCon = cod_con

        Dim UM As String = IIf(Urg_man = True, "1", "0")
        Dim EC As String = IIf(Est_Conv = True, "1", "0")

        Dim PerApo As String = IIf(PER_APO = True, "1", "0")
        Dim Pacto_Anticipo As String = IIf(ANTICIPO = True, "1", "0")
        Dim Ag_Ppto As String = IIf(Agotar_Ppto = True, "1", "0")

        'Dim Fecp As Date
        Try
            Me.Conectar()
            Me.ComenzarTransaccion()
            Dim i As Integer

            gac = IIf(gac <> "", gac, " ")
            pla_pre = IIf(pla_pre <> "", pla_pre, " ")
            'EST_CON,VIGENCIA NRO TIP CON COD CON


            querystring = "UPDATE Contratos set ide_con=:ide_con ,obj_con=:obj_con,pro_con=:pro_con,PLA_EJE_CON=:PLA_EJE_CON,DEP_CON=:DEP_CON,STIP_CON=:STIP_CON,val_con=:val_con,cod_sec=:cod_sec,tip_for=:tip_for,COD_TPRO=:COD_TPRO,OTR_CNS=:OTR_CNS,IDE_REP=:IDE_REP,NRO_PLA_CON=:NRO_PLA_CON, Urg_Man=:Urg_Man, Est_Conv=:Est_Conv,pro_sel_nro=:pro_sel_nro,dep_pcon=:dep_pcon,val_apo_gob=:val_apo_gob,ANTICIPO=:ANTICIPO,NEMPLEOS=:NEMPLEOS,PER_APO=:PER_APO,AGOTAR_PPTO=:AGOTAR_PPTO,TIPO_PLAZO=:TIPO_PLAZO,TIPO_PLAZO2=:TIPO_PLAZO2, PLAZO2_EJE_CON=:PLAZO2_EJE_CON,Dep_Sup=:Dep_Sup  WHERE COD_CON=:cod_con_pk "
            Me.CrearComando(querystring)

            Me.AsignarParametroCadena(":ide_con", ide)
            Me.AsignarParametroCadena(":obj_con", obj)
            Me.AsignarParametroCadena(":pro_con", pro)

            Me.AsignarParametroCadena(":PLA_EJE_CON", pla)
            Me.AsignarParametroCadena(":DEP_CON", dep)

            Me.AsignarParametroCadena(":STIP_CON", stip)

            Me.AsignarParametroDecimal(":val_con", val_con) 'OJO


            Me.AsignarParametroCadena(":cod_sec", cod_sec)
            Me.AsignarParametroCadena(":tip_for", tip_for)
            Me.AsignarParametroCadena(":COD_TPRO", tip_proc)
            Me.AsignarParametroCadena(":OTR_CNS", cc)  'será modificado
            Me.AsignarParametroCadena(":IDE_REP", ide_rep)
            Me.AsignarParametroCadena(":NRO_PLA_CON", pla_pre)
            Me.AsignarParametroCadena(":Urg_Man", UM)
            Me.AsignarParametroCadena(":Est_Conv", EC)
            Me.AsignarParametroCadena(":pro_sel_nro", Pro_Sel_Nro)
            Me.AsignarParametroCadena(":dep_pcon", dep_pcon)

            '21 DE MAYO DE 2011     BGR

            Me.AsignarParametroDecimal(":val_apo_gob", val_apo_gob)

            Me.AsignarParametroCadena(":cod_con_pk", cod_con) 'será quitado
            Me.AsignarParametroCadena(":ANTICIPO", Pacto_Anticipo)   ' EL DIA 25 de enero de 2011, Boris Gonzalez
            Me.AsignarParametroCadena(":NEMPLEOS", NEMPLEOS.ToString.Replace(",", ".")) ' EL DIA 25 de enero de 2011, Boris Gonzalez
            Me.AsignarParametroCadena(":PER_APO", PerApo) ' EL DIA 25 de enero de 2011, Boris Gonzalez
            Me.AsignarParametroCadena(":AGOTAR_PPTO", Ag_Ppto) ' EL DIA 25 de enero de 2011, Boris Gonzalez

            Me.AsignarParametroCadena(":TIPO_PLAZO", TIPO_PLAZO) ' EL DIA 23 de Abril de 2011, Boris Gonzalez
            Me.AsignarParametroCadena(":TIPO_PLAZO2", TIPO_PLAZO2) ' EL DIA 23 de Abril de 2011, Boris Gonzalez
            Me.AsignarParametroCadena(":PLAZO2_EJE_CON", PLAZO2_EJE_CON) ' EL DIA 23 de Abril de 2011, Boris Gonzalez

            'Enero 27 de 2012,
            Me.AsignarParametroCadena(":Dep_Sup", Dep_Sup) ' EL DIA 23 de Abril de 2011, Boris Gonzalez

            'AGREGAR EL CONTRATO A LA BD
            'Throw New Exception(Me._Comando.CommandText)
            EjecutarComando()
            querystring = "DELETE FROM ConMun WHERE Nro_Con='" + cod_con + "' "
            Me.CrearComando(querystring)
            EjecutarComando()
            'ASOCIAR LOS MUNICIPIOS A LOS CONTRATOS
            For i = 0 To nm
                querystring = "INSERT INTO ConMun(Cod_Mun,nro_con)VALUES('" + Mun(i) + "','" + cod_con + "') "
                Me.CrearComando(querystring)
                EjecutarComando()
            Next i
            Msg = "Se Actualizó La Información del Contrato Nº" + Me.NroCon
            'f.InsAud(Me.dbConnection, t, "Contratos", msg, usuario)
            ConfirmarTransaccion()
            Msg = MsgOk + "<br>" + Msg
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            lErrorG = True
        Finally
            Desconectar()
        End Try

        Return Msg

    End Function
    ''' <summary>
    ''' Consulta de contratos por llave primaria, filtrando por dependencia delegada asociada.
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkD(ByVal Cod_Con As String) As DataTable
        Me.NroCon = Cod_Con
        Me.Conectar()
        querystring = "SELECT * FROM VCONTRATOSC_A2_2012 Where numero =:cod_con And Dep_pCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo ) "
        Me.CrearComando(querystring)

        AsignarParametroCadena(":cod_con", Cod_Con)
        Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Consulta de contratos por llave primaria, filtrando por dependencia necesidad asociada.
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkF(ByVal Cod_Con As String) As DataTable
        GetFiltro_Contrato()
        If FiltroC = FiltroContratos.DepDel Then
            'Throw New Exception("Entro por DepDel:" + FiltroC.ToString)
            Return GetByPkD(Cod_Con)
        ElseIf FiltroC = FiltroContratos.DepNec Then
            'Throw New Exception("Entro por DepNec:" + FiltroC.ToString)
            Return GetByPkN(Cod_Con)
        Else
            'Throw New Exception("Entro por Todos:" + FiltroC.ToString)
            Return GetByPk(Cod_Con)
        End If

    End Function

    ''' <summary>
    ''' Consulta de contratos por llave primaria, filtrando por dependencia necesidad asociada.
    ''' 2 / NOVIEMBRE DE 2012
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkDelegada(ByVal Cod_Con As String) As DataTable
            Return GetByPkD(Cod_Con)
    End Function
    ''' <summary>
    ''' Consulta de contratos por llave primaria, filtrando por dependencia necesidad asociada.
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkN(ByVal Cod_Con As String) As DataTable
        Me.NroCon = Cod_Con
        Me.Conectar()
        querystring = "SELECT * FROM VCONTRATOSC_A2_2012 Where numero =:cod_con And Dep_Con In (SELECT cod_dep FROM vdepter WHERE ide_ter_abo=:ide_ter_abo ) "

        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", Cod_Con)
        Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)

        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Consulta de contratos por llave primaria
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPk(ByVal Cod_Con As String) As DataTable
        Me.NroCon = Cod_Con
        Me.Conectar()
        Dim dataTb As DataTable = GetByIde(Cod_Con)
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Consulta de Contratos por Código de Contratos, require Conexion Abierta
    ''' SE MODIFICA LA VISTA DE LA CUAL SE OBTIENEN LOS DATOS
    ''' CON EL FIN DE SINCRONIZAR--->ING. ERIC MARTINEZ--->15 DE ABRIL DE 2011
    ''' NO SE OBTIENES TODOS LOS DATOS, SE MODIFICA LA VISTA A LA QUE SE ACCEDE PARA QUE SE MUESTRE EL DETALLE DE LOS PLAZOS DE EJECUCION
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetByIde(ByVal Cod_Con As String) As DataTable
        'VCONTRATOSC_A2
        querystring = "SELECT * FROM VCONTRATOSC_A2_2012 Where numero =:cod_con"

        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", Cod_Con)
        Return EjecutarConsultaDataTable()
    End Function

    Function GetByPKEncargado(ByVal Cod_Con As String) As DataTable
        Me.NroCon = Cod_Con
        Me.Conectar()
        querystring = "SELECT * FROM VCONTRATOSC_A2 Where numero =:cod_con and Encargado=:Encargado"

        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", Cod_Con)
        AsignarParametroCadena(":Encargado", Me.usuario)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Debe haber conexion a la base de datos
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetTablaByIde(ByVal Cod_Con As String) As DataTable
        Dim queryString As String = "SELECT * FROM Contratos Where cod_con =:cod_con"
        Me.CrearComando(queryString)
        AsignarParametroCadena(":cod_con", Cod_Con)
        Return EjecutarConsultaDataTable()
    End Function

    ' Campos de Exoneración de Impuestos
    ' Fecha 1 de marzo 2010
    ' Autor: Boris Gonzalez 
    ' Se agrega el campo de fecha de aprobación de la poliza
    ''' <summary>
    ''' Registrar la exoneracion de impuesto, Colocar el Observacion el detalle
    ''' </summary>
    ''' <param name="cod_con"></param>
    ''' <param name="Exo_Imp"></param>
    ''' <param name="Exo_Obs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdExoImp(ByVal cod_con As String, ByVal Exo_Imp As Boolean, ByVal Exo_Obs As String) As String


        Dim EI As String = IIf(Exo_Imp = True, "1", "0")
        Try
            Me.Conectar()
            querystring = "Update Contratos Set Exo_Imp=:Exo_Imp, Exo_Obs=:Exo_Obs WHERE  cod_con=:cod_con"
            Me.CrearComando(querystring)
            AsignarParametroCadena(":cod_con", cod_con)
            AsignarParametroCadena(":Exo_Obs", Exo_Obs)
            AsignarParametroCadena(":Exo_Imp", EI)
            EjecutarComando()
            Msg = "Se exonero del pago de impuesto " + cod_con
            'f.InsAud(Me.dbConnection, t, "Contratos", msg, usuario)
            ConfirmarTransaccion()
            Msg = MsgOk + "<br>" + Msg
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function


    Public Function CederContratos(ByVal COD_CON As String, ByVal NIT_ANT As String, ByVal NIT_NUE As String, ByVal FEC_CES As String, ByVal PLA_CES As Integer, ByVal VAL_CES As Decimal, ByVal RES_AUT As String, ByVal FEC_RES As Date) As String

        Try
            Conectar()
            ComenzarTransaccion()


            ',:NIT_ANT,
            querystring = "INSERT INTO CESIONES(NIT_ANT,NIT_NUE,PLA_CES,VAL_CES,FEC_CES,RES_AUT,COD_CON,FEC_RES)VALUES(:NIT_ANT,:NIT_NUE,TO_NUMBER(:PLA_CES),TO_NUMBER(:VAL_CES),TO_DATE(:FEC_CES,'dd/mm/yyyy'),:RES_AUT,:COD_CON,to_date(:FEC_RES,'dd/mm/yyyy'))"
            CrearComando(querystring)
            'Throw New Exception(NIT_ANT)
            AsignarParametroCadena(":NIT_ANT", NIT_ANT)
            AsignarParametroCadena(":NIT_NUE", NIT_NUE)
            AsignarParametroCadena(":PLA_CES", PLA_CES)
            AsignarParametroCadena(":VAL_CES", VAL_CES)
            AsignarParametroCadena(":FEC_CES", FEC_CES)
            AsignarParametroCadena(":RES_AUT", RES_AUT)
            AsignarParametroCadena(":COD_CON", COD_CON)
            AsignarParametroCadena(":FEC_RES", FEC_RES)
            EjecutarComando()

            querystring = "UPDATE CONTRATOS SET IDE_CON =:NIT_NUE,IDE_REP=:NIT_NUE WHERE COD_CON=:COD_CON"
            CrearComando(querystring)
            AsignarParametroCadena(":COD_CON", COD_CON)
            AsignarParametroCadena(":NIT_NUE", NIT_NUE)
            AsignarParametroCadena(":NIT_NUE", NIT_NUE)
            EjecutarComando()

            Msg = "Se registro la Cesión al Contrato " + COD_CON
            'f.InsAud(Me.dbConnection, t, "Contratos", msg, usuario)
            ConfirmarTransaccion()
            Msg = MsgOk + "<br>" + Msg
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSql(ByVal cSql As String) As System.Data.DataTable
        Conectar()
        CrearComando(cSql)
        Dim datat As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        Return datat

    End Function


    ''' <summary>
    ''' Consutla de HContratos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetHContratos(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM HContratos Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
