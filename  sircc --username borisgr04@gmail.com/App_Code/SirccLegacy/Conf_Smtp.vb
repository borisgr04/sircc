Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Municipios de la Base de datos
'Fecha Creaciòn: 19 dic 2009
'Autor: Ronal Javier
<System.ComponentModel.DataObject()> _
Public Class Conf_Smtp
    Inherits BDDatos
    Dim _puerto As String
    Dim _EnableSSL As String
    Dim _Host As String
    Dim _TimeOut As Long
    Dim _Dominio As String

    Property Dominio As String
        Get
            Return _Dominio
        End Get
        Set(ByVal value As String)
            _Dominio = value
        End Set
    End Property
    '---------------------------------------------------------------------------------------------------------------
    Property Puerto As String
        Get
            Return _puerto
        End Get
        Set(ByVal value As String)
            _puerto = value
        End Set
    End Property
    Property EnableSSL As String
        Get
            Return _EnableSSL
        End Get
        Set(ByVal value As String)
            _EnableSSL = value
        End Set
    End Property

    Property Host As String
        Get
            Return _Host
        End Get
        Set(ByVal value As String)
            _Host = value
        End Set
    End Property

    Property TimeOut As Long
        Get
            Return _TimeOut
        End Get
        Set(ByVal value As Long)
            _TimeOut = value
        End Set
    End Property
       
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Conf_Smtp "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Carga la configración del host de la direccion de correo especificada
    ''' </summary>
    ''' <param name="Mail_Adreess"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function CargarConf(ByVal Mail_Adreess As String) As Boolean
        Me.Conectar()
        Me.Dominio = GetDominio(Mail_Adreess)

        querystring = "SELECT * FROM Conf_Smtp Where Dominio=:Dominio"
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Dominio", GetDominio(Mail_Adreess))
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        If dataTb.Rows.Count > 0 Then
            Me.Puerto = dataTb.Rows(0)("puerto")
            Me.EnableSSL = dataTb.Rows(0)("EnableSSL")
            Me.Host = dataTb.Rows(0)("Host")
            Me.TimeOut = dataTb.Rows(0)("TimeOut")
            Return True
        Else
            Return False 
        End If


    End Function

    Public Shared Function GetDominio(ByVal Direccion As String) As String
        Dim s As String = Direccion
        Return s.Substring(s.LastIndexOf("@"))
    End Function
End Class
