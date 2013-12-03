Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class CtrConxProy
    Private ctx As New BDDatosG

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetContratos(ByVal Proyecto As String) As DataTable
        ctx.Conectar()
        Dim querystring As String
        querystring = " select cod_con, obj_con from contratos where cod_con In (Select Cod_Con from cproyectos cp where cp.Proyecto=:Proyecto) "
        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":Proyecto", Proyecto)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function
End Class
