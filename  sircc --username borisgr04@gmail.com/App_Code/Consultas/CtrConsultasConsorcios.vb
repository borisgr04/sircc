Imports Microsoft.VisualBasic
Imports System.Data


Public Class CtrConsultasConsorcios
    Private ctx As New BDDatosG

    Public Function GetConsorcios(Filtro As String) As DataTable
        ctx.Conectar()
        Dim qry As String
    
        Dim sb = New StringBuilder()
        sb.Append("Select c.Ide_ter,id_miembros,id_estado, porc_part, c.cod_con, tm.NOM_TER Miembro,tc.NOM_TER Nombre, cont.Obj_Con  From ConsorciosUTxC c ")
        sb.Append("Inner Join vTerceros tc on tc.IDE_TER=c.ide_ter ")
        sb.Append("Inner Join vTerceros tm on tm.IDE_TER=c.id_miembros ")
        sb.Append("Inner Join Contratos cont On cont.Cod_Con = c.cod_con ")
        sb.Append("Where Id_Miembros='{0}'")
        qry = String.Format(sb.ToString(), Filtro)
        ctx.CrearComando(qry)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function
End Class
