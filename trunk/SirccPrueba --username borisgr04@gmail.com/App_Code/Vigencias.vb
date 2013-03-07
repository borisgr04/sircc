Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel


<System.ComponentModel.DataObject()> _
Public Class Vigencias
    Inherits BDDatos

    Private Año_Vigencia As String
    Private cod_Estado As String

    Public Property Vigencia() As String
        Get
            Return Año_Vigencia
        End Get
        Set(ByVal value As String)
            Año_Vigencia = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return cod_Estado
        End Get
        Set(ByVal value As String)
            cod_Estado = value
        End Set
    End Property
    Public Sub New()

        Me.Tabla = "VIGENCIAS"
        Me.Vista = "VIGENCIAS"
        Me.VistaDB = "VVigenciasDB"
        'Order by Vig_Cod desc
    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCons(ByVal Vig As String) As DataTable
        Me.Conectar()
        querystring = "select cvg.*,to_char(fec_sus_con,'dd/mm/yyyy') ""Fecha Suscripción"" from vConsVig cvg Inner Join Contratos On Numero=Cod_Con Where Vigencia=:Vigencia"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Vigencia", Vig)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByPK(ByVal Vig As String) As DataTable
        Me.Conectar()
        querystring = "select * from Vigencias Where Year_Vig=:Vigencia"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Vigencia", Vig)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCons(ByVal Vig As String, ByVal Tipo As String) As DataTable
        Me.Conectar()
        querystring = "select cvg.*,to_char(fec_sus_con,'dd/mm/yyyy') ""Fecha Suscripción"" from vConsVig cvg Inner Join Contratos On Numero=Cod_Con Where Vigencia=:Vigencia And tip_con=:tipo"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Vigencia", Vig)
        AsignarParametroCadena(":tipo", Tipo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    ''' <summary>
    ''' Retorna las vigencias en Orden descendentes
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        querystring = "SELECT * FROM  " + Vista + " Order By Year_Vig Desc "

        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
    '<DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Año As String, ByVal fechaI As Date, ByVal fechaF As Date, ByVal Porcentaje As Integer, ByVal estado As String, ByVal radAut As String) As String
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "INSERT INTO VIGENCIAS(YEAR_VIG,FEC_INI_VIG,FEC_FIN_VIG,POR_ADI_VIG,EST_VIG,RAD_AUT) VALUES(:YEAR_VIG,to_date(:FEC_INI_VIG,'dd/mm/yyyy'),to_date(:FEC_FIN_VIG,'dd/mm/yyyy'),:POR_ADI_VIG,:EST_VIG,:RAD_AUT)"
            CrearComando(querystring)
            Me.AsignarParametroCadena(":YEAR_VIG", Año)
            Me.AsignarParametroCadena(":FEC_INI_VIG", fechaI.ToShortDateString)
            Me.AsignarParametroCadena(":FEC_FIN_VIG", fechaF.ToShortDateString)
            Me.AsignarParametroCadena(":POR_ADI_VIG", Porcentaje)
            Me.AsignarParametroCadena(":EST_VIG", estado)
            Me.AsignarParametroCadena(":RAD_AUT", radAut)
            Me.num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Update(ByVal Pk As String, ByVal Año As String, ByVal fechaI As Date, ByVal fechaF As Date, ByVal Porcentaje As Integer, ByVal estado As String, ByVal radAut As String) As String
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "UPDATE VIGENCIAS SET YEAR_VIG=:YEAR_VIG,FEC_INI_VIG=to_date(:FEC_INI_VIG,'dd/mm/yyyy'),FEC_FIN_VIG=to_date(:FEC_FIN_VIG,'dd/mm/yyyy'),POR_ADI_VIG=:POR_ADI_VIG,EST_VIG=:EST_VIG,RAD_AUT=:RAD_AUT WHERE YEAR_VIG=:YEAR_VIG_PK"
            CrearComando(querystring)
            Me.AsignarParametroCadena(":YEAR_VIG", Año)
            Me.AsignarParametroCadena(":FEC_INI_VIG", fechaI.ToShortDateString)
            Me.AsignarParametroCadena(":FEC_FIN_VIG", fechaF.ToShortDateString)
            Me.AsignarParametroCadena(":POR_ADI_VIG", Porcentaje)
            Me.AsignarParametroCadena(":EST_VIG", estado)
            Me.AsignarParametroCadena(":RAD_AUT", radAut)
            Me.AsignarParametroCadena(":YEAR_VIG_PK", Pk)
            Me.num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    '<DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Delete(ByVal Año As String) As String
        Me.Conectar()
        Me.ComenzarTransaccion()
        Try
            Me.querystring = "DELETE FROM VIGENCIAS  WHERE YEAR_VIG=:YEAR_VIG"
            CrearComando(querystring)
            Me.AsignarParametroCadena(":YEAR_VIG", Año)
            Me.EjecutarComando()
            Me.Msg = MsgOk
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    ''' <summary>
    ''' Sin Conexion
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetActiva_s() As String

        Me.CrearComando("SELECT Year_Vig FROM  Vigencias Where Est_Vig='ABIERTA' order by year_vig desc")
        Dim dataTb As DataTable = New DataTable
        dataTb = Me.EjecutarConsultaDataTable()

        Return dataTb.Rows(0)(0).ToString
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
      Public Function GetActiva() As String
        Me.Conectar()
        Me.CrearComando("SELECT Year_Vig FROM  Vigencias Where Est_Vig='ABIERTA' order by year_vig desc")
        Dim dataTb As DataTable = New DataTable
        dataTb = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb.Rows(0)(0).ToString
    End Function

    Public Function GetVigenciaA() As String
        Me.Conectar()
        Me.CrearComando("SELECT Year_Vig FROM  Vigencias Where Est_Vig='ABIERTA' order by year_vig desc")
        Dim dataTb As DataTable = New DataTable
        dataTb = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb.Rows(0)(0).ToString
    End Function
    ''' <summary>
    ''' Leer Vigencia, Requiere Conexión Abierta. Boris G. Fecha: 15  Enero 2011
    ''' </summary>
    ''' <param name="VIG_COD"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByIde(ByVal VIG_COD As String) As DataTable
        Me.CrearComando("SELECT * FROM  Vigencias Where Est_Vig='ABIERTA' order by year_vig desc")
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Return dataTb
    End Function

    Public Function Update(ByVal Vig_Cod As String, ByVal VIG_EST As String) As String
        'Dim na As String
        'Me.AbrirDB()
        'Try
        '    Dim dbCommand As New OracleCommand
        '    dbCommand.Connection = dbConnection
        '    dbCommand.CommandText = "UPDATE Vigencia SET VIG_EST='" + VIG_EST + "' WHERE VIG_COD='" + Vig_Cod + "'"
        '    na = dbCommand.ExecuteNonQuery()
        '    Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"

        '    Me.lErrorG = False
        'Catch exo As OracleException
        '    Me.lErrorG = True
        '    Me.Msg = "Error de Datos:" + exo.Message
        'Catch ex As Exception
        '    Me.lErrorG = True
        '    Me.Msg = "Error de App:" + ex.Message
        'Finally
        '    Me.CerrarBD()
        'End Try
        Return Msg
    End Function

    Public Function TRALADAR_CONF(ByVal vig_para As String, ByVal tabla As String) As String

        'Dim na As Integer
        'Me.AbrirDB()
        'Try

        '    Dim dbCommand As New OracleCommand
        '    dbCommand.Connection = dbConnection
        '    dbCommand.CommandText = "Config.TRASLADAR_CONF"
        '    dbCommand.CommandType = CommandType.StoredProcedure
        '    dbCommand.Parameters.Add("vig_para", OracleDbType.Varchar2, ParameterDirection.Input).Value = vig_para
        '    dbCommand.Parameters.Add("tbla", OracleDbType.Varchar2, ParameterDirection.Input).Value = tabla
        '    na = dbCommand.ExecuteNonQuery()
        '    Me.Msg = MsgOk + "Traslado de " + tabla
        '    Me.lErrorG = False
        'Catch exo As OracleException
        '    Me.lErrorG = True
        '    Me.Msg = "Error de Datos:" + exo.Message
        'Catch ex As Exception
        '    Me.lErrorG = True
        '    Me.Msg = "Error de App:" + ex.Message
        'Finally
        '    Me.CerrarBD()
        'End Try

        'Me.CerrarBD()
        Return Msg

    End Function
    ''' <summary>
    ''' Retorma el Consecutivo Actual para el Contrato/COnvenio en la fecha actual
    ''' Autor: Boris Fecha. 10 de Enero 2010
    ''' </summary>
    ''' <param name="tip"></param>
    ''' <param name="año"></param>
    ''' <param name="nro"></param>
    ''' <remarks></remarks>
    Sub GetNroConByIdeVig(ByVal tip As String, ByVal año As Integer, ByRef nro As Integer)
        querystring = "SELECT * FROM NroCon Where est_vig='ABIERTA' And cod_tip=:cod_tip and year_vig=:year_vig"
        CrearComando(querystring)
        AsignarParametroCadena(":cod_tip", tip)
        AsignarParametroCadena(":year_vig", año.ToString)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        nro = CInt(dt.Rows(0)("nro_act_con"))
    End Sub


    ''' <summary>
    ''' Retoirna el tipo de radicacion
    ''' </summary>
    ''' <param name="year"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTipo_Radicación(ByVal year As Integer) As Boolean
        Me.Conectar()
        querystring = "SELECT Rad_Aut FROM Vigencias Where year_vig=:year_vig"
        CrearComando(querystring)
        AsignarParametroCadena(":year_vig", year)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Return IIf(dt.Rows(0)("Rad_Aut") = "1", True, False)
        Me.Desconectar()
    End Function


End Class



