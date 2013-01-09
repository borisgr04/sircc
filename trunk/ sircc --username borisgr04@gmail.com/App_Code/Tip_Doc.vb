Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Tip_Doc
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "TIP_DOC"
        Me.VistaDB = "VTIP_DOCDB"
        Me.Vista = "VTIP_DOC"

    End Sub

    ''' <summary>
    '''  Retorna los todos los registros de la tabla de la Base de datos, segun el filtro especificado
    ''' </summary>
    ''' <param name="Filtro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsComplete(ByVal Filtro As String) As DataTable
        Dim queryString As String = "SELECT Cod_Tip||'-'||Des_Tip As Des_Tip FROM Tip_Doc Where Upper(Des_Tip) Like '%" + Filtro.ToUpper + "%'"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM " + Vista
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyEtapa(ByVal Cod_Eta As String) As DataTable
        querystring = "SELECT * FROM  " + VistaDB + " Where Cod_Eta=:Cod_Eta"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Eta", Cod_Eta)
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
    Public Function Insert(ByVal Cod_Tip As String, ByVal Des_Tip As String, ByVal Est_Tip As String, ByVal Cod_Etapa As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Tip_Doc(Cod_Tip, Des_Tip, Est_Tip, Cod_Etapa)VALUES(:Cod_Tip, :Des_Tip,:Est_Tip, :Cod_Etapa) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Tip", Cod_Tip)
            Me.AsignarParametroCadena(":Des_Tip", Des_Tip)
            Me.AsignarParametroCadena(":Est_Tip", Est_Tip)
            Me.AsignarParametroCadena(":Cod_Etapa", Cod_Etapa)

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
    Public Function Update(ByVal Cod_Tip_O As String, ByVal Cod_Tip As String, ByVal Des_Tip As String, ByVal Est_Tip As String, ByVal Cod_Etapa As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE Tip_Doc SET Cod_Tip=:Cod_Tip, Des_Tip=:Des_Tip,Est_Tip=:Est_Tip, Cod_Etapa=:Cod_Etapa WHERE Cod_Tip=:Cod_Tip_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Tip", Cod_Tip)
            Me.AsignarParametroCadena(":Des_Tip", Des_Tip)
            Me.AsignarParametroCadena(":Est_Tip", Est_Tip)
            Me.AsignarParametroCadena(":Cod_Etapa", Cod_Etapa)
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
            querystring = "DELETE FROM Tip_Doc WHERE Cod_Tip=:Cod_Tip"
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
