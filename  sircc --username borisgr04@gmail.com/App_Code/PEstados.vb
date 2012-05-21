Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class PEstados
    Inherits BDDatos

    ''' <summary>
    ''' Se actualizo de tabla  a vista. Ing Boris G. 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPestados "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyTprocCrono(ByVal Cod_Tpro As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPestados_Crono Where Cod_Tpro=:Cod_Tpro"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
End Class