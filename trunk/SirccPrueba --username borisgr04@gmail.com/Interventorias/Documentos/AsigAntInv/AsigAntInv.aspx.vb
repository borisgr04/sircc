Imports System.Data
Partial Class Contratos_GesContratos_Default
    Inherits PaginaComun


    Sub Guardar()
        Me.CodCon = Request("Cod_Con")
        If Me.Oper = "Nuevo" Then
            Dim obj As New ActaAnticipo
            Dim est_ini As String = "09"
            Dim est_sig As String = "08"
            MsgResult.Text = obj.Insert(Me.CodCon, est_ini, est_sig, CDate(txtFecDoc.Text), txtObs.Text, Publico.PuntoPorComa(Me.TxtValPago.Text))
            Me.MsgBox(MsgResult, obj.lErrorG)
            If obj.lErrorG = False Then
                ' Limpiar()
                Habilitar(False)
                Me.NoID = obj.GetIdbyCod_con(Me.CodCon)
                Me.TxtNoDocumento.Text = Me.NoID
                llenar_GRid2(Me.NoID)
                'BtnNuevo.Enabled = True
            End If
        ElseIf Me.Oper = "Editar" Then
            Dim obj As New ActaAnticipo
            Dim VanticipoRealiz As Long

            VanticipoRealiz = obj.GetSUMbyPkI(Me.NoID)
            If TxtValPago.Text >= VanticipoRealiz Then
                MsgResult.Text = obj.Update(Pk1, CDate(txtFecDoc.Text), txtObs.Text, Publico.PuntoPorComa(Me.TxtValPago.Text))
                Me.MsgBox(MsgResult, obj.lErrorG)
                If obj.lErrorG = False Then
                    ' Limpiar()
                    Habilitar(False)
                    ActualizarPorcentajesTabla()
                    llenar_GRid2(Me.NoID)
                    ' BtnNuevo.Enabled = True
                End If

            Else
                MsgResult.Text = "Valor Autorizado del Pago Es Menor, Que el Valor Asignados Actualmente a los Anticipos"
                MsgBoxAlert(Me.MsgResult, True)
                llenar_GRid2(Me.NoID)
            End If



        End If


    End Sub
    Sub ActualizarPorcentajesTabla()
        Dim i As Integer
        Dim ValPorcentaje As Decimal
        Dim ID_CONT1, COD_INVAN1, VAL_INVAN1 As String
        Dim obj As New ActaAnticipo
        Dim dataTb As DataTable

        Try
            dataTb = obj.GetAnticipos(Me.NoID)

            If dataTb.Rows.Count > 0 Then

                For i = 0 To dataTb.Rows.Count - 1
                    ID_CONT1 = dataTb.Rows(i)("ID_CONT")
                    COD_INVAN1 = dataTb.Rows(i)("COD_INVAN")
                    VAL_INVAN1 = dataTb.Rows(i)("VAL_INVAN")

                    ValPorcentaje = Convert.ToDecimal(VAL_INVAN1) * 100 / Convert.ToDecimal(Me.TxtValPago.Text)
                    MsgResult2.Text = obj.UpdatePorcentajes(ID_CONT1, COD_INVAN1, ValPorcentaje)

                    Me.MsgBox(MsgResult2, obj.lErrorG)
                Next
            End If

        Catch ex As Exception
            MsgResult2.Text = ex.Message
            MsgBox(MsgResult2, True)
        End Try


    End Sub
    Sub Limpiar()

        Me.TxtNoDocumento.Text = ""
        Me.TxtValPago.Text = 0

        Me.txtFecDoc.Text = Today.ToShortDateString
        Me.txtObs.Text = "."

        LbEst1.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        
        If Not Page.IsPostBack Then

            txtvalor.Attributes.Add("onblur", "CalculatePor();")
            txtporcentaje.Attributes.Add("onblur", "CalculateVal();")
            hdCodCon.Value = Request("Cod_Con")
            Me.Oper = Request("Oper")
            Me.NoID = Request("NoID")
            Me.grdInformes.Visible = False
            mostrarDatos()
            If Me.Oper = "Editar" Then
                llenar_GRid2(Me.NoID)
            End If
        End If

    End Sub
    Protected Sub grdInformes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdInformes.SelectedIndexChanged

        Me.MsgBoxLimpiar(MsgResult)
    End Sub

    Protected Sub grdInformes_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdInformes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdInformes_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdInformes.RowEditing
        grdInformes.EditIndex = e.NewEditIndex
        FillCustomerInGrid()
    End Sub
    Private Sub FillCustomerInGrid()
        Me.grdInformes.DataBind()

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
        txtObs.Enabled = v
        TxtNoDocumento.Enabled = False
        TxtValPago.Enabled = v

        PnlPIA.Enabled = v
        IBtnGuardar.Enabled = v
        IBtnGuardar.CssClass = cssEnabled(v)

        
    End Sub
    Protected Sub llenar_GRid2(ByVal ConId As String)
        Dim c As New ActaAnticipo
        Dim dt As DataTable = c.GetRecordsDBbyPk1(ConId)
        Me.grdInformes.Visible = True
        Me.grdInformes.DataSource = dt
        Me.grdInformes.DataBind()

    End Sub

    

    Sub Cancelar()
        Me.Oper = ""
        'Me.Limpiar()
        Me.MsgBoxLimpiar(MsgResult)
        Me.MsgBoxLimpiar(MsgResult2)
        Me.Habilitar(False)
        llenar_GRid2(Me.NoID)
        '' Me.BtnNuevo.Enabled = True
        VolverPanel()
    End Sub
    Sub VolverPanel()
        Redireccionar_Pagina(RutasPag.GetInstance.GetRuta("00"))
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
        Dim v As New ActaAnticipo
        Me.Panel1.Visible = False
        Dim dt As DataTable = v.GetByPkS(hdCodCon.Value)
        If dt.Rows.Count > 0 Then
            Me.DtPCon.DataSource = dt
            Me.DtPCon.DataBind()
            Me.Panel1.Visible = True
            Dim fs As New Date
            Dim Docfs As String = ""
            v.FechaSugerida(hdCodCon.Value, fs, Docfs)
            LbFS.Text = fs
            LbDocFS.text = Docfs
            Me.Habilitar(True)
            If (Me.Oper = "Nuevo") Then
                If dt.Rows(0)("Est_Con").ToString <> "09" Then
                    MsgResult.Text = "El Contrato, No Se Encuentra En El Estado Correspondiente Para Hacer Plan De Anticipo"
                    MsgBoxAlert(Me.MsgResult, True)
                    Me.Panel1.Visible = False
                End If
            ElseIf (Me.Oper = "Editar") Then
                Editar(Me.NoID)
                llenar_GRid2(Me.NoID)
            End If
        End If

    End Sub
  
    Public Sub Editar(ByVal Index As String)
        Me.Oper = "Editar"
        Dim Obj As ActaAnticipo = New ActaAnticipo()
        Dim dt As DataTable = Obj.GetbyPk(Index)
        If dt.Rows.Count > 0 Then
            MsgResult.Text = "Editando Registro"
            MsgBoxInfo(MsgResult, False)
            Me.LbEst1.Visible = True
            ' Me.LbEst1.Text = dt.Rows(0)("ESTado_FINAL").ToString
            txtFecDoc.Text = CDate(dt.Rows(0)("FECHA").ToString).ToShortDateString
            txtObs.Text = dt.Rows(0)("OBSERVACION").ToString
            TxtValPago.Text = dt.Rows(0)("Valor_Pago").ToString.Replace(Publico.Punto_DecOracle, ".")
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
                    MsgResult.Text = "El Documento No es Ultimo Documento Activo. No Puede Revertirse "
                End If
                MsgBoxAlert(MsgResult, False)
            End If
        Else
            MsgResult.Text = "No se encuentra el registro"
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub

    Protected Sub grdInformes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdInformes.RowCommand

        Dim Obj As New ActaAnticipo
        Dim ValActualAnticipo, VanticipoRealiz As Long
        Me.Oper2 = e.CommandName
        VanticipoRealiz = Obj.GetSUMbyPkI(Me.NoID)
        ValActualAnticipo = Convert.ToInt32(TxtValPago.Text) - Convert.ToInt32(VanticipoRealiz)
        Me.lbValorD.Text = ValActualAnticipo

        Select Case Me.Oper2

            Case "Nuevo"
                If Me.lbValorD.Text <> "0" Then
                    Me.SubT.Text = "Nuevo..."
                    Habilitar2("New")
                    Limpiar2()
                    Me.ModalPopupTer.Show()
                Else
                    MsgResult2.Text = "Valor Asignado de los Anticipos...Completo"
                    Obj.lErrorG = True
                    MsgBox(MsgResult2, True)
                End If

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.grdInformes.SelectedIndex = index

                If Obj.GetbyPkID1(grdInformes.DataKeys(index).Values(0).ToString(), Me.NoID) Then
                    Try
                        Limpiar2()
                        txtvalor.Text = Obj.VAL_INVAN
                        txtporcentaje.Text = Obj.VPORCENT
                        CboEstado.Text = Obj.EST_INVAN_CONT
                        CboPlanAnticipo.Text = Obj.COD_INVAN

                        Me.lbValorD.Text = Convert.ToInt32(Me.lbValorD.Text) + Convert.ToInt32(txtvalor.Text)

                        Me.Pk1 = Obj.COD_INVAN
                        Me.ModalPopupTer.Show()

                        Habilitar2("Edit")

                        Me.MsgResult2.Text = "Editando: Código [" + Me.Pk1 + "]"
                    Catch ex As Exception
                        MsgResult2.Text = ex.Message
                        MsgBox(MsgResult2, True)
                    End Try
                End If



            Case "Eliminar"
                Me.SubT.Text = "Eliminando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.grdInformes.SelectedIndex = index
                Pk1 = grdInformes.DataKeys(index).Values(0).ToString()
                If Obj.GetbyPkID1(grdInformes.DataKeys(index).Values(0).ToString(), Me.NoID) Then
                    Try
                        txtvalor.Text = Obj.VAL_INVAN
                        txtporcentaje.Text = Obj.VPORCENT
                        CboEstado.Text = Obj.EST_INVAN_CONT
                        CboPlanAnticipo.Text = Obj.COD_INVAN
                        Me.Pk1 = Obj.ID_CONT
                        Me.ModalPopupTer.Show()
                        Habilitar2("Delete")
                        Me.MsgResult2.Text = "Eliminando: Código [" + Me.Pk1 + "]"

                    Catch ex As Exception
                        MsgResult2.Text = ex.Message
                        MsgBox(MsgResult2, True)
                    End Try


                End If
                Me.ModalPopupTer.Show()
            Case "Exportar"
                ExportGridView(grdInformes, "Registro de Plan De Inversión Y Anticipos")
        End Select
        llenar_GRid2(NoID)

    End Sub
   
    Protected Sub Guardar2()
        Dim Obj As New ActaAnticipo
        Try
            Obj.VAL_INVAN = txtvalor.Text
            Obj.VPORCENT = txtporcentaje.Text
            Obj.EST_INVAN_CONT = CboEstado.SelectedValue
            Obj.COD_INVAN = CboPlanAnticipo.SelectedValue
            Obj.ID_CONT = Me.NoID
        Catch ex As Exception
            MsgResult2.Text = ex.Message
            MsgBox(MsgResult2, True)
            Return
        End Try

            Select Case Me.Oper2
                Case "Nuevo"
                If Obj.GetbyPkID1(CboPlanAnticipo.Text, Me.NoID) Then
                    MsgResult2.Text = "Imposible Registrar, Esté Plan de Anticipo, Ya se Insertó un Valor"
                    Obj.lErrorG = True
                    llenar_GRid2(Me.NoID)
                Else
                    If Convert.ToInt32(Me.txtvalor.Text) <= Convert.ToInt32(Me.lbValorD.Text) Then
                        MsgResult2.Text = Obj.Insert1()
                    Else
                        MsgResult2.Text = "El Valor Excede, el Total del Acumulado de los Anticipos"
                        Obj.lErrorG = True
                    End If

                End If

            Case "Editar"
                If Convert.ToInt32(Me.txtvalor.Text) <= Convert.ToInt32(Me.lbValorD.Text) Then
                    MsgResult2.Text = Obj.Update1(NoID, CboPlanAnticipo.Text)
                Else
                    MsgResult2.Text = "El Valor Excede, el Total del Acumulado de los Anticipos"
                    Obj.lErrorG = True
                End If

        End Select
            MsgBox(MsgResult2, Obj.lErrorG)
            llenar_GRid2(Me.NoID)
            If Not Obj.lErrorG Then
                Me.Limpiar2()
        End If


       

    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub Limpiar2()

        Me.txtporcentaje.Text = ""
      
        Me.txtvalor.Text = ""


    End Sub

    Sub Nuevo2()

        Me.Oper = "Nuevo"
        Me.SubT.Text = "Nuevo..."


        Limpiar2()

        Me.ModalPopupTer.Show()

    End Sub

    Protected Sub Habilitar2(ByVal opcion As String)
        Dim b As Boolean
        b = True
        If opcion = "Edit" Then
            Me.txtporcentaje.Enabled = b
            Me.CboEstado.Enabled = b
            Me.CboPlanAnticipo.Enabled = Not b
            Me.txtvalor.Enabled = b
            Me.BtnEliminarPinv.Enabled = Not b
            Me.BtnGuardarPinv.Enabled = b
            Me.txtvalor.Focus()
        ElseIf (opcion = "New") Then

            Me.txtporcentaje.Enabled = b
            Me.CboEstado.Enabled = b
            Me.CboPlanAnticipo.Enabled = b
            Me.txtvalor.Enabled = b
            Me.BtnEliminarPinv.Enabled = Not b
            Me.BtnGuardarPinv.Enabled = b
            Me.CboPlanAnticipo.Focus()

        ElseIf (opcion = "Delete") Then
            Me.txtporcentaje.Enabled = Not b
            Me.CboEstado.Enabled = Not b
            Me.CboPlanAnticipo.Enabled = Not b
            Me.txtvalor.Enabled = Not b
            Me.BtnEliminarPinv.Enabled = b
            Me.BtnGuardarPinv.Enabled = Not b
            Me.BtnEliminarPinv.Focus()

        End If



    End Sub

    Protected Sub BtnEliminarPinv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEliminarPinv.Click
        Dim Obj As New ActaAnticipo
        Me.MsgResult2.Text = Obj.Delete1(Me.NoID, CboPlanAnticipo.Text)
        Me.MsgBox(MsgResult2, Obj.lErrorG)
        llenar_GRid2(NoID)

    End Sub

    Protected Sub BtnGuardarPinv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardarPinv.Click
        Guardar2()
    End Sub

    Protected Sub txtvalor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.TextChanged
        
    End Sub

   
    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Guardar()
    End Sub

    Protected Sub lBtnEditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lBtnEditar.Click
        Me.Oper = "Editar"
        Editar(TxtNoDocumento.Text)

    End Sub


    Protected Sub lBtnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lBtnGenerar.Click
        Dim npa As New genPlanAnticipos
        MsgBoxLimpiar(MsgResult)
        MsgResult.Text = npa.GenActa(hdCodCon.Value, CboPlantilla.SelectedValue, Me.TxtNoDocumento.Text)
        MsgBox(MsgResult, npa.lErrorG)
    End Sub

    Protected Sub lBtnAtras_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lBtnAtras.Click
        VolverPanel()
    End Sub

    Protected Sub IBtnValidar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnValidar.Click
        Dim Obj As New ActaAnticipo
        Dim VanticipoRealiz, ValorAnticipoTotal As Long
        VanticipoRealiz = Obj.GetSUMbyPkI(Me.NoID)
        ValorAnticipoTotal = (TxtValPago.Text)
        Me.MsgBoxLimpiar(MsgResult2)

        If VanticipoRealiz < ValorAnticipoTotal Then
            MsgResult.Text = "El Valor del Anticipo, No Se Ha Especificado Completamente"
            Obj.lErrorG = True
            Me.MsgBox(MsgResult, Obj.lErrorG)
            Me.grdInformes.Visible = True
        Else
            Dim valfecha As Boolean
            valfecha = Obj.GetValFecha(Me.CodCon, Me.txtFecDoc.Text)
            If valfecha = True Then
                MsgResult.Text = Obj.Msg
                Me.MsgBox(MsgResult, True)
            Else
                MsgResult.Text = Obj.ValActaEstado(TxtNoDocumento.Text) 'Actualiza Estado
                Habilitar(False)
                Me.grdInformes.Visible = True
                Me.MsgBox(MsgResult, Obj.lErrorG)
                If Not Obj.lErrorG Then
                    mostrarDatos()
                End If
            End If
        End If



    End Sub

    Protected Sub IBtnRevertir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnRevertir.Click
        Dim Obj As New ActaAnticipo
        MsgResult.Text = Obj.RevActaEstado(TxtNoDocumento.Text) 'Revierte a Borrador
        Habilitar(False)
        Me.grdInformes.Visible = True
        Me.MsgBox(MsgResult, Obj.lErrorG)
        mostrarDatos()
    End Sub

    Protected Sub IBtnVerDoc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnVerDoc.Click
        If Not String.IsNullOrEmpty(TxtNoDocumento.Text) Then
            Redireccionar_Pagina("/ashx/VerActas.ashx?Ide_Acta=" + TxtNoDocumento.Text)
        End If
    End Sub
End Class
