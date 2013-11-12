Imports System.Data
Partial Class Solicitudes_Anulacion_Anulacion
    Inherits PaginaComun
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Request.QueryString.Count > 0 Then
                TxtCod.Text = Request.QueryString("Cod_Sol")
                Buscar()
                UpdAsig.Update()
            End If
        End If
    End Sub

    Public Sub Buscar()
        txtObs.Text = ""
        MsgBoxLimpiar(LbMsg)
        Dim oP As New PSolicitudes
        'Me.CodigoPContrato = TxtCod.Text
        Dim dtSolicitudes As DataTable = oP.GetByPk(TxtCod.Text)
        Me.DtPCon.DataSource = dtSolicitudes
        Me.DtPCon.DataBind()
        If (dtSolicitudes.Rows.Count = 0) Then
            txtObs.Enabled = False
            BtnAnular.Enabled = False
        Else
            If dtSolicitudes.Rows(0)("Recibido") = "S" Then
                LbMsg.Text = "La  Solicitud, fue asignada, no se puede eliminar"
                MsgBox(LbMsg, True)
                txtObs.Enabled = False
                BtnAnular.Enabled = False
            Else
                txtObs.Enabled = True
                BtnAnular.Enabled = True
            End If
        End If
    End Sub

    Sub NuevaSol()
        Redireccionar_Pagina("/Solicitudes/NuevaSolicitud/NuevaSolicitud.aspx")
    End Sub


    

    Protected Sub BtnAnular_Click(sender As Object, e As System.EventArgs) Handles BtnAnular.Click

        Dim obj As New PSolicitudes

        Me.LbMsg.Text = obj.Anular(Me.TxtCod.Text, txtObs.Text)
        Me.MsgBox(Me.LbMsg, obj.lErrorG)
        If Not obj.lErrorG Then
            txtObs.Enabled = False
            BtnAnular.Enabled = False
        End If

    End Sub

    Protected Sub IBtnBuscar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Buscar()
    End Sub
End Class
