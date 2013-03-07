Imports System.Data
Partial Class MPPublic
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Page.Title = Publico.Nombre_App
        Cargar_Datos()
    End Sub

    Sub Cargar_Datos()
        Dim ObjEnt As Entidad = New Entidad
        Dim dtEnt As DataTable = ObjEnt.GetRecords()
        Me.LbEntidad.Text = "<B>" + dtEnt.Rows(0)("Nom_SecPrincipal") + "</B>" '+ Request.Cookies(Publico.Cookie)("Modulo")
        Me.LbNit.Text = "<B>" + dtEnt.Rows(0)("NIT") + "</B>" '+ Request.Cookies(Publico.Cookie)("Modulo")
        Me.LbCodigo.Text = "<B>" + dtEnt.Rows(0)("Cod_SecPrincipal") + "</B>" '+ Request.Cookies(Publico.Cookie)("Modulo")
        Context.Request.Browser.Adapters.Clear()
        LbConex.Text = "Usuarios en Linea:" + Membership.GetNumberOfUsersOnline().ToString

    End Sub
End Class

