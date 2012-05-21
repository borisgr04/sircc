Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Est_Ruta
    Inherits BDDatos

    ''' <summary>
    ''' Consulta de Sector
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByEstIni(ByVal EST_INI As String) As DataTable
        Me.Conectar()
        querystring = "SELECT EST_INI, EST_FIN, NOM_EST FROM RUTAESTADOS WHERE (EST_INI = :EST_INI)"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":EST_INI", EST_INI)
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



End Class
