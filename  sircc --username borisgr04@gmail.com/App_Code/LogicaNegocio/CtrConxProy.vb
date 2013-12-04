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

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetTercero(ByVal Ide_Ter As String) As DataTable
        ctx.Conectar()
        Dim querystring As String
        querystring = " Select   Tip_Ide, Ide_Ter,dv_ter,Nom_Ter,dir_Ter,Tel_Ter,Ema_Ter from vterceros where Ide_Ter=:Ide_Ter"
        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":Ide_Ter", Ide_Ter)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function
End Class
