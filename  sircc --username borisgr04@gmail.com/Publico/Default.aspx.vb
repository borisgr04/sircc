Imports System.IO

Partial Class Publico_Default
    Inherits System.Web.UI.Page

    Protected Sub LbNav_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbNav.Load
        'Dim s As String = ""
        'With Request.Browser
        '    s &= "Browser Capabilities" & "<br/>"
        '    s &= "Type = " & .Type & "<br/>"
        '    s &= "Name = " & .Browser & "<br/>"
        '    s &= "Version = " & .Version & "<br/>"
        '    s &= "Major Version = " & .MajorVersion & "<br/>"
        '    s &= "Minor Version = " & .MinorVersion & "<br/>"
        '    s &= "Platform = " & .Platform & "<br/>"
        '    s &= "Is Beta = " & .Beta & "<br/>"
        '    s &= "Is Crawler = " & .Crawler & "<br/>"
        '    s &= "Is AOL = " & .AOL & "<br/>"
        '    s &= "Is Win16 = " & .Win16 & "<br/>"
        '    s &= "Is Win32 = " & .Win32 & "<br/>"
        '    s &= "Supports Frames = " & .Frames & "<br/>"
        '    s &= "Supports Tables = " & .Tables & "<br/>"
        '    s &= "Supports Cookies = " & .Cookies & "<br/>"
        '    s &= "Supports VBScript = " & .VBScript & "<br/>"
        '    s &= "Supports JavaScript = " & _
        '        .EcmaScriptVersion.ToString() & "<br/>"
        '    s &= "Supports Java Applets = " & .JavaApplets & "<br/>"
        '    s &= "Supports ActiveX Controls = " & .ActiveXControls & _
        '        "<br/>"
        'End With
        'LbNav.Text = s
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim obj As New BDDatos

            Dim Script As String = txtScript.Text

            Script = Script.Replace("@v", "Pct" + txtVig.Text)
            Script = Script.Replace("@ei", txtei.Text)
            Script = Script.Replace("@ef", txtef.Text)

            txtScript.Text = Script

            Dim grd As New GridView
            grd.DataSource = obj.GetSelect(Script)
            grd.DataBind()
            ExportGridView(grd, "Export")
        Catch ex As Exception
            LbError.Text = ex.Message
            LbError.ForeColor = Drawing.Color.Red
        End Try


    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub Configuración_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk1.CheckedChanged
        txtScript.Visible = Chk1.Checked
    End Sub
    Public Sub ExportGridView(ByVal grd As GridView, Optional ByVal Archivo As String = "Export")

        Dim attachment As String = String.Format("attachment; filename={0}.xls", Archivo)
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        grd.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.End()
    End Sub
End Class
