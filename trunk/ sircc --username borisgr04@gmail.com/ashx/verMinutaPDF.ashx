<%@ WebHandler Language="VB" Class="verMinutaPDF" %>

Imports System
Imports System.Web
Imports System.Data

Public Class verMinutaPDF : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World")
        
        Dim Id As String = context.Request.QueryString("Id")
        
        Dim Num_Proc As String = context.Request.QueryString("Num_Proc")
        Dim Grupo As String = context.Request.QueryString("Grupo")
        Dim obj As New PGContratosM
        Dim m As Byte()
        If Not String.IsNullOrEmpty(Id) Then
            m = obj.GetMinutaPDF(Num_Proc, Grupo, Id)
        Else
            m = obj.GetMinutaPDF(Num_Proc, Grupo)
        End If
        
        If m.Length > 0 Then
            context.Response.Clear()
            context.Response.AddHeader("content-disposition", "attachment; filename=" & Num_Proc + "-" + Grupo + ".pdf")
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