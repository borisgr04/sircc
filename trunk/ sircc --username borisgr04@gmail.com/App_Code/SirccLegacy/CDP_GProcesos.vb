Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class CDP_GProcesos
    Inherits BDDatos


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM cdp_gprocesos "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Num_Pcon As String, ByVal Nro_Cdp As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM cdp_gprocesos Where Num_GProc=:Num_Pcon And Nro_Cdp=:Nro_Cdp And Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Pcon", Num_Pcon)
        Me.AsignarParametroCadena(":Nro_Cdp", Nro_Cdp)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Num_Pcon As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM cdp_gprocesos Where Num_GProc=:Num_Pcon And Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Pcon", Num_Pcon)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function Insert(ByVal Num_Pcon As String, ByVal Nro_Cdp As String, ByVal Fec_Cdp As Date, ByVal val_cdp As Decimal, ByVal Grupo As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO cdp_gprocesos(Num_GProc, Nro_Cdp,FEC_CDP,VAL_CDP, Grupo)VALUES(:Num_PCon, :Nro_Cdp,:FEC_CDP,:VAL_CDP, :Grupo) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_PCon", Num_Pcon)
            Me.AsignarParametroEntero(":Nro_Cdp", Nro_Cdp)
            Me.AsignarParametroFecha(":FEC_CDP", Fec_Cdp)
            Me.AsignarParametroDecimal(":VAL_CDP", val_cdp)
            Me.AsignarParametroCadena(":Grupo", Grupo)
            Me.num_reg = Me.EjecutarComando()
            'SincronizarValor(Num_Pcon, Nro_Cdp, Grupo)
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

    Public Sub SincronizarValor(ByVal Num_Pcon As String, ByVal Nro_Cdp As String, ByVal Grupo As String)
        querystring = "Update cdp_gprocesos c Set Val_Cdp =(Select Nvl(Sum(Valor),0) From Rubros_GProcesos Where Num_Pro=c.Num_GProc And Nro_Cdp=c.Nro_Cdp) Where c.Num_GProc=:Num_PCon And c.Nro_Cdp =:Nro_Cdp  And c.Grupo=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_PCon", Num_Pcon)
        Me.AsignarParametroEntero(":Nro_Cdp", Nro_Cdp)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Me.num_reg = Me.EjecutarComando()
    End Sub

    Public Function Delete(ByVal Nro_Cdp As String, ByVal Num_Pro As String, ByVal Grupo As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM cdp_gprocesos WHERE Num_GProc=:Num_PCOn AND Nro_Cdp=:Nro_Cdp And Grupo=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_PCOn", Num_Pro)
            Me.AsignarParametroCadena(":Nro_Cdp", Nro_Cdp)
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