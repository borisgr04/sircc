Partial Class Consultas_Consolidados_Default
    Inherits PaginaComun
    Dim _Total As Decimal
    Dim _TCan As Decimal

    Dim _Total2 As Decimal
    Dim _TCan2 As Decimal

    Dim _Total3 As Decimal
    Dim _TCan3 As Decimal

    Const Url_Report As String = "~/Reportes/Parametrizado/ReportIP.aspx"
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdModalidad.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me._Total = 0
                Me._TCan = 0
            Case DataControlRowType.DataRow
                'Me._Total += CDec(DataBinder.Eval(e.Row.DataItem, "Valor"))
                Me._TCan += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(2).Text = FormatCurrency(Me._Total.ToString)
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                e.Row.Cells(1).Text = FormatNumber(Me._TCan.ToString)
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select

        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.TxtFecIni.Text = CDate("01/01/" + Vigencia_Cookie).ToShortDateString
            Me.TxtFecFin.Text = CDate("31/12/" + Vigencia_Cookie).ToShortDateString

        End If
    End Sub

    Protected Sub grdProcesos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDepNec.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me._Total2 = 0
                Me._TCan2 = 0
            Case DataControlRowType.DataRow
                'Me._Total2 += CDec(DataBinder.Eval(e.Row.DataItem, "Valor"))
                Me._TCan2 += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(2).Text = FormatCurrency(Me._Total2.ToString)
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                e.Row.Cells(1).Text = FormatNumber(Me._TCan2.ToString)
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdDepDel_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDepDel.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me._Total3 = 0
                Me._TCan3 = 0
            Case DataControlRowType.DataRow
                'Me._Total3 += CDec(DataBinder.Eval(e.Row.DataItem, "Valor"))
                Me._TCan3 += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(2).Text = FormatCurrency(Me._Total3.ToString)
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                e.Row.Cells(1).Text = FormatNumber(Me._TCan3.ToString)
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    

    Protected Sub optVista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optVista.SelectedIndexChanged
        MultiView1.ActiveViewIndex = optVista.SelectedValue
    End Sub
    'Buscar  POr Fecha suscripcio, tipo y dep_del
    Protected Sub grdDepDel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDepDel.SelectedIndexChanged
        Response.Redirect(Url_Report + "?sql=" + Server.UrlEncode(SqlFecha_Tipo_Del()) & "&tit=" + Server.UrlEncode("X") & "&Rpte=" + Server.UrlEncode(False))
        'Dim url As String = "~/Reportes/Parametrizado/ReportI.aspx?sql=" + Server.UrlEncode(SqlFecha_Tipo_Del()) & "&tit=" + Server.UrlEncode("X") & "&Rpte=" + Server.UrlEncode(False)
        'Dim strjscript As String = "function AbrirGlobal(){"
        'strjscript = strjscript & "window.open ('" + url + "', 'mywindow','status=1,toolbar=1');"
        'strjscript = strjscript & "}"

        'ScriptManager.RegisterStartupScript(Me, GetType(Page), "AbrirGlobal", strjscript, True)
    End Sub


    Protected Function SqlFecha_Tipo_Del() As String
        Dim strsql As String
        Dim obj As New Contratos()
        Dim cFiltro As String = ""
        Util.AddFiltro(cFiltro, "TIPO='" + grdTipos.SelectedValue + "'")
        Util.AddFiltro(cFiltro, "FEC_SUS_CON BETWEEN TO_DATE('" + CDate(TxtFecIni.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecFin.Text).ToShortDateString + "','dd/mm/yyyy')")
        Util.AddFiltro(cFiltro, "dependenciap = '" + Me.grdDepDel.SelectedValue + "'")
        If cFiltro <> String.Empty Then
            cFiltro = "Where " + cFiltro
        End If
        strsql = "SELECT c.*,Cant_Adicion(c.numero) nro_adi,Plazo_Adicion(c.numero) Pla_Adi,Valor_Adicion(c.numero) Val_Adi FROM vcontratosc2 c  " + cFiltro + " ORDER BY numero"
        Return strsql
    End Function



    Protected Sub grdModalidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdModalidad.SelectedIndexChanged
        Response.Redirect(Url_Report + "?sql=" + Server.UrlEncode(SqlFecha_Del_Tproc()) & "&tit=" + Server.UrlEncode("X") & "&Rpte=" + Server.UrlEncode(False))
    End Sub

    Protected Sub grdTipos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdTipos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdDepNec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDepNec.SelectedIndexChanged
        Response.Redirect(Url_Report + "?sql=" + Server.UrlEncode(SqlFecha_Del_DepNec()) & "&tit=" + Server.UrlEncode("X") & "&Rpte=" + Server.UrlEncode(False))
    End Sub

    Protected Function SqlFecha_Del_DepNec() As String
        Dim strsql As String
        Dim obj As New Contratos()
        Dim cFiltro As String = ""
        Util.AddFiltro(cFiltro, "DEPENDENCIA='" + grdDepNec.SelectedValue + "'")
        Util.AddFiltro(cFiltro, "DEP_PCON='" + CboDepP.SelectedValue + "'")
        Util.AddFiltro(cFiltro, "FEC_SUS_CON BETWEEN TO_DATE('" + CDate(TxtFecIni.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecFin.Text).ToShortDateString + "','dd/mm/yyyy')")
        If cFiltro <> String.Empty Then
            cFiltro = "Where " + cFiltro
        End If
        strsql = "SELECT c.*,Cant_Adicion(c.numero) nro_adi,Plazo_Adicion(c.numero) Pla_Adi,Valor_Adicion(c.numero) Val_Adi FROM vcontratosc2 c  " + cFiltro + " ORDER BY numero"
        Return strsql
    End Function

    Protected Function SqlFecha_Del_Tproc() As String
        Dim strsql As String
        Dim obj As New Contratos()
        Dim cFiltro As String = ""
        Util.AddFiltro(cFiltro, "NOM_TPROC='" + grdModalidad.SelectedValue + "'")
        Util.AddFiltro(cFiltro, "DEP_PCON='" + CboDepP.SelectedValue + "'")
        Util.AddFiltro(cFiltro, "FEC_SUS_CON BETWEEN TO_DATE('" + CDate(TxtFecIni.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecFin.Text).ToShortDateString + "','dd/mm/yyyy')")
        If cFiltro <> String.Empty Then
            cFiltro = "Where " + cFiltro
        End If
        strsql = "SELECT c.*,Cant_Adicion(c.numero) nro_adi,Plazo_Adicion(c.numero) Pla_Adi,Valor_Adicion(c.numero) Val_Adi FROM vcontratosc2 c  " + cFiltro + " ORDER BY numero"
        Return strsql
    End Function

    Protected Function SqlFecha_Del_Tip() As String
        Dim strsql As String
        Dim obj As New Contratos()
        Dim cFiltro As String = ""
        Util.AddFiltro(cFiltro, "TIPO='" + grdTiposD.SelectedValue + "'")
        Util.AddFiltro(cFiltro, "DEP_PCON='" + CboDepP.SelectedValue + "'")
        Util.AddFiltro(cFiltro, "FEC_SUS_CON BETWEEN TO_DATE('" + CDate(TxtFecIni.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecFin.Text).ToShortDateString + "','dd/mm/yyyy')")
        If cFiltro <> String.Empty Then
            cFiltro = "Where " + cFiltro
        End If
        strsql = "SELECT c.*,Cant_Adicion(c.numero) nro_adi,Plazo_Adicion(c.numero) Pla_Adi,Valor_Adicion(c.numero) Val_Adi FROM vcontratosc2 c  " + cFiltro + " ORDER BY numero"
        Return strsql
    End Function

    Protected Sub grdTiposD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTiposD.SelectedIndexChanged
        Response.Redirect(Url_Report + "?sql=" + Server.UrlEncode(SqlFecha_Del_Tip()) & "&tit=" + Server.UrlEncode("X") & "&Rpte=" + Server.UrlEncode(False))
    End Sub
End Class
