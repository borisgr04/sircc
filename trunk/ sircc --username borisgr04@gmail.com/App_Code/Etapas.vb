Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Etapas
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "Etapas"
        Me.Vista = "vEtapas"
        Me.VistaDB = "vEtapasDB"

    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Cod_Eta As String) As DataTable
        querystring = "SELECT * FROM  " + Tabla + " Where Cod_Eta=:Cod_Eta"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Eta", Cod_Eta)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Cod_Eta As String, ByVal Nom_Eta As String, ByVal Estado As String) As String
        Me.Conectar()
        Try
            MsgBox(Cod_Eta & Nom_Eta & Estado)
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Etapas(Cod_Eta, Nom_Eta, Estado)VALUES(:Cod_Eta, :Nom_Eta, :Estado) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Eta", Cod_Eta)
            Me.AsignarParametroCadena(":Nom_Eta", Nom_Eta)
            Me.AsignarParametroCadena(":Estado", Estado)
            MsgBox(Cod_Eta & Nom_Eta & Estado)
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
    Public Function Update(ByVal Cod_Eta_O As String, ByVal Cod_Eta As String, ByVal Nom_Eta As String, ByVal Estado As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE Etapas SET Cod_Eta=:Cod_Eta, Nom_Eta=:Nom_Eta, Estado=:Estado WHERE Cod_Eta=:Cod_Eta_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Eta", Cod_Eta)
            Me.AsignarParametroCadena(":Nom_Eta", Nom_Eta)
            Me.AsignarParametroCadena(":Estado", Estado)
            Me.AsignarParametroCadena(":Cod_Eta_O", Cod_Eta_O)

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

    Function Delete(ByVal Cod_Eta As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Etapas WHERE Cod_Eta=:Cod_Eta"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Eta", Cod_Eta)

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
