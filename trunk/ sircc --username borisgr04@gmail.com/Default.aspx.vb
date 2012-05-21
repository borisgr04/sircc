Imports System.Data
Partial Class _Default
    Inherits PaginaComun


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.SetTitulo()

        Dim t As New Terceros

        If t.GetIsAsig_Proc() Then
            Redireccionar_Pagina("Consultas/AvisosAct/AvisosAct.aspx")
        End If

        'Dim objE As New Entidad
        'Dim dt As DataTable = objE.GetRecords()
        'Dim b As Byte() = DirectCast(dt.Rows(0)("Logo_Rpt"), Byte())
        'Dim vFilename As String = "Docs/Logo.jpg"
        'Dim FileName As String = Server.MapPath(vFilename)
        'Util.SaveJPG(Util.Bytes2Image(b), FileName)
        'Image3.ImageUrl = vFilename

    End Sub
End Class
