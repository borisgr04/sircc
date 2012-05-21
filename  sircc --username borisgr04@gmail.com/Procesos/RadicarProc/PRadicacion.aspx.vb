Imports System.Data
Partial Class Procesos_RadicarProc_PRadicacion
    Inherits PaginaComun
    Private Property TotalCDP As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalCDP") = value
        End Set
        Get
            Return ViewState("TotalCDP")
        End Get
    End Property
    Private Property Encontrado As Boolean
        Set(ByVal value As Boolean)
            ViewState("Encontrado") = value
        End Set
        Get
            Return ViewState("Encontrado")
        End Get
    End Property
    Private Property TotalPago As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalPago") = value
        End Set
        Get
            Return ViewState("TotalPago")
        End Get
    End Property
    Private Property TotalRubro As Decimal
        Set(ByVal value As Decimal)
            ViewState("TotalRubro") = value
        End Set
        Get
            Return ViewState("TotalRubro")
        End Get
    End Property
    Private Property Porcentaje As Decimal
        Set(ByVal value As Decimal)
            ViewState("Porcentaje") = value
        End Set
        Get
            Return ViewState("Porcentaje")
        End Get
    End Property

    Protected Sub GrCDP_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrCDP.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.TotalCDP = 0
            Case DataControlRowType.DataRow

                Me.TotalCDP += CDec(DataBinder.Eval(e.Row.DataItem, "Val_CDP"))
                'Me.TCan += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(2).Text = FormatCurrency(Me.TotalCDP.ToString)
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                'e.Row.Cells(5).Text = FormatNumber(Me.TCan.ToString)
                'e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                'e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub GrRubros_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrRubros.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.TotalRubro = 0
            Case DataControlRowType.DataRow

                Me.TotalRubro += CDec(DataBinder.Eval(e.Row.DataItem, "Valor"))
                'Me.TCan += CDec(DataBinder.Eval(e.Row.DataItem, "Cantidad"))
            Case DataControlRowType.Footer
                e.Row.Cells(1).Text = FormatCurrency(Me.TotalRubro.ToString)
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True

                'e.Row.Cells(5).Text = FormatNumber(Me.TCan.ToString)
                'e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                'e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub GrFPago_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrFPago.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

        End If
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me.TotalPago = 0
                Me.Porcentaje = 0
            Case DataControlRowType.DataRow

                Me.TotalPago += CDec(DataBinder.Eval(e.Row.DataItem, "Valor_Pago"))
                Me.Porcentaje += CDec(DataBinder.Eval(e.Row.DataItem, "Porcentaje"))
            Case DataControlRowType.Footer
                e.Row.Cells(1).Text = FormatCurrency(Me.TotalPago.ToString)
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(2).Text = FormatPercent(Me.Porcentaje.ToString)
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub TxtNumProc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumProc.TextChanged
        MsgResult.Text = ""
        MsgResult.CssClass = ""
        Dim pcon As New Con_PContratos
        Dim dt As DataTable = pcon.GetByPkRad(UCase(TxtNumProc.Text))
        If dt.Rows.Count > 0 Then
            Me.MostrarUId(dt.Rows(0).Item("Tip_Con").ToString)
            BtnRadicar.Enabled = True
            Me.TxtFecRad.Text = Today.ToShortDateString
            Me.TxtFecRad.Enabled = True
            Me.DetailsView1.DataBind()
            Me.TxtTipDoc.Text = dt.Rows(0).Item("Nom_Tip").ToString
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
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Me.ModalPopupConP.Show()
    End Sub

    Protected Sub ConPContratos1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPContratos1.SelClicked
        TxtNumProc.Text = ConPContratos1.Num_Proc
        Me.ModalPopupConP.Hide()
    End Sub
    Protected Sub MostrarUId(ByVal tip As String)
        Dim obj As ContratosA = New ContratosA()
        Dim fec_sus As Date
        Me.TxtUId.Text = obj.UltId(tip, Vigencia_Cookie, fec_sus)
        Me.TxtUFs.Text = fec_sus.ToLongDateString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MostrarUId("02")
        Me.TxtTipDoc.Text = "Contrato"
    End Sub

    Protected Sub BtnRadicar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRadicar.Click
        If IsDate(TxtFecRad.Text) Then
            If CDate(TxtFecRad.Text) >= CDate(TxtUFs.Text) Then
                Dim obj As New ContratosA
                obj.RadicarA(TxtNumProc.Text, CDate(TxtFecRad.Text).ToShortDateString)
                If obj.ResPRad.ToString = 1 Then
                    MsgResult.Text = "El Proceso aún se encuentra en TRAMITE'"
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
                Else
                    MsgResult.Text = "Se Radico correctamente el contrato con el No. " + obj.ResPRad.ToString
                    MsgBox(MsgResult, False)
                End If
            Else
                MsgResult.Text = "La fecha no puede ser inferior a la de la ultima radicación" '+ CDate(TxtFecRad.Text).ToLongDateString + CDate(TxtUFs.Text).ToLongDateString)
                Me.MsgBoxAlert(MsgResult, True)
            End If
        Else
            MsgResult.Text = "Debe seleccionar una fecha valida"
            Me.MsgBoxAlert(MsgResult, True)
        End If
    End Sub
End Class
