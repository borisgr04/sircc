<%@ WebHandler Language="VB" Class="verZIP" %>

Imports System
Imports System.Web

Public Class verZIP : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim cod_con As String = context.Request("Id")
        Dim obj As DocContratos = New DocContratos
        Dim c As Integer = obj.GetCant_Doc_Contratos(cod_con)
        If c > 0 Then
            Dim arrImg() As Byte = obj.Generar_Zip_Byte(cod_con)
            context.Response.Clear()
            context.Response.ContentType = "APPLICATION/ZIP"
            context.Response.AddHeader("Content-Disposition", "attachment;filename = " & cod_con & ".ZIP")
            context.Response.BinaryWrite(arrImg)
            context.Response.End()
        Else
            context.Response.ContentType = "text/plain"
            context.Response.Write("No se generó archivo de salida, verificar si existe archivos cargados al contrato. si existen comuniquese con el proveedor")
        End If
        
        'MsgBox(MsgR, obj.lErrorG)
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class