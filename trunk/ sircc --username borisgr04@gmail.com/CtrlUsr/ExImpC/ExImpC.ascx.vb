Imports System.Data
Partial Class CtrlUsr_ExImpC_ExImpC
    Inherits CtrlUsrComun
    Property Enabled() As Boolean
        Get
            Return Me.TxtObsExo.Enabled
        End Get
        Set(ByVal value As Boolean)
            habilitar(value)
        End Set
    End Property
    Property Cod_Con As String
        Set(ByVal value As String)
            ViewState("Cod_Con") = value
        End Set
        Get
            Return ViewState("Cod_Con")
        End Get
    End Property
    Property dtContratos As DataTable

        Set(ByVal value As DataTable)
            ViewState("DTContratos") = value
        End Set
        Get
            Return DirectCast(ViewState("DTContratos"), DataTable)
        End Get

    End Property
    Dim valor As Boolean
    Public Sub Actualizar()
        Me.MsgResult.Text = ""
        Dim obj As Contratos = New Contratos
        Dim dt As DataTable = dtContratos 'obj.GetByPk(Cod_Con)
        'Me.Response.Write(dtContratos.Rows.Count)
        If dt.Rows.Count > 0 Then
            'Me.TxtFAP.Text = CDate(dt.Rows(0)("FEC_APR_POL").ToString).ToShortDateString
            Me.TxtObsExo.Text = dt.Rows(0)("EXO_OBS").ToString
            Me.ChkExo.Checked = IIf(dt.Rows(0)("EXO_IMP").ToString = "1", True, False)

        End If

    End Sub

    Public Function habilitar(ByVal valor As Boolean) As Boolean
        Me.TxtObsExo.Enabled = valor
        Me.ChkExo.Enabled = valor
        Me.BtnGuardarEx.Enabled = valor
        Return valor
    End Function

    Protected Sub BtnGuardarEx_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardarEx.Click

        Dim obj As Contratos = New Contratos
        If Trim(Me.TxtObsExo.Text) = "" Then
            Me.MsgResult.Text = "Especifique una Observación"
            Me.MsgResult.CssClass = "respuestaNotOk"
        Else
            Me.MsgResult.Text = obj.UpdExoImp(Cod_Con, Me.ChkExo.Checked, Me.TxtObsExo.Text)
            MsgBox(MsgResult, obj.lErrorG)


        End If


    End Sub
End Class
