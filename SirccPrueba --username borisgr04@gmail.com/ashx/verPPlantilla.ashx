<%@ WebHandler Language="VB" Class="verDoc" %>

Imports System
Imports System.Web
Imports System.Data


Public Class verDoc : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World")
        
        Dim Id As String = context.Request.QueryString("Ide_Pla")
        
        Dim obj As New PPlantillas
        Dim m As Byte()
        If Not String.IsNullOrEmpty(Id) Then
            m = obj.GetPlantillabyPK(Id)
        End If
        
        If m.Length > 0 Then
            context.Response.Clear()
            'Response.ContentType = mimeType 
            context.Response.ContentType = "application/vnd.ms-word"
            context.Response.AddHeader("content-disposition", "attachment; filename=PPlantilla" + Id + ".doc")
            context.Response.BinaryWrite(DirectCast(m, Byte()))
            context.Response.End()
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class