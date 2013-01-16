Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Data

Partial Class Interventorias_PanelSupervision_PanelSupervision
    Inherits PaginaComun


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.hdUserName.Value = Membership.GetUser().UserName

        End If
    End Sub
    'Me.OperS = "Nuevo"

    ' If Me.CboEstSig.SelectedValue.ToString() = "08" Then
    '     Me.CodCon = DetContratoI1.Cod_Con
    '     Redireccionar_Pagina("/Interventorias/Documentos/AsigAntInv/AsigAntInv.aspx")
    ' End If
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
        Dim CboEstSig As DropDownList = DirectCast(e.Item.FindControl("CboEstSig"), DropDownList)
        'Response.Write(e.CommandName + e.CommandArgument + "-" + CboEstSig.SelectedValue)
        'Nuevo(e.CommandArgument, CboEstSig.SelectedValue)
    End Sub

    Sub Nuevo(ByVal Cod_Con As String, ByVal NewEstado As String)
        If NewEstado = "08" Then
            Redireccionar_Pagina("/Interventorias/Documentos/AsigAntInv/AsigAntInv.aspx?Cod_Con=" + Cod_Con + "&Oper=Nuevo")
        End If
    End Sub

    Protected Sub LstSupervisiones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstSupervisiones.SelectedIndexChanged
        mpe.Show()
        Dim objE As New EstContratos
        If objE.GetActasBorrador(Me.LstSupervisiones.SelectedValue) = 0 Then
            PnlNuevoDoc.Visible = True
            PnLabelNuevo.Visible = False
        Else
            PnlNuevoDoc.Visible = False
            PnLabelNuevo.Visible = True
            LbNuevo.Text = "Existe un Documento en Borrador, debe Editarlo para Terminar su diligenciamiento o Anularlo para elaborar otro."
            MsgBoxInfo(LbNuevo, True)
        End If
    End Sub

    Protected Sub IBtnDoc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnDoc.Click
        Nuevo(LstSupervisiones.SelectedValue, CboEstSig.SelectedValue)
    End Sub

    Protected Sub IBtnVolver_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnVolver.Click

    End Sub

 
    Protected Sub grdEstContratos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEstContratos.RowCommand
        Me.Oper = e.CommandName
        If Me.Oper = "Anular" Then
            'Dim Obj As EstContratos = New EstContratos()
            'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            'Me.grdEstContratos.SelectedIndex = index
            'Me.MsgResult.Visible = True
            'Me.MsgResult.Text = Obj.Anular(Me.grdEstContratos.SelectedValue)
            'Me.MsgBox(MsgResult, Obj.lErrorG)
            'DetContratoI1.Buscar()
            'grdEstContratos.DataBind()
            'Me.grdEstContratos.DataBind()
        ElseIf Me.Oper = "Editar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.grdEstContratos.SelectedIndex = index
            Me.NoID = Me.grdEstContratos.SelectedValue
            Redireccionar_Pagina("/Interventorias/Documentos/AsigAntInv/AsigAntInv.aspx?Cod_Con=" + LstSupervisiones.SelectedValue + "&Oper=Editar&NoID=" + Me.NoID)
        End If
    End Sub
End Class
