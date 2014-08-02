Imports System.Data
Imports System.IO
Partial Class Contratos_GDocumentos_HEAD_Oficios_Head
    Inherits PaginaComun

    Sub Designar()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Nro_Cto") = DetContratoN1.Cod_Con
        Redireccionar_Pagina("/Contratos/GDocumentos/Designacion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
    Sub RPC()

        querystringSeguro = Me.SetRequest()
        querystringSeguro("Nro_Cto") = DetContratoN1.Cod_Con
        Redireccionar_Pagina("/Contratos/GDocumentos/HEAD/PresServProf/PPalServProf.aspx?Nro_Cto=" + DetContratoN1.Cod_Con)
    End Sub
 

    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.DetContratoN1.ValoraBuscar = Request("Numero")
            Me.DetContratoN1.Buscar()
        End If

    End Sub

    Protected Sub LnkOficios_Click(sender As Object, e As EventArgs) Handles LnkOficios.Click
        Me.DetContratoN1.Buscar()
        If DetContratoN1.dtContratos.Rows.Count > 0 Then
            RPC()
        Else
            Me.MsgResult.Text = "No es posible generar el oficio, el Nro de contrato digitado no existe o es nulo"
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub
End Class


