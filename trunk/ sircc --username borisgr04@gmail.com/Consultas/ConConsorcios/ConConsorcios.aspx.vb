
Partial Class Consultas_ConConsorcios_ConConsorcios
    Inherits PaginaComun

    Protected Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        Dim f As String = txtFiltro.Text
        Dim obj As New CtrConsultasConsorcios


        grdConsorcios.DataSource = obj.GetConsorcios(f)
        grdConsorcios.DataBind()


    End Sub

    Protected Sub grdConsorcios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdConsorcios.SelectedIndexChanged
        'Response.Redirect("Consultas/Contratos/Contratos.aspx?numero=" + grdConsorcios.SelectedValue)
        Redireccionar_Pagina("/Consultas/Contratos/Contratos.aspx?numero=" + grdConsorcios.SelectedValue)
    End Sub
End Class
