Imports System.Data
Imports System.IO

Partial Class Modificaciones_Mod_Contratos
    Inherits PaginaComun
    Dim obj As Modificaciones = New Modificaciones


    Private Property ID_FP() As String
        Set(ByVal value As String)
            ViewState("ID_FP") = value
        End Set
        Get
            Return ViewState("ID_FP")
        End Get
    End Property
    Private Property IdProp() As String
        Set(ByVal value As String)
            ViewState("IdProp") = value
        End Set
        Get
            Return ViewState("IdProp")
        End Get
    End Property
    Private Property TipAdi() As String
        Set(ByVal value As String)
            ViewState("TipAdi") = value
        End Set
        Get
            Return ViewState("TipAdi")
        End Get
    End Property
    Private Property GuardarFP() As String
        Set(ByVal value As String)
            ViewState("GuardarFP") = value
        End Set
        Get
            Return IIf(String.IsNullOrEmpty(ViewState("GuardarFP")), "Nuevo", ViewState("GuardarFP"))
        End Get
    End Property
    Private Property Num_Proc() As String
        Set(ByVal value As String)
            ViewState("Num_Proc") = value
        End Set
        Get
            Return ViewState("Num_Proc")
        End Get
    End Property
    Private Property TotalFP() As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalFP") = value
        End Set
        Get
            Return ViewState("TotalFP")
        End Get
    End Property

    Private Property TotalPor() As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalPor") = value
        End Set
        Get
            Return ViewState("TotalPor")
        End Get
    End Property

    Private WriteOnly Property ValTot As String
        Set(ByVal value As String)
            Me.TxtValTot.Text = value.ToString.Replace(Publico.Punto_DecOracle, ".")
            LbValTot.Text = FormatCurrency(TxtValTot.Text.Replace(".", ","))
        End Set
    End Property

    Private WriteOnly Property ValOtros As String
        Set(ByVal value As String)
            Me.TxtValOtros.Text = value.ToString.Replace(Publico.Punto_DecOracle, ".")
            'LbValOtros.Text = FormatCurrency(TxtValOtros.Text.Replace(".", ","))
        End Set
    End Property

    Private WriteOnly Property ValProp As String
        Set(ByVal value As String)
            Me.TxtValProp.Text = value.ToString.Replace(Publico.Punto_DecOracle, ".")
            'LbValProp.Text = FormatCurrency(TxtValProp.Text.Replace(".", ","))
        End Set
    End Property
    Public Sub Guardar()
        MsgBoxLimpiar(MsgResult)
        obj = New Modificaciones
        'Me.MsgResult.Text = Me.valor_dec(Me.TxtValTot.Text)
        Select Case Me.Oper
            Case "nuevo"
                'Me.MsgResult.Text = obj.Insert(Me.CboTproc.SelectedValue, Me.TxtNProc.Text, Me.TxtObj.Text, "", Me.TxtNPla.Text, Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, Me.Vigencia.ToString, Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, Publico.PuntoPorComa(Me.TxtValTot.Text), Publico.PuntoPorComa(Me.TxtValProp.Text), Me.CboSec.SelectedValue, Me.CboFor.SelectedValue, Me.TxtNPla.Text, Util.invN1_0(ChkUM.Checked), Util.invN1_0(ChkEC.Checked), "0", Me.TxtLugEje.Text, Me.CboTPlazo.SelectedValue, Util.invN1_0(Me.ChkAgotarPpto.Checked), TxtConsiderandos.Text)
            Case "editar"
                Dim j As String = 0, mun(25) As String
                Dim chk As New CheckBox, txt As New TextBox
                For i = 0 To DataList1.Items.Count - 1
                    chk = DataList1.Items(i).FindControl("chknommun")
                    txt = DataList1.Items(i).FindControl("txtcodmun")
                    If chk.Checked = True Then
                        mun(j) = txt.Text
                        j = j + 1
                    End If
                Next
                Me.MsgResult.Text = obj.Update(Me.Pk1, Me.CboTproc.SelectedValue, Me.TxtObj.Text, "", Me.TxtPlazo.Text, Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, Me.Vigencia.ToString, Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, Publico.PuntoPorComa(Me.TxtValTot.Text), Publico.PuntoPorComa(Me.TxtValProp.Text), Me.CboSec.SelectedValue, Me.CboFor.SelectedValue, Me.TxtNPla.Text, Util.invN1_0(ChkUM.Checked), Util.invN1_0(ChkEC.Checked), "0", Me.TxtLugEje.Text, Me.CboTPlazo.SelectedValue, Me.CboSec.SelectedValue, Me.TxtNProc.Text, TxtPlazo2.Text, CboTPlazo3.SelectedValue, Publico.PuntoPorComa(TxtValSinIva.Text), Me.CboInterventoria.SelectedValue, Util.invN1_0(Me.ChkAgotarPpto.Checked), TxtConsiderandos.Text, TxtAportes.Text, mun, j - 1, CboRevPor.SelectedValue, Me.TxtObsProy.Text, Me.TxtObsCDP.Text, Me.TxtObsPol.Text)
        End Select
        MsgBox(MsgResult, obj.lErrorG)
        If obj.lErrorG = False Then
            Me.Habilitar(False)
            Me.IBtnCancelar.Enabled = False
            Me.IBtnNuevo.Enabled = True
            Me.IBtnGuardar.Enabled = False
            Me.IBtnAbrir.Enabled = True
            Me.GrPagos.DataBind()
            Me.UpdFpago.Update()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            Me.TxtValTot.Attributes.Add("onkeyup", "javascript:AporOtros();")
            Me.TxtValProp.Attributes.Add("onkeyup", "javascript:AporOtros();")
            Me.TxtValOtros.Attributes.Add("onkeyup", "javascript:AporOtros();")

            Me.TxtValRub.Attributes.Add("onblur", "javascript:ValRub();")
            Me.TxtValPago.Attributes.Add("onblur", "javascript:ValPago();")

            Me.TxtValTot.Attributes.Add("onblur", "javascript:ValTotal();")
            Me.TxtValProp.Attributes.Add("onblur", "javascript:ValAporGob();")
            Me.TxtValSinIva.Attributes.Add("onblur", "javascript:ValIVA();")

            Me.TxtValAdi.Attributes.Add("onkeyup", "javascript:AporOtrosAdi();")
            Me.TxtValPropAdi.Attributes.Add("onkeyup", "javascript:AporOtrosAdi();")
            Me.TxtValOtrosAdi.Attributes.Add("onkeyup", "javascript:AporOtrosAdi();")

            Me.TxtValAdi.Attributes.Add("onblur", "javascript:ValTotalAdi();")
            Me.TxtValPropAdi.Attributes.Add("onblur", "javascript:ValAporGobAdi();")
            Me.TxtValSinIVAAdi.Attributes.Add("onblur", "javascript:ValIVAAdi();")
            Cancelar()
            Me.TxtNprocA.Text = Request("Num_Proc")
            'Me.CboGrupos.DataBind()
            'Me.CboGrupos.SelectedValue = Request("Grupo")
            ''Buscar("1")
            Abrir()
        End If


    End Sub

    Private Sub Nuevo()
        Me.Habilitar(True)
        Me.Limpiar()
        Me.TxtNProc.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.IBtnCancelar.Enabled = True
        Me.IbtnEditar.Enabled = False
        Me.grdObligMod1.Limpiar()
        Me.BtnDefinitivo.Visible = False
        BtnAnular.Visible = False
        Me.BtnTramite.Visible = False
        Me.LblDef.Visible = False
        Me.LblTra.Visible = False
        Me.Oper = "nuevo"
    End Sub

    Private Sub Habilitar(ByVal Valor As Boolean)
        Me.CboInterventoria.Enabled = Valor
        Me.TxtLugEje.Enabled = Valor
        Me.TxtNPla.Enabled = False
        Me.TxtNProc.Enabled = False
        Me.TxtObj.Enabled = Valor
        Me.TxtPlazo.Enabled = Valor
        TxtPlazo2.Enabled = Valor
        CboTPlazo3.Enabled = Valor
        TxtValIva.Enabled = Valor
        TxtValSinIva.Enabled = Valor
        'Me.TxtPro.Enabled = Valor
        Me.TxtValOtros.Enabled = Valor
        Me.TxtValProp.Enabled = Valor
        Me.TxtValTot.Enabled = Valor
        Me.cboDep.Enabled = False
        Me.CboDepP.Enabled = False
        Me.CboFor.Enabled = Valor
        Me.CboSec.Enabled = Valor
        Me.cboStip.Enabled = Valor
        Me.CboTip.Enabled = False
        Me.CboTproc.Enabled = False
        'Me.grdObligMod1.Enabled = Valor
        'Me.grdCDPMod1.Enabled = Valor
        Me.ChkEC.Enabled = Valor
        Me.ChkUM.Enabled = Valor
        Me.CboTPlazo.Enabled = Valor
        Me.DataList1.Enabled = Valor
        'Me.Grv_Ppol.Enabled = Valor
        Me.TxtVigencia.Enabled = Valor
        ''Desde el 11 Junio de 2011
        ChkAgotarPpto.Enabled = Valor
        TxtConsiderandos.Enabled = Valor
        '18 de Jn 2011
        TxtAportes.Enabled = Valor
        ChkModFP.Enabled = Valor
        ChkModPry.Enabled = Valor
        ChkModRub.Enabled = Valor
        ChkModProp.Enabled = Valor
        UpdateTodaAcordeon()
    End Sub
    Sub HabilitarValorAdi(ByVal val As Boolean)
        TxtValAdi.Enabled = val
        TxtValPropAdi.Enabled = val
        TxtValOtrosAdi.Enabled = val
        TxtValSinIVAAdi.Enabled = val
        TxtValIVAAdi.Enabled = val
        RfvValAdi.Enabled = val
        RequiredFieldValidator8.Enabled = val
        RequiredFieldValidator9.Enabled = val
    End Sub
    Sub HabilitarPlazoAdi(ByVal Val As Boolean)
        TxtAdiPla1.Enabled = Val
        TxtAdiPla2.Enabled = Val
        CmbTipAdiPla1.Enabled = Val
        CmbTipAdiPla2.Enabled = Val
    End Sub
    Private Sub Limpiar()
        Me.TxtLugEje.Text = ""
        Me.TxtNPla.Text = ""
        Me.TxtNProc.Text = ""
        Me.TxtObj.Text = ""

        Me.TxtPlazo.Text = 0
        'Me.TxtPro.Text = ""

        TxtValIva.Text = 0


        TxtValSinIva.Text = 0
        TxtPlazo2.Text = 0
        'Me.TxtValOtros.Text = 0
        ValOtros = 0
        ValProp = 0
        'Me.TxtValProp.Text = 0
        ValTot = 0
        TxtValAdi.Text = ""
        TxtValPropAdi.Text = ""
        TxtValOtrosAdi.Text = ""
        TxtValSinIVAAdi.Text = ""
        TxtValIVAAdi.Text = ""

        Me.cboDep.SelectedIndex = -1
        Me.CboDepP.SelectedIndex = -1
        Me.CboFor.SelectedIndex = -1
        Me.CboSec.SelectedIndex = -1
        Me.cboStip.SelectedIndex = -1
        Me.CboTip.SelectedIndex = -1
        Me.CboTproc.SelectedIndex = -1
        '11 de Jun 2011 - Boris 
        Me.ChkAgotarPpto.Checked = False
        Me.ChkUM.Checked = False
        Me.ChkEC.Checked = False
        Me.TxtConsiderandos.Text = ""
        Me.TxtAportes.Text = ""

        Me.grdObligMod1.Limpiar()
        Me.grdCDPMod1.Limpiar()
        Me.MsgPagos.Text = ""
        Me.MsgPagos.CssClass = ""
        Me.MsgPol.Text = ""
        Me.MsgPol.CssClass = ""
        Me.MsgProy.Text = ""
        Me.MsgProy.CssClass = ""
        Me.MsgRubro.Text = ""
        Me.MsgRubro.CssClass = ""
        MsgAdi.Text = ""
        MsgAdi.CssClass = ""
        Me.ChkAgotarPpto.Checked = False
        Me.ChkUM.Checked = False
        Me.ChkEC.Checked = False
        UpdateTodaAcordeon()
    End Sub

    Public Sub Cancelar()
        Me.Limpiar()
        Me.IBtnNuevo.Enabled = True
        Me.IBtnAbrir.Enabled = True
        Me.IBtnGuardar.Enabled = False
        Me.IBtnCancelar.Enabled = False
        Me.IbtnEditar.Enabled = False
        Me.BtnGuardaProy.Enabled = False
        Me.BtnBuscaProy.Enabled = False
        Me.TxtProyecto.Enabled = False
        Me.Habilitar(False)
        HabilitarValorAdi(False)
        HabilitarPlazoAdi(False)
        Me.BtnDefinitivo.Visible = False
        BtnAnular.Visible = False
        Me.BtnTramite.Visible = False
        Me.LblDef.Visible = False
        Me.LblTra.Visible = False
        Me.Oper = ""
        Me.MsgResult.Text = ""
        Me.MsgPagos.Text = ""
        Me.MsgPagos.CssClass = ""
        Me.MsgPol.Text = ""
        Me.MsgPol.CssClass = ""
        Me.MsgProy.Text = ""
        Me.MsgProy.CssClass = ""
        Me.MsgRubro.Text = ""
        Me.MsgRubro.CssClass = ""
        MsgAdi.Text = ""
        MsgAdi.CssClass = ""
        UpdateTodaAcordeon()
    End Sub

    Public Sub Editar()
        MsgBoxLimpiar(MsgResult)
        Habilitar(True)
        If GrPagos.Rows.Count > 0 Then
            ChkModFP.Checked = True
        Else
            ChkModFP.Checked = False
        End If
        If GrRubros.Rows.Count > 0 Then
            ChkModRub.Checked = True
        Else
            ChkModRub.Checked = False
        End If
        If GrProyectos.Rows.Count > 0 Then
            ChkModPry.Checked = True
        Else
            ChkModPry.Checked = False
        End If
        If Grv_Ppol.Rows.Count > 0 Then
            ChkModPol.Checked = True
        Else
            ChkModPol.Checked = False
        End If
        If GridView2.Rows.Count > 0 Then
            ChkModProp.Checked = True
        Else
            ChkModProp.Checked = True
        End If
        Me.IbtnEditar.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnCancelar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.Oper = "editar"
        UpdateTodaAcordeon()
    End Sub
    ''' <summary>
    ''' ''Actualiza todos los grid, solo cuando se cambia el proceso o cuando se le da editar o cualquier operacion comun para todo el formulario
    ''' </summary>
    ''' <remarks></remarks>
    Sub UpdateTodaAcordeon()
        UpdRubros.Update()
        UpdCDP.Update()
        UpdFpago.Update()
        UpdProy.Update()
        updOblig.Update()
        UpdPolizas.Update()
        UpdCons.Update()
        UpdMin.Update()
        UpdValPla.Update()
        UpdProp.Update()
    End Sub
    Sub Buscar()
        Dim Cod_Con As String
        Dim IdSolAdi As String
        Dim oC As New Contratos
        Dim oSA As New Sol_Adiciones
        Cod_Con = oC.GetCodigo(Me.CboTip.SelectedValue, Me.TxtNprocA.Text, Vigencia_Cookie)
        Me.TxtNprocA.Text = Cod_Con
        IdSolAdi = Me.CboNumSol.SelectedValue
        Dim dt As DataTable = obj.GetbyPK(IdSolAdi)
        'Dim dt As DataTable = obj.GetbyPK(Me.TxtNprocA.Text) 'obj.GetByPk(Me.TxtNprocA.Text)
        If dt.Rows.Count > 0 Then
            'Me.TxtLugEje.Text=
            Me.LbVtotal.Text = FormatCurrency(obj.ValordelContrato1(dt.Rows(0)("NUM_SOL_ADI").ToString, dt.Rows(0)("COD_CON").ToString), 3)
            Me.TxtNProc.Text = dt.Rows(0)("COD_CON").ToString
            Me.Num_Proc = dt.Rows(0)("Pro_Sel_Nro").ToString
            Me.TxtNPla.Text = dt.Rows(0)("NRO_PLA_CON").ToString
            Me.Pk1 = dt.Rows(0)("NUM_SOL_ADI").ToString
            Me.TipAdi = dt.Rows(0)("Tip_Adi").ToString
            Me.TxtObj.Text = dt.Rows(0)("obj_con").ToString
            Me.TxtPlazo.Text = dt.Rows(0)("PLA_EJE_CON").ToString
            'Me.TxtPro.Enabled = CStr(dt.Rows(0)("PRO_CON"))
            Me.CboInterventoria.SelectedValue = dt.Rows(0)("INTERVENTORIA").ToString
            Me.LbTipAdi.Text = dt.Rows(0)("Tipo_Adicion").ToString
            'Me.TxtValTot.Text
            ValTot = dt.Rows(0)("VAL_CON").ToString.Replace(",", ".")
            'Me.TxtValProp.Text
            ValProp = dt.Rows(0)("VAL_APO_GOB").ToString.Replace(Publico.Punto_DecOracle, ".")
            'Me.TxtValOtros.Text 
            ValOtros = dt.Rows(0)("VAL_OTROS").ToString.Replace(Publico.Punto_DecOracle, ".")

            Me.cboDep.SelectedValue = dt.Rows(0)("DEP_CON").ToString
            Me.CboDepP.SelectedValue = dt.Rows(0)("DEP_PCON").ToString

            'Me.CboFor.SelectedValue = dt.Rows(0)("TIP_FOR").ToString
            If dt.Rows(0)("COD_SEC").ToString <> "" Then
                Me.CboSec.SelectedValue = dt.Rows(0)("COD_SEC").ToString
            End If

            Me.CboTip.SelectedValue = dt.Rows(0)("TIP_CON").ToString
            Me.cboStip.DataBind()
            Me.cboStip.SelectedValue = dt.Rows(0)("STIP_CON").ToString
            Me.CboTproc.SelectedValue = dt.Rows(0)("COD_TPRO").ToString

            Me.TxtLugEje.Text = dt.Rows(0)("LUG_EJE").ToString

            Me.LbEstado.Text = dt.Rows(0)("NOM_EST").ToString

            'Me.grdProy1.Num_Proc = dt.Rows(0)("PRO_SEL_NRO").ToString
            'Me.grdProy1.LlenarGrid()
            Me.grdObligMod1.Num_Proc = dt.Rows(0)("COD_CON").ToString
            Me.HiddenField1.Value = dt.Rows(0)("COD_CON").ToString
            Me.grdCDPMod1.Cod_Con = dt.Rows(0)("COD_CON").ToString
            Me.grdCDPMod1.Num_Sol_Adi = dt.Rows(0)("Num_Sol_Adi").ToString
            Me.grdObligMod1.Num_Sol_Adi = dt.Rows(0)("Num_Sol_Adi").ToString
            Me.ChkEC.Checked = Util.N1_0(dt.Rows(0)("EST_CONV").ToString)
            Me.ChkUM.Checked = Util.N1_0(dt.Rows(0)("URG_MAN").ToString)
            Me.TxtFecPago.Text = Today.ToShortDateString
            Me.TxtValSinIva.Text = dt.Rows(0)("VAL_SIN_IVA").ToString.Replace(Publico.Punto_DecOracle, ".")
            Me.TxtValIva.Text = dt.Rows(0)("VAL_IVA").ToString.Replace(Publico.Punto_DecOracle, ".")
            If dt.Rows(0)("PLAZO2_EJE_CON").ToString = "" Then
                Me.TxtPlazo2.Text = "0"
            Else
                Me.TxtPlazo2.Text = dt.Rows(0)("PLAZO2_EJE_CON").ToString
            End If

            If dt.Rows(0)("TIPO_PLAZO").ToString <> "" Then
                Me.CboTPlazo.SelectedValue = dt.Rows(0)("TIPO_PLAZO").ToString
            End If
            CboTPlazo3.DataBind()
            If Me.CboTPlazo.SelectedValue <> "D" And dt.Rows(0)("TIPO_PLAZO2").ToString <> "" Then
                Me.CboTPlazo3.SelectedValue = dt.Rows(0)("TIPO_PLAZO2").ToString
            End If
            Me.TxtValAdi.Text = dt.Rows(0)("VAL_CON_ADI").ToString.Replace(",", ".")
            Me.TxtValPropAdi.Text = dt.Rows(0)("VAL_APO_GOB_ADI").ToString.Replace(",", ".")
            Me.TxtValSinIVAAdi.Text = dt.Rows(0)("VAL_SIN_IVA_ADI").ToString.Replace(",", ".")
            Me.TxtValIVAAdi.Text = dt.Rows(0)("VAL_IVA_ADI").ToString.Replace(",", ".")
            If dt.Rows(0)("PLAZO1_ADI").ToString <> "" Then
                Me.TxtAdiPla1.Text = dt.Rows(0)("PLAZO1_ADI").ToString
            Else
                Me.TxtAdiPla1.Text = "0"
            End If
            If dt.Rows(0)("PLAZO2_ADI").ToString <> "" Then
                Me.TxtAdiPla2.Text = dt.Rows(0)("PLAZO2_ADI").ToString
            Else
                Me.TxtAdiPla2.Text = "0"
            End If
            If dt.Rows(0)("TIPO_PLAZO1_ADI").ToString <> "" Then
                Me.CmbTipAdiPla1.SelectedValue = dt.Rows(0)("TIPO_PLAZO1_ADI").ToString
            End If
            CmbTipAdiPla2.DataBind()
            If Me.CmbTipAdiPla1.SelectedValue <> "D" And dt.Rows(0)("TIPO_PLAZO2_ADI").ToString <> "" Then
                Me.CmbTipAdiPla2.SelectedValue = dt.Rows(0)("TIPO_PLAZO2_ADI").ToString
            End If
            Me.TxtValOtrosAdi.Text = dt.Rows(0)("VAL_OTROS_ADI").ToString.Replace(",", ".")

            '11 JN 2011- BORIS
            Me.ChkAgotarPpto.Checked = Util.N1_0(dt.Rows(0)("AGOTAR_PPTO").ToString)
            Me.TxtConsiderandos.Text = dt.Rows(0)("considerandos").ToString
            '18 Jn 2011 BORIS
            Me.TxtAportes.Text = dt.Rows(0)("Aportes").ToString
            Me.TxtObsCDP.Text = dt.Rows(0)("Obs_CDP").ToString
            Me.TxtObsProy.Text = dt.Rows(0)("Obs_Proyectos").ToString
            Me.TxtObsPol.Text = dt.Rows(0)("Obs_Poliza").ToString

            'Me.grdOblig1.Enabled = Valor
            Me.grdCDPMod1.LlenarGrid()
            Me.grdObligMod1.LlenarGrid()
            'Me.grdCDP1.Enabled = Valor
            Me.Habilitar(False)
            HabilitarPlazoAdi(False)
            HabilitarValorAdi(False)
            Me.IBtnAbrir.Enabled = True
            Me.IbtnEditar.Enabled = True
            Me.IBtnGuardar.Enabled = False
            Me.IBtnCancelar.Enabled = False
            Me.BtnDefinitivo.Visible = False
            BtnAnular.Visible = False
            Me.BtnTramite.Visible = False
            Me.LblDef.Visible = False
            Me.LblTra.Visible = False
            Me.MsgResult.Text = ""
            Me.MsgResult.CssClass = ""
            UpdateTodaAcordeon()
            'Grv_Ppol.DataBind()

        Else
            MsgResult.Text = " No se encontro el Proceso " + Me.TxtNprocA.Text + " a cargo del Usuario " + Usuarios.UserName
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub
    Public Sub Abrir()
        If TxtNprocA.Text <> "" Then
            Buscar()
        Else
            Limpiar()
        End If
    End Sub

    Protected Sub IBtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        Nuevo()
    End Sub

    Protected Sub IBtnAbrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAbrir.Click
        Abrir()
    End Sub

    Protected Sub IbtnEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnEditar.Click
        Dim pcont As New Modificaciones
        Dim dt As DataTable
        dt = pcont.GetbyPK(CboNumSol.SelectedValue)
        Dim est As String = dt.Rows(0).Item("Mod_Estado").ToString
        If dt.Rows(0)("Tip_Adi").ToString = "1" Then
            HabilitarPlazoAdi(True)
            HabilitarValorAdi(True)
        ElseIf dt.Rows(0)("Tip_Adi").ToString = "2" Then
            HabilitarPlazoAdi(False)
            HabilitarValorAdi(True)
        ElseIf dt.Rows(0)("Tip_Adi").ToString = "3" Then
            HabilitarPlazoAdi(True)
            HabilitarValorAdi(False)
        Else
            HabilitarPlazoAdi(False)
            HabilitarValorAdi(False)
        End If
        If est = "TR" Then
            Editar()
            Me.BtnDefinitivo.Visible = True
            Me.BtnTramite.Visible = False
            Me.BtnAnular.Visible = True
            Me.LblDef.Visible = True
            Me.LblTra.Visible = False
        ElseIf est = "DF" Then
            HabilitarPlazoAdi(False)
            HabilitarValorAdi(False)
            UpdValPla.Update()
            Me.BtnDefinitivo.Visible = False
            Me.BtnTramite.Visible = True
            Me.BtnAnular.Visible = True
            Me.LblDef.Visible = False
            Me.LblTra.Visible = True
            Me.MsgResult.Text = "El proceso ya esta válidado y listo para Generar la Minuta y Radicar la Modificación, para modificarlo debe revertir la válidación"
            MsgBoxAlert(MsgResult, True)
        ElseIf est = "AN" Then
            Me.MsgResult.Text = "El proceso fue Anulado. No puede ser Editado."
            MsgBoxAlert(MsgResult, True)
        Else
            Me.MsgResult.Text = "El proceso ya fue Radicado. No puede ser Editado."
            MsgBoxAlert(MsgResult, True)
        End If

    End Sub

    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        If Val(Me.TxtValTot.Text) < Val(Me.TxtValProp.Text) Then
            Me.MsgResult.Text = "El valor de los aportes propios no puede ser mayor que el valor del contrato"
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        If Val(Me.TxtValTot.Text) < Val(Me.TxtValSinIva.Text) Then
            Me.MsgResult.Text = "El valor sin IVA no puede ser mayor que el valor del contrato" & Val(Me.TxtValTot.Text) & " , " & Val(Me.TxtValSinIva.Text)
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        Guardar()
        Me.IbtnEditar.Enabled = True
    End Sub

    Protected Sub IBtnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnCancelar.Click
        Cancelar()
    End Sub
    Protected Sub BtnBuscaProy_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscaProy.Click
        Me.ModalPopupExtender1.Show()
    End Sub

    Protected Sub ConProyectos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConProyectos1.SelClicked
        TxtProyecto.Text = ConProyectos1.Num_Proy
        TxtNomProyecto.Text = ConProyectos1.Nom_Proy
        Me.ModalPopupExtender1.Hide()
        UpdProy.Update()
    End Sub
    Sub BuscarProyecto()
        Dim t As New Proyectos
        Dim dt As DataTable = t.GetbyPk(Me.TxtProyecto.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNomProyecto.Text = dt.Rows(0)("Nombre_Proyecto").ToString()
        Else
            Me.TxtNomProyecto.Text = ""
        End If
    End Sub

    Protected Sub TxtProyecto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProyecto.TextChanged
        BuscarProyecto()
        MsgBoxLimpiar(MsgProy)
    End Sub

    Protected Sub BtnGuardaProy_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardaProy.Click
        MsgProy.Text = obj.InsertProy(TxtProyecto.Text, Me.CboNumSol.SelectedValue, TxtNProc.Text)
        Me.GrProyectos.DataBind()
    End Sub

    Protected Sub GrProyectos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrProyectos.RowCommand
        Select Case e.CommandName
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GrProyectos.SelectedIndex = index
                MsgProy.Text = obj.DeleteProy(Me.GrProyectos.DataKeys(index).Values(0).ToString, Me.GrProyectos.DataKeys(index).Values(1).ToString)
                GrProyectos.DataBind()
        End Select
    End Sub

    Protected Sub IbtnBucaRubro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnBucaRubro.Click
        Me.ModalPopupRubros.Show()
    End Sub
    Protected Sub ConRubros1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConRubros1.SelClicked
        Txt_CodRub.Text = ConRubros1.Cod_Rub
        Txt_DesRub.Text = ConRubros1.Des_Rub
        Me.ModalPopupRubros.Hide()
        UpdRubros.Update()
    End Sub
    Sub BuscarRubro()
        Dim t As New Rubros
        Dim dt As DataTable = t.GetbyPK(Me.Txt_CodRub.Text)
        If dt.Rows.Count > 0 Then
            Me.Txt_DesRub.Text = dt.Rows(0)("Des_Rub").ToString()
        Else
            Me.Txt_DesRub.Text = ""
        End If
    End Sub

    Protected Sub Txt_CodRub_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CodRub.TextChanged
        BuscarRubro()
    End Sub

    Protected Sub BtnGuardaRubro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardaRubro.Click
        If CboCDP.Items.Count = 0 Then
            MsgRubro.Text = "No existen certificados de disponibilidad"
            MsgBoxAlert(MsgRubro, True)
            Exit Sub
        Else
            Dim ObjRub As New Rubros_GProcesos
            Me.MsgRubro.Text = obj.InsertRubro(Me.Txt_CodRub.Text, Me.CboNumSol.SelectedValue, Me.TxtValRub.Text, Me.CboCDP.SelectedValue, Me.TxtNProc.Text)
            MsgBox(MsgRubro, obj.lErrorG)
            Me.GrRubros.DataBind()
            LimpiarRubros()
        End If
    End Sub
    Sub LimpiarRubros()
        Me.Txt_CodRub.Text = ""
        Me.TxtValRub.Text = ""
    End Sub

    Protected Sub GrRubros_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrRubros.RowCommand
        Select Case e.CommandName
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GrProyectos.SelectedIndex = index
                Dim objRubro As New Rubros_GProcesos
                MsgRubro.Text = obj.DeleteRubro(Me.GrRubros.DataKeys(index).Values(0).ToString, Me.GrRubros.DataKeys(index).Values(1).ToString)
                MsgBox(MsgRubro, objRubro.lErrorG)
                GrRubros.DataBind()
        End Select
    End Sub

    Protected Sub BtnGuardarPago_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardarPago.Click
        If GuardarFP = "Nuevo" Then
            If IsDate(Me.TxtFecPago.Text) And IsNumeric(Me.TxtValPago.Text) Then
                Me.MsgPagos.Text = obj.InsertPago(Me.CboNumSol.SelectedValue, Me.TxtFecPago.Text, Me.CboTipPago.SelectedValue, Publico.PuntoPorComa(Me.TxtValPago.Text), Me.TxtCondicionPago.Text, RbtPorcentaje.Checked, Me.TxtNProc.Text, Util.invN1_0(ChkPagGober.Checked))
                GrPagos.DataBind()
                If obj.lErrorG = False Then
                    limpiarPagos()
                End If
                MsgBox(MsgPagos, obj.lErrorG)

            Else
                Me.fechavalida.Text = "Fecha Inválida"
                MsgBoxAlert(Me.fechavalida, True)
            End If
        ElseIf GuardarFP = "Editar" Then
            If IsDate(Me.TxtFecPago.Text) And IsNumeric(Me.TxtValPago.Text) Then
                Me.MsgPagos.Text = obj.UpdatePago(ID_FP, Me.CboNumSol.SelectedValue, Me.TxtFecPago.Text, Me.CboTipPago.SelectedValue, Publico.PuntoPorComa(Me.TxtValPago.Text), Me.TxtCondicionPago.Text, RbtPorcentaje.Checked, Me.TxtNProc.Text, Util.invN1_0(ChkPagGober.Checked))
                MsgBox(MsgPagos, obj.lErrorG)
                GrPagos.DataBind()
                If obj.lErrorG = False Then
                    limpiarPagos()
                    'MsgBox(MsgPagos, pp.lErrorG)
                    GuardarFP = "Nuevo"
                End If
            Else
                Me.fechavalida.Text = "Fecha Inválida"
                MsgBoxAlert(Me.fechavalida, True)
            End If
        End If

    End Sub

    Protected Sub GrPagos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrPagos.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.GrPagos.SelectedIndex = index
        Dim pp As New Pagos_Gprocesos
        GuardarFP = e.CommandName
        Select Case e.CommandName
            Case "Eliminar"
                MsgPagos.Text = obj.DeletePago(Me.GrPagos.DataKeys(index).Values(0).ToString, Me.GrPagos.DataKeys(index).Values(1).ToString)
                MsgBox(MsgPagos, pp.lErrorG)
                GrPagos.DataBind()
                GuardarFP = "Nuevo"
            Case "Editar"
                Me.MsgPagos.Text = "Editando"
                Me.MsgBoxInfo(MsgPagos, True)
                ID_FP = Me.GrPagos.DataKeys(index).Values(0).ToString
                Dim dtPagos As DataTable = obj.GetPagobyPk(Me.GrPagos.DataKeys(index).Values(0).ToString, Me.GrPagos.DataKeys(index).Values(1).ToString)
                Me.CboTipPago.SelectedValue = dtPagos.Rows(0)("Tipo_pago")
                Me.TxtFecPago.Text = dtPagos.Rows(0)("Fecha_Pago")
                Me.TxtCondicionPago.Text = dtPagos.Rows(0)("Condicion_Pago")
                Me.TxtValPago.Text = CDec(dtPagos.Rows(0)("Porcentaje") * 100).ToString.Replace(",", ".")
                ChkPagGober.Checked = Util.N1_0(dtPagos.Rows(0)("Paga_Gober")) ' 
                Me.RbtValPago.Checked = True
                GuardarFP = "Nuevo"
                ' Publico.PuntoPorComa(Me.TxtValPago.Text), Me.TxtCondicionPago.Text, RbtPorcentaje.Checked, Me.CboGrupos.SelectedValue)
        End Select
    End Sub

    Protected Sub grdCDP1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCDPMod1.SelClicked
        Me.CboCDP.DataBind()
        Me.GrRubros.DataBind()
        Me.UpdRubros.Update()
    End Sub
    Sub limpiarPagos()
        Me.TxtValPago.Text = ""
        Me.TxtFecPago.Text = Today.ToShortDateString
        Me.TxtCondicionPago.Text = ""
    End Sub

    'Protected Sub BtnDefinitivo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnDefinitivo.Click
    '    Dim pcont As New GProcesos
    '    MsgResult.Text = pcont.Definitivo(TxtNProc.Text, CboGrupos.SelectedValue)
    '    MsgBox(MsgResult, pcont.lErrorG)
    '    If Not pcont.lErrorG Then
    '        Habilitar(False)
    '    End If

    'End Sub

    'Protected Sub BtnTramite_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnTramite.Click
    '    Dim pcont As New GProcesos
    '    MsgResult.Text = pcont.Tramite(TxtNProc.Text, CboGrupos.SelectedValue)
    '    MsgBox(MsgResult, pcont.lErrorG)
    '    If Not pcont.lErrorG Then
    '        Habilitar(False)
    '    End If
    'End Sub

    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        Me.TxtNprocA.Text = ConPContratos1.Num_Proc
        Buscar()
        Me.ModalPopupConP.Hide()
    End Sub

    Protected Sub IbtnBucar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnBucar.Click
        Me.ModalPopupConP.Show()
    End Sub

    Protected Sub BtnGuardarPol_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardarPol.Click
        If CboAmparo.SelectedIndex = 0 Or CboCalPol.SelectedIndex = 0 Or CboCalVigPol.SelectedIndex = 0 Then
            Me.MsgPol.Text = "Debe especificar toda la informacion necesaria"
            MsgBoxAlert(MsgPol, True)

        Else
            MsgPol.Text = obj.InsertPol(CboAmparo.SelectedValue, Me.CboNumSol.SelectedValue, TxtSMMLV.Text, CboCalPol.SelectedValue, TxtVigencia.Text, CboCalVigPol.SelectedValue, cboTipo.SelectedValue, Me.TxtNProc.Text)
            If obj.lErrorG = False Then
                Me.Grv_Ppol.DataBind()
                Me.TxtVigencia.Text = ""
                Me.TxtSMMLV.Text = ""
                Me.CboCalVigPol.SelectedIndex = 0
                Me.CboCalPol.SelectedIndex = 0
                Me.CboAmparo.SelectedIndex = 0
            End If
            MsgBox(MsgPol, obj.lErrorG)
        End If
    End Sub

    Protected Sub Grv_Ppol_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grv_Ppol.RowCommand
        Select Case e.CommandName
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.Grv_Ppol.SelectedIndex = index
                Dim ppol As New GPPolizas
                MsgRubro.Text = obj.DeletePol(Me.Grv_Ppol.DataKeys(index).Values(0).ToString, Me.Grv_Ppol.DataKeys(index).Values(1).ToString)
                Grv_Ppol.DataBind()
        End Select
    End Sub

    Protected Sub GrPagos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrPagos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If

        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.TotalFP = 0
                Me.TotalPor = 0
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Center

            Case DataControlRowType.DataRow

                Me.TotalFP += CDec(DataBinder.Eval(e.Row.DataItem, "VALOR_PAGO"))
                Me.TotalPor += CDec(DataBinder.Eval(e.Row.DataItem, "PORCENTAJE"))

                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right

            Case DataControlRowType.Footer
                e.Row.Cells(3).Text = FormatCurrency(Me.TotalFP.ToString, 3)
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                e.Row.Cells(4).Text = FormatPercent(Me.TotalPor.ToString, 3)
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub TxtNprocA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNprocA.TextChanged
        Buscar()
    End Sub

    Protected Sub CboTPlazo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTPlazo.SelectedIndexChanged
        If CboTPlazo.SelectedValue = "D" Then
            TxtPlazo2.Enabled = False
        Else
            TxtPlazo2.Enabled = True
        End If
    End Sub

    Protected Sub TxtConsiderandos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtConsiderandos.TextChanged
        LbConsiderandos.Text = TxtConsiderandos.Text
    End Sub

    Protected Sub TxtValTot_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValTot.TextChanged
        LbValTot.Text = FormatCurrency(TxtValTot.Text.Replace(".", ","))

    End Sub

    Protected Sub TxtValProp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValProp.TextChanged
        LbValProp.Text = FormatCurrency(TxtValProp.Text.Replace(".", ","))
        Dim AportesOtros As Decimal = (CDec(TxtValTot.Text.Replace(".", ",")) - CDec(TxtValProp.Text.Replace(".", ",")))
        TxtValOtros.Text = AportesOtros.ToString.Replace(",", ".")
        If AportesOtros < 0 Then
            TxtValOtros.ForeColor = Drawing.Color.Red
            LbValOtros.Text = "Valor Incoherente, por favor corrija"
            LbValOtros.ForeColor = Drawing.Color.Red
            TxtValTot.Focus()
        Else
            MsgBoxLimpiar(LbValOtros)
            LbValOtros.ForeColor = Drawing.Color.Black
            TxtValOtros.ForeColor = Drawing.Color.Black
            LbValOtros.Text = FormatCurrency(TxtValOtros.Text.Replace(".", ","))


        End If

    End Sub

    'Protected Sub LnkProponentes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkProponentes.Click
    '    Redireccionar_Pagina("/Procesos/GPProponentes/GPProponentes.aspx?Num_Proc=" + Me.TxtNProc.Text + "&Grupo=" + Me.CboGrupos.SelectedValue)
    'End Sub

    'Protected Sub LnkAdj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkAdj.Click
    '    Redireccionar_Pagina("/Procesos/GAdjudicacion/GAdjudicacion.aspx?Num_Proc=" + Me.TxtNProc.Text + "&Grupo=" + Me.CboGrupos.SelectedValue)
    'End Sub

    'Protected Sub GrdMin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdMin.SelectedIndexChanged
    '    Redireccionar_Pagina("/Procesos/GProcesosN/VerMin.aspx?Num_Proc=" + Me.TxtNProc.Text + "&Grupo=" + Me.CboGrupos.SelectedValue + "&ID=" + GrdMin.SelectedValue.ToString)
    'End Sub

    Protected Sub ChkModFP_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkModFP.CheckedChanged
        Me.TxtValPago.Enabled = ChkModFP.Checked
        Me.CboTipPago.Enabled = ChkModFP.Checked
        Me.TxtFecPago.Enabled = ChkModFP.Checked
        Me.TxtCondicionPago.Enabled = ChkModFP.Checked
        Me.BtnGuardarPago.Enabled = ChkModFP.Checked
        Me.RbtPorcentaje.Enabled = ChkModFP.Checked
        Me.RbtValPago.Enabled = ChkModFP.Checked
        Me.ChkPagGober.Enabled = ChkModFP.Checked
        Me.GrPagos.Enabled = ChkModFP.Checked
        MsgPagos.Text = obj.Tras_FP(TxtNProc.Text, CboNumSol.SelectedValue, Util.invN1_0(ChkModFP.Checked))
        MsgBoxInfo(MsgPagos, False)
        Me.GrPagos.DataBind()
    End Sub


    Protected Sub ChkModPry_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkModPry.CheckedChanged
        Me.TxtProyecto.Enabled = ChkModPry.Checked
        Me.GrProyectos.Enabled = ChkModPry.Checked
        Me.BtnGuardaProy.Enabled = ChkModPry.Checked
        Me.BtnBuscaProy.Enabled = ChkModPry.Checked
        MsgProy.Text = obj.Tras_Cproy(TxtNProc.Text, CboNumSol.SelectedValue, Util.invN1_0(ChkModPry.Checked))
        MsgBoxInfo(MsgProy, False)
        Me.GrProyectos.DataBind()
    End Sub

    Protected Sub ChkModRub_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkModRub.CheckedChanged
        Me.Txt_CodRub.Enabled = ChkModRub.Checked
        Me.IbtnBucaRubro.Enabled = ChkModRub.Checked
        Me.BtnGuardaRubro.Enabled = ChkModRub.Checked
        Me.TxtValRub.Enabled = ChkModRub.Checked
        Me.CboCDP.Enabled = ChkModRub.Checked
        Me.GrRubros.Enabled = ChkModRub.Checked
        MsgRubro.Text = obj.Tras_Rubros(TxtNProc.Text, CboNumSol.SelectedValue, Util.invN1_0(ChkModRub.Checked))
        MsgBoxInfo(MsgProy, False)
        Me.GrRubros.DataBind()
    End Sub

    Protected Sub ChkModPol_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkModPol.CheckedChanged
        Me.CboAmparo.Enabled = ChkModPol.Checked
        Me.CboCalPol.Enabled = ChkModPol.Checked
        Me.CboCalVigPol.Enabled = ChkModPol.Checked
        Me.cboTipo.Enabled = ChkModPol.Checked
        Me.TxtSMMLV.Enabled = ChkModPol.Checked
        Me.TxtVigencia.Enabled = ChkModPol.Checked
        Me.BtnGuardarPol.Enabled = ChkModPol.Checked
        obj.Tras_Polizas(TxtNProc.Text, CboNumSol.SelectedValue, Util.invN1_0(ChkModPol.Checked))
        Me.Grv_Ppol.DataBind()
    End Sub

    Protected Sub BtnDefinitivo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnDefinitivo.Click
        MsgResult.Text = obj.Validar(Me.Pk1, Me.TxtNProc.Text, Me.Num_Proc)
        MsgBox(MsgResult, obj.lErrorG)
        If obj.lErrorG = False Then
            Habilitar(False)
            HabilitarPlazoAdi(False)
            HabilitarValorAdi(False)
            Me.BtnDefinitivo.Visible = False
            Me.LblDef.Visible = False
        End If
    End Sub

    Protected Sub BtnGuardarAdi_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardarAdi.Click
        If CDec(Publico.PuntoPorComa(Me.TxtValAdi.Text)) > CDec(obj.Restante(Me.TxtNProc.Text, Me.Vigencia)) Then
            MsgAdi.Text = "EL valor de la adicion no puede ser mayor de " & FormatCurrency(obj.Restante(Me.TxtNProc.Text, Me.Vigencia).Replace(".", ","), 3)
            MsgBoxAlert(MsgAdi, True)
            Exit Sub
        End If
        If Val(TxtValSinIVAAdi.Text) > Val(TxtValAdi.Text) Then
            MsgAdi.Text = "El Valor Sin IVA no puede ser mayor que el Valor de la Adición"
            MsgBoxAlert(MsgAdi, True)
            Exit Sub
        End If
        Me.MsgAdi.Text = obj.AdicionarValPlazo(Me.Pk1, Me.TipAdi, Me.TxtAdiPla1.Text, Me.CmbTipAdiPla1.SelectedValue, Publico.PuntoPorComa(Me.TxtValAdi.Text), Publico.PuntoPorComa(Me.TxtValPropAdi.Text), Publico.PuntoPorComa(Me.TxtValSinIVAAdi.Text), Me.TxtAdiPla2.Text, CmbTipAdiPla2.SelectedValue)
        MsgBox(MsgAdi, obj.lErrorG)
        Me.LbVtotal.Text = FormatCurrency(obj.ValordelContrato1(Me.CboNumSol.SelectedValue, Me.TxtNprocA.Text), 3)
        UpdFpago.Update()
    End Sub

    Protected Sub BtnTramite_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnTramite.Click
        Dim pcont As New Modificaciones
        MsgResult.Text = pcont.Revertir(TxtNProc.Text, CboNumSol.SelectedValue)
        MsgBox(MsgResult, pcont.lErrorG)
        If Not pcont.lErrorG Then
            Habilitar(False)
        End If
    End Sub

    Protected Sub CboNumSol_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboNumSol.SelectedIndexChanged
        Abrir()
    End Sub
    Protected Sub ChkModProp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkModProp.CheckedChanged
        GridView2.Enabled = ChkModProp.Checked
        MsgProp.Text = obj.Tras_Proponentes(TxtNProc.Text, CboNumSol.SelectedValue, Util.invN1_0(ChkModProp.Checked))
        GridView2.DataBind()
    End Sub
    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Me.Oper = e.CommandName
        Select Case Me.Oper
            Case "Editar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.IdProp = GridView1.DataKeys(index).Values(0).ToString()
                ModCrGPProponentes1.Nit = GridView2.DataKeys(index).Values(0).ToString()
                ModCrGPProponentes1.Num_Sol_Adi = Me.Pk1
                ModCrGPProponentes1.Editar()
                Me.MultiView1.ActiveViewIndex = 1
        End Select
    End Sub

    Protected Sub BtnVoler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVoler.Click
        Me.GridView2.DataBind()
        Me.MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub BtnAnular_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAnular.Click
        Dim pcont As New Modificaciones
        MsgResult.Text = pcont.Anular(TxtNProc.Text, CboNumSol.SelectedValue)
        MsgBox(MsgResult, pcont.lErrorG)
        If Not pcont.lErrorG Then
            Habilitar(False)
        End If
    End Sub
End Class
