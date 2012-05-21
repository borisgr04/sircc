Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Impuestos
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "Impuestos"
        Me.Vista = "VImpuestos"
        Me.VistaDB = "VImpuestosDB"

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
    Public Function GetbyPk(ByVal Nro_Imp As String) As DataTable
        querystring = "SELECT * FROM  " + Tabla + " Where Nro_Imp=:Nro_Imp"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Nro_Imp", Nro_Imp)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Nro_Imp As String, ByVal Nom_Imp As String, ByVal Cod_Pct As String, ByVal Estado As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Impuestos(Nro_Imp, Nom_Imp, Cod_Pct, estado)VALUES(:Nro_Imp, :Nom_Imp,:Cod_Pct, :Estado) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Nro_Imp", Nro_Imp)
            Me.AsignarParametroCadena(":Nom_Imp", Nom_Imp)
            Me.AsignarParametroCadena(":Cod_Pct", Cod_Pct)
            Me.AsignarParametroCadena(":Estado", Estado)

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
    Public Function Update(ByVal Nro_Imp_O As String, ByVal Nro_Imp As String, ByVal Nom_Imp As String, ByVal Cod_Pct As String, ByVal Estado As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE Impuestos SET Nro_Imp=:Nro_Imp, Nom_Imp=:Nom_Imp, Cod_Pct=:Cod_Pct, Estado=:Estado WHERE Nro_Imp=:Nro_Imp_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Nro_Imp", Nro_Imp)
            Me.AsignarParametroCadena(":Nom_Imp", Nom_Imp)
            Me.AsignarParametroCadena(":Cod_Pct", Cod_Pct)
            Me.AsignarParametroCadena(":Estado", Estado)
            Me.AsignarParametroCadena(":Nro_Imp_O", Nro_Imp_O)

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

    Function Delete(ByVal Nro_Imp As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Impuestos WHERE Nro_Imp=:Nro_Imp"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Nro_Imp", Nro_Imp)

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