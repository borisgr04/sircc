Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common


Public Class AdicionesOficios
    Inherits BDDatos

    ''' <summary>
    ''' Retorna los todos los registros de la tabla de la Base de datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPk(Nro_Adi As String) As DataTable
        Dim queryString As String = "SELECT * FROM  adiciones Where Nro_Adi='" + Nro_Adi + "'"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function


End Class
