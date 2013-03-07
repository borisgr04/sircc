Imports System.Data
Partial Class Interventorias_Designaciones_Default
    Inherits PaginaComun

    
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Pk1 = Request("Numero")
            Me.HfCod_Con.Value = Pk1
            Dim obj As New Designaciones
            Me.TxtFec_Ini.Text = Today
            Me.DetContratoI1.DataSource = obj.GetByPK(Pk1)
            Me.DetContratoI1.DataBind()
        End If
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        UpdAdmTerceros1.Mostrar()
    End Sub

    Protected Sub UpdAdmTerceros1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdAdmTerceros1.SelClicked
        Me.TxtIde.Text = UpdAdmTerceros1.Nit
        Me.TxtNomTer.Text = UpdAdmTerceros1.Nom_Ter
        Me.UpdAdmTerceros1.Ocultar()
    End Sub

    Protected Sub BtnAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAsignar.Click
        Dim obj As New Designaciones
        obj.Cod_Con = Pk1
        obj.Ide_Int = TxtIde.Text
        obj.Tip_Int = "S"
        obj.Fec_Inicio = TxtFec_Ini.Text
        MsgResult.Text = obj.Designar()
        MsgBox(MsgResult, obj.lErrorG)
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim datos() As String = Split(e.CommandArgument, ",")
        Pk1 = datos(0)
        Pk2 = datos(1)
        Me.TxtFecFin.Text = Today
        ModalPopupExtender3.Show()
    End Sub

    Protected Sub Btn_Recibir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Recibir.Click
        Dim obj As New Designaciones
        obj.Ide_Int = Pk2
        obj.Cod_Con = Pk1
        obj.Obs_Int = TxtObservaciones.Text
        obj.Fec_Fin = TxtFecFin.Text
        MsgResult.Text = obj.Desabilitar
        MsgBox(MsgResult, obj.lErrorG)
        Me.GridView1.DataBind()
    End Sub
End Class
