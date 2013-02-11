
Partial Class Consultas_AvisosActD_Con_Cronograma
    Inherits PaginaComun

    Dim obj As New Con_Cronograma

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            DetPContratoF1.CodigoPContrato = Request("Cod_PCon")
            DetPContratoF1.Buscar()
            GridView1.DataSource = obj.GetRecordsRPT(Request("Cod_PCon"))
            GridView1.DataBind()
            HyperLink1.NavigateUrl = "~/Procesos/Programacion/ImprimirCrono.aspx?Num_Proc=" + Request("Cod_PCon")
            HyperLink2.NavigateUrl = "~/Procesos/Programacion/RptCrono.aspx?Num_Proc=" + Request("Cod_PCon")
        End If
    End Sub
End Class
