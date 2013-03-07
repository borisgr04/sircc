
Partial Class Consultas_AvisosAct_Default
    Inherits PaginaComun

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        querystringSeguro = Me.SetRequest()
        querystringSeguro("Num_Proc") = GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString()
        querystringSeguro("ID") = GridView1.DataKeys(GridView1.SelectedIndex).Values(1).ToString()
        'Title = GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString() + GridView1.DataKeys(GridView1.SelectedIndex).Values(1).ToString()
        Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        'Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?Num_Proc=" + GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString())
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Num_Proc") = GridView2.DataKeys(GridView2.SelectedIndex).Values(0).ToString()
        querystringSeguro("ID") = GridView2.DataKeys(GridView2.SelectedIndex).Values(1).ToString()
        'Title = GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString() + GridView1.DataKeys(GridView1.SelectedIndex).Values(1).ToString()
        Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        'Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?Num_Proc=" + GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString())
    End Sub

   
    Protected Sub Selecc_DTProc(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtProcesosACargo.SelectedIndexChanged
        HdPNom_Est.Value = DirectCast(sender, LinkButton).CommandArgument
    End Sub

    Protected Sub grdRevisar_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRevisar.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdRecibir_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRecibir.SelectedIndexChanged
        Redireccionar_Pagina("/Solicitudes/Recibido/Recibido.aspx?Cod_Sol=" + grdRecibir.SelectedValue)
    End Sub

    Protected Sub grdRevisar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRevisar.SelectedIndexChanged
        Redireccionar_Pagina("/Solicitudes/ReporteRevision/ReporteRevision.aspx?Cod_Sol=" + grdRevisar.SelectedValue)
    End Sub

    Protected Sub grdProcACargo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProcACargo.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.grdProcACargo.SelectedIndex = index
        Dim Num_Proc = grdProcACargo.DataKeys(grdProcACargo.SelectedIndex).Values(0).ToString()
        Select e.CommandName
            Case "crono"
                querystringSeguro = Me.SetRequest()
                querystringSeguro("Num_Proc") = Num_Proc
                querystringSeguro("ID") = "1" 'GridView1.DataKeys(GridView1.SelectedIndex).Values(1).ToString()
                'Title = GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString() + GridView1.DataKeys(GridView1.SelectedIndex).Values(1).ToString()
                Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                'Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?Num_Proc=" + GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString())
            Case "dbproc"
                Redireccionar_Pagina("/Procesos/DBProcesos/DBProcesos.aspx?Num_Proc=" + Num_Proc)
            Case "documentos"
                Redireccionar_Pagina("/Procesos/DocProceso/DocProcesos.aspx?Num_Proc=" + Num_Proc)
        End Select
    End Sub
End Class
