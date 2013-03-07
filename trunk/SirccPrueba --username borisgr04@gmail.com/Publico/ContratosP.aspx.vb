Imports System.Data
Partial Class Publico_ContratosP
    Inherits PaginaComun

   
    Protected Sub FiltroConP1_FiltrarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles FiltroConP1.FiltrarClicked
        If FiltroConP1.Activo = "1" Then
            Dim obj As New ConsultaPubliContratos
            Dim dt As DataTable = obj.GetContratos(FiltroConP1.Filtro)
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
            MsgBoxLimpiar(Label2)
        Else
            Me.Label2.Text = "Debe seleccionar otro campo ademas de la vigencia para filtrar."
            MsgBoxAlert(Label2, True)
            Dim dt As New DataTable
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
        End If
        UpdatePanel1.Update()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Me.GridView1.SelectedIndex = CInt(e.CommandArgument)
        If e.CommandName = "Descargar" Then
            Dim obj As New ConsultaPubliContratos
            Dim dt As DataTable = obj.GetId_Minuta(Me.GridView1.SelectedValue)
            If dt.Rows.Count > 0 Then
                Response.Redirect("~/ashx/verDOC.ashx?id=" + dt.Rows(0)("id").ToString)
            Else
                Me.Label2.Text = " En el momento no se puede mostrar el Documento"
                MsgBoxAlert(Label2, True)
            End If


        End If
    End Sub
End Class
