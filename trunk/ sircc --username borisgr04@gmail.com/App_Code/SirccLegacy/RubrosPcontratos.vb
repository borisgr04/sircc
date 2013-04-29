﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class RubrosPcontratos
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "RUBROS_PCONTRATOS"
        Me.Vista = "VRUBROS_PCONTRATOS"
        Me.VistaDB = "VRUBROS_PCONTRATOS"

    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        querystring = "SELECT * FROM  " + Vista
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyNum_Proc(ByVal Num_Proc As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Vista + " Where Num_Pro=:Num_Proc"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function Insert(ByVal Cod_Rub As String, ByVal Num_Pro As String, ByVal Valor As String, ByVal Nro_RP As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Rubros_Pcontratos(Cod_Rub, Num_Pro, Valor, Nro_Cdp)VALUES(:Cod_Rub, :Num_Pro, :Valor, :Nro_Cdp) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Rub", Cod_Rub)
            Me.AsignarParametroCadena(":Num_Pro", Num_Pro)
            Me.AsignarParametroCadena(":Valor", Valor)
            Me.AsignarParametroCadena(":Nro_Cdp", Nro_RP)
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
    Public Function Delete(ByVal Cod_Rub As String, ByVal Num_Pro As String) As String
        Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Rubros_Pcontratos WHERE Num_Pro=:Num_Pro AND Cod_Rub=:Cod_Rub "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Rub", Cod_Rub)
            Me.AsignarParametroCadena(":Num_Pro", Num_Pro)
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
