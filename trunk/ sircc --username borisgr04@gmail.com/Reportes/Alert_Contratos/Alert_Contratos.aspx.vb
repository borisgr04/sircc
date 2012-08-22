
Partial Class Reportes_Alert_Contratos_Alert_Contratos
    Inherits PaginaComun

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAlert_Contratos.SelectedIndexChanged
        'TxtFRef.Text = GridView1.SelectedValue
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Select CboTipo.SelectedValue
            Case "CxT"
                MultiView1.ActiveViewIndex = 0
            Case "CxL"
                MultiView1.ActiveViewIndex = 0
            Case "PxV"
                MultiView1.ActiveViewIndex = 1
                grdPolizas.DataBind()
        End Select

        Title = CboTipo.SelectedValue

    End Sub

    Protected Sub grdPolizas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPolizas.SelectedIndexChanged
        hlContrato.NavigateUrl = hdUrl.Value + "?Numero=" + grdPolizas.SelectedValue
    End Sub

    Protected Sub ExpExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpExcel.Click
        Dim g As New GridView
        Dim obj As New Alert_Contratos
        g.DataSource = obj.GetExp_Alert_Polizas(txtNdias.Text, CboFilVig0.SelectedValue)
        g.DataBind()
        ExportGridView(g, CboTipo.Text)
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub ExpExcel0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpExcel0.Click
        Dim g As New GridView
        Dim obj As New Alert_Contratos
        g.DataSource = obj.GetExp_Alert(Me.CboTipo.SelectedValue, txtNdias.Text, CboFilVig0.SelectedValue)
        g.DataBind()
        ExportGridView(g, CboTipo.Text)

    End Sub
End Class
