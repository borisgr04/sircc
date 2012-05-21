Imports System.Data
Partial Class Procesos_RadicarProc_GRadicacion
    Inherits PaginaComun
    Private Property TotalCDP() As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalCDP") = value
        End Set
        Get
            Return ViewState("TotalCDP")
        End Get
    End Property
    Private Property Encontrado() As Boolean
        Set(ByVal value As Boolean)
            ViewState("Encontrado") = value
        End Set
        Get
            Return ViewState("Encontrado")
        End Get
    End Property
    Private Property TotalPago() As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalPago") = value
        End Set
        Get
            Return ViewState("TotalPago")
        End Get
    End Property
    Private Property TotalRubro() As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalRubro") = value
        End Set
        Get
            Return ViewState("TotalRubro")
        End Get
    End Property
    Private Property Porcentaje() As Decimal
        Set(ByVal value As Decimal)
            ViewState("Porcentaje") = value
        End Set
        Get
            Return ViewState("Porcentaje")
        End Get
    End Property

    Protected Sub GrCDP_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrCDP.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.TotalCDP = 0
            Case DataControlRowType.DataRow

                Me.TotalCDP += CDec(DataBinder.Eval(e.Row.DataItem, "Val_CDP"))
                'Me.TCan += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(2).Text = FormatCurrency(Me.TotalCDP.ToString)
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                'e.Row.Cells(5).Text = FormatNumber(Me.TCan.ToString)
                'e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                'e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub GrRubros_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrRubros.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.TotalRubro = 0
            Case DataControlRowType.DataRow

                Me.TotalRubro += CDec(DataBinder.Eval(e.Row.DataItem, "Val_Compromiso"))
                'Me.TCan += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(1).Text = FormatCurrency(Me.TotalRubro.ToString)
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                'e.Row.Cells(5).Text = FormatNumber(Me.TCan.ToString)
                'e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                'e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub GrFPago_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrFPago.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.TotalPago = 0
                Me.Porcentaje = 0
            Case DataControlRowType.DataRow

                Me.TotalPago += CDec(DataBinder.Eval(e.Row.DataItem, "Valor_Pago"))
                Me.Porcentaje += CDec(DataBinder.Eval(e.Row.DataItem, "Porcentaje"))
            Case DataControlRowType.Footer
                e.Row.Cells(1).Text = FormatCurrency(Me.TotalPago.ToString)
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(2).Text = FormatPercent(Me.Porcentaje.ToString)
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString.Count > 0 Then
                querystringSeguro = Me.GetRequest
                HFNumProc.Value = querystringSeguro("Num_Proc")
                HFGrupo.Value = querystringSeguro("Grupo")
            End If
        End If
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Num_Proc") = DetailsView1.SelectedValue
        Redireccionar_Pagina("/Consultas/Procesos/PContratosDepN/ConDetPContratosDepN.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
