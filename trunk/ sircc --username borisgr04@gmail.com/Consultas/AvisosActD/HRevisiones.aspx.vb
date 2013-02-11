
Partial Class Consultas_AvisosActD_HRevisiones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim obj As New HRevisiones
            Me.DtPCon.DataSource = obj.GetByPk(Request("Cod_Sol"))
            Me.DtPCon.DataBind()
            Me.GridView1.DataSource = obj.GetHrev(Request("Cod_Sol"))
            GridView1.DataBind()
        End If
    End Sub
End Class
