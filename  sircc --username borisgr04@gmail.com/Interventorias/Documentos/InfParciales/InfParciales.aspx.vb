Imports System.Data
Partial Class Interventorias_Documentos_InfParciales
    Inherits PaginaComun

    Sub Guardar()
        Me.CodCon = Request("Cod_Con")
        Dim obj As New ActaInicio
        'Datos Requeridos para Acta de Inicio
        obj.Cod_Con = Me.hdCodCon.Value
        obj.Est_Ini = hdEstInicial.Value
        obj.Fec_Ent = CDate(txtFecDoc.Text)
        obj.Fec_Fin = CDate(TxtFecFin.Text)
        obj.Obs = txtObs.Text
        If obj.Fec_Ent > obj.Fec_Fin Then
            MsgResult.Text = "Fechas No Válidas, Verifique la Fecha Final sea posterior a la Fecha Inicial"
            Me.MsgBox(MsgResult, True)
            Return
        End If
        If Me.Oper = "Nuevo" Then
            MsgResult.Text = obj.Insert()
            Me.MsgBox(MsgResult, obj.lErrorG)
            If obj.lErrorG = False Then
                Habilitar(False)
                Me.NoID = obj.GetIdbyCod_con(Me.CodCon)
                Me.TxtNoDocumento.Text = Me.NoID
                Me.lBtnGenerar.Enabled = True
            End If
        ElseIf Me.Oper = "Editar" Then
            MsgResult.Text = obj.Update(Pk1, CDate(txtFecDoc.Text), txtObs.Text, CDate(TxtFecFin.Text))
            Me.MsgBox(MsgResult, obj.lErrorG)
            If obj.lErrorG = False Then
                Habilitar(False)
            End If
        End If
    End Sub
    Sub Limpiar()
        Me.TxtNoDocumento.Text = ""
        Me.txtFecDoc.Text = Today.ToShortDateString
        Me.txtObs.Text = "."
        LbEst1.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdCodCon.Value = Request("Cod_Con")
            Me.Oper = Request("Oper")
            Me.NoID = Request("NoID")
            Me.DtPCon.DataBind()
            mostrarDatos()
            Me.lBtnGenerar.Enabled = True
            Me.lBtnGenerar.CssClass = ""
        End If

    End Sub

    Sub Nuevo()
        If Me.Oper = "Nuevo" Then
            MsgResult.Text = " Agregando Nueva Acta"
            MsgBoxInfo(MsgResult, False)
            Habilitar(True)
            LbEst1.Visible = False
            ' BtnNuevo.Enabled = False
            IBtnGuardar.Enabled = True

            Me.Oper = "Nuevo"
            ' Me.CboEstSig.Visible = True
        End If
    End Sub

    Sub Habilitar(ByVal v As Boolean)
        txtFecDoc.Enabled = v
        TxtFecFin.Enabled = v
        txtObs.Enabled = v
        TxtNoDocumento.Enabled = False

        IBtnGuardar.Enabled = v
        IBtnGuardar.CssClass = cssEnabled(v)


    End Sub



    Sub EnableValidar(ByVal v As Boolean)
        Me.IBtnValidar.Enabled = v
        Me.LbValidar.Enabled = v
        Me.IBtnValidar.CssClass = cssEnabled(v)
    End Sub
    Sub EnableRevertir(ByVal v As Boolean)
        Me.IBtnRevertir.Enabled = v
        Me.LbRevertir.Enabled = v
        Me.IBtnRevertir.CssClass = cssEnabled(v)
        Me.lBtnGenerar.Enabled = v
        Me.lBtnGenerar.CssClass = cssEnabled(v)
    End Sub

    Protected Sub mostrarDatos()
        EnableRevertir(False)
        EnableValidar(False)
        Dim v As New ActasParciales
        Me.Panel1.Visible = False
        Dim dt As DataTable = v.GetByPkS(hdCodCon.Value)
        If dt.Rows.Count > 0 Then
            hdEstInicial.Value = dt.Rows(0)("Est_Con").ToString
            LbPlazoEje.Text = dt.Rows(0)("PLAZO_TEXTO").ToString
            Dim fs As New Date
            Dim Docfs As String = ""
            v.FechaSugerida(hdCodCon.Value, fs, Docfs)
            LbFS.Text = fs
            LbDocFS.Text = Docfs
            Me.DtPCon.DataSource = dt
            Me.DtPCon.DataBind()
            Me.Panel1.Visible = True
            Me.Habilitar(True)
            If (Me.Oper = "Nuevo") Then
                If Not v.EstEsValido(hdEstInicial.Value) Then
                    MsgResult.Text = "El Contrato, No Se Encuentra En El Estado Correspondiente para la Elaboración de Acta de Inicio: " + hdEstInicial.Value
                    MsgBoxAlert(Me.MsgResult, True)
                    Me.Panel1.Visible = True
                    Habilitar(False)
                Else
                    Habilitar(True)
                End If
            ElseIf (Me.Oper = "Editar") Then
                Editar(Me.NoID)
            End If
        End If
        UpdatePanel1.Update()
    End Sub

    Public Sub Editar(ByVal Index As String)
        Try
            Me.Oper = "Editar"
            Dim Obj As New ActasParciales
            Dim dt As DataTable = Obj.GetbyPk(Index)
            If dt.Rows.Count > 0 Then

                MsgResult.Text = "Editando Registro"
                MsgBoxInfo(MsgResult, False)
                Me.LbEst1.Visible = True
                ' Me.LbEst1.Text = dt.Rows(0)("ESTado_FINAL").ToString
                txtFecDoc.Text = CDate(dt.Rows(0)("FECHA").ToString).ToShortDateString
                TxtFecFin.Text = CDate(dt.Rows(0)("FEC_FIN").ToString).ToShortDateString
                txtObs.Text = dt.Rows(0)("OBSERVACION").ToString
                Me.TxtNoDocumento.Text = dt.Rows(0)("ID").ToString
                LbEstado.Text = dt.Rows(0)("Estado").ToString
                Me.Pk1 = dt.Rows(0)("ID").ToString
                If dt.Rows(0)("Estado").ToString = "BO" Then
                    Habilitar(True)
                    EnableRevertir(False)
                    EnableValidar(True)
                Else
                    Habilitar(False)
                    EnableValidar(False)
                    If Obj.GetEsUlt(Me.NoID) Then
                        EnableRevertir(True)
                        MsgResult.Text = "El Documento esta Activo, debe Desaprobarlo para Editarlo..."
                    Else
                        EnableRevertir(False)
                        MsgResult.Text = "El Documento esta Activo, debe Desaprobarlo para Editarlo..."
                    End If
                    MsgBoxAlert(MsgResult, False)
                End If
            Else

                MsgResult.Text = "No se encuentra el registro"
                MsgBoxAlert(MsgResult, True)
            End If
        Catch

        End Try
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Guardar()
    End Sub
    Protected Sub lBtnEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lBtnEditar.Click
        Me.Oper = "Editar"
        Editar(TxtNoDocumento.Text)
    End Sub

    Protected Sub lBtnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lBtnGenerar.Click
        Dim npa As New genActaInicio
        MsgBoxLimpiar(MsgResult)
        MsgResult.Text = npa.GenActa(hdCodCon.Value, CboPlantilla.SelectedValue, Me.TxtNoDocumento.Text)
        MsgBox(MsgResult, npa.lErrorG)
    End Sub

    Protected Sub lBtnAtras_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lBtnAtras.Click
        Redireccionar_Pagina(RutasPag.GetInstance.GetRuta("00"))
    End Sub

    Protected Sub IBtnValidar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnValidar.Click
        Dim Obj As New ActasParciales
        Dim valfecha As Boolean
        valfecha = Obj.GetValFecha(Me.CodCon, Me.txtFecDoc.Text)
        If valfecha = True Then
            MsgResult.Text = Obj.Msg
            Me.MsgBox(MsgResult, True)
        Else
            MsgResult.Text = Obj.ValActaEstado(TxtNoDocumento.Text) 'Actualiza Estado
            Habilitar(False)
            Me.MsgBox(MsgResult, Obj.lErrorG)
            If Not Obj.lErrorG Then
                mostrarDatos()
            End If
        End If



    End Sub

    Protected Sub IBtnRevertir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnRevertir.Click
        Dim Obj As New ActasParciales
        MsgResult.Text = Obj.RevActaEstado(TxtNoDocumento.Text) 'Revierte a Borrador
        Habilitar(False)
        Me.MsgBox(MsgResult, Obj.lErrorG)
        mostrarDatos()
    End Sub

    Protected Sub IBtnVerDoc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnVerDoc.Click
        If Not String.IsNullOrEmpty(TxtNoDocumento.Text) Then
            Redireccionar_Pagina("/ashx/VerActas.ashx?Ide_Acta=" + TxtNoDocumento.Text)
        End If
    End Sub

    Protected Sub txtFecDoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecDoc.TextChanged
        Calcular()
    End Sub

    Sub Calcular()
        If ChkCalcular.Checked = True Then
            If IsDate(txtFecDoc.Text) Then
                Dim fi As Date = txtFecDoc.Text
                Dim ff As Date
                Dim c As New ActasParciales
                Dim dt As DataTable = c.GetByPkS(hdCodCon.Value)
                Dim tp1 As String = dt.Rows(0)("Tipo_Plazo")
                Dim pe1 As Integer = dt.Rows(0)("Plazo1_Eje_Con")

                Dim tp2 As String = IIf(IsDBNull(dt.Rows(0)("Tipo_Plazo2")), "", dt.Rows(0)("Tipo_Plazo2"))
                Dim pe2 As Integer = dt.Rows(0)("Plazo2_Eje_Con")

                If dt.Rows.Count > 0 Then
                    Select Case tp1
                        Case "D"
                            ff = fi.AddDays(pe1)
                        Case "M"
                            ff = fi.AddMonths(pe1)
                            If pe2 > 0 Then
                                ff = ff.AddDays(pe2)
                            End If
                        Case "A"
                            ff = fi.AddYears(pe1)
                            If pe2 > 0 Then
                                ff = ff.AddMonths(pe2)
                            End If
                    End Select
                End If
                TxtFecFin.Text = ff.AddDays(-1)
            End If

        End If

    End Sub
End Class
