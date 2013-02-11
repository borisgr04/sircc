
Partial Class Consultas_AvisosActD_Con_Documentos
    Inherits PaginaComun
    Dim obj As New Con_Documentos
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            DetPContratoF1.CodigoPContrato = Request("Cod_PCon")
            DetPContratoF1.Buscar()
            grdDocP.DataSource = obj.GetDocs(Request("Cod_PCon"))
            grdDocP.DataBind()
        End If
    End Sub

    Protected Sub grdDocP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocP.SelectedIndexChanged
        Redireccionar_Pagina("/ashx/VerPDoc.ashx?Id=" + grdDocP.SelectedValue.ToString())
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Redireccionar_Pagina("/ashx/VerDocZip.ashx?Num_Proc=" + Request("Cod_PCon"))
    End Sub
End Class
