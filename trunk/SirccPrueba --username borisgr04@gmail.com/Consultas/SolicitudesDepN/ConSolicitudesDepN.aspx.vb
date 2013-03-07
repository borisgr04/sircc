
Partial Class Consultas_ConSolicitudesDepN
    Inherits PaginaComun

    Dim obj As New Sol_Adiciones
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.TxtDesde.Text = Now.AddMonths(-1).ToShortDateString
            Me.TxtHasta.Text = Now.ToShortDateString
            Me.GridView1.DataBind()
            If Not IsPostBack Then
                If Request.QueryString.Count > 0 Then
                    querystringSeguro = Me.GetRequest
                    TxtNSol.Text = querystringSeguro("Cod_Sol")
                    GridView1.DataBind()
                End If
            End If
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Cod_Sol") = GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString()
        Redireccionar_Pagina("/Consultas/SolicitudesDepN/ConDetSolicitudesDepN.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
