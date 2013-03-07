
Partial Class Procesos_GRadicacion_Default
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HfNumPcon.Value = Session("NumProc")
        HfGrupo.Value = Session("Grupo")
    End Sub
End Class
