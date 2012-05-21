Imports System.Data
Imports System.Math
Imports System.Collections.Generic


Partial Class CtrlUsr_CalenProg_GActividades
    Inherits CtrlUsrComun

    Protected dsHolidays As DataTable
    Dim obj As New PCronogramas
    Dim oCal As New Calendario

#Region "Eventos del control"

    Public Event CancelClicked As EventHandler
    Public Event SaveNuevoClicked As EventHandler
    Public Event SaveSeguimientoClicked As EventHandler
    Public Event AnularClicked As EventHandler
    Public Event SaveEditadoClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        If Oper = "nuevo" Then
            RaiseEvent SaveNuevoClicked(sender, New EventArgs())
        End If
        If Oper = "editar" Then
            RaiseEvent SaveEditadoClicked(sender, New EventArgs())
        End If
        If Oper = "seguimiento" Then
            RaiseEvent SaveSeguimientoClicked(sender, New EventArgs())
        End If
        If Oper = "anular" Then
            RaiseEvent AnularClicked(sender, New EventArgs())
        End If
        If Oper = "cancelar" Then
            RaiseEvent CancelClicked(sender, New EventArgs())
        End If
    End Sub
#End Region
#Region "Propiedades de Interacción"
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
    Property Num_Proc As String
        Set(ByVal value As String)
            HdNumProc.Value = value
            Me.CboAct.DataBind()
        End Set
        Get
            Return HdNumProc.Value
        End Get
    End Property

    ''' <summary>
    ''' Numero de Proceso de Contratación asignado
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Id_Crono As String
        Set(ByVal value As String)
            ViewState("Id_Crono") = value
        End Set
        Get
            Return ViewState("Id_Crono")
        End Get
    End Property

#End Region

    Function ActividadPermitidaSoloDiaHabil() As Boolean
        Return (ChkDia_NoHabil.Checked = False)
    End Function
    
    Function ValidarCalendario() As Boolean

        Me.MsgResult.CssClass = ""
        Me.MsgResult.Text = ""
        If HdMFf.Value = "NO" Then
            TxtFechaF.Text = TxtFechaI.Text
            cbohor_f.Text = 18
        End If

        Dim fechaini As Date = Me.TxtFechaI.Text
        Dim fechafin As Date = Me.TxtFechaF.Text
        Dim horai As Integer = Me.cbohor_i.Text + cbomin_i.Text
        Dim horaf As Integer = Me.cbohor_f.Text + cbomin_f.Text

     
        Dim _horai As String = Me.cbohor_i.Text + ":" + cbomin_i.Text
        Dim _horaf As String = Me.cbohor_f.Text + ":" + cbomin_f.Text

        If fechaini > fechafin Then
            Me.MsgResult.Text = "Fecha Final debe ser mayor o igual a la Fecha Inicial"
            MsgBoxAlert(Me.MsgResult, True)
            Return False
        End If

        'Validar Si Son Dias Habiles
        If ActividadPermitidaSoloDiaHabil() Then '' Si es permitdo un dia no habil
            If (Weekday(fechaini) = 1 Or Weekday(fechaini) = 7 Or IsFestivo(fechaini)) Then
                Me.MsgResult.Text = "Fecha Inicial No Permitida. La Actividad sólo puede ser programada un dia hábil"
                MsgBoxAlert(Me.MsgResult, True)
                Return False
            End If
            If (Weekday(fechafin) = 1 Or Weekday(fechafin) = 7 Or IsFestivo(fechafin)) Then
                Me.MsgResult.Text = "Fecha Final No Permitida. La Actividad sólo puede ser programada un dia hábil"
                MsgBoxAlert(Me.MsgResult, True)
                Return False
            End If
        End If

        If (fechafin = fechaini) And (horai >= horaf) Then
            Me.MsgResult.Text = String.Format("La Hora Final debe ser mayor que la hora inicial, para una actividad de un mismo dia {0},{1}", horai, horaf)
            MsgBoxAlert(Me.MsgResult, True)
            Return False
        End If

        If ChkOcup.Checked = True Then
            If Oper = "nuevo" Then
                If Not obj.IsValid_Marcar_Ocupados(fechaini, _horai, fechafin, _horaf) Then
                    Me.MsgResult.Text = String.Format("Existe {0} Actividad(es) Marcadas cómo ocupadas en este periodo", obj.NActividadesOcup)
                    MsgBoxAlert(Me.MsgResult, True)
                    Return False
                End If
            Else
                If Not obj.IsValid_Marcar_Ocupados2(fechaini, _horai, fechafin, _horaf, Me.Pk1) Then
                    Me.MsgResult.Text = String.Format("Existe {0} Actividad(es) Marcadas cómo ocupadas en este periodo", obj.NActividadesOcup)
                    MsgBoxAlert(Me.MsgResult, True)
                    Return False
                End If

            End If
        End If

        Dim lstFechas As New List(Of Date)
        If String.IsNullOrEmpty(fechaini) Or String.IsNullOrEmpty(fechafin) Then
            Return False
        End If
        Dim dias As Integer = Abs(DateDiff(DateInterval.DayOfYear, CDate(fechafin), CDate(fechaini)))
        Dim fecha As Date = IIf(fechaini < fechafin, fechaini, fechafin)
        'LbDias.Text = "Dias Totales:" + (dias + 1).ToString
        'FillHolidayDataset()
        Dim Dias_hab As Integer = dias
        For i As Integer = i To Abs(dias)
            If ActividadPermitidaSoloDiaHabil() Then
                If Not (Weekday(fecha) = 1 Or Weekday(fecha) = 7 Or IsFestivo(fecha)) Then
                    'cal1.SelectedDates.Add(fecha)
                    lstFechas.Add(fecha)
                    Me.lstFechasSel = lstFechas
                Else
                    Dias_hab -= 1
                End If
            Else
                lstFechas.Add(fecha)
                Me.lstFechasSel = lstFechas
            End If

            fecha = fecha.AddDays(1)
        Next
        'OnAplicarClick(Me.BtnCancelar)
        Return True
    End Function
   

    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Anular()
        OnClick(sender)
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Cancelar()
        OnClick(sender)
    End Sub
    Protected Sub Limpiar()
        'Me.CboAct.Text = 
        HdEsFinalPA.Value = "NO"
        Me.TxtFechaI.Text = Now.ToShortDateString
        Me.TxtFechaF.Text = Now.ToShortDateString
        'Me.cbohorai.Text = 8
        Me.cbohor_i.Text = 8
        'Me.cbohoraf.DataBind()
        Me.cbohor_f.DataBind()
        'Me.UpdateHoraf.Update()
        Me.UpdHoraF2.Update()
        Me.cbomin_f.SelectedValue = "00"
        'Me.cbohoraf.Text = 18
        Me.cbohor_f.Text = 18
        Me.TxtUbicacion.Text = ""
        Me.TxtNotas.Text = ""
        'Me.cboDiasAviso.SelectedValue = 2
        Me.TxtFecAviso.Text = Today.ToShortDateString

        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        TxtObs.Text = ""
        TxtColor.Text = "000000"
        TxtColor.ForeColor = Util.HEXCOL2RGB("000000")
        cboEstAct.SelectedIndex = -1
        'Me.MultiView1.ActiveViewIndex = -1
    End Sub
    Protected Sub Habilitar(ByVal b As Boolean)
        Me.CboAct.Enabled = b
        Me.TxtFechaI.Enabled = b
        Me.TxtFechaF.Enabled = b
        Me.TxtColor.Enabled = b
        'Me.cbohorai.Enabled = b
        'Me.cbohoraf.Enabled = b
        Me.cbohor_i.Enabled = b
        Me.cbohor_f.Enabled = b
        Me.TxtUbicacion.Enabled = b
        Me.TxtNotas.Enabled = b
        Me.TxtFecAviso.Enabled = b

        Me.cbomin_i.Enabled = b
        Me.cbomin_f.Enabled = b

        Me.TxtObs.Enabled = b

        Me.cboEstAct.Enabled = b
        Me.TxtObs.ReadOnly = b

        Me.BtnEliminar.Enabled = b
        Me.BtnCancelar.Enabled = b
        Me.BtnGuardar.Enabled = b
        Me.BtnNuevo.Enabled = b

        TxtFechaI.Enabled = IIf(b = True, Util.SI_NO(HdMFi.Value), False)
        cbohor_i.Enabled = IIf(b = True, Util.SI_NO(HdMHi.Value), False)
        cbomin_i.Enabled = IIf(b = True, Util.SI_NO(HdMHi.Value), False)
        TxtFechaF.Enabled = IIf(b = True, Util.SI_NO(HdMFf.Value), False)
        cbohor_f.Enabled = IIf(b = True, Util.SI_NO(HdMHf.Value), False)
        cbomin_f.Enabled = IIf(b = True, Util.SI_NO(HdMHi.Value), False)
    End Sub

    Private Sub Guardar()


        Select Case Me.Oper
            Case "nuevo"
                If ValidarCalendario() = False Then
                    Return
                End If
                MsgResult.Text = obj.Insert(Me.Num_Proc, Me.CboAct.Text, CboAct.SelectedItem.Text, HdCod_TProc.Value, TxtFechaI.Text, cbohor_i.Text, TxtFechaF.Text, cbohor_f.Text, TxtUbicacion.Text, TxtNotas.Text, 0, ChkOcup.Checked, TxtColor.Text, ChkOblig.Checked, cboEstProc.SelectedValue, TxtFecAviso.Text, HdNotificar.Value, cbomin_i.SelectedValue, cbomin_f.SelectedValue, HdMFi.Value, HdMHi.Value, HdMFf.Value, HdMHf.Value, CInt(HdOrdenAct.Value), Me.lstFechasSel)
                Me.MsgBox(MsgResult, obj.lErrorG, 20)
                FillCustomerInGrid()
                If obj.lErrorG = False Then
                    Me.Habilitar(False)
                    Me.BtnCancelar.Enabled = True
                    Me.Oper = ""
                    Me.BtnGuardar.Enabled = False
                    Me.BtnNuevo.Enabled = True
                    OnClick(Me.BtnGuardar)
                End If

            Case "editar"
                If ValidarCalendario() = False Then
                    Return
                End If
                MsgResult.Text = obj.Update(Me.Pk1, Me.CboAct.Text, CboAct.SelectedItem.Text, HdCod_TProc.Value, TxtFechaI.Text, cbohor_i.Text, TxtFechaF.Text, cbohor_f.Text, TxtUbicacion.Text, TxtNotas.Text, 0, ChkOcup.Checked, TxtColor.Text, ChkOblig.Checked, cboEstProc.SelectedValue, TxtFecAviso.Text, HdNotificar.Value, cbomin_i.SelectedValue, cbomin_f.SelectedValue, HdMFi.Value, HdMHi.Value, HdMFf.Value, HdMHf.Value, Me.lstFechasSel)
                Me.MsgBox(MsgResult, obj.lErrorG, 20)
                FillCustomerInGrid()
                If obj.lErrorG = False Then
                    Me.Habilitar(False)
                    Me.BtnCancelar.Enabled = True
                    Me.Oper = ""
                    Me.BtnGuardar.Enabled = False
                    Me.BtnNuevo.Enabled = True
                    OnClick(Me.BtnGuardar)
                End If
            Case "seguimiento"
                Dim Notificar As Boolean = (Util.SI_NO(HdNotificar.Value) And Util.SI_NO(HdEsFinalPA.Value))
                MsgResult.Text = obj.UpdateEst(Me.Pk1, cboEstAct.SelectedValue, Me.TxtObs.Text, Notificar)
                Me.MsgBox(MsgResult, obj.lErrorG, 20)
                FillCustomerInGrid()
                If obj.lErrorG = False Then
                    Me.Habilitar(False)
                    Me.BtnCancelar.Enabled = True
                    Me.Oper = ""
                    Me.BtnGuardar.Enabled = False
                    Me.BtnNuevo.Enabled = True
                    OnClick(Me.BtnGuardar)
                End If

        End Select


    End Sub

    ReadOnly Property IsFestivo(ByVal fecha As Date) As Boolean
        Get
            Return oCal.IsFestivo(fecha)
        End Get
    End Property
    Private Sub FillCustomerInGrid()
        'Me.GridView1.SelectedIndex = -1
        'GridView1.DataBind()
    End Sub
    ''' <summary>
    ''' Prepara el control para crear una nueva actividad
    ''' </summary>
    ''' <param name="Num_Proc"></param>
    ''' <remarks></remarks>
    Public Sub Nuevo(ByVal Num_Proc As String, ByVal FechaIni As Date)
        TxtFechaI.Text = FechaIni
        TxtFechaF.Text = FechaIni

        Limpiar()



        Me.Oper = "nuevo"
        Me.Num_Proc = Num_Proc
        Me.CboAct.DataBind()
        If CboAct.Items.Count > 0 Then
            Me.Habilitar(True)
            Actualizar_Datos_Act()
        Else
            Me.Habilitar(False)
        End If
        Me.cboEstAct.Enabled = False
        Me.TxtObs.Enabled = False
        Me.BtnEliminar.Enabled = False
        Me.BtnNuevo.Enabled = False

    End Sub

    Private Sub Nuevo()
        Limpiar()
        TxtFechaI.Text = Today
        TxtFechaF.Text = Today
        Me.Oper = "nuevo"

        Me.CboAct.DataBind()

        If CboAct.Items.Count > 0 Then
            Me.Habilitar(True)
            Actualizar_Datos_Act()
        Else
            Me.MsgResult.Text = "No hay activiades disponibles para programar"
            MsgBox(MsgResult, False)
            Me.Habilitar(False)
        End If

        Me.cboEstAct.Enabled = False
        Me.TxtObs.Enabled = False
        Me.BtnEliminar.Enabled = False
        Me.BtnNuevo.Enabled = False

    End Sub
    Public Sub Editar(ByVal Num_Proc As String, ByVal Id_Crono As String)
        Me.Oper = "editar"
        Me.Num_Proc = Num_Proc
        Me.Id_Crono = Id_Crono
        Comando()
    End Sub
    Public Sub VerDetalles(ByVal Num_Proc As String, ByVal Id_Crono As String)
        Me.Oper = "ver"
        Me.Id_Crono = Id_Crono
        Me.Num_Proc = Num_Proc
        Comando()
    End Sub
    Public Sub Seguimiento(ByVal Num_Proc As String, ByVal Id_Crono As String)
        Me.Oper = "seguimiento"
        Me.Id_Crono = Id_Crono
        Me.Num_Proc = Num_Proc
        Comando()
      
    End Sub
    Public Sub Anular(ByVal Num_Proc As String, ByVal Id_Crono As String)
        Me.Oper = "anular"
        Me.Id_Crono = Id_Crono
        Me.Num_Proc = Num_Proc
        Comando()
    End Sub
    Private Sub Comando()
        Select Case Me.Oper
            Case "ver"
                MostrarActividad()
                Habilitar(False)
            Case "editar"
                MostrarActividad()
                Habilitar(False)
                'If (cboEstAct.SelectedValue <> "0003") And (cboEstAct.SelectedValue <> "0004") Then
                If HdEsFinal.Value <> "SI" Then
                    Habilitar(True)
                    BtnEliminar.Enabled = False
                    'Me.CboAct.Enabled = False
                End If
                Me.cboEstAct.Enabled = False
                Me.TxtObs.Enabled = False
                Me.BtnCancelar.Enabled = True
            Case "seguimiento"
                If MostrarActividad() Then
                    Habilitar(False)
                    'Si es diferente de aplazado y de completado, estado finales
                    'If (cboEstAct.SelectedValue <> "0003") And (cboEstAct.SelectedValue <> "0004") Then
                    If CType(HdDTFecIni.Value, DateTime) <= CType(Now, DateTime) Then
                        If (HdEsFinal.Value <> "SI") Then
                            Me.cboEstAct.Enabled = True
                            Me.TxtObs.Enabled = True
                            'Me.cboDiasAviso.Enabled = True
                            Me.TxtFecAviso.Enabled = True
                            Me.TxtNotas.Enabled = True
                            Me.TxtColor.Enabled = True
                            Me.BtnGuardar.Enabled = True
                        Else
                            Me.TxtObs.ReadOnly = True
                            Me.TxtObs.Enabled = True
                        End If
                        Me.BtnCancelar.Enabled = True
                    Else
                        MsgResult.Text = "Todavia no se puede iniciar la actividad"
                        MsgBoxAlert(MsgResult, True)
                    End If
                End If
            Case "anular"
                If MostrarActividad() Then
                    Habilitar(False)
                    'If (cboEstAct.SelectedValue <> "0003") And (cboEstAct.SelectedValue <> "0004") Then
                    If HdEsFinal.Value <> "SI" Then
                        Me.BtnEliminar.Enabled = True
                        Me.TxtObs.Enabled = True

                    End If
                End If
        End Select
        Me.BtnCancelar.Enabled = True
        Me.BtnNuevo.Enabled = False
    End Sub

    Private Function MostrarActividad() As Boolean
        MsgResult.Text = ""
        MsgResult.CssClass = ""

        Dim tb As DataTable = obj.GetbyPk(Me.Id_Crono)
        If tb.Rows.Count > 0 Then
            Me.CboAct.Text = tb.Rows(0)("Cod_Act").ToString.Trim

            Actualizar_Datos_Act()

            'Me.ChkOcup.Checked = IIf(tb.Rows(0)("Ocupado").ToString = "SI", True, False)
            'Me.ChkOblig.Checked = IIf(tb.Rows(0)("Obligatorio").ToString = "SI", True, False)
            'Me.cboEstProc.SelectedValue = tb.Rows(0)("Est_Proc").ToString
            'HdNotificar.Value = tb.Rows(0)("Notificar").ToString

            Me.TxtFechaI.Text = CDate(tb.Rows(0)("FechaI").ToString).ToShortDateString
            Me.TxtFechaF.Text = CDate(tb.Rows(0)("FechaF").ToString).ToShortDateString

            Me.cbohor_i.Text = tb.Rows(0)("horaI").ToString.Trim
            Me.cbohor_f.DataBind()
            Me.cbohor_f.Text = tb.Rows(0)("horaf").ToString.Trim

            Me.cbomin_i.Text = tb.Rows(0)("min_i").ToString.Trim
            Me.cbomin_f.Text = tb.Rows(0)("min_f").ToString.Trim

            Me.TxtUbicacion.Text = tb.Rows(0)("ubicacion").ToString.Trim
            Me.TxtNotas.Text = tb.Rows(0)("notas").ToString.Trim
            'Me.cboDiasAviso.Text = tb.Rows(0)("Dias_Aviso")
            Me.TxtFecAviso.Text = CDate(tb.Rows(0)("Fec_Aviso").ToString).ToShortDateString

            Me.cboEstAct.Text = tb.Rows(0)("est_act").ToString
            Me.TxtObs.Text = tb.Rows(0)("Obs_Seg").ToString
            Me.Pk1 = tb.Rows(0)("ID").ToString
            TxtColor.Text = tb.Rows(0)("COLOR").ToString
            TxtColor.ForeColor = Util.HEXCOL2RGB(tb.Rows(0)("COLOR").ToString)
            HdEsFinal.Value = tb.Rows(0)("IS_FINAL").ToString
            HdNotificar.Value = tb.Rows(0)("Notificar").ToString
            HdDTFecIni.Value = tb.Rows(0)("DateTimeI").ToString
          
            Return True
        Else
            Return False
        End If

    End Function

    Sub Cancelar()
        Limpiar()
        Me.Oper = "cancelar"
        OnClick(Me.BtnGuardar)
        Me.Oper = ""
    End Sub

    Sub Anular()
        If Oper = "anular" Then
            MsgResult.Text = obj.Anular(Me.Pk1, TxtObs.Text)
            Me.MsgBox(MsgResult, obj.lErrorG, 20)
            FillCustomerInGrid()
            If obj.lErrorG = False Then
                Me.Oper = ""
                Me.BtnEliminar.Enabled = False
            End If
        End If
    End Sub

    'Protected Overloads Sub MsgBox(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
    '    'msg.Height = alto
    '    'msg.Width = ancho
    '    msg.Visible = True
    '    'msg.CssClass = IIf(lError = True, "NotOk", "Ok")
    '    msg.ForeColor = IIf(lError = True, Drawing.Color.Red, Drawing.Color.Blue)

    'End Sub

    Protected Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Nuevo()
    End Sub

    Protected Sub CboAct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboAct.SelectedIndexChanged

        Actualizar_Datos_Act()

    End Sub

    Sub Actualizar_Datos_Act()
        Dim obj As New PActividades
        Dim dt As DataTable = obj.GetbyPk(Me.CboAct.SelectedValue, Me.HdNumProc.Value)
        If dt.Rows.Count > 0 Then
            Me.ChkOcup.Checked = Util.SI_NO(dt.Rows(0)("Ocupado"))
            Me.ChkOblig.Checked = Util.SI_NO(dt.Rows(0)("Obligatorio"))
            Me.cboEstProc.SelectedValue = dt.Rows(0)("Est_Proc")
            Me.HdCod_TProc.Value = dt.Rows(0)("Cod_TPro")
            Me.ChkDia_NoHabil.Checked = Util.SI_NO(dt.Rows(0)("dia_nohabil"))
            HdNotificar.Value = dt.Rows(0)("Notificar")

            HdMFi.Value = dt.Rows(0)("MFecIni")
            TxtFechaI.Enabled = Util.SI_NO(HdMFi.Value)

            HdMHi.Value = dt.Rows(0)("MHorIni")
            cbohor_i.Enabled = Util.SI_NO(HdMHi.Value)
            cbomin_i.Enabled = Util.SI_NO(HdMHi.Value)

            HdMFf.Value = dt.Rows(0)("MFecFin")
            TxtFechaF.Enabled = Util.SI_NO(HdMFf.Value)

            'MsgResult.Text = HdMFf.Value
            'MsgBoxAlert(MsgResult, True)

            HdMHf.Value = dt.Rows(0)("MHorIni")
            HdOrdenAct.Value = dt.Rows(0)("Orden")
            cbohor_f.Enabled = Util.SI_NO(HdMHf.Value)
            cbomin_f.Enabled = Util.SI_NO(HdMHi.Value)

            TxtUbicacion.Text = dt.Rows(0)("Ubicacion").ToString

            

        End If
        'MsgBoxLimpiar(MsgResult)

    End Sub

    Protected Sub TxtFechaI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFechaI.TextChanged
        Actualizar_Horario()
        '        MsgResult.Text = TxtFechaI.Text
        '       MsgBoxAlert(MsgResult, True)
        'TxtFechaF.Text = TxtFechaI.Text
        'UpdateAct.Update()
        'If HdMFf.Value.Trim = "NO" Then
        'UpdateAct.Update()
        'End If
    End Sub

    Protected Sub TxtFechaF_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFechaF.TextChanged
        Actualizar_Horario()
    End Sub

    Protected Sub cbohor_i_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbohor_i.SelectedIndexChanged
        Actualizar_Horario()
    End Sub

    Protected Sub cbomin_i_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbomin_i.SelectedIndexChanged
        Actualizar_Horario()
    End Sub

    Sub Actualizar_Horario()
      
        'If cbomin_i.SelectedIndex < 3 Then
        'cbomin_f.SelectedIndex = cbomin_i.SelectedIndex + 1
        'Else
        'cbohor_f.SelectedIndex = IIf(cbohor_f.SelectedValue < cbohor_f.Items.Count, cbohor_i.SelectedIndex + 1, cbohor_f.Items.Count)
        'cbomin_f.SelectedIndex = 0
        'End If

    End Sub

    Protected Sub BtnGuardar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Guardar()
        OnClick(sender)
    End Sub

    Protected Sub cboEstAct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEstAct.SelectedIndexChanged
        Dim pea As New PEstadosAct
        Dim dt As DataTable = pea.GetbyPK(cboEstAct.SelectedValue)
        If dt.Rows.Count > 0 Then
            HdEsFinalPA.Value = dt.Rows(0)("IS_FINAL")
        Else
            HdEsFinalPA.Value = "NO"
        End If


    End Sub
End Class
