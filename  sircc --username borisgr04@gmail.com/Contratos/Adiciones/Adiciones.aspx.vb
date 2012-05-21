
Partial Class Contratos_Adiciones_Default
    Inherits PaginaComun
    Protected Sub DetContrato1_OnAceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContrato1.AceptarClicked
        Me.grdAdiC1.Cod_Con = Me.DetContrato1.Cod_Con
        Me.grdAdiC1.LlenarGrid()
    End Sub

    Protected Sub grdAdiC1_RadClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAdiC1.RadClicked
        Me.DetContrato1.Buscar()
    End Sub
End Class
