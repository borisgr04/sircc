
Partial Class Contratos_Legalizacion_Default
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
        Me.grdPolC1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.grdPolC1.LlenarGrid()
        Me.grdIntC1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.grdIntC1.LlenarGrid()
        Me.grdLegC1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.grdLegC1.LlenarGrid()
        If DetContrato1.TipRadicacion = "A" Then
            Me.grdRP1.Enabled = False
            Me.grdImpC1.Enabled = False
            Me.grdPolC1.Enabled = False
            Me.grdIntC1.Enabled = False
            Me.grdLegC1.Enabled = False
            Me.ExImpC1.Enabled = False
            Me.MsgResult.Text = "Legalización solo para contratos Manuales"
            MsgBoxAlert(MsgResult, True)
        Else
            Me.grdRP1.Enabled = True
            Me.grdImpC1.Enabled = True
            Me.grdPolC1.Enabled = True
            Me.grdIntC1.Enabled = True
            Me.grdLegC1.Enabled = True
            Me.ExImpC1.Enabled = True
        End If
    End Sub
End Class
