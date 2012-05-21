Imports Microsoft.VisualBasic
Imports System.Data

Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

<System.ComponentModel.DataObject()> _
Public Class Prev_Estudios
    Inherits BDDatos

    Public Sub New()
        Me.Tabla = "Prev_Estudios"
        Me.Vista = "Prev_Estudios"
    End Sub

    Public Overloads Function GetByPk(ByVal Vigencia As String, ByVal Num_Previo As String) As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado

        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Prev_Estudios WHERE Num_Previo=:Num_Previo And Vigencia=:Vigencia"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Num_Previo", Num_Previo)
        Me.AsignarParametroCadena(":Vigencia", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    

    'Public Function Update(ByVal ide_old As String, ByVal ide As String, ByVal ape1 As String, ByVal ape2 As String, ByVal nom1 As String, ByVal nom2 As String, ByVal dir As String, ByVal tel As String, ByVal ema As String) As String

    '    Dim t As OracleTransaction = dbConnection.BeginTransaction()

    '    ape1 = UCase(ape1)
    '    ape2 = IIf(UCase(ape2) <> "", UCase(ape2), " ")
    '    nom1 = IIf(UCase(nom1) <> "", UCase(nom1), " ")
    '    nom2 = IIf(UCase(nom2) <> "", UCase(nom2), " ")



    '    Dim queryString As String = "UPDATE Terceros SET ide_ter= :ide_ter, ape1_ter= '" + ape1 + "', ape2_ter= '" + ape2 + "', nom1_ter= '" + nom1 + "', nom2_ter= '" + nom2 + "', dir_ter= :dir_ter, tel_ter= :tel_ter, ema_ter= :ema_ter WHERE ide_ter= '" + ide_old + "'"
    '    Dim dbCommand As New OracleCommand(queryString, dbConnection)

    '    dbCommand.Parameters.Add("ide_ter", ide)
    '    dbCommand.Parameters.Add("dir_ter", IIf(dir <> "", dir, "-"))
    '    dbCommand.Parameters.Add("tel_ter", IIf(tel <> "", tel, "-"))
    '    dbCommand.Parameters.Add("ema_ter", IIf(ema <> "", ema, "-"))

    '    Try
    '        dbCommand.ExecuteNonQuery()
    '        msg = "Se Modificò Tercero Nº " + ide
    '        f.InsAud(Me.dbConnection, "Terceros", msg, usuario)
    '        t.Commit()
    '        lErrorG = False
    '        msg = MsgOk + "<br>" + msg
    '    Catch ex As Exception
    '        msg = ex.Message
    '        t.Rollback()
    '        lErrorG = True
    '    End Try

    '    Return msg

    'End Function


    'Public Function GetByIde(ByVal ide As String) As System.Data.DataTable

    '    Dim dataAdapter As New OracleDataAdapter
    '    Dim datat As New Data.DataTable

    '    Dim queryString As String = "SELECT * FROM Terceros Where ide_ter=:ide_ter"

    '    Dim dbCommand As New OracleCommand(queryString, dbConnection)

    '    dbCommand.Parameters.Add("ide_ter", ide)

    '    dataAdapter.SelectCommand = dbCommand
    '    dataAdapter.Fill(datat)

    '    Return datat

    'End Function
    'Public Function Delete(ByVal ide As String) As String
    '    Dim t As OracleTransaction = Me.dbConnection.BeginTransaction()

    '    Dim queryString As String = "DELETE FROM Terceros WHERE  ide_ter =:ide_ter"
    '    Dim dbCommand As New OracleCommand(queryString, dbConnection)


    '    dbCommand.Parameters.Add("ide_ter", ide)

    '    Try
    '        dbCommand.ExecuteNonQuery()
    '        msg = "Se un Eliminó Tercero Nº " + ide
    '        f.InsAud(Me.dbConnection, "Terceros", msg, usuario)

    '        t.Commit()
    '        msg = MsgOk + "<br>" + msg
    '        lErrorG = False
    '    Catch ex As Exception
    '        msg = ex.Message
    '        t.Rollback()
    '        lErrorG = True

    '    End Try

    '    Return msg

    'End Function

End Class
