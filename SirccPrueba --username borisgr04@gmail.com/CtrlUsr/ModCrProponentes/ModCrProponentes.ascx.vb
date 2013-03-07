Imports System.Data
Partial Class CtrlUsr_CrProponentes_ModCrProponentes
    Inherits CtrlUsrComun



    Public Property Evento() As String
        Get
            Return ViewState("Evento")
        End Get
        Set(ByVal value As String)
            ViewState("Evento") = value
        End Set
    End Property
    Property Nit As String
        Get
            'Session("NitTer") '

            Return ViewState("NitTer")

        End Get
        Set(ByVal value As String)
            'Session("NitTer") = value
            TxtNit.Text = value
            ViewState("NitTer") = value
        End Set
    End Property

    Public Property NomTer As String
        Get
            Return ViewState("NomTer")
        End Get
        Set(ByVal value As String)
            ViewState("NomTer") = value
        End Set
    End Property
    Public Property Num_Sol_Adi As String
        Get
            Return ViewState("Num_Sol_Adi")
        End Get
        Set(ByVal value As String)
            ViewState("Num_Sol_Adi") = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return ViewState("Tipo")
        End Get
        Set(ByVal value As String)
            ViewState("Tipo") = value
        End Set
    End Property

#Region "Eventos del control"

    Public Event CancelClicked As EventHandler
    Public Event SaveClicked As EventHandler

    Public Property Num_Proc As String
        Get
            Return ViewState("Num_Proc")
        End Get
        Set(ByVal value As String)
            ViewState("Num_Proc") = value
        End Set
    End Property

    Protected Overridable Sub OnClick(ByVal sender As Object)
        If Evento = "Guardar" Then
            RaiseEvent SaveClicked(sender, New EventArgs())
        End If
        If Evento = "Cancelar" Then
            RaiseEvent CancelClicked(sender, New EventArgs())
        End If
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Opcion = Me.Tit.Text
        'Me.SetTitulo()
        'var theForm = document.forms['aspnetForm'];
        If Not Page.IsPostBack Then
            CvFecha.ValueToCompare = Today
            Me.Oper = "Nuevo"
            Limpiar()
            Me.TxtNit.Attributes.Add("onfocusout", "javascript:ColocarNit();")

            Me.TxtApe1.Attributes.Add("onfocusout", "javascript:ColocarNombre();")
            Me.TxtApe2.Attributes.Add("onfocusout", "javascript:ColocarNombre();")
            Me.TxtNom1.Attributes.Add("onfocusout", "javascript:ColocarNombre();")
            Me.TxtNom2.Attributes.Add("onfocusout", "javascript:ColocarNombre();")
            Me.TxtValProp.Attributes.Add("onfocusout", "javascript:ValProp();")
        End If
    End Sub




    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Guardar()


    End Sub

    Protected Sub Limpiar()


        Me.TxtNom2.Text = ""
        Me.TxtNom1.Text = ""
        Me.TxtApe2.Text = ""
        Me.TxtApe1.Text = ""
        Me.TxtDir.Text = ""
        Me.TxtDir.Text = ""
        Me.TxtLugExp.Text = ""
        Me.TxtFecProp.Text = Today.ToShortDateString
        Me.TxtNit.Text = ""
        Me.TxtValProp.Text = 0
        Me.TxtObs.Text = ""
        Me.TxtTel.Text = ""
        Me.TxtNom.Text = ""
        Me.TxtEma.Text = ""
        Me.TxtRepLeg.Text = ""
        Me.TxtIdRepLeg.Text = ""
        Me.TxtNumFolio.Text = 0.0
        CbTdoc.SelectedValue = "SELECCIONE..."
        CboTipProp.SelectedValue = "SELECCIONE..."
        Me.CbTdoc.Enabled = True

        Me.TxtNit.Enabled = True

        Me.TxtNom.Enabled = True

        Me.TxtMun.Enabled = True
        Me.TxtEma.Enabled = True
        Me.TxtTel.Enabled = True
        Me.TxtDir.Enabled = True

        Me.CbEst.Enabled = True
        Me.TxtObs.Enabled = True
        Me.BtnSave.Visible = True

        Me.MsgResult.CssClass = ""
        Me.MsgResult.Text = ""

    End Sub




    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCancel.Click
        Limpiar()
        'Me.Evento = "Cancelar"
        'OnClick(sender)
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Me.MsgResult.Text = ""
        Me.SubT.Text = "Buscando..."

    End Sub

    Protected Sub Btnsave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Guardar()
    End Sub

    Protected Sub Guardar()
        Dim Obj As PProponentes = New PProponentes
        Me.Nit = Me.TxtNit.Text
        Select Case Me.Oper
            Case "Nuevo"
                Me.MsgResult.Text = Obj.Insert(CboTipProp.SelectedValue, TxtNit.Text, Me.Num_Proc, CDate(TxtFecProp.Text).ToShortDateString, Publico.PuntoPorComa(TxtValProp.Text), TxtApe1.Text, _
                                         Me.TxtDir.Text, Me.TxtTel.Text, Me.TxtEma.Text, Me.TxtApe2.Text, Me.TxtNom1.Text, Me.TxtNom2.Text, Me.TxtNom.Text, _
                                         Me.CbTdoc.SelectedValue, Me.TxtLugExp.Text, Me.CbEst.SelectedValue, Me.TxtObs.Text, Me.TxtNumFolio.Text, Me.TxtDver.Text, Me.TxtIdRepLeg.Text, Me.TxtRepLeg.Text, Me.TxtMun.Text)
                MsgBox(MsgResult, Obj.lErrorG)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Pk1, Me.TxtNit.Text, Me.Num_Proc, CDate(TxtFecProp.Text).ToShortDateString, TxtValProp.Text, TxtApe1.Text, _
                                             Me.TxtDir.Text, Me.TxtTel.Text, Me.TxtEma.Text, Me.TxtApe2.Text, Me.TxtNom1.Text, Me.TxtNom2.Text, Me.TxtNom.Text, _
                                             Me.CbTdoc.SelectedValue, Me.TxtLugExp.Text, Me.CbEst.SelectedValue, Me.TxtObs.Text, Me.TxtNumFolio.Text, Me.TxtDver.Text, Me.TxtIdRepLeg.Text, Me.TxtRepLeg.Text, Me.TxtMun.Text)
                MsgBox(MsgResult, Obj.lErrorG)
        End Select
    End Sub

    Protected Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Nuevo()
    End Sub

    Public Sub Nuevo()
        Limpiar()
        Me.SubT.Text = "Nuevo..."

        Page.SetFocus(Me.CbTdoc)
        Me.Oper = "Nuevo"

    End Sub

    Protected Sub TxtNit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNit.TextChanged
        Dim obj As New Modificaciones
        Dim dt As DataTable = obj.GetPropbyPK(TxtNit.Text, Num_Sol_Adi)
        If CbTdoc.SelectedValue = "NI" Then
            Me.TxtDver.Text = Util.ValidarDigitoVerificacion(TxtNit.Text)
        End If
        If dt.Rows.Count > 0 Then
            MsgResult.Text = "Ya se encuentra Registrado"
            MsgBox(MsgResult, True)
        Else
            MsgResult.Text = ""
            MsgResult.CssClass = ""
        End If
    End Sub

    Sub habilitar(ByVal val As Boolean)
        Me.TxtNom2.Enabled = val
        Me.TxtNom1.Enabled = val
        Me.TxtApe2.Enabled = val
        Me.TxtApe1.Enabled = val
        Me.TxtDir.Enabled = val
        Me.TxtDir.Enabled = val
        Me.TxtLugExp.Enabled = val
        Me.TxtFecProp.Enabled = val
        Me.TxtNit.Enabled = val
        Me.TxtValProp.Enabled = val
        Me.TxtObs.Enabled = val
        Me.TxtTel.Enabled = val
        Me.CbEst.Enabled = val
        Me.TxtMun.Enabled = val
        Me.CbTdoc.Enabled = val
        Me.BtnSave.Enabled = val
        Me.TxtNom.Enabled = val
        Me.TxtNumFolio.Enabled = val
        Me.TxtIdRepLeg.Enabled = val
        Me.TxtRepLeg.Enabled = val
        Me.CboTipProp.Enabled = val
        'Me.BtnEliminar.Enabled = Not val
    End Sub
    Public Sub Editar()
        Me.Oper = "Editar"
        Dim obj As Modificaciones = New Modificaciones


        Dim tb As DataTable = obj.GetPropbyPK(Nit, Num_Sol_Adi)
        If tb.Rows.Count > 0 Then
            Limpiar()
            CboTipProp.DataBind()
            CbTdoc.DataBind()
            Me.TxtNom2.Text = tb.Rows(0)("Nom2_Prop").ToString
            Me.TxtNom1.Text = tb.Rows(0)("Nom1_Prop").ToString
            Me.TxtApe2.Text = tb.Rows(0)("Ape2_Prop").ToString
            Me.TxtApe1.Text = tb.Rows(0)("Ape1_Prop").ToString
            Me.TxtDir.Text = tb.Rows(0)("Dir_prop").ToString
            Me.TxtEma.Text = tb.Rows(0)("Email_prop").ToString
            Me.TxtLugExp.Text = tb.Rows(0)("Exp_Ide").ToString
            Me.TxtFecProp.Text = CDate(tb.Rows(0)("Fec_Prop").ToString).ToShortDateString
            Me.TxtNit.Text = tb.Rows(0)("Ide_prop").ToString
            Me.TxtValProp.Text = tb.Rows(0)("Val_Prop").ToString
            Me.TxtObs.Text = tb.Rows(0)("Observacion").ToString
            Me.TxtTel.Text = tb.Rows(0)("Tel_prop").ToString
            'Throw New Exception(CbTdoc.Items.Count)
            CbEst.SelectedValue = tb.Rows(0)("Estado").ToString
            Me.TxtNom.Text = tb.Rows(0)("Razon_Social").ToString
            Me.Pk1 = tb.Rows(0)("Ide_Prop").ToString
            Me.TxtNumFolio.Text = tb.Rows(0)("Num_Folio").ToString
            Me.CboTipProp.SelectedValue = Trim(tb.Rows(0)("Tipo").ToString)
            Me.TxtIdRepLeg.Text = tb.Rows(0)("Id_Rep_Legal").ToString
            TxtRepLeg.Text = tb.Rows(0)("Nom_Rep_Legal").ToString
            If Trim(tb.Rows(0)("Tip_Ide").ToString) = "CA" Then
                Me.TxtNit_FilteredTextBoxExtender.FilterType = AjaxControlToolkit.FilterTypes.Custom
                Me.TxtNit_FilteredTextBoxExtender.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            End If
            Me.CbTdoc.SelectedValue = Trim(tb.Rows(0)("Tip_Ide").ToString)
            habilitar(True)
            'Me.MultiView1.ActiveViewIndex = 1
        Else
            MsgResult.Text = "No se encuentra registro N° de Identifiación [" + Nit + "]"
            MsgBox(MsgResult, True)
        End If

    End Sub




    'function calcularDV(i_rut) {var pesos = new Array(71,67,59,53,47,43,41,37,29,23,19,17,13,7,3); rut_fmt = zero_fill(i_rut, 15);suma = 0;for ( i=0; i<=14; i++ ) suma += rut_fmt.substring(i, i+1) * pesos[i];resto = suma % 11;if ( resto == 0 || resto == 1 )digitov = resto;Else digitov = 11 - resto;Return (digitov);}
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim strjscript As String = "function ColocarNit(){"
        strjscript = strjscript & " document.getElementById ('" + Me.TxtDver.ClientID + "').value='';"
        strjscript = strjscript & " if(document.getElementById ('" + Me.CbTdoc.ClientID + "').value='NI'){"
        strjscript = strjscript & "  var dv=calcularDV(document.aspnetForm." + Me.TxtNit.ClientID + ".value);"
        strjscript = strjscript & "  document.aspnetForm." + Me.TxtDver.ClientID + ".value=dv;"
        strjscript = strjscript & " }"
        strjscript = strjscript & "}"
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "ColocarNit", strjscript, True)

        strjscript = " function ColocarNombre(){"
        strjscript += "var ape1=document.getElementById ('" + Me.TxtApe1.ClientID + "').value;"
        strjscript += "var ape2=document.getElementById ('" + Me.TxtApe2.ClientID + "').value;"
        strjscript += "var nom1=document.getElementById ('" + Me.TxtNom1.ClientID + "').value;"
        strjscript += "var nom2=document.getElementById ('" + Me.TxtNom2.ClientID + "').value;"
        strjscript += "document.getElementById ('" + Me.TxtNom.ClientID + "').value=ape1+' '+ape2+' '+nom1+' '+nom2; "
        strjscript += " }"
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "ColocarNombre", strjscript, True)

        strjscript = " function zero_fill(i_valor, num_ceros) {"
        strjscript += " relleno = '';"
        strjscript += " i = 1;"
        strjscript += "    salir = 0;"
        strjscript += "    while ( ! salir ) { "
        strjscript += "     total_caracteres = i_valor.length + i;"
        strjscript += "     if ( i > num_ceros || total_caracteres > num_ceros )"
        strjscript += "      salir = 1; "
        strjscript += "      else   relleno = relleno + '0'; "
        strjscript += "     i++;"
        strjscript += "}"
        strjscript += "  i_valor = relleno + i_valor;"
        strjscript += "  return i_valor;"
        strjscript += "}"
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "zero_fill", strjscript, True)

        strjscript = " function calcularDV(i_rut){"
        strjscript += "var pesos = new Array(71,67,59,53,47,43,41,37,29,23,19,17,13,7,3); "
        strjscript += "rut_fmt = zero_fill(i_rut, 15);"
        strjscript += "suma = 0;"
        strjscript += "for ( i=0; i<=14; i++ ) "
        strjscript += "suma += rut_fmt.substring(i, i+1) * pesos[i];"
        strjscript += "resto = suma % 11;"
        strjscript += "if ( resto == 0 || resto == 1 )"
        strjscript += "digitov = resto;"
        strjscript += "else digitov = 11 - resto;"
        strjscript += " return (digitov);}"
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "calcularDV", strjscript, True)

        strjscript = " function ValProp(){"
        strjscript += "var val=document.getElementById ('" + Me.TxtValProp.ClientID + "').value;"
        strjscript += "document.getElementById ('" + Me.TxtValProp.ClientID + "').value=(parseFloat(val)).toFixed(2); "
        strjscript += " }"
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "ValProp", strjscript, True)
    End Sub

    Protected Sub CboTipProp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTipProp.SelectedIndexChanged
        If CboTipProp.SelectedValue <> "PU" And CboTipProp.SelectedValue <> "SELECCIONE..." Then
            CbTdoc.SelectedValue = "CA"
            CbTdoc.Enabled = False
            TxtNit.Enabled = False
            RequiredFieldValidator2.Enabled = False
            RequiredFieldValidator1.Enabled = False
        Else
            CbTdoc.Enabled = True
            TxtNit.Enabled = True
            CbTdoc.SelectedValue = "SELECCIONE..."
            RequiredFieldValidator2.Enabled = True
            RequiredFieldValidator1.Enabled = True
        End If
    End Sub

End Class

