Imports System.Data
Imports System.Web.Services
Imports System.Web.Script.Services

Partial Class DatosBasicos_Proyectos_Default
    Inherits PaginaComun

    Dim Obj As New Proyectos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            FillCustomerInGrid()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
        If GridView1.Rows.Count = 0 Then
            IbtnNuevo.Visible = True
        Else
            IbtnNuevo.Visible = False
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."

                Me.Habilitar(True)
                Limpiar()

                MostrarEdicion()

                Me.SetFocus(Me.CmbVigP)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetbyPk(GridView1.DataKeys(index).Values(0).ToString())
                If tb.Rows.Count > 0 Then
                    Me.CmbVigP.Text = tb.Rows(0)("Vigencia").ToString
                    Me.txt_proy.Text = tb.Rows(0)("Proyecto").ToString
                    Me.txtNomProy.Text = tb.Rows(0)("Nombre_Proyecto").ToString
                    Me.Txt_Fec_Rad.Text = CDate(tb.Rows(0)("Fecha_Rad").ToString).ToShortDateString()
                    Me.Txt_comite.Text = tb.Rows(0)("Comite").ToString
                    Me.TxtValTot.Text = tb.Rows(0)("Valor").ToString
                    Me.TxtValProp.Text = tb.Rows(0)("APORTES_PROPIOS").ToString
                    Me.TxtValOtros.Text = (tb.Rows(0)("Valor") - tb.Rows(0)("APORTES_PROPIOS"))
                    Me.Cmb_Estado.Text = tb.Rows(0)("Estado").ToString
                    Me.Pk1 = tb.Rows(0)("Proyecto").ToString
                    Me.TxtIdeTer.Text = tb.Rows(0)("Ide_Aportante").ToString
                    Habilitar(True)
                    MostrarEdicion()
                End If

                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.CmbVigP.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                'Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Dim tb As DataTable = Obj.GetbyPk(GridView1.DataKeys(index).Values(0).ToString())
                If tb.Rows.Count > 0 Then
                    Me.CmbVigP.Text = tb.Rows(0)("Vigencia").ToString
                    Me.txt_proy.Text = tb.Rows(0)("Proyecto").ToString
                    Me.txtNomProy.Text = tb.Rows(0)("Nombre_Proyecto").ToString
                    Me.Txt_Fec_Rad.Text = tb.Rows(0)("Fecha_Rad").ToString
                    Me.Txt_comite.Text = tb.Rows(0)("Comite").ToString
                    Me.TxtValTot.Text = tb.Rows(0)("Valor").ToString
                    Me.TxtValProp.Text = tb.Rows(0)("APORTES_PROPIOS").ToString

                    Me.TxtValOtros.Text = (tb.Rows(0)("Valor") - tb.Rows(0)("APORTES_PROPIOS"))
                    Me.Cmb_Estado.Text = tb.Rows(0)("Estado").ToString
                    Me.TxtIdeTer.Text = tb.Rows(0)("Ide_Aportante").ToString
                    Me.Pk1 = tb.Rows(0)("Proyecto").ToString
                    MostrarEdicion()
                    Habilitar(False)
                End If
                'Me.ModalPopupTer.Show()

            Case "Exportar"
                ExportGridView(GridView1, "Proyectos-SIRCC")
        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.CmbVigP.Enabled = b
        Me.txt_proy.Enabled = b
        Me.txtNomProy.Enabled = b
        Me.Txt_Fec_Rad.Enabled = b
        Me.TxtValTot.Enabled = b
        Me.Txt_comite.Enabled = b
        Me.Cmb_Estado.Enabled = b
        Me.BtnGuardar.Enabled = b
        Me.BtnEliminar.Enabled = Not b
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        FillCustomerInGrid()
    End Sub
    Private Sub FillCustomerInGrid()
        Me.GridView1.DataBind()

    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Select Case Me.Oper
            Case "Nuevo"
                Me.MsgResult.Text = Obj.Insert(Me.CmbVigP.Text, Me.txt_proy.Text, Me.txtNomProy.Text, Me.Txt_Fec_Rad.Text, Me.Txt_comite.Text, Me.TxtValTot.Text, Cmb_Estado.SelectedValue, Me.TxtIdeTer.Text, cboTipPro.SelectedValue, TxtValProp.Text)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Pk1, Me.CmbVigP.Text, Me.txt_proy.Text, Me.txtNomProy.Text, Me.Txt_Fec_Rad.Text, Me.Txt_comite.Text, Me.TxtValTot.Text, Cmb_Estado.SelectedValue, Me.TxtIdeTer.Text, cboTipPro.SelectedValue, TxtValProp.Text)
        End Select
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()

    End Sub

    Protected Sub Limpiar()

        Me.txt_proy.Text = ""
        Me.Txt_Fec_Rad.Text = ""
        Me.TxtValTot.Text = 0
        Me.TxtValProp.Text = 0
        Me.TxtValOtros.Text = 0
        Me.Txt_comite.Text = ""


        'Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub

    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Delete(Me.txt_proy.Text)
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
    End Sub

    Protected Sub GridView1_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If

    End Sub

    Protected Sub IbtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnNuevo.Click
        Me.SubT.Text = "Nuevo..."
        Me.Oper = "Nuevo"
        'Me.ModalPopupTer.Show()
        MultiView1.ActiveViewIndex = 1
        Me.Habilitar(True)
        Limpiar()
        'Me.TxtCodNew.ReadOnly = True
        Me.SetFocus(Me.CmbVigP)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles BtnBuscar.Click
        Dim p As New Proyectos()
        GridView1.DataSource = p.GetProyectos(CmbVig.SelectedValue, TxtBuscar.Text)
        GridView1.DataBind()

    End Sub

    Private Sub MostrarEdicion()
        MultiView1.ActiveViewIndex = 1
    End Sub

    Private Sub MostrarConsulta()
        MultiView1.ActiveViewIndex = 0
        MsgBoxLimpiar(Me.MsgResult)
    End Sub

    Protected Sub BtnVolver_Click(sender As Object, e As System.EventArgs) Handles BtnVolver.Click
        MostrarConsulta()
    End Sub

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Shared Function GetTercerosPk(ide_ter As String) As String
        Dim t As New Terceros
        Dim tb As DataTable = t.GetByIde(ide_ter)
        Return If(tb.Rows.Count = 0, "0", tb.Rows(0)("Nom_Ter"))
    End Function
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
End Class
