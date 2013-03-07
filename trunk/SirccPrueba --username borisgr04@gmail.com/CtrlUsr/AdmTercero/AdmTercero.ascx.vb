
Partial Class CtrlUsr_AdmTercero_AdmTercero
    Inherits CtrlUsrComun


    Public ReadOnly Property Nit As String
        Get
            Return ConsultaTer21.Ide_Ter
        End Get

    End Property

    Public ReadOnly Property Nom_Ter As String
        Get
            Return ConsultaTer21.Nom_Ter
        End Get

    End Property

    Public Property TipoTer As String
        Get
            Return ViewState("TipoTer")
        End Get
        Set(ByVal value As String)
            ViewState("TipoTer") = value
        End Set
    End Property

#Region "Eventos del control"
    Public Event SelClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent SelClicked(sender, New EventArgs())
    End Sub
#End Region
    Sub ConsultaTer21_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        OnClick(sender)
    End Sub

    Sub ConsultaTer21_OnNuevoClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        CrTerceros1.Nuevo()
        Me.MultiView1.ActiveViewIndex = 1
    End Sub
    Sub ConsultaTer21_EditClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        CrTerceros1.Nit = ConsultaTer21.Ide_Ter
        CrTerceros1.Editar()
        Me.MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub BtnVoler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVoler.Click
        ConsultaTer21.Filtro = CrTerceros1.Nit
        ConsultaTer21.DataBind()
        Me.MultiView1.ActiveViewIndex = 0
    End Sub
End Class
