Option Explicit On
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data



Public Class ConfiguracionDAO

    Private ctx As New BDDatosG



    Public Function GetbyPk(PROPIEDAD As String) As EConfiguracion
        Dim c As EConfiguracion = Nothing
        ctx.Conectar()
        Dim querystring As String = "select PROPIEDAD, VALOR from CONFIGURACION where PROPIEDAD=:PROPIEDAD"
        ctx.CrearComando(querystring)
        ctx.AsignarParametroCadena(":PROPIEDAD", PROPIEDAD)
        Dim dataTb As DataTable = ctx.EjecutarConsultaDataTable()
        ctx.Desconectar()
        If dataTb.Rows.Count > 0 Then
            c = New EConfiguracion()
            c.Propiedad = dataTb.Rows(0)("PROPIEDAD")
            c.Valor = dataTb.Rows(0)("VALOR")
        End If
        Return c
    End Function

End Class


Public Class Conf
    Public Const Busc_Proc As String = "BUSC_PROC"
    Public Const VBP_Todos As String = "BP_Todos"
    Public Const VBP_ADCE As String = "BP_ADCE"
    Public Const VBP_Validados As String = "BP_Validados"
    Public Const Filtro_Contratos As String = "FILTRO_CONTRATOS"

End Class