
Partial Class CtrlUsr_grdProyectos_ConProyectos
    Inherits CtrlUsrComun

#Region "Eventos del control"

    Public Event SelClicked As EventHandler

    Public Property Num_Proy() As String
        Get
            Return ViewState("Num_Proy")
        End Get
        Set(ByVal value As String)
            ViewState("Num_Proy") = value
        End Set
    End Property
    Public Property Nom_Proy() As String
        Get
            Return ViewState("Nom_Proy")
        End Get
        Set(ByVal value As String)
            ViewState("Nom_Proy") = value
        End Set
    End Property
    Protected Overridable Sub OnClick(ByVal sender As Object)
        If Oper = "Seleccionar" Then
            RaiseEvent SelClicked(sender, New EventArgs())
        End If
    End Sub
#End Region


    Protected Sub grdProcesos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProcesos.SelectedIndexChanged
        Dim index As Integer = grdProcesos.SelectedIndex
        Num_Proy = Me.grdProcesos.DataKeys(index).Values(0).ToString
        Nom_Proy = Me.grdProcesos.DataKeys(index).Values(1).ToString
        Oper = "Seleccionar"
        OnClick(sender)
        TxtFiltrar.Text = ""
        grdProcesos.DataBind()
    End Sub

    Protected Sub grdProcesos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProcesos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub IbtnBucar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnBucar.Click

    End Sub
End Class
