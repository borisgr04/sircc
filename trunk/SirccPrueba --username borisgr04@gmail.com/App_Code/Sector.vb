Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Public Class Sector
    Inherits BDDatos


    Sub New()
        Me.Vista = ""
        Me.VistaDB = "vSECTORDB"
    End Sub


    ''' <summary>
    ''' Consulta de Sector
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vSECTOR ORDER BY NOM_SEC"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Municipios

    'Public Function Insert(ByVal MUN_COD As String, ByVal MUN_NOM As String, ByVal MUN_DPCO As String) As String

    '    Dim na As Integer
    '    Me.AbrirDB()
    '    Try
    '        Dim dbCommand As New OracleCommand
    '        dbCommand.Connection = dbConnection
    '        dbCommand.CommandText = "INSERT INTO Municipios (MUN_COD,MUN_NOM,MUN_DPCO)VALUES(:MUN_COD,:MUN_NOM,:MUN_DPCO)"
    '        dbCommand.Parameters.Add("MUN_COD", OracleDbType.Varchar2, ParameterDirection.Input).Value = MUN_COD
    '        dbCommand.Parameters.Add("MUN_NOM", OracleDbType.Varchar2, ParameterDirection.Input).Value = MUN_NOM
    '        dbCommand.Parameters.Add("MUN_DPCO", OracleDbType.Varchar2, ParameterDirection.Input).Value = MUN_DPCO

    '        'Me.usuario

    '        na = dbCommand.ExecuteNonQuery()
    '        Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
    '        Me.lErrorG = False
    '    Catch exo As OracleException
    '        Me.lErrorG = True
    '        Me.Msg = "Error de Datos:" + exo.Message
    '    Catch ex As Exception
    '        Me.lErrorG = True
    '        Me.Msg = "Error de App:" + ex.Message
    '    Finally
    '        Me.CerrarBD()
    '    End Try


    '    Return Msg
    'End Function
    '' Funciòn Actualizar: Acatualiza datos a la tabla Municipios
    ''    
    'Public Function Update(ByVal MUN_COD_OR As String, ByVal MUN_COD As String, ByVal MUN_NOM As String, ByVal MUN_DPCO As String) As String
    '    Dim na As String
    '    Me.AbrirDB()
    '    Try
    '        Dim dbCommand As New OracleCommand
    '        dbCommand.Connection = dbConnection
    '        dbCommand.CommandText = "UPDATE Municipios SET MUN_COD='" + MUN_COD + "',MUN_NOM='" + MUN_NOM + "' ,MUN_DPCO='" + MUN_DPCO + "' WHERE MUN_COD='" + MUN_COD_OR + "' "
    '        na = dbCommand.ExecuteNonQuery()
    '        Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"

    '        Me.lErrorG = False
    '    Catch exo As OracleException
    '        Me.lErrorG = True
    '        Me.Msg = "Error de Datos:" + exo.Message
    '    Catch ex As Exception
    '        Me.lErrorG = True
    '        Me.Msg = "Error de App:" + ex.Message
    '    Finally
    '        Me.CerrarBD()
    '    End Try

    '    Return Msg
    'End Function
    ''Funciòn Delete: elimina datos a la tabla Municipios
    '' Parametros: Tcta_Codi : Còdigo

    'Public Function Delete(ByVal MUN_COD As String) As String
    '    Dim na As String

    '    'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

    '    'Return "Esta Clase de Impuesto, No se puede eliminar"
    '    'End If
    '    Me.AbrirDB()
    '    Try
    '        Dim dbCommand As New OracleCommand
    '        dbCommand.Connection = dbConnection

    '        dbCommand.CommandText = "DELETE Municipios WHERE MUN_COD='" + MUN_COD + "'"
    '        na = dbCommand.ExecuteNonQuery()
    '        Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
    '        Me.lErrorG = False
    '    Catch exo As OracleException
    '        Me.lErrorG = True
    '        Me.Msg = "Error de Datos:" + exo.Message
    '    Catch ex As Exception
    '        Me.lErrorG = True
    '        Me.Msg = "Error de App:" + ex.Message
    '    Finally
    '        Me.CerrarBD()
    '    End Try
    '    Return Msg
    'End Function

    ' <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    '    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
    '     Me.AbrirDB()
    '     Dim queryString As String = "SELECT * FROM Municipios WHERE MUN_COD=:MUN_COD"
    '     Dim dbCommand As New OracleCommand(queryString, dbConnection)
    '     Dim dataAdapter As New OracleDataAdapter
    '     dbCommand.Parameters.Add("TCTA_CODI", OracleDbType.Varchar2, ParameterDirection.Input).Value = Cod
    '     dataAdapter.SelectCommand = dbCommand
    '     Dim dataTb As DataTable = New DataTable
    '     dataAdapter.Fill(dataTb)
    '     Me.CerrarBD()
    '     Return dataTb

    ' End Function

    ' <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    'Public Overloads Function GetPorDpto(ByVal DpCo As String) As DataTable
    '     Me.AbrirDB()
    '     Dim queryString As String = "SELECT * FROM MUNICIPIOS WHERE MUN_DPCO=:MUN_DPCO"
    '     Dim dbCommand As New OracleCommand(queryString, dbConnection)
    '     dbCommand.Parameters.Add("MUN_DPCO", OracleDbType.Varchar2, ParameterDirection.Input).Value = DpCo
    '     Dim dataAdapter As New OracleDataAdapter
    '     dataAdapter.SelectCommand = dbCommand
    '     Dim dataTb As DataTable = New DataTable
    '     dataAdapter.Fill(dataTb)
    '     Me.CerrarBD()
    '     Return dataTb

    ' End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Cod_Sec As String, ByVal Nom_Sec As String, ByVal estado As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Sector(Cod_Sec, Nom_Sec, estado)VALUES(:Cod_Sec, :Nom_Sec, :estado) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sec", Cod_Sec)
            Me.AsignarParametroCadena(":Nom_Sec", Nom_Sec)
            Me.AsignarParametroCadena(":estado", estado)

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
    Public Function Update(ByVal Cod_Sec_O As String, ByVal Cod_Sec As String, ByVal Nom_Sec As String, ByVal estado As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE Sector SET Cod_Sec=:Cod_Sec, Nom_sec=:Nom_Sec, estado=:estado WHERE Cod_Sec=:Cod_Sec_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sec", Cod_Sec)
            Me.AsignarParametroCadena(":Nom_Sec", Nom_Sec)
            Me.AsignarParametroCadena(":estado", estado)
            Me.AsignarParametroCadena(":Cod_Sec_O", Cod_Sec_O)

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

    Function Delete(ByVal Cod_Sec As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Sector WHERE Cod_Sec=:Cod_Sec"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sec", Cod_Sec)

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
    Public Function GetbyPk(ByVal Cod_Sec As String) As DataTable
        querystring = "SELECT * FROM  Sector Where Cod_Sec=:Cod_Sec"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Sec", Cod_Sec)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
End Class
