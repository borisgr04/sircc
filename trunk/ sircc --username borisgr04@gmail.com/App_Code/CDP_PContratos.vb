Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class CDP_PContratos
    Inherits BDDatos


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM cdp_pcontratos "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Num_Pcon As String, ByVal Nro_Cdp As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM cdp_pcontratos Where Num_Pcon=:Num_Pcon And Nro_Cdp=:Nro_Cdp"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Pcon", Num_Pcon)
        Me.AsignarParametroCadena(":Nro_Cdp", Nro_Cdp)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Num_Pcon As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM cdp_pcontratos Where Num_Pcon=:Num_Pcon"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Pcon", Num_Pcon)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function Insert(ByVal Num_Pcon As String, ByVal Nro_Cdp As String, ByVal Fec_Cdp As Date, ByVal val_cdp As Decimal) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO CDP_PCONTRATOS(Num_PCon, Nro_Cdp,FEC_CDP,VAL_CDP)VALUES(:Num_PCon, :Nro_Cdp,:FEC_CDP,:VAL_CDP) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_PCon", Num_Pcon)
            Me.AsignarParametroEntero(":Nro_Cdp", Nro_Cdp)
            Me.AsignarParametroFecha(":FEC_CDP", Fec_Cdp)
            Me.AsignarParametroDecimal(":VAL_CDP", val_cdp)
            Me.num_reg = Me.EjecutarComando()
            SincronizarValor(Num_Pcon, Nro_Cdp)
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

    Public Sub SincronizarValor(ByVal Num_Pcon As String, ByVal Nro_Cdp As String)
        querystring = "Update Cdp_PContratos c Set Val_Cdp =(Select Nvl(Sum(Valor),0) From Rubros_PContratos Where Num_Pro=c.Num_PCon And Nro_Cdp=c.Nro_Cdp) Where c.Num_PCon=:Num_PCon And c.Nro_Cdp =:Nro_Cdp  "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_PCon", Num_Pcon)
        Me.AsignarParametroEntero(":Nro_Cdp", Nro_Cdp)
        Me.num_reg = Me.EjecutarComando()
    End Sub

    Public Function Delete(ByVal Nro_Cdp As String, ByVal Num_Pro As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Cdp_PContratos WHERE Num_PCOn=:Num_PCOn AND Nro_Cdp=:Nro_Cdp "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_PCOn", Num_Pro)
            Me.AsignarParametroCadena(":Nro_Cdp", Nro_Cdp)
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