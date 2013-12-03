Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class CtrEgresosSIIAF

    Private ctx As New BDDatosG

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPagos(ByVal Cod_Con As String) As DataTable
        ctx.Conectar()
        Dim querystring As String

        querystring = " Select Vigencia, Num_Orden, Obj_Orden, Fec_Aprobacion, Num_egreso,Fec_egreso, Anticipo, Amortiza,Val_Amortizado "
        querystring += " From pct2013.Morden"
        querystring += " Where(Num_compromiso, Vig_compromiso) "
        querystring += " In (Select Num_Compromiso, Vigencia from pct2013.MCompromiso where Substr(Nro_Documento,0,10) = :Cod_Con)"
        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":Cod_Con", Cod_Con)
        'Throw New Exception(ctx.getComando())
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return dataTb
    End Function

End Class
