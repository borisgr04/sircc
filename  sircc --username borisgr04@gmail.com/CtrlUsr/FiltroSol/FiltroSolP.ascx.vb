
Partial Class CtrlUsr_FiltroSol_FiltroSolP
    Inherits CtrlUsrComun

#Region "Eventos del control"
    ''' <summary>
    ''' Evento Aceptar del Control
    ''' </summary>
    ''' <remarks></remarks>
    Public Event FiltrarClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent FiltrarClicked(sender, New EventArgs())
    End Sub
#End Region

#Region "Propiedades del control"
    ''' <summary>
    ''' Establece o devuele el valor del filtro.  
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Filtro() As String
        Set(ByVal value As String)
            ViewState("FiltroSol_Filtro") = value
            Session("FiltroSol_Filtro") = value
        End Set
        Get
            'ViewState("FiltroPCon_Filtro") 
            Return Session("FiltroSol_Filtro")
        End Get
    End Property
#End Region

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        FiltrarD()
        OnClick(sender)
    End Sub

    Sub FiltrarD()
        Dim cFiltro As String = ""
        If (Me.ChkNProc.Checked = True) Then
            Me.TxtNProc.Text = UCase(Me.TxtNProc.Text)
            Util.AddFiltro(cFiltro, "UPPER(Cod_Sol) Like '%" + Me.TxtNProc.Text + "%'")
        End If
        If (Me.ChkTproc.Checked = True) Then
            Util.AddFiltro(cFiltro, "Cod_TPro = '" + Me.CboTproc.SelectedValue + "'")
        End If
        If (Me.ChkDep.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_Sol = '" + Me.cboDep.SelectedValue + "'")
        End If
        If (Me.ChkDepP.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_PSol = '" + Me.CboDepP.SelectedValue + "'")
        End If

        If (Me.ChkObj.Checked = True) Then
            Me.TxtObj.Text = UCase(Me.TxtObj.Text)
            Util.AddFiltro(cFiltro, "UPPER(Obj_Sol) Like '%" + Me.TxtObj.Text + "%'")
        End If
        If (Me.ChkEnc.Checked = True) Then
            If Me.CboEnc.SelectedValue = "" Then
                Util.AddFiltro(cFiltro, "Id_Abog_Enc Is Null ")
            Else
                Util.AddFiltro(cFiltro, "Id_Abog_Enc = '" + Me.CboEnc.SelectedValue + "'")
            End If

        End If
        If Me.ChkConcepto.Checked = True Then
            Util.AddFiltro(cFiltro, "Concepto Like '%" + Me.CboConcepto.SelectedValue + "%'")
        End If

        If Me.ChkFechaRec.Checked = True Then
            Util.AddFiltro(cFiltro, "Fec_Recibido Between to_date('" + Me.TxtF1.Text + "','dd/mm/yyyy') And to_date('" + Me.TxtF2.Text + "','dd/mm/yyyy')")
        End If

        If Me.ChkTipDoc.Checked = True Then
            Util.AddFiltro(cFiltro, "Tip_Con = '" + Me.CboTip.SelectedValue + "'")
        End If
        If Me.ChkClase.Checked = True Then
            Util.AddFiltro(cFiltro, "STip_Con = '" + Me.cboStip.SelectedValue + "'")
        End If
        If Me.ChkNProceso.Checked = True Then
            Util.AddFiltro(cFiltro, "Proceso Like  '%" + Me.TxtNProceso.Text + "%'")
        End If
        If Me.ChkEstProc.Checked = True Then
            Util.AddFiltro(cFiltro, "Est_proceso Like  '" + Me.cboEstProc.Text + "'")
        End If
        Me.Filtro = cFiltro
        'LbFiltro.Text = cFiltro

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Filtro = ""
        End If
    End Sub

    Protected Sub Filtrar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkNProc.CheckedChanged, ChkTproc.CheckedChanged, ChkDep.CheckedChanged, ChkDepP.CheckedChanged, ChkObj.CheckedChanged, TxtNProc.TextChanged, CboTproc.TextChanged, cboDep.TextChanged, CboDepP.TextChanged, TxtObj.TextChanged, CboConcepto.SelectedIndexChanged, ChkFechaRec.CheckedChanged, ChkEnc.CheckedChanged, cboStip.SelectedIndexChanged, CboTip.SelectedIndexChanged, ChkClase.CheckedChanged, ChkTipDoc.CheckedChanged, ChkEstProc.CheckedChanged, ChkNProceso.CheckedChanged, cboEstProc.SelectedIndexChanged, TxtNProceso.TextChanged
        FiltrarD()
        OnClick(sender)
    End Sub

    
End Class
