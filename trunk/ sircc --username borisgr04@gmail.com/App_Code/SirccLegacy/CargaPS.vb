Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class CargaPS
    Inherits BDDatos


    ''' <summary>
    '''  Carga de Trabajo Procesos y Solicitudes sin terminar
    ''' </summary>
    ''' <returns>Tabla Estado, Cantidad </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCargaPSxDel(ByVal Dep_PCon As String, Vigencia As String) As DataTable
        Me.Conectar()
        querystring = "Select * from vCargaPS  where  Dep_PCon=:Dep_PCon And codigo like '%" + Vigencia + "'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Dep_PCon", Dep_PCon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
