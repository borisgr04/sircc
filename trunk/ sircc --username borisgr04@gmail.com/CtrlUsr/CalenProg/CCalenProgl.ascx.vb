Imports System.Data
Imports System.Math
Imports System.Collections.Generic

Partial Class CtrlUsr_CalenProg_CCalenProgl
    Inherits CtrlUsrComun
    Protected dsHolidays As DataTable
    Dim obj As New PCronogramas

#Region "Eventos del control"
    ''' <summary>
    ''' Evento Aceptar del Control
    ''' </summary>
    ''' <remarks></remarks>
    Public Event AplicarClicked As EventHandler
    Public Event CambiarEstProc As EventHandler


    Protected Overridable Sub OnCambiarEstProc(ByVal sender As Object)
        RaiseEvent CambiarEstProc(sender, New EventArgs())
    End Sub

    Protected Overridable Sub OnAplicarClick(ByVal sender As Object)
        RaiseEvent AplicarClicked(sender, New EventArgs())
    End Sub
#End Region
#Region "Propiedades de Interacción"

    Public Property UpdateMode() As UpdatePanelUpdateMode
        Get
            Return Me.UpdateHora.UpdateMode
        End Get
        Set(ByVal value As UpdatePanelUpdateMode)
            ' Me.UpdateHora.UpdateMode = value
        End Set
    End Property

    Public Sub Update()
        Me.UpdateHora.Update()
    End Sub

    ''' <summary>
    ''' Listado de Fechas seleccionadas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property lstFechasSel As List(Of Date)
        Set(ByVal value As List(Of Date))
            ViewState("LstFechas") = value
        End Set
        Get
            Return DirectCast(ViewState("LstFechas"), List(Of Date))
        End Get
    End Property
    ''' <summary>
    ''' Numero de Proceso de Contratación asignado
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Num_Proc As String
        Set(ByVal value As String)
            HdNumProc.Value = value
            Actualizar_Crono()
        End Set
        Get
            Return HdNumProc.Value
        End Get
    End Property

    ''' <summary>
    ''' Filtro
    ''' </summary>
    ''' <value>Filtro que se ejecuta en el Where de la Consulta SQL</value>
    ''' <remarks></remarks>
    Public Property Filtro As String
        Set(ByVal value As String)
            HdFiltro.Value = value
            Actualizar_Crono()
        End Set
        Get
            Return HdFiltro.Value
        End Get
    End Property
    Public WriteOnly Property MododeVista As BgrModoVista
        Set(ByVal value As BgrModoVista)
            If value = BgrModoVista.VistaTabla Then
                MultiView1.ActiveViewIndex = BgrModoVista.VistaTabla
                rdTabla.Checked = True
                Actualizar_Crono()
            ElseIf value = BgrModoVista.VistaCalendario Then
                MultiView1.ActiveViewIndex = BgrModoVista.VistaCalendario
                rdCalendario.Checked = True
                cal1.VisibleDate = obj.GetFechaPrimerEventobyFiltro(Me.Filtro)
                Cargar_Dias()
            ElseIf value = BgrModoVista.Ninguno Then
                MultiView1.ActiveViewIndex = BgrModoVista.Ninguno
            End If
            UpdateHora.Update()
        End Set
    End Property
    Public WriteOnly Property MostrarMododeVista As Boolean
        Set(ByVal value As Boolean)
            Me.rdTabla.Visible = value
            Me.rdCalendario.Visible = value
        End Set
    End Property

    Enum BgrModoVista
        Ninguno = -1
        VistaTabla = 0
        VistaCalendario = 1
    End Enum

#End Region

#Region "Calendario"
    ''' <summary>
    ''' Reenlaza el Control de Datos y Llama a MyBase.DataBind()
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub DataBind()
        MyBase.DataBind()
        FillCustomerInGrid()
        Cargar_Dias()
    End Sub

    Public Sub Cargar_Dias()
        Dim startDate As DateTime = New DateTime(cal1.VisibleDate.Year, cal1.VisibleDate.Month, 1).AddDays(-7)
        Dim endDate As DateTime = New DateTime(cal1.VisibleDate.Date.AddMonths(1).Year, cal1.VisibleDate.Date.AddMonths(1).Month, 1).AddDays(7)
        Dim dt As DataTable = GetEventData(startDate, endDate)
        cal1.DataSource = dt
        cal1.DataBind()
    End Sub
    Function GetEventData(ByVal startDate As DateTime, ByVal endDate As DateTime) As DataTable
        'Dim Obj As Calendario = New Calendario
        Dim Obj As PCronogramas = New PCronogramas
        Dim ObjP As New PContratos
        Dim dtEvent As DataTable = Obj.GetCronogramabyFiltro(startDate, endDate, Me.Filtro)


        Return dtEvent
    End Function
    Sub MonthChange(ByVal o As Object, ByVal e As MonthChangedEventArgs)
        Dim startDate As DateTime = e.NewDate.AddDays(-7)
        Dim endDate As DateTime = e.NewDate.AddMonths(1).AddDays(7)
        Dim dt As DataTable = GetEventData(startDate, endDate)
        cal1.DataSource = dt
    End Sub
    Protected Sub cal1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles cal1.DayRender
        ''Si es Domingo o Sábado
        If e.Day.IsWeekend Then
            e.Day.IsSelectable = False
        End If
        If IsFestivo(e.Day.Date) Then
            e.Day.IsSelectable = False
            'e.Cell.BackColor = Util.HEXCOL2RGB("#992200") 'Casi Rojo #992200 #CCCCFF
            e.Cell.ForeColor = Util.HEXCOL2RGB("#992200") 'Casi Rojo #992200 #CCCCFF
            e.Cell.Font.Bold = True
            e.Cell.Font.Name = "Arial"
            e.Cell.ToolTip = "Festivo [" + e.Day.Date.ToLongDateString + "]"
        Else
            e.Cell.ToolTip = e.Day.Date.ToLongDateString ' "Agregar Actividad " + e.Day.Date.ToLongDateString
        End If

    End Sub

    Protected Function GetFirstDayOfNextMonth() As DateTime
        Dim monthNumber, yearNumber As Integer
        If cal1.VisibleDate.Month = 12 Then
            monthNumber = 1
            yearNumber = cal1.VisibleDate.Year + 1
        Else
            monthNumber = cal1.VisibleDate.Month + 1
            yearNumber = cal1.VisibleDate.Year
        End If
        Dim lastDate As New DateTime(yearNumber, monthNumber, 1)
        Return lastDate
    End Function
    Function GetCurrentMonthData(ByVal firstDate As DateTime, ByVal lastDate As DateTime) As DataTable
        Dim dsMonth As New DataSet
        Dim Obj As Calendario = New Calendario
        Return Obj.GetFestivos(firstDate, lastDate)
    End Function

    Protected Sub cal1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cal1.SelectionChanged
        'NuevoCal()
    End Sub

#End Region

#Region "Festivos"
    '------------------------------
    ReadOnly Property IsFestivo(ByVal TablaFestivo As DataTable, ByVal fecha As Date) As Boolean
        Get
            Dim value As Boolean = False
            If TablaFestivo.Rows.Count > 0 Then
                Dim nextdate As DateTime
                For Each dr As DataRow In TablaFestivo.Rows
                    nextdate = CType(dr("Fecha"), DateTime)
                    If nextdate = fecha Then
                        value = True
                    End If
                Next
            End If
            Return value
        End Get
    End Property
    ReadOnly Property IsFestivo(ByVal fecha As Date) As Boolean
        Get
            FillHolidayDataset()
            Dim value As Boolean = False
            If dsHolidays.Rows.Count > 0 Then
                Dim nextdate As DateTime
                For Each dr As DataRow In dsHolidays.Rows
                    nextdate = CType(dr("Fecha"), DateTime)
                    If nextdate = fecha Then
                        value = True
                    End If
                Next
            End If
            Return value

        End Get
    End Property
    Protected Sub FillHolidayDataset()
        Dim firstDate As New DateTime(cal1.VisibleDate.Year, _
             cal1.VisibleDate.Month, 1)
        Dim lastDate As DateTime = GetFirstDayOfNextMonth()
        dsHolidays = GetCurrentMonthData(firstDate, lastDate)
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.TxtColor.Attributes.Add("onBlur", "UpdateColor")

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Me.Oper = e.CommandName
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.GridView1.SelectedIndex = index
        Select Case Me.Oper
            Case "editar"
                GActividades1.Editar(Num_Proc, GridView1.SelectedValue)
                Me.ModalPopupAct.Show()
            Case "seguimiento"
                GActividades1.Seguimiento(Num_Proc, GridView1.SelectedValue)
                Me.ModalPopupAct.Show()
            Case "anular"
                GActividades1.Anular(Num_Proc, GridView1.SelectedValue)
                Me.ModalPopupAct.Show()

        End Select
    End Sub



    Private Sub FillCustomerInGrid()
        Me.GridView1.SelectedIndex = -1
        GridView1.DataBind()
    End Sub


    Sub NuevoCal()
        Dim f As Date = IIf(cal1.SelectedDates.Count > 0, cal1.SelectedDate, Today)
        GActividades1.Nuevo(Me.Num_Proc, f)
        Cargar_Dias()
        Me.ModalPopupAct.Show()
    End Sub


    Sub Nuevo()
        GActividades1.Nuevo(Me.Num_Proc, Today)
        Cargar_Dias()
        Me.ModalPopupAct.Show()
    End Sub

    Protected Sub GActividades1_AnularClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles GActividades1.AnularClicked
        Actualizar_Crono()
    End Sub

    Protected Sub GActividades1_CancelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles GActividades1.CancelClicked
        Actualizar_Crono()
        OnCambiarEstProc(sender)
        Me.ModalPopupAct.Hide()

    End Sub

    Protected Sub GActividades1_SaveEditadoClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles GActividades1.SaveEditadoClicked
        Actualizar_Crono()
    End Sub

    Protected Sub GActividades1_SaveNuevoClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles GActividades1.SaveNuevoClicked
        Actualizar_Crono()
    End Sub

    Protected Sub GActividades1_SaveSeguimientoClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles GActividades1.SaveSeguimientoClicked
        Actualizar_Crono()

    End Sub

    Sub Actualizar_Crono()
        GridView1.DataSource = obj.GetbyFiltro(Filtro)
        GridView1.DataBind()
        Cargar_Dias()

    End Sub

    Protected Sub LnkNu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkNu.Click, LnkNu0.Click
        If MultiView1.ActiveViewIndex = 0 Then
            Nuevo()
        Else
            NuevoCal()
        End If
    End Sub

    Protected Sub rdTabla_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdTabla.CheckedChanged
        If rdTabla.Checked = True Then
            MultiView1.ActiveViewIndex = 0
            Actualizar_Crono()
        End If
    End Sub

    Protected Sub rdCalendario_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdCalendario.CheckedChanged
        If rdCalendario.Checked = True Then
            MultiView1.ActiveViewIndex = 1
            cal1.VisibleDate = obj.GetFechaPrimerEvento(Me.Num_Proc)
            Cargar_Dias()

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        GActividades1.VerDetalles(Num_Proc, GridView1.SelectedValue)
        Me.ModalPopupAct.Show()
    End Sub
End Class

