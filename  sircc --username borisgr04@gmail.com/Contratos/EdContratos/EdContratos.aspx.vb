Imports System.Data
Partial Class Contratos_EdContratos_EdContratos
    Inherits PaginaComun

  
    Sub Guardar()

        Dim edc As New EdContratos
        edc.Cod_Con = DetContrato1.Cod_Con
        MsgResult.Text = edc.Mod_Fec_Sus_Con(DetContrato1.Cod_Con, TxtFecSusCon.Text)
        DetContrato1.Buscar()
        MsgBox(MsgResult, edc.lErrorG)

    End Sub
    Protected Sub DetContrato1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContrato1.AceptarClicked

        If DetContrato1.Encontrado = True Then
            Panel1.Visible = True

            Me.TxtFecSusCon.Text = DetContrato1.dtContratos.Rows(0)("Fec_Sus_Con")
            Dim edc As New EdContratos()
            edc.Cod_Con = DetContrato1.Cod_Con
            edc.cargarRef(TxtFecSusCon.Text)
            LbFS_Ant.Text = edc.Fs_ant
            lbFS_Sig.Text = edc.Fs_sig

        Else
            Panel1.Visible = False
            LbFS_Ant.Text = ""
            lbFS_Sig.Text = ""
           
        End If
     


    End Sub
    

    

    Protected Sub IBtnGuardar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Guardar()
  
    End Sub

End Class
