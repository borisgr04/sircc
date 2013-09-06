Imports System.Data
Partial Class Dependencias_Dependencias
    Inherits PaginaComun

    Dim Obj As Dependencias = New Dependencias
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Me.MultiView1.ActiveViewIndex = 1

        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
            Case "Exportar"
                ExportGridView(GridView1, "Dependencias-SIRCC")
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."

                Me.Habilitar(True)
                Limpiar()

                'Me.ModalPopupTer.Show()
                Me.MultiView1.ActiveViewIndex = 1
                'Me.TxtCodNew.ReadOnly = True
                'Me.SetFocus(Me.TxtCod.Text)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)

                Me.GridView1.SelectedIndex = index
                Dim tb As DataTable = Obj.GetbyPK(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then

                    Me.TxtCod.Text = tb.Rows(0)("COD_DEP").ToString
                    Me.TxtNom.Text = tb.Rows(0)("NOM_DEP").ToString
                    Me.CboDel.SelectedValue = tb.Rows(0)("DEP_DEL").ToString
                    Me.TxtAbr.Text = tb.Rows(0)("DEP_ABR").ToString
                    Me.TxtIde.Text = tb.Rows(0)("ide_ter").ToString
                    Me.TxtNomTer.Text = tb.Rows(0)("nom_ter").ToString
                    Me.TxtNorma.Text = tb.Rows(0)("norma_del").ToString
                    Me.CboEst.Text = tb.Rows(0)("Estado").ToString
                    Me.TxtEmail.Text = tb.Rows(0)("Email").ToString
                    Me.TxtCargo.Text = tb.Rows(0)("cargo_enc").ToString
                    Me.CboIntPrc.SelectedValue = tb.Rows(0)("int_pro").ToString
                    Me.Pk1 = tb.Rows(0)("COD_DEP").ToString
                    Habilitar(True)

                End If
                ''Me.ModalPopupTer.Show()
                MultiView1.ActiveViewIndex = 1
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtCod.Text + "]"

            Case "Eliminar"
                Me.SubT.Text = "Eliminar..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)

                Me.GridView1.SelectedIndex = index
                Dim tb As DataTable = Obj.GetbyPK(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then

                    Me.TxtCod.Text = tb.Rows(0)("COD_DEP").ToString
                    Me.TxtNom.Text = tb.Rows(0)("NOM_DEP").ToString
                    Me.CboDel.SelectedValue = tb.Rows(0)("DEP_DEL").ToString
                    Me.TxtAbr.Text = tb.Rows(0)("DEP_ABR").ToString
                    Me.TxtIde.Text = tb.Rows(0)("ide_ter").ToString
                    Me.TxtNomTer.Text = tb.Rows(0)("nom_ter").ToString
                    Me.TxtNorma.Text = tb.Rows(0)("norma_del").ToString
                    Me.CboEst.Text = tb.Rows(0)("Estado").ToString
                    Me.TxtEmail.Text = tb.Rows(0)("Email").ToString
                    Me.TxtCargo.Text = tb.Rows(0)("cargo_enc").ToString
                    Me.Pk1 = tb.Rows(0)("COD_DEP").ToString
                    Me.CboIntPrc.SelectedValue = tb.Rows(0)("int_pro").ToString
                    Habilitar(False)

                End If
                ''Me.ModalPopupTer.Show()
                MultiView1.ActiveViewIndex = 1
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtCod.Text + "]"

            Case "encargado"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)

                Me.GridView1.SelectedIndex = index
                'Dim tb As DataTable = Obj.GetbyPK(GridView1.SelectedValue)
                'If tb.Rows.Count > 0 Then
                'Me.ModalPopup.Show()
                'End If

                MultiView1.ActiveViewIndex = 1

            Case Else
                MultiView1.ActiveViewIndex = 0


        End Select



    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

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

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case Me.Oper
            Case "Nuevo"
                Me.MsgResult.Text = Obj.Insert(Me.TxtCod.Text, Me.TxtNom.Text, Me.CboDel.SelectedValue, Me.TxtAbr.Text, Me.TxtIde.Text, Me.TxtNorma.Text, Me.TxtEmail.Text, Me.TxtCargo.Text, CboEst.SelectedValue, CboIntPrc.SelectedValue)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.Pk1, Me.TxtCod.Text, Me.TxtNom.Text, Me.CboDel.SelectedValue, Me.TxtAbr.Text, Me.TxtIde.Text, Me.TxtNorma.Text, Me.TxtEmail.Text, Me.TxtCargo.Text, CboEst.SelectedValue, CboIntPrc.SelectedValue)
        End Select
        FillCustomerInGrid()
        Me.MsgBox(MsgResult, Obj.lErrorG)
        If Obj.lErrorG = False Then
            'Me.Limpiar()
        End If
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.MultiView1.ActiveViewIndex = 0
        MsgBoxLimpiar(MsgResult)
    End Sub

    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Me.MsgResult.Text = Obj.Delete(Me.TxtCod.Text)
        FillCustomerInGrid()
        Me.MsgBox(MsgResult, Obj.lErrorG)
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If
    End Sub

    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtCod.Enabled = b
        Me.TxtNom.Enabled = b
        Me.CboDel.Enabled = b
        Me.TxtAbr.Enabled = b
        Me.TxtNomTer.Enabled = False
        Me.TxtIde.Enabled = b
        Me.TxtEmail.Enabled = b
        Me.CboEst.Enabled = b
        Me.BtnGuardar.Enabled = b
        Me.BtnEliminar.Enabled = Not b
    End Sub

    Protected Sub Limpiar()
        Me.TxtCod.Text = ""
        Me.TxtNom.Text = ""
        Me.TxtAbr.Text = ""
        Me.TxtIde.Text = ""
        Me.TxtNomTer.Text = ""
        Me.TxtNorma.Text = ""
        Me.TxtEmail.Text = ""
        Me.CboDel.SelectedIndex = 0
        'Me.MultiView1.ActiveViewIndex = -1
    End Sub
    Private Sub FillCustomerInGrid()
        Me.GridView1.DataBind()
    End Sub


    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.ModalPopup.Show()
    End Sub
End Class
''' <summary>
''' losstfocus
''' </summary>
''' <remarks></remarks>
Public Class MyTextBox
    Inherits TextBox
    Implements IPostBackEventHandler

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        If Not Page.ClientScript.IsClientScriptBlockRegistered("OnBlurTextBoxEvent") Then
            Page.ClientScript.RegisterStartupScript(MyBase.GetType, "OnBlurTextBoxEvent", GetScript, True)
            Attributes.Add("onblur", "OnBlurred('" & UniqueID & "','')")
        End If
    End Sub

    Public Delegate Sub OnBlurDelegate(ByVal sender As Object, ByVal e As EventArgs)

    Public Event Blur As OnBlurDelegate

    Protected Sub OnBlur()
        RaiseEvent Blur(Me, EventArgs.Empty)
    End Sub

    Private Function GetScript() As String
        Return "function OnBlurred(control, arg)" & vbCrLf & _
                "{" & vbCrLf & _
                "    __doPostBack(control, arg);" & vbCrLf & _
                "}"
    End Function

    Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements System.Web.UI.IPostBackEventHandler.RaisePostBackEvent
        OnBlur()
    End Sub
End Class