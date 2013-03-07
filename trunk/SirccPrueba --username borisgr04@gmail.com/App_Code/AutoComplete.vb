Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Collections.Generic

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la siguiente línea.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class AutoComplete
     Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hola a todos"
    End Function

    <WebMethod()> Public Function GetTerceros(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim obj As New Terceros
        Dim lerrorg As Boolean = False

        If (count = 0) Then
            count = 10
        End If

        'If (prefixText.Equals("xyz")) Then
        ' Return New String(0)
        'End If

        Dim datat As New DataTable
        datat = obj.GetRecords(prefixText, "OT")

        Dim items As List(Of String) = New List(Of String)(count)
        Dim i As Integer
        Dim Sal As String
        If datat.Rows.Count > 0 Then
            For i = 0 To datat.Rows.Count - 1
                Sal = datat.Rows(i).Item("Nom_Ter").ToString()
                items.Add(Sal)
            Next i
        Else
            count = 0
            items.Add("****** . No se ha encontrado coincidencias.")
        End If


        Return items.ToArray()
    End Function

    <WebMethod()> Public Function GetPContratos(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim obj As New PContratos
        Dim lerrorg As Boolean = False

        If (count = 0) Then
            count = 10
        End If

        Dim datat As New DataTable
        datat = obj.GetLikeNProc(prefixText)

        Dim items As List(Of String) = New List(Of String)(count)
        Dim i As Integer
        Dim Sal As String
        If datat.Rows.Count > 0 Then
            For i = 0 To datat.Rows.Count - 1
                Sal = datat.Rows(i).Item("Pro_Sel_Nro").ToString()
                items.Add(Sal)
            Next i
        Else
            count = 0
            items.Add("****** . No se ha encontrado coincidencias.")
        End If


        Return items.ToArray()
    End Function
End Class
