<%@ WebHandler Language="VB" Class="verSopInfCon" %>

Imports System
Imports System.Web
Imports System.Data


Public Class verSopInfCon : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        
        Dim Id As String = context.Request.QueryString("Id")
        Dim Cod_Con As String = context.Request.QueryString("Cod_Con")
        Dim Num_Inf As String = context.Request.QueryString("Num_Inf")
        Dim obj As New Sop_Inf_Descagar
        Dim dt As ArchivosT
        If Not Id Is Nothing Then
            dt = obj.GetSoporte(Cod_Con, Num_Inf, Id)
        Else
            dt = obj.GenZip(Cod_Con, Num_Inf)
            'context.Response.Write(dt.NomArchivo)
            'context.Response.End()
        End If
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