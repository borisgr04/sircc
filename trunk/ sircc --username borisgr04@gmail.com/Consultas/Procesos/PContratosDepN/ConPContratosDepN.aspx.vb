
Partial Class Consultas_ConPContratosDepN
    Inherits PaginaComun

    Dim obj As New Sol_Adiciones
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.GridView1.DataBind()
            If Not IsPostBack Then
                If Request.QueryString.Count > 0 Then
                    querystringSeguro = Me.GetRequest
                    TxtNSol.Text = querystringSeguro("Num_Proc")
                    GridView1.DataBind()
                End If
            End If
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Num_Proc") = GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString()
        Redireccionar_Pagina("/Consultas/Procesos/PContratosDepN/ConDetPContratosDepN.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
