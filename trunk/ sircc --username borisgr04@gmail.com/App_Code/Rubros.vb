Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Rubros
    Inherits BDDatos
    Public Sub New()

        Me.Tabla = "RUBROS"
        Me.Vista = "RUBROS"
        Me.VistaDB = "RUBROS"

    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  " + Vista
        'Me.Desconectar()
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyVigencia(ByVal Vigencia As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM RUBROS Where Vigencia=:Vigencia"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Vigencia", Vigencia)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Vigencia As String, ByVal Rubro As String) As DataTable
        Me.Conectar()
        If Not String.IsNullOrEmpty(Rubro) Then
            querystring = "SELECT * FROM  RUBROS WHERE Vigencia=:Vigencia And (COD_RUB LIKE :COD_RUB or Upper(DES_RUB) LIKE :NOM_RUB)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Vigencia", Vigencia)
            Me.AsignarParametroCadena(":COD_RUB", "%" + Rubro + "%")
            Me.AsignarParametroCadena(":NOM_RUB", "%" + UCase(Rubro) + "%")
        Else
            querystring = "SELECT * FROM  " + Vista + " WHERE 1=0"
            Me.CrearComando(querystring)
        End If
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPK(ByVal Cod_Rub As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM RUBROS Where Cod_Rub=:Cod_Rub"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Rub", Cod_Rub)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
