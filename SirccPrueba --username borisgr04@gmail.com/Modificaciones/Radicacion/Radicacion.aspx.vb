Imports System.Data
Partial Class SolAdiciones_Radicacion_Default
    Inherits PaginaComun
    Dim obj As New Modificaciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub DetPContrato_OnAceptarClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetContratoAdi1.AceptarClicked
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Me.TxtFecha.Text = ""
        Me.TxtObs.Text = ""
        If Me.DetContratoAdi1.Encontrado = True Then
            Dim dt As DataTable = obj.GetbyPK(Me.DetContratoAdi1.IdSolAdi)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("Mod_Estado").ToString = "TR" Then
                    Me.MsgResult.Text = "El Proceso aún no se encuentra validado para ser Radicado"
                    MsgBox(MsgResult, True)
                    Me.ImageButton1.Enabled = False
                    Me.TxtFecha.Enabled = False
                    Me.TxtObs.Enabled = False
                ElseIf dt.Rows(0)("Mod_Estado").ToString = "RA" Then
                    Me.MsgResult.Text = "El proceso ya fue Radicado."
                    MsgBox(MsgResult, True)
                    Me.ImageButton1.Enabled = False
                    Me.TxtFecha.Enabled = False
                    Me.TxtObs.Enabled = False
                Else
                    Me.ImageButton1.Enabled = True
                    Me.TxtFecha.Enabled = True
                    Me.TxtObs.Enabled = True
                End If
            End If
        Else
            Me.MsgResult.Text = "No se encontró el Procesos."
            MsgBoxAlert(MsgResult, True)
            Me.ImageButton1.Enabled = False
        End If
    End Sub
    
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If IsDate(TxtFecha.Text) Then
            obj.Mod_Radicar(Me.DetContratoAdi1.Cod_Con, Me.DetContratoAdi1.IdSolAdi, Me.TxtFecha.Text, Me.TxtObs.Text)
            Me.MsgResult.Text = obj.ResPRad
            MsgBox(MsgResult, False)
            Me.TxtFecha.Enabled = False
            Me.TxtObs.Enabled = False
            Me.ImageButton1.Enabled = False
        Else
            Me.MsgResult.Text = "Debe seleccionar o escribir una fecha valida."
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub
End Class
