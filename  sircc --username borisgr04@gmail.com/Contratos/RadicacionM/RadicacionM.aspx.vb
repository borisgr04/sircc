Imports System.Data
Imports System.Threading

Partial Class Contratos_RadicacionM_Default
    Inherits PaginaComun
    Dim _tip_rad As Boolean

    Property tipo_rad() As Boolean
        Get
            Return ViewState("_tipo_rad")
        End Get
        Set(ByVal value As Boolean)
            ViewState("_tipo_rad") = value
        End Set
    End Property

    Sub Guardar()
        If Oper = "editar" Then
            Me.Actualizar()
        Else
            Me.Radicar()
        End If
    End Sub

    Protected Sub Radicar()
        Dim obj As New Contratos()

        Dim chk As New CheckBox, txt As New TextBox
        Dim j As String = 0, mun(25) As String, i As Integer
        'Municipios
        For i = 0 To DataList1.Items.Count - 1
            chk = DataList1.Items(i).FindControl("chknommun")
            txt = DataList1.Items(i).FindControl("txtcodmun")
            If chk.Checked = True Then
                mun(j) = txt.Text
                j = j + 1
            End If
        Next

        Dim vigencia As Integer = Me.Vigencia_Cookie
        If Me.tipo_rad = True Then
            ' si se genera numero de radicaicon automatico
            MsgResult.Text = obj.Insert(vigencia, TxtIde.Text, TxtObj.Text, TxtPro.Text, CDate(TxtFsus.Text), Val(TxtPla.Text), CboDep.Text, cboStip.Text, CboTip.Text, Me.valor_dec(TxtVal.Text), mun, j - 1, CboSec.Text, CboFor.Text, TxtCsor.Text, CboTproc.Text, Me.TxtPlapre.Text, Me.TxtIdeRlc.Text, Me.ChkUM.Checked, Me.ChkEC.Checked, Me.TxtNProc.Text, Me.CboDepP.SelectedValue, Me.valor_dec(TxtValProp.Text), Me.ChkAnticipo.Checked, CInt(Me.TxtNEmpleos.Text), Me.ChkApo.Checked, Me.ChkAgotarPpto.Checked, Me.TxtPlazo2.Text, CboTPlazo.Text, CboTPlazo3.Text)
        Else
            If String.IsNullOrEmpty(TxtCodCon.Text) Then
                MsgResult.Visible = True
                MsgResult.Text = "Digite Número de Contrato"
                Exit Sub
            End If
            If (CInt(TxtCodCon.Text) > 0) And (CInt(TxtCodCon.Text) < 9999) Then
                'si numeracion es manual
                ' MsgResult.Text = obj.Insert(CInt(TxtCodCon.Text), vigencia, TxtIde.Text, TxtObj.Text, TxtPro.Text, CDate(TxtFsus.Text), Val(TxtPla.Text), CboDep.Text, cboStip.Text, CboTip.Text, Me.valor_dec(TxtVal.Text), mun, j - 1, CboSec.Text, CboFor.Text, TxtCsor.Text, CboTproc.Text, Me.TxtPlapre.Text, Me.TxtIdeRlc.Text, Me.ChkUM.Checked, Me.ChkEC.Checked, Me.TxtNProc.Text, Me.CboDepP.SelectedValue, Me.valor_dec(Me.TxtValProp.Text))
            End If
        End If

        If obj.lErrorG = False Then
            'LimpiarTxt()
            Me.TxtUId.Text = obj.Cod_Con.ToString
            Me.TxtCodCon.Text = obj.Cod_Con.ToString
            Me.IBtnGuardar.Enabled = False
            Me.IBtnCancelar.Enabled = False
            Me.IBtnAbrir.Enabled = True
            Abrir()
        End If
        MsgResult.Visible = True

        MsgBox(MsgResult, obj.lErrorG) 'Cóloca stilo al label según el error



    End Sub

    'Se agrego campo Dependencia Proceso Contractual
    '31 de Agosto de 2010
    'Ing Boris Gonzalez Rivera
    Protected Sub LimpiarTxt()


        Me.TxtIde.Text = ""
        Me.TxtCodCon.Text = ""
        Me.TxtNom.Text = ""
        Me.TxtObj.Text = ""
        Me.TxtPla.Text = 0
        Me.TxtPro.Text = ""
        Me.TxtVal.Text = 0
        Me.TxtCsor.Text = ""
        Me.TxtNomRlc.Text = ""
        Me.TxtIdeRlc.Text = ""
        Me.TxtPlapre.Text = ""

        Me.ChkEC.Checked = False
        Me.ChkUM.Checked = False

        Me.CboTip.Enabled = True
        CboDep.SelectedIndex = 0
        CboDepP.SelectedIndex = 0

        CboTproc.SelectedIndex = 0
        CboSec.SelectedIndex = 0

        Me.TxtValProp.Text = 0
        Me.TxtValOtros.Text = 0
        Me.MsgResult.Visible = False
        Me.grdCDPC1.Visible = False
        Me.grdProyC1.Visible = False

        '25 DE ENERO
        Me.ChkAgotarPpto.Checked = False
        Me.ChkAnticipo.Checked = False
        Me.ChkApo.Checked = False

        MostrarUId("02")

        Me.TxtNEmpleos.Text = 0
    End Sub

    Protected Sub Editar(ByVal V As Boolean)


        Me.TxtIde.Enabled = V
        ' Me.txtncp.Enabled = V
        Me.TxtNom.Enabled = V
        Me.TxtObj.Enabled = V
        Me.TxtPla.Enabled = V
        Me.TxtPro.Enabled = V
        Me.ChkEC.Enabled = V
        Me.ChkUM.Enabled = V
        Me.BtnBCon.Enabled = V
        Me.BtnBRlc.Enabled = V

        Me.TxtVal.Enabled = V
        Me.TxtIdeRlc.Enabled = V
        Me.CboTip.Enabled = False
        'Me.BtnAct.Enabled = V
        Me.TxtNomRlc.Enabled = V
        Me.TxtNProc.Enabled = V

        Me.DataList1.Enabled = V

        Me.TxtPlapre.Enabled = V
        Me.cboStip.Enabled = V
        TxtFsus.Enabled = V
        CboSec.Enabled = V
        CboFor.Enabled = V
        CboTproc.Enabled = V
        Me.CboDep.Enabled = V
        Me.CboDepP.Enabled = V
        Me.TxtCsor.Enabled = V
        TxtPlazo2.Enabled = V
        CboTPlazo.Enabled = V
        CboTPlazo3.Enabled = V

        '2 SEPT 2010, BORIS GONZALEZ
        Me.TxtValProp.Enabled = V
        '13 de enero de 2011 , Boris G.
        Me.TxtValOtros.Enabled = False


        Me.grdCDPC1.Enabled = V
        Me.grdProyC1.Enabled = V

        '25 de enero de 2010
        Me.ChkAnticipo.Enabled = V
        Me.ChkApo.Enabled = V
        Me.TxtNEmpleos.Enabled = V
        Me.ChkAgotarPpto.Enabled = V



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("es-CO")
        If Not Page.IsPostBack Then
            Me.Editar(False)
            'Tabla de CDP
            MostrarUId("02")
            Me.CboTip.Enabled = True
            Me.TxtVal.Attributes.Add("onkeypress", "javascript:Solo_Numeros();")
            Me.TxtValProp.Attributes.Add("onkeypress", "javascript:Solo_Numeros();")

            'Me.TxtVal.Attributes.Add("onfocusout", "javascript:ValProp();")
            Me.TxtVal.Attributes.Add("onblur", "javascript:CValProp();")
            
            'Me.TxtObj.Attributes.Add("onkeypress", "javascript:mayusculas(this);")
            'Me.TxtObj.Attributes.Add("onblur", "javascript:mayusculas(this);")
            Me.TxtValProp.Attributes.Add("onblur", "javascript:CValOtros();")

        End If
    End Sub

    Protected Sub MostrarUId(ByVal tip As String)
        Dim obj As Contratos = New Contratos()
        Dim fec_sus As Date
        Me.TxtUId.Text = obj.UltId(tip, Vigencia_Cookie, fec_sus)
        Me.TxtFsus.Text = fec_sus.ToShortDateString
        Me.TxtUFs.Text = fec_sus.ToLongDateString
    End Sub




    Protected Sub CboTip_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTip.SelectedIndexChanged
        MostrarUId(Me.CboTip.Text)

    End Sub

    Protected Sub IbtnAbrir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnAbrir.Click
        Abrir()
    End Sub

    Sub Abrir()
        Dim obj As Contratos = New Contratos()
        Dim dt As DataTable
        If Me.TxtCodCon.Text.Length <> 8 Then
            Me.TxtCodCon.Text = obj.GetCodigo(Me.CboTip.SelectedValue, Me.TxtCodCon.Text, Vigencia_Cookie)
        End If
        dt = obj.GetByPk(Me.TxtCodCon.Text)

        If dt.Rows.Count > 0 Then
            Me.TxtObj.Text = dt.Rows(0)("obj_con").ToString
            Me.TxtIde.Text = dt.Rows(0)("ide_con").ToString
            Me.TxtIdeRlc.Text = dt.Rows(0)("ide_rep").ToString
            Me.TxtCsor.Text = dt.Rows(0)("otr_cns").ToString
            Me.TxtPla.Text = dt.Rows(0)("pla_eje_con").ToString
            Me.TxtPlapre.Text = dt.Rows(0)("nro_pla_con").ToString
            Me.CboTip.Enabled = False
            Me.CboTip.SelectedValue = dt.Rows(0)("tip_con").ToString
            Me.cboStip.DataBind()
            Me.cboStip.SelectedValue = dt.Rows(0)("stip_con").ToString
            TxtPro.Text = dt.Rows(0)("pro_con").ToString
            TxtFsus.Text = CDate(dt.Rows(0)("fec_sus_con")).ToShortDateString
            CboDep.SelectedValue = dt.Rows(0)("dep_con").ToString
            CboDepP.SelectedValue = dt.Rows(0)("dep_pcon").ToString
            TxtVal.Text = dt.Rows(0)("val_con").ToString.Replace(",", ".")
            CboSec.SelectedValue = dt.Rows(0)("cod_sec").ToString
            CboFor.SelectedValue = dt.Rows(0)("tip_for").ToString
            CboTproc.SelectedValue = dt.Rows(0)("cod_tpro").ToString
            Me.TxtNom.Text = dt.Rows(0)("contratista").ToString
            Me.TxtNomRlc.Text = dt.Rows(0)("rep_legal").ToString
            Me.TxtNProc.Text = dt.Rows(0)("pro_sel_nro").ToString
            Me.TxtValProp.Text = dt.Rows(0)("val_apo_gob").ToString.Replace(",", ".")
            Me.TxtValOtros.Text = dt.Rows(0)("val_otros").ToString.Replace(",", ".")
            Me.ChkEC.Checked = IIf(dt.Rows(0)("EST_CONV").ToString = "1", True, False)
            Me.ChkUM.Checked = IIf(dt.Rows(0)("URG_MAN").ToString = "1", True, False)
            '25 DE ENERO 2011
            Me.ChkAnticipo.Checked = IIf(dt.Rows(0)("ANTICIPO").ToString = "1", True, False)
            Me.ChkApo.Checked = IIf(dt.Rows(0)("PER_APO").ToString = "1", True, False)
            Me.TxtNEmpleos.Text = dt.Rows(0)("NEMPLEOS").ToString.Replace(",", ".")

            Me.CboTPlazo.Text = dt.Rows(0)("TIPO_PLAZO").ToString

            If Not (DBNull.Value Is dt.Rows(0)("TIPO_PLAZO2")) Then
                Me.CboTPlazo3.Text = dt.Rows(0)("TIPO_PLAZO2").ToString
                Me.TxtPlazo2.Text = dt.Rows(0)("PLAZO2_EJE_CON").ToString
            Else
                Me.TxtPlazo2.Text = 0

            End If

            Me.ChkAgotarPpto.Enabled = IIf(dt.Rows(0)("AGOTAR_PPTO").ToString = "1", True, False)

            'Me.BtnAct.Enabled = False
            Me.Editar(False)
            MsgResult.Visible = False
            Me.IBtnGuardar.Enabled = False
            If dt.Rows(0)("Tip_Radicacion").ToString = "A" Then
                Me.IBtnEditar.Enabled = False
            Else
                Me.IBtnEditar.Enabled = True
            End If

            Me.IBtnCancelar.Enabled = True
            Me.IBtnNuevo.Enabled = True

            Me.grdProyC1.Visible = True
            Me.grdProyC1.Cod_Con = dt.Rows(0)("Numero").ToString
            Me.grdProyC1.LlenarGrid()


            Me.grdCDPC1.Visible = True
            Me.grdCDPC1.Cod_Con = dt.Rows(0)("Numero").ToString
            Me.grdCDPC1.LlenarGrid()
        Else
            Me.LimpiarTxt()
            MsgResult.Text = "No se encontró en la Base de Datos el Contrato/Convenio Buscado"
            MsgBox(Me.MsgResult, True)
            MsgResult.Visible = True
            Me.IBtnEditar.Enabled = False
            Me.TxtCodCon.Focus()
            Me.IBtnCancelar.Enabled = False
        End If
    End Sub

    Sub Nuevo()
        Me.LimpiarTxt()
        Me.Editar(True)
        'Me.BtnAct.Enabled = False
        Me.CboTip.Enabled = True
        Me.IBtnEditar.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnCancelar.Enabled = True
        Me.DataList1.DataBind()
        MostrarUId(Me.CboTip.SelectedValue)
        Dim objV As New Vigencias
        Me.tipo_rad = objV.GetTipo_Radicación(Me.Vigencia_Cookie)
        If Me.tipo_rad = True Then
            Me.TipoRad.Text = "EL Número de Radicacón lo Genera el Sistema de Forma Automática "
        Else
            Me.TipoRad.Text = "La Númeración es manual, Por favor Digite el número de Radicación en la Casilla N° de Contrato "
        End If
        Oper = "nuevo"
        BtnGuardar_ConfirmButtonExtender.ConfirmText = "Confirme FECHA DE SUSCRIPCIÓN. ¿Desea Radicar el Contrato/Convenio?"
    End Sub
    

    
    Private Function valor_dec(ByVal v As String) As Decimal
        Return v.Replace(".", ",")
    End Function

    Sub Actualizar()
        Dim obj As New Contratos()

        Dim chk As New CheckBox, txt As New TextBox
        Dim j As String = 0, mun(25) As String
        'Municipios
        For i = 0 To DataList1.Items.Count - 1
            chk = DataList1.Items(i).FindControl("chknommun")
            txt = DataList1.Items(i).FindControl("txtcodmun")
            If chk.Checked = True Then
                mun(j) = txt.Text
                j = j + 1
            End If
        Next
        MsgResult.Text = obj.UpdateP(Me.TxtCodCon.Text, TxtIde.Text, TxtObj.Text, TxtPro.Text, CDate(TxtFsus.Text), Val(TxtPla.Text), CboDep.Text, cboStip.Text, CboTip.Text, Me.valor_dec(TxtVal.Text), mun, j - 1, CboSec.Text, CboFor.Text, TxtCsor.Text, CboTproc.Text, Me.TxtPlapre.Text, Me.TxtIdeRlc.Text, Me.ChkUM.Checked, Me.ChkEC.Checked, Me.TxtNProc.Text, Me.CboDepP.SelectedValue, Me.valor_dec(Me.TxtValProp.Text), ChkAnticipo.Checked, Me.TxtNEmpleos.Text, Me.ChkApo.Checked, Me.ChkAgotarPpto.Checked, Me.TxtPlazo2.Text, CboTPlazo.Text, CboTPlazo3.Text)
        If obj.lErrorG = False Then
            Me.TxtUId.Text = obj.Cod_Con.ToString
            Oper = ""
        Else

        End If
        MsgBox(MsgResult, obj.lErrorG)
        MsgResult.Visible = True

    End Sub
    
    Protected Sub iBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnCancelar.Click
        Me.Editar(False)
        Me.LimpiarTxt()
        Me.IBtnCancelar.Enabled = False
        Me.IBtnGuardar.Enabled = False
        Me.IBtnEditar.Enabled = False
        Oper = ""
    End Sub

    Sub VerModalPopup(ByVal Tipo As String)
        AdmTercero1.tipoter = Tipo
        Me.ModalPopup.Show()
    End Sub



    Protected Sub TxtIde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIde.TextChanged
        BuscarContratista()
    End Sub

    Sub BuscarContratista()
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.TxtIde.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNom.Text = dt.Rows(0)("Nom_Ter").ToString()
            TxtIdeRlc.Text = Me.TxtIde.Text
            Me.TxtNomRlc.Text = dt.Rows(0)("Nom_Ter").ToString()
            Me.MsgResult.Text = ""
        Else
            Me.MsgResult.Text = "No encontro el Tercero"
            MsgBox(MsgResult, False)
            VerModalPopup("CON")
        End If
    End Sub
    Sub BuscarRlc()
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.TxtIdeRlc.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNomRlc.Text = dt.Rows(0)("Nom_Ter").ToString()
            Me.MsgResult.Text = ""
        Else
            Me.MsgResult.Text = "No encontro el Tercero"
            MsgBox(MsgResult, False)
            VerModalPopup("RLC")
        End If
    End Sub
    Protected Sub TxtCodCon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodCon.TextChanged
        Abrir()
    End Sub

    Protected Sub BtnBCon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBCon.Click
        VerModalPopup("CON")
    End Sub
    'Protected Sub CTerceros1_OnSelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CTerceros1.SelClicked
    '    'Me.ModalPopup.Hide()
    '    'If CTerceros1.Tipo = "CON" Then
    '    '    Me.TxtIde.Text = CTerceros1.Nit
    '    '    BuscarContratista()
    '    'ElseIf CTerceros1.Tipo = "RLC" Then
    '    '    Me.TxtIdeRlc.Text = CTerceros1.Nit
    '    '    BuscarRlc()
    '    'End If
    'End Sub

    'OnSelClicked="CTerceros1_OnSelClicked"

    Protected Sub TxtIdeRlc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIdeRlc.TextChanged
        BuscarRlc()
    End Sub

    Protected Sub BtnBRlc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBRlc.Click
        VerModalPopup("RLC")

    End Sub


    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + "Ajax"
        End If
    End Sub

    Protected Sub AdmTercero1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdmTercero1.SelClicked
        If AdmTercero1.tipoter = "CON" Then
            TxtIde.Text = AdmTercero1.Nit
            BuscarContratista()
        ElseIf AdmTercero1.tipoter = "RLC" Then
            TxtIdeRlc.Text = AdmTercero1.Nit
            BuscarRlc()
        End If
        
        ModalPopup.Hide()
    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim strjscript As String = "function CValOtros(){"
        strjscript = strjscript & "Vdoc=document.getElementById ('" + Me.TxtVal.ClientID + "').value;"
        strjscript = strjscript & "ValProp=document.getElementById ('" + Me.TxtValProp.ClientID + "').value;"

        strjscript = strjscript & "Vdoc = (parseFloat(Vdoc)).toFixed(2);"
        'strjscript = strjscript & "alert('Valor Doc'+Vdoc); "

        strjscript = strjscript & "ValProp = (parseFloat(ValProp)).toFixed(2);"
        'strjscript = strjscript & "alert('Valor Prop'+ValProp); "

        strjscript = strjscript & "if ( (Vdoc - ValProp) <0) {"
        'strjscript = strjscript & "if ( Vdoc < ValProp) {"
        strjscript = strjscript & "  ValProp=Vdoc;"
        strjscript = strjscript & "  alert('El Valor del Aporte Propio debe ser menor o igual al valor Total del Contrato');"
        strjscript = strjscript & "  ValProp=Vdoc;"
        strjscript = strjscript & "}"
        strjscript = strjscript & "  VOtros=Vdoc - ValProp;"
        strjscript = strjscript & " document.getElementById('" + Me.TxtValProp.ClientID + "').value=(parseFloat(ValProp)).toFixed(2);"
        strjscript = strjscript & " document.getElementById('" + Me.TxtValOtros.ClientID + "').value=(parseFloat(VOtros)).toFixed(2);"
        strjscript = strjscript & " document.getElementById('" + Me.TxtVal.ClientID + "').value=(parseFloat(Vdoc)).toFixed(2);"
        strjscript = strjscript & "}"
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "CValOtros", strjscript, True)


        strjscript = "function CValProp() { "
        strjscript = strjscript & " Vdoc=document.getElementById ('" + Me.TxtVal.ClientID + "').value;"
        strjscript = strjscript & " Vdoc = (parseFloat(Vdoc)).toFixed(2);"
        strjscript = strjscript & " ValProp=Vdoc;"
        strjscript = strjscript & " VOtros=Vdoc - ValProp;"
        strjscript = strjscript & " document.getElementById('" + Me.TxtValProp.ClientID + "').value=(parseFloat(ValProp)).toFixed(2);"
        strjscript = strjscript & " document.getElementById('" + Me.TxtValOtros.ClientID + "').value=(parseFloat(VOtros)).toFixed(2);"
        strjscript = strjscript & " document.getElementById('" + Me.TxtVal.ClientID + "').value=(parseFloat(Vdoc)).toFixed(2);"
        strjscript = strjscript & "}"
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "CValProp", strjscript, True)
    End Sub

    Protected Sub TxtVal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVal.TextChanged
        LbValTot.Text = FormatCurrency(TxtVal.Text.Replace(".", ","))
    End Sub

    Protected Sub TxtValProp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtValProp.TextChanged
        LbValProp.Text = FormatCurrency(TxtValProp.Text.Replace(".", ","))
        Dim AportesOtros As Decimal = (CDec(TxtVal.Text.Replace(".", ",")) - CDec(TxtValProp.Text.Replace(".", ",")))
        TxtValOtros.Text = AportesOtros.ToString.Replace(",", ".")
        If AportesOtros < 0 Then
            TxtValOtros.ForeColor = Drawing.Color.Red
            LbValOtros.Text = "Valor Incoherente, por favor corrija"
            LbValOtros.ForeColor = Drawing.Color.Red
            TxtVal.Focus()
        Else
            MsgBoxLimpiar(LbValOtros)
            LbValOtros.ForeColor = Drawing.Color.Black
            TxtValOtros.ForeColor = Drawing.Color.Black
            LbValOtros.Text = FormatCurrency(TxtValOtros.Text.Replace(".", ","))


        End If
    End Sub

    Protected Sub IBtnEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnEditar.Click
        Me.Editar(True)
        Me.IBtnCancelar.Enabled = True
        Me.TxtFsus.Enabled = False
        IBtnGuardar.Enabled = True
        Me.Oper = "editar"

        BtnGuardar_ConfirmButtonExtender.ConfirmText = "Confirme FECHA DE SUSCRIPCIÓN. ¿Desea Actualizar el Contrato/Convenio? "
    End Sub

    
    Protected Sub IBtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        Nuevo()
    End Sub

    Protected Sub iBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Guardar()
    End Sub
End Class

