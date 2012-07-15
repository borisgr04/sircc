
Partial Class CtrlUsr_SelCampos_SelCampos
    Inherits CtrlUsrComun

    Property Vista As String
        Get
            Return HdVista.Value
        End Get
        Set(ByVal value As String)
            HdVista.Value = value
        End Set
    End Property
    ReadOnly Property Campos As String
        Get
            Return ObtenerCampos()
        End Get
    End Property

    Private Function ObtenerCampos() As String
        Dim campos As String = ""
        LbCampos.Text = ""
        For i As Integer = 0 To ListBox2.Items.Count - 1
            campos += IIf(String.IsNullOrEmpty(campos), "", ",") + ListBox2.Items(i).Value + " As " + ListBox2.Items(i).Text
        Next
        Return campos
    End Function


End Class
