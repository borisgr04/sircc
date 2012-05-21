Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class PagosParciales
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

        Me.Tabla = "PAGOS_PARCIALES"
        Me.Vista = "VPAGOS_PARCIALES"
        Me.VistaDB = "PAGOS_PARCIALES"

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
    Public Function GetbyNum_Proc(ByVal Num_Proc As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VPAGOS_PARCIALES Where Num_Proc=:Num_Proc"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function Insert(ByVal Num_Proc As String, ByVal Fec_Pago As Date, ByVal Tipo_pago As String, ByVal Val_Pago As Decimal, ByVal Condicion_Pago As String, ByVal CalPorcentaje As Boolean) As String
        Dim valpcon As New PContratos
        Dim dt As New DataTable
        Dim val_pa As Decimal
        Dim porcentaje As Decimal
        Me.Conectar()
        valpcon.Conexion = Me.Conexion
        Dim Val_Apo_Prop As Decimal = valpcon.ValordelContrato(Num_Proc)
        Dim Val_FormaPago = Valor_Programado(Num_Proc)
        Me.Valor_Restante = Val_Apo_Prop - Val_FormaPago

        If CalPorcentaje Then
            porcentaje = Val_Pago / 100
            val_pa = Val_Apo_Prop * porcentaje
            porcentaje = Math.Round(porcentaje, 4)
        Else
            val_pa = Val_Pago
            porcentaje = ((val_pa) / (Val_Apo_Prop))
            porcentaje = Math.Round(porcentaje, 4)
        End If
        Try
            If Me.Valor_Restante < CDbl(val_pa) Then
                Me.lErrorG = True
                Throw New Exception("El valor del Pago no puede ser superior al restante del valor del contrato (" & FormatCurrency(Me.Valor_Restante) & ")")
            ElseIf Me.Valor_Restante = 0 Then
                Me.lErrorG = True
                Throw New Exception("Los pagos han cubierto la totalidad del contrato")
            Else
                Me.ComenzarTransaccion()
                querystring = "INSERT INTO PAGOS_PARCIALES(Num_Proc, Fecha_Pago, Tipo_pago, Valor_Pago, Porcentaje, Condicion_Pago)VALUES(:Num_Proc, to_date(:Fec_Pago, 'dd/mm/yyyy'), :Tipo_pago, :Val_Pago, :Porcentaje, :Condicion_Pago) "
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
                Me.AsignarParametroCadena(":Fec_Pago", Fec_Pago.ToShortDateString)
                Me.AsignarParametroCadena(":Tipo_pago", Tipo_pago)
                Me.AsignarParametroDecimal(":Val_Pago", val_pa)
                Me.AsignarParametroDecimal(":Porcentaje", porcentaje)
                Me.AsignarParametroCadena(":Condicion_Pago", Condicion_Pago)
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


    Public Function Delete(ByVal Id As String, ByVal Num_Pro As String) As String
        Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM PAGOS_PARCIALES WHERE Num_Proc=:Num_Pro AND Id=:Id "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Id", Id)
            Me.AsignarParametroCadena(":Num_Pro", Num_Pro)
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
    Private Function Valor_Programado(ByVal Num_Proc As String) As Decimal
        querystring = "SELECT NVL(SUM(VALOR_PAGO),0) Valor_Prog FROM pagos_parciales WHERE NUM_PROC=:Num_Proc"
        CrearComando(querystring)
        AsignarParametroCadena(":Num_Proc", Num_Proc)
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
End Class
