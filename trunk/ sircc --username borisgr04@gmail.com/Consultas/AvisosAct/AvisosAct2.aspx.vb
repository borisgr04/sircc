Imports Telerik.Web.UI
Imports System.Data

Partial Class Consultas_AvisosAct_AvisosAct2
    Inherits PaginaComun

    Protected Sub grdAvisosHoy_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAvisosHoy.RowDataBound, grdProcACargo.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdAvisosHoy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAvisosHoy.SelectedIndexChanged

        querystringSeguro = Me.SetRequest()
        querystringSeguro("Num_Proc") = grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(0).ToString()
        querystringSeguro("ID") = grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(1).ToString()
        'Title = grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(0).ToString() + grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(1).ToString()
        Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        'Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?Num_Proc=" + grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(0).ToString())
    End Sub

    Protected Sub grdAtrazadas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAtrazadas.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdAtrazadas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAtrazadas.SelectedIndexChanged
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Num_Proc") = grdAtrazadas.DataKeys(grdAtrazadas.SelectedIndex).Values(0).ToString()
        querystringSeguro("ID") = grdAtrazadas.DataKeys(grdAtrazadas.SelectedIndex).Values(1).ToString()
        'Title = grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(0).ToString() + grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(1).ToString()
        Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        'Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?Num_Proc=" + grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(0).ToString())
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
        Select Case e.CommandName
            Case "crono"
                querystringSeguro = Me.SetRequest()
                querystringSeguro("Num_Proc") = Num_Proc
                querystringSeguro("ID") = "1" 'grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(1).ToString()
                'Title = grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(0).ToString() + grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(1).ToString()
                Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                'Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?Num_Proc=" + grdAvisosHoy.DataKeys(grdAvisosHoy.SelectedIndex).Values(0).ToString())
            Case "dbproc"
                Redireccionar_Pagina("/Procesos/DBProcesos/DBProcesos.aspx?Num_Proc=" + Num_Proc)
            Case "documentos"
                Redireccionar_Pagina("/Procesos/DocProceso/DocProcesos.aspx?Num_Proc=" + Num_Proc)
            Case "hojaRutas"
                Redireccionar_Pagina("/Procesos/HojaRuta/HojaRuta.aspx?Codigo=" + Num_Proc + "&tp=p")

        End Select
    End Sub

    'Protected Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
    '    querystringSeguro = Me.SetRequest()
    '    querystringSeguro("Num_Proc") = RadGrid2.DataKeys(grdAvisosHoy.SelectedIndex).Values(0).ToString()
    '    querystringSeguro("ID") = RadGrid2.SelectedItems( .DataKeys(grdAvisosHoy.SelectedIndex).Values(1).ToString()
    '    Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))

    'End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim tab1 As RadTab = RadTabStrip1.Tabs.FindTabByValue("hoy")
            tab1.Text = "Actividades para hoy (" + grdAvisosHoy.Rows.Count.ToString + ")"

            Dim tab2 As RadTab = RadTabStrip1.Tabs.FindTabByValue("atrazadas")
            tab2.Text = "Actividades Atrazadas/En Curso (" + grdAtrazadas.Rows.Count.ToString + ")"

            Dim tab3 As RadTab = RadTabStrip1.Tabs.FindTabByValue("sinrecibir")
            tab3.Text = "Solicitudes Sin Recibir (" + grdRecibir.Rows.Count.ToString + ")"

            Dim tab4 As RadTab = RadTabStrip1.Tabs.FindTabByValue("sinrevisar")
            tab4.Text = "Solicitudes Pendientes (" + grdRevisar.Rows.Count.ToString + ")"
            Dim objP As New AvisosAct

            Dim dt As DataTable = objP.GetxUsuario(Session("Vigencia"))
            Dim tab5 As RadTab = RadTabStrip1.Tabs.FindTabByValue("procesos")
            tab5.Text = "Procesos a Cargo (" + dt.Rows.Count.ToString + ")"

            lnkVerTodos.Text = "Ver Todos (" + dt.Rows.Count.ToString + ")"

            Dim t As New Terceros
            If t.GetIsCoordinador() Then
                Me.HyperLink1.Visible = True
                Me.HyperLink2.Visible = True
                Me.IBtnNuevo.Visible = True
                IBtnPanelD.Visible = True
            Else
                Me.HyperLink1.Visible = False
                Me.HyperLink2.Visible = False
                Me.IBtnNuevo.Visible = False
                IBtnPanelD.Visible = False
            End If
        End If


        'dt = objP.GetMisProcesos()
        'For Each row As DataRow In dt.Rows
        '    Dim rtadd As New RadTab(row("Estado") + "(" + row("cantidad").ToString + ")", row("Estado"))
        '    rtadd.PageViewID = "RadPageView5"
        '    RadTabStrip1.Tabs.Item(4).Tabs.Add(rtadd)
        'Next

    End Sub

    Protected Sub lnkVerTodos_Click(sender As Object, e As System.EventArgs) Handles lnkVerTodos.Click
        HdPNom_Est.Value = ""
        grdProcACargo.DataBind()
    End Sub

    Protected Sub IBtnNuevo_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        Response.Redirect(HyperLink2.NavigateUrl)
    End Sub

    Protected Sub IBtnPanelD_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnPanelD.Click
        Response.Redirect(HyperLink1.NavigateUrl)
    End Sub

    Protected Sub grdRevisar_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdRevisar.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.grdRevisar.SelectedIndex = index
        Dim Num_Proc = grdRevisar.DataKeys(grdRevisar.SelectedIndex).Values(0).ToString()
        If e.CommandName = "hojaRutas" Then
            Redireccionar_Pagina("/Procesos/HojaRuta/HojaRuta.aspx?Codigo=" + Num_Proc + "&tp=s")
        End If



    End Sub
End Class
