Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Data

Partial Class Consultas_Auditoria_Auditoria
    Inherits System.Web.UI.Page





    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click

    End Sub

    Protected Sub grdBusqueda_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBusqueda.RowDataBound

    End Sub
    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Shared Function GetTercerosPk(ide_ter As String) As String
        Dim t As New Terceros
        Dim tb As DataTable = t.GetByIde(ide_ter)
        Return If(tb.Rows.Count = 0, "0", tb.Rows(0)("Nom_Ter"))
    End Function

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HdUser.Value = Usuarios.UserName
        End If
        
    End Sub

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
    <WebMethod()> _
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Xml)> _
    Public Shared Function GetDetalle(Vigencia As String, Dep_Nec As String, Ide_Sup As String, Est As String) As String
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
        If Est <> "" Then
            vc.Estado = Est.ToUpper()
        End If
        Dim cc As New GesCConsolidados
        Return cc.GetDetalleXML(vc)
    End Function


    '<WebMethod()> _
    '    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    'Public Shared Function GetTercerosPk(ide_ter As String) As String
    '    Dim t As New Terceros
    '    Dim tb As DataTable = t.GetByIde(ide_ter)
    '    Return If(tb.Rows.Count = 0, "0", tb.Rows(0)("Nom_Ter"))
    'End Function

    '


End Class
