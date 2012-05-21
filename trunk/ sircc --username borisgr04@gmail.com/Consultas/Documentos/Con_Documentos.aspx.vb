
Partial Class Consultas_Documentos_Con_Documentos
    Inherits PaginaComun
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RadTabStrip1.Visible = True
        End If
    End Sub
End Class
