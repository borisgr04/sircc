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


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Pk1 As String, pk2 As String) As Boolean
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where COD_CON='" + Pk1 + "' AND NUM_INF=" + pk2
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
            querystring = "INSERT INTO " + Tabla + " (COD_CON,FEC_ENT,FEC_INI,FEC_FIN, CAN_HOJ) VALUES"
            querystring += " (:COD_CON,:FEC_ENT,:FEC_INI,:FEC_FIN, :CAN_HOJ)"

            Me.CrearComando(querystring)

            Me.AsignarParametroEntero(":COD_CON", Cod_Con)
            Me.AsignarParametroCadena(":FEC_INF", Fec_Inf)
            Me.AsignarParametroCadena(":FEC_INI", Fec_Ini)
            Me.AsignarParametroCadena(":FEC_FIN", Fec_Fin)
            Me.AsignarParametroCadena(":CAN_HOJ", Can_Hoj)

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

    Function Delete(ByVal Codigo As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM " + Tabla + " WHERE COD_CON=:COD_CON AND NUM_INF=:NUM_INF"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_CON", Cod_Con)
            Me.AsignarParametroCadena(":NUM_INF", NUM_INF)
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



    Public Function Update(ByVal PK1 As String, PK2 As String) As String
        Me.Conectar()
        Try
            querystring = "UPDATE " + Tabla + " SET FEC_INF=:FEC_INF,FEC_INI=:FEC_INI,FEC_FIN=:FEC_FIN,CAN_HOJ "
            querystring += "WHERE COD_CON=:PK1 AND NUM_INF=:PK2"

            Me.CrearComando(querystring)

            Me.AsignarParametroEntero(":PK1", Cod_Con)
            Me.AsignarParametroEntero(":PK2", Num_Inf)
            Me.AsignarParametroCadena(":FEC_INF", Fec_Inf)
            Me.AsignarParametroCadena(":FEC_INI", Fec_Ini)
            Me.AsignarParametroCadena(":FEC_FIN", Fec_Fin)
            Me.AsignarParametroCadena(":CAN_HOJ", Can_Hoj)

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


End Class
