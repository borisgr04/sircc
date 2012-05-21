Imports System.Data
Imports System.IO

Partial Class Procesos_DBProceso_Default
    Inherits PaginaComun
    Dim obj As PContratos = New PContratos


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

    Public Sub Guardar()
        obj = New PContratos
        'Me.MsgResult.Text = Me.valor_dec(Me.TxtValTot.Text)
        Dim chk As New CheckBox, txt As New TextBox
        Dim j As String = 0, mun(25) As String
        'Municipios
        'For i = 0 To DataList1.Items.Count - 1
        '    chk = DataList1.Items(i).FindControl("chknommun")
        '    txt = DataList1.Items(i).FindControl("txtcodmun")
        '    If chk.Checked = True Then
        '        mun(j) = txt.Text
        '        j = j + 1
        '    End If
        'Next
        Select Case Me.Oper
            Case "nuevo"
                'Me.MsgResult.Text = obj.Insert(Me.CboTproc.SelectedValue, Me.TxtNProc.Text, Me.TxtObj.Text, "", Me.TxtNPla.Text, Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, Me.Vigencia.ToString, Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, Publico.PuntoPorComa(Me.TxtValTot.Text), Publico.PuntoPorComa(Me.TxtValProp.Text), Me.CboSec.SelectedValue, Me.CboFor.SelectedValue, Me.TxtNPla.Text, Util.invN1_0(ChkUM.Checked), Util.invN1_0(ChkEC.Checked), "0", Me.TxtLugEje.Text, Me.CboTPlazo.SelectedValue)
            Case "editar"
                Me.MsgResult.Text = obj.Update(Me.Pk1, Me.CboTproc.SelectedValue, Me.TxtNProc.Text, Me.TxtObj.Text, "", Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, Me.Vigencia.ToString, Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, Publico.PuntoPorComa(Me.TxtValTot.Text), Publico.PuntoPorComa(Me.TxtValProp.Text), Me.TxtNPla.Text, "0", TxtNumGrupos.Text)
        End Select
        MsgBox(MsgResult, obj.lErrorG)
        If obj.lErrorG = False Then
            Me.Habilitar(False)
            Me.IBtnCancelar.Enabled = False
            Me.IBtnNuevo.Enabled = True
            Me.IBtnGuardar.Enabled = False
            Me.IBtnAbrir.Enabled = True
            
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            Me.TxtValTot.Attributes.Add("onkeyup", "javascript:AporOtros();")
            Me.TxtValProp.Attributes.Add("onkeyup", "javascript:AporOtros();")
            Me.TxtValOtros.Attributes.Add("onkeyup", "javascript:AporOtros();")
            Me.TxtValTot.Attributes.Add("onblur", "javascript:ValTotal();")
            Me.TxtValProp.Attributes.Add("onblur", "javascript:ValAporGob;")
            Cancelar()

            Dim num_proc As String = Request("Num_Proc")
            If Not String.IsNullOrEmpty(num_proc) Then
                Me.TxtNprocA.Text = num_proc
                Abrir()
            End If
            
        End If


    End Sub

    Private Sub Nuevo()
        Me.Habilitar(True)
        Me.Limpiar()
        Me.TxtNProc.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.IBtnCancelar.Enabled = True
        Me.iBtnEditar.Enabled = False
        Me.BtnDefinitivo.Visible = False
        Me.BtnTramite.Visible = False
        Me.LblDef.Visible = False
        Me.LblTra.Visible = False
        Me.Oper = "nuevo"
    End Sub

    Private Sub Habilitar(ByVal Valor As Boolean)
        Me.TxtNPla.Enabled = Valor
        Me.TxtNProc.Enabled = False
        Me.TxtObj.Enabled = Valor
        'Me.TxtPro.Enabled = Valor
        Me.TxtValOtros.Enabled = Valor
        Me.TxtValProp.Enabled = Valor
        Me.TxtValTot.Enabled = Valor
        Me.cboDep.Enabled = Valor
        Me.CboDepP.Enabled = False
        Me.cboStip.Enabled = Valor
        Me.CboTip.Enabled = False
        Me.CboTproc.Enabled = False
        Me.TxtNumGrupos.Enabled = Valor
    End Sub

    Private Sub Limpiar()
        Me.TxtNPla.Text = ""
        Me.TxtNProc.Text = ""
        Me.TxtObj.Text = ""
        'Me.TxtPro.Text = ""

        Me.TxtValOtros.Text = 0
        Me.TxtValProp.Text = 0
        Me.TxtValTot.Text = 0

        Me.cboDep.SelectedIndex = -1
        Me.CboDepP.SelectedIndex = -1

        Me.cboStip.SelectedIndex = -1
        Me.CboTip.SelectedIndex = -1
        Me.CboTproc.SelectedIndex = -1

    End Sub

    Public Sub Cancelar()
        Me.Limpiar()
        Me.IBtnNuevo.Enabled = True
        Me.IBtnAbrir.Enabled = True
        Me.IBtnGuardar.Enabled = False
        Me.IBtnCancelar.Enabled = False
        Me.IbtnEditar.Enabled = False
        Me.Habilitar(False)
        Me.BtnDefinitivo.Visible = False
        Me.BtnTramite.Visible = False
        Me.LblDef.Visible = False
        Me.LblTra.Visible = False
        Me.Oper = ""
        Me.MsgResult.Text = ""
    End Sub

    Public Sub Editar()
        Habilitar(True)
        Me.IbtnEditar.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnCancelar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.Oper = "editar"
    End Sub
    ''' <summary>
    ''' ''Actualiza todos los grid, solo cuando se cambia el proceso o cuando se le da editar o cualquier operacion comun para todo el formulario
    ''' </summary>
    ''' <remarks></remarks>
    Sub Buscar()
        Dim dt As DataTable = obj.GetxUsuario("Pro_Sel_Nro='" + Me.TxtNprocA.Text + "'") 'obj.GetByPk(Me.TxtNprocA.Text)
        If dt.Rows.Count > 0 Then
            'Me.TxtLugEje.Text=
            Me.TxtNPla.Text = dt.Rows(0)("NRO_PLA_CON").ToString
            Me.TxtNProc.Text = dt.Rows(0)("PRO_SEL_NRO").ToString
            Me.Pk1 = dt.Rows(0)("PRO_SEL_NRO").ToString
            Me.TxtObj.Text = dt.Rows(0)("obj_con").ToString
            'Me.TxtPro.Enabled = CStr(dt.Rows(0)("PRO_CON"))


            Me.TxtValTot.Text = dt.Rows(0)("VAL_CON").ToString.Replace(Publico.Punto_DecOracle, ".")
            Me.TxtValProp.Text = dt.Rows(0)("VAL_APO_GOB").ToString.Replace(Publico.Punto_DecOracle, ".")
            Me.TxtValOtros.Text = dt.Rows(0)("VAL_OTROS").ToString.Replace(Publico.Punto_DecOracle, ".")

            Me.cboDep.SelectedValue = dt.Rows(0)("DEP_CON").ToString
            Me.CboDepP.SelectedValue = dt.Rows(0)("DEP_PCON").ToString

            Me.CboTip.SelectedValue = dt.Rows(0)("TIP_CON").ToString
            Me.cboStip.DataBind()
            Me.cboStip.SelectedValue = dt.Rows(0)("STIP_CON").ToString
            Me.CboTproc.SelectedValue = dt.Rows(0)("COD_TPRO").ToString

            Me.LbEstado.Text = dt.Rows(0)("NOM_EST").ToString

            'Me.grdProy1.Num_Proc = dt.Rows(0)("PRO_SEL_NRO").ToString
            'Me.grdProy1.LlenarGrid()
            
            
            Me.TxtNumGrupos.Text = dt.Rows(0)("NUMGRUPOS").ToString
            'Me.grdOblig1.Enabled = Valor
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
        Else
            MsgResult.Text = " No se encontro el Proceso " + Me.TxtNprocA.Text + " a cargo del Usuario " + Usuarios.UserName
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub
    Public Sub Abrir()
        If TxtNprocA.Text <> "" Then
            Buscar()
        Else
            ' ModalPopupConP.Show()
        End If
    End Sub

    Protected Sub IBtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        Nuevo()
    End Sub


    Protected Sub TxtNprocA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNprocA.TextChanged
        Abrir()
    End Sub

    Protected Sub IBtnAbrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAbrir.Click
        Abrir()
    End Sub

    Protected Sub IbtnEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnEditar.Click
        editar2()

    End Sub
    Sub editar2()
        Dim pcont As New PContratos
        Dim dt As DataTable
        dt = pcont.GetByPk(TxtNProc.Text)
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
    End Sub

    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        If Val(Me.TxtValTot.Text) < Val(Me.TxtValProp.Text) Then
            Me.MsgResult.Text = "El valor de los aportes propios no puede ser mayor que el valor del contrato"
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        Guardar()
        Me.IbtnEditar.Enabled = True
    End Sub

    Protected Sub IBtnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnCancelar.Click
        Cancelar()
    End Sub
    
    Protected Sub BtnDefinitivo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnDefinitivo.Click
        Dim pcont As New PContratos
        MsgResult.Text = pcont.Definitivo(TxtNProc.Text)
        MsgBox(MsgResult, pcont.lErrorG)
        If Not pcont.lErrorG Then
            Habilitar(False)
        End If

    End Sub

    Protected Sub BtnTramite_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnTramite.Click
        Dim pcont As New PContratos
        MsgResult.Text = pcont.Tramite(TxtNProc.Text)
        MsgBox(MsgResult, pcont.lErrorG)
        If Not pcont.lErrorG Then
            Habilitar(False)
        End If
    End Sub

    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        Me.TxtNprocA.Text = ConPContratos1.Num_Proc
        Buscar()
        Me.ModalPopupConP.Hide()
    End Sub

    Protected Sub IbtnBucar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnBucar.Click
        Me.ModalPopupConP.Show()
    End Sub

    Protected Sub LnkDatos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkDatos.Click
        Redireccionar_Pagina("/Procesos/GProcesosN/GProcesosN.aspx?Num_Proc=" + Me.TxtNProc.Text)
    End Sub
End Class
