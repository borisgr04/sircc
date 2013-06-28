Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Collections.Specialized
Imports System.ComponentModel



'CLASE              : BDDATOS
'DESCRIPCIÓN        : Clase Base de Acceso a la Base de Datos
'AUTOR              : BORIS GONZALEZ.
'FECHA CREACIÓN     : 18 de Julio del 2009
'FECHA MODIFICACION : 23 DE SEPTIEMBRE DE 2010
'AGREGADO A SIRCC2011, 26 de septiembre
<DataObjectAttribute()> _
Public Class BDDatosG
    Inherits BD

    'HEREDADO DE BD CLASE 
    Protected MsgOk As String = "Se Realizó la Operación Exitosamente - "
    Protected usuario As String
    Protected AppName As String
    Protected inLine As Boolean
    Protected num_reg As Integer
    Protected querystring As String
    'Publicos
    Public Doc As String
    Public lErrorG As Boolean
    Public Msg As String = ""

    Public ReadOnly Property Estado_Conexion As String
        Get
            Return Conexion.State.ToString
        End Get
    End Property

    Public Sub ResetConexion()
        If Not Conexion.State.Equals(ConnectionState.Closed) Then
            Conexion.Close()
        End If
    End Sub

    ''' <summary>
    ''' Abre la Conexión con la base de datos
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Sub Conectar()
        'If BDDatos._Conexion.State = ConnectionState.Closed Then
        MyBase.Conectar()
        'End If
        'Inicializar_Usuario()
    End Sub

    Public Sub New()
        MyBase.New()
        Try
            Me.usuario = Membership.GetUser().UserName
            Me.AppName = Membership.ApplicationName.ToString()
            Me.inLine = True
        Catch ex As Exception
            Me.inLine = False
        End Try
    End Sub
    Public Function getComando() As String
        Return Me.vComando.CommandText
    End Function
    ' ''' <summary>
    ' ''' Inicializa el Usuario, MemberShip en la base de datos (v.usap)
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Sub Inicializar_Usuario()
    '    Me.CrearComando("Begin Inicializar_Usuario('" + Me.usuario + "'); End;")
    '    Me.EjecutarComando()
    'End Sub

    'Public Sub InifechaRef(ByVal fecha As Date)
    '    Me.CrearComando("Begin inifecharef(to_date('" + fecha.ToShortDateString + "','dd/mm/yyyy')); End;")
    '    Me.EjecutarComando()
    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
