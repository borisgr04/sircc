Imports System.Data
Partial Class DatosBasicos_Entidad_Default
    Inherits PaginaComun
    
    Protected Sub Btn_Guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Obj As Entidad = New Entidad

        MsgResult.Text = Obj.Update(Me.Pk1, Me.Txt_Cod.Text, Me.Txt_nom.Text, Txt_Nit.Text, Txt_Rep_Legal.Text, Txt_Tel.Text, Txt_Fax.Text, Txt_Correo.Text, Txt_Dir.Text, Txt_Pais.Text, Txt_Dep.Text, Txt_Ciudad.Text, Txt_Eslogan.Text, FuLogo)
        Me.DvEnt.DataBind()
        Me.MsgBox(MsgResult, Obj.lErrorG)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim Obj As Entidad = New Entidad
        Dim dt As DataTable
        dt = Obj.GetbyPk(Me.DvEnt.DataKey("Cod_SecPrincipal").ToString)
        Txt_Cod.Text = dt.Rows(0)("Cod_SecPrincipal").ToString
        Txt_nom.Text = dt.Rows(0)("Nom_SecPrincipal").ToString
        Txt_Nit.Text = dt.Rows(0)("Nit").ToString
        Txt_Rep_Legal.Text = dt.Rows(0)("Representante_Legal").ToString
        Txt_Tel.Text = dt.Rows(0)("Telefono").ToString
        Txt_Fax.Text = dt.Rows(0)("Fax").ToString
        Txt_Correo.Text = dt.Rows(0)("Email").ToString
        Txt_Dir.Text = dt.Rows(0)("Direccion").ToString
        Txt_Pais.Text = dt.Rows(0)("Pais").ToString
        Txt_Dep.Text = dt.Rows(0)("Departamento").ToString
        Txt_Ciudad.Text = dt.Rows(0)("Ciudad").ToString
        Txt_Eslogan.Text = dt.Rows(0)("Municipio").ToString
        Me.Pk1 = dt.Rows(0)("Cod_SecPrincipal").ToString
        Me.ModalPopupExtender3.Show()
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        

    End Sub
End Class
