Imports System.Data

Partial Class Procesos_GProcesosN_verMin
    Inherits PaginaComun
    'volver Clase de descarga de documento

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Id As String = Request.QueryString("Id")
        Dim Num_Proc As String = Request.QueryString("Num_Proc")
        Dim Grupo As String = Request.QueryString("Grupo")
        Dim obj As New PGContratosM
        Dim m As Byte() = obj.GetMinuta(Num_Proc, Grupo, Id)
        If m.Length > 0 Then
            Response.Clear()
            'Response.ContentType = mimeType
            Response.AddHeader("content-disposition", "attachment; filename=" & Num_Proc + "-" + Grupo + ".doc")
            Response.BinaryWrite(DirectCast(m, Byte()))
            Response.End()
        End If

    End Sub
End Class
