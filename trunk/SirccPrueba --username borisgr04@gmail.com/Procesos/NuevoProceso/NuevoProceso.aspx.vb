Imports System.Data
Imports System.IO

Partial Class Procesos_NuevoProceso_Default
    Inherits PaginaComun
    Dim obj As PContratos = New PContratos


    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnGuardar.Click
        Guardar()
    End Sub
    Public Sub Guardar()
        If Me.cboDep.SelectedIndex = 0 Then
            Me.MsgResult.Text = "Seleccione la Dependencia que Origina la Necesidad"
            MsgBox(MsgResult, True)
            Exit Sub
        End If
        obj = New PContratos
        Select Case Me.Oper
            Case "nuevo"
                Me.MsgResult.Text = obj.Insert(Me.CboTproc.SelectedValue, Me.TxtObj.Text, Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, CDec(Me.Vigencia.ToString), Me.CboTip.SelectedValue, Me.cboStip.SelectedValue, TxtFechaRecibido.Text)
            Case "editar"
                ' Me.MsgResult.Text = obj.Update(Me.Pk1, Me.CboTproc.SelectedValue, Me.TxtNProc.Text, Me.TxtObj.Text, Me.cboDep.SelectedValue, Me.CboDepP.SelectedValue, CDec(Me.Vigencia.ToString), Me.CboTip.SelectedValue, Me.cboStip.SelectedValue)
        End Select
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        Me.Habilitar(False)
        Me.IBtnCancelar.Enabled = False
        Me.IBtnNuevo.Enabled = True
        Me.IBtnGuardar.Enabled = False
        Me.IBtnAbrir.Enabled = True
        Me.TxtNProc.Text = obj.Num_PCon

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Cancelar()
        End If

    End Sub
    Protected Sub IBtnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnNuevo.Click
        Nuevo()
    End Sub
    Private Sub Nuevo()
        Me.Habilitar(True)
        Me.Limpiar()
        'Me.TxtNProc.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.IBtnCancelar.Enabled = True
        Me.IBtnEditar.Enabled = False

        Me.Oper = "nuevo"
    End Sub

    Private Sub Habilitar(ByVal Valor As Boolean)
        Me.TxtNPla.Enabled = Valor
        'Me.TxtNProc.Enabled = Valor
        Me.TxtObj.Enabled = Valor

        Me.cboDep.Enabled = Valor
        Me.CboDepP.Enabled = Valor

        Me.cboStip.Enabled = Valor
        Me.CboTip.Enabled = Valor
        Me.CboTproc.Enabled = Valor
        Me.TxtFechaRecibido.Enabled = Valor

    End Sub

    Private Sub Limpiar()
        Me.TxtNPla.Text = ""
        Me.TxtNProc.Text = ""
        Me.TxtObj.Text = ""
        TxtNprocA.Text = ""
        Me.TxtFechaRecibido.Text = Today.ToString("dd/MM/yyyy")
        Me.cboDep.SelectedIndex = -1
        Me.CboDepP.SelectedIndex = -1

        Me.cboStip.SelectedIndex = -1
        Me.CboTip.SelectedIndex = -1
        Me.CboTproc.SelectedIndex = -1

        Me.MsgResult.CssClass = ""
        Me.MsgResult.Text = ""


    End Sub

    Protected Sub IBtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnCancelar.Click
        Cancelar()
    End Sub

    Public Sub Cancelar()
        Me.Limpiar()
        Me.IBtnNuevo.Enabled = True
        Me.IBtnAbrir.Enabled = True
        Me.IBtnGuardar.Enabled = False
        Me.IBtnCancelar.Enabled = False
        Me.IBtnEditar.Enabled = False
        Me.Habilitar(False)
        Me.Oper = ""
    End Sub

    Protected Sub BtnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IBtnEditar.Click
        Editar()

    End Sub
    Public Sub Editar()
        Habilitar(True)
        Me.TxtFechaRecibido.Enabled = False
        Me.IBtnEditar.Enabled = False
        Me.IBtnGuardar.Enabled = True
        Me.IBtnCancelar.Enabled = True
        Me.IBtnNuevo.Enabled = False
        Me.Oper = "editar"
    End Sub
    Public Sub Abrir()

        Dim dt As DataTable = obj.GetByPk(Me.TxtNprocA.Text)
        If dt.Rows.Count > 0 Then

            'Me.TxtLugEje.Text=
            Me.TxtNPla.Text = dt.Rows(0)("NRO_PLA_CON").ToString
            Me.TxtNProc.Text = dt.Rows(0)("PRO_SEL_NRO").ToString
            Me.Pk1 = dt.Rows(0)("PRO_SEL_NRO").ToString
            Me.TxtObj.Text = dt.Rows(0)("obj_con").ToString
            Me.LbEstado.Text = dt.Rows(0)("nom_est").ToString
            Me.LbEncargado.Text = dt.Rows(0)("Encargado").ToString
            Me.TxtFechaRecibido.Text = dt.Rows(0)("FechaRecibido").ToString
            Me.cboDep.SelectedValue = dt.Rows(0)("DEP_CON").ToString
            Me.CboDepP.SelectedValue = dt.Rows(0)("DEP_PCON").ToString
            Me.CboTproc.SelectedValue = dt.Rows(0)("COD_TPRO").ToString
            Me.CboTip.SelectedValue = dt.Rows(0)("TIP_CON").ToString
            Me.cboStip.DataBind()
            Me.cboStip.SelectedValue = dt.Rows(0)("STIP_CON").ToString






            'Me.grdCDP1.Enabled = Valor

            Me.Habilitar(False)
            Me.IBtnAbrir.Enabled = True
            Me.IBtnEditar.Enabled = False
            If dt.Rows(0)("nom_est").ToString = "E001" Then
                Me.IBtnEditar.Enabled = True
            End If

            Me.IBtnGuardar.Enabled = False
            Me.IBtnCancelar.Enabled = True
            Me.MsgResult.Text = ""
            Me.MsgResult.CssClass = ""
        Else
            Me.MsgResult.Text = "No se encontró el registro"
            MsgBox(Me.MsgResult, True)
        End If


    End Sub

    Protected Sub BtnVerMinuta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVerMinuta.Click

        'verminuta()
        'word()
        VerMinutaHTML()



    End Sub

    Sub Word()
        Dim ds As New DataSet("minuta_Minutas")
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Body", System.Type.GetType("System.String"))

        Dim obj As CMinutas = New CMinutas
        ' comando insert
        Dim datat As DataTable = obj.GetByPk("02")
        Dim row As DataRow = dt.NewRow()
        row("body") = datat.Rows(0)("cmin_body")
        dt.Rows.Add(row)
        dt.AcceptChanges()
        ds.Tables.Add(dt)

    End Sub
    'Sub verminuta()
    '    Dim pdf As VerMinuta = New VerMinuta()
    '    Response.Buffer = True
    '    Response.ContentType = "application/pdf"
    '    Response.AddHeader("Content-Disposition", "inline")
    '    Dim MemStream As MemoryStream = New MemoryStream()
    '    MemStream = pdf.GenerarPDF(Me.TxtNprocA.Text)
    '    If MemStream Is Nothing Then
    '        Response.Write("No Data is available for output")
    '    Else
    '        Response.OutputStream.Write(MemStream.GetBuffer(), 0, MemStream.GetBuffer().Length)
    '        Response.OutputStream.Flush()
    '        Response.OutputStream.Close()
    '        MemStream.Close()
    '    End If
    'End Sub

    Sub VerMinutaHTML()
        ' Response.Redirect("minuta.aspx?proceso=" + Me.TxtNProc.Text)
    End Sub

    Protected Sub IBtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnNuevo.Click
        Nuevo()
    End Sub
    Protected Sub BtnAbrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAbrir.Click
        Abrir()
    End Sub

    Protected Sub TxtNprocA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNprocA.TextChanged
        Abrir()
    End Sub

End Class
