Imports System.Data
Partial Class DependenciasD_DependenciasD
    Inherits PaginaComun

    Dim Obj As Dependencias = New Dependencias
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Me.MultiView1.ActiveViewIndex = 1
        Me.Oper = e.CommandName
        Select Case Me.Oper
            Case "Exportar"
                GridView2.DataSource = Obj.GetRecordsDB
                GridView2.DataBind()
                ExportGridView(GridView2, "Aseguradoras-SIRCC")
            Case "nuevo"
                Me.SubT.Text = "Nuevo..."
                Me.Habilitar(True)
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.Pk1 = GridView1.SelectedValue
                Limpiar()
                Me.MultiView1.ActiveViewIndex = 1
            Case Else
                MultiView1.ActiveViewIndex = 0
        End Select
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            'Me.Tit.Text += e.Row.Cells(0).Text
            If e.Row.Cells(0).Text = "00" Then
                e.Row.Cells(6).Controls.Clear()
                e.Row.Cells(7).Controls.Clear()
            End If
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        MsgBoxLimpiar(MsgResult)
    End Sub



    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.MultiView1.ActiveViewIndex = 0
        End If

    End Sub

    Protected Sub Asignar()
        Select Case Me.Oper
            Case "nuevo"
                Me.MsgResult.Text = Obj.AsignarAbogado(Me.Pk1, Me.TxtIde.Text, Util.invSI_NO(Me.ChkAsigProc.Checked), Util.invSI_NO(Me.ChkCord.Checked))
            Case "editar"
                Me.MsgResult.Text = Obj.Update(Me.Pk1, Util.invSI_NO(Me.ChkAsigProc.Checked), Util.invSI_NO(Me.ChkCord.Checked))
        End Select
        FillCustomerInGrid()
        Me.MsgBox(MsgResult, Obj.lErrorG)
        If Obj.lErrorG = False Then
            'Me.Limpiar()
        End If
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.MultiView1.ActiveViewIndex = 0
        Limpiar()
    End Sub



    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtNomTer.Enabled = False
        Me.TxtIde.Enabled = b
        Me.BtnAsignar.Enabled = b
        Me.ChkAsigProc.Enabled = b
    End Sub

    Protected Sub Limpiar()
        Me.TxtIde.Text = ""
        Me.TxtNomTer.Text = ""
        MsgBoxLimpiar(MsgResult)
    End Sub
    Private Sub FillCustomerInGrid()
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
    End Sub


    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.ModalPopup.Show()
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            If e.Row.Cells(4).Text = "IN" Then
                e.Row.Cells(1).Text = "<i>" & e.Row.Cells(1).Text & "</i>"
                e.Row.Cells(8).Controls.Clear()
                e.Row.Cells(9).Controls.Clear()
            End If
        End If
    End Sub

    Protected Sub BtnAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAsignar.Click
        Asignar()
    End Sub
    Protected Sub Retirar_Vin(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ibtnret As ImageButton = DirectCast(sender, ImageButton)
        Me.MsgResult.Text = Obj.DAsignarAbogado(ibtnret.CommandArgument)
        MsgBox(MsgResult, Obj.lErrorG)
        Me.FillCustomerInGrid()
    End Sub
    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        Me.Oper = e.CommandName
        If e.CommandName = "retirar" Then
            'Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            'Me.GridView2.SelectedIndex = index
            'Me.MsgResult.Text = Obj.DAsignarAbogado(Me.GridView2.SelectedValue)
            'MsgBox(MsgResult, Obj.lErrorG)
            'Me.FillCustomerInGrid()
        End If
        If e.CommandName = "editar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.GridView2.SelectedIndex = index
            Dim dt As DataTable = Obj.GetVinculado(Me.GridView2.SelectedValue)
            If dt.Rows.Count > 0 Then
                Me.TxtIde.Text = dt.Rows(0)("IDE_TER").ToString
                Me.TxtNomTer.Text = dt.Rows(0)("NOM_TER").ToString
                Me.ChkAsigProc.Checked = Util.SI_NO(dt.Rows(0)("ASIG_PROC").ToString)
                Me.ChkCord.Checked = Util.SI_NO(dt.Rows(0)("Coordinador").ToString)
                Me.Pk1 = Me.GridView2.SelectedValue
            End If
            Me.Habilitar(False)
            Me.BtnAsignar.Enabled = True
            Me.ChkAsigProc.Enabled = True
            'Me.ModalPopupTer.Show()
            Me.MultiView1.ActiveViewIndex = 1
        End If


    End Sub

    Protected Sub TxtIde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIde.TextChanged
        Dim obj As New Terceros
        Dim dt As DataTable = obj.GetByIde(Me.TxtIde.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNomTer.Text = dt.Rows(0)("Nom_Ter").ToString
        End If

    End Sub

    Private Sub Retirar()
       
    End Sub

    
End Class
