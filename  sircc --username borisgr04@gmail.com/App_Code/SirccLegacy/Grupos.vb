Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Public Class Grupos
    Inherits BDDatos
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyProc(ByVal Num_Proc As String) As DataTable
        Me.Conectar()
        querystring = "SELECT grupo, 'NUMERO '||grupo Grupos from gprocesos Where Pro_Sel_Nro=:Num_Proc"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
