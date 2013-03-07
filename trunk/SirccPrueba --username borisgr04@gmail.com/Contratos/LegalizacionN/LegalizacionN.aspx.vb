
Partial Class Contratos_LegalizacionN_Default
    Inherits PaginaComun

    Protected Sub DetContrato1_OnAceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContrato1.AceptarClicked
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Me.grdRP1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.grdRP1.LlenarGrid()
        Me.grdImpC1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.grdImpC1.LlenarGrid()
        Me.ExImpC1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.ExImpC1.dtContratos = Me.DetContrato1.dtContratos
        Me.ExImpC1.Actualizar()
        Me.grdPolCN1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.grdPolCN1.Grupo = Me.DetContrato1.Grupo
        Me.grdPolCN1.Proceso = Me.DetContrato1.Proceso
        Me.grdPolCN1.LlenarGrid()
        Me.grdPolCN1.llenarCOmbo()
        Me.grdIntC1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.grdIntC1.LlenarGrid()
        Me.grdLegC1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.grdLegC1.Proceso = DetContrato1.Proceso
        Me.grdLegC1.Grupo = DetContrato1.Grupo
        Me.grdLegC1.LlenarGrid()
        If DetContrato1.TipRadicacion = "M" Or DetContrato1.Encontrado = False Then
            Me.grdRP1.Enabled = False
            Me.grdImpC1.Enabled = False
            Me.grdPolCN1.Enabled = False
            Me.grdIntC1.Enabled = False
            Me.grdLegC1.Enabled = False
            Me.ExImpC1.Enabled = False
            If DetContrato1.TipRadicacion = "M" Then
                Me.MsgResult.Text = "Legalización solo para contratos Automaticos"
                MsgBoxAlert(MsgResult, True)
            End If
        ElseIf DetContrato1.Encontrado = True Or DetContrato1.TipRadicacion = "A" Then
            Me.grdRP1.Enabled = True
            Me.grdImpC1.Enabled = True
            Me.grdPolCN1.Enabled = True
            Me.grdIntC1.Enabled = True
            Me.grdLegC1.Enabled = True
            Me.ExImpC1.Enabled = True
        End If
    End Sub
End Class
