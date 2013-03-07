Imports System.Data
Partial Class Contratos_Asignaciones_Default
    Inherits PaginaComun

    Protected Sub BtnAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAsignar.Click
        Dim obj As New ContratosA
        Me.MsgResult.Text = obj.Asignar_Encargado(DetContrato1.Cod_Con, Me.TxtIde.Text)
        MsgBox(MsgResult, obj.lErrorG)
        Me.GridView1.DataBind()
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.ModalPopup.Show()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub DetPContrato_OnAceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContrato1.AceptarClicked
        Me.ConsultaTerxDep.Tipo = Me.DetContrato1.Dep_PCon
        Me.ConsultaTerxDep.DataBind()
        If Me.DetContrato1.Encontrado = True Then
            Me.Panel1.Visible = True
        Else
            Me.Panel1.Visible = False
        End If
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
        dt = oTer.GetTercerosxIde_Dep(Me.TxtIde.Text, Me.DetContrato1.Dep_PCon)
        If dt.Rows.Count > 0 Then
            Me.TxtIde.Text = dt.Rows(0).Item("Ide_Ter").ToString
            Me.TxtNomTer.Text = dt.Rows(0).Item("Nom_Ter").ToString
        Else
            Me.ModalPopup.Show()
        End If
    End Sub
End Class
