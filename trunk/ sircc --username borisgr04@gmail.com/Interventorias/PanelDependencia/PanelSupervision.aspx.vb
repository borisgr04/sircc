Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Data

Partial Class Interventorias_PanelDependencias_PanelDependencias
    Inherits PaginaComun


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.hdUserName.Value = Membership.GetUser().UserName
        End If
    End Sub

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Shared Function ObtieneNombres(ByVal Vigencia As String, ByVal prefixText As String) As String() 'As List(Of Terc)
        Dim obj As New PanelSupervision
        Dim lerrorg As Boolean = False
        Dim datat As New DataTable
        datat = obj.GetRecords(Membership.GetUser().UserName, prefixText, Vigencia)
        Dim items As List(Of String) = New List(Of String)
        Dim i As Integer
        Dim Sal As String

        If datat.Rows.Count > 0 Then
            For i = 0 To datat.Rows.Count - 1
                Sal = datat.Rows(i).Item("Contratista").ToString().Trim()
                items.Add(Sal)
            Next i
        Else
            items.Clear()
        End If
        Return items.ToArray
    End Function


    Protected Sub LstSupervisiones_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles LstSupervisiones.ItemCommand
        Select Case e.CommandName
            Case "Detalle"
                Redireccionar_Pagina("/Interventorias/DetContratos/Contratos.aspx?Numero=" + e.CommandArgument.ToString())
            Case "Designar"
                Redireccionar_Pagina("/Interventorias/Designaciones/Designaciones.aspx?Numero=" + e.CommandArgument.ToString())
        End Select
        Dim CboEstSig As DropDownList = DirectCast(e.Item.FindControl("CboEstSig"), DropDownList)
    End Sub

    Sub Nuevo(ByVal Cod_Con As String, ByVal NewEstado As String)
        Dim ruta As String = RutasPag.GetInstance.GetRuta(NewEstado)
        Redireccionar_Pagina(ruta + "?Cod_Con=" + Cod_Con + "&Oper=Nuevo")
    End Sub

    Protected Sub LstSupervisiones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstSupervisiones.SelectedIndexChanged
        
    End Sub

    Protected Sub RadTabStrip1_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick
        Me.HfOper.Value = RadTabStrip1.SelectedTab.Text
        Label5.Text = HfOper.Value
        LstSupervisiones.DataBind()
    End Sub
End Class
