Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Municipios de la Base de datos
'Fecha Creaciòn: 19 dic 2009
'Autor: Ronal Javier
<System.ComponentModel.DataObject()> _
Public Class MenuMB
    Inherits BDDatos
    '---------------------------------------------------------------------------------------------------------------

    ''' <summary>
    ''' Retorna las opciones a las que tiene permiso el usuario desde su Dispositivo Movil SmarthPhone
    ''' </summary>
    ''' <param name="UserName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyUser(ByVal UserName As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vMenuMB "
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class
