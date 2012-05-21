Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Municipios de la Base de datos
'Fecha Creaciòn: 19 dic 2009
'Autor: Ronal Javier
<System.ComponentModel.DataObject()> _
Public Class PPlantillas_Campos
    Inherits BDDatos
    '---------------------------------------------------------------------------------------------------------------

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Vista As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPPlantillas_Campos where vista=:vista"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":vista", Vista)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class
