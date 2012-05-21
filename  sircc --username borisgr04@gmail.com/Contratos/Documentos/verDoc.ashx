<%@ WebHandler Language="VB" Class="verDoc" %>

Imports System
Imports System.Web
Imports System.Data


Public Class verDoc : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World")
        
        Dim Id As String = context.Request.QueryString("Id")
        Dim obj As New DocContratos
        Dim dt As DataTable = obj.GetDoc(Id)
        If dt.Rows.Count > 0 Then
            context.Response.Clear()
            'Response.ContentType = mimeType
            context.Response.AddHeader("content-disposition", "attachment; filename=" & dt.Rows(0)("FileName"))
            context.Response.BinaryWrite(DirectCast(dt.Rows(0)("DOCUMENTO"), Byte()))
            context.Response.End()
            'Dim SalPDF As Byte() = {}
            'PdfManipulation2.ExtractPdfPage(DirectCast(dt.Rows(0)("DOCUMENTO"), Byte()), 10, 13, SalPDF)
            'Response.AddHeader("content-disposition", "attachment; filename=" & dt.Rows(0)("FileName"))
            'Response.BinaryWrite(SalPDF)
            'Response.End()
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class