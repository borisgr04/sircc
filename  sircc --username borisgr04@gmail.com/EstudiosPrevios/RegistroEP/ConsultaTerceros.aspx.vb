
Partial Class EstudiosPrevios_RegistroEP_ConsultaTerceros
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim t As New TercerosDAO
        GridView1.DataSource = t.GetAll()
        GridView1.DataBind()

    End Sub
End Class
