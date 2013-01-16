Imports System.Data
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim UsuTercero As New Terceros
    Dim mn As New DBMenu
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'BDDatos.ResetConexion()
        'LbConex.Text = BDDatos.Estado_Conexion
        Dim c As New Contratos

        LbConex.Text = "Usuarios en Linea:" + Membership.GetNumberOfUsersOnline().ToString + " Tipo de Filtro <b>" + c.GetFiltro_Contrato().ToString + "</b>"

        If Not Me.IsPostBack Then
            'mn.cargarMenu(Me.MnuPpal, Request.Cookies(Publico.Cookie)("Modulo"))
            Cargar_Menu()
            'mn.cargarMenu(Me.Menu1, Request.Cookies(Publico.Cookie)("Modulo"))
            'Me.Menu2.Orientation = Orientation.Vertical
            'Me.Menu2.DisappearAfter = 2000
            'Me.Menu2.MaximumDynamicDisplayLevels = 3
            'Me.Menu2.StaticDisplayLevels = 2
            'Me.Menu2.DynamicVerticalOffset = 0

            'Me.Menu2.StaticSubMenuIndent = 20
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            If dt.Rows.Count > 0 Then
                Me.LbTer.Text = dt.Rows(0)("Nom_Ter").ToString
            End If
            ''..
            'LbVig.Text = Request.Cookies("DERWEB")("vigencia")
            'LbVig.Text = ""
            Dim ObjEnt As Entidad = New Entidad
            Dim dtEnt As DataTable = ObjEnt.GetRecords()
            Me.LbEntidad.Text = "<B>" + dtEnt.Rows(0)("Nom_SecPrincipal") + "</B>" '+ Request.Cookies(Publico.Cookie)("Modulo")
            Me.LbNit.Text = "<B>" + dtEnt.Rows(0)("NIT") + "</B>" '+ Request.Cookies(Publico.Cookie)("Modulo")
            Me.LbCodigo.Text = "<B>" + dtEnt.Rows(0)("Cod_SecPrincipal") + "</B>" '+ Request.Cookies(Publico.Cookie)("Modulo")
            Me.LbVig.Text = Request.Cookies(Publico.Cookie)("Vigencia")
            Me.CmbVigencia.SelectedValue = Request.Cookies(Publico.Cookie)("Vigencia")
            Context.Request.Browser.Adapters.Clear()


        End If
    End Sub
    Sub Actualizar_Cookie(ByVal Modulo As String, ByVal NModulo As String)
        Response.Cookies(Publico.Cookie)("Modulo") = UCase(Modulo)
        Response.Cookies(Publico.Cookie)("NModulo") = UCase(NModulo)
        Response.Cookies(Publico.Cookie)("Vigencia") = Request.Cookies(Publico.Cookie)("Vigencia")
    End Sub
    Sub Cargar_Menu()
        Cargar_Menu(Request.Cookies(Publico.Cookie)("Modulo"))
    End Sub
    Sub Cargar_Menu(ByVal Modulo As String)
        mn.cargarMenu(RMnPpal, Modulo)
        Request.Cookies(Publico.Cookie)("NModulo") = Modulo
    End Sub
    
    Protected Sub LoginStatus1_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles LoginStatus1.LoggingOut
        FormsAuthentication.SignOut()
        Context.User = Nothing
        Session.Abandon()
        Session.Clear()
        'FormsAuthentication.RedirectToLoginPage()

    End Sub

    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        FormsAuthentication.SignOut()
        Context.User = Nothing
        Session.Abandon()
        Session.Clear()
        Response.Redirect("~/publico/logout.aspx")
    End Sub

    'Protected Sub BtnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCerrar.Click
    '    CerrarForm()
    'End Sub

    'Public Sub CerrarForm()
    '    Response.Redirect("~/default.aspx")
    'End Sub

    'Protected Sub CboMod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMod.SelectedIndexChanged

    'End Sub

    Protected Sub Change_Menu(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As LinkButton = DirectCast(sender, LinkButton)
        Dim p() As String = b.CommandArgument.Split(",")
        Actualizar_Cookie(p(0), p(1))
        Cargar_Menu()
        LbModulo.Text = p(1)
    End Sub

    Protected Sub CmbVigencia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbVigencia.SelectedIndexChanged
        'Response.Cookies(Publico.Cookie)("Vigencia") = CmbVigencia.SelectedValue
        'Response.Cookies(Publico.Cookie)("Modulo") = Request.Cookies(Publico.Cookie)("Modulo")
        'Response.Cookies(Publico.Cookie)("NModulo") = Request.Cookies(Publico.Cookie)("NModulo")
        'LbVig.Text = Request.Cookies(Publico.Cookie)("Vigencia")
        'Cargar_Menu()
    End Sub

    Protected Sub lstMenu_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lstMenu.ItemCommand
        Dim p() As String = e.CommandArgument.Split(",")
        Actualizar_Cookie(p(0), p(1))
        Cargar_Menu(p(0))

    End Sub
End Class


