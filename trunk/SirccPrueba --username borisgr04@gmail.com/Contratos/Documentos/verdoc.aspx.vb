Imports System.Data

Partial Class Contratos_Documentos_verdoc
    Inherits PaginaComun
    'volver Clase de descarga de documento
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Id As String = Request.QueryString("Id")
        Dim obj As New DocContratos
        Dim dt As DataTable = obj.GetDoc(Id)
        If dt.Rows.Count > 0 Then
            Response.Clear()
            'Response.ContentType = mimeType

            Response.AddHeader("content-disposition", "attachment; filename=" & dt.Rows(0)("FileName"))
            Response.BinaryWrite(DirectCast(dt.Rows(0)("DOCUMENTO"), Byte()))
            Response.End()

            'Dim SalPDF As Byte() = {}
            'PdfManipulation2.ExtractPdfPage(DirectCast(dt.Rows(0)("DOCUMENTO"), Byte()), 10, 13, SalPDF)
            'Response.AddHeader("content-disposition", "attachment; filename=" & dt.Rows(0)("FileName"))
            'Response.BinaryWrite(SalPDF)
            'Response.End()

        End If

    End Sub
End Class
