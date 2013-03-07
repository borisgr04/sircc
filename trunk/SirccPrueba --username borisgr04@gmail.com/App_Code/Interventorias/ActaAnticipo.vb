Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data.Common
Imports System.Data


Public Class ActaAnticipo
    Inherits ActasSupervision

    Sub New()
        'Estado Final que genera el Documento
        Me.Est_Fin = "08"

        ''Para Manejo de Tbla de Item de Anticipo
        Me.Tabla = "INTANT_CONT"
        Me.Vista = "VINTANT_CONT" ' where estado="AC"
        Me.VistaDB = "VINTANT_CONTDB" ' sin filtro


    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Overloads Function Insert(ByVal cod_con As String, ByVal est_ini As String, ByVal est_fin As String, ByVal fec_ent As Date, ByVal obs As String, ByVal val_pago As Decimal) As String

        Dim oCon As New Contratos

        Dim tbCon As New DataTable
        Dim fecsus As Date, fecentant As Date, fecaprpol As Date
        Dim estfinant As String
        Me.lErrorG = True
        Conectar()
        ComenzarTransaccion()
        oCon.Conexion = Me.Conexion
        ' VALIDACION DE FECHA DE SUSCRIPCION
        tbCon = oCon.GetByIde(cod_con)
        fecsus = CDate(tbCon.Rows(0)("fec_sus_con").ToString)
        If fecsus > fec_ent Then
            Msg = "La Fecha del Acta debe ser mayor a la Fecha de Suscripción"
            Return Msg
            Exit Function
        End If
        If GetEnBorrador(cod_con) > 0 Then
            Msg = "Existe un Acta/Documento en Borrador, debe Confirmarlo para Continuar con otro Documento"
            Return Msg
            Exit Function
        End If

        fecaprpol = CDate(tbCon.Rows(0)("fec_apr_pol").ToString)
        If fecaprpol > fec_ent Then
            Msg = "La Fecha del Acta debe ser mayor a la Fecha de Aprobación de la Póliza"
            Return Msg
            Exit Function
        End If

        ' VALIDACION DE FECHA DE SUSCRIPCION
        tbCon = Me.GetEstByIdep(cod_con)
        If tbCon.Rows.Count > 0 Then
            fecentant = CDate(tbCon.Rows(0)("fec_ent").ToString)
            If fecentant > fec_ent Then
                Msg = "La Fecha del Acta debe ser mayor a la Fecha del Acta Anterior :" + fecentant.ToShortDateString
                Return Msg
                Exit Function
            End If
            estfinant = tbCon.Rows(0)("est_fin").ToString
            If estfinant <> est_ini Then
                Msg = "El Estado Final Actual no Coincide el Nuevo Estado Inicial "
                Return Msg
                Exit Function
            End If
        End If

        Try
            querystring = "INSERT INTO EstContratos (cod_con,est_ini,est_fin,fec_ent,usuario,fec_reg,obs_est,val_pago,nvisitas,por_eje_fis,estado,cla_doc) "
            querystring += " Values(:cod_con,:est_ini,:est_fin,to_date(:fec_ent,'dd/mm/yyyy'),user,sysdate,:obs_est,:val_pago,to_number(:nvisitas),:por_eje_fis,:estado,:cla_doc)"
            CrearComando(querystring)

            AsignarParametroCadena(":cod_con", cod_con)
            AsignarParametroCadena(":est_ini", est_ini)
            AsignarParametroCadena(":est_fin", est_fin)
            AsignarParametroCadena(":fec_ent", fec_ent)
            AsignarParametroCadena(":obs_est", obs)
            AsignarParametroDecimal(":val_pago", val_pago)
            AsignarParametroCadena(":nvisitas", 0)
            AsignarParametroCadena(":estado", "BO")
            AsignarParametroCadena(":cla_doc", "GD") 'Clase de Documento
            AsignarParametroDecimal(":por_eje_fis", 0)

            num_reg = EjecutarComando()

            'Cuando se inserta en Borrador No de Cambiar el Estado del Contrato
            'querystring = "UPDATE Contratos Set est_con='" & est_fin & "' Where cod_con='" & cod_con & "'"
            'CrearComando(querystring)
            'num_reg = EjecutarComando()
            'f.InsAud(Me.dbConnection, t, "CONTRATOS", "REGISTRO DE ACTA/CAMBIO DE ESTADO", Me.usuario)

            ConfirmarTransaccion()
            Msg = MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        Finally
            Desconectar()
        End Try


        Return Msg

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Overloads Function Update(ByVal ID As String, ByVal fec_ent As Date, ByVal Obs As String, ByVal val_pago As Decimal) As String
        Return Me.Update(ID, fec_ent, Obs, val_pago, 0, 0)
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetIdbyCod_con(ByVal cod_con As String) As String
        Dim id_cont1 As String
        Me.Conectar()
        querystring = "SELECT MAX(ID) as ID FROM VGESACTAS WHERE (NRO_CONTRATO = :cod_con)  and estado <>'AN'"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod_con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        id_cont1 = dataTb.Rows(0)("ID")
        Me.Desconectar()
        Return id_cont1
    End Function

#Region "Región de Items Plan del Anticipo"

    Dim mID_CONT As Long
    Dim mCOD_INVAN As String
    Dim mVAL_INVAN As Long
    Dim mVPORCENT As Decimal
    Dim mEST_INVAN_CONT As String

  
    Public Property ID_CONT As Long
        Get
            Return mID_CONT
        End Get
        Set(ByVal value As Long)
            mID_CONT = value
        End Set
    End Property

    Public Property COD_INVAN As String
        Get
            Return mCOD_INVAN
        End Get
        Set(ByVal value As String)
            mCOD_INVAN = value
        End Set
    End Property
    Public Property VPORCENT As Decimal
        Get
            Return mVPORCENT
        End Get
        Set(ByVal value As Decimal)
            mVPORCENT = value
        End Set
    End Property
    Public Property VAL_INVAN As Long
        Get
            Return mVAL_INVAN
        End Get
        Set(ByVal value As Long)
            mVAL_INVAN = value
        End Set
    End Property

    Public Property EST_INVAN_CONT As String
        Get
            Return mEST_INVAN_CONT
        End Get
        Set(ByVal value As String)
            mEST_INVAN_CONT = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista
        Me.CrearComando(querystring)
        ' Me.AsignarParametroCadena(":VIGENCIA", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecordsDB() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista
        Me.CrearComando(querystring)
        ' Me.AsignarParametroCadena(":VIGENCIA", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsDBbyPk1(ByVal Pk As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where ID_CONT=" + Pk
        Me.CrearComando(querystring)
        ' Me.AsignarParametroCadena(":VIGENCIA", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPkID1(ByVal Pk As String, ByVal ID As String) As Boolean
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where ID_CONT=" + ID + "and COD_INVAN=" + Pk
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Me.ID_CONT = dataTb.Rows(0)("ID_CONT")
            Me.COD_INVAN = dataTb.Rows(0)("COD_INVAN")
            Me.VAL_INVAN = dataTb.Rows(0)("VAL_INVAN")
            Me.VPORCENT = Convert.ToDecimal(dataTb.Rows(0)("VPORCENT"))
            Me.EST_INVAN_CONT = dataTb.Rows(0)("EST_INVAN_CONT")

            Return True
        Else
            Return False
        End If
    End Function
    'GetbyPk

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert1() As String
        Conectar()
        Try
            querystring = "INSERT INTO INTANT_CONT (ID_CONT, COD_INVAN,VAL_INVAN,VPORCENT,EST_INVAN_CONT) VALUES"
            querystring += " (:ID_CONT,:COD_INVAN,:VAL_INVAN,:VPORCENT,:EST_INVAN_CONT)"

            Me.CrearComando(querystring)

            Me.AsignarParametroEntero(":ID_CONT", ID_CONT)
            Me.AsignarParametroCadena(":COD_INVAN", COD_INVAN)
            Me.AsignarParametroCadena(":VAL_INVAN", VAL_INVAN)
            Me.AsignarParametroDecimal(":VPORCENT", VPORCENT)
            Me.AsignarParametroCadena(":EST_INVAN_CONT", EST_INVAN_CONT)
            'Throw New Exception(Me.vComando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try

        Return Msg
    End Function

    Function Delete1(ByVal ID_CONT As String, ByVal PK2 As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM INTANT_CONT WHERE ID_CONT=:ID_CONT AND COD_INVAN=:PK2"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":ID_CONT", ID_CONT)
            Me.AsignarParametroCadena(":PK2", PK2)

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


    '(ID_CONT, COD_INVAN,VAL_INVAN,VPORCENT,EST_INVAN_CONT)
    Public Function Update1(ByVal PK1 As String, ByVal PK2 As String) As String
        Me.Conectar()
        Try
            querystring = "UPDATE INTANT_CONT SET VAL_INVAN=:VAL_INVAN,VPORCENT=:VPORCENT,EST_INVAN_CONT=:EST_INVAN_CONT "
            querystring += "WHERE ID_CONT=:PK1 AND COD_INVAN=:PK2"

            Me.CrearComando(querystring)



            Me.AsignarParametroEntero(":PK1", PK1)
            Me.AsignarParametroEntero(":PK2", PK2)
            Me.AsignarParametroCadena(":VAL_INVAN", VAL_INVAN)
            Me.AsignarParametroDecimal(":VPORCENT", VPORCENT)
            Me.AsignarParametroCadena(":EST_INVAN_CONT", EST_INVAN_CONT)


            Me.num_reg = Me.EjecutarComando()

            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try

        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSUMbyPkI(ByVal ID As String) As Long
        Me.Conectar()
        querystring = "SELECT Nvl(SUM(VAL_INVAN),0) as SVAL_INVAN FROM " + Me.Vista + " Where ID_CONT=" + ID + " and EST_INVAN_CONT='AC'"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb.Rows(0)("SVAL_INVAN")
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetAnticipos(ByVal ID As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where ID_CONT=" + ID
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb

    End Function
    Public Function UpdatePorcentajes(ByVal PK1 As String, ByVal PK2 As String, ByVal VPORCENT1 As Decimal) As String
        Me.Conectar()
        Try
            querystring = "UPDATE INTANT_CONT SET VPORCENT=:VPORCENT "
            querystring += "WHERE ID_CONT=:PK1 AND COD_INVAN=:PK2"
            Me.CrearComando(querystring)
            Me.AsignarParametroEntero(":PK1", PK1)
            Me.AsignarParametroEntero(":PK2", PK2)
            Me.AsignarParametroDecimal(":VPORCENT", VPORCENT1)
            Me.num_reg = Me.EjecutarComando()
            Me.Msg = Me.MsgOk
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try

        Return Msg
    End Function


#End Region

    
End Class


