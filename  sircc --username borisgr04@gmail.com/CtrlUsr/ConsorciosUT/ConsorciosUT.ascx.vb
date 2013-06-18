Imports System.Data
Partial Class CtrlUsr_ConsorciosUT_ConsorciosUT
    Inherits CtrlUsrComun
    Dim Obj As ConsorciosxC = New ConsorciosxC
    Private Property Total() As Decimal
        Set(ByVal value As Decimal)
            ViewState("Total") = value
        End Set
        Get
            Return ViewState("Total")
        End Get
    End Property
    Property Cod_Con As String
        Set(ByVal value As String)
            ViewState("Cod_Con") = value
            CargarDatos()
        End Set
        Get
            Return ViewState("Cod_Con")
        End Get
    End Property

    Private Property ispConsorcioUT As Boolean
        Set(ByVal value As Boolean)
            ViewState("isConsorcioUT") = value
        End Set
        Get
            Return ViewState("isConsorcioUT")
        End Get
    End Property

    Public Function isConsorcioUT() As Boolean
        Return ispConsorcioUT
    End Function

    Function BuscarCSUT() As Boolean
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIdeCSUT(Me.TxtNitCSUT.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNomCSUT.Text = dt.Rows(0)("Nom_Ter").ToString()
            Me.ispConsorcioUT = True
            Me.MsgResult.Text = ""
            Return True
        Else
            Me.MsgResult.Text = "El Tercero no esta Clasificado como unión Temporal o Consorcio"
            Me.ispConsorcioUT = False
            Return False
        End If

    End Function


    Sub AgregarN()
        Me.MsgResult.Text = Obj.Insert(TxtCodCon.Text, TxtNitCSUT.Text, Me.Txt_Id.Text, Me.CmbEstado.SelectedValue, TxtPp_m.Text)
        Me.GridView1.DataBind()
        Me.MsgBox(MsgResult, Obj.lErrorG)
        UpdatePanel1.Update()
        If Obj.lErrorG = False Then
            'Me.Limpiar()
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Me.Oper = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper
            Case "Editar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetbyUK(TxtNitCSUT.Text, GridView1.DataKeys(index).Values(0).ToString(), TxtCodCon.Text)
                If tb.Rows.Count > 0 Then
                    Me.Txt_Id.Text = tb.Rows(0)("Id_Miembros").ToString
                    Me.Txt_nom.Text = tb.Rows(0)("Nom_Miembro").ToString
                    Me.CmbEstado.Text = tb.Rows(0)("Id_Estado").ToString
                    Me.TxtPp_m.Text = tb.Rows(0)("Porc_Part").ToString
                    Me.Pk1 = tb.Rows(0)("Id_Miembros").ToString
                    Habilitar(True)
                    Me.ModalPopupExtender3.Show()
                End If

                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.Txt_Id.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Pk1 = GridView1.DataKeys(index).Values(0).ToString()
                'Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Dim tb As DataTable = Obj.GetbyUK(TxtNitCSUT.Text, GridView1.DataKeys(index).Values(0).ToString(), TxtCodCon.Text)
                If tb.Rows.Count > 0 Then
                    Me.Txt_Id.Text = tb.Rows(0)("Id_Miembros").ToString
                    Me.Txt_nom.Text = tb.Rows(0)("Nom_Miembro").ToString
                    Me.CmbEstado.Text = tb.Rows(0)("Id_Estado").ToString
                    Me.TxtPp_m.Text = tb.Rows(0)("Porc_Part").ToString
                    Me.Pk1 = tb.Rows(0)("Id_Miembros").ToString
                    Habilitar(False)
                    Me.ModalPopupExtender3.Show()
                End If
                Me.ModalPopupExtender3.Show()
                'MultiView1.ActiveViewIndex = 0
        End Select

    End Sub
    Protected Sub Habilitar(ByVal b As Boolean)
        Me.Txt_Id.Enabled = False
        Me.Txt_nom.Enabled = False
        Me.CmbEstado.Enabled = b
        Me.Btn_Guardar.Enabled = b
        Me.Btn_Eliminar.Enabled = Not b
    End Sub

    Protected Sub Btn_Guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Oper = "nuevo" Then
            AgregarN()
        ElseIf Oper = "Editar" Then
            Me.MsgResult.Text = Obj.Update(TxtNitCSUT.Text, Txt_Id.Text, CmbEstado.SelectedValue, TxtPp_m.Text, TxtCodCon.Text)
            Me.GridView1.DataBind()
            Me.MsgBox(MsgResult, Obj.lErrorG)
            If Obj.lErrorG = False Then
                'Me.Limpiar()
            End If
        End If

    End Sub

    Protected Sub Btn_Eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Delete(TxtNitCSUT.Text, Txt_Id.Text, TxtCodCon.Text)
        Me.GridView1.DataBind()
        Me.MsgBox(MsgResult, Obj.lErrorG)
        If Obj.lErrorG = False Then
            Me.ModalPopupExtender3.Hide()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If

        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.Total = 0
            Case DataControlRowType.DataRow

                Me.Total += CDec(DataBinder.Eval(e.Row.DataItem, "Porc_Part")) / 100
            Case DataControlRowType.Footer
                e.Row.Cells(2).Text = FormatPercent(Me.Total.ToString, 1)
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub



    Protected Sub UpdAdmTerceros1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdAdmTerceros1.SelClicked
        Txt_Id.Text = UpdAdmTerceros1.Nit
        Txt_nom.Text = UpdAdmTerceros1.Nom_Ter
        UpdAdmTerceros1.Ocultar()
        Me.ModalPopupExtender3.Show()
        Oper = "nuevo"
        UpdatePanel1.Update()

    End Sub


    
    Protected Sub IBtnNuevoMiembro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevoMiembro.Click
        AgregarMiembro()
    End Sub

    Sub AgregarMiembro()
        UpdAdmTerceros1.Mostrar()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDatos()
        End If

    End Sub

    Sub CargarDatos()

        Dim ObjC As New Contratos
        Dim dt As DataTable = ObjC.GetByPk(Cod_Con)
        If dt.Rows.Count > 0 Then
            TxtNitCSUT.Text = dt.Rows(0)("Ide_Con")
            If BuscarCSUT() Then
                TxtCodCon.Text = Cod_Con
                'Me.PnlConUT.Visible = True
            Else
                'Me.PnlConUT.Visible = False
            End If

        End If

    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        UpdAdmTerceros1.Mostrar()
    End Sub
End Class

