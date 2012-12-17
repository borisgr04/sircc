Imports System.Data
Partial Class Procesos_GAdjudicacion_Default
    Inherits PaginaComun
    Dim obj As New GPProponentes

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

    End Sub
    Protected Sub DetPContrato1_BuscarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetPContrato1.BuscarClicked
        Me.ModalPopupConP.Show()
    End Sub

    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        Me.DetPContrato1.CodigoPContrato = ConPContratos1.Num_Proc
        UpdatePanel1.Update()
        Me.ModalPopupConP.Hide()
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        GridView1.DataBind()
    End Sub

    Protected Sub IbAdjudicar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbAdjudicar.Click
        If DetPContrato1.Encontrado Then
            If IsDate(TxtFecAdju.Text) Then
                MsgResult.Text = obj.Adjudicar(Me.GridView1, Me.DetPContrato1.CodigoPContrato, CDate(TxtFecAdju.Text).ToShortDateString, Me.DetPContrato1.Grupo)
                MsgBox(MsgResult, obj.lErrorG)
                GridView1.DataBind()
            Else
                MsgResult.Text = "Debe seleccionar o escribir una Fecha Valida"
                MsgBoxAlert(MsgResult, obj.lErrorG)
            End If
        Else
            MsgResult.Text = "No se ha seleccionado un proceso para Adjudicar"
            MsgBoxAlert(MsgResult, obj.lErrorG)
        End If
    End Sub
    Sub desabilitar()
        Me.TxtIdPr.Enabled = False
        Me.Txt_nomPro.Enabled = False
        Me.Txt_FecPro.Enabled = False
        Me.Txt_ValPro.Enabled = False
    End Sub

    Protected Sub Btn_Adjudicar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.MsgResult.Text = obj.Adjudicar(Me.DetPContrato1.CodigoPContrato, TxtIdPr.Text, CDate(TxtFecAdj.Text), TxtObservaciones.Text)
        'Me.GridView1.DataBind()
        'Me.MsgBox(MsgResult, obj.lErrorG)
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.TxtFecAdj.Text = ""
        Me.TxtObservaciones.Text = ""
        MsgResult.Text = ""
        MsgResult.CssClass = ""
    End Sub
    Protected Sub DetPContrato1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetPContrato1.AceptarClicked
        MsgResult.Text = ""
        MsgResult.CssClass = ""
        If Me.DetPContrato1.Encontrado = True And Me.DetPContrato1.Tramite = False Then
            MsgResult.Text = "El Proceso ha finalizado su TRAMITE y no puede ser modificado"
            MsgBoxAlert(MsgResult, True)
            Me.IbAdjudicar.Enabled = False
            Me.GridView1.Enabled = False
        ElseIf Me.DetPContrato1.Encontrado = False Then
            MsgResult.Text = "No se encontró el Proceso"
            MsgBoxAlert(MsgResult, True)
        Else
            Me.IbAdjudicar.Enabled = True
            Me.GridView1.Enabled = True
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CvFecha.ValueToCompare = Today
            Me.DetPContrato1.CodigoPContrato = Request("Num_Proc")
            Me.DetPContrato1.Grupo = Request("Grupo")
            Me.DetPContrato1.Buscar(Request("Grupo"))
        End If
    End Sub

    Protected Sub IBtnProp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnProp.Click
        IrAProponentes()
    End Sub

    Sub IrDatosC()
        Redireccionar_Pagina("/Procesos/GProcesosN/GProcesosN.aspx?Num_Proc=" + Me.DetPContrato1.CodigoPContrato + "&Grupo=" + Me.DetPContrato1.Grupo)
    End Sub

    Sub IrAProponentes()
        Redireccionar_Pagina("/Procesos/GPProponentes/GPProponentes.aspx?Num_Proc=" + Me.DetPContrato1.CodigoPContrato + "&Grupo=" + Me.DetPContrato1.Grupo)
    End Sub

    Protected Sub IBtnDatosContrato_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnDatosContrato.Click
        IrDatosC()
    End Sub
End Class
