Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

<System.ComponentModel.DataObject()> _
Public Class Calendario
    Inherits BDDatos
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetFestivos(ByVal Mes As Integer, ByVal Year As Integer) As DataTable
        Me.Conectar()
        querystring = "Select * from vFestivos where mes=:mes and year =:year"
        Me.CrearComando(querystring)
        Me.AsignarParametroEntero(":mes", Mes)
        Me.AsignarParametroEntero(":year", Year)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetFestivos(ByVal Finicial As Date, ByVal Ffinal As Date) As DataTable
        Me.Conectar()
        querystring = "Select * from vFestivos where fecha between to_date(:fi,'dd/mm/yyyy') and to_date(:ff,'dd/mm/yyyy')"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":fi", Finicial.ToShortDateString)
        Me.AsignarParametroCadena(":ff", Ffinal.ToShortDateString)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function IsFestivo(ByVal Fecha As Date) As Boolean
        Me.Conectar()
        querystring = "Select * from vFestivos where fecha = to_date(:fecha,'dd/mm/yyyy') "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":fecha", Fecha.ToShortDateString)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCronograma(ByVal Finicial As Date, ByVal Ffinal As Date) As DataTable
        Me.Conectar()
        querystring = "Select * from vpcronograma_dias where fecha between to_date(:fi,'dd/mm/yyyy') and to_date(:ff,'dd/mm/yyyy')"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":fi", Finicial.ToShortDateString)
        Me.AsignarParametroCadena(":ff", Ffinal.ToShortDateString)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCronograma(ByVal Finicial As Date, ByVal Ffinal As Date, ByVal Num_Proc As String) As DataTable
        Me.Conectar()
        querystring = "Select * from vpcronograma_dias where fecha between to_date(:fi,'dd/mm/yyyy') and to_date(:ff,'dd/mm/yyyy') and Num_Proc=:Num_Proc"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":fi", Finicial.ToShortDateString)
        Me.AsignarParametroCadena(":ff", Ffinal.ToShortDateString)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class
