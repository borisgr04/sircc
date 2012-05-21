Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Consorcios
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "ConsorciosUT"
        Me.Vista = "VCONSORCIOSUT"

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
    Public Function GetbyUK(ByVal IDE_TER As String, ByVal Id_Miembro As String) As DataTable
        querystring = "SELECT * FROM  " + Vista + " Where IDE_TER=:IDE_TER and ID_MIEMBRO=:ID_MIEMBRO"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":IDE_TER", IDE_TER)
        AsignarParametroCadena(":ID_MIEMBRO", Id_Miembro)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyTer(ByVal IDE_TER As String) As DataTable
        querystring = "SELECT * FROM  " + Vista + " Where IDE_TER=:IDE_TER"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":IDE_TER", IDE_TER)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Ide_Ter As String, ByVal Id_Miembros As String, ByVal Id_Estado As String, ByVal Porc_Part As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO ConsorciosUT(Ide_Ter, Id_Miembros, Id_Estado,Porc_Part)VALUES(:Ide_Ter, :Id_Miembros,:Id_Estado,:Porc_Part) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Ide_Ter", Ide_Ter)
            Me.AsignarParametroCadena(":Id_Miembros", Id_Miembros)
            Me.AsignarParametroCadena(":Id_Estado", Id_Estado)
            Me.AsignarParametroCadena(":Porc_Part", Porc_Part)

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
    Public Function Update(ByVal Ide_Ter As String, ByVal Id_Miembros As String, ByVal Id_Estado As String, ByVal Porc_Part As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE ConsorciosUT SET Id_Estado=:Id_Estado, Porc_Part=To_Number(:Porc_Part) WHERE Ide_Ter=:Ide_Ter And Id_Miembros=:Id_Miembros"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Ide_Ter", Ide_Ter)
            Me.AsignarParametroCadena(":Id_Miembros", Id_Miembros)
            Me.AsignarParametroCadena(":Id_Estado", Id_Estado)
            Me.AsignarParametroCadena(":Porc_Part", Porc_Part)
            'Throw New Exception(Me.vComando.CommandText)

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

    Function Delete(ByVal Ide_Ter As String, ByVal Id_Miembros As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM ConsorciosUT WHERE Ide_Ter=:Ide_Ter and Id_Miembros=:Id_Miembros"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Ide_Ter", Ide_Ter)
            Me.AsignarParametroCadena(":Id_Miembros", Id_Miembros)

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