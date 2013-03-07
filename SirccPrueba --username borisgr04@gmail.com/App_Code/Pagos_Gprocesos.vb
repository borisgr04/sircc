Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Pagos_Gprocesos
    Inherits BDDatos
    Private _Valor_Restante As String
    Property Valor_Restante() As Double
        Get
            Return _Valor_Restante
        End Get
        Set(ByVal value As Double)
            _Valor_Restante = value
        End Set
    End Property
    Public Sub New()

        Me.Tabla = "PAGOS_GPROCESOS"
        Me.Vista = "VPAGOS_GPROCESOS"
        Me.VistaDB = "PAGOS_GPROCESOS"

    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista
        Me.Desconectar()
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyNum_Proc(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VPAGOS_GPROCESOSMIN Where Num_Proc=:Num_Proc And Grupo=:Grupo Order By Fecha_Pago"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function Insert(ByVal Num_Proc As String, ByVal Fec_Pago As Date, ByVal Tipo_pago As String, ByVal Val_Pago As Decimal, ByVal Condicion_Pago As String, ByVal CalPorcentaje As Boolean, ByVal Grupo As String, ByVal PagaGober As String) As String
        Dim valpcon As New GProcesos
        Dim dt As New DataTable
        Dim val_pa As Decimal
        Dim porcentaje As Decimal
        Me.Conectar()
        Me.ComenzarTransaccion()
        valpcon.Conexion = Me.Conexion ' Compartir conexion

        Dim Val_Apo_Prop As Decimal = valpcon.ValorApoProp(Num_Proc, Grupo)
        Dim Val_Tot_Con As Decimal = valpcon.ValordelContrato(Num_Proc, Grupo)
        Dim Val_FormaPago = Valor_Programado(Num_Proc, Grupo)
        Me.Valor_Restante = Val_Apo_Prop - Val_FormaPago

        If CalPorcentaje Then
            porcentaje = Val_Pago / 100
            val_pa = Val_Tot_Con * porcentaje
            porcentaje = Math.Round(porcentaje, 4)
        Else
            val_pa = Val_Pago
            porcentaje = ((val_pa) / (Val_Tot_Con))
            porcentaje = Math.Round(porcentaje, 4)
        End If
        Try
            If Me.Valor_Restante < CDbl(val_pa) And PagaGober = "1" And Tipo_pago <> "AN" Then
                Throw New Exception("El valor del Pago no puede ser superior al restante del valor del contrato (" & FormatCurrency(Me.Valor_Restante) & ")")
            ElseIf Me.Valor_Restante = 0 And PagaGober = "1" And Tipo_pago <> "AN" Then
                Throw New Exception("Los pagos han cubierto la totalidad del contrato")
            Else
                querystring = "INSERT INTO PAGOS_GPROCESOS(Num_Proc, Fecha_Pago, Tipo_pago, Valor_Pago, Porcentaje, Condicion_Pago, Grupo, Paga_Gober)VALUES(:Num_Proc, to_date(:Fec_Pago, 'dd/mm/yyyy'), :Tipo_pago, :Val_Pago, :Porcentaje, :Condicion_Pago, :Grupo, :Paga_Gober) "
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
                Me.AsignarParametroCadena(":Fec_Pago", Fec_Pago.ToShortDateString)
                Me.AsignarParametroCadena(":Tipo_pago", Tipo_pago)
                Me.AsignarParametroDecimal(":Val_Pago", val_pa)
                Me.AsignarParametroDecimal(":Porcentaje", porcentaje)
                Me.AsignarParametroCadena(":Condicion_Pago", Condicion_Pago)
                Me.AsignarParametroCadena(":Grupo", Grupo)
                Me.AsignarParametroCadena(":Paga_Gober", PagaGober)
                'Throw New Exception(_Comando.CommandText)
                Me.num_reg = Me.EjecutarComando()
                Me.ConfirmarTransaccion()
                Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
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

    Public Function Delete(ByVal Id As String, ByVal Num_Pro As String, ByVal Grupo As String) As String
        Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM PAGOS_GPROCESOS WHERE Num_Proc=:Num_Pro AND Id=:Id AND Grupo=:Grupo "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Id", Id)
            Me.AsignarParametroCadena(":Num_Pro", Num_Pro)
            Me.AsignarParametroCadena(":Grupo", Grupo)
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

    Private Function Delete_D(ByVal Id As String, ByVal Num_Pro As String, ByVal Grupo As String) As String
            querystring = "DELETE FROM PAGOS_GPROCESOS WHERE Num_Proc=:Num_Pro AND Id=:Id AND Grupo=:Grupo "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Id", Id)
            Me.AsignarParametroCadena(":Num_Pro", Num_Pro)
            Me.AsignarParametroCadena(":Grupo", Grupo)
            Me.num_reg = Me.EjecutarComando()
        Return Msg
    End Function


    Public Function GetbyPk(ByVal Id As String, ByVal Num_Pro As String, ByVal Grupo As String) As DataTable
        Conectar()
        querystring = "SELECT * FROM PAGOS_GPROCESOS WHERE Num_Proc=:Num_Pro AND Id=:Id AND Grupo=:Grupo "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Id", Id)
        Me.AsignarParametroCadena(":Num_Pro", Num_Pro)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dt As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
    Private Function Valor_Programado(ByVal Num_Proc As String, ByVal Grupo As String) As Decimal
        querystring = "SELECT NVL(SUM(VALOR_PAGO),0) Valor_Prog FROM pagos_gprocesos WHERE NUM_PROC=:Num_Proc and Grupo=:Grupo and Paga_Gober='1' AND TIPO_PAGO<>'AN'"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Proc", Num_Proc)
        AsignarParametroCadena(":Grupo", Grupo)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Return CDec(dt.Rows(0)("Valor_Prog"))
        'querystring = "VALOR_PCONTRATO"
        'CrearComando(querystring)
        'Me._Comando.CommandType = CommandType.StoredProcedure
        'Dim preturn As DbParameter = AsignarParametroReturn(20)
        'AsignarParametroCad("Num_Proc", Num_Proc)
        'EjecutarComando()
        '.ToString().Replace(Publico.NoPunto_Dec, Publico.Punto_Dec)

    End Function

    Public Function Update(ByVal Id_Pago As String, ByVal Num_Proc As String, ByVal Fec_Pago As Date, ByVal Tipo_pago As String, ByVal Val_Pago As Decimal, ByVal Condicion_Pago As String, ByVal CalPorcentaje As Boolean, ByVal Grupo As String, ByVal paga_gober As String) As String
        Dim valpcon As New GProcesos
        Dim dt As New DataTable
        Dim val_pa As Decimal
        Dim porcentaje As Decimal
        Me.Conectar()
        Me.ComenzarTransaccion()
        Try
            Delete_D(Id_Pago, Num_Proc, Grupo)
            valpcon.Conexion = Me.Conexion ' Compartir conexion
            Dim Val_Apo_Prop As Decimal = valpcon.ValorApoProp(Num_Proc, Grupo)
            Dim Val_Tot_Con As Decimal = valpcon.ValordelContrato(Num_Proc, Grupo)
            Dim Val_FormaPago = Valor_Programado(Num_Proc, Grupo)
            Me.Valor_Restante = Val_Apo_Prop - Val_FormaPago

            If CalPorcentaje Then
                porcentaje = Val_Pago / 100
                val_pa = Val_Tot_Con * porcentaje
                porcentaje = Math.Round(porcentaje, 4)
            Else
                val_pa = Val_Pago
                porcentaje = ((val_pa) / (Val_Tot_Con))
                porcentaje = Math.Round(porcentaje, 4)
            End If

            If Me.Valor_Restante < CDbl(val_pa) And paga_gober = "1" And Tipo_pago <> "AN" Then
                Throw New Exception("El valor del Pago no puede ser superior al restante del valor del contrato (" & FormatCurrency(Me.Valor_Restante) & ")")
            ElseIf Me.Valor_Restante = 0 And paga_gober = "1" And Tipo_pago <> "AN" Then
                Throw New Exception("Los pagos han cubierto la totalidad del contrato")
            Else
                querystring = "INSERT INTO PAGOS_GPROCESOS(Num_Proc, Fecha_Pago, Tipo_pago, Valor_Pago, Porcentaje, Condicion_Pago, Grupo, paga_gober)VALUES(:Num_Proc, to_date(:Fec_Pago, 'dd/mm/yyyy'), :Tipo_pago, :Val_Pago, :Porcentaje, :Condicion_Pago, :Grupo, :Paga_Gober) "
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
                Me.AsignarParametroCadena(":Fec_Pago", Fec_Pago.ToShortDateString)
                Me.AsignarParametroCadena(":Tipo_pago", Tipo_pago)
                Me.AsignarParametroDecimal(":Val_Pago", val_pa)
                Me.AsignarParametroDecimal(":Porcentaje", porcentaje)
                Me.AsignarParametroCadena(":Condicion_Pago", Condicion_Pago)
                Me.AsignarParametroCadena(":Grupo", Grupo)
                Me.AsignarParametroCadena(":Paga_Gober", paga_gober)
                'Throw New Exception(_Comando.CommandText)
                Me.num_reg = Me.EjecutarComando()
                Me.ConfirmarTransaccion()
                Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
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

End Class
