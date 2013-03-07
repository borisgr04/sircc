
Partial Class Publico_Navegador
    Inherits System.Web.UI.Page

    Protected Sub LbNav_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbNav.Load
        Dim s As String = ""
        With Request.Browser
            s &= "Browser Capabilities" & "<br/>"
            s &= "Type = " & .Type & "<br/>"
            s &= "Name = " & .Browser & "<br/>"
            s &= "Version = " & .Version & "<br/>"
            s &= "Major Version = " & .MajorVersion & "<br/>"
            s &= "Minor Version = " & .MinorVersion & "<br/>"
            s &= "Platform = " & .Platform & "<br/>"
            s &= "Is Beta = " & .Beta & "<br/>"
            s &= "Is Crawler = " & .Crawler & "<br/>"
            s &= "Is AOL = " & .AOL & "<br/>"
            s &= "Is Win16 = " & .Win16 & "<br/>"
            s &= "Is Win32 = " & .Win32 & "<br/>"
            s &= "Supports Frames = " & .Frames & "<br/>"
            s &= "Supports Tables = " & .Tables & "<br/>"
            s &= "Supports Cookies = " & .Cookies & "<br/>"
            s &= "Supports VBScript = " & .VBScript & "<br/>"
            s &= "Supports JavaScript = " & _
                .EcmaScriptVersion.ToString() & "<br/>"
            s &= "Supports Java Applets = " & .JavaApplets & "<br/>"
            s &= "Supports ActiveX Controls = " & .ActiveXControls & _
                "<br/>"
        End With
        LbNav.Text = s
    End Sub
End Class
