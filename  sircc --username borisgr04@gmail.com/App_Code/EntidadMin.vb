Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel
Imports System.Drawing

<System.ComponentModel.DataObject()> _
Public Class EntidadMin
    Dim _Nombre As String
    Dim _Direccion As String
    Dim _Ciudad_Dep As String
    Dim _Telefono As String
    Dim _Lema As String
    Dim _Logo As Byte()
    Dim _Ruta_Logo As String
    Dim _Nit As String
    Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property
    Property Nit As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property
    Property Ruta_Logo As String
        Get
            Return _Ruta_Logo
        End Get
        Set(ByVal value As String)
            _Ruta_Logo = value
        End Set
    End Property
    Property Logo As Byte()
        Get
            Return _Logo
        End Get
        Set(ByVal value As Byte())
            _Logo = value
        End Set
    End Property
    Property Lema As String
        Get
            Return _Lema
        End Get
        Set(ByVal value As String)
            _Lema = value
        End Set
    End Property
    Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property
    Property Ciudad_Dep As String
        Get
            Return _Ciudad_Dep
        End Get
        Set(ByVal value As String)
            _Ciudad_Dep = value
        End Set
    End Property
    Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property




    Public Sub CargarDatos()
        Dim ws As New WS_Sircc_GMinutas
        Dim dtEnt As DataTable
        dtEnt = ws.GetEntidad()

        Me.Nombre = UCase(dtEnt.Rows(0)("Nom_SecPrincipal"))
        Me.Nit = dtEnt.Rows(0)("Nit")
        Me.Direccion = UCase(dtEnt.Rows(0)("Direccion"))
        Me.Ciudad_Dep = UCase(dtEnt.Rows(0)("Ciudad") + "-" + dtEnt.Rows(0)("Departamento"))
        Me.Telefono = dtEnt.Rows(0)("Telefono")
        Me.Lema = UCase(dtEnt.Rows(0)("Municipio"))
        Me.Logo = DirectCast(dtEnt.Rows(0)("Logo_Rpt"), Byte())

        Me.Ruta_Logo = GMinuta.FolderEspecial + "Logo.jpg"
        Dim img As Bitmap = Util.Bytes2Image(Logo)
        If Not img.Size.IsEmpty Then
            Util.SaveJPG(img, Ruta_Logo)
        End If
    End Sub




End Class

