
Partial Class CtrlUsr_ConsorciosUT_ConMiembros
    Inherits CtrlUsrComun
    Private Property Total() As Decimal
        Set(ByVal value As Decimal)
            ViewState("Total") = value
        End Set
        Get
            Return ViewState("Total")
        End Get
    End Property
    Property Ide_Ter As String
        Set(ByVal value As String)
            HdIde_Ter.Value = value
        End Set
        Get
            Return HdIde_Ter.Value
        End Get
    End Property

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If

        Select e.Row.RowType
            Case DataControlRowType.Header
                Me.Total = 0
            Case DataControlRowType.DataRow

                Me.Total += CDec(DataBinder.Eval(e.Row.DataItem, "Porc_Part")) / 100
            Case DataControlRowType.Footer
                e.Row.Cells(2).Text = FormatPercent(Me.Total.ToString, 1)
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub

End Class
