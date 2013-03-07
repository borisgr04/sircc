Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Municipios de la Base de datos
'Fecha Creaciòn: 19 dic 2009
'Autor: Ronal Javier
<System.ComponentModel.DataObject()> _
Public Class GP_Ppto
    Inherits BDDatos
    '---------------------------------------------------------------------------------------------------------------

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Gp_Ppto "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Num_Proc As String, ByVal Grupo As String, ByVal Nom_Item As String, ByVal Tipo_Item As String, ByVal Unidad As String, ByVal Cantidad As Decimal, ByVal Valor_Unit As Decimal, ByVal Porcentaje_IVA As Decimal, ByVal Porc_Iva As String, ByVal Id_Item As String, ByVal Fec_Mod As String, ByVal Usap As String, ByVal Valor_Parcial As Decimal, ByVal Usbd As String, ByVal Usap_Mod As String, ByVal Fec_Reg As String, ByVal Usbd_Mod As String) As String
        Try
            Conectar()
            querystring = "INSERT INTO Gp_Ppto(Num_Proc, Grupo, Nom_Item, Tipo_Item, Unidad, Cantidad, Valor_Unit, Porc_Iva)VALUES(:Num_Proc, :Grupo, :Nom_Item, :Tipo_Item, :Unidad, :Cantidad, :Valor_Unit, :Porc_Iva) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Proc", Num_Proc)

            Me.AsignarParametroCadena(":Grupo", Grupo)
            Me.AsignarParametroCadena(":Nom_Item", Nom_Item)
            Me.AsignarParametroCadena(":Tipo_Item", Tipo_Item)
            Me.AsignarParametroCadena(":Unidad", Unidad)

            Me.AsignarParametroDecimal(":Cantidad", Cantidad)
            Me.AsignarParametroDecimal(":Valor_Unit", Grupo)
            Me.AsignarParametroDecimal(":Porc_Iva", Porcentaje_IVA)

            'Throw New Exception(_Comando.CommandText)
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

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal Num_Proc As String, ByVal Grupo As String, ByVal Nom_Item As String, ByVal Tipo_Item As String, ByVal Unidad As String, ByVal Cantidad As Decimal, ByVal Valor_Unit As Decimal, ByVal Porcentaje_IVA As Decimal, ByVal Original_Id_Item As String, ByVal Porc_Iva As String, ByVal Valor_Parcial As String) As String
        Try
            Conectar()
            querystring = "UPDATE Gp_Ppto SET Num_Proc=:Num_Proc, Grupo=:Grupo, Nom_Item=:Nom_Item, Tipo_Item=:Tipo_Item, Unidad=: Unidad, Cantidad=:Cantidad, Valor_Unit=:Valor_Unit, Porc_Iva=:Porc_Iva"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Proc", Num_Proc)

            Me.AsignarParametroCadena(":Grupo", Grupo)
            Me.AsignarParametroCadena(":Nom_Item", Nom_Item)
            Me.AsignarParametroCadena(":Tipo_Item", Tipo_Item)
            Me.AsignarParametroCadena(":Unidad", Unidad)

            Me.AsignarParametroDecimal(":Cantidad", Cantidad)
            Me.AsignarParametroDecimal(":Valor_Unit", Grupo)
            Me.AsignarParametroDecimal(":Porckkkk_Iva", Porcentaje_IVA)

            Me.AsignarParametroCadena(":Id_Item_o", Original_Id_Item)
            'Throw New Exception(_Comando.CommandText)
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
