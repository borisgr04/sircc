Imports System.Data
Partial Class Procesos_RadicarProc_GRadicacion
    Inherits PaginaComun
    Private Property TotalCDP() As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalCDP") = value
        End Set
        Get
            Return ViewState("TotalCDP")
        End Get
    End Property
    Private Property Encontrado() As Boolean
        Set(ByVal value As Boolean)
            ViewState("Encontrado") = value
        End Set
        Get
            Return ViewState("Encontrado")
        End Get
    End Property
    Private Property TotalPago() As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalPago") = value
        End Set
        Get
            Return ViewState("TotalPago")
        End Get
    End Property
    Private Property TotalRubro() As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalRubro") = value
        End Set
        Get
            Return ViewState("TotalRubro")
        End Get
    End Property
    Private Property Porcentaje() As Decimal
        Set(ByVal value As Decimal)
            ViewState("Porcentaje") = value
        End Set
        Get
            Return ViewState("Porcentaje")
        End Get
    End Property


    Protected Sub TxtNumProc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumProc.TextChanged
        TxtNumProc.TEXT = UCASE(TxtNumProc.TEXT)

        MsgResult.Text = ""
        MsgResult.CssClass = ""
        Session("NumProc") = Me.TxtNumProc.Text
        Session("Grupo") = Me.CboGrupos.SelectedValue
        Dim pcon As New ConGProcesos
        Dim dt As DataTable = pcon.GetByPkRad(UCase(TxtNumProc.Text), "1")

        If dt.Rows.Count > 0 Then
            'Me.MostrarUId(dt.Rows(0).Item("Tip_Con").ToString)
            MsgResult.Text = "Verifique que la información sea correcta."
            Me.MsgBoxInfo(MsgResult, True)
            BtnRadicar.Enabled = True
            Me.TxtFecRad.Text = Today.ToShortDateString
            Me.TxtFecRad.Enabled = True

            'Me.TxtTipDoc.Text = dt.Rows(0).Item("Nom_Tip").ToString
            If dt.Rows(0).Item("Estado").ToString = "RA" Then
                MsgResult.Text = "El Proceso se encuentra RADICADO"
                Me.MsgBoxAlert(MsgResult, True)
                BtnRadicar.Enabled = False
                Me.TxtFecRad.Enabled = False
            End If
        Else
            BtnRadicar.Enabled = False
            Me.TxtFecRad.Enabled = False
        End If
        Act()

        Me.DetailsView1.DataBind()
        'BtnRadicar.Enabled = True
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Me.ModalPopupConP.Show()
    End Sub

    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        TxtNumProc.Text = ConPContratos1.Num_Proc
        Session("NumProc") = Me.TxtNumProc.Text
        Session("Grupo") = Me.CboGrupos.SelectedValue
        Act()
        MsgBoxLimpiar(MsgResult)
        MsgResult.Text = "Verifique que la información sea correcta."
        Me.MsgBoxInfo(MsgResult, True)
        Me.ModalPopupConP.Hide()
    End Sub

    Sub Act()
        Dim p As New GProcesos
        Dim dt As DataTable = p.GetByPkC(Me.TxtNumProc.Text, Me.CboGrupos.SelectedValue)

        If dt.Rows.Count > 0 Then
            Dim v As New Vigencias
            Dim dt2 As DataTable = v.GetCons(hdVigencias.Value, dt.Rows(0)("Tip_Con"))
            If dt2.Rows.Count > 0 Then
                Me.TxtFecRad.Text = dt2.Rows(0)("Fecha Suscripción").ToString
                lbClase.Text = "Ultimo " + dt.Rows(0)("NOM_TIP").ToString + " N°:<u>" + dt2.Rows(0)("Numero").ToString + "</u> de fecha: <i>" + CDate(dt2.Rows(0)("Fecha Suscripción").ToString).ToLongDateString + "</i>"
            End If

            'MsgBoxLimpiar(MsgResult)
            'MsgResult.Text = "Verifique que la información sea correcta."
            'Me.MsgBoxInfo(MsgResult, True)
        Else
            lbClase.Text = ""
            MsgResult.Text = "No encontró datos del proceso " + Me.TxtNumProc.Text + " Grupo " + Me.CboGrupos.Text
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub


    Protected Sub MostrarUId(ByVal tip As String)
        Dim obj As ContratosA = New ContratosA()
        Dim fec_sus As Date
        obj.UltId(tip, Vigencia_Cookie, fec_sus)
        'Me.TxtUFs.Text = fec_sus.ToLongDateString
        Me.TxtFecRad.Text = fec_sus.ToShortDateString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MostrarUId("02")
        'Me.TxtTipDoc.Text = "Contrato"
        Me.GridView2.Visible = ChkVerRadicacion.Checked
        Me.hdVigencias.Value = Vigencia.ToString
        'Me.MsgResult.Text = Vigencia.ToString

    End Sub

    Protected Sub BtnRadicar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRadicar.Click
        If IsDate(TxtFecRad.Text) Then
            If CDate(TxtFecRad.Text) >= CDate(TxtFecRad.Text) Then
                Dim obj As New GContratosA
                obj.RadicarA(TxtNumProc.Text, CDate(TxtFecRad.Text).ToShortDateString, CboGrupos.SelectedValue)
                If obj.ResPRad.ToString = 1 Then
                    MsgResult.Text = "El Proceso aún se encuentra en TRAMITE"
                    MsgBox(MsgResult, True)
                ElseIf obj.ResPRad.ToString = 2 Then
                    MsgResult.Text = "Se produjo un duplicado en el número del contrato consulte con el Administrador"
                    MsgBox(MsgResult, True)
                ElseIf obj.ResPRad.ToString = 3 Then
                    MsgResult.Text = "Se produjo error al Radicar el Contrato"
                    MsgBox(MsgResult, True)
                ElseIf obj.ResPRad.ToString = 4 Then
                    MsgResult.Text = "El sistema no encontro el Proceso habilitado para la radicación"
                    MsgBox(MsgResult, True)
                ElseIf obj.ResPRad.ToString = 5 Then
                    MsgResult.Text = "El Proceso se encuentra RADICADO"
                    MsgBox(MsgResult, True)
                ElseIf obj.ResPRad.ToString = 6 Then
                    MsgResult.Text = "La fecha de Suscripción debe ser Mayor o Igual a la Ultima fecha radicada "
                    MsgBox(MsgResult, True)
                Else
                    MsgResult.Text = "Se Radico correctamente el contrato con el No. " + obj.ResPRad.ToString
                    MsgBox(MsgResult, False)
                    Dim pcon As New ConGProcesos
                    Dim dt As DataTable = pcon.GetByPkRad(UCase(TxtNumProc.Text), CboGrupos.SelectedValue)
                    Me.MostrarUId(dt.Rows(0).Item("Tip_Con").ToString)
                    Act()
                    Me.GridView2.DataBind()
                End If
            Else
                MsgResult.Text = "La fecha no puede ser inferior a la de la ultima radicacion"
                Me.MsgBoxAlert(MsgResult, True)
            End If
        Else
            MsgResult.Text = "Debe seleccionar una fecha valida"
            Me.MsgBoxAlert(MsgResult, True)
        End If
    End Sub

    Protected Sub CboGrupos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboGrupos.SelectedIndexChanged
        Session("NumProc") = Me.TxtNumProc.Text
        Session("Grupo") = Me.CboGrupos.SelectedValue
        MsgResult.Text = "Verifique que la información sea correcta."
        Me.MsgBoxInfo(MsgResult, True)
    End Sub

    Protected Sub DetailsView1_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetailsView1.DataBinding
        Session("NumProc") = Me.TxtNumProc.Text
        Session("Grupo") = Me.CboGrupos.SelectedValue
    End Sub

    Protected Sub ChkVerRadicacion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkVerRadicacion.CheckedChanged
        Me.GridView2.Visible = ChkVerRadicacion.Checked
    End Sub

    Protected Sub IBtnMinuta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnMinuta.Click

        Redireccionar_Pagina("/ashx/VerMinuta.ashx?Num_Proc=" + Me.TxtNumProc.Text + "&Grupo=" + Me.CboGrupos.SelectedValue)
        

    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If
    End Sub
End Class
