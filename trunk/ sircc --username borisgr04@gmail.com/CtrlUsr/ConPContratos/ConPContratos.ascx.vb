
Partial Class CtrlUsr_ConPContratos_ConPContratos
    Inherits CtrlUsrComun

#Region "Eventos del control"

    Public Event SelClicked As EventHandler

    Public Property Num_Proc As String
        Get
            Return grdProcesos.SelectedValue
        End Get
        Set(ByVal value As String)
            'FiltroPCon1.ChkNum_Proc = True
            FiltroPCon1.Num_Proc = value
            'FiltroPCon1.RFiltrar()
            'Me.grdProcesos.DataBind()
        End Set
    End Property

    Protected Overridable Sub OnClick(ByVal sender As Object)
        If Oper = "Seleccionar" Then
            RaiseEvent SelClicked(sender, New EventArgs())

        End If

    End Sub
#End Region


    Protected Sub grdProcesos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProcesos.SelectedIndexChanged
        'Num_Proc = grdProcesos.SelectedValue
        Oper = "Seleccionar"
        OnClick(sender)
    End Sub

    Protected Sub grdProcesos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProcesos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub
End Class
