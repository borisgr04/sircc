Imports System.Data
Partial Class Modificaciones_Recibir_Recibir
    Inherits PaginaComun
    Dim obj As New Sol_Adiciones
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.TxtDesde.Text = Now.AddMonths(-1).ToShortDateString
            Me.TxtHasta.Text = Now.ToShortDateString
            Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Select Case e.CommandName
            Case "recibir"
                MsgBoxLimpiar(MsgResult)
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                GridView1.SelectedIndex = index
                Me.Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                Dim dt As DataTable = obj.GetByPk(Me.Pk1)
                If dt.Rows(0).Item("Recibido").ToString = "S" Then
                    Me.TxtObservaciones.Text = dt.Rows(0).Item("Observacion_Recibido").ToString
                    habilitar(False)
                    Me.ModalPopupsOper.Show()
                Else
                    limpiar()
                    habilitar(True)
                    Me.ModalPopupsOper.Show()
                End If
            Case "modificar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                GridView1.SelectedIndex = index
                Dim Cod_Sol As String = GridView1.DataKeys(index).Values(0).ToString()
                Dim cod_con As String = GridView1.DataKeys(index).Values(1).ToString()
                'Redireccionar_Pagina("/Modificaciones/Modificar/Modificar.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                Redireccionar_Pagina("/Modificaciones/Modificar/Modificar.aspx?Num_Sol_Adi=" + Cod_Sol + "&Cod_Con=" + Cod_Con)
            Case "revisar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                GridView1.SelectedIndex = index
                Dim Cod_Sol As String = GridView1.DataKeys(index).Values(0).ToString()
                Dim cod_con As String = GridView1.DataKeys(index).Values(1).ToString()
                'querystringSeguro("Cod_Con") = GridView1.DataKeys(index).Values(1).ToString()
                'Redireccionar_Pagina("/Modificaciones/Revisar/ReporteRevision.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                Redireccionar_Pagina("/Modificaciones/Revisar/ReporteRevision.aspx?Num_Sol=" + Cod_Sol + "&Cod_Con=" + cod_con)
        End Select
    End Sub
    Sub habilitar(ByVal b As Boolean)
        Me.TxtObservaciones.Enabled = b
        Me.Btn_Recibir.Enabled = b
    End Sub
    Sub limpiar()
        Me.TxtObservaciones.Text = "."
    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        GridView1.DataBind()
    End Sub

    Protected Sub Btn_Recibir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Recibir.Click
        MsgResult.Text = obj.Recibir(Me.GridView1.SelectedDataKey.Value, TxtObservaciones.Text)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        If obj.lErrorG = False Then
            TxtNSol.Text = Pk1
            Me.GridView1.DataBind()
            Me.TxtObservaciones.Text = ""
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub
End Class
