Imports System.Data
Partial Class Publico_grd
    Inherits System.Web.UI.Page


    'Property variable As datatable
    '    Set(ByVal value As DataTable)
    '        ViewState("dt") = value
    '    End Set
    '    Get
    '        Return DirectCast(ViewState("dt"), DataTable)
    '    End Get
    'End Property

    Protected Sub DetailsView1_ItemDeleted(ByVal sender As Object, ByVal e As DetailsViewDeletedEventArgs)
        If ((e.Exception Is Nothing) _
                    OrElse e.ExceptionHandled) Then
            'Response.Redirect(table.ListActionPath)
            '            ViewState("variable") = 1



        End If
    End Sub
End Class
