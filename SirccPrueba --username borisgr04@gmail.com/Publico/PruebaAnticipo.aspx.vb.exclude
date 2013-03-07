
Partial Class Publico_PruebaAnticipo
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim npa As New genPlanAnticipos

        npa.GenActa("2012020001")

        Response.AddHeader("content-disposition", "attachment; filename=" + "1" + ".pdf")
        Response.BinaryWrite(npa.Doc_PDF)


    End Sub
End Class
