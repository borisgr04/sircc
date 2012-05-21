Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class GPObligaciones
    Inherits BDDatos


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM GPOBLIGACIONES "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Num_PCon As String, ByVal Grupo As String) As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()

        Dim queryString As String = "SELECT ide_oblig ,Num_PCon ,Des_Oblig FROM GPOBLIGACIONES Where Num_Pcon=:Num_Pcon And Grupo=:Grupo"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Num_Pcon", Num_PCon)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        'Me.AsignarParametroCadena(":Vigencia", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Public Function Insert(ByVal Num_PCon As String, ByVal Des_Oblig As String, ByVal Grupo As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO GPOBLIGACIONES(Num_PCon, Des_Oblig, Grupo)VALUES(:Num_PCon, :Des_Oblig, :Grupo) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_PCon", Num_PCon)
            Me.AsignarParametroCLOB(":Des_Oblig", Des_Oblig)
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

    Public Function Delete(ByVal Ide_Oblig As String, ByVal Num_Proc As String, ByVal Grupo As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM GPOBLIGACIONES WHERE Num_Pcon=:Num_Pcon AND Ide_Oblig =:Ide_Oblig  And Grupo=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Pcon", Num_Proc)
            Me.AsignarParametroCadena(":Ide_Oblig", Ide_Oblig)
            Me.AsignarParametroCadena(":Grupo", Grupo)
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

    Public Function Update(ByVal Num_PCon As String, ByVal Des_Oblig As String, ByVal Ide_Oblig As Integer, ByVal Grupo As String) As String

        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = " UPDATE GPOBLIGACIONES SET Des_Oblig=:Des_Oblig WHERE Num_PCon=:Num_PCon AND Ide_Oblig=:Ide_Oblig And Grupo=:Grupo"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_PCon", Num_PCon)
            Me.AsignarParametroCLOB(":Des_Oblig", Des_Oblig)
            Me.AsignarParametroEntero(":Ide_Oblig", Ide_Oblig)
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
            'Me.Msg = Me._Comando.CommandText
            Me.Desconectar()
        End Try
        Return Msg
    End Function
End Class