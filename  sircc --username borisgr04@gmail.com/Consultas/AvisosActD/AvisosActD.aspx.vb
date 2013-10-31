Imports Telerik.Web.UI
Imports System.Data
Partial Class Consultas_AvisosActD_Default
    Inherits PaginaComun

    Protected Sub grdActHoy_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdActHoy.RowDataBound, grdRecibir.RowDataBound, grdProcACargo.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdActHoy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdActHoy.SelectedIndexChanged
        Dim Num_Proc = grdActHoy.DataKeys(grdActHoy.SelectedIndex).Values(0).ToString()
        Redireccionar_Pagina("/Consultas/AvisosActD/Con_Cronograma.aspx?Cod_PCon=" + Num_Proc)
    End Sub

    Protected Sub grdActAtrazadas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdActAtrazadas.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdActAtrazadas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdActAtrazadas.SelectedIndexChanged
        Dim Num_Proc = grdActAtrazadas.DataKeys(grdActAtrazadas.SelectedIndex).Values(0).ToString()
        Redireccionar_Pagina("/Consultas/AvisosActD/Con_Cronograma.aspx?Cod_PCon=" + Num_Proc)
    End Sub

    Protected Sub Selecc_DTProc(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtProcesosACargo.SelectedIndexChanged
        HdPNom_Est.Value = DirectCast(sender, LinkButton).CommandArgument
        Dim obj As New AvisosActD
        obj.Num_PSol = TxtNSol.Text
        obj.Num_Proc = TxtNSol.Text
        obj.Fec_Ini = TxtDesde.Text
        obj.Fec_Fin = TxtHasta.Text
        grdProcACargo.DataSource = obj.GetProcbyDepDelEstado(HdPNom_Est.Value, Vigencia)
        grdProcACargo.DataBind()
    End Sub

    Protected Sub grdRevisar_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRevisar.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdRecibir_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRecibir.SelectedIndexChanged
        Redireccionar_Pagina("/Solicitudes/NuevaSolicitud/NuevaSolicitud.aspx?Cod_Sol=" + grdRecibir.SelectedValue)
    End Sub

    Protected Sub grdRevisar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRevisar.SelectedIndexChanged
        Redireccionar_Pagina("/Solicitudes/NuevaSolicitud/NuevaSolicitud.aspx?Cod_Sol=" + grdRevisar.SelectedValue)
    End Sub

    Protected Sub grdProcACargo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProcACargo.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.grdProcACargo.SelectedIndex = index
        Dim Num_Proc = grdProcACargo.DataKeys(grdProcACargo.SelectedIndex).Values(0).ToString()
        Select Case e.CommandName
            Case "crono"
                querystringSeguro = Me.SetRequest()
                querystringSeguro("Num_Proc") = Num_Proc
                querystringSeguro("ID") = "1" 'GridView1.DataKeys(GridView1.SelectedIndex).Values(1).ToString()
                'Title = GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString() + GridView1.DataKeys(GridView1.SelectedIndex).Values(1).ToString()
                Redireccionar_Pagina("/Consultas/AvisosActD/Con_Cronograma.aspx?Cod_PCon=" + Num_Proc)
                'Redireccionar_Pagina("/Procesos/Programacion/Programacion.aspx?Num_Proc=" + GridView1.DataKeys(GridView1.SelectedIndex).Values(0).ToString())
            Case "documentos"
                Redireccionar_Pagina("/Consultas/AvisosActD/Con_Documentos.aspx?Cod_PCon=" + Num_Proc)
        End Select
    End Sub

    Protected Sub RadTabStrip1_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick
        'Me.TxtNSol.Text = RadTabStrip1.SelectedIndex
        Filtrar()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TxtDesde.Text = "01/01/" + Today.Year.ToString
            TxtHasta.Text = "31/12/" + Today.Year.ToString
            
            Filtrar()
           
            Dim t As New Terceros

            If t.GetIsAsig_Proc() Then
                Me.HyperLink1.Visible = True
                IBtnPanelF.Enabled = True
            Else
                Me.HyperLink1.Visible = False
                IBtnPanelF.Enabled = False
            End If


        End If
    End Sub

    Protected Sub grdxAsignar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdxAsignar.SelectedIndexChanged
        Redireccionar_Pagina("/Solicitudes/NuevaSolicitud/NuevaSolicitud.aspx?Cod_Sol=" + grdxAsignar.SelectedValue)
    End Sub

    Protected Sub GvAcep_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GvAcep.SelectedIndexChanged
        Redireccionar_Pagina("/Consultas/AvisosActD/HRevisiones.aspx?Cod_Sol=" + GvAcep.SelectedValue)
    End Sub

    Protected Sub GvRech_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GvRech.SelectedIndexChanged
        Redireccionar_Pagina("/Consultas/AvisosActD/HRevisiones.aspx?Cod_Sol=" + GvRech.SelectedValue)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Filtrar()
    End Sub

    Sub Filtrar()
        Dim obj As New AvisosActD
        obj.Num_PSol = TxtNSol.Text
        obj.Num_Proc = TxtNSol.Text
        obj.Fec_Ini = TxtDesde.Text
        obj.Fec_Fin = TxtHasta.Text

        'Select Case RadTabStrip1.SelectedIndex

        'Case 0
        grdxAsignar.DataSource = obj.GetxAsig(Vigencia)
        grdxAsignar.DataBind()
        Dim tab6 As RadTab = RadTabStrip1.Tabs.FindTabByValue("asignar")
        tab6.Text = "Solicitudes Sin Asignar (" + grdxAsignar.Rows.Count.ToString + ")"
        'Case 1
        grdRecibir.DataSource = obj.GetxRecibirD(Vigencia)
        grdRecibir.DataBind()
        Dim tab3 As RadTab = RadTabStrip1.Tabs.FindTabByValue("recibir")
        tab3.Text = "Solicitudes Sin Recibir (" + grdRecibir.Rows.Count.ToString + ")"
        'Case 2
        grdRevisar.DataSource = obj.GetSolPend(Vigencia)
        grdRevisar.DataBind()
        Dim tab4 As RadTab = RadTabStrip1.Tabs.FindTabByValue("revisar")
        tab4.Text = "Solicitudes Pendientes (" + grdRevisar.Rows.Count.ToString + ")"

        'Case 3
        GvAcep.DataSource = obj.GetSolAcep(Vigencia)
        GvAcep.DataBind()
        Dim tab7 As RadTab = RadTabStrip1.Tabs.FindTabByValue("Aceptadas")
        tab7.Text = "Solicitudes Aceptadas (" + GvAcep.Rows.Count.ToString + ")"
        'Case 4
        GvRech.DataSource = obj.GetSolRech(Vigencia)
        GvRech.DataBind()
        Dim tab8 As RadTab = RadTabStrip1.Tabs.FindTabByValue("Rechazadas")
        tab8.Text = "Solicitudes Rechazadas (" + GvRech.Rows.Count.ToString + ")"
        ' Case 5
        grdActHoy.DataSource = obj.GetAvisosHoyD()
        grdActHoy.DataBind()
        Dim tab1 As RadTab = RadTabStrip1.Tabs.FindTabByValue("hoy")
        tab1.Text = "Actividades para hoy (" + grdActHoy.Rows.Count.ToString + ")"
        '  Case 6
        grdActAtrazadas.DataSource = obj.GetAvisosAtrasadosD()
        grdActAtrazadas.DataBind()
        Dim tab2 As RadTab = RadTabStrip1.Tabs.FindTabByValue("atrazadas")
        tab2.Text = "Actividades Atrazadas/En Curso (" + grdActAtrazadas.Rows.Count.ToString + ")"


        '   Case 7
        DtProcesosACargo.DataSource = obj.GetProcesosxDepDel(Vigencia)
        DtProcesosACargo.DataBind()
        grdProcACargo.DataSource = obj.GetProcbyDepDelEstado(DtProcesosACargo.SelectedValue, Vigencia)
        grdProcACargo.DataBind()
        'End Select
        Dim dt As DataTable = obj.GetProcxDepDel(Session("Vigencia"))
        Dim tab5 As RadTab = RadTabStrip1.Tabs.FindTabByValue("procesos")
        tab5.Text = "Procesos a Cargo (" + dt.Rows.Count.ToString + ")"
    End Sub

    Protected Sub IBtnPanelF_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnPanelF.Click
        Response.Redirect(HyperLink1.NavigateUrl)
    End Sub

    Protected Sub IBtnNuevo_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        Response.Redirect(HyperLink2.NavigateUrl)
    End Sub

    Protected Sub BtnEx_SinAsig_Click(sender As Object, e As System.EventArgs) Handles BtnEx_SinAsig.Click
        ExportGridView(grdxAsignar, "Solicitudes por Asignar")
    End Sub

    Protected Sub BtnExp_Aceptar_Click(sender As Object, e As System.EventArgs) Handles BtnExp_Aceptar.Click
        ExportGridView(GvAcep, "Solicitudes Aceptadas")
    End Sub

    Protected Sub BtnExp_Rech_Click(sender As Object, e As System.EventArgs) Handles BtnExp_Rech.Click
        ExportGridView(GvRech, "Solicitudes Rechazadas")
    End Sub

    Protected Sub BtnExp_Pend_Click(sender As Object, e As System.EventArgs) Handles BtnExp_Pend.Click
        ExportGridView(grdRevisar, "Solicitudes Pendientes")
    End Sub

    Protected Sub BtnExp_xRecibir_Click(sender As Object, e As System.EventArgs) Handles BtnExp_xRecibir.Click
        ExportGridView(grdRecibir, "Solicitudes por Recibir")
    End Sub

    Protected Sub BtnActHoy_Click(sender As Object, e As System.EventArgs) Handles BtnActHoy.Click
        ExportGridView(grdActHoy, "Actividades para Hoy")
    End Sub
    Protected Sub BtnExpProcCargo_Click(sender As Object, e As System.EventArgs) Handles BtnExpProcCargo.Click
        ExportGridView(grdProcACargo, "Procesos")
    End Sub
    Protected Sub BtnExpAtrazadas_Click(sender As Object, e As System.EventArgs) Handles BtnExpAtrazadas.Click

        ExportGridView(grdActAtrazadas, "Actividades Atrazados")
    End Sub


    'Protected Sub lnkVerTodos_Click(sender As Object, e As System.EventArgs) Handles lnkVerTodos.Click
    '    Dim obj As New AvisosActD
    '    HdPNom_Est.Value = ""
    '    grdProcACargo.DataSource = obj.GetProcbyDepDelEstado(HdPNom_Est.Value, Vigencia)
    '    grdProcACargo.DataBind()
    'End Sub



    'Se requiere para exportar a excel
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
End Class
