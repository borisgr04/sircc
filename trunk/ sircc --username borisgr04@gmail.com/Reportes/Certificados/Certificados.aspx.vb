Imports System.Data

Partial Class Reportes_Certificados_Certificados
    Inherits PaginaComun

    Dim oCert As New Cert_Contratos()

    Property lstContratosCVS As String
        Get
            Return ViewState("lstContratosCVS")
        End Get
        Set(ByVal value As String)
            ViewState("lstContratosCVS") = value
        End Set
    End Property

    Property lstContratos As String
        Get
            Return ViewState("lstContratos")
        End Get
        Set(ByVal value As String)
            ViewState("lstContratos") = value
        End Set
    End Property

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    

    Protected Sub TxtIde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIde.TextChanged

        Dim Obj As New Terceros
        Dim dt As DataTable = Obj.GetByIde(Me.TxtIde.Text)

        If dt.Rows.Count > 0 Then
            Me.TxtNom.Text = dt.Rows(0)("Nom_Ter").ToString
            MsgBoxLimpiar(Me.MsgResult)
        Else
            Me.TxtNom.Text = ""
            Me.MsgResult.Text = "El usuario debe estar registrado cómo Tercero"
            MsgBoxAlert(Me.MsgResult, True)
        End If
        grdContratos.DataBind()
        RdCert.SelectedValue = 0
        MultiView1.ActiveViewIndex = 0

        
    End Sub

    Protected Sub BtnCert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCert.Click
        Me.lstContratos = ""
        For Each grdRows As GridViewRow In grdContratos.Rows
            Dim nuevoCheckBox As CheckBox = grdRows.FindControl("ChkSel")
            Dim estaCheckeado As Boolean = nuevoCheckBox.Checked
            If (estaCheckeado = True) Then
                lstContratos += IIf(String.IsNullOrEmpty(lstContratos), "", ",") + grdRows.Cells(1).Text
            End If
        Next
        lstContratosCVS = Util.FormatCVS(lstContratos)
        If Not String.IsNullOrEmpty(lstContratos) Then


            'SE INICIALIZAN LOS DATOS PAR CREAR EL REGISTRO DEL CERTIFICADO
            oCert.Ide_Con = TxtIde.Text
            oCert.Lst_Cont = lstContratos
            MsgResult.Text = oCert.GenCertificado() ' Crea el Certificado

            If Not oCert.lErrorG Then
                grdCert.DataBind()
                MultiView1.ActiveViewIndex = 1
                RdCert.SelectedValue = 1
                MsgResult.Text = "Se Generó Certificado N° " + oCert.Nro_Cert.ToString
            End If
            MsgBox(MsgResult, oCert.lErrorG)
        Else
            MsgResult.Text = "Seleccione al menos un contrato a Certificar."
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub


    Protected Sub RdCert_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdCert.SelectedIndexChanged
        MultiView1.ActiveViewIndex = RdCert.SelectedValue
    End Sub

    Protected Sub grdCert_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCert.SelectedIndexChanged
        Redireccionar_Pagina(String.Format("ashx/verCert.ashx?nro_cert={0}&vig_cert={1}", grdCert.SelectedRow.Cells(1).Text, grdCert.SelectedRow.Cells(0).Text))
    End Sub
End Class
