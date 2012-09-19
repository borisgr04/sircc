Imports System.Data
Partial Class Reportes_Dinamico_RptDinamico
    Inherits PaginaComun
    Dim dt As DataTable
    Dim obj As New BDDatos

    Property hasDatos As Boolean
        Set(ByVal value As Boolean)
            ViewState("hasDatos") = value
        End Set
        Get
            Return ViewState("hasDatos")
        End Get
    End Property
    Function CargarDatos() As Boolean
        Dim SqlCount As String = "Select Count(*) Cant From  " + SelCampos1.Vista + " " + FiltroContratos1.strFiltro
        hasDatos = False
        Try
            dt = obj.GetSelect(SqlCount)
            If dt.Rows(0)("Cant") > 0 Then
                hasDatos = True
            Else
                hasDatos = False
                Return False
            End If
        Catch ex As Exception
            Label1.Text = ex.Message
            MsgBox(Label1, True)
        End Try
        Return hasDatos
    End Function
    Protected Sub Wizard1_ActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Wizard1.ActiveStepChanged
        If Wizard1.ActiveStepIndex = 3 Then

            If CargarDatos() Then
                lbConsolidados.Text = ""
                Label1.Text = "Presione Botón Finalizar para Exportar el Informe"
                MsgBoxInfo(Label1, True)
                For Each itemSelSelect In SelCamposC1.ListaSelect
                    lbConsolidados.Text += itemSelSelect.Titulo + "<br/>"
                Next
                If SelCamposC1.ListaSelect.Count > 0 Then
                    lbConsolidados.Text = "<b>CONSOLIDADOS</b><br>" + lbConsolidados.Text + "<br/>"
                End If
            Else
                Label1.Text = "No Genero Datos"
                MsgBoxAlert(Label1, True)
            End If

        End If
    End Sub

    Protected Sub Wizard1_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick
        Finalizar2()
    End Sub

    Sub Finalizar1()
        If hasDatos Then
            Dim Sql As String = "Select " + SelCampos1.Campos + " From  " + SelCampos1.Vista + " " + FiltroContratos1.strFiltro
            dt = obj.GetSelect(Sql)
            GridView1.DataSource = dt
            GridView1.DataBind()
            ExportGridView(GridView1)
        Else
            Label1.Text = "No Hay Datos a Exportar"
            MsgBoxAlert(Label1, True)
        End If
    End Sub

    Sub Finalizar2()
        'If hasDatos Then
        If (Not String.IsNullOrEmpty(SelCampos1.Campos)) Or (SelCamposC1.ListaSelect.Count > 0) Then

            Try

                ExportGridViewIni("InformeContratacion")
                Dim filtro As String = FiltroContratos1.strFiltro
                If Not String.IsNullOrEmpty(SelCampos1.Campos) Then ' Si esocgio campos
                    ExportGridViewWrite("<b>REPORTE DETALLADO</b>")
                    Dim Sql As String = "Select " + SelCampos1.Campos + " From  " + SelCampos1.Vista + " " + filtro
                    'Throw New Exception(Sql)
                    dt = obj.GetSelect(Sql)
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    ExportGridViewBody(GridView1)
                End If
                Dim lselect As New List(Of SelSelect)
                lselect = SelCamposC1.ListaSelect
                filtro = FiltroContratos1.strFiltroSinOrder
                'Throw New Exception(SelCamposC1.ListaSelect.Count)
                For Each itemSelSelect In lselect
                    ExportGridViewWrite("<br/>")
                    'SE IMPRIME TITULO
                    ExportGridViewWrite("<b>" + itemSelSelect.Titulo + "</b>")
                    'Consultar Lsitado Agrupado
                    dt = obj.GetSelect(itemSelSelect.strSelect.Replace("{filtro}", filtro))
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    'Imprimirlo
                    ExportGridViewBody(GridView1)
                    'Consultar Total
                    dt = obj.GetSelect(itemSelSelect.strSelectCount.Replace("{filtro}", filtro))
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    'Imprimirlo

                    ExportGridViewBody(GridView1)
                    'Nueva Linea
                Next

            Catch ex As Exception
                Label1.Text = ex.Message
                MsgBoxAlert(Label1, True)
            Finally
                ExportGridViewFin()

            End Try

        Else
            Label1.Text = "No Hay Datos a Exportar"
            MsgBoxAlert(Label1, True)
        End If

    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub


    Protected Sub Wizard1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Wizard1.Load

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()


    End Sub

    'Protected Sub Wizard1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Wizard1.PreRender
    '    Dim SideBarList As Repeater = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList")
    '    SideBarList.DataSource = Wizard1.WizardSteps
    '    SideBarList.DataBind()
    'End Sub

    Protected Function GetClassForWizardStep(ByVal wizardStep As Object) As String
        Dim [step] As WizardStep = TryCast(wizardStep, WizardStep)
        If [step] Is Nothing Then
            Return ""
        End If
        Dim stepIndex As Integer = Wizard1.WizardSteps.IndexOf([step])
        If stepIndex < Wizard1.ActiveStepIndex Then
            Return "prevStep"
        ElseIf stepIndex > Wizard1.ActiveStepIndex Then
            Return "nextStep"
        Else
            Return "currentStep"
        End If
    End Function

End Class
