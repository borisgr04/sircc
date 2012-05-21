Imports System.Data
Partial Class Controles_DetGProcesos
    Inherits System.Web.UI.UserControl

    Dim est As String

#Region "Eventos del control"
    Public Event AceptarClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent AceptarClicked(sender, New EventArgs())
    End Sub
    Public Event BuscarClicked As EventHandler
    Protected Overridable Sub BuscarOnClick(ByVal sender As Object)
        RaiseEvent BuscarClicked(sender, New EventArgs())
    End Sub
#End Region
#Region "Propiedades del control"
    Public Property dtContratos() As DataTable
        Set(ByVal value As DataTable)
            ViewState("dtPcon") = value
        End Set
        Get
            Return ViewState("dtPcon")
        End Get
    End Property
    Public ReadOnly Property Estado() As String
        Get
            Return ""
        End Get
    End Property
    ''' <summary>
    ''' Dependencia Delegada del Proceso de Contratación
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Dep_PCon() As String
        Get
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Dep_PCon").ToString
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
    Public ReadOnly Property Dep_Con() As String
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
            If Me.dtContratos.Rows.Count > 0 Then
                Return Me.dtContratos.Rows(0).Item("Cod_Tpro").ToString
            Else

                Return ""
            End If
        End Get
    End Property
    ''' <summary>
    ''' Código del Proceso del Contrato
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodigoPContrato() As String
        Get
            Return ViewState("Num_Pro")
        End Get
        Set(ByVal value As String)
            If Me.TxtCodCon.Text <> value Then
                Me.TxtCodCon.Text = value
                Buscar(1)
                OnClick(TxtCodCon)
            End If
            ViewState("Num_Pro") = value
            Session("Num_Pro") = value
        End Set
    End Property

    Public Property Grupo() As String
        Get
            Return ViewState("Grupo")
        End Get
        Set(ByVal value As String)
            ViewState("Grupo") = value
            Session("Grupo") = value
        End Set
    End Property
    Public Property Tramite() As Boolean
        Get
            Return ViewState("Tramite")
        End Get
        Set(ByVal value As Boolean)
            ViewState("Tramite") = value
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
#End Region

#Region "Métodos del control"
    ''' <summary>
    ''' Ejecuta el metodo buscar tomando como paramentro, el texto escrito en el texbox
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Buscar(ByVal numgrupo As String)
        Me.CodigoPContrato = Me.TxtCodCon.Text
        Me.Grupo = numgrupo
        Dim oP As New GProcesos
        Me.dtContratos = oP.GetByPk(Me.CodigoPContrato, Me.Grupo)
        Me.DtPCon.DataSource = Me.dtContratos
        Me.DtPCon.DataBind()
        Me.Encontrado = IIf(DtPCon.Rows.Count > 0, True, False)
        If Encontrado Then
            If dtContratos.Rows(0).Item("Estado").ToString = "TR" Then
                Me.Tramite = True
            Else
                Me.Tramite = False
            End If
        End If
        If Encontrado = True Then
            Session("DP.Cod_TProc") = Me.DtPCon.Rows(0).Cells(1).Text
        End If
    End Sub
#End Region

    'Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
    '    Buscar()
    '    OnClick(sender)
    'End Sub
    Protected Sub DtPCon_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtPCon.DataBound

    End Sub

    Protected Sub TxtCodCon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodCon.TextChanged
        Buscar(1)
        OnClick(sender)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Me.TxtCodCon.Text = ""
            Me.CodigoPContrato = Me.TxtCodCon.Text
        End If
    End Sub

    Protected Sub IbtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnBuscar.Click
        'Buscar()
        BuscarOnClick(sender)
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboGrupos.SelectedIndexChanged
        Buscar(CboGrupos.SelectedValue)
        OnClick(sender)
    End Sub
End Class
