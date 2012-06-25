
Partial Class Contratos_RadicacionM_MiembrosCSUT
    Inherits PaginaComun



    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ConsorciosUT1.Cod_Con = Request("Cod_Con")
    End Sub

    Protected Sub BtnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        Response.Redirect("radicacionm.aspx?Cod_Con=" + Request("Cod_Con"))
    End Sub
End Class
