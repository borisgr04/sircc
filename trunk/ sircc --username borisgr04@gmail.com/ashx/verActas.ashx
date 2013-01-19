<%@ WebHandler Language="VB" Class="verActas" %>

Imports System
Imports System.Web
Imports System.Data


Public Class verActas: Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World")
        
        Dim Ide_Acta As String = context.Request.QueryString("Ide_Acta")
        Dim obj As New genDocActas
        obj.CargarDoc(Ide_Acta)
        If obj.Doc_PDF.Length > 0 Then
            context.Response.Clear()
            context.Response.AddHeader("content-disposition", "attachment; filename=" + Ide_Acta + ".pdf")
            context.Response.BinaryWrite(obj.Doc_PDF)
            context.Response.End()
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class