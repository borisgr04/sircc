
Partial Class Reportes_Ias_Ias
    Inherits PaginaComun

    Protected Function genFiltro() As String

        Dim obj As New Contratos()
        Dim cFiltro As String = ""
        If (ChkNum.Checked = True) Then
            If (Me.TxtNCon.Text.Length <> 10) Then
                chkTip.Checked = True
                Me.TxtNCon.Text = obj.GetCodigo(Me.CboTip.SelectedValue, Me.TxtNCon.Text, Me.Vigencia_Cookie)
            End If
            Util.AddFiltro(cFiltro, "numero Like '" + TxtNCon.Text + "'")
        End If
        If (chkTip.Checked = True) Then
            Util.AddFiltro(cFiltro, "tip_con='" + CboTip.Text + "'")
        End If
        If (ChkDep.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_con='" + CboDep.Text + "'")
        End If
        If (ChkEst.Checked = True) Then
            Util.AddFiltro(cFiltro, "est_con='" + CboEst.Text + "'")
        End If
        If (ChkStip.Checked = True) Then
            Util.AddFiltro(cFiltro, "stip_con='" + cboStip.Text + "'")
        End If

        If (Me.ChkPDep.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_pcon = '" + Me.CboDepP.SelectedValue + "'")
        End If

        If (Me.ChkAnul.Checked = False) Then
            Util.AddFiltro(cFiltro, "EST_CON <> '07'")
        End If

        If cFiltro <> String.Empty Then
            cFiltro = " Where " + cFiltro
        End If

        Return cFiltro
    End Function
    Protected Sub IBtnExportExcel_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnExportExcel.Click

        Dim rptG As IReportes = CReporteFactory.Intance.CreateReport("FUT_2012_1", genFiltro())
        Dim str As String = rptG.GenerarReporte()

        Response.Write(str)
        'GridView1.DataBind()
        'GridView1.Visible = True
        'ExportGridView(GridView1, "Formato_FUT_Regalias")

    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
End Class
