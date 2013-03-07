Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
<System.ComponentModel.DataObject()> _
Public Class Tipos_Entidades
    Inherits BDDatos
    Public Sub New()


        Me.Tabla = "inttipo_ess"
        Me.Vista = "vinttipo_ess"
        Me.VistaDB = "vinttipo_essDB"

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
    Public Function GetbyPk(ByVal Cod_Tip As String) As DataTable
        querystring = "SELECT * FROM  " + Tabla + " Where Cod_Tip=:Cod_Tip"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Tip", Cod_Tip)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Cod_Tip As String, ByVal Nom_Tip As String, ByVal Est_Tip As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Tipo_ESS(COD_TIP, NOM_TIP,EST_TIP)VALUES(:Cod_Tip, :Nom_Tip, :Est_Tip) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Tip", Cod_Tip)
            Me.AsignarParametroCadena(":Nom_Tip", Nom_Tip)
            Me.AsignarParametroCadena(":Est_Tip", Est_Tip)


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
    Public Function Update(ByVal Cod_Tip_O As String, ByVal Cod_Tip As String, ByVal Nom_Tip As String, ByVal Est_Tip As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE TiposCont SET Cod_Tip=:Cod_Tip, Nom_Tip=:Nom_Tip,Est_Tip=:Est_Tip WHERE Cod_Tip=:Cod_Tip_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Tip", Cod_Tip)
            Me.AsignarParametroCadena(":Nom_Tip", Nom_Tip)
            Me.AsignarParametroCadena(":Est_Tip", Est_Tip)
            Me.AsignarParametroCadena(":Cod_Tip_O", Cod_Tip_O)

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

    Function Delete(ByVal Cod_Tip As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Tipo_ESS WHERE Cod_Tip=:Cod_Tip"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Tip", Cod_Tip)

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



