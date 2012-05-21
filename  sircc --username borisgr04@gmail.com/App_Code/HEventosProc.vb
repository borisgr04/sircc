Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class HEventosProc
    Inherits BDDatos


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Num_Pro As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vHEventosProc Where NUM_PRO=:NUM_PRO"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUM_PRO", Num_Pro)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal NUM_PROC As String, ByVal OBS_EVEN As String, ByVal ESTADO As String) As String
        Me.Conectar()
        Try
            querystring = "Insert Into HEventosProc (NUM_PRO, ESTADO, OBS_EVEN) Values(:NUM_PRO, :ESTADO, :OBS_EVEN)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":NUM_PRO", NUM_PROC)
            Me.AsignarParametroCadena(":OBS_EVEN", OBS_EVEN)
            Me.AsignarParametroCadena(":ESTADO", ESTADO)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "] - "
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try

        Return Me.Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal NUM_PROC As String, ByVal ESTADO As String, ByVal FECHAINI As Date, ByVal FECHAFIN As Date, ByVal HORAINI As String, ByVal HORAFIN As String, ByVal OBS As String, ByVal lstFechas As List(Of Date)) As String

        Me.Conectar()
        Try
            querystring = "Insert into PCRONOGRAMA (NUM_PROC, ESTADO, FECHAINI, FECHAFIN, HORAINI, HORAFIN,OBS)"
            querystring += "VALUES(:NUM_PROC, :ESTADO, to_date(:FECHAINI,'dd/mm/yyyy'), to_date(:FECHAFIN,'dd/mm/yyyy'), :HORAINI, :HORAFIN,:OBS)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            Me.AsignarParametroCadena(":ESTADO", ESTADO)
            Me.AsignarParametroCadena(":FECHAINI", FECHAINI)
            Me.AsignarParametroCadena(":FECHAFIN", FECHAFIN)
            Me.AsignarParametroCadena(":HORAINI", HORAINI.Trim)
            Me.AsignarParametroCadena(":HORAFIN", HORAFIN.Trim)
            Me.AsignarParametroCadena(":OBS", OBS)
            Me.num_reg = Me.EjecutarComando()
            For Each f In lstFechas
                querystring = "Insert into PCRONO_DIAS ( FECHA)VALUES( to_date(:FECHA,'dd/mm/yyyy'))"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":FECHA", f)
                Me.EjecutarComando()
            Next
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "] - "
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try

        Return Me.Msg
    End Function
End Class
