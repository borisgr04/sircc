Imports Telerik.Web.UI
Imports System.Data

Partial Class GPagosTerceros_Radicacion_RadDocumentos
    Inherits PaginaComun

    Protected Sub RTabDocs_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RTabDocs.TabClick
        Me.MsgResult.Text = e.Tab.Value
        HdEstado.Value = e.Tab.Value

        GridView1.DataBind()



    End Sub

    Protected Sub Page_Load1(sender As Object, e As System.EventArgs) Handles Me.Load
        Session("vigencia") = Me.Vigencia_Cookie
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub RTabDocs_TabDataBound(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RTabDocs.TabDataBound

    End Sub

    'Protected Sub RadComboBox1_DataBound(sender As Object, e As EventArgs)
    '    'set the initial footer label
    '    CType(RadCboFiltro.Footer.FindControl("RadComboItemsCount"), Literal).Text = Convert.ToString(RadCboFiltro.Items.Count)
    'End Sub

    'Protected Sub RadComboBox1_ItemDataBound(ByVal sender As Object, ByVal e As RadComboBoxItemEventArgs)
    '    'set the Text and Value property of every item
    '    'here you can set any other properties like Enabled, ToolTip, Visible, etc.
    '    e.Item.Text = (DirectCast(e.Item.DataItem, DataRowView))("ID").ToString()
    '    e.Item.Value = (DirectCast(e.Item.DataItem, DataRowView))("ID").ToString()
    'End Sub

    'Protected Sub RadComboBox1_ItemsRequested(ByVal sender As Object, ByVal e As RadComboBoxItemsRequestedEventArgs)
    '    'Dim sql As String = "SELECT * from Customers WHERE ContactName LIKE '" + e.Text + "%'"
    '    'SessionDataSource1.SelectCommand = sql
    '    'RadComboBox1.DataBind()
    'End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim num As String = GridView1.SelectedRow.Cells(0).Text
        Dim id As String = GridView1.SelectedRow.Cells(1).Text
        Redireccionar_Pagina("/GPagosTerceros/Radicacion/recep.aspx?cod_con=" + num + "&id=" + id)
    End Sub
End Class
