Imports Microsoft.VisualBasic
Imports System.Data.Common
Imports System.ComponentModel
Imports System.Data


Public Class EntSegSocial
    Inherits BDDatos

    'Dim mVigencia As String
    ''Dim mCodigo As Long
    'Dim mInformes As String
    ''Dim mDescripcion As String
    'Dim mFechaI As Date
    'Dim mFechaF As Date
    'Dim mTipoRecordatorio As String
    'Dim mRecordatorio As Date
    'Dim mDestinatario As String


    Dim mCodigo As Long
    Dim mDescripcion As String
    Dim mEstado As String
    Dim mTipo As String




    Sub New()
        Me.Tabla = "INTENTSEGSOCIAL"
        Me.Vista = "vINTENTSEGSOCIAL" ' where estado="AC"
        Me.VistaDB = "vINTENTSEGSOCIALDB" ' sin filtro
    End Sub

   

    Public Property Codigo As Long
        Get
            Return mCodigo
        End Get
        Set(ByVal value As Long)
            mCodigo = value
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

    Public Property Estado As String
        Get
            Return mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
        End Set
    End Property
    Public Property Tipo As String
        Get
            Return mTipo
        End Get
        Set(ByVal value As String)
            mTipo = value
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
    Public Function GetbyPk(ByVal Pk As String) As Boolean
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where Cod_Ent=" + Pk
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Me.Codigo = dataTb.Rows(0)("Cod_Ent")
            Me.Descripcion = dataTb.Rows(0)("Nom_Ent")
            Me.Estado = dataTb.Rows(0)("Est_Ent")
            Me.Tipo = dataTb.Rows(0)("Tipo_Ent")
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

            querystring = "INSERT INTO INTENTSEGSOCIAL (COD_ENT,  NOM_ENT, TIPO_ENT, EST_ENT) VALUES"
            querystring += " (:CODIGO,:DESCRIPCION,:TIPO,:ESTADO)"

            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":CODIGO", Codigo)
            Me.AsignarParametroCadena(":DESCRIPCION", Descripcion)
            Me.AsignarParametroCadena(":TIPO", Tipo)
            Me.AsignarParametroCadena(":ESTADO", Estado)


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

    Function Delete(ByVal Cod_Ent As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM  INTEntSegSocial WHERE  Cod_Ent=:Cod_Ent"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Ent", Cod_Ent)

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
    Public Function Update(ByVal PK1 As String) As String
        Conectar()
        Try
            querystring = "UPDATE INTEntSegSocial SET Nom_Ent=:Nom_Ent,Tipo_Ent=:Tipo_Ent,EST_ENT=:EST_ENT "
            querystring += "WHERE Cod_Ent=:PK1"

            Me.CrearComando(querystring)

            Dim Nom_Ent As String
            Nom_Ent = Descripcion
            Me.AsignarParametroCadena(":Nom_Ent", Nom_Ent)
            Me.AsignarParametroCadena(":Tipo_Ent", Tipo)
            Me.AsignarParametroCadena(":EST_ENT", Estado)
            Me.AsignarParametroCadena(":PK1", PK1)



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
        'Me.Conectar()
        'querystring = "SELECT * FROM txtAlertas Where Vigencia=to_char(sysdate,'yyyy')" ' Where Codigo=" + Pk
        'Me.CrearComando(querystring)
        'Dim dataTb As DataTable = EjecutarConsultaDataTable()
        'Me.Desconectar()
        'Return dataTb
    End Function
End Class
