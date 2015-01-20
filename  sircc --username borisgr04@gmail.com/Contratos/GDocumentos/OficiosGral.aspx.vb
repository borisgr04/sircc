Imports System.Data
Imports System.IO
Partial Class Contratos_GDocumentos_OficiosGral
    Inherits PaginaComun

    Sub Designar()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Nro_Cto") = DetContratoN1.Cod_Con
        Redireccionar_Pagina("/Contratos/GDocumentos/Designacion.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
    Sub RPC()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("Nro_Cto") = DetContratoN1.Cod_Con
        Redireccionar_Pagina("/Contratos/GDocumentos/SolicitudRPC.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub

    'Protected Sub LinkRPC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkRPC.Click
    '    Me.DetContratoN1.Buscar()
    '    If DetContratoN1.dtContratos.Rows.Count > 0 Then
    '        RPC()
    '    Else
    '        Me.MsgResult.Text = "No es posible generar el oficio, el Nro de contrato digitado no existe o es nulo"
    '        MsgBoxAlert(MsgResult, True)
    '    End If
    'End Sub
    'Protected Sub LinkDesSup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkDesSup.Click
    '    Me.DetContratoN1.Buscar()
    '    If DetContratoN1.dtContratos.Rows.Count > 0 Then
    '        Designar()
    '    Else
    '        Me.MsgResult.Text = "No es Posible Generar el oficio, el Nro de contrato digitado no existe o es nulo"
    '        MsgBoxAlert(MsgResult, True)
    '    End If
    'End Sub

    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.DetContratoN1.ValoraBuscar = Request("Numero")
            Me.DetContratoN1.Buscar()
            ActGridOficios()
        End If

    End Sub

    Protected Sub DetContratoN1_AceptarClicked(sender As Object, e As EventArgs) Handles DetContratoN1.AceptarClicked

        ActGridOficios()

    End Sub

    Sub ActGridOficios()
        Dim gto As New GR_TIP_OFI()
        Me.grdOficios.DataSource = gto.GetRecordsC(DetContratoN1.Cod_Con)
        Me.grdOficios.DataBind()
    End Sub

    Protected Sub grdOficios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdOficios.SelectedIndexChanged

        If DetContratoN1.dtContratos.Rows.Count > 0 Then
            Dim top As New GD_CT_OFICIOS
            Dim dto As New GD_CT_OFICIOS_DTO
            dto.COD_CON = DetContratoN1.Cod_Con
            dto.TIP_OFI = grdOficios.SelectedValue
            'Msg.Text = grdOficios.SelectedRow.Cells(3).Text
            If grdOficios.SelectedRow.Cells(3).Text = "NO GENERADO" Then
                Msg.Text = top.Insert(dto)
                ActGridOficios()
                If Not top.lError Then
                    VerDoc()
                End If
            Else
                VerDoc()
            End If
        Else
            Me.MsgResult.Text = "No es Posible Generar el oficio, el Nro de contrato digitado no existe o es nulo"
            MsgBoxAlert(MsgResult, True)
        End If


    End Sub
    Sub VerDoc()
        If grdOficios.SelectedValue = "01" Then
            RPC()
        End If
        If grdOficios.SelectedValue = "02" Then
            Designar()
        End If
    End Sub
End Class
