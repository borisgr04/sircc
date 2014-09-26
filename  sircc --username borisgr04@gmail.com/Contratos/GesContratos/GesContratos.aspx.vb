Imports System.Data
Partial Class Contratos_GesContratos_Default
    Inherits PaginaComun

    Private Property Val_App_Pro As Decimal
        Set(ByVal value As Decimal)
            ViewState("Val_App_Pro") = value
        End Set
        Get
            Return ViewState("Val_App_Pro")
        End Get
    End Property
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
        Dim obj As New CtrGesContratos
        If Me.Oper = "Nuevo" Then
            obj.Insert(TxtCodCon.Text, hdEstado.Value, CboEstSig.SelectedValue, CDate(txtFecDoc.Text), "", txtObs.Text, Publico.PuntoPorComa(Me.TxtValPago.Text), TxtNVisitas.Text, Publico.PuntoPorComa(TxtPorFis.Text))
        ElseIf Me.Oper = "Editar" Then
            obj.Update(Pk1, CDate(txtFecDoc.Text), txtObs.Text, Publico.PuntoPorComa(Me.TxtValPago.Text), TxtNVisitas.Text, Publico.PuntoPorComa(TxtPorFis.Text))
        End If
        MsgResult.Text = obj.Msg
        Me.MsgBox(MsgResult, obj.lErrorG)
        If obj.lErrorG = False Then
            Limpiar()
            Habilitar(False)
            BtnNuevo.Enabled = True
            Buscar()
            grdEstContratos.DataBind()
        End If
       
       
    End Sub
    Protected Sub Buscar()
        Dim c As New Contratos
        Dim dt As DataTable = c.GetByPk(TxtCodCon.Text)
        DtPCon.DataSource = dt
        DtPCon.DataBind()
        If dt.Rows.Count > 0 Then
            Panel1.Visible = True
            Limpiar()
            Habilitar(False)
            BtnNuevo.Enabled = True
            Val_App_Pro = dt.Rows(0).Item("Valor_Total_Prop").ToString
            lbTotalPorPagar.Text = FormatCurrency(Val_App_Pro)
            hdEstado.Value = dt.Rows(0)("Est_Con")
        Else
            hdEstado.Value = ""
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

        If hdEstado.Value = "00" Then
            Me.MsgResult.Text = "El Contrato No se ha Legalizado."
            sw = False
        ElseIf hdEstado.Value = "07" Then
            Me.MsgResult.Text = "El Contrato Fue Anulado."
            sw = False
        Else
            sw = True
        End If

        Dim cg As New CtrGesContratos
        If Not cg.TieneInterventor(TxtCodCon.Text) Then
            Me.MsgResult.Text = cg.Msg
            MsgBoxAlert(MsgResult, True)
            sw = False
        End If

        If sw = False Then
            Panel1.Enabled = False
            Habilitar(False)
        End If

    End Sub

    Protected Sub grdEstContratos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEstContratos.RowCommand
        Dim Obj As New CtrGesContratos
        Me.Oper = e.CommandName

        If Me.Oper = "Anular" Then


            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.grdEstContratos.SelectedIndex = index

            Me.MsgResult.Visible = True
            Me.MsgResult.Text = Obj.Anular(Me.grdEstContratos.SelectedValue)
            Me.MsgBox(MsgResult, Obj.lErrorG)

            If Obj.lErrorG = False Then
                Limpiar()
            End If
            Buscar()
            grdEstContratos.DataBind()
            Me.grdEstContratos.DataBind()

        ElseIf Me.Oper = "Editar" Then

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

                lbTotalPorPagar.Text = FormatCurrency(Val_App_Pro - Me.Total)
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
            TxtCodCon.Text = Request("CodCon")
            Habilitar(False)
            Habilitar2(False)
            Limpiar()
            If TxtCodCon.Text <> "" Then
                Buscar()
            End If

            
        End If

    End Sub

    Protected Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
       
        Nuevo()
    End Sub


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


    Protected Sub TxtCodCon_TextChanged(sender As Object, e As System.EventArgs) Handles TxtCodCon.TextChanged
        Buscar()
    End Sub


    Protected Sub BtnGuardar_Click(sender As Object, e As System.EventArgs) Handles BtnGuardar.Click
        Guardar()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnBuscar_Click(sender As Object, e As System.EventArgs) Handles BtnBuscar.Click
        Buscar()
    End Sub
End Class
