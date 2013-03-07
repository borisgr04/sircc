
Partial Class Controles_ConDocContratos
    Inherits CtrlUsrComun

    Property CodigoContrato As String
        Set(ByVal value As String)
            ViewState("CodigoContrato") = value
        End Set
        Get
            Return ViewState("CodigoContrato")
        End Get
    End Property
    
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Response.Redirect("~/ashx/verDOC.ashx?id=" + Me.GridView1.SelectedValue.ToString)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnDescargar.Click
        Dim obj As DocContratos = New DocContratos
        'Me.MsgR.Text = obj.Generar_Zip(CodigoContrato)
        'MsgBox(MsgR, obj.lErrorG)
        Dim c As Integer = obj.GetCant_Doc_Contratos(CodigoContrato)
        If c > 0 Then
            Response.Redirect("~/ashx/verZIP.ashx?id=" + CodigoContrato)
            MsgBoxLimpiar(MsgR)
        Else
            Me.MsgR.Text = "No se generó archivo de salida, verificar si existe archivos cargados al contrato. si existen comuniquese con el proveedor"
            MsgBox(MsgR, True)
        End If

    End Sub
End Class