
Partial Class Consultas_ConsultasRp_DCompararRp
    Inherits PaginaComun

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lbcod_con.text = Session("Cod_Con")
        Me.LbCod_Con.Text = Request("Cod_Con")
        Me.grd.DataBind()

    End Sub
End Class
