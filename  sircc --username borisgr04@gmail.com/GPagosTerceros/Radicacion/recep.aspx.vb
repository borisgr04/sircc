
Partial Class GPagosTerceros_Radicacion_recep
    Inherits PaginaComun


    Protected Sub Page_Load1(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim rp As New recepAP
        hdCodCon.Value = Request("Cod_Con")
        Me.DetContratoI1.DataSource = rp.GetByContratosPk(hdCodCon.Value)
        Me.DetContratoI1.DataBind()
    End Sub

    Protected Sub IBtnVerDoc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnVerDoc.Click
        Dim nd As String = Request("Id")
        If Not String.IsNullOrEmpty(nd) Then
            Redireccionar_Pagina("/ashx/VerActas.ashx?Ide_Acta=" + nd)

        End If
    End Sub

    Protected Sub IBtnGuardar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Dim obj As New Int_GP_SEG_DOC
        obj.Est_Ini = "00"
        obj.Est_Fin = "01"
        obj.Id_Doc = Request("Id")
        obj.Fec_Reg = TxtRad.Text
        obj.Obs_Seg = ""

        Dim objR As New recepAP
        MsgResult.Text = objR.insert(obj)
        MsgBox(MsgResult, objR.lErrorG)



    End Sub
End Class
