
Partial Class CtrlUsr_Consorcios_UpdConConsorcios
    Inherits UpdCtrlUsrComun

    Public ReadOnly Property Ide_Ter As String
        Get
            Return Me.ConsultaCONUT1.Ide_Ter
        End Get

    End Property

    Public ReadOnly Property Nom_Ter As String
        Get
            Return Me.ConsultaCONUT1.Nom_Ter
        End Get

    End Property

    Public Overrides Sub Mostrar()
        modalPopupCon.Show()
    End Sub

    Public Overrides Sub Ocultar()
        modalPopupCon.Hide()
    End Sub



    Public Sub Grid1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConsultaCONUT1.SelClicked
        Grid_SelClicked(sender, e)
    End Sub


End Class
