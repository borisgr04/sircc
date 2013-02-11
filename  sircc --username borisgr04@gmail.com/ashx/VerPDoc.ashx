<%@ WebHandler Language="VB" Class="VerPDoc" %>

Imports System
Imports System.Web
Imports System.Data

Public Class VerPDoc : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim Id As String = context.Request.QueryString("Id")
        Dim obj As New Con_Documentos
        Dim dt As DataTable = obj.GetbyPk(Id)
        If dt.Rows.Count > 0 Then
            context.Response.Clear()
            'Response.ContentType = mimeType
            context.Response.AddHeader("content-disposition", "attachment; filename=" & dt.Rows(0)("Nombre") + ".doc")
            context.Response.BinaryWrite(DirectCast(dt.Rows(0)("MINUTA"), Byte()))
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