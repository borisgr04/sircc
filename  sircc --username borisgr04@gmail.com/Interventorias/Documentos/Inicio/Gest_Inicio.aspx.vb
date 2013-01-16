Imports System.Data
Partial Class Contratos_GesContratos_Default
    Inherits PaginaComun

    Protected Sub DetContrato1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContratoI1.AceptarClicked

        If DetContratoI1.Encontrado = True Then
            Panel1.Visible = True
            Limpiar()
            Habilitar(False)
            BtnNuevo.Enabled = True
            If (DetContratoI1.dtContratos.Rows(0)("Est_Con") <> "00") Or (DetContratoI1.dtContratos.Rows(0)("Est_Con") <> "07") Then
                Panel1.Visible = False
                Limpiar()
                Habilitar(False)
                MsgResult.Text = "El Contrato esta en estado " + DetContratoI1.dtContratos.Rows(0)("Estado") + ", no puede realizarse ninguna operación."
                MsgBoxAlert(MsgResult, True)
            End If
        Else
            Panel1.Visible = False
            Limpiar()
            Habilitar(False)
        End If
        CboEstSig.DataBind()
    End Sub

    Protected Sub grdEstContratos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEstContratos.RowCommand

        Me.Oper = e.CommandName

        If Me.Oper = "Anular" Then

            Dim Obj As EstContratos = New EstContratos()
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.grdEstContratos.SelectedIndex = index
            

            Me.MsgResult.Visible = True
            Me.MsgResult.Text = Obj.Anular(Me.grdEstContratos.SelectedValue)
            Me.MsgBox(MsgResult, Obj.lErrorG)

            DetContratoI1.Buscar()
            grdEstContratos.DataBind()
            Me.grdEstContratos.DataBind()

        ElseIf Me.Oper = "Editar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.grdEstContratos.SelectedIndex = index


            Me.NoID = Me.grdEstContratos.SelectedValue
            Me.OperS = "Editar"
            Me.CodCon = DetContratoI1.Cod_Con

            Redireccionar_Pagina("/Interventorias/Documentos/AsigAntInv/AsigAntInv.aspx")

        End If

    End Sub

    Sub Limpiar()
        '    MsgBoxLimpiar(MsgResult)
        LbEst.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Limpiar()
            Habilitar(False)
            Habilitar2(False)

        End If

    End Sub

    Protected Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click

        Nuevo()
    End Sub

    Sub Habilitar(ByVal v As Boolean)
    
        BtnNuevo.Enabled = v
        BtnCancelar.Enabled = v

        If Not v Then

            BtnCancelar.CssClass = "disabledImageButton"
        Else

            BtnCancelar.CssClass = ""
        End If

        If CboEstSig.SelectedValue = "01" Then
            Habilitar2(False)
        End If


    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click

        Cancelar()
    End Sub

    Sub Cancelar()
        Me.Oper = ""
        Me.Limpiar()
        Me.Habilitar(False)
        Me.BtnNuevo.Enabled = True
    End Sub

    Sub Nuevo()
        
        Me.OperS = "Nuevo"

        If Me.CboEstSig.SelectedValue.ToString() = "08" Then
            Me.CodCon = DetContratoI1.Cod_Con
            Redireccionar_Pagina("/Interventorias/Documentos/AsigAntInv/AsigAntInv.aspx")
        End If

    End Sub

    Protected Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNuevo.Click
        Nuevo()

    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub CboEstSig_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboEstSig.SelectedIndexChanged

        If CboEstSig.SelectedValue = "01" Then
            Habilitar2(False)
        Else
            Habilitar2(True)
        End If

    End Sub


    Public Sub Habilitar2(ByVal valor As Boolean)
    End Sub



    Protected Sub grdEstContratos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEstContratos.SelectedIndexChanged

    End Sub
End Class
