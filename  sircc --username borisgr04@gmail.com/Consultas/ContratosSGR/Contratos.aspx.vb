
Partial Class Consultas_ContratosSGR_Contratos
    Inherits PaginaComun

    Private Property Total As Decimal
        Set(ByVal value As Decimal)
            ViewState("Total") = value
        End Set
        Get
            Return ViewState("Total")
        End Get
    End Property

    Private Property TCan As Integer
        Set(ByVal value As Integer)
            ViewState("Can") = value
        End Set
        Get
            Return ViewState("Can")
        End Get
    End Property
    Protected Sub DetContratoN1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContratoN1.AceptarClicked
        'Me.ConDocContratos1.CodigoContrato = Me.DetContratoN1.Cod_Con
    End Sub
    Protected Sub grdEstContratos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEstContratos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If

        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.Total = 0
                Me.TCan = 0
            Case DataControlRowType.DataRow

                Me.Total += CDec(DataBinder.Eval(e.Row.DataItem, "VALOR_PAGO"))
                'Me.TCan += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(7).Text = FormatCurrency(Me.Total.ToString)
                e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                'lbTotalPorPagar.Text = FormatCurrency(CDec(DetContrato1.Valor_Total_Prop) - Me.Total)
                'Valor_Total_Prop
                'e.Row.Cells(5).Text = FormatNumber(Me.TCan.ToString)
                'e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                'e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.DetContratoN1.ValoraBuscar = Request("Numero")
            Me.DetContratoN1.Buscar()
        End If

    End Sub
End Class
