Imports System.Data
Partial Class Interventorias_Documentos_InfParciales
    Inherits PaginaComun

    Sub Guardar()
        Me.CodCon = Request("Cod_Con")
        Dim obj As New ActasParciales

        'Datos Básicos
        obj.Cod_Con = Me.hdCodCon.Value
        obj.Est_Ini = hdEstInicial.Value
        'Perido del Informe
        obj.Fec_PIni = TxtFecPFin.SelectedDate
        obj.Fec_Ent = TxtFecPFin.SelectedDate ' Fecha Final del Periodo
        'Valor Autorizado a Pagar
        obj.Val_Pago = TxtValAutPag.Text
        obj.Saldo_Per = TxtSaldoAnterior.Text
        'Avance de Ejecucón
        obj.Por_Eje_Fis = TxtPorEjeAcum.Text
        obj.Por_Eje_Fis_Per = TxtPorEjePer.Text
        obj.NVisitas = TxtNVisAcum.Text

        obj.fec_act = TxtFecAct.SelectedDate
        obj.NVis_Per = TxtNVisPer.Text
        obj.Fec_Act = TxtFecAct.SelectedDate 'Fecha del Documento
        'Notas, Recomendaciones y Observaciones
        obj.Obs = txtObs.Text
        If obj.Fec_PIni > obj.Fec_Ent Then
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
            MsgResult.Text = obj.Update(TxtNoDocumento.Text)
            Me.MsgBox(MsgResult, obj.lErrorG)
            If obj.lErrorG = False Then
                Habilitar(False)
            End If
        End If
    End Sub
    Sub Limpiar()
        Me.TxtNoDocumento.Text = ""
        Me.TxtFecAct.SelectedDate = Today
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
        txtFecAct.Enabled = v
        txtFecPFin.Enabled = v

        TxtPorEjePer.Enabled = v
        TxtNVisPer.Enabled = v
        txtFecPFin.Enabled = v
        txtFecPIni.Enabled = v
        TxtValAutPag.Enabled = v
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
            Dim Val_Con As Decimal = dt.Rows(0)("Valor_Total_Prop")
            'LbPlazoEje.Text = dt.Rows(0)("PLAZO_TEXTO").ToString
            Dim fs As New Date
            Dim Docfs As String = ""
            v.FechaSugerida(hdCodCon.Value, fs, Docfs)
            TxtSaldoAnterior.Text = Val_Con - v.GetValPagoAutorizado(hdCodCon.Value)
            LbFS.Text = fs
            TxtFecPIni.SelectedDate = fs.AddDays(1) 'Fecha Sugerida Inicial
            TxtFecPFin.SelectedDate = fs.AddMonths(1) 'Fecha Sugerida Final
            TxtFecAct.SelectedDate = Today
            LbDocFS.Text = Docfs
            TxtNVisAnt.Text = v.GetNVisitas(hdCodCon.Value)
            TxtPorEjeAnt.Text = v.GetPor_Eje_Fis(hdCodCon.Value)
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
            TxtNoDocumento.Text = Index
            Me.Oper = "Editar"
            Dim Obj As New ActasParciales
            Dim dt As DataTable = Obj.GetbyPk(Index)
            If dt.Rows.Count > 0 Then

                MsgResult.Text = "Editando Registro"
                MsgBoxInfo(MsgResult, False)
                Me.LbEst1.Visible = True
                TxtFecPIni.SelectedDate = dt.Rows(0)("FEC_PINI").ToString
                TxtFecPFin.SelectedDate = dt.Rows(0)("FECHA").ToString
                Me.LbEst1.Text = dt.Rows(0)("ESTado_FINAL").ToString
                TxtFecAct.SelectedDate = CDate(dt.Rows(0)("FEC_ACT").ToString).ToShortDateString
                txtObs.Text = dt.Rows(0)("OBSERVACION").ToString
                TxtValAutPag.Text = dt.Rows(0)("VALOR_PAGO").ToString

                TxtNVisPer.Text = dt.Rows(0)("NVis_Per").ToString

                TxtNVisAcum.Text = dt.Rows(0)("NVisitas").ToString
                TxtNVisAnt.Text = CInt(dt.Rows(0)("NVisitas").ToString) - CInt(dt.Rows(0)("NVis_Per").ToString)

                TxtPorEjePer.Text = dt.Rows(0)("Por_Eje_Fis_Per").ToString
                TxtPorEjeAcum.Text = dt.Rows(0)("Por_Eje_Fis").ToString

                TxtSaldoAnterior.Text = dt.Rows(0)("Saldo_Per").ToString
                TxtSaldo.Text = TxtSaldoAnterior.Text - TxtValAutPag.Text

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
        Catch ex As Exception
            MsgResult.Text = ex.Message
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
        valfecha = Obj.GetValFecha(Me.CodCon, Me.TxtFecPFin.SelectedDate)
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

    
  
End Class
