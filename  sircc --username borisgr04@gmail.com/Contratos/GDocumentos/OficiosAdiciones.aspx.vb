Imports System.Data

Partial Class Contratos_GDocumentos_OficiosAdiciones
    Inherits PaginaComun

    Private obj As New Adiciones

    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.DetContratoN1.ValoraBuscar = Request("Numero")
            Me.DetContratoN1.Buscar()
            LlenarGrid()
            LnkRPC.Visible = True
            LinkDesSup.Visible = True
        End If

    End Sub

    Private Function GetRecords() As DataTable
        Dim dt As DataTable = New DataTable
        dt = obj.GetRecordsUlt(Me.DetContratoN1.Cod_Con)
        Return dt
    End Function


    Public Sub LlenarGrid()
        Dim dtCustomer As DataTable = Me.GetRecords()
        grd.DataSource = dtCustomer
        grd.DataBind()
        
    End Sub

    Protected Sub DetContratoN1_AceptarClicked(sender As Object, e As EventArgs)
        LlenarGrid()
        LnkRPC.Visible = True
        LinkDesSup.Visible = True
    End Sub

    Protected Sub LnkRPC_Click(sender As Object, e As EventArgs) Handles LnkRPC.Click
       
        Me.DetContratoN1.Buscar()
        If (DetContratoN1.Encontrado = False) Then
            Me.MsgResult.Text = "Debe consultar un contrato y luego seleccionar la adición a la cual se le imprimirá el oficio "
            MsgBoxAlert(MsgResult, True)
        ElseIf (grd.SelectedValue = Nothing Or grd.SelectedValue = "") Then
            Me.MsgResult.Text = "Seleccione la Adición a la cual se le imprimira el oficio"
            MsgBoxAlert(MsgResult, True)
        Else
            RPC()
        End If

    End Sub

    Protected Sub LinkDesSup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkDesSup.Click
        Me.DetContratoN1.Buscar()
        If (DetContratoN1.Encontrado = False) Then
            Me.MsgResult.Text = "Debe consultar un contrato y luego seleccionar la adición a la cual se le imprimirá el oficio "
            MsgBoxAlert(MsgResult, True)
        ElseIf (grd.SelectedValue = Nothing Or grd.SelectedValue = "") Then
            Me.MsgResult.Text = "Seleccione la Adición a la cual se le imprimira el oficio"
            MsgBoxAlert(MsgResult, True)
        Else
            Designar()
        End If


    End Sub
    Sub RPC()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Nro_Cto") = DetContratoN1.Cod_Con
        querystringSeguro("Nro_Adi") = grd.SelectedValue
        Redireccionar_Pagina("/Contratos/GDocumentos/AddSolicitudRPC.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub



    Sub Designar()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Nro_Cto") = DetContratoN1.Cod_Con
        querystringSeguro("Nro_Adi") = grd.SelectedValue
        Redireccionar_Pagina("/Contratos/GDocumentos/DesignacionAdicion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
