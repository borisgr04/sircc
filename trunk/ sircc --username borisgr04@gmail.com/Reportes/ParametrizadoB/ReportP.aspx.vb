Imports System.Configuration
Imports System.Data
Imports Microsoft.Reporting.WebForms

Partial Class Reportes_ParametrizadoB_ReportP
    Inherits PaginaComun
    Dim rutaReport As String

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Reporte()

    End Sub

    Sub Reporte()
        Dim Sql As String = Request.QueryString("Sql")
        Me.TxtSql.Text = Sql
        Me.TxtSql.Visible = False
        Select Case Request.QueryString("Rpte")
            Case "Dep_Nec"
                rutaReport = "Rpt\RptB\RptConsTCt2013xDep.rdlc"
                ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia"
            Case "Dep_Del"
                rutaReport = "Rpt\RptB\RptConsTCt2013xDepE.rdlc"
                ReportViewer1.LocalReport.DisplayName = "Reporte x Proyecto"
                'Case "Pro_Con"
                '    rutaReport = "Rpt\RptB\RptConsTCt2011xPro.rdlc"
                '    ReportViewer1.LocalReport.DisplayName = "Reporte x Dependencia Delegada"
                'Case "Pol_Con"
                '    rutaReport = "Rpt\RptB\RptConsTCt2011Pol.rdlc"
                '    ReportViewer1.LocalReport.DisplayName = "Reporte x Polizas"
                'Case "sb" 'solo datos basicos
                '    rutaReport = "Rpt\RptB\RptConsTCt2011.rdlc"
                '    ReportViewer1.LocalReport.DisplayName = "Reporte x Datos del Contrato"
            Case Else
                rutaReport = "Rpt/RptB/RptConsTCt2013.rdlc"
                ReportViewer1.LocalReport.DisplayName = "Reporte General"
        End Select
        ReportViewer1.LocalReport.ReportPath = rutaReport
        ReportViewer1.LocalReport.Refresh()
    End Sub

  
End Class
