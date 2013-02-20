Imports System.Data
Partial Class Contratos_GesContratos_Default
    Inherits PaginaComun

    Private Property Total As Decimal
        Set(ByVal value As Decimal)
            ViewState("Total") = value
        End Set
        Get
            Return ViewState("Total")
        End Get
    End Property

    Private Property TCan As Integer
        Set(ByVal value As Integer)
            ViewState("Can") = value
        End Set
        Get
            Return ViewState("Can")
        End Get
    End Property

    Sub Guardar()
        Dim obj As New AnuContratos()
        If Me.Oper = "Nuevo" Then

            MsgResult.Text = obj.Insert(DetContrato1.Cod_Con, DetContrato1.Estado, CboEstSig.SelectedValue, CDate(txtFecDoc.Text), txtObs.Text)
            Me.MsgBox(MsgResult, obj.lErrorG)
            If obj.lErrorG = False Then
                Limpiar()
                Habilitar(False)
                BtnNuevo.Enabled = True
            End If
        ElseIf Me.Oper = "Editar" Then
            MsgResult.Text = obj.Update(Pk1, CDate(txtFecDoc.Text), txtObs.Text)
            Me.MsgBox(MsgResult, obj.lErrorG)
            If obj.lErrorG = False Then
                Limpiar()
                Habilitar(False)
                BtnNuevo.Enabled = True
            End If
        End If
        DetContrato1.Buscar()
        grdEstContratos.DataBind()
    End Sub
    Protected Sub DetContrato1_AceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContrato1.AceptarClicked

        If DetContrato1.Encontrado = True Then
            Panel1.Visible = True
            Panel1.Enabled = True
            Limpiar()
            Habilitar(False)
            BtnNuevo.Enabled = True
            lbTotalPorPagar.Text = FormatCurrency(DetContrato1.Valor_Total_Prop)
        Else
            Panel1.Enabled = True
            Panel1.Visible = False
            Limpiar()
            Habilitar(False)
        End If
        grdEstContratos.DataBind()
        CboEstSig.DataBind()

        'If CboEstSig.Items.Count = 0 Then
        Limpiar()
        
        Dim isAnulable As Boolean = False

        If DetContrato1.Estado = "00" Then
            Me.MsgResult.Text = "El Contrato No se ha Legalizado, puede realizar la Anulación, especifique el soporte de la misma."
            isAnulable = True
            grdEstContratos.Enabled = True
        ElseIf DetContrato1.Estado = "07" Then
            Me.MsgResult.Text = "El Contrato Fue Anulado."
            grdEstContratos.Enabled = True
        ElseIf DetContrato1.Estado = "09" Then
            Me.MsgResult.Text = "El Contrato ya fue legalizado, No se puede Anular."
            grdEstContratos.Enabled = False
        Else
            Me.MsgResult.Text = "El Contrato se encuentra en ejecución No se puede Anular."

            grdEstContratos.Enabled = False
        End If
        Habilitar(False)
        BtnNuevo.Enabled = isAnulable
        If isAnulable Then
            MsgBoxAlert(MsgResult, True)
        Else
            MsgBox(MsgResult, True)
        End If



    End Sub

    Protected Sub grdEstContratos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEstContratos.RowCommand

        Me.Oper = e.CommandName

        If Me.Oper = "Anular" Then

            Dim Obj As AnuContratos = New AnuContratos()
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.grdEstContratos.SelectedIndex = index

            Me.MsgResult.Visible = True
            Me.MsgResult.Text = Obj.Anular(Me.grdEstContratos.SelectedValue)
            Me.MsgBox(MsgResult, Obj.lErrorG)

            If Obj.lErrorG = False Then
                Limpiar()
                BtnNuevo.Enabled = True
            End If
            DetContrato1.Buscar()
            grdEstContratos.DataBind()
            CboEstSig.DataBind()
            Me.grdEstContratos.DataBind()

        ElseIf Me.Oper = "Editar" Then
            Dim Obj As AnuContratos = New AnuContratos()
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.grdEstContratos.SelectedIndex = index

            Dim dt As DataTable = Obj.GetbyPk(Me.grdEstContratos.SelectedValue)
            If dt.Rows.Count > 0 Then
                MsgResult.Text = "Editando Registro"
                MsgBoxInfo(MsgResult, False)
                Me.CboEstSig.Visible = False
                Me.LbEst.Visible = True
                Me.LbEst.Text = dt.Rows(0)("ESTado_FINAL").ToString
                txtFecDoc.Text = CDate(dt.Rows(0)("FECHA").ToString).ToShortDateString
                txtObs.Text = dt.Rows(0)("OBSERVACION").ToString

                Me.Pk1 = dt.Rows(0)("ID").ToString
                Habilitar(True)
                BtnNuevo.Enabled = False
                BtnGuardar.Enabled = True
            Else
                MsgResult.Text = "No se encuentra el registro"
                MsgBoxAlert(MsgResult, True)
            End If

        End If

    End Sub

    Protected Sub grdEstContratos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEstContratos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If

    End Sub
   
    

    Sub Limpiar()
 
        Me.txtFecDoc.Text = Today.ToShortDateString
        Me.txtObs.Text = "."
        MsgBoxLimpiar(MsgResult)
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
        txtFecDoc.Enabled = v
        txtObs.Enabled = v
        CboEstSig.Enabled = v

        BtnNuevo.Enabled = v
        BtnGuardar.Enabled = v
        BtnCancelar.Enabled = v

        If Not v Then
            BtnGuardar.CssClass = "disabledImageButton"
            BtnCancelar.CssClass = "disabledImageButton"
        Else
            BtnGuardar.CssClass = ""
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
        Me.MsgBoxLimpiar(MsgResult)
        Me.Habilitar(False)
        Me.BtnNuevo.Enabled = True
    End Sub

    Sub Nuevo()
        Limpiar()
        MsgResult.Text = " Agregando Nueva Acta"
        MsgBoxInfo(MsgResult, False)
        Habilitar(True)
        LbEst.Visible = False
        BtnNuevo.Enabled = False
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        Me.Oper = "Nuevo"
        Me.CboEstSig.Visible = True
    End Sub

    Protected Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNuevo.Click
        Nuevo()
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardar.Click
        Guardar()
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
        'Me.TxtValPago.Enabled = valor
        'Me.TxtNVisitas.Enabled = valor
        'Me.TxtPorFis.Enabled = valor
    End Sub


End Class
