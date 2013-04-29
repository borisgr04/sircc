Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Con_Cronograma
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsRPT(ByVal Num_ProC As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPCronogramasRPT Where NUM_PROC=:NUM_PROC"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUM_PROC", Num_ProC)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsCal(ByVal Num_ProC As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vpcronogramas_cal Where NUM_PROC=:NUM_PROC"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUM_PROC", Num_ProC)
        'Throw New Exception(vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
