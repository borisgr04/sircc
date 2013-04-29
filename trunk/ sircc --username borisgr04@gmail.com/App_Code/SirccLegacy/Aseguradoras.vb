Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Aseguradoras
    Inherits BDDatos
    Sub New()
        Me.VistaDB = "vAseguradorasDB"
    End Sub


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vAseguradoras"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Public Function Insert(ByVal Cod_Ase As String, ByVal Nom_Ase As String, ByVal estado As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Aseguradoras(Cod_Ase, Nom_Ase, estado)VALUES(:Cod_Ase, :Nom_Ase, :estado) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Ase", Cod_Ase)
            Me.AsignarParametroCadena(":Nom_Ase", Nom_Ase)
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
    Public Function Update(ByVal Cod_Ase_O As String, ByVal Cod_Ase As String, ByVal Nom_Ase As String, ByVal estado As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE Aseguradoras SET Cod_Ase=:Cod_Ase, Nom_Ase=:Nom_Ase, estado=:estado WHERE Cod_Ase=:Cod_Ase_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Ase", Cod_Ase)
            Me.AsignarParametroCadena(":Nom_Ase", Nom_Ase)
            Me.AsignarParametroCadena(":estado", estado)
            Me.AsignarParametroCadena(":Cod_Ase_O", Cod_Ase_O)

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

    Function Delete(ByVal Cod_Ase As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Aseguradoras WHERE Cod_Ase=:Cod_Ase"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Ase", Cod_Ase)

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
    Public Function GetbyPk(ByVal Cod_Ase As String) As DataTable
        querystring = "SELECT * FROM  Aseguradoras Where Cod_Ase=:Cod_Ase"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Ase", Cod_Ase)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function


End Class