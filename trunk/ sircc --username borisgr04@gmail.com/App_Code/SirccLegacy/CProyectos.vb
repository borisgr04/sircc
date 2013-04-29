Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class CProyectos
    Inherits BDDatos


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vCproyectos "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Proyecto As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vCproyectos Where Proyecto=:Proyecto"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Proyecto", Proyecto)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyNum_Proc(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vCproyectos Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function Insert(ByVal Proyecto As String, ByVal Cod_Con As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO CProyectos(Cod_Con, Proyecto)VALUES(:Cod_Con, :Proyecto) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":Proyecto", Proyecto)
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
    Public Function Delete(ByVal Proyecto As String, ByVal Cod_Con As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM CProyectos WHERE Cod_Con=:Cod_Con AND Proyecto=:Proyecto "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
            Me.AsignarParametroCadena(":Proyecto", Proyecto)
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