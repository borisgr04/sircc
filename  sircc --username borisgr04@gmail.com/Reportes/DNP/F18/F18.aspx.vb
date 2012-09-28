Imports System.Data
Partial Class Reportes_DNP_F18
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

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TxtVig.Text = Vigencia_Cookie
            Me.ChkVig.Checked = True
        End If
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Sub FUTReg()
        Dim strSql As String = ""
        Dim cFiltro As String = genFiltro()
        If TxtVig.Text = "2012" Then
            strSql = " Select * From dnp2012 "
            strSql += " WHERE numero LIKE '2012%' "
            If (ChkFecSus.Checked = True) Then
                strSql += " AND FEC_SUS_CON BETWEEN TO_DATE('" + CDate(TxtFecSus1.Text).ToShortDateString + "','dd/mm/yyyy') AND inifecharef(to_date('" + CDate(TxtFecSus2.Text).ToShortDateString + "','dd/mm/yyyy'))"
            End If
            If Not String.IsNullOrEmpty(cFiltro) Then
                strSql += " And Numero In ( Select Numero FROM vcontratos_Sinc_p c  " + cFiltro + " )"
            End If
            ''extraer parte de la cadena
            strSql += " And SUBSTR (TRIM (SUBSTR (id_ppal, 0, INSTR (id_ppal, ':') - 1)), -2) In (Select Recursos from rec_reg WHERE VIGENCIA=2012 AND TIP_REC='REG')"
            'strSql += " AND valorxrp > 0"
            'strSql += " AND valregalias2012 (nro_rp, cod_rub)>0   "
            strSql += " ORDER BY numero"
            Me.HdSql.Value = strSql
            MsgResult.Text = strSql
            GridView1.DataBind()
            GridView1.Visible = True
            ExportGridView(GridView1, "Formato_DNP_18")
        Else
            MsgResult.Text = "No Implementado"
        End If

    End Sub

    Protected Sub IBtnExportExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnExportExcel.Click
        FUTReg()

    End Sub
End Class
