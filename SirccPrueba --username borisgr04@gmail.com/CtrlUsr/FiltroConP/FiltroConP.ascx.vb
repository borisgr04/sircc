
Partial Class CtrlUsr_FiltroConP
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
    Property Filtro As String
        Set(ByVal value As String)
            Session("FiltroPCon_Filtro") = value
        End Set
        Get
            'ViewState("FiltroPCon_Filtro")
            Return Session("FiltroPCon_Filtro")
        End Get
    End Property
    Property Activo As String
        Set(ByVal value As String)
            Session("Activo") = value
        End Set
        Get
            'ViewState("FiltroPCon_Filtro")
            Return Session("Activo")
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
    Public Property Vigencia As String
        Set(ByVal value As String)
            Me.CmbVigencia.SelectedValue = value
        End Set
        Get
            Return Me.CmbVigencia.SelectedValue
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
        Me.Activo = 0
        Dim cFiltro As String = ""
        If (Me.ChkNProc.Checked = True) Then
            Me.TxtNProc.Text = UCase(Me.TxtNProc.Text)
            If Not String.IsNullOrEmpty(TxtNProc.Text) Then
                Util.AddFiltro(cFiltro, "UPPER(Numero) Like '%" + Me.TxtNProc.Text + "%'")
                Me.Activo = 1
            Else
                Me.Activo = 0
            End If
        End If
        If (Me.ChkTproc.Checked = True) Then
            If Not String.IsNullOrEmpty(Me.TxtCedCon.Text) Then
                Util.AddFiltro(cFiltro, "Ide_Con = '" + Me.TxtCedCon.Text + "'")
                Me.Activo = 1
            Else
                Me.Activo = 0
            End If
        End If
        If (Me.ChkObj.Checked = True) Then
            If Not String.IsNullOrEmpty(Me.TxtObj.Text) Then
                Me.TxtObj.Text = UCase(Me.TxtObj.Text)
                Util.AddFiltro(cFiltro, "UPPER(Obj_Con) Like '%" + Me.TxtObj.Text + "%'")
                Me.Activo = 1
            Else
                Me.Activo = 0
            End If
        End If
        If (Me.ChkVig.Checked = True) Then
            Util.AddFiltro(cFiltro, "Vig_Con= '" + Me.CmbVigencia.SelectedValue + "'")
        End If

        Me.Filtro = cFiltro
        ',ValPagado(c.numero,to_date('31/12/2010','dd/mm/yyyy')) As ValorPago
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Filtro = "1=0"
        End If
    End Sub

    Protected Sub Filtrar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkNProc.CheckedChanged, ChkTproc.CheckedChanged, ChkObj.CheckedChanged, TxtNProc.TextChanged, TxtObj.TextChanged, ChkVig.CheckedChanged, CmbVigencia.TextChanged
        FiltrarD()
        OnClick(sender)
    End Sub
    Protected Sub BuscarCodCon() Handles TxtNProc.TextChanged
        Me.Num_Proc = Me.TxtNProc.Text
        Dim oC As New Contratos
        If ChkVig.Checked Then
            Me.Vigencia = CmbVigencia.SelectedValue
        Else
            Me.Vigencia = Vigencia_Cookie
        End If
        Me.Num_Proc = oC.GetCodigo(Me.CboTip.SelectedValue, Me.TxtNProc.Text, Me.Vigencia)
        Me.TxtNProc.Text = Num_Proc
    End Sub
End Class
