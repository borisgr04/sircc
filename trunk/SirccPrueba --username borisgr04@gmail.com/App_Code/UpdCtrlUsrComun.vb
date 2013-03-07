Imports Microsoft.VisualBasic

Public MustInherit Class UpdCtrlUsrComun
    Inherits CtrlUsrComun


    Public Event SelClicked As EventHandler

    Protected Overridable Sub Onclick(ByVal sender As Object)
        RaiseEvent SelClicked(sender, New EventArgs)
    End Sub

    Public MustOverride Sub Mostrar()

    Public MustOverride Sub Ocultar()

    Public Sub Grid_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        Onclick(sender)
    End Sub

End Class
