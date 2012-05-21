
Partial Class CtrlUsr_FiltroCon
    Inherits System.Web.UI.UserControl

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
    Property Filtro As String
        Set(ByVal value As String)
            Session("FiltroPCon_Filtro") = value
        End Set
        Get
            'ViewState("FiltroPCon_Filtro")
            Return Session("FiltroPCon_Filtro")
        End Get
    End Property
    ''' <summary>
    ''' Establece y Obtiene el numero del proceso del texto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Num_Proc As String
        Set(ByVal value As String)
            Me.TxtNProc.Text = value
        End Set
        Get
            Return Me.TxtNProc.Text
        End Get
    End Property

    ''' <summary>
    ''' Chequea el Numero del Proceso
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChkNum_Proc As Boolean
        Set(ByVal value As Boolean)
            Me.ChkNProc.Checked = value
        End Set
        Get
            Return Me.ChkNProc.Checked
        End Get
    End Property
#End Region

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        FiltrarD()
        OnClick(sender)
    End Sub
    Public Sub RFiltrar()
        FiltrarD()
        OnClick(New Object)
    End Sub

    Private Sub FiltrarD()
        Dim cFiltro As String = ""
        If (Me.ChkNProc.Checked = True) Then
            Me.TxtNProc.Text = UCase(Me.TxtNProc.Text)
            Util.AddFiltro(cFiltro, "UPPER(Numero) Like '%" + Me.TxtNProc.Text + "%'")
        End If
        If (Me.ChkTproc.Checked = True) Then
            Util.AddFiltro(cFiltro, "Cod_TPro = '" + Me.CboTproc.SelectedValue + "'")
        End If
        If (Me.ChkDep.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_con = '" + Me.cboDep.SelectedValue + "'")
        End If
        If (Me.ChkDepP.Checked = True) Then
            Util.AddFiltro(cFiltro, "dep_pcon = '" + Me.CboDepP.SelectedValue + "'")
        End If

        If (Me.ChkObj.Checked = True) Then
            Me.TxtObj.Text = UCase(Me.TxtObj.Text)
            Util.AddFiltro(cFiltro, "UPPER(Obj_Con) Like '%" + Me.TxtObj.Text + "%'")
        End If
        If (Me.ChkVig.Checked = True) Then
            Util.AddFiltro(cFiltro, "Vig_Con= '" + Me.CmbVigencia.SelectedValue + "'")
        End If
        If (Me.ChkValC.Checked = True) Then
            Util.AddFiltro(cFiltro, "val_con BETWEEN " + TxtValC1.Text + " And " + TxtValC2.Text)
        End If
        If (ChkFecSus.Checked = True) Then
            Util.AddFiltro(cFiltro, "FEC_SUS_CON BETWEEN TO_DATE('" + CDate(TxtFecSus1.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecSus2.Text).ToShortDateString + "','dd/mm/yyyy')")
        End If
        If (ChkFecR.Checked = True) Then
            Util.AddFiltro(cFiltro, "to_date(to_char(fec_reg,'dd/mm/yyyy'),'dd/mm/yyyy') BETWEEN TO_DATE('" + CDate(TxtFecReg1.Text).ToShortDateString + "','dd/mm/yyyy') AND to_date('" + CDate(TxtFecReg2.Text).ToShortDateString + "','dd/mm/yyyy')")
        End If
        Me.Filtro = cFiltro
        ',ValPagado(c.numero,to_date('31/12/2010','dd/mm/yyyy')) As ValorPago
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TxtFecReg1.Text = Now.AddMonths(-1).ToShortDateString
            Me.TxtFecReg2.Text = Now.ToShortDateString
            Me.TxtFecSus1.Text = Now.AddMonths(-1).ToShortDateString
            Me.TxtFecSus2.Text = Now.ToShortDateString
            Me.Filtro = "1=0"
        End If
    End Sub

    Protected Sub Filtrar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkNProc.CheckedChanged, ChkTproc.CheckedChanged, ChkDep.CheckedChanged, ChkDepP.CheckedChanged, ChkObj.CheckedChanged, TxtNProc.TextChanged, CboTproc.TextChanged, cboDep.TextChanged, CboDepP.TextChanged, TxtObj.TextChanged, ChkValC.CheckedChanged, ChkFecR.CheckedChanged, ChkFecSus.CheckedChanged, ChkVig.CheckedChanged, CmbVigencia.TextChanged
        FiltrarD()
        OnClick(sender)
    End Sub
End Class
