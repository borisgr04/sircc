Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class PagoSS
    Inherits BDDatos

    Dim mCod_Con As String
    Dim mCod_Tip_ESS As String
    Dim mPlanillaN As String
    Dim mVal_Apo As Decimal
    Dim mMes_Pag As String
    Dim mYear_Pag As String
    Dim mTip_Pla As String
    Dim mObs As String
    Dim mId As String
    Dim mNro_Doc As Long

    Dim mlstAdj As New List(Of ArchivosT)()

    Public Property lstAdj As List(Of ArchivosT)
        Get
            Return mlstAdj
        End Get
        Set(value As List(Of ArchivosT))
            mlstAdj = value
        End Set
    End Property

    Sub New()
        Me.Tabla = "Int_PagoSS"
        Me.Vista = "Int_PagoSS" ' where estado="AC"
        Me.VistaDB = "Int_PagoSS" ' sin filtro
    End Sub

    Public Property Cod_Con As String
        Get
            Return mCod_Con
        End Get
        Set(ByVal value As String)

            mCod_Con = value
        End Set
    End Property

    Property Cod_Tip_ESS As String
        Get
            Return mCod_Tip_ESS
        End Get
        Set(value As String)
            mCod_Tip_ESS = value
        End Set
    End Property

    Property PlanillaN As String
        Get
            Return mPlanillaN
        End Get
        Set(value As String)
            mPlanillaN = value
        End Set
    End Property

    Property Obs As String
        Get
            Return mObs
        End Get
        Set(value As String)
            mObs = value
        End Set
    End Property

    Property Val_Apo As String
        Get
            Return mVal_Apo
        End Get
        Set(value As String)
            mVal_Apo = value
        End Set
    End Property
    Property Mes_Pag As String
        Get
            Return mMes_Pag
        End Get
        Set(value As String)
            mMes_Pag = value
        End Set
    End Property
    Property Year_Pag As String
        Get
            Return mYear_Pag
        End Get
        Set(value As String)
            mYear_Pag = value
        End Set
    End Property
    Property Tip_Pla As String
        Get
            Return mTip_Pla
        End Get
        Set(value As String)
            mTip_Pla = value
        End Set
    End Property

    Property Id As String
        Get
            Return mId
        End Get
        Set(value As String)
            mId = value
        End Set
    End Property

    Property Nro_Doc As String
        Get
            Return mNro_Doc
        End Get
        Set(value As String)
            mNro_Doc = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "select * from Int_PagoSS Inner Join IntTipo_ESS On Cod_Tip_Ess=Cod_Tip Where Cod_Con=:Cod_Con And Estado='AC'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        'Throw New Exception(Me.vComando.CommandText)
        Me.Desconectar()
        Return dataTb
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(Cod_Con As String, ByVal Id As String) As Boolean
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Tabla + " Where  ID=" + Id + " And Cod_Con=" + Cod_Con
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Cod_Con = dataTb.Rows(0)("COD_CON")
            Cod_Tip_ESS = dataTb.Rows(0)("COD_TIP_ESS")
            PlanillaN = dataTb.Rows(0)("PLANILLAN")
            Val_Apo = dataTb.Rows(0)("VAL_APO")
            Mes_Pag = dataTb.Rows(0)("MES_PAGO")
            Year_Pag = dataTb.Rows(0)("YEAR_PAGO")
            Id = dataTb.Rows(0)("ID")
            Nro_Doc = dataTb.Rows(0)("Nro_Doc")
            Obs = dataTb.Rows(0)("Obs")
            Return True
        Else
            Return False
        End If
    End Function
    'GetbyPk

    Private Function UltNum() As Integer
        querystring = "SELECT Nvl(Max(ID),0) ID  FROM " + Tabla + " WHERE COD_CON=:COD_CON"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":COD_CON", Cod_Con)
        Id = Convert.ToInt32(Me.EjecutarEscalar()) + 1
        Return Id
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert() As String
        Conectar()
        Try
            ComenzarTransaccion()
            Id = UltNum()
            querystring = "INSERT INTO " + Tabla + " (ID,COD_CON,COD_TIP_ESS,PLANILLAN,VAL_APO, MES_PAGO,TIPO_PLA,YEAR_PAGO,NRO_DOC,USBD,USAP,FEC_REG,OBS) VALUES"
            querystring += " (:ID,:COD_CON,:COD_TIP_ESS,:PLANILLAN,:VAL_APO, :MES_PAGO,:TIPO_PLA,:YEAR_PAGO,:NRO_DOC,USER,:USAP,SYSDATE,:OBS)"
            Me.CrearComando(querystring)

            Me.AsignarParametroCadena(":COD_CON", Cod_Con)
            Me.AsignarParametroCadena(":COD_TIP_ESS", Cod_Tip_ESS)
            Me.AsignarParametroCadena(":PLANILLAN", PlanillaN)
            Me.AsignarParametroDecimal(":VAL_APO", Val_Apo)
            Me.AsignarParametroCadena(":MES_PAGO", Mes_Pag)
            Me.AsignarParametroCadena(":YEAR_PAGO", Year_Pag)
            Me.AsignarParametroCadena(":ID", Id)
            Me.AsignarParametroCadena(":TIPO_PLA", Tip_Pla)
            Me.AsignarParametroCadena(":NRO_DOC", Nro_Doc)
            Me.AsignarParametroCadena(":USAP", Me.usuario)
            Me.AsignarParametroCadena(":OBS", Obs)
            'Throw New Exception(Me.vComando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            'num_reg = Adjuntar(1)
            ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Adjuntos Agregados [" + Me.num_reg.ToString + "]"
            lErrorG = False

        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message

        Finally
            Desconectar()
        End Try
        Return Msg
    End Function

    Function Adjuntar(Id As Integer) As Integer
        Dim msg0 As String = ""
        For Each archivo In lstAdj
            querystring = "INSERT INTO Int_InCo_Sop (ID,COD_CON,NUM_INF,CONTENT,ICONO, NOMARC,SOPORTE,USAP,USBD,FEC_REG) VALUES"
            querystring += " (:ID,:COD_CON,:NUM_INF,:CONTENT,:ICONO, :NOMARC,:SOPORTE,:USAP,USER,SYSDATE)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":ID", Id)
            Me.AsignarParametroCadena(":COD_CON", Cod_Con)
            Me.AsignarParametroCadena(":NUM_INF", Id)
            Me.AsignarParametroCadena(":CONTENT", archivo.Content)
            Me.AsignarParametroCadena(":ICONO", archivo.Icono)
            Me.AsignarParametroCadena(":NOMARC", archivo.NomArchivo)
            Me.AsignarParametroBLOB(":SOPORTE", archivo.SoporteB)
            Me.AsignarParametroCadena(":USAP", Me.usuario)
            num_reg += Me.EjecutarComando()
            'msg0 += "<br/>" + Me.vComando.CommandText
            'Throw New Exception(Me.vComando.CommandText)
            Id += 1
        Next
        'Throw New Exception(msg0)
        Return num_reg
    End Function

    Function Anular(ByVal COd_Con As String, ID As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE " + Tabla + " SET ESTADO='AN' WHERE COD_CON=:COD_CON AND ID=:ID"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_CON", COd_Con)
            Me.AsignarParametroCadena(":ID", Id)
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



    Public Function Update(ByVal PK_COD_CON As String, PK_ID As String) As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            
            querystring = "UPDATE " + Tabla + " SET COD_TIP_ESS=:COD_TIP_ESS,PLANILLAN=:PLANILLAN,VAL_APO=:VAL_APO, MES_PAGO=:MES_PAGO,TIPO_PLA=:TIPO_PLA,YEAR_PAGO=:YEAR_PAGO,NRO_DOC=:NRO_DOC,USBDM=USER,USAPM=:USAP,FEC_MOD=SYSDATE,OBS=:OBS "
            querystring += "WHERE COD_CON=:COD_CON_PK AND ID=:ID_PK"
            Me.CrearComando(querystring)

            Me.AsignarParametroCadena(":COD_CON_PK", PK_COD_CON)
            Me.AsignarParametroCadena(":ID_PK", PK_ID)
            Me.AsignarParametroCadena(":COD_TIP_ESS", Cod_Tip_ESS)
            Me.AsignarParametroCadena(":PLANILLAN", PlanillaN)
            Me.AsignarParametroDecimal(":VAL_APO", Val_Apo)
            Me.AsignarParametroCadena(":MES_PAGO", Mes_Pag)
            Me.AsignarParametroCadena(":YEAR_PAGO", Year_Pag)
            Me.AsignarParametroCadena(":TIPO_PLA", Tip_Pla)
            Me.AsignarParametroCadena(":NRO_DOC", Nro_Doc)
            Me.AsignarParametroCadena(":USAP", Me.usuario)
            Me.AsignarParametroCadena(":OBS", Obs)
            'Throw New Exception(Me.vComando.CommandText)
            Me.num_reg = Me.EjecutarComando()

            'querystring = "Select Nvl(Max(Id),0) new_Id From Int_InCo_Sop Where Cod_Con=:COD_CON And Num_Inf=:NUM_INF"
            'Me.CrearComando(querystring)
            'Me.AsignarParametroCadena(":COD_CON", Cod_Con)
            'Me.AsignarParametroCadena(":NUM_INF", Num_Inf)
            'Dim Id As Integer = CInt(Me.EjecutarEscalar()) + 1
            'num_reg = Adjuntar(Id)

            ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Soportes Adicionados [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message + ex.StackTrace
        Finally
            Desconectar()
        End Try

        Return Msg
    End Function



    ''' <summary>
    ''' Consulta de contratos por llave primaria, filtrando por dependencia necesidad asociada.
    ''' </summary>
    ''' <param name="Cod_Con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkS(ByVal Cod_Con As String) As DataTable

        Me.Conectar()
        querystring = "SELECT * FROM vcontratos_sinc_p Where numero =:cod_con and Numero In (Select Cod_Con from INTERVENTORES_CONTRATO where ide_int=:ide_int And Est_int='AC') "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":cod_con", Cod_Con)
        Me.AsignarParametroCadena(":ide_int", Me.usuario)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetSoporte(ByVal Cod_Con As String, Num_Inf As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Int_InCo_Sop Where Cod_Con =:Cod_Con And Num_Inf =:Num_Inf And Sop_Est='AC' "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Con", Cod_Con)
        Me.AsignarParametroCadena(":Num_Inf", Num_Inf)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function AnularSoporte(ByVal Cod_Con As String, Id As String) As String
        Try
            Me.Conectar()
            querystring = "UPDATE Int_PagoSS Set Estado='AN' Where Cod_Con =:Cod_Con And ID =:ID And Estado='AC' "
            Me.CrearComando(querystring)
            AsignarParametroCadena(":Cod_Con", Cod_Con)
            AsignarParametroCadena(":ID", Id)
            num_reg = EjecutarComando()
            Me.Msg = Me.MsgOk + " Soporte Anulados [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message + ex.StackTrace
        Finally
            Desconectar()
        End Try

        Return Msg
    End Function

    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    'Public Overloads Function GetSoporte(ByVal Cod_Con As String, Num_Inf As String, Id As String) As DataTable
    '    Me.Conectar()
    '    querystring = "SELECT * FROM Int_InCo_Sop Where Cod_Con =:Cod_Con And Num_Inf =:Num_Inf And Sop_Est='AC' And Id =:ID "
    '    Me.CrearComando(querystring)
    '    AsignarParametroCadena(":Cod_Con", Cod_Con)
    '    Me.AsignarParametroCadena(":Num_Inf", Num_Inf)
    '    Me.AsignarParametroCadena(":Id", Id)
    '    Dim dataTb As DataTable = EjecutarConsultaDataTable()
    '    Me.Desconectar()
    '    Return dataTb
    'End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetTipoEntidad() As DataTable
        Dim queryString As String = "Select * from inttipo_ess Where Est_Tip='AC'"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

End Class
