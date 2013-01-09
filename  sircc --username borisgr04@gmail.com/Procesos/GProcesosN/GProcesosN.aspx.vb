Imports System.Data
Imports System.IO
'Modificado el 10 de septiembre de 2011- BORIS
' SE AGREGO GENERACION DE MINUTAS A PARTIR DE OTRA PAGINA DE ERCI
Partial Class Procesos_GProcesoN_Default
    Inherits PaginaComun
    Dim obj As GProcesos = New GProcesos

    Private Property operRubro() As Boolean
        Set(ByVal value As Boolean)
            ViewState("operRubro") = value
        End Set
        Get
            Return ViewState("operRubro")
        End Get
    End Property
    Private Property ID_FP() As String
        Set(ByVal value As String)
            ViewState("ID_FP") = value
        End Set
        Get
            Return ViewState("ID_FP")
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

    Private WriteOnly Property ValTot As Decimal
        Set(ByVal value As Decimal)
            Me.TxtValTot.Text = value
            'LbValTot.Text = FormatCurrency(TxtValTot.Text.Replace(".", ","))
        End Set
    End Property

    Private WriteOnly Property ValOtros As Decimal
        Set(ByVal value As Decimal)
            Me.TxtValOtros.Text = value
            'LbValOtros.Text = FormatCurrency(TxtValOtros.Text.Replace(".", ","))
        End Set
    End Property

    Private WriteOnly Property ValProp As Decimal
        Set(ByVal value As Decimal)
            Me.TxtValProp.Text = value
            'LbValProp.Text = FormatCurrency(TxtValProp.Text.Replace(".", ","))
        End Set
    End Property
    Public Sub Guardar()
        MsgBoxLimpiar(MsgResult)
        obj = New GProcesos
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
                Me.MsgResult.Text = obj.Update(Me.Pk1, Me.CboTproc.SelectedValue, Me.TxtNProc.Text, Me.TxtObj.Text, "", Me.TxtPlazo.Text, Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, Me.Vigencia.ToString, Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, Publico.PuntoPorComa(Me.TxtValTot.Text), Publico.PuntoPorComa(Me.TxtValProp.Text), Me.CboSec.SelectedValue, Me.CboFor.SelectedValue, Me.TxtNPla.Text, Util.invN1_0(ChkUM.Checked), Util.invN1_0(ChkEC.Checked), "0", Me.TxtLugEje.Text, Me.CboTPlazo.SelectedValue, Me.CboSec.SelectedValue, Me.CboGrupos.SelectedValue, TxtPlazo2.Text, CboTPlazo3.SelectedValue, Publico.PuntoPorComa(TxtValSinIva.Text), Me.CboInterventoria.SelectedValue, Util.invN1_0(Me.ChkAgotarPpto.Checked), TxtConsiderandos.Text, TxtAportes.Text, mun, j - 1, CboRevPor.SelectedValue, Me.TxtObsProy.Text, Me.TxtObsCDP.Text, Me.TxtObsPol.Text)
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
            Me.HdUsuario.Value = Usuarios.UserName
            Me.TxtValTot.Attributes.Add("onkeyup", "javascript:AporOtros();")
            Me.TxtValProp.Attributes.Add("onkeyup", "javascript:AporOtros();")
            Me.TxtValOtros.Attributes.Add("onkeyup", "javascript:AporOtros();")
            Me.TxtValRub.Attributes.Add("onblur", "javascript:ValRub();")
            Me.TxtValPago.Attributes.Add("onblur", "javascript:ValPago();")

            Me.TxtValTot.Attributes.Add("onblur", "javascript:ValTotal();")
            Me.TxtValProp.Attributes.Add("onblur", "javascript:ValAporGob();")
            Me.TxtValSinIva.Attributes.Add("onblur", "javascript:ValIVA();")
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
        Me.grdObligGP1.Limpiar()
        Me.BtnDefinitivo.Visible = False
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
        Me.grdObligGP1.Enabled = Valor
        Me.grdCDPGP1.Enabled = Valor
        Me.ChkEC.Enabled = Valor
        Me.ChkUM.Enabled = Valor
        Me.BtnBuscaProy.Enabled = Valor
        Me.BtnGuardaProy.Enabled = Valor
        Me.TxtProyecto.Enabled = Valor
        Me.IbtnBucaRubro.Enabled = Valor
        Me.BtnGuardaRubro.Enabled = Valor
        Me.Txt_CodRub.Enabled = Valor
        Me.CboCDP.Enabled = Valor
        Me.TxtValRub.Enabled = Valor
        Me.GrProyectos.Enabled = Valor
        Me.GrRubros.Enabled = Valor
        Me.TxtFecPago.Enabled = Valor
        Me.TxtValPago.Enabled = Valor
        Me.TxtCondicionPago.Enabled = Valor
        Me.CboTipPago.Enabled = Valor
        Me.GrPagos.Enabled = Valor
        Me.BtnGuardarPago.Enabled = Valor
        Me.CboTPlazo.Enabled = Valor
        Me.BtnGuardarPol.Enabled = Valor
        Me.CboCalVigPol.Enabled = Valor
        Me.CboCalPol.Enabled = Valor
        Me.CboAmparo.Enabled = Valor
        Me.DataList1.Enabled = Valor
        Me.Grv_Ppol.Enabled = Valor
        Me.TxtSMMLV.Enabled = Valor
        Me.cboTipo.Enabled = Valor
        Me.TxtVigencia.Enabled = Valor
        Me.RbtPorcentaje.Enabled = Valor
        Me.RbtValPago.Enabled = Valor
        ''Desde el 11 Junio de 2011
        ChkAgotarPpto.Enabled = Valor
        TxtConsiderandos.Enabled = Valor
        '18 de Jn 2011
        TxtAportes.Enabled = Valor
        CboRevPor.Enabled = Valor
        Me.TxtObsCDP.Enabled = Valor
        Me.TxtObsProy.Enabled = Valor
        Me.TxtObsPol.Enabled = Valor
        UpdateTodaAcordeon()
    End Sub

    Private Sub Limpiar()
        Me.TxtLugEje.Text = ""
        Me.TxtNPla.Text = ""
        Me.TxtNProc.Text = ""
        Me.TxtObj.Text = ""
        Me.txtobsCDP.text = ""
        Me.txtObsProy.text = ""
        Me.txtObsPol.text = ""

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


        Me.cboDep.SelectedIndex = -1
        Me.CboDepP.SelectedIndex = -1
        Me.CboGrupos.SelectedIndex = -1
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

        Me.grdObligGP1.Limpiar()
        Me.grdCDPGP1.Limpiar()
        Me.MsgPagos.Text = ""
        Me.MsgPagos.CssClass = ""
        Me.MsgPol.Text = ""
        Me.MsgPol.CssClass = ""
        Me.MsgProy.Text = ""
        Me.MsgProy.CssClass = ""
        Me.MsgRubro.Text = ""
        Me.MsgRubro.CssClass = ""

        LbMinuta.CssClass = ""
        LbMinuta.Text = ""

        Me.ChkAgotarPpto.Checked = False
        Me.ChkUM.Checked = False
        Me.ChkEC.Checked = False

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
        Me.BtnDefinitivo.Visible = False
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
        UpdateTodaAcordeon()
    End Sub

    Public Sub Editar()
        MsgBoxLimpiar(MsgResult)
        Habilitar(True)
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
        UpdMinWord.Update()


    End Sub
    Sub Buscar(ByVal grupo As String)
        Dim dt As DataTable = obj.GetByPk(Me.TxtNprocA.Text, grupo) 'obj.GetByPk(Me.TxtNprocA.Text)
        If dt.Rows.Count > 0 Then
            'Me.TxtLugEje.Text=
            Me.TxtNPla.Text = dt.Rows(0)("NRO_PLA_CON").ToString
            Me.TxtNProc.Text = dt.Rows(0)("PRO_SEL_NRO").ToString
            Me.Pk1 = dt.Rows(0)("PRO_SEL_NRO").ToString
            Me.TxtObj.Text = dt.Rows(0)("obj_con").ToString
            Me.TxtPlazo.Text = dt.Rows(0)("PLA_EJE_CON").ToString
            'Me.TxtPro.Enabled = CStr(dt.Rows(0)("PRO_CON"))
            Me.CboInterventoria.SelectedValue = dt.Rows(0)("INTERVENTORIA").ToString

            'Me.TxtValTot.Text
            'Throw New Exception(dt.Rows(0)("VAL_CON").ToString)
            ValTot = dt.Rows(0)("VAL_CON").ToString.Replace(Publico.Punto_DecOracle, ".")
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
            If dt.Rows(0)("REVISADOPOR").ToString <> "" Then
                Me.CboRevPor.SelectedValue = dt.Rows(0)("REVISADOPOR").ToString
            End If
            Me.TxtLugEje.Text = dt.Rows(0)("LUG_EJE").ToString

            Me.LbEstado.Text = dt.Rows(0)("NOM_EST").ToString

            'Me.grdProy1.Num_Proc = dt.Rows(0)("PRO_SEL_NRO").ToString
            'Me.grdProy1.LlenarGrid()
            Me.grdObligGP1.Num_Proc = dt.Rows(0)("PRO_SEL_NRO").ToString
            Me.grdCDPGP1.Num_Proc = dt.Rows(0)("PRO_SEL_NRO").ToString
            Me.grdCDPGP1.Grupo = dt.Rows(0)("Grupo").ToString
            Me.grdObligGP1.Grupo = dt.Rows(0)("Grupo").ToString
            Me.ChkEC.Checked = Util.N1_0(dt.Rows(0)("EST_CONV").ToString)
            Me.ChkUM.Checked = Util.N1_0(dt.Rows(0)("URG_MAN").ToString)
            Me.TxtFecPago.Text = Today.ToShortDateString
            Me.TxtValSinIva.Text = dt.Rows(0)("VAL_SIN_IVA").ToString
            Me.TxtValIva.Text = dt.Rows(0)("VAL_IVA").ToString
            Me.TxtPlazo2.Text = dt.Rows(0)("PLAZO2_EJE_CON").ToString
            If dt.Rows(0)("TIPO_PLAZO").ToString <> "" Then
                Me.CboTPlazo.SelectedValue = dt.Rows(0)("TIPO_PLAZO").ToString
            End If

            If Me.CboTPlazo.SelectedValue <> "D" Then
                Me.CboTPlazo3.SelectedValue = dt.Rows(0)("TIPO_PLAZO2").ToString
            End If

            '11 JN 2011- BORIS
            Me.ChkAgotarPpto.Checked = Util.N1_0(dt.Rows(0)("AGOTAR_PPTO").ToString)
            Me.TxtConsiderandos.Text = dt.Rows(0)("considerandos").ToString
            '18 Jn 2011 BORIS
            Me.TxtAportes.Text = dt.Rows(0)("Aportes").ToString
            Me.TxtObsCDP.Text = dt.Rows(0)("Obs_CDP").ToString
            Me.TxtObsProy.Text = dt.Rows(0)("Obs_Proyectos").ToString
            Me.TxtObsPol.Text = dt.Rows(0)("Obs_Polizas").ToString

            
            'Me.grdOblig1.Enabled = Valor
            Me.grdCDPGP1.LlenarGrid()
            Me.grdObligGP1.LlenarGrid()
            'Me.grdCDP1.Enabled = Valor
            Me.Habilitar(False)
            Me.IBtnAbrir.Enabled = True
            Me.IbtnEditar.Enabled = True
            Me.IBtnGuardar.Enabled = False
            Me.IBtnCancelar.Enabled = False
            Me.BtnDefinitivo.Visible = False
            Me.BtnTramite.Visible = False
            Me.LblDef.Visible = False
            Me.LblTra.Visible = False
            Me.MsgResult.Text = ""
            Me.MsgResult.CssClass = ""
            UpdateTodaAcordeon()
            Grv_Ppol.DataBind()

            If dt.Rows(0)("ESTADO").ToString = "RA" Then
                Me.IbtnEditar.Enabled = False
                MsgResult.Text = " El Contrato ya esta Radicado "
                MsgBoxInfo(MsgResult, True)

            End If

        Else
            MsgResult.Text = " No se encontro el Proceso " + Me.TxtNprocA.Text + " a cargo del Usuario " + Usuarios.UserName
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub
    Public Sub Abrir()
        If TxtNprocA.Text <> "" And CboGrupos.SelectedValue <> "" Then
            Buscar(Me.CboGrupos.SelectedValue)
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
        Dim pcont As New GProcesos
        Dim dt As DataTable
        dt = pcont.GetByPk(TxtNProc.Text, CboGrupos.SelectedValue)
        If dt.Rows.Count > 0 Then
            Dim est As String = dt.Rows(0).Item("Estado").ToString
            If est = "TR" Then
                Editar()
                Me.BtnDefinitivo.Visible = True
                Me.BtnTramite.Visible = False
                Me.LblDef.Visible = True
                Me.LblTra.Visible = False
            Else 'If est = "DF" Then
                Me.BtnDefinitivo.Visible = False
                Me.BtnTramite.Visible = True
                Me.LblDef.Visible = False
                Me.LblTra.Visible = True
                Me.MsgResult.Text = "El proceso ya esta válidado y listo para Generar la Minuta y Radicar el Contrato, para modificarlo debe revertir la válidación"
                MsgBoxAlert(MsgResult, True)

            End If
        End If
    End Sub

    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        If Val(Me.TxtValTot.Text) < Val(Me.TxtValProp.Text) Then
            Me.MsgResult.Text = "El valor de los aportes propios no puede ser mayor que el valor del contrato"
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        If Val(Me.TxtValTot.Text) < Val(Me.TxtValSinIva.Text) Then
            Me.MsgResult.Text = "El valor sin IVA no puede ser mayor que el valor del contrato"
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
        Dim pproy As New GPProyectos
        MsgProy.Text = pproy.Insert(TxtProyecto.Text, TxtNProc.Text, CboGrupos.SelectedValue)
        Me.GrProyectos.DataBind()
    End Sub

    Protected Sub GrProyectos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrProyectos.RowCommand
        Select Case e.CommandName
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GrProyectos.SelectedIndex = index
                Dim pproy As New GPProyectos
                MsgProy.Text = pproy.Delete(Me.GrProyectos.DataKeys(index).Values(0).ToString, Me.GrProyectos.DataKeys(index).Values(1).ToString, CboGrupos.SelectedValue)
                GrProyectos.DataBind()
        End Select
    End Sub

    Protected Sub IbtnBucaRubro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnBucaRubro.Click
        Me.ModalPopupRubros.Show()
    End Sub
    '' RUBROS
    Protected Sub ConRubros1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConRubros1.SelClicked
        Txt_CodRub.Text = ConRubros1.Cod_Rub
        Txt_DesRub.Text = ConRubros1.Des_Rub
        CboCDP.DataBind()
        Me.ModalPopupRubros.Hide()
        UpdRubros.Update()
    End Sub
    Sub BuscarRubro()
        Dim t As New Rubros
        Dim dt As DataTable = t.GetbyPK(Me.Txt_CodRub.Text)
        If dt.Rows.Count > 0 Then
            Me.Txt_DesRub.Text = dt.Rows(0)("Des_Rub").ToString()
            Me.Txt_DesRub.Enabled = False
            Me.operRubro = False
        Else
            Me.Txt_DesRub.Text = ""
            If isInsertarRubro() Then
                Me.Txt_DesRub.Enabled = True
                Me.operRubro = True
            End If
            
        End If
    End Sub

    Function isInsertarRubro() As Boolean
        Return (operRubro And (Publico.InsRubro = "S"))
    End Function

    Protected Sub Txt_CodRub_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CodRub.TextChanged
        BuscarRubro()
    End Sub

    Protected Sub BtnGuardaRubro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardaRubro.Click
        If CboCDP.Items.Count = 0 Then
            MsgRubro.Text = "No existen certificados de disponibilidad"
            MsgBoxAlert(MsgRubro, True)
            Exit Sub
        End If
        If isInsertarRubro() And String.IsNullOrEmpty(Txt_DesRub.Text) Then
            MsgRubro.Text = "Nombre del Rubro Obligatorio"
            MsgBoxAlert(MsgRubro, True)
            Exit Sub
        End If

        Dim ObjRub As New Rubros_GProcesos
        Me.MsgRubro.Text = ObjRub.Insert(Me.Txt_CodRub.Text, Me.TxtNProc.Text, Publico.PuntoPorComa(Me.TxtValRub.Text), Me.CboCDP.SelectedValue, Me.CboGrupos.SelectedValue, operRubro, Txt_DesRub.Text)
        MsgBox(MsgRubro, ObjRub.lErrorG)
        Me.GrRubros.DataBind()
        LimpiarRubros()

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
                MsgRubro.Text = objRubro.Delete(Me.GrRubros.DataKeys(index).Values(0).ToString, Me.GrRubros.DataKeys(index).Values(1).ToString, Me.CboGrupos.SelectedValue)
                MsgBox(MsgRubro, objRubro.lErrorG)
                GrRubros.DataBind()
        End Select
    End Sub

    Protected Sub BtnGuardarPago_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardarPago.Click
        If GuardarFP = "Nuevo" Then
            If IsDate(Me.TxtFecPago.Text) And IsNumeric(Me.TxtValPago.Text) Then
                Dim pp As New Pagos_Gprocesos
                Me.MsgPagos.Text = pp.Insert(Me.TxtNProc.Text, Me.TxtFecPago.Text, Me.CboTipPago.SelectedValue, Publico.PuntoPorComa(Me.TxtValPago.Text), Me.TxtCondicionPago.Text, RbtPorcentaje.Checked, Me.CboGrupos.SelectedValue, Util.invN1_0(ChkPagGober.Checked))
                GrPagos.DataBind()
                If pp.lErrorG = False Then
                    limpiarPagos()
                End If
                MsgBox(MsgPagos, pp.lErrorG)
            Else
                Me.fechavalida.Text = "Fecha Inválida"
                MsgBoxAlert(Me.fechavalida, True)
            End If
        ElseIf GuardarFP = "Editar" Then
            If IsDate(Me.TxtFecPago.Text) And IsNumeric(Me.TxtValPago.Text) Then
                Dim pp As New Pagos_Gprocesos
                'Me.MsgPagos.Text = pp.Delete(ID_FP, TxtNprocA.Text, CboGrupos.SelectedValue)
                Me.MsgPagos.Text = pp.Update(ID_FP, Me.TxtNprocA.Text, Me.TxtFecPago.Text, Me.CboTipPago.SelectedValue, Publico.PuntoPorComa(Me.TxtValPago.Text), Me.TxtCondicionPago.Text, RbtPorcentaje.Checked, Me.CboGrupos.SelectedValue, Util.invN1_0(ChkPagGober.Checked))
                MsgBox(MsgPagos, pp.lErrorG)
                GrPagos.DataBind()
                If pp.lErrorG = False Then
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
                MsgPagos.Text = pp.Delete(Me.GrPagos.DataKeys(index).Values(0).ToString, Me.GrPagos.DataKeys(index).Values(1).ToString, CboGrupos.SelectedValue)
                MsgBox(MsgPagos, pp.lErrorG)
                GrPagos.DataBind()
                GuardarFP = "Nuevo"
            Case "Editar"
                Me.MsgPagos.Text = "Editando"
                Me.MsgBoxInfo(MsgPagos, True)
                ID_FP = Me.GrPagos.DataKeys(index).Values(0).ToString
                Dim dtPagos As DataTable = pp.GetbyPk(Me.GrPagos.DataKeys(index).Values(0).ToString, Me.GrPagos.DataKeys(index).Values(1).ToString, CboGrupos.SelectedValue)

                Me.CboTipPago.SelectedValue = dtPagos.Rows(0)("Tipo_pago")
                Me.TxtFecPago.Text = dtPagos.Rows(0)("Fecha_Pago")
                Me.TxtCondicionPago.Text = dtPagos.Rows(0)("Condicion_Pago")
                Me.TxtValPago.Text = CDec(dtPagos.Rows(0)("Porcentaje") * 100).ToString.Replace(",", ".") ' 
                Me.RbtValPago.Checked = True
                ChkPagGober.Checked = Util.N1_0(dtPagos.Rows(0)("Paga_Gober"))
                ' Publico.PuntoPorComa(Me.TxtValPago.Text), Me.TxtCondicionPago.Text, RbtPorcentaje.Checked, Me.CboGrupos.SelectedValue)


        End Select
    End Sub

    Protected Sub grdCDP1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCDPGP1.SelClicked
        Me.CboCDP.DataBind()
        Me.GrRubros.DataBind()
        Me.UpdRubros.Update()
    End Sub
    Sub limpiarPagos()
        Me.TxtValPago.Text = ""
        Me.TxtFecPago.Text = Today.ToShortDateString
        Me.TxtCondicionPago.Text = ""
    End Sub

    Protected Sub BtnDefinitivo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnDefinitivo.Click
        Dim pcont As New GProcesos
        MsgResult.Text = pcont.Definitivo(TxtNProc.Text, CboGrupos.SelectedValue)
        MsgBox(MsgResult, pcont.lErrorG)
        If Not pcont.lErrorG Then
            Habilitar(False)
        End If

    End Sub

    Protected Sub BtnTramite_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnTramite.Click
        Dim pcont As New GProcesos
        MsgResult.Text = pcont.Tramite(TxtNProc.Text, CboGrupos.SelectedValue)
        MsgBox(MsgResult, pcont.lErrorG)
        If Not pcont.lErrorG Then
            Habilitar(False)
        End If
    End Sub

    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        Me.TxtNprocA.Text = ConPContratos1.Num_Proc
        Buscar("1")
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
            Dim ppol As New GPPolizas
            MsgPol.Text = ppol.Insert(CboAmparo.SelectedValue, TxtNProc.Text, TxtSMMLV.Text, CboCalPol.SelectedValue, TxtVigencia.Text, CboCalVigPol.SelectedValue, cboTipo.SelectedValue, CboGrupos.SelectedValue)
            If ppol.lErrorG = False Then
                Me.Grv_Ppol.DataBind()
                Me.TxtVigencia.Text = ""
                Me.TxtSMMLV.Text = ""
                Me.CboCalVigPol.SelectedIndex = 0
                Me.CboCalPol.SelectedIndex = 0
                Me.CboAmparo.SelectedIndex = 0
            End If
            MsgBox(MsgPol, ppol.lErrorG)
        End If
    End Sub

    Protected Sub Grv_Ppol_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grv_Ppol.RowCommand
        Select Case e.CommandName
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.Grv_Ppol.SelectedIndex = index
                Dim ppol As New GPPolizas
                MsgRubro.Text = ppol.Delete(Me.Grv_Ppol.DataKeys(index).Values(0).ToString, Me.Grv_Ppol.DataKeys(index).Values(1).ToString, Me.CboGrupos.SelectedValue)
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
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Center

            Case DataControlRowType.DataRow

                Me.TotalFP += CDec(DataBinder.Eval(e.Row.DataItem, "VALOR_PAGO"))
                Me.TotalPor += CDec(DataBinder.Eval(e.Row.DataItem, "PORCENTAJE"))

                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right

            Case DataControlRowType.Footer
                e.Row.Cells(2).Text = FormatCurrency(Me.TotalFP.ToString, 3)
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                e.Row.Cells(3).Text = FormatPercent(Me.TotalPor.ToString, 3)
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub CboGrupos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboGrupos.SelectedIndexChanged
        Abrir()
    End Sub

    Protected Sub TxtNprocA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNprocA.TextChanged
        Buscar("1")
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
        'LbValTot.Text = FormatCurrency(TxtValTot.Text.Replace(".", ","))
        If String.IsNullOrEmpty(TxtValTot.Text) Then
            TxtValTot.Text = 0
        End If
        TxtValProp.Text = TxtValTot.Text
        TxtValOtros.Text = 0

    End Sub

    Protected Sub TxtValProp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValProp.TextChanged
        'LbValProp.Text = FormatCurrency(TxtValProp.Text.Replace(".", ","))
        Dim AportesOtros As Decimal = (CDec(TxtValTot.Text.Replace(".", ",")) - CDec(TxtValProp.Text.Replace(".", ",")))
        TxtValOtros.Text = AportesOtros.ToString.Replace(",", ".")
        TxtValOtros.ForeColor = Drawing.Color.Black
        If AportesOtros < 0 Then
            TxtValOtros.ForeColor = Drawing.Color.Red
            'LbValOtros.Text = "Valor Incoherente, por favor corrija"
            'LbValOtros.ForeColor = Drawing.Color.Red
            TxtValTot.Focus()
        Else
            'MsgBoxLimpiar(LbValOtros)
            'LbValOtros.ForeColor = Drawing.Color.Black
            TxtValOtros.ForeColor = Drawing.Color.Black
            'LbValOtros.Text = FormatCurrency(TxtValOtros.Text.Replace(".", ","))
        End If

    End Sub

    Protected Sub GrdMin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdMin.SelectedIndexChanged
        If Me.TxtNprocA.Text = Me.TxtNProc.Text Then
            Redireccionar_Pagina("/ashx/VerMinuta.ashx?Num_Proc=" + Me.TxtNprocA.Text + "&Grupo=" + Me.CboGrupos.SelectedValue + "&ID=" + GrdMin.SelectedValue.ToString)
        Else
            LbMinuta.Text = "Debe presionar el botón abrir"
            MsgBoxAlert(LbMinuta, True)

        End If

    End Sub

    Protected Sub BtnGen_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGen.Click
        Dim pcont As New GProcesos
        Dim dt As DataTable
        dt = pcont.GetByPk(TxtNProc.Text, CboGrupos.SelectedValue)
        Dim est As String = dt.Rows(0).Item("Estado").ToString
        MsgBoxLimpiar(MsgResult)
        MsgBoxLimpiar(LbMinuta)
        If est = "TR" Then
            Me.MsgResult.Text = "El proceso no se encuentra validado para generar MINUTA"
            LbMinuta.Text = Me.MsgResult.Text
            MsgBoxAlert(MsgResult, True)
            MsgBoxAlert(LbMinuta, True)
        Else
            Dim GM As New GMinuta
            GM.operacion = GMinuta.eoperacion.Generar
            GM.Num_Proc = Me.TxtNprocA.Text
            GM.Grupo = Me.CboGrupos.SelectedValue
            GM.Ide_Pla = Me.CboPlantilla.SelectedValue
            GM.GenerarMinuta()
            Me.TxtLog.Text = GM.Ultimo_Msg.Replace("<br>", vbCrLf)
            GrdMin.DataBind()
        End If
    End Sub
    Protected Sub GrdMin_Ppol_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdMin.RowCommand
        Select Case e.CommandName
            Case "Inhabilitar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GrdMin.SelectedIndex = index
                Dim objMin As New PGContratosM
                LbMinuta.Text = objMin.Anular(Me.TxtNprocA.Text, Me.CboGrupos.SelectedValue, Me.GrdMin.DataKeys(index).Values(0).ToString)
                MsgBox(LbMinuta, objMin.lErrorG)
                GrdMin.DataBind()
                UpdMin.Update()
            Case "Inhabilitar"

        End Select
    End Sub

    Protected Sub ChkLog_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLog.CheckedChanged
        If ChkLog.Checked = True Then
            Me.TxtLog.visible = True
        Else
            Me.TxtLog.visible = False
        End If
    End Sub

    Protected Sub IBtnProp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnProp.Click
        Redireccionar_Pagina("/Procesos/GPProponentes/GPProponentes.aspx?Num_Proc=" + Me.TxtNProc.Text + "&Grupo=" + Me.CboGrupos.SelectedValue)
    End Sub

    Protected Sub IBtnAdj_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAdj.Click
        Redireccionar_Pagina("/Procesos/GAdjudicacion/GAdjudicacion.aspx?Num_Proc=" + Me.TxtNProc.Text + "&Grupo=" + Me.CboGrupos.SelectedValue)
    End Sub

    Protected Sub IBtnItemO_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnItemO.Click
        Redireccionar_Pagina("/Procesos/GProcesosN/ItemObjeto.aspx?Num_Proc=" + Me.TxtNProc.Text + "&Grupo=" + Me.CboGrupos.SelectedValue)
    End Sub

    Protected Sub IBtnAnular_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAnular.Click
        Dim objMin As New PGContratosM
        LbMinutaW.Text = objMin.AnularAC(Me.TxtNprocA.Text, Me.CboGrupos.SelectedValue)
        MsgBox(LbMinutaW, objMin.lErrorG)
        GrdMin.DataBind()
        UpdMin.Update()
    End Sub
End Class
