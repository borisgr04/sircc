Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Correos
'Fecha Creaciòn: 5 de Marzo del 2011
'Autor: Boris gonzalez 
<System.ComponentModel.DataObject()> _
Public Class CorreosE
    Inherits BDDatos
    '---------------------------------------------------------------------------------------------------------------

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM CorreosE "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNomb(ByVal Corr_Nomb As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM CorreosE Where Corr_Nomb=:Corr_Nomb "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Corr_Nomb", Corr_Nomb)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
