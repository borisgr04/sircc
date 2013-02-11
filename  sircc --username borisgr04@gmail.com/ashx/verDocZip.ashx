<%@ WebHandler Language="VB" Class="verDocZip" %>

Imports System
Imports System.Web

Public Class verDocZip : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim Num_Proc As String = context.Request.QueryString("Num_Proc")
        Dim obj As New Con_Documentos
        Dim dt As ArchivosT
        
        dt = obj.GenZip(Num_Proc)
        'context.Response.Write(dt.NomArchivo)
        'context.Response.End()
        If obj.lErrorG Then
            context.Response.Write(obj.Msg)
            context.Response.End()
        End If
        If Not dt Is Nothing Then
            context.Response.Clear()
            context.Response.ContentType = dt.Content
            context.Response.AddHeader("content-disposition", "attachment; filename=" & dt.NomArchivo)
            context.Response.BinaryWrite(dt.SoporteB)
            context.Response.End()
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class