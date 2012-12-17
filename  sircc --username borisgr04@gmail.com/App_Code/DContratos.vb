Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
'Clase para manejar la Tabla Contratos
'Fecha Creaciòn: 19 dic 2010
'Autor: Boris Gonzalez Rivera
'
''' <summary>
''' Documentos Susceptibles de legalización
''' </summary>
''' <remarks></remarks>
Public Class DContratos
    Inherits BDDatos
    Dim Vigencia As String
    Dim Tip_Con As String
    Dim NroCon As String
    Private _NumPol As String
    Property NumPol() As String
        Get
            Return _NumPol
        End Get
        Set(ByVal value As String)
            _NumPol = value
        End Set
    End Property
    ReadOnly Property Cod_Con As String
        Get
            Return NroCon
        End Get
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Cod_Con As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vDContratos Where Cod_Con=:Cod_Con"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Con", Cod_Con)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function Update(ByVal Documento As String, ByVal Fec_Apr_Pol As Date, ByVal Legalizado As String, ByVal Tipo As String, ByVal Proceso As String, ByVal grupo As String, ByVal Exenpol As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            If Tipo = "CONTRATOS" Then
                'ValidarPolizas(Documento, Proceso, grupo)
                If CInt(Me.NumPol) > 0 Then
                    Throw New Exception("No se han diligenciado todas la Polizas requeridas para la legalizacion del contrato")
                End If
                querystring = " UPDATE CONTRATOS SET Fec_Apr_Pol=To_Date(:Fec_Apr_Pol,'dd/mm/yyyy'), Legalizado=:Legalizado, ExenPol=:ExenPol WHERE Cod_Con=:Documento"
            ElseIf Tipo = "ADICIONES" Then
                querystring = " UPDATE ADICIONES SET Fec_Apr_Pol=To_Date(:Fec_Apr_Pol,'dd/mm/yyyy'), Legalizado=:Legalizado, ExenPol=:ExenPol WHERE Nro_Adi=:Documento"
            End If
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Fec_Apr_Pol", Fec_Apr_Pol)
            Me.AsignarParametroCadena(":Legalizado", Legalizado)
            Me.AsignarParametroCadena(":Documento", Documento)
            Me.AsignarParametroCadena(":ExenPol", Exenpol)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            'Me.Msg = Me._Comando.CommandText
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Sub ValidarPolizas(ByVal Cod_Con As String, ByVal Num_Proc As String, ByVal grupo As String)
        querystring = "VALPOLIZAS_CON"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("COD_CONTRATO", Cod_Con)
        AsignarParametroCad("NUM_PROCESO", Num_Proc)
        AsignarParametroCad("GRUPO_PROC", grupo)
        EjecutarComando()
        Me.NumPol = preturn.Value.ToString
    End Sub
End Class
