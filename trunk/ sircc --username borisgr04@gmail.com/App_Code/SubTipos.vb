Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class SubTipos
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "SubTipos"
        Me.Vista = "VSubTipos"
        Me.VistaDB = "VSubTiposDB"
        'SELECT "COD_DEP", "NOM_DEP" FROM sircc.vdepdel ORDER BY "NOM_DEP"
        'SELECT "COD_DEP", "NOM_DEP" FROM "DEPENDENCIA" ORDER BY "NOM_DEP"

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
    Public Function GetByTipoDB(ByVal cod_tip As String) As DataTable
        Dim queryString As String = "SELECT * FROM  " + VistaDB + " WHERE COD_TIP=:COD_TIP"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":COD_TIP", cod_tip)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByTipo(ByVal cod_tip As String) As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista + " WHERE COD_TIP=:COD_TIP ORDER BY NOM_STIP"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":COD_TIP", cod_tip)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Cod_Stip As String, ByVal Nom_Stip As String, ByVal Cod_Tip As String, ByVal Cla_Con_Dep As String, ByVal Crt_F20_1A As String, ByVal Cla_Con_Dp As String, ByVal estado As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO subtipos(Cod_Stip, Nom_Stip, Cod_Tip, Cla_Con_Dep, Crt_F20_1A, Cla_Con_Dp, Estado)VALUES(:Cod_Stip, :Nom_Stip,:Cod_Tip, :Cla_Con_Dep, :Crt_F20_1A, :Cla_Con_Dp, :Estado) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Stip", Cod_Stip)
            Me.AsignarParametroCadena(":Nom_Stip", Nom_Stip)
            Me.AsignarParametroCadena(":Cod_Tip", Cod_Tip)
            Me.AsignarParametroCadena(":Cla_Con_Dep", Cla_Con_Dep)
            Me.AsignarParametroCadena(":Crt_F20_1A", Crt_F20_1A)
            Me.AsignarParametroCadena(":Cla_Con_Dp", Cla_Con_Dp)
            Me.AsignarParametroCadena(":Estado", estado)

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
    Public Function Update(ByVal Cod_Stip_O As String, ByVal Cod_Stip As String, ByVal Nom_Stip As String, ByVal Cod_Tip As String, ByVal Cla_Con_Dep As String, ByVal Crt_F20_1A As String, ByVal Cla_Con_Dp As String, ByVal Estado As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE Subtipos SET Cod_Stip=:Cod_Stip, Nom_Stip=:Nom_Stip, cod_tip=:Cod_Tip, Cla_Con_Dep=:Cla_Con_Dep, Crt_F20_1A=:Crt_F20_1A, Cla_Con_Dp=:Cla_Con_Dp, Estado=:Estado WHERE Cod_Stip=:Cod_Stip_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Stip", Cod_Stip)
            Me.AsignarParametroCadena(":Nom_Stip", Nom_Stip)
            Me.AsignarParametroCadena(":Cod_Tip", Cod_Tip)
            Me.AsignarParametroCadena(":Cla_Con_Dep", Cla_Con_Dep)
            Me.AsignarParametroCadena(":Crt_F20_1A", Crt_F20_1A)
            Me.AsignarParametroCadena(":Cla_Con_Dp", Cla_Con_Dp)
            Me.AsignarParametroCadena(":Estado", Estado)
            Me.AsignarParametroCadena(":Cod_Stip_O", Cod_Stip_O)

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

    Function Delete(ByVal Cod_Stip As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM SubTipos WHERE Cod_Stip=:Cod_Stip"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Stip", Cod_Stip)

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
    Public Function GetbyPk(ByVal Cod_Stip As String) As DataTable
        querystring = "SELECT * FROM  " + Tabla + " Where Cod_Stip=:Cod_Stip"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Stip", Cod_Stip)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
End Class



