Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Public Class CalculoPol
    Inherits BDDatos
    Sub New()
        Me.Tabla = "CalculoPol"
        Me.Vista = "CalculoPol"
        Me.VistaDB = "CalculoPol"
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
    Public Function Insert(ByVal Cod_Cal As String, ByVal Descripcion As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO CalculoPol(Cod_Cal, Descripcion)VALUES(:Cod_Cal, :Descripcion) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Cal", Cod_Cal)
            Me.AsignarParametroCadena(":Descripcion", Descripcion)

            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
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

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal Cod_Cal_O As String, ByVal Cod_Cal As String, ByVal Descripcion As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE CalculoPol SET Cod_Cal=:Cod_Cal, Descripcion=:Descripcion WHERE Cod_Cal=:Cod_Cal_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Cal", Cod_Cal)
            Me.AsignarParametroCadena(":Descripcion", Descripcion)
            Me.AsignarParametroCadena(":Cod_Cal_O", Cod_Cal_O)

            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
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

    Function Delete(ByVal Cod_Cal As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM CalculoPol WHERE Cod_Cal=:Cod_Cal"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Cal", Cod_Cal)

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
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Cod_Cal As String) As DataTable
        querystring = "SELECT * FROM  CalculoPol Where Cod_Cal=:Cod_Cal"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Cal", Cod_Cal)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
End Class
