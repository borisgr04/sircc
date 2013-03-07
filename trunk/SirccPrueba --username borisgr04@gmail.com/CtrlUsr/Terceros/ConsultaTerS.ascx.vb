
Partial Class CtrlUsr_ConsultaTerS
    Inherits System.Web.UI.UserControl

    Dim sRet As String



    Public Property Oper() As String
        Get
            Return ViewState("Oper")
        End Get
        Set(ByVal value As String)
            ViewState("Oper") = value
        End Set
    End Property


#Region "Eventos del control"
    Public Event SelClicked As EventHandler

    Protected Overridable Sub OnClick(ByVal sender As Object)
        If Oper = "Seleccionar" Then
            RaiseEvent SelClicked(sender, New EventArgs())

        End If

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

    Public Property TipoTer() As String
        Get
            Return ViewState("TipoTer")
        End Get
        Set(ByVal value As String)
            ViewState("TipoTer") = value
        End Set
    End Property

    Public Property Ide_Ter() As String
        Get
            Return ViewState("ide_ter")
        End Get
        Set(ByVal value As String)

            ViewState("ide_ter") = value
        End Set
    End Property

    Public Property Filtro() As String
        Get

            Return ViewState("ide_ter")
        End Get
        Set(ByVal value As String)
            TxtFilNom.Text = value
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


    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Ide_Ter = GridView1.SelectedValue
        Oper = "Seleccionar"
        OnClick(sender)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            ' e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            'e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Me.IsPostBack Then
        '    Me.HiddenField1.Value = Me.Tipo
        'End If

    End Sub


    'Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

    '    If e.CommandName = "editar" Then
    '        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    '        Me.GridView1.SelectedIndex = index
    '        Ide_Ter = GridView1.SelectedValue
    '        Oper = "Editar"
    '        OnClick(sender)
    '    End If

    'End Sub

    'Protected Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAgregar.Click
    '    Oper = "Nuevo"
    '    OnClick(sender)
    'End Sub
End Class
