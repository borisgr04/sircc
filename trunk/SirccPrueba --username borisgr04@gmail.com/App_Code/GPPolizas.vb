Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Public Class GPPolizas
    Inherits BDDatos
    Sub New()
        Me.Tabla = "PPolizas"
        Me.Vista = "VGPPolizas"
        Me.VistaDB = "VGPPolizas"
    End Sub

    ''' <summary>
    ''' Consulta de estados de actividad
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyTproc(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VGPPolizasMIN Where Num_Proc=:Num_Proc And Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPK(ByVal Num_Proc As String, ByVal Cod_Pol As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VGPPolizas Where Num_Proc=:Num_Proc and Cod_Pol=:Cod_Pol and Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function Insert(ByVal Cod_Pol As String, ByVal Num_Proc As String, ByVal por_SMMLV As String, ByVal Cal_Apartirde As String, ByVal Vigencia As String, ByVal Apartirde As String, ByVal Tipo As String, ByVal Grupo As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO GPPolizas(Num_Proc, Cod_Pol, por_SMMLV, Cal_Apartirde, Vigencia, Apartirde, Tipo, Grupo)VALUES(:Num_Proc, :Cod_Pol, :por_SMMLV, :Cal_Apartirde, :Vigencia, :Apartirde,:Tipo, :Grupo)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
            Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
            Me.AsignarParametroCadena(":por_SMMLV", por_SMMLV)
            Me.AsignarParametroCadena(":Cal_Apartirde", Cal_Apartirde)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
            Me.AsignarParametroCadena(":Apartirde", Apartirde)
            Me.AsignarParametroCadena(":Tipo", Tipo)
            Me.AsignarParametroCadena(":Grupo", Grupo)
            'Throw New Exception(_Comando.CommandText)
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
    Public Function Delete(ByVal Cod_Pol As String, ByVal Num_Proc As String, ByVal Grupo As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM GPPolizas WHERE Num_Proc=:Num_Proc AND Cod_Pol=:Cod_Pol And Grupo=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
            Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
            Me.AsignarParametroCadena(":Grupo", Grupo)
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
End Class
