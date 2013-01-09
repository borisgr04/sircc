Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data


Public Class PGContratosM
    Inherits BDDatos

    Sub New()
        Me.Vista = "vPGContratosM"
        Me.Tabla = "PGContratosM"
    End Sub
    ''' <summary>
    ''' REtorna Bytes de MINUTA ACTIVA
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMinuta(ByVal NUM_PROC As String, ByVal GRUPO As Integer) As Byte()
        Me.Conectar()
        querystring = "SELECT * FROM PGContratosM Where ESTADO='AC' AND NUM_PROC=:NUM_PROC And  GRUPO=:GRUPO "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        AsignarParametroEntero(":GRUPO", GRUPO)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Dim Minuta As Byte() = DirectCast(dataTb.Rows(0)("Minuta"), Byte())
        Me.Desconectar()
        Return Minuta
    End Function
    ''' <summary>
    ''' RETORNA BYTES DE MINUTA ESPECIFICADA
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMinuta(ByVal NUM_PROC As String, ByVal GRUPO As Integer, ByVal ID As Integer) As Byte()
        Me.Conectar()
        querystring = "SELECT * FROM PGContratosM Where NUM_PROC=:NUM_PROC And  GRUPO=:GRUPO And ID =:ID"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        AsignarParametroEntero(":GRUPO", GRUPO)
        AsignarParametroEntero(":ID", ID)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Dim Minuta As Byte() = DirectCast(dataTb.Rows(0)("Minuta"), Byte())
        Me.Desconectar()
        Return Minuta
    End Function
    ''' <summary>
    ''' RETORNA SI EXISTE MINUTA ACTIVA
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetExitsAC(ByVal NUM_PROC As String, ByVal GRUPO As Integer) As Boolean
        Me.Conectar()
        querystring = "SELECT Nvl(Count(*),0) Cant FROM " + Vista + " Where NUM_PROC=:NUM_PROC And  GRUPO=:GRUPO And Estado='AC'"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        AsignarParametroEntero(":GRUPO", GRUPO)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()

        Return IIf(dataTb.Rows(0)("Cant") > 0, True, False)

    End Function
    ''' <summary>
    '''  RETORNA MINUTAS DE PROCESO Y GRUPO
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPG(ByVal NUM_PROC As String, ByVal GRUPO As Integer) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Vista + " Where NUM_PROC=:NUM_PROC And  GRUPO=:GRUPO"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        AsignarParametroEntero(":GRUPO", GRUPO)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' INSERTA MINUTA EN BYTES
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <param name="MINUTA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Insert(ByVal NUM_PROC As String, ByVal GRUPO As Integer, ByVal MINUTA As Byte()) As String
        Try
            Conectar()
            ComenzarTransaccion()
            querystring = "Insert Into PGContratosM(MINUTA,NUM_PROC,GRUPO)Values(:MINUTA,:NUM_PROC,:GRUPO)"
            CrearComando(querystring)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":GRUPO", GRUPO)
            AsignarParametroBLOB("MINUTA", MINUTA)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = "Se guardo el Registro " + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try
        Return Msg
    End Function
    ''' <summary>
    ''' INSERTA MINUTA, CON SU BASE-PLANTILLA
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <param name="EDITABLE"></param>
    ''' <param name="MINUTA"></param>
    ''' <param name="MINUTABASE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Insert1(ByVal NUM_PROC As String, ByVal GRUPO As Integer, ByVal EDITABLE As String, ByVal MINUTA As Byte(), ByVal MINUTABASE As Byte()) As String
        Try
            Conectar()
            ComenzarTransaccion()
            querystring = "Insert Into PGContratosM(MINUTA,NUM_PROC,GRUPO,MINUTABASE,EDITABLE)Values(:MINUTA,:NUM_PROC,:GRUPO,:MINUTABASE,:EDITABLE)"
            CrearComando(querystring)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":GRUPO", GRUPO)
            AsignarParametroEntero(":EDITABLE", EDITABLE)
            AsignarParametroBLOB("MINUTA", MINUTA)
            AsignarParametroBLOB("MINUTABASE", MINUTABASE)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = "Se guardo el Registro " + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try
        Return Msg
    End Function

    ''' <summary>
    ''' ANULA UNA MINUTA ESPECIFCIAC
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Anular(ByVal NUM_PROC As String, ByVal GRUPO As Integer, ByVal ID As Integer) As String
        Try
            Conectar()
            ComenzarTransaccion()
            querystring = "Update PGContratosM Set Estado='AN' Where NUM_PROC=:NUM_PROC And GRUPO=:GRUPO And ID=:ID"
            CrearComando(querystring)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":GRUPO", GRUPO)
            AsignarParametroEntero(":ID", ID)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = MsgOk + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function

    Public Function AnularAC(ByVal NUM_PROC As String, ByVal GRUPO As Integer) As String
        Try
            Conectar()
            ComenzarTransaccion()
            querystring = "Update PGContratosM Set Estado='AN' Where NUM_PROC=:NUM_PROC And GRUPO=:GRUPO And ESTADO='AC'"
            CrearComando(querystring)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":GRUPO", GRUPO)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = MsgOk + num_reg.ToString
            lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function

    ''' <summary>
    ''' RETORNA PLANTILLA BASE
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDocBase(ByVal NUM_PROC As String, ByVal GRUPO As String, ByVal ID As Integer) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM PGContratosM Where NUM_PROC=:NUM_PROC And GRUPO=:GRUPO And ID=:ID"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        AsignarParametroEntero(":ID", ID)
        AsignarParametroEntero(":GRUPO", GRUPO)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Retorna Minuta base Activa
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDocBaseAC(ByVal NUM_PROC As String, ByVal GRUPO As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM PGContratosM Where NUM_PROC=:NUM_PROC And GRUPO=:GRUPO And ESTADO='AC'"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":NUM_PROC", NUM_PROC)
        AsignarParametroEntero(":GRUPO", GRUPO)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' ACTUALIZA PLANTILLLA DE LA MINTA
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="ID"></param>
    ''' <param name="GRUPO"></param>
    ''' <param name="dContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Update(ByVal NUM_PROC As String, ByVal ID As Integer, ByVal GRUPO As String, ByVal dContent As [Byte]()) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE PGContratosM SET MinutaBase=:PLANTILLA WHERE NUM_PROC=:NUM_PROC And GRUPO=:GRUPO And ID=:ID"
            CrearComando(querystring)
            AsignarParametroBLOB(":PLANTILLA", dContent)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":ID", ID)
            AsignarParametroEntero(":GRUPO", GRUPO)
            num_reg = EjecutarComando()
            'Throw New Exception(Me.vComando.CommandText)
            ConfirmarTransaccion()
            Msg = MsgOk + "Tamaño del Archivo: " & FormatNumber(dContent.Length / 1024).ToString & " kb - "
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function
    ''' <summary>
    ''' Actualiza Plantilla Base de la Minuta Activa
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="GRUPO"></param>
    ''' <param name="dContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdatePBaseMinAC(ByVal NUM_PROC As String, ByVal GRUPO As String, ByVal dContent As [Byte]()) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE PGContratosM SET MinutaBase=:PLANTILLA WHERE NUM_PROC=:NUM_PROC And GRUPO=:GRUPO And ESTADO='AC'"
            CrearComando(querystring)
            AsignarParametroBLOB(":PLANTILLA", dContent)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":GRUPO", GRUPO)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = MsgOk + " " + num_reg.ToString + " - Fila." + "Tamaño del Archivo: " & FormatNumber(dContent.Length / 1024).ToString & " kb - "
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function

    ''' <summary>
    ''' ACTUALIZA MINUTA FINAL DE LA MINUTA
    ''' </summary>
    ''' <param name="NUM_PROC"></param>
    ''' <param name="ID"></param>
    ''' <param name="grupo"></param>
    ''' <param name="dContent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Regenerar(ByVal NUM_PROC As String, ByVal ID As Integer, ByVal grupo As String, ByVal dContent As [Byte]()) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE PGContratosM SET Minuta=:PLANTILLA WHERE NUM_PROC=:NUM_PROC And GRUPO=:GRUPO And ID=:ID"
            CrearComando(querystring)
            AsignarParametroBLOB(":PLANTILLA", dContent)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":ID", ID)
            AsignarParametroEntero(":GRUPO", grupo)
            num_reg = EjecutarComando()
            'Throw New Exception(Me.vComando.CommandText)
            ConfirmarTransaccion()
            Msg = MsgOk + "Tamaño del Archivo: " & FormatNumber(dContent.Length / 1024).ToString & " kb - "
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function

    Public Function UpdateMinutaAC(ByVal NUM_PROC As String, ByVal grupo As String, ByVal dContent As [Byte]()) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE PGContratosM SET Minuta=:PLANTILLA WHERE NUM_PROC=:NUM_PROC And GRUPO=:GRUPO And ESTADO='AC'"
            CrearComando(querystring)
            AsignarParametroBLOB(":PLANTILLA", dContent)
            AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            AsignarParametroEntero(":GRUPO", grupo)
            num_reg = EjecutarComando()
            'Throw New Exception(Me.vComando.CommandText)
            ConfirmarTransaccion()
            Msg = MsgOk + "Tamaño del Archivo: " & FormatNumber(dContent.Length / 1024).ToString & " kb - "
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function


End Class

