
Partial Class CtrlUsr_ConsultaCONUT
    Inherits CtrlUsrComun
    Dim sTipo As String
    Dim sRet As String

#Region "Eventos del control"
    Public Event SelClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent SelClicked(sender, New EventArgs())
    End Sub
#End Region

    
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
            Return GridView1.SelectedValue
        End Get
        Set(ByVal value As String)
            ViewState("ide_ter") = value
        End Set
    End Property

    Property Nom_Ter() As String
        Get
            Return GridView1.SelectedRow.Cells(1).Text
        End Get
        Set(ByVal value As String)
            ViewState("nom_ter") = value
        End Set
    End Property
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.GridView1.SelectedIndex = index
        If e.CommandName = "enviar" Then
            'Me.Ide_Ter = Me.GridView1.SelectedValue
            'Me.Nom_Ter = Me.GridView1.SelectedRow.Cells(2).Text
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        OnClick(sender)
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


    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click

    End Sub
End Class
