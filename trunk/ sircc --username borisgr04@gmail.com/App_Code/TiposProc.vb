Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class TiposProc
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "TiposProc"
        Me.Vista = "vTiposProc"
        Me.VistaDB = "vTiposProcDB"
        'SELECT "COD_DEP", "NOM_DEP" FROM sircc.vdepdel ORDER BY "NOM_DEP"
        'SELECT "COD_DEP", "NOM_DEP" FROM "DEPENDENCIA" ORDER BY "NOM_DEP"

    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista + " Order by Nom_TProc"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
Public Function GetAbreviatura(ByVal cod_tproc As String, Optional ByVal connectar As Boolean = False) As String
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        If connectar = True Then
            Me.Conectar()
        End If

        Dim queryString As String = "select abre_tproc from TIPOSPROC where cod_tproc=:cod_tproc "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":cod_tproc", cod_tproc)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        If connectar = True Then
            Me.Desconectar()
        End If
        Return dataTb.Rows(0)("abre_tproc").ToString

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Cod_Tproc As String, ByVal Nom_Tproc As String, ByVal Abre_Tproc As String, ByVal Esta_Tproc As String, ByVal Cod_Ctr As String, ByVal Ctr_F20_1A As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO TiposProc(Cod_Tproc, Nom_Tproc, Abre_Tproc, Esta_Tproc, Cod_Ctr, Ctr_F20_1A)VALUES(:Cod_Tproc, :Nom_Tproc,:Abre_Tproc, :Esta_Tproc, :Cod_Ctr, :Ctr_F20_1A) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Tproc", Cod_Tproc)
            Me.AsignarParametroCadena(":Nom_Tproc", Nom_Tproc)
            Me.AsignarParametroCadena(":Abre_Tproc", Abre_Tproc)
            Me.AsignarParametroCadena(":Esta_Tproc", Esta_Tproc)
            Me.AsignarParametroCadena(":Cod_Ctr", Cod_Ctr)
            Me.AsignarParametroCadena(":Ctr_F20_1A", Ctr_F20_1A)

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
    Public Function Update(ByVal Cod_Tproc_O As String, ByVal Cod_Tproc As String, ByVal Nom_Tproc As String, ByVal Abre_Tproc As String, ByVal Esta_Tproc As String, ByVal Cod_Ctr As String, ByVal Ctr_F20_1A As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "UPDATE TiposProc SET Cod_Tproc=:Cod_Tproc, Nom_Tproc=:Nom_Tproc, Abre_Tproc=:Abre_Tproc, Esta_Tproc=:Esta_Tproc, Cod_Ctr=:Cod_Ctr, Ctr_F20_1A=:Ctr_F20_1A WHERE Cod_Tproc=:Cod_Tproc_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Tproc", Cod_Tproc)
            Me.AsignarParametroCadena(":Nom_Tproc", Nom_Tproc)
            Me.AsignarParametroCadena(":Abre_Tproc", Abre_Tproc)
            Me.AsignarParametroCadena(":Esta_Tproc", Esta_Tproc)
            Me.AsignarParametroCadena(":Cod_Ctr", Cod_Ctr)
            Me.AsignarParametroCadena(":Ctr_F20_1A", Ctr_F20_1A)
            Me.AsignarParametroCadena(":Cod_Tproc_O", Cod_Tproc_O)

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

    Function Delete(ByVal Cod_Tproc As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM TiposProc WHERE Cod_Tproc=:Cod_Tproc"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Tproc", Cod_Tproc)

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
    Public Function GetbyPk(ByVal Cod_Tproc As String) As DataTable
        querystring = "SELECT * FROM  TiposProc Where Cod_Tproc=:Cod_Tproc"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Cod_Tproc", Cod_Tproc)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
End Class



