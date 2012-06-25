
Partial Class CtrlUsr_AdmTercero_UpdAdmTerceros
    Inherits UpdCtrlUsrComun

    Public ReadOnly Property Nit As String
        Get
            Return AdmTercero1.Nit
        End Get

    End Property

    Public ReadOnly Property Nom_Ter As String
        Get
            Return AdmTercero1.Nom_Ter
        End Get

    End Property

    Public Overrides Sub Mostrar()
        modalPopupCon.Show()
    End Sub

    Public Overrides Sub Ocultar()
        modalPopupCon.Hide()
    End Sub


    Public Sub Grid1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdmTercero1.SelClicked
        Grid_SelClicked(sender, e)
    End Sub

    
End Class
