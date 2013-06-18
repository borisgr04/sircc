
Partial Class CGestion_VerActas_VerActas
    Inherits System.Web.UI.Page

    Dim ct As New CEstContratos

    Public Sub getUltimoID()
        TxtUltimaActa.Text = ct.getUltimoID()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        getUltimoID()
    End Sub
End Class
