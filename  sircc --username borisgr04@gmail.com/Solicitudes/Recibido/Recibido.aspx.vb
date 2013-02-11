Imports System.Data

Partial Class Solicitudes_Recibido_Default
    Inherits PaginaComun
    Dim obj As New PSolicitudes

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Select Case e.CommandName
            Case "recibir"
                MsgBoxLimpiar(MsgResult)
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                GridView1.SelectedIndex = index
                Dim dt As DataTable = obj.GetByPk(GridView1.DataKeys(index).Values(0).ToString())
                If dt.Rows(0).Item("Recibido").ToString = "S" Then
                    Me.TxtObservaciones.Text = dt.Rows(0).Item("Observacion_Recibido").ToString
                    habilitar(False)
                    Me.ModalPopupExtender3.Show()
                Else
                    limpiar()
                    habilitar(True)
                    Me.ModalPopupExtender3.Show()
                End If
            Case "modificar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                GridView1.SelectedIndex = index
                Dim Cod_Sol As String = GridView1.DataKeys(index).Values(0).ToString()
                querystringSeguro = Me.SetRequest()
                querystringSeguro("Cod_Sol") = Cod_Sol
                'Redireccionar_Pagina("/Solicitudes/ModSolicitud/ModSolicitud.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                Redireccionar_Pagina("/Solicitudes/ModSolicitud/ModSolicitud.aspx?Cod_Sol=" + Cod_Sol)
            Case "revisar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                GridView1.SelectedIndex = index
                Dim Cod_Sol As String = GridView1.DataKeys(index).Values(0).ToString()
                'querystringSeguro = Me.SetRequest()
                'querystringSeguro("Cod_Sol") = Cod_Sol
                'Redireccionar_Pagina("/Solicitudes/ReporteRevision/ReporteRevision.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                Redireccionar_Pagina("/Solicitudes/ReporteRevision/ReporteRevision.aspx?Cod_Sol=" + Cod_Sol)

        End Select

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

    Sub desabilitar()
        Me.TxtObservaciones.Enabled = False
        Btn_Recibir.Enabled = False
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        MsgBoxLimpiar(MsgResult)
        Dim dt As DataTable = obj.GetByPk(Me.GridView1.SelectedDataKey.Value.ToString)
        If dt.Rows(0).Item("Recibido").ToString = "S" Then
            Me.TxtObservaciones.Text = dt.Rows(0).Item("Observacion_Recibido").ToString
            habilitar(False)
            Me.ModalPopupExtender3.Show()
        Else
            limpiar()
            habilitar(True)
            Me.ModalPopupExtender3.Show()
        End If
    End Sub

    Protected Sub Btn_Recibir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Recibir.Click
        MsgResult.Text = obj.Recibir(Me.GridView1.SelectedDataKey.Value, TxtObservaciones.Text)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        Me.GridView1.DataBind()
        Me.TxtObservaciones.Text = ""

    End Sub
    Sub habilitar(ByVal b As Boolean)
        Me.TxtObservaciones.Enabled = b
        Me.Btn_Recibir.Enabled = b
    End Sub
    Sub limpiar()
        Me.TxtObservaciones.Text = "."
    End Sub

    Protected Sub CboEstRec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboEstRec.SelectedIndexChanged
        If CboEstRec.SelectedValue = "S" Then 'recibidas
            CboConcepto.Visible = True
            LbConcepto.Visible = True
        Else
            CboConcepto.SelectedValue = ""
            CboConcepto.Visible = False
            LbConcepto.Visible = False

        End If
        GridView1.DataBind()

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.TxtDesde.Text = Now.AddMonths(-1).ToShortDateString
            Me.TxtHasta.Text = Now.ToShortDateString
            TxtNSol.Text = Request("Cod_Sol")
            GridView1.DataSource = obj.GetByAbogxFec("N", TxtDesde.Text, TxtHasta.Text, TxtNSol.Text, "P")
            GridView1.DataBind()
            DataBind()
        End If
    End Sub

    Protected Sub CboConcepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboConcepto.SelectedIndexChanged

    End Sub

    Protected Sub RadTabStrip1_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick
        Select Case RadTabStrip1.SelectedIndex
            Case 0
                GridView1.DataSource = obj.GetByAbogxFec("N", TxtDesde.Text, TxtHasta.Text, TxtNSol.Text, "P")
            Case 1
                GridView1.DataSource = obj.GetByAbogxFec("S", TxtDesde.Text, TxtHasta.Text, TxtNSol.Text, "P")
            Case 2
                GridView1.DataSource = obj.GetByAbogxFec("S", TxtDesde.Text, TxtHasta.Text, TxtNSol.Text, "A")
            Case 3
                GridView1.DataSource = obj.GetByAbogxFec("S", TxtDesde.Text, TxtHasta.Text, TxtNSol.Text, "R")
        End Select
        Me.GridView1.DataBind()


    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Select Case RadTabStrip1.SelectedIndex
            Case 0
                GridView1.DataSource = obj.GetByAbogxFec("N", TxtDesde.Text, TxtHasta.Text, TxtNSol.Text, "P")
            Case 1
                GridView1.DataSource = obj.GetByAbogxFec("S", TxtDesde.Text, TxtHasta.Text, TxtNSol.Text, "P")
            Case 2
                GridView1.DataSource = obj.GetByAbogxFec("S", TxtDesde.Text, TxtHasta.Text, TxtNSol.Text, "A")
            Case 3
                GridView1.DataSource = obj.GetByAbogxFec("S", TxtDesde.Text, TxtHasta.Text, TxtNSol.Text, "R")
        End Select
        Me.GridView1.DataBind()
    End Sub

    Private Function DateDiff(ByVal dateInterval As DateInterval, ByVal p2 As String, ByVal p3 As Date) As String
        Throw New NotImplementedException
    End Function

End Class
