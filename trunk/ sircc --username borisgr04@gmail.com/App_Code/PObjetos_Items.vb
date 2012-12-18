Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data


Public Class PObjetos_Items
    Inherits BDDatos

    Public num_gproc As String
    Public grupo As Integer
    Public Id_Item As Integer
    Public Desc_Item As String
    Public Can_Item As Integer
    Public Uni_Item As String
    Public Val_Uni_Item As Decimal
    Public Iva_Item As Decimal

    Sub New()
        Me.Tabla = "PObjetos_Items"
        Me.Tabla = "PObjetos_Items"
        Me.Vista = "vpobjetos_items"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Num_GProc As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where num_proc='" + Num_GProc + "' And grupo=" + Grupo
        Me.CrearComando(querystring)
        'Throw New Exception(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Pk1 As String, ByVal Pk2 As String, ByVal Pk3 As String) As Boolean
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where num_proc='" + Pk1 + "' And grupo=" + Pk2 + " And Id_item =" + Pk3
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Me.num_gproc = dataTb.Rows(0)("num_proc")
            Me.grupo = dataTb.Rows(0)("grupo")
            Me.Id_Item = dataTb.Rows(0)("Id_Item")
            Me.Desc_Item = dataTb.Rows(0)("Desc_Item")
            Me.Can_Item = dataTb.Rows(0)("Can_Item")
            Me.Uni_Item = dataTb.Rows(0)("Uni_Item")
            Me.Val_Uni_Item = dataTb.Rows(0)("Val_Uni_Item")
            Me.Iva_Item = dataTb.Rows(0)("Iva_Item")
            Return True
        Else
            Return False
        End If
    End Function
    'GetbyPk

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert() As String
        Conectar()
        Try
            querystring = "INSERT INTO PObjetos_Items (num_gproc, grupo,  Desc_item, Can_Item,Uni_Item, Val_Uni_Item,Iva_Item) VALUES"
            querystring += " (:num_gproc, :grupo,  :Desc_item, :Can_Item,:Uni_Item, :Val_Uni_Item,:Iva_Item)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":num_gproc", num_gproc)
            Me.AsignarParametroEntero(":grupo", grupo)
            Me.AsignarParametroCadena(":Desc_item", Desc_Item)
            Me.AsignarParametroEntero(":Can_Item", Can_Item)
            Me.AsignarParametroCadena(":Uni_Item", Uni_Item)
            Me.AsignarParametroDecimal(":Val_uni_item", Val_Uni_Item)
            Me.AsignarParametroDecimal(":Iva_Item", Iva_Item)

            Me.num_reg = Me.EjecutarComando()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try

        Return Msg
    End Function


    Public Function Update() As String
        Conectar()
        Try
            querystring = "UPDATE " + Tabla + " SET Desc_item=:Desc_item, Can_Item=:Can_Item,Uni_Item=:Uni_Item, Val_Uni_Item=:Val_Uni_Item,Iva_Item=:Iva_Item "
            querystring += "WHERE id_Item=:id_itemPK And num_gproc=:num_gprocPk And grupo=:grupoPk"
            Me.CrearComando(querystring)

            Me.AsignarParametroCadena(":Desc_item", Desc_Item)
            Me.AsignarParametroEntero(":Can_Item", Can_Item)
            Me.AsignarParametroCadena(":Uni_Item", Uni_Item)
            Me.AsignarParametroDecimal(":Val_uni_item", Val_Uni_Item)
            Me.AsignarParametroDecimal(":Iva_Item", Iva_Item)

            Me.AsignarParametroEntero(":id_itemPK", Id_Item)
            Me.AsignarParametroCadena(":num_gprocPk", num_gproc)
            Me.AsignarParametroCadena(":grupoPk", grupo)

            'Throw New Exception(Me.vComando.CommandText)
            Me.num_reg = Me.EjecutarComando()

            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try

        Return Msg
    End Function

    Public Function Delete() As String
        Conectar()
        Try
            querystring = "DELETE FROM " + Tabla + " WHERE id_Item=:id_itemPK And num_gproc=:num_gprocPk And grupo=:grupoPk"
            Me.CrearComando(querystring)

            Me.AsignarParametroEntero(":id_itemPK", Id_Item)
            Me.AsignarParametroCadena(":num_gprocPk", num_gproc)
            Me.AsignarParametroCadena(":grupoPk", grupo)

            Me.num_reg = Me.EjecutarComando()

            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            lErrorG = False
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
        Finally
            Desconectar()
        End Try

        Return Msg
    End Function

End Class


