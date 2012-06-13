Imports System.Data
Partial Class Controles_DetContratoD
    Inherits CtrlUsrComun

    Dim est As String

#Region "Eventos del control"
    Public Event AceptarClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent AceptarClicked(sender, New EventArgs())
    End Sub
#End Region
#Region "Propiedades del control"
    ''' <summary>
    ''' Valor Total Prop(Valor a pagar por parte de la Entidad
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Valor_Total_Prop As String
        Get
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Valor_Total_Prop").ToString
            Else
                Return 0
            End If
        End Get
    End Property
    Public Property dtContratos() As DataTable
        Set(ByVal value As DataTable)
            ViewState("dtPcon") = value
        End Set
        Get
            Return ViewState("dtPcon")
        End Get
    End Property
    ''' <summary>
    ''' Dependencia Delegada del Proceso de Contratación
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Dep_PCon As String
        Get
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Dep_PCon").ToString
            Else
                Return ""
            End If
        End Get
    End Property
    ''' <summary>
    ''' Estado actual del Contrato
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Estado As String
        Get
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Est_Con").ToString
            Else

                Return ""
            End If
        End Get
    End Property
    ''' <summary>
    ''' Dependencia que genera la Necesidad
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Dep_Con As String
        Get
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Dep_Con").ToString
            Else

                Return ""
            End If
        End Get
    End Property
    ''' <summary>
    ''' Tipo de Proceso
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TProc() As String
        Get
            Return Me.DtPCon.Rows(0).Cells(1).Text
        End Get
    End Property
    ''' <summary>
    ''' Código del Proceso del Contrato
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Cod_Con() As String
        Get
            Return ViewState("Cod_Con")
        End Get
        Set(ByVal value As String)
            ViewState("Cod_Con") = value
            Session("Cod_Con") = value
        End Set
    End Property

    Public Property Ide_Con() As String
        Get
            Return ViewState("Ide_Con")
        End Get
        Set(ByVal value As String)
            ViewState("Ide_Con") = value
        End Set
    End Property
    ''' <summary>
    ''' Retorna si el Proceso Fue encontrado
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Encontrado() As Boolean
        Get
            Return ViewState("Encontrado")
        End Get
        Set(ByVal value As Boolean)
            ViewState("Encontrado") = value
        End Set
    End Property
    Public Property TipRadicacion() As String
        Get
            Return ViewState("TipRadicacion")
        End Get
        Set(ByVal value As String)
            ViewState("TipRadicacion") = value
        End Set
    End Property
    Public Property Proceso() As String
        Get
            Return ViewState("Proceso")
        End Get
        Set(ByVal value As String)
            ViewState("Proceso") = value
        End Set
    End Property
    Public Property Grupo() As String
        Get
            Return ViewState("Grupo")
        End Get
        Set(ByVal value As String)
            ViewState("Grupo") = value
        End Set
    End Property
#End Region

#Region "Métodos del control"
    ''' <summary>
    ''' Ejecuta el metodo buscar tomando como paramentro, el texto escrito en el texbox
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Buscar()
        Me.Cod_Con = Me.TxtCodCon.Text
        Dim oC As New Contratos
        Me.Cod_Con = oC.GetCodigo(Me.CboTip.SelectedValue, Me.TxtCodCon.Text, Vigencia_Cookie)
        Me.TxtCodCon.Text = Cod_Con
        Me.dtContratos = oC.GetByPkD(Me.Cod_Con)
        Me.DtPCon.DataSource = Me.dtContratos
        Me.DtPCon.DataBind()
        Me.Encontrado = IIf(dtContratos.Rows.Count > 0, True, False)
        If Encontrado = True Then
            Session("DP.Cod_TProc") = Me.DtPCon.Rows(0).Cells(1).Text
            Ide_Con = dtContratos.Rows(0)("Ide_Con").ToString
            Me.TipRadicacion = dtContratos.Rows(0)("Tip_Radicacion").ToString
            Me.Proceso = dtContratos.Rows(0)("Num_Proc").ToString
            Me.Grupo = dtContratos.Rows(0)("Grupo").ToString
        End If
    End Sub
#End Region


    Protected Sub DtPCon_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtPCon.DataBound

    End Sub

    Protected Sub TxtCodCon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodCon.TextChanged
        Buscar()
        OnClick(sender)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TxtCodCon.Text = ""
            Me.Cod_Con = Me.TxtCodCon.Text
            Me.dtContratos = New DataTable()
        End If
    End Sub

    Protected Sub CmbVigencia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbVigencia.SelectedIndexChanged
        Buscar()
        OnClick(sender)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Buscar()
        OnClick(sender)
    End Sub

    Public Sub Actualizar()
        Buscar()
    End Sub
End Class
