Imports System.Data
Partial Class Procesos_Asignaciones_Default
    Inherits PaginaComun

    Protected Sub BtnAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAsignar.Click
        Dim obj As New PContratos
        Me.MsgResult.Text = obj.Asignar_Usuario_Encargado(Me.DetPContrato1.CodigoPContrato, Me.TxtIde.Text)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        Me.DetPContrato1.Buscar()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.ModalPopup.Show()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        

    End Sub

    Protected Sub DetPContrato1_BuscarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetPContrato1.BuscarClicked
        'CalenProgl1.Num_Proc = Me.DetPContrato1.CodigoPContrato
        'CalenProgl1.Est_Crono = Me.DetPContrato1.Est_Crono
        'CalenProgl1.DataBind()
        Me.ModalPopupConP.Show()
    End Sub

    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        Me.DetPContrato1.CodigoPContrato = ConPContratos1.Num_Proc
        Me.DetPContrato1.Buscar()
        Me.ModalPopupConP.Hide()
        UpdatePanel1.Update()
    End Sub
    Protected Sub DetPContrato_OnAceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetPContrato1.AceptarClicked
        Me.ConsultaTerxDep.Tipo = Me.DetPContrato1.Dep_PCon
        Me.ConsultaTerxDep.DataBind()
        If Me.DetPContrato1.Encontrado = True Then
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
        dt = oTer.GetTercerosxIde_Dep(Me.TxtIde.Text, Me.DetPContrato1.Dep_PCon)
        If dt.Rows.Count > 0 Then
            Me.TxtIde.Text = dt.Rows(0).Item("Ide_Ter").ToString
            Me.TxtNomTer.Text = dt.Rows(0).Item("Nom_Ter").ToString
        Else
            Me.ModalPopup.Show()
        End If
    End Sub
End Class
