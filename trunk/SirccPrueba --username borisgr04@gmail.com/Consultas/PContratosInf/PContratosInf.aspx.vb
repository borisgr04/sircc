
Partial Class Consultas_Pcontratos_PContratosInf
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TxtF1.Text = Today.AddMonths(-1).ToShortDateString
            TxtF2.Text = Today.ToShortDateString
        End If
    End Sub

    Protected Sub BtnAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAct.Click
        ArmarMod()
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub ChkMod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMod.SelectedIndexChanged
        ArmarMod()

    End Sub

    Private Sub ArmarMod()
        Dim Sel As String
        Sel = ""
        For i As Integer = 0 To ChkMod.Items.Count - 1
            If ChkMod.Items(i).Selected Then
                Sel += IIf(Sel = "", "'" + ChkMod.Items(i).Value + "'", ",'" + ChkMod.Items(i).Value + "'")
            End If
        Next i
        Label1.Text = Sel
        TextBox1.Text = Sel



    End Sub

End Class
