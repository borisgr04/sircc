Imports Microsoft.VisualBasic
Imports System.Data.Common
Imports System.ComponentModel
Imports System.Data


Public Class PlanAnticipos
    Inherits BDDatos

    Dim mCodigo As Long
    Dim mNombre As String
    Dim mEstado As String

    Sub New()
        Me.Tabla = "INTINVAN"

        Me.Vista = "VINTINVAN" ' where estado="AC"
        Me.VistaDB = "VINTINVANDB" ' sin filtro

    End Sub

    Public Property Codigo As Long
        Get
            Return mCodigo
        End Get
        Set(ByVal value As Long)
            mCodigo = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return mNombre
        End Get
        Set(ByVal value As String)
            mNombre = value
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
        querystring = "SELECT * FROM " + Me.Vista + " Where COD_INVAN=" + Pk
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Me.Codigo = dataTb.Rows(0)("COD_INVAN")
            Me.Nombre = dataTb.Rows(0)("NOM_INVAN")
            Me.Estado = dataTb.Rows(0)("EST_INVAN")

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
            querystring = "INSERT INTO INTINVAN (COD_INVAN, NOM_INVAN, EST_INVAN) VALUES"
            querystring += " (:CODIGO,:NOMBRE,:ESTADO)"

            Me.CrearComando(querystring)

            Me.AsignarParametroEntero(":CODIGO", Codigo)
            Me.AsignarParametroCadena(":NOMBRE", Nombre)
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

    Function Delete(ByVal Codigo As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM INTINVAN WHERE COD_INVAN=:Codigo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Codigo", Codigo)

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
        Me.Conectar()
        Try
            querystring = "UPDATE INTINVAN SET NOM_INVAN=:Nombre,EST_INVAN=:Estado "
            querystring += "WHERE COD_INVAN=:PK1"

            Me.CrearComando(querystring)



            Me.AsignarParametroCadena(":Estado", Estado)
            Me.AsignarParametroCadena(":Nombre", Nombre)
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

    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    'Public Function GetbyTxt() As DataTable
    '    'Me.Conectar()
    '    'querystring = "SELECT * FROM txtAlertas Where Vigencia=to_char(sysdate,'yyyy')" ' Where Codigo=" + Pk
    '    'Me.CrearComando(querystring)
    '    'Dim dataTb As DataTable = EjecutarConsultaDataTable()
    '    'Me.Desconectar()
    '    'Return dataTb
    'End Function
End Class
