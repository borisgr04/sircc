Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class RP_Contratos
    Inherits BDDatos


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vRP_CONTRATOS "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Cod_Con As String, ByVal Nro_Rp As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vRP_CONTRATOS Where Cod_Con=:Cod_Con And Nro_Cdp=:Nro_Rp"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Me.AsignarParametroCadena(":Nro_Cdp", Nro_Rp)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vRP_CONTRATOS Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function Insert(ByVal Cod_Con As String, ByVal Nro_Rp As String, ByVal Fec_Rp As Date, ByVal Val_RP As Decimal, ByVal Vigencia As String, ByVal Doc_Sop As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO RP_CONTRATOS(Cod_Con, Nro_Rp,Fec_Rp,Val_Rp,Vigencia,Doc_Sop)VALUES(:Cod_Con, :Nro_Rp,:Fec_Rp,:Val_Rp,:Vigencia,:Doc_Sop) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroEntero(":Nro_Rp", Nro_Rp)
            Me.AsignarParametroFecha(":Fec_Rp", Fec_Rp)
            Me.AsignarParametroDecimal(":Val_Rp", Val_RP)
            Me.AsignarParametroDecimal(":Vigencia", Vigencia)
            Me.AsignarParametroCadena(":Doc_Sop", Doc_Sop)
            'Throw New Exception(Me._Comando.CommandText)
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

    Public Function Delete(ByVal Cod_Con As String, ByVal Nro_rp As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM RP_CONTRATOS WHERE Cod_Con=:Cod_Con AND Nro_rp=:Nro_rp "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":Nro_rp", Nro_rp)
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
End Class