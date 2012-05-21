
Partial Class Consultas_ConDetSolicitudesDepN
    Inherits PaginaComun

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString.Count > 0 Then
                querystringSeguro = Me.GetRequest
                HFCod_Sol.Value = querystringSeguro("Cod_Sol")
            End If
        End If
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Cod_Sol") = DtPCon.SelectedValue
        Redireccionar_Pagina("/Consultas/SolicitudesDepN/ConSolicitudesDepN.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Num_Proc") = GridView2.DataKeys(GridView2.SelectedIndex).Values(0).ToString()
        Redireccionar_Pagina("/Consultas/Procesos/PContratosDepN/ConDetPContratosDepN.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
