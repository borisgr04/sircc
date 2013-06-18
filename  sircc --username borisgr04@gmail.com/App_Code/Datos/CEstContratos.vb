Imports Microsoft.VisualBasic
Imports System.Data

Public Class CEstContratos
    Private ctx As New BDDatosG
    Public Function getActabyID(Id As String) As DataTable
        ctx.Conectar()
        Dim querystring As String = "SELECT ESTADO_INICIAL, ESTADO_FINAL, FECHA, DOCUMENTO, USUARIO, NRO_CONTRATO, EXT , 0 DIAS_EJEC, OBSERVACION,NRO_DOC,NVISITAS,VALOR_PAGO,por_eje_fis,ID FROM VGESACTAS WHERE (ID = :ID) "
        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":ID", Id)
        Dim datat As New DataTable
        datat = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        Return datat
    End Function

    Function getUltimoID() As String
        ctx.Conectar()
        Dim querystring As String = "SELECT Max(ID) FROM VGESACTAS  "
        ctx.CrearComando(querystring)
        Dim datat As String
        datat = ctx.EjecutarEscalar()
        Return datat
    End Function

End Class
