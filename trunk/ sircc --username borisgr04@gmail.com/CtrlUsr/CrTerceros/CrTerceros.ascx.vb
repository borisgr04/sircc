Imports System.Data
Partial Class CtrlUsr_CrTerceros_CrTerceros
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
        If Not IsPostBack Then
            Me.Oper = "Nuevo"
            Limpiar()

            '            FillCustomerInGrid()

            Me.TxtNit.Attributes.Add("onfocusout", "javascript:ColocarNit();")

            Me.TxtApe1.Attributes.Add("onfocusout", "javascript:ColocarNombre();")
            Me.TxtApe2.Attributes.Add("onfocusout", "javascript:ColocarNombre();")
            Me.TxtNom1.Attributes.Add("onfocusout", "javascript:ColocarNombre();")
            Me.TxtNom2.Attributes.Add("onfocusout", "javascript:ColocarNombre();")

            Me.TxtNom2.Attributes.Add("onfocusout", "javascript:ColocarNombre();")

            'Me.CbTdoc.Attributes.Add("onchange", "javascript:SwNombre();")

        End If

    End Sub




    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Guardar()


    End Sub

    Protected Sub Limpiar()

        'Me.CbTdoc.Text = ""
        Me.TxtUsu.Text = ""
        Me.TxtNit.Text = ""
        Me.TxtDver.Text = ""
        Me.TxtNom.Text = ""
        'Me.CbTTcer.SelectedValue = ""
        'Me.CbMun.SelectedValue = ""
        Me.TxtEma.Text = ""
        Me.TxtTel.Text = ""
        Me.TxtDir.Text = ""

        Me.TxtApe1.Text = ""
        Me.TxtApe2.Text = ""
        Me.TxtNom1.Text = ""
        Me.TxtNom2.Text = ""
        Me.TxtLugExp.Text = ""

        'Me.CbTUsu.Text = ""
        'Me.CbEst.Text = ""
        Me.TxtObs.Text = ""

        'Me.Oper = ""
        Me.CbTdoc.Enabled = True
        ' Me.TxtUsu.Enabled = True
        Me.TxtNit.Enabled = True
        'Me.TxtDver.Enabled = True
        Me.TxtNom.Enabled = True
        Me.CbTTcer.Enabled = True
        Me.CbMun.Enabled = True
        Me.TxtEma.Enabled = True
        Me.TxtTel.Enabled = True
        Me.TxtDir.Enabled = True

        Me.CbEst.Enabled = True
        Me.TxtObs.Enabled = True
        Me.BtnSave.Visible = True

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
        Dim Obj As Terceros = New Terceros
        Me.Nit = Me.TxtNit.Text
        Select Case Me.Oper
            Case "Nuevo"
                Me.MsgResult.Text = Obj.Insert(Me.TxtNit.Text, Me.TxtApe1.Text, Me.TxtApe2.Text, Me.TxtNom1.Text, Me.TxtNom2.Text, Me.TxtDir.Text, Me.TxtTel.Text, Me.TxtEma.Text, Me.CbTdoc.SelectedValue, Me.TxtDver.Text, Me.TxtLugExp.Text, Me.TxtNom.Text, Cmb_CLa.SelectedValue)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HOldNit.Value, Me.TxtNit.Text, Me.TxtApe1.Text, Me.TxtApe2.Text, Me.TxtNom1.Text, Me.TxtNom2.Text, Me.TxtDir.Text, Me.TxtTel.Text, Me.TxtEma.Text, Me.TxtNom.Text, Me.TxtDver.Text, Me.TxtLugExp.Text, Me.CbTdoc.SelectedValue, Cmb_CLa.SelectedValue)
        End Select
        MsgResult.Visible = True
        Me.MsgBox(MsgResult, Obj.lErrorG)

        If Obj.lErrorG = False Then
            'Me.Limpiar()
        End If

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
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.TxtNit.Text)
        If dt.Rows.Count > 0 Then
            MsgResult.Text = "Ya se encuentra Registrado"
            MsgBox(MsgResult, True)
        Else
            MsgResult.Text = ""
            MsgResult.CssClass = ""
        End If
    End Sub


    Public Sub Editar()
        Me.Oper = "Editar"
        Dim Obj As Terceros = New Terceros
        Dim tb As DataTable = Obj.GetByIde(Nit)
        If tb.Rows.Count > 0 Then
            '    'If 1 = 0 Then
            Me.HoldDVer.Value = tb.Rows(0)("DV_TER").ToString
            Me.HOldNit.Value = tb.Rows(0)("IDE_TER").ToString
            Me.HoldTDoc.Value = tb.Rows(0)("TIP_IDE").ToString
            Me.MsgResult.Text = tb.Rows(0)("TIP_IDE").ToString
            Me.CbTdoc.SelectedValue = tb.Rows(0)("TIP_IDE").ToString.Trim
            Me.TxtNit.Text = tb.Rows(0)("IDE_TER").ToString
            Me.TxtDver.Text = tb.Rows(0)("DV_TER").ToString
            Me.TxtNom.Text = tb.Rows(0)("NOM_TER").ToString

            Me.TxtApe1.Text = tb.Rows(0)("APE1_TER").ToString
            Me.TxtApe2.Text = tb.Rows(0)("APE2_TER").ToString
            Me.TxtNom1.Text = tb.Rows(0)("NOM1_TER").ToString
            Me.TxtNom2.Text = tb.Rows(0)("NOM2_TER").ToString

            'Me.CbTTcer.SelectedValue = tb.Rows(0)("TER_TIP").ToString
            'Me.CbMun.SelectedValue = tb.Rows(0)("TER_MPIO").ToString
            Me.TxtEma.Text = tb.Rows(0)("EMA_TER").ToString
            Me.TxtTel.Text = tb.Rows(0)("TEL_TER").ToString
            Me.TxtDir.Text = tb.Rows(0)("DIR_TER").ToString
            'Me.TxtCed.Text = tb.Rows(0)("TER_CED").ToString
            'Me.TxtRep.Text = tb.Rows(0)("TER_REP").ToString
            Me.TxtUsu.Text = tb.Rows(0)("IDE_TER").ToString
            'Me.CbTUsu.SelectedValue = tb.Rows(0)("TER_TUS").ToString
            'Me.TxtObs.Text = tb.Rows(0)("TER_OBS").ToString

            'Nuevos Campos agregados en DERWEB
            Me.TxtLugExp.Text = tb.Rows(0)("EXP_IDE").ToString
            Me.TxtNom.Text = tb.Rows(0)("RAZ_SOC").ToString
            Me.TxtDver.Text = tb.Rows(0)("DV_TER").ToString
            Me.TxtLugExp.Text = tb.Rows(0)("EXP_IDE").ToString
            Me.Cmb_CLa.SelectedValue = tb.Rows(0)("TIPO").ToString

            '--------------------------
            Me.CbTdoc.Enabled = True
            Me.TxtUsu.Enabled = False
            Me.TxtNit.Enabled = True
            'Me.TxtDver.Enabled = False
            Me.TxtNom.Enabled = True
            Me.CbTTcer.Enabled = True
            Me.CbMun.Enabled = True
            Me.TxtEma.Enabled = True
            Me.TxtTel.Enabled = True
            Me.TxtDir.Enabled = True

            Me.TxtApe1.Enabled = True
            Me.TxtApe2.Enabled = True
            Me.TxtNom1.Enabled = True
            Me.TxtNom2.Enabled = True

            Me.CbEst.Enabled = True
            Me.TxtObs.Enabled = True
            Me.BtnSave.Visible = True

            Me.TxtLugExp.Enabled = True
            MsgResult.Text = ""
            MsgResult.CssClass = ""
            Me.SubT.Text = "Editando..."
        Else
            MsgResult.Text = "No se encuentra registro N° de Identifiación [" + Nit + "]"
            MsgBox(MsgResult, True)
        End If

    End Sub

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




    End Sub
End Class

