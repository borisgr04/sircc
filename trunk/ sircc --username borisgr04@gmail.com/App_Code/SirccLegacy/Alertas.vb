Imports Microsoft.VisualBasic
Imports System.Data.Common
Imports System.ComponentModel
Imports System.Data


Public Class Alertas
    Inherits BDDatos

    Dim mVigencia As String
    Dim mCodigo As Long
    Dim mInformes As String
    Dim mDescripcion As String
    Dim mFechaI As Date
    Dim mFechaF As Date
    Dim mTipoRecordatorio As String
    Dim mRecordatorio As Date
    Dim mDestinatario As String
    Dim mEstado As String

    Sub New()
        Me.Tabla = "Alertas"
        Me.Tabla = "Alertas"
        Me.Vista = "Alertas"
    End Sub

    Public Property Vigencia As String
        Get
            Return mVigencia
        End Get
        Set(ByVal value As String)
            mVigencia = value
        End Set
    End Property

    Public Property Codigo As Long
        Get
            Return mCodigo
        End Get
        Set(ByVal value As Long)
            mCodigo = value
        End Set
    End Property

    Public Property Informes As String
        Get
            Return mInformes
        End Get
        Set(ByVal value As String)
            mInformes = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return mDescripcion
        End Get
        Set(ByVal value As String)
            mDescripcion = value
        End Set
    End Property

    Public Property FechaI As Date
        Get
            Return mFechaI
        End Get
        Set(ByVal value As Date)
            mFechaI = value
        End Set
    End Property

    Public Property FechaF As Date
        Get
            Return mFechaF
        End Get
        Set(ByVal value As Date)
            mFechaF = value
        End Set
    End Property

    Public Property TipoRecordatorio As String
        Get
            Return mTipoRecordatorio
        End Get
        Set(ByVal value As String)
            mTipoRecordatorio = value
        End Set
    End Property

    Public Property Recordatorio As String
        Get
            Return mRecordatorio
        End Get
        Set(ByVal value As String)
            mRecordatorio = value
        End Set
    End Property

    Public Property Destinatario As String
        Get
            Return mDestinatario
        End Get
        Set(ByVal value As String)
            mDestinatario = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Vigencia As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where Vigencia=:VIGENCIA"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":VIGENCIA", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Pk As String) As Boolean
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where Codigo=" + Pk
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Me.Codigo = dataTb.Rows(0)("Codigo")
            Me.Vigencia = dataTb.Rows(0)("Vigencia")
            Me.Recordatorio = dataTb.Rows(0)("Recordatorio")
            'Me.TipoRecordatorio = dataTb.Rows(0)("TipoRecordatorio")
            Me.Informes = dataTb.Rows(0)("Informes")
            Me.Destinatario = dataTb.Rows(0)("Destinatario")
            Me.Descripcion = dataTb.Rows(0)("Descripcion")
            Me.FechaI = dataTb.Rows(0)("FechaI")
            Me.FechaF = dataTb.Rows(0)("FechaF")
            Me.Estado = dataTb.Rows(0)("Estado")
            Return True
        Else
            Return False
        End If
    End Function
    'GetbyPk

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert() As String
        Conectar()
        Try
            querystring = "INSERT INTO ALERTAS (VIGENCIA, INFORMES, DESCRIPCION, FECHAI, FECHAF,RECORDATORIO, DESTINATARIO) VALUES"
            querystring += " (:VIGENCIA, :INFORMES,:DESCRIPCION, to_date(:FECHAI,'dd/mm/yyyy'),to_date(:FECHAF,'dd/mm/yyyy'),to_date(:RECORDATORIO,'dd/mm/yyyy'), :DESTINATARIO)"

            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":VIGENCIA", Vigencia)
            'Me.AsignarParametroEntero(":CODIGO", Codigo)
            Me.AsignarParametroCadena(":INFORMES", Informes)
            Me.AsignarParametroCadena(":DESCRIPCION", Descripcion)
            Me.AsignarParametroCadena(":FECHAI", FechaI)
            Me.AsignarParametroCadena(":FECHAF", FechaF)
            Me.AsignarParametroCadena(":RECORDATORIO", Recordatorio)
            Me.AsignarParametroCadena(":DESTINATARIO", Destinatario)
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


    Public Function Update(ByVal PK1 As String) As String
        Conectar()
        Try
            querystring = "UPDATE ALERTAS SET ESTADO=:ESTADO,VIGENCIA=:VIGENCIA, INFORMES=:INFORMES, DESCRIPCION=:DESCRIPCION, FECHAI=to_date(:FECHAI,'dd/mm/yyyy'), FECHAF=to_date(:FECHAF,'dd/mm/yyyy'), RECORDATORIO=:RECORDATORIO, DESTINATARIO=:DESTINATARIO "
            querystring += "WHERE CODIGO=:PK1"

            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":VIGENCIA", Vigencia)
            Me.AsignarParametroEntero(":PK1", PK1)
            Me.AsignarParametroCadena(":INFORMES", Informes)
            Me.AsignarParametroCadena(":DESCRIPCION", Descripcion)
            Me.AsignarParametroCadena(":FECHAI", FechaI)
            Me.AsignarParametroCadena(":FECHAF", FechaF)
            Me.AsignarParametroCadena(":ESTADO", Estado)

            Me.AsignarParametroCadena(":RECORDATORIO", Recordatorio)
            Me.AsignarParametroCadena(":DESTINATARIO", Destinatario)

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
    Public Function GetbyTxt() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM txtAlertas Where Vigencia=to_char(sysdate,'yyyy')" ' Where Codigo=" + Pk
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
