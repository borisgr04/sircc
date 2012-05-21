Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

<System.ComponentModel.DataObject()> _
Public Class Cons_Proc
    Inherits BDDatos

    Sub New()
        Me.Tabla = "Cons_Proc"
        Me.Vista = "VCons_Proc"
        Me.VistaDB = "VCons_Proc"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsFill(ByVal vigencia As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where vigencia=:vigencia"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":vigencia", vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyTproc(ByVal Cod_Tpro As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where Tip_Proc=:Cod_Tpro"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Public Function Insert(ByVal Vigencia As String, ByVal Dep_Del As String, ByVal Cod_Tpro As String, ByVal Inicial As Integer, ByVal Siguiente As Integer) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "INSERT INTO Cons_Proc(Vigencia, Dep_Del, Tip_proc, Inicial, Siguiente)VALUES(:vigencia, :Dep_Del, :Cod_Tpro, :Inicial, :Siguiente)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Dep_Del", Dep_Del)
            Me.AsignarParametroCadena(":Inicial", Inicial)
            Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)
            Me.AsignarParametroCadena(":vigencia", vigencia)
            Me.AsignarParametroCadena(":Siguiente", Siguiente)


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
    Public Function GetbyPKDB(ByVal Vigencia_PK As String, ByVal Dep_Del_PK As String, ByVal Cod_Tpro_PK As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.VistaDB + " Where Vigencia=:Vigencia_PK and Dep_Del=:Dep_Del_PK and Tip_Proc=:Cod_Tpro_PK"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Vigencia_PK", Vigencia_PK)
        Me.AsignarParametroCadena(":Dep_Del_PK", Dep_Del_PK)
        Me.AsignarParametroCadena(":Cod_Tpro_PK", Cod_Tpro_PK)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal Vigencia_PK As String, ByVal Dep_Del_PK As String, ByVal Cod_Tpro_PK As String, ByVal Vigencia As String, ByVal Dep_Del As String, ByVal Cod_Tpro As String, ByVal Inicial As Integer, ByVal Siguiente As Integer) As String

        Try
            Me.Conectar()
            Me.ComenzarTransaccion()
            querystring = "UPDATE Cons_Proc SET vigencia=:vigencia, Dep_Del=:Dep_Del, Tip_Proc=:Cod_Tpro, Inicial=:Inicial, Siguiente=:Siguiente WHERE Vigencia=:Vigencia_PK and Dep_Del=:Dep_Del_PK and Tip_Proc=:Cod_Tpro_PK"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Dep_Del", Dep_Del)
            Me.AsignarParametroCadena(":Inicial", Inicial)
            Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)
            Me.AsignarParametroCadena(":vigencia", Vigencia)
            Me.AsignarParametroCadena(":Siguiente", Siguiente)
            Me.AsignarParametroCadena(":Vigencia_PK", Vigencia_PK)
            Me.AsignarParametroCadena(":Dep_Del_PK", Dep_Del_PK)
            Me.AsignarParametroCadena(":Cod_Tpro_PK", Cod_Tpro_PK)

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

    Function Delete(ByVal Vigencia_PK As String, ByVal Dep_Del_PK As String, ByVal Cod_Tpro_PK As String) As String
        Me.Conectar()
        Try

            Me.ComenzarTransaccion()
            querystring = "DELETE FROM Cons_Proc WHERE Vigencia=:Vigencia_PK and Dep_Del=:Dep_Del_PK and Tip_Proc=:Cod_Tpro_PK"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Vigencia_PK", Vigencia_PK)
            Me.AsignarParametroCadena(":Dep_Del_PK", Dep_Del_PK)
            Me.AsignarParametroCadena(":Cod_Tpro_PK", Cod_Tpro_PK)

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
