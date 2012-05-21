<%@ WebHandler Language="VB" Class="Logo" %>

Imports System
Imports System.Web
Imports System.Data

Public Class Logo : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World")
        Dim ObjE As New Entidad
        Dim dt As DataTable = ObjE.GetRecords()
        Dim arrImg() As Byte = DirectCast(dt.Rows(0)("logo_Rpt"), Byte())
        context.Response.Clear()
        context.Response.ContentType = "image/jpeg"
        context.Response.BinaryWrite(arrImg)
        context.Response.End()
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class