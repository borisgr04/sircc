Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Polizas
    Inherits BDDatos

    Sub New()
        Me.Vista = "vPOLIZAS"
        Me.VistaDB = "vPOLIZASDB"
    End Sub
    
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPOLIZAS ORDER BY NOM_POL"
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
   Public Function GetbyPk(ByVal Cod_Pol As String) As DataTable
        querystring = "SELECT * FROM  Polizas Where Cod_Pol=:Cod_Pol"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Pol", Cod_Pol)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Cod_Pol As String, ByVal Nom_Pol As String, ByVal Descripcion As String, ByVal Est_Pol As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Polizas(Cod_Pol, Nom_Pol, Est_Pol,Descripcion)VALUES(:Cod_Pol, :Nom_Pol, :Est_Pol,:Descripcion) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
            Me.AsignarParametroCadena(":Nom_Pol", Nom_Pol)
            Me.AsignarParametroCadena(":Est_Pol", Est_Pol)
            Me.AsignarParametroCadena(":Descripcion", Descripcion)

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
    Public Function Update(ByVal Cod_Pol_O As String, ByVal Cod_Pol As String, ByVal Nom_Pol As String, ByVal Descripcion As String, ByVal Est_Pol As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE Polizas SET Descripcion=:Descripcion,Cod_Pol=:Cod_Pol, Nom_Pol=:Nom_Pol, Est_Pol=:Est_Pol WHERE Cod_Pol=:Cod_Pol_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)
            Me.AsignarParametroCadena(":Nom_Pol", Nom_Pol)
            Me.AsignarParametroCadena(":Est_Pol", Est_Pol)
            Me.AsignarParametroCadena(":Descripcion", Descripcion)
            Me.AsignarParametroCadena(":Cod_Pol_O", Cod_Pol_O)

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

    Function Delete(ByVal Cod_Pol As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Polizas WHERE Cod_Pol=:Cod_Pol"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Pol", Cod_Pol)

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