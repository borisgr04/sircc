
Partial Class CtrlUsr_ConsultaTerxDep
    Inherits System.Web.UI.UserControl
    Dim sTipo As String
    Dim sRet As String
    Property Ret() As String
        Get
            Return sRet
        End Get
        Set(ByVal value As String)
            sRet = value
        End Set
    End Property

    Property Tipo() As String
        Get
            Return sTipo
        End Get
        Set(ByVal value As String)
            sTipo = value
            Me.HiddenField1.Value = Me.Tipo
        End Set
    End Property

    Property Ide_Ter() As String
        Get
            Return ViewState("ide_ter")
        End Get
        Set(ByVal value As String)
            ViewState("ide_ter") = value
        End Set
    End Property

    Property Nom_Ter() As String
        Get
            Return ViewState("nom_ter")
        End Get
        Set(ByVal value As String)
            ViewState("nom_ter") = value
        End Set
    End Property
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "Seleccionar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.GridView1.SelectedIndex = index
        End If
        If e.CommandName = "enviar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.GridView1.SelectedIndex = index
            Me.Ide_Ter = Me.GridView1.SelectedValue
            Me.Nom_Ter = Me.GridView1.SelectedRow.Cells(2).ToString
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.HiddenField1.Value = Me.Tipo
        End If

    End Sub


End Class
