Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.Data

Partial Class Procesos_DocProceso_DocProcesos
    Inherits PaginaComun

    <WebMethod()> _
   <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Shared Function ObtieneNombres(ByVal prefixText As String) As String() 'As List(Of Terc)
        Dim obj As New Tip_Doc
        Dim lerrorg As Boolean = False
        Dim datat As New DataTable
        datat = obj.GetRecordsComplete(prefixText)
        Dim items As List(Of String) = New List(Of String)
        Dim i As Integer
        Dim Sal As String
        If datat.Rows.Count > 0 Then
            For i = 0 To datat.Rows.Count - 1
                Sal = datat.Rows(i).Item("Des_Tip").ToString()
                items.Add(Sal)
            Next i
        Else
            items.Clear()
        End If
        Return items.ToArray
    End Function




    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdUrl.Value = ResolveClientUrl(Publico.rutaExe)
            Me.HdUsuario.Value = Usuarios.UserName
            Habilitar(False)
            txtNProceso.Text = Request("Num_Proc")
            Dim obj As New PContratos()
            Dim dt As DataTable = obj.GetByPk(txtNProceso.Text)
            If (dt.Rows.Count > 0) Then
                LbObjeto0.Text = dt.Rows(0)("Obj_Con").ToString
                EnabledIBtn(IBtnGenDoc, True)
                Me.TxtDoc.Enabled = True
                TxtFec.Enabled = True
                TxtNom.Enabled = True
            Else
                EnabledIBtn(IBtnGenDoc, False)
                Me.TxtDoc.Enabled = False
                TxtFec.Enabled = False
                TxtNom.Enabled = False
                MsgResult.Text = "El Proceso no existe"
                MsgBoxAlert(MsgResult, True)
            End If
        End If

    End Sub

    
    Protected Sub grdDocP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocP.SelectedIndexChanged
        Dim obj As New DocPContratos
        Pk1 = grdDocP.SelectedValue
        Dim tb As DataTable = Obj.GetbyPK(Pk1)
        If tb.Rows.Count > 0 Then
            Try
                Habilitar(True)
                Me.TxtId.Text = tb.Rows(0)("ID").ToString
                Me.TxtNom.Text = tb.Rows(0)("NOMBRE").ToString
                Me.TxtDoc.Text = tb.Rows(0)("DES_TIP").ToString
                Me.TxtFec.Text = CDate(tb.Rows(0)("FEC_DOC").ToString).ToShortDateString
                Me.CboPlantilla.Visible = False
                Habilitar(True)
                
                MsgBoxLimpiar(MsgResult)
            Catch ex As Exception
                MsgResult.Text = ex.Message
                MsgBox(MsgResult, True)
            End Try

        End If

    End Sub

    Private Sub Habilitar(ByVal p1 As Boolean)
        Me.TxtId.Enabled = False
        EnabledIBtn(IBtnEditarB, p1)
        EnabledIBtn(IBtnEditarD, p1)
        EnabledIBtn(IBtnRegenerar, p1)
        EnabledIBtn(IBtnAnular, p1)
        EnabledIBtn(IBtnGenDoc, Not p1)
        EnabledIBtn(IBtnGuardar, p1)
        EnabledIBtn(IBtnCancelar, p1)
        CboPlantilla.Visible = Not p1
    End Sub

    Protected Sub IBtnAnular_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAnular.Click
        Dim obj As New DocPContratos
        MsgResult.Text = obj.Anular(txtNProceso.Text, TxtId.Text)
        MsgBox(MsgResult, obj.lErrorG)
        If Not obj.lErrorG Then
            limpiar()
            Habilitar(False)
            Me.grdDocP.DataBind()
        End If


    End Sub

    Protected Sub IBtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGuardar.Click
        Dim obj As New DocPContratos
        MsgResult.Text = obj.Update(txtNProceso.Text, TxtId.Text, TxtNom.Text, TxtFec.Text)
        MsgBox(MsgResult, obj.lErrorG)
        Me.grdDocP.DataBind()
    End Sub

    Protected Sub IBtnGenDoc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnGenDoc.Click

    End Sub

    Protected Sub IBtnReload_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnReload.Click
        CboPlantilla.DataBind()
        'TxtNom.Text = Right(TxtDoc.Text, TxtDoc.Text.Length - 3)
    End Sub

    Protected Sub TxtDoc_TextChanged(sender As Object, e As System.EventArgs) Handles TxtDoc.TextChanged
        CboPlantilla.DataBind()
        'TxtNom.Text = Right(TxtDoc.Text, TxtDoc.Text.Length - 3)
        
    End Sub

    Protected Sub IBtnCancelar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles IBtnCancelar.Click
        cancelar()

    End Sub

    Sub cancelar()
        limpiar()
        Habilitar(False)
    End Sub
    Sub limpiar()
        TxtDoc.Text = ""
        TxtNom.Text = ""
        TxtFec.Text = ""
        TxtId.Text = ""
    End Sub
End Class
