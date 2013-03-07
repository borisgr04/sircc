
Partial Class Seguridad_Conf_Conf
    Inherits System.Web.UI.Page

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim bd As New BDDatos

        LbResult.Text = bd.ExeComando(TxtSql0.Text).ToString
    End Sub
End Class
