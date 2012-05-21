
Partial Class Procesos_NuevoProceso_Minuta
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim mt As VerMinuta = New VerMinuta()
        'Me.Title = Request("Proceso")
        'Response.Write(mt.GenerarHTML(Request("Proceso")))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim W As AutoComplete = New AutoComplete
        Me.GridView1.DataSource = W.GetTerceros(Me.TxtNprocA.Text, 10)
        Me.GridView1.DataBind()

    End Sub

    Protected Sub TxtNprocA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNprocA.TextChanged
        Dim W As AutoComplete = New AutoComplete
        Me.GridView1.DataSource = W.GetTerceros(Me.TxtNprocA.Text, 10)
        Me.GridView1.DataBind()
    End Sub
End Class
