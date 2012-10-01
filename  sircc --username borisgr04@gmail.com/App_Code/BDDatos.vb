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
Public Class BDDatos
    Inherits BD

    'HEREDADO DE BD CLASE 
    Protected MsgOk As String = "Se Realizó la Operación Exitosamente - "
    Protected Tabla As String
    Protected VistaDB As String
    Protected Vista As String
    Protected usuario As String
    Protected Ruta_Doc As String
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
    '''  Retorna resultados de sentencia select
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSelect(ByVal Sql As String) As DataTable
        Dim dt As DataTable = New DataTable
        If Not String.IsNullOrEmpty(Sql) Then
            Dim queryString As String = Sql
            Me.Conectar()
            Me.CrearComando(queryString)
            dt = Me.EjecutarConsultaDataTable()
            Me.Desconectar()
        End If
        Return dt
    End Function
    ''' <summary>
    ''' Retorna los todos los registros de la tabla de la Base de datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overridable Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overridable Function GetRecordsDB() As DataTable
        Dim queryString As String = "SELECT * FROM  " + VistaDB
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
    ''' <summary>
    '''  Retorna los todos los registros de la tabla de la Base de datos, segun el filtro especificado
    ''' </summary>
    ''' <param name="Filtro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecords(ByVal Filtro As String) As DataTable
        Dim queryString As String = "SELECT * FROM " + Vista + " Where " + Filtro
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSession() As DataTable
        Dim queryString As String = "select username,status,count(*) Cantidad from v$session group by username,status"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    '
    ''' <summary>
    ''' Abre la Conexión con la base de datos
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Sub Conectar()
        'If BDDatos._Conexion.State = ConnectionState.Closed Then
        MyBase.Conectar()
        'End If

        Inicializar_Usuario()
    End Sub

    Public Sub New()
        MyBase.New()
        'Me.Ruta_Doc = ConfigurationManager.AppSettings("RUTA_DOC").ToString
        Try
            Me.usuario = Membership.GetUser().UserName
            Me.AppName = Membership.ApplicationName.ToString()
            Me.inLine = True

        Catch ex As Exception
            Me.inLine = False
        End Try
    End Sub

    ''' <summary>
    ''' Inicializa el Usuario, MemberShip en la base de datos (v.usap)
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ExeComando(ByVal Sql As String) As Integer
        Me.Conectar()
        Me.CrearComando(Sql)
        Dim nr As Integer
        nr = Me.EjecutarComando()
        Desconectar()
        Return nr
    End Function
    ''' <summary>
    ''' Inicializa el Usuario, MemberShip en la base de datos (v.usap)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Inicializar_Usuario()
        Me.CrearComando("Begin Inicializar_Usuario('" + Me.usuario + "'); End;")
        Me.EjecutarComando()
    End Sub

    Public Sub InifechaRef(ByVal fecha As Date)
        Me.CrearComando("Begin inifecharef(to_date('" + fecha.ToShortDateString + "','dd/mm/yyyy')); End;")
        Me.EjecutarComando()
    End Sub

    ''' <summary>
    ''' Retorna los todos los registros de la tabla de la Base de datos, segun el filtro especificado
    ''' </summary>
    ''' <param name="cTabla"></param>
    ''' <param name="cFiltro"></param>
    ''' <param name="cCampos"></param>
    ''' <param name="mSQl"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetTabla(ByVal cTabla As String, ByVal cFiltro As String, Optional ByVal cCampos As String = "*", Optional ByVal mSQl As String = "") As DataTable
        querystring = "SELECT " & cCampos & " FROM " + cTabla + " Where " + cFiltro + " " + mSQl
        Me.Conectar()
        Me.CrearComando(querystring)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
