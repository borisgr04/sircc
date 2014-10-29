Imports Microsoft.VisualBasic
Imports System.Data

Public Class CesionesDAO
    Private ctx As New BDDatosG

    Public Function GetRecords(Cod_Con As String) As DataTable
        Dim querystring As String
        ctx.Conectar()
        querystring = " Select TAnt.NOM_TER Contratista_Anterior, TNew.NOM_TER Contratista_Nuevo,Pla_Ces Plazo_Cesion,Val_Ces Valor_Cesion,Fec_Ces Fecha_Cesion,Res_Aut Resolucion,Fec_Res Fecha_Resolucion from Cesiones C"
        querystring += " Inner Join vTerceros TAnt On TAnt.IDE_TER=C.Nit_Ant "
        querystring += " Inner Join vTerceros TNew On TNew.IDE_TER=C.Nit_Nue "
        querystring += " Where Cod_Con=:Cod_Con "

        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":Cod_Con", cod_con)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function

End Class
