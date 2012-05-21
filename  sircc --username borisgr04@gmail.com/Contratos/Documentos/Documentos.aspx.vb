
Partial Class Contratos_Documentos_default
    Inherits PaginaComun

    Protected Sub BtnDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDoc.Click
        Me.CargarDoc1.CodigoContrato = Me.DetContrato1.Cod_Con
        Me.CargarDoc1.Cargar_Documentos()

        Me.CargarDoc2.CodigoContrato = Me.DetContrato1.Cod_Con
        Me.CargarDoc2.Cargar_Documentos()

        Me.CargarDoc3.CodigoContrato = Me.DetContrato1.Cod_Con
        Me.CargarDoc3.Cargar_Documentos()

        Me.CargarDoc4.CodigoContrato = Me.DetContrato1.Cod_Con
        Me.CargarDoc4.Cargar_Documentos()

        Me.CargarDoc5.CodigoContrato = Me.DetContrato1.Cod_Con
        Me.CargarDoc5.Cargar_Documentos()


        Me.ConDocContratos1.DataBind()
    End Sub

  

    Protected Sub DetContrato1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContrato1.AceptarClicked
        Me.ConDocContratos1.CodigoContrato = Me.DetContrato1.Cod_Con
    End Sub
End Class
