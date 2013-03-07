Imports System.Data
Partial Class Procesos_AnProceso
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

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Me.ModalPopupConP.Show()
    End Sub

    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        TxtNumProc.Text = ConPContratos1.Num_Proc
        Session("NumProc") = Me.TxtNumProc.Text
        Act()
        MsgBoxLimpiar(MsgResult)
        Me.ModalPopupConP.Hide()
    End Sub

    Sub Act()
        
    End Sub


    'Protected Sub BtnRadicar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRadicar.Click
    '    If IsDate(TxtFecRad.Text) Then
    '        If CDate(TxtFecRad.Text) >= CDate(TxtFecRad.Text) Then
    '            Dim obj As New GContratosA
    '            obj.RadicarA(TxtNumProc.Text, CDate(TxtFecRad.Text).ToShortDateString, CboGrupos.SelectedValue)
    '            If obj.ResPRad.ToString = 1 Then
    '                MsgResult.Text = "El Proceso aún se encuentra en TRAMITE"
    '                MsgBox(MsgResult, True)
    '            ElseIf obj.ResPRad.ToString = 2 Then
    '                MsgResult.Text = "Se produjo un duplicado en el número del contrato consulte con el Administrador"
    '                MsgBox(MsgResult, True)
    '            ElseIf obj.ResPRad.ToString = 3 Then
    '                MsgResult.Text = "Se produjo error al Radicar el Contrato"
    '                MsgBox(MsgResult, True)
    '            ElseIf obj.ResPRad.ToString = 4 Then
    '                MsgResult.Text = "El sistema no encontro el Proceso habilitado para la radicación"
    '                MsgBox(MsgResult, True)
    '            ElseIf obj.ResPRad.ToString = 5 Then
    '                MsgResult.Text = "El Proceso se encuentra RADICADO"
    '                MsgBox(MsgResult, True)
    '            ElseIf obj.ResPRad.ToString = 6 Then
    '                MsgResult.Text = "La fecha de Suscripción debe ser Mayor o Igual a la Ultima fecha radicada "
    '                MsgBox(MsgResult, True)
    '            Else
    '                MsgResult.Text = "Se Radico correctamente el contrato con el No. " + obj.ResPRad.ToString
    '                MsgBox(MsgResult, False)
    '                Dim pcon As New ConGProcesos
    '                Dim dt As DataTable = pcon.GetByPkRad(UCase(TxtNumProc.Text), CboGrupos.SelectedValue)
    '                Me.MostrarUId(dt.Rows(0).Item("Tip_Con").ToString)
    '                Me.GridView2.DataBind()
    '            End If
    '        Else
    '            MsgResult.Text = "La fecha no puede ser inferior a la de la ultima radicacion"
    '            Me.MsgBoxAlert(MsgResult, True)
    '        End If
    '    Else
    '        MsgResult.Text = "Debe seleccionar una fecha valida"
    '        Me.MsgBoxAlert(MsgResult, True)
    '    End If
    'End Sub

    Protected Sub BtnRadicar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRadicar.Click
        Dim objproc As New PContratos
        If objproc.GetProcRad(DetailsView1.SelectedValue) > 0 Then
            MsgResult.Text = "No se puede anular el proceso debido a que ya se le ha Radicado Contrato."
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        Dim dt As DataTable = objproc.GetByPk(DetailsView1.SelectedValue)
        If dt.Rows(0)("Estado").ToString = "AN" Then
            MsgResult.Text = "El proceso ya fue Anulado."
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If
        Dim res As String = objproc.AnularProc(DetailsView1.SelectedValue, TextBox1.Text)
        If res = "1" Then
            MsgResult.Text = "Se Anulo el proceso con éxito."
            MsgBox(MsgResult, False)
        Else
            MsgResult.Text = "Ocurrio un problema durante la anulación del proceso."
            MsgBox(MsgResult, True)
        End If
    End Sub
End Class
