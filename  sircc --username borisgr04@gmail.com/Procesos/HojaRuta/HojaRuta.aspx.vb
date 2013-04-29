Imports Telerik.Web.UI
Imports System.Data
Imports Microsoft.Reporting.WebForms

Partial Class Procesos_HojaRuta_HojaRuta
    Inherits PaginaComun

    Function MostrarCheck(val As String) As Boolean
        Return Not (val = "0")
    End Function

    Protected Sub IBtnGuardar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        If HdTip.Value = "SIN" Then
            Guardar()
        Else
            Eliminar()
        End If

    End Sub
    Private Sub Eliminar()
        MsgResult.Text = ""
        Dim lhr As New List(Of HRSolPro)
        For Each grow In GridView1.Rows
            Dim TxtIdeDoc As TextBox = DirectCast(grow.FindControl("TxtIdeDoc"), TextBox)
            Dim LbCodTip As Label = DirectCast(grow.FindControl("LbCodTip"), Label)
            Dim TxtFecDoc As RadDatePicker = DirectCast(grow.FindControl("TxtFecDoc"), RadDatePicker)
            Dim ChkSel As CheckBox = DirectCast(grow.FindControl("ChkSel"), CheckBox)
            Dim txtFolios As RadNumericTextBox = DirectCast(grow.FindControl("txtFolios"), RadNumericTextBox)
            If ChkSel.Checked Then
                Dim hr As New HRSolPro
                If Not TxtFecDoc.SelectedDate Is Nothing Then
                    hr.Fec_Doc = TxtFecDoc.SelectedDate
                    hr.Oper = "M"
                    hr.Ide_Doc = TxtIdeDoc.Text
                    hr.Fec_Doc = TxtFecDoc.SelectedDate
                    hr.Cod_Sol = TxtCodSol.Text
                    hr.Cod_Tip = LbCodTip.Text
                    hr.Folios = txtFolios.Text
                    lhr.Add(hr)
                Else
                    'log += LbCodTip.Text + "-"
                    LbCodTip.Font.Bold = True
                    'hr.Fec_Doc = New Date(1900, 1, 1)
                End If
                    

            Else
                Dim hr As New HRSolPro
                hr.Oper = "D"
                hr.Cod_Sol = TxtCodSol.Text
                hr.Cod_Tip = LbCodTip.Text
                lhr.Add(hr)
            End If
        Next
        MsgResult.Text += HRSolProDAO.GetInstance.Actualizar(TxtCodSol.Text, lhr)
        MsgBox(MsgResult, HRSolProDAO.GetInstance.lErrorG)
        GridView1.DataBind()
    End Sub
    Private Sub Guardar()
        MsgResult.Text = ""
        Dim lhr As New List(Of HRSolPro)
        Dim log As String = ""
        For Each grow In GridView1.Rows
            Dim TxtIdeDoc As TextBox = DirectCast(grow.FindControl("TxtIdeDoc"), TextBox)
            Dim LbCodTip As Label = DirectCast(grow.FindControl("LbCodTip"), Label)
            Dim TxtFecDoc As RadDatePicker = DirectCast(grow.FindControl("TxtFecDoc"), RadDatePicker)
            Dim ChkSel As CheckBox = DirectCast(grow.FindControl("ChkSel"), CheckBox)
            Dim txtFolios As RadNumericTextBox = DirectCast(grow.FindControl("txtFolios"), RadNumericTextBox)
            If ChkSel.Checked Then
                Dim hr As New HRSolPro
                If Not TxtFecDoc.SelectedDate Is Nothing Then
                    hr.Fec_Doc = TxtFecDoc.SelectedDate
                Else
                    'log += LbCodTip.Text + "-"
                    'LbCodTip.Font.Bold = True
                    hr.Fec_Doc = New Date(1900, 1, 1)
                End If
                hr.Oper = "I"
                hr.Ide_Doc = TxtIdeDoc.Text
                hr.Cod_Sol = TxtCodSol.Text
                hr.Cod_Tip = LbCodTip.Text
                hr.Folios = txtFolios.Text
                LbCodTip.Font.Bold = False
                lhr.Add(hr)

            End If
        Next
        If lhr.Count > 0 Then
            MsgResult.Text = HRSolProDAO.GetInstance.Insert(TxtCodSol.Text, lhr)
            MsgBox(MsgResult, HRSolProDAO.GetInstance.lErrorG)
            GridView1.DataBind()
        Else
            MsgResult.Text = String.Format("Los Documentos {0} no tienen fecha especificada", log)
            MsgBox(MsgResult, True)
        End If

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            'DataBinder.Eval(e.Row.DataItem, "Cod_Eta")
            Dim ChkSel As CheckBox = DirectCast(e.Row.FindControl("ChkSel"), CheckBox)
            Dim TxtFecDoc As RadDatePicker = DirectCast(e.Row.FindControl("TxtFecDoc"), RadDatePicker)
            'TxtFecDoc.SelectedDate = e.Row.DataItem(
            Try
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "FEC_DOC")) Then
                    If CDate(DataBinder.Eval(e.Row.DataItem, "FEC_DOC")).Year > 1950 Then
                        TxtFecDoc.SelectedDate = CDate(DataBinder.Eval(e.Row.DataItem, "FEC_DOC"))
                    End If
                End If
                If DataBinder.Eval(e.Row.DataItem, "Doc_Oblig") = "S" Then
                    ChkSel.Checked = True
                End If
            Catch ex As Exception

            End Try

            'If e.Row.DataItem Then
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If

    End Sub

    Protected Sub RadTabStrip1_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick
        MsgAyuda()
    End Sub

    Private Sub MsgAyuda()
        Dim msg As String
        If RadTabStrip1.SelectedIndex = 0 Then
            HdTip.Value = "SIN"
            LbSubTit.Text = "Documentos Sin Seleccionar"
            msg = "<b>Agregar</b><br/>Para Agregar un Documento Marque del Cuadro de Chequeo a la Izquierda y especifique Fecha y Identificación del Documento."
        Else
            HdTip.Value = "CON"
            LbSubTit.Text = "Documentos Seleccionados"
            msg = "<b>Eliminar</b><br/>Para Eliminar un Documento quite la Marca del Cuadro de Chequeo y presione Guardar."
        End If
        ctrAyudIzql1.Mensaje = msg
    End Sub

    Protected Sub Page_Load1(sender As Object, e As System.EventArgs) Handles Me.Load
        MsgAyuda()

        Dim cod As String = Request("Codigo")
        Dim tip As String = Request("tp")

        Dim hr As New Hojas_Rutas()
        Dim dataTb As DataTable = hr.GetSolPro(cod, tip)
        If dataTb.Rows.Count > 0 Then
            If tip.ToUpper() = "S" Then
                TxtCodSol.Text = cod
                TxtNroProc.Text = dataTb.Rows(0)("Proceso").ToString
                TxtObjeto.Text = dataTb.Rows(0)("Obj_Sol").ToString
            Else
                TxtCodSol.Text = dataTb.Rows(0)("Num_Sol").ToString
                TxtNroProc.Text = cod
                TxtObjeto.Text = dataTb.Rows(0)("Obj_Con").ToString
            End If
        End If

    End Sub

    Sub ExpReportPDF()
        Dim bytes As Byte()
        ReportViewer1.LocalReport.Refresh()
        bytes = ReportViewer1.LocalReport.Render("PDF")
        Dim ms As New System.IO.MemoryStream(bytes)
        Response.AddHeader("content-disposition", "inline; filename=" + TxtCodSol.Text + ".pdf")
        Response.ContentType = "Application/pdf"
        Response.BinaryWrite(ms.ToArray())
        Response.End()
    End Sub

    Protected Sub IBtnPDF_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnPDF.Click
        ExpReportPDF()
    End Sub
End Class
