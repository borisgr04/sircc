Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Public Class Designaciones
    Inherits BDDatos

    Dim mCod_Con As String
    Property Cod_Con As String
        Get
            Return mCod_Con
        End Get
        Set(ByVal value As String)
            mCod_Con = value
        End Set
    End Property

    Dim mIde_Int As String
    Property Ide_Int As String
        Get
            Return mIde_Int
        End Get
        Set(ByVal value As String)
            mIde_Int = value
        End Set
    End Property

    Dim mTip_Int As String
    Property Tip_Int As String
        Get
            Return mTip_Int
        End Get
        Set(ByVal value As String)
            mTip_Int = value
        End Set
    End Property
    Dim mUsuario As String
    Property USAP As String
        Get
            Return mUsuario
        End Get
        Set(ByVal value As String)
            mUsuario = value
        End Set
    End Property
    Dim mEst_Int As String
    Property Est_Int As String
        Get
            Return mEst_Int
        End Get
        Set(ByVal value As String)
            mEst_Int = value
        End Set
    End Property
    Dim mObs_Int As String
    Property Obs_Int As String
        Get
            Return mObs_Int
        End Get
        Set(ByVal value As String)
            mObs_Int = value
        End Set
    End Property
    Dim mFec_Inicio As String
    Property Fec_Inicio As String
        Get
            Return mFec_Inicio
        End Get
        Set(ByVal value As String)
            mFec_Inicio = value
        End Set
    End Property
    Dim mFec_Fin As String
    Property Fec_Fin As String
        Get
            Return mFec_Fin
        End Get
        Set(ByVal value As String)
            mFec_Fin = value
        End Set
    End Property
    Dim mId_Apoyo As String
    Property Id_Apoyo As String
        Get
            Return mId_Apoyo
        End Get
        Set(ByVal value As String)
            mId_Apoyo = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPK(ByVal Numero As String) As DataTable
        Me.Conectar()

        querystring = "Select * From vContratos_sinc_p"
        querystring += " Where  Numero =:Numero"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Numero", Numero)
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetIntxContrato(ByVal Numero As String) As DataTable
        Me.Conectar()

        querystring = "Select * From vinterventores_contrato"
        querystring += " Where  Cod_Con =:Numero"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Numero", Numero)
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Public Function IntActivo(ByVal Numero As String) As Boolean
        Me.querystring = "Select count(*) cantidad from Interventores_Contrato where Cod_Con=:Numero and Est_Int='AC'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Numero", Numero)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        If CInt(dt.Rows(0)("cantidad").ToString()) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IntHabil(ByVal Numero As String, ByVal Ide_Int As String) As Boolean
        Me.querystring = "Select count(*) cantidad from Interventores_Contrato where Cod_Con=:Numero and Ide_Int=:Ide_Int and Est_Int='IN'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Numero", Numero)
        Me.AsignarParametroCadena(":Ide_Int", Ide_Int)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        If CInt(dt.Rows(0)("cantidad").ToString()) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Designar() As String
        Try
            Me.Conectar()
            If IntActivo(Me.Cod_Con) Then
                Throw New Exception("El contrato cuenta con un supervisor activo")
            Else
                querystring = "Insert into Interventores_Contrato(Ide_Int, Cod_Con, Tip_Int, Usuario, Est_Int, Fec_Inicio)values(:Id_Int, :Cod_Con, :Tip_Int, :Usuario, :Est_Int, :Fec_Inicio)"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Id_Int", Ide_Int)
                Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
                Me.AsignarParametroCadena(":Tip_Int", Tip_Int)
                Me.AsignarParametroCadena(":Usuario", Me.usuario)
                Me.AsignarParametroCadena(":Est_Int", "AC")
                Me.AsignarParametroCadena(":Fec_Inicio", CDate(Fec_Inicio).ToShortDateString)

                EjecutarComando()
                Msg = "Se designo el supervisor con exito"
                lErrorG = False
            End If
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Function Desabilitar() As String
        Try
            Me.Conectar()
            If IntHabil(Me.Cod_Con, Me.Ide_Int) Then
                Throw New Exception("El supervisor ya se encuentra desabilitado")
            Else
                querystring = "update Interventores_Contrato set Est_Int='IN', Obs_Int=:Obs_Int, Fec_Fin=:Fec_Fin where Cod_Con=:Cod_Con and Ide_Int=:Ide_Int"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Ide_Int", Ide_Int)
                Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
                Me.AsignarParametroCadena(":Obs_Int", Obs_Int)
                Me.AsignarParametroCadena(":Fec_Fin", CDate(Fec_Fin).ToShortDateString)

                EjecutarComando()
                Msg = "Se deshabilitó el supervisor con éxito"
                lErrorG = False
            End If
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
End Class
