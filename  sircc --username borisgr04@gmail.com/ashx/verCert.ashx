<%@ WebHandler Language="VB" Class="verDoc" %>

Imports System
Imports System.Web
Imports System.Data


Public Class verDoc : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        
        
        Dim nro_cert As String = context.Request.QueryString("nro_cert")
        Dim vig_cert As String = context.Request.QueryString("vig_cert")
        Dim cod_serie As String = context.Request.QueryString("CVXX")
        Dim ftmt As String = context.Request.QueryString("fmt")
        Dim oCert As New Cert_Contratos
        
        If oCert.Cargar(nro_cert, vig_cert) Then
            context.Response.Clear()
            'Response.ContentType = mimeType
            context.Response.AddHeader("content-disposition", "attachment; filename=" + cod_serie+ ".pdf")
            context.Response.BinaryWrite(oCert.Doc_PDF)
            context.Response.End()
            'Dim SalPDF As Byte() = {}
            'PdfManipulation2.ExtractPdfPage(DirectCast(dt.Rows(0)("DOCUMENTO"), Byte()), 10, 13, SalPDF)
            'Response.AddHeader("content-disposition", "attachment; filename=" & dt.Rows(0)("FileName"))
            'Response.BinaryWrite(SalPDF)
            'Response.End()
        Else
            context.Response.Write("No se encontró ningun certificado con esas especificaciones")
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class