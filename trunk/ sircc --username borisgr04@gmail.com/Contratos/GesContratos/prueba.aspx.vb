Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Data

Partial Class Contratos_GesContratos_prueba
    Inherits System.Web.UI.Page


    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Shared Function GetDatos(Vigencia As String, Dep_Nec As String, Ide_Sup As String) As IList(Of cEstCan)
        Dim vc As New vContratosInt()
        If Vigencia <> "" Then
            vc.Vigencia = Vigencia
        End If
        If Dep_Nec <> "" Then
            vc.Dep_Nec = Dep_Nec
        End If
        If Ide_Sup <> "" Then
            vc.Ide_Interventor = Ide_Sup
        End If
        Dim cc As New GesCConsolidados
        Return cc.GetConsolidadC(vc)
    End Function

    

    <WebMethod()> _
<ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Xml)> _
    Public Shared Function GetDatos2(Vigencia As String, Dep_Nec As String, Ide_Sup As String) As String
        Dim vc As New vContratosInt()
        If Vigencia <> "" Then
            vc.Vigencia = Vigencia
        End If
        If Dep_Nec <> "" Then
            vc.Dep_Nec = Dep_Nec
        End If
        If Ide_Sup <> "" Then
            vc.Ide_Interventor = Ide_Sup
        End If
        Dim cc As New GesCConsolidados

        Return cc.GetConsolidadXML(vc)
    End Function

End Class
