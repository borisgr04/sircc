Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class InfContratista
    'Int_InfoCont
    Inherits BDDatos

    Dim mCod_Con As Long
    Dim mFec_Inf As Date
    Dim mFec_Ini As Date
    Dim mFec_fin As Date
    Dim mCan_Hoj As Integer
    Dim mNum_Inf As Integer
    Dim mDes_Inf As String

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
        Me.Tabla = "Int_InfoCont"
        Me.Vista = "Int_InfoCont" ' where estado="AC"
        Me.VistaDB = "Int_InfoCont" ' sin filtro

    End Sub

    Public Property Cod_Con As String
        Get
            Return mCod_Con
        End Get
        Set(ByVal value As String)

            mCod_Con = value
        End Set
    End Property

    Public Property Num_Inf As Long
        Get
            Return mNum_Inf
        End Get
        Set(ByVal value As Long)
            mNum_Inf = value
        End Set
    End Property

    Public Property Fec_Inf As Date
        Get
            Return mFec_Inf
        End Get
        Set(ByVal value As Date)
            mFec_Inf = value
        End Set
    End Property

    Public Property Fec_Ini As Date
        Get
            Return mFec_Ini
        End Get
        Set(ByVal value As Date)
            mFec_Ini = value
        End Set
    End Property

    Public Property Fec_Fin As Date
        Get
            Return mFec_fin
        End Get
        Set(ByVal value As Date)
            mFec_fin = value
        End Set
    End Property

    Public Property Can_Hoj As Integer
        Get
            Return mCan_Hoj
        End Get
        Set(ByVal value As Integer)
            mCan_Hoj = value
        End Set
    End Property

    Public Property Des_Inf As String
        Get
            Return mDes_Inf
        End Get
        Set(value As String)
            mDes_Inf = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where Cod_Con=:Cod_Con and EST_INF<>'AN'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        'Throw New Exception(Me.vComando.CommandText)
        Me.Desconectar()
        Return dataTb
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Cod_Con As String, Num_Inf As String) As Boolean
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where COD_CON='" + Cod_Con + "' AND NUM_INF=" + Num_Inf
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Cod_Con = dataTb.Rows(0)("COD_CON")
            Num_Inf = dataTb.Rows(0)("NUM_INF")
            Fec_Inf = dataTb.Rows(0)("FEC_INF")
            Fec_Ini = dataTb.Rows(0)("FEC_INI")
            Fec_Fin = dataTb.Rows(0)("FEC_FIN")
            Can_Hoj = dataTb.Rows(0)("CAN_HOJ")
            Des_Inf = dataTb.Rows(0)("DES_INF").ToString
            Return True
        Else
            Return False
        End If
    End Function
    'GetbyPk

    Private Function UltNumInf() As Integer
        querystring = "SELECT Nvl(Max(NUM_INF),0) Num_Inf  FROM " + Tabla + " WHERE COD_CON=:COD_CON"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":COD_CON", Cod_Con)
        Num_Inf = Convert.ToInt32(Me.EjecutarEscalar()) + 1
        Return Num_Inf
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert() As String
        Conectar()
        Try
            ComenzarTransaccion()
            Num_Inf = UltNumInf()
            querystring = "INSERT INTO " + Tabla + " (COD_CON,FEC_INF,FEC_INI,FEC_FIN, CAN_HOJ,NUM_INF) VALUES"
            querystring += " (:COD_CON,:FEC_INF,:FEC_INI,:FEC_FIN, :CAN_HOJ,:NUM_INF)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_CON", Cod_Con)
            Me.AsignarParametroCadena(":NUM_INF", Num_Inf)
            Me.AsignarParametroFecha(":FEC_INF", Fec_Inf)
            Me.AsignarParametroFecha(":FEC_INI", Fec_Ini)
            Me.AsignarParametroFecha(":FEC_FIN", Fec_Fin)
            Me.AsignarParametroCadena(":CAN_HOJ", Can_Hoj)
            Me.num_reg = Me.EjecutarComando()
            num_reg = Adjuntar(1)
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
            Me.AsignarParametroCadena(":NUM_INF", Num_Inf)
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

    Function Anular(ByVal COd_Con As String, Num_Inf As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE " + Tabla + " SET EST_INF='AN' WHERE COD_CON=:COD_CON AND NUM_INF=:NUM_INF"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_CON", COd_Con)
            Me.AsignarParametroCadena(":NUM_INF", Num_Inf)
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



    Public Function Update(ByVal PK_COD_CON As String, PK_NUM_INF As String) As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            querystring = "UPDATE " + Tabla + " SET FEC_INF=:FEC_INF,FEC_INI=:FEC_INI,FEC_FIN=:FEC_FIN,CAN_HOJ=:CAN_HOJ,DES_INF=:DES_INF  "
            querystring += "WHERE COD_CON=:PK1 AND NUM_INF=:PK2"

            Me.CrearComando(querystring)

            Me.AsignarParametroCadena(":PK1", PK_COD_CON)
            Me.AsignarParametroCadena(":PK2", PK_NUM_INF)
            Me.AsignarParametroFecha(":FEC_INF", Fec_Inf)
            Me.AsignarParametroFecha(":FEC_INI", Fec_Ini)
            Me.AsignarParametroFecha(":FEC_FIN", Fec_Fin)
            Me.AsignarParametroCadena(":CAN_HOJ", Can_Hoj)
            Me.AsignarParametroCadena(":DES_INF", DES_INF)
            'Throw New Exception(Me.vComando.CommandText)
            Me.num_reg = Me.EjecutarComando()

            querystring = "Select Nvl(Max(Id),0) new_Id From Int_InCo_Sop Where Cod_Con=:COD_CON And Num_Inf=:NUM_INF"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_CON", Cod_Con)
            Me.AsignarParametroCadena(":NUM_INF", Num_Inf)
            Dim Id As Integer = CInt(Me.EjecutarEscalar()) + 1

            num_reg = Adjuntar(Id)
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

    ' ''' <summary>
    ' ''' Consulta de contratos por llave primaria, filtrando por dependencia necesidad asociada.
    ' ''' </summary>
    ' ''' <param name="Cod_Con"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    'Public Overloads Function GetByPk(ByVal Cod_Con As String, Num_Inf As String) As Boolean
    '    Me.Conectar()
    '    querystring = "SELECT * FROM " + Tabla + " Where numero =:cod_con and num_inf=:num_inf "
    '    Me.CrearComando(querystring)
    '    AsignarParametroCadena(":cod_con", Cod_Con)
    '    Me.AsignarParametroCadena(":num_inf", Num_Inf)
    '    Dim dataTb As DataTable = EjecutarConsultaDataTable()
    '    Me.Desconectar()
    '    If dataTb.Rows.Count > 0 Then
    '        'Me.Cod_Con = d
    '    Else
    '        Return False
    '    End If

    'End Function

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
    Public Overloads Function AnularSoporte(ByVal Cod_Con As String, Num_Inf As String, Id As String) As String
        Try
            Me.Conectar()
            querystring = "UPDATE Int_InCo_Sop Set Sop_Est='AN' Where Cod_Con =:Cod_Con And Num_Inf =:Num_Inf And Id=:Id And Sop_Est='AC' "
            Me.CrearComando(querystring)
            AsignarParametroCadena(":Cod_Con", Cod_Con)
            AsignarParametroCadena(":Id", Id)
            Me.AsignarParametroCadena(":Num_Inf", Num_Inf)
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

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetSoporte(ByVal Cod_Con As String, Num_Inf As String, Id As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Int_InCo_Sop Where Cod_Con =:Cod_Con And Num_Inf =:Num_Inf And Sop_Est='AC' And Id =:ID "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Con", Cod_Con)
        Me.AsignarParametroCadena(":Num_Inf", Num_Inf)
        Me.AsignarParametroCadena(":Id", Id)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
