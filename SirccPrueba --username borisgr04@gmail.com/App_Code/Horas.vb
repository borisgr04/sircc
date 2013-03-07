Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Municipios de la Base de datos
'Fecha Creaciòn: 19 dic 2009
'Autor: Ronal Javier
<System.ComponentModel.DataObject()> _
Public Class Horas
    Inherits BDDatos
    '---------------------------------------------------------------------------------------------------------------
    Sub New()

        Me.Vista = "vHoras"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + ""
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal FechaI As Date, ByVal HoraI As Integer, ByVal FechaF As Date) As DataTable
        Dim dataTb As DataTable = New DataTable

        If FechaI = FechaF Then
            Me.Conectar()
            querystring = "SELECT * FROM " + Me.Vista + " Where Cod_Hor >= :HoraI"
            Me.CrearComando(querystring)
            AsignarParametroEntero(":HoraI", HoraI)
            dataTb = Me.EjecutarConsultaDataTable()
            Me.Desconectar()
        ElseIf FechaI <= FechaF Then
            dataTb = GetRecords()
        End If

        Return dataTb
    End Function

End Class
