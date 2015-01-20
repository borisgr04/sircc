Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel


<DataObjectAttribute()> _
Public Class GR_TIP_OFI
    Private ctx As New BDDatosG
    Public Function GetRecordsC(Cod_Con As String) As DataTable
        ctx.Conectar()
        Dim querystring As String = "select tip.tip_ofi , tip.nom_ofi ,ID,NVL(EST_OFI,'NO GENERADO') ESTADO,FEC_OFI   from GR_TIP_OFI  tip left join GD_CT_OFICIOS  ofi on tip.TIP_OFI= ofi.TIP_OFI and ofi.cod_con=:Cod_Con "
        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":Cod_Con", Cod_Con)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function

End Class
