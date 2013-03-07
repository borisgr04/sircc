
Partial Class CtrlUsr_ConsultaTer2
    Inherits System.Web.UI.UserControl
    Dim sTipo As String
    Dim sRet As String


    Public Property PermitirNuevo() As Boolean
        Get
            Return CBool(ViewState("PermitirNuevo"))
        End Get
        Set(ByVal value As Boolean)
            Me.BtnAgregar.Visible = value
            ViewState("PermitirNuevo") = value
        End Set
    End Property

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
    Public Event EditClicked As EventHandler
    Public Event CancelClicked As EventHandler
    Public Event NuevoClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        If Oper = "Seleccionar" Then
            RaiseEvent SelClicked(sender, New EventArgs())
        ElseIf Oper = "Editar" Then
            RaiseEvent EditClicked(sender, New EventArgs())
        ElseIf Oper = "Cancelar" Then
            RaiseEvent CancelClicked(sender, New EventArgs())
        ElseIf Oper = "Nuevo" Then
            RaiseEvent NuevoClicked(sender, New EventArgs())
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

    Property Tipo() As String
        Get
            Return sTipo
        End Get
        Set(ByVal value As String)
            sTipo = value
            Me.HiddenField1.Value = Me.Tipo
        End Set
    End Property

    Public Property Ide_Ter() As String
        Get
            Return GridView1.SelectedValue 'ViewState("ide_ter")
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
            Return GridView1.SelectedRow.Cells(1).Text 'ViewState("nom_ter")
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
        If Not Me.IsPostBack Then
            Me.HiddenField1.Value = Me.Tipo
        End If

    End Sub


    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        If e.CommandName = "editar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.GridView1.SelectedIndex = index
            Ide_Ter = GridView1.SelectedValue
            Oper = "Editar"
            OnClick(sender)
        End If

    End Sub

    Protected Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAgregar.Click
        Oper = "Nuevo"
        OnClick(sender)
    End Sub
End Class
