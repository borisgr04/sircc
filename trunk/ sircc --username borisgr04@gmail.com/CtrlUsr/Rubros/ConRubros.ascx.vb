
Partial Class CtrlUsr_Rubros_ConRubros
    Inherits CtrlUsrComun

#Region "Eventos del control"

    Public Event SelClicked As EventHandler

    Public Property Cod_Rub() As String
        Get
            Return ViewState("Cod_Rub")
        End Get
        Set(ByVal value As String)
            ViewState("Cod_Rub") = value
        End Set
    End Property
    Public Property Des_Rub() As String
        Get
            Return ViewState("Des_Rub")
        End Get
        Set(ByVal value As String)
            ViewState("Des_Rub") = value
        End Set
    End Property

    Protected Overridable Sub OnClick(ByVal sender As Object)
        If Oper = "Seleccionar" Then
            RaiseEvent SelClicked(sender, New EventArgs())

        End If

    End Sub
#End Region

    Protected Sub grdProcesos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProcesos.Load
        If Not Page.IsPostBack Then
            Me.LbVigencia.Text = Vigencia_Cookie
            'Me.LbVigencia.Text = "2010"
        End If
    End Sub


    Protected Sub grdProcesos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProcesos.SelectedIndexChanged
        Dim index As Integer = grdProcesos.SelectedIndex
        Cod_Rub = Me.grdProcesos.DataKeys(index).Values(0).ToString
        Des_Rub = Me.grdProcesos.DataKeys(index).Values(1).ToString
        Oper = "Seleccionar"
        OnClick(sender)
        Me.TxtFil.Text = ""
        grdProcesos.DataBind()
    End Sub

    Protected Sub grdProcesos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProcesos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub
End Class

