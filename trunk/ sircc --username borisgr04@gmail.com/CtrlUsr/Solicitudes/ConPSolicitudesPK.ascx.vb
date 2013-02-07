
Partial Class CtrlUsr_ConPSolicitudesPk
    Inherits CtrlUsrComun

#Region "Eventos del control"

    Public Event SelClicked As EventHandler

    Public Property Cod_Sol() As String
        Get
            Return ViewState("Cod_Sol")
        End Get
        Set(ByVal value As String)
            ViewState("Cod_Sol") = value
        End Set
    End Property

    Protected Overridable Sub OnClick(ByVal sender As Object)
        If Oper = "Seleccionar" Then
            RaiseEvent SelClicked(sender, New EventArgs())
        End If

    End Sub
#End Region

    Protected Sub grdProcesos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProcesos.SelectedIndexChanged
        Cod_Sol = grdProcesos.SelectedValue
        Oper = "Seleccionar"
        OnClick(sender)
        Me.TxtFill.Text = ""
        Me.grdProcesos.DataBind()
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LbVigencia.Text = Me.Vigencia_Cookie
    End Sub
End Class
