Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
''' <summary>
''' Estados de cada actividad del cronograma
''' </summary>
''' <remarks></remarks>
<System.ComponentModel.DataObject()> _
Public Class PEstadosAct
    Inherits BDDatos
    Sub New()
        Me.Tabla = "PESTADOSACT"
        Me.Vista = "PESTADOSACT"
        Me.VistaDB = "PESTADOSACT"
    End Sub

    ''' <summary>
    ''' Consulta de estados de actividad
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Public Function Insert(ByVal Cod_Est As String, ByVal Nom_Est As String, ByVal Imagen As String, ByVal Color As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO PESTADOSACT(Cod_Est, Nom_Est, Imagen, Color)VALUES(:Cod_Est, :Nom_Est, :Imagen, :Color)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Est", Cod_Est)
            Me.AsignarParametroCadena(":Nom_Est", Nom_Est)
            Me.AsignarParametroCadena(":Imagen", Imagen)
            Me.AsignarParametroCadena(":Color", Color)

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
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPK(ByVal Cod_Est As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.VistaDB + " Where Cod_Est=:Cod_Est"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Est", Cod_Est)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal Cod_Est_PK As String, ByVal Cod_Est As String, ByVal Nom_Est As String, ByVal Imagen As String, ByVal Color As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            If Imagen = "" Then
                querystring = "UPDATE PESTADOSACT SET Cod_Est=:Cod_Est, Nom_Est=:Nom_Est, Color=:Color  WHERE Cod_Est=:Cod_Est_PK"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Cod_Est", Cod_Est)
                Me.AsignarParametroCadena(":Nom_Est", Nom_Est)
                Me.AsignarParametroCadena(":Color", Color)
                Me.AsignarParametroCadena(":Cod_Est_PK", Cod_Est_PK)

                Me.num_reg = Me.EjecutarComando()
                Me.ConfirmarTransaccion()
                Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
                Me.lErrorG = False
            Else
                querystring = "UPDATE PESTADOSACT SET Cod_Est=:Cod_Est, Nom_Est=:Nom_Est, Imagen=:Imagen, Color=:Color  WHERE Cod_Est=:Cod_Est_PK"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Cod_Est", Cod_Est)
                Me.AsignarParametroCadena(":Nom_Est", Nom_Est)
                Me.AsignarParametroCadena(":Imagen", Imagen)
                Me.AsignarParametroCadena(":Color", Color)
                Me.AsignarParametroCadena(":Cod_Est_PK", Cod_Est_PK)

                Me.num_reg = Me.EjecutarComando()
                Me.ConfirmarTransaccion()
                Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
                Me.lErrorG = False
            End If
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Function Delete(ByVal Cod_Est As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM PESTADOSACT WHERE Cod_Est=:Cod_Est"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Est", Cod_Est)

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