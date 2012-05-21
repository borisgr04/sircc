Imports System.Data
Partial Class Contratos_Cesiones_Default
    Inherits PaginaComun

    Protected Sub BtnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Dim obj As Contratos = New Contratos()
        MsgResult.Text = obj.CederContratos(Me.DetContrato1.Cod_Con, Me.DetContrato1.Ide_Con, Me.TxtIde.Text, Me.TxtFecCes.Text, CDec(Me.TxtPla.Text), CDec(Me.TxtVal.Text), TxtRes.Text, TxtFecRes.Text)
        MsgBox(MsgResult, obj.lErrorG)
        Me.MsgResult.Visible = True
    End Sub

    Protected Sub AdmTercero1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdmTercero1.SelClicked
        If AdmTercero1.TipoTer = "CON" Then
            TxtIde.Text = AdmTercero1.Nit
            BuscarContratista()
            Me.ModalPopup.Hide()
        End If
    End Sub
    Sub BuscarContratista()
        Dim t As New Terceros
        Dim dt As DataTable = t.GetByIde(Me.TxtIde.Text)
        If dt.Rows.Count > 0 Then
            Me.TxtNom.Text = dt.Rows(0)("Nom_Ter").ToString()
            Me.MsgResult.Text = ""
        Else
            Me.MsgResult.Text = "No encontro el Tercero"
            MsgBox(MsgResult, False)
            VerModalPopup("CON")
        End If
    End Sub
    Sub VerModalPopup(ByVal Tipo As String)
        AdmTercero1.tipoter = Tipo
        Me.ModalPopup.Show()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        VerModalPopup("CON")
    End Sub
End Class
