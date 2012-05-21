Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel

Public Class GContratosA
    Inherits Contratos
    Private _ResPRad As String
    Property ResPRad() As String
        Get
            Return _ResPRad
        End Get
        Set(ByVal value As String)
            _ResPRad = value
        End Set
    End Property
    Public Sub RadicarA(ByVal Num_Proc As String, ByVal fec_Rad As Date, ByVal Grupo As String)
        Me.Conectar()
        querystring = "PRADICACION"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(100)
        AsignarParametroCad("Num_Proc", Num_Proc)
        'Throw New Exception(fec_Rad.ToShortDateString)
        AsignarParametroCad("Fec_Rad", fec_Rad.ToShortDateString)
        AsignarParametroCad("Grupo", Grupo)
        EjecutarComando()
        Me.ResPRad = preturn.Value.ToString().Replace(Publico.NoPunto_Dec, Publico.Punto_Dec)
        Me.Desconectar()
    End Sub
End Class