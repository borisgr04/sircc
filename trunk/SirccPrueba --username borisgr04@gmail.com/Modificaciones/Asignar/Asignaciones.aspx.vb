Imports System.Data
Partial Class SolAdiciones_Asignaciones_Default
    Inherits PaginaComun

    Protected Sub BtnAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAsignar.Click
        Dim obj As New Sol_Adiciones
        Me.MsgResult.Text = obj.Asignar_Usuario_Encargado(DetContratoAdi1.IdSolAdi, Me.TxtIde.Text)
        MsgBox(MsgResult, obj.lErrorG)
        Me.GridView1.DataBind()
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.ModalPopup.Show()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.DetContratoAdi1.Cod_Con = Request("Cod_Con")
            Me.DetContratoAdi1.IdSolAdi = Request("Num_Sol")
            Me.DetContratoAdi1.Buscar2()
            DetPContrato_OnAceptarClicked(Nothing, Nothing)
            'Me.DetContratoAdi1.Actualizar()
        End If
    End Sub

    Protected Sub DetPContrato_OnAceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContratoAdi1.AceptarClicked
        Me.ConsultaTerxDep.Tipo = Me.DetContratoAdi1.Dep_PCon
        Me.ConsultaTerxDep.DataBind()
        MsgBoxLimpiar(MsgResult)
        limpiar()

        
        If Me.DetContratoAdi1.Encontrado = True Then
            Me.Panel1.Visible = True
        Else
            Me.Panel1.Visible = False
        End If
        Me.UpdatePanel1.Update()


        Me.Title = (Me.DetContratoAdi1.Dep_PCon)


    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If

    End Sub

    Protected Sub TxtIde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIde.TextChanged
        Dim oTer As New Terceros
        Dim dt As DataTable = New DataTable
        dt = oTer.GetTercerosxIde_Dep(Me.TxtIde.Text, Me.DetContratoAdi1.Dep_PCon)

        If dt.Rows.Count > 0 Then
            Me.TxtIde.Text = dt.Rows(0).Item("Ide_Ter").ToString
            Me.TxtNomTer.Text = dt.Rows(0).Item("Nom_Ter").ToString
            Me.BtnAsignar.Enabled = True
            Me.MsgResult.Text = ""
            Me.MsgResult.CssClass = ""
        Else
            Me.ModalPopup.Show()
            Me.BtnAsignar.Enabled = False
            Me.TxtNomTer.Text = ""
            Me.MsgResult.Text = "El documento no corresponde a un Abogado de la Dependencia."
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub
    Sub limpiar()
        Me.TxtIde.Text = ""
        Me.TxtNomTer.Text = ""
    End Sub
End Class
