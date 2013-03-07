Imports Microsoft.Reporting.WebForms

Partial Class CtrlUsr_ConAsignacionesSP_ConAsigSP
    Inherits CtrlUsrComun
    Protected Sub CboDepP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDepP.SelectedIndexChanged
        ReportViewer2.LocalReport.Refresh()
        'Mail.EnviarNot("borisgr04@hotmail.com", "Prueba envio de reporte", "report", RenderReport(ReportViewer1.LocalReport))
    End Sub

    Private Function RenderReport(ByVal Rpt As LocalReport) As Byte()
        'string reportType = "Image"; 
        Dim reportType As String = "PDF"
        Dim fileNameExtension As String = ""
        Dim warnings As Warning() = Nothing
        Dim streamids As String() = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim extension As String = Nothing
        'The DeviceInfo settings should be changed based on the reportType 
        'http://msdn2.microsoft.com/en-us/library/ms155397.aspx 
        Dim deviceInfo As String = "<DeviceInfo>" & " <OutputFormat>PDF</OutputFormat>" & " <PageWidth>8.5in</PageWidth>" & " <PageHeight>11in</PageHeight>" & " <MarginTop>0.5in</MarginTop>" & " <MarginLeft>1in</MarginLeft>" & " <MarginRight>1in</MarginRight>" & " <MarginBottom>0.5in</MarginBottom>" & "</DeviceInfo>"
        Dim streams As String() = Nothing
        Dim renderedBytes As Byte()
        Rpt.Refresh()
        renderedBytes = Rpt.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, streams, warnings)
        Return renderedBytes
    End Function
End Class
