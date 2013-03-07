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
        If Me.Oper = "Nuevo" Then
            Dim obj As New EstContratos()
            MsgResult.Text = obj.Insert(DetContrato1.Cod_Con, DetContrato1.Estado, CboEstSig.SelectedValue, CDate(txtFecDoc.Text), "", txtObs.Text, Publico.PuntoPorComa(Me.TxtValPago.Text), TxtNVisitas.Text, Publico.PuntoPorComa(TxtPorFis.Text))
            Me.MsgBox(MsgResult, obj.lErrorG)
            If obj.lErrorG = False Then
                Limpiar()
                Habilitar(False)
                BtnNuevo.Enabled = True
            End If
        ElseIf Me.Oper = "Editar" Then
            Dim obj As New EstContratos()

            MsgResult.Text = obj.Update(Pk1, CDate(txtFecDoc.Text), txtObs.Text, Publico.PuntoPorComa(Me.TxtValPago.Text), TxtNVisitas.Text, Publico.PuntoPorComa(TxtPorFis.Text))
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
        Habilitar(False)
        If CboEstSig.Items.Count = 0 Then
            Panel1.Enabled = False
            BtnNuevo.Enabled = False
            Limpiar()
            MsgBox(MsgResult, True)
        Else
            Panel1.Enabled = True
            BtnNuevo.Enabled = True
            Limpiar()
        End If

        Dim sw As Boolean

        If DetContrato1.Estado = "00" Then
            Me.MsgResult.Text = "El Contrato No se ha Legalizado."
            sw = False
        ElseIf DetContrato1.Estado = "07" Then
            Me.MsgResult.Text = "El Contrato Fue Anulado."
            sw = False
        Else
            sw = True
        End If


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

            If Obj.lErrorG = False Then
                LIMPIAR()
            End If
            DetContrato1.Buscar()
            grdEstContratos.DataBind()
            Me.grdEstContratos.DataBind()

        ElseIf Me.Oper = "Editar" Then
            Dim Obj As EstContratos = New EstContratos()
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
                TxtNVisitas.Text = dt.Rows(0)("NVisitas").ToString
                TxtValPago.Text = dt.Rows(0)("Valor_Pago").ToString.Replace(Publico.Punto_DecOracle, ".")
                TxtPorFis.Text = dt.Rows(0)("por_eje_fis").ToString.Replace(Publico.Punto_DecOracle, ".")
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

        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.Total = 0
                Me.TCan = 0
            Case DataControlRowType.DataRow

                Me.Total += CDec(DataBinder.Eval(e.Row.DataItem, "VALOR_PAGO"))
                'Me.TCan += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(7).Text = FormatCurrency(Me.Total.ToString)
                e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                lbTotalPorPagar.Text = FormatCurrency(CDec(DetContrato1.Valor_Total_Prop) - Me.Total)
                'Valor_Total_Prop
                'e.Row.Cells(5).Text = FormatNumber(Me.TCan.ToString)
                'e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                'e.Row.Font.Bold = True
        End Select
    End Sub
   
    

    Sub Limpiar()
        Me.TxtNVisitas.Text = 0
        Me.TxtValPago.Text = 0
        TxtPorFis.Text = 0
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

    'Sub Nuevo()
    '    Limpiar()
    '    MsgResult.Text = " Agregando Nueva Acta"
    '    MsgBoxInfo(MsgResult, False)
    '    Habilitar(True)
    '    LbEst.Visible = False
    '    BtnNuevo.Enabled = False
    '    BtnAceptar.Enabled = True
    '    BtnCancelar.Enabled = True
    '    Me.Oper = "Nuevo"
    '    Me.CboEstSig.Visible = True
    'End Sub

    Sub Habilitar(ByVal v As Boolean)
        txtFecDoc.Enabled = v
        TxtNVisitas.Enabled = v
        txtObs.Enabled = v
        TxtPorFis.Enabled = v
        TxtValPago.Enabled = v
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
        Me.TxtValPago.Enabled = valor
        Me.TxtNVisitas.Enabled = valor
        Me.TxtPorFis.Enabled = valor
    End Sub


End Class
