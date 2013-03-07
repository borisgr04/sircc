Imports System.Data
Partial Class Controles_DetPSolicitudes
    Inherits CtrlUsrComun

    Dim est As String

#Region "Eventos del control"

    Public Event AceptarClicked As EventHandler
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent AceptarClicked(sender, New EventArgs())
    End Sub

#End Region
#Region "Propiedades del control"
    Public Property dtSolicitudes() As DataTable
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
            If Me.dtSolicitudes.Rows.Count > 0 Then
                Return Me.dtSolicitudes.Rows(0).Item("Dep_PSol").ToString
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
            If Me.dtSolicitudes.Rows.Count > 0 Then
                Return Me.dtSolicitudes.Rows(0).Item("Dep_Sol").ToString
            Else
                Return ""
            End If
        End Get
    End Property
    Private Property NumSol As String
        Set(ByVal value As String)
            ViewState("Num_Sol") = value
            Session("Num_Sol") = value
            Buscar()
            OnClick(TxtCodCon)
        End Set
        Get
            Return ViewState("Num_Sol")
        End Get
    End Property
    ''' <summary>
    ''' Código del Solcitud
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodigoPContrato() As String
        Get
            Return NumSol
        End Get
        Set(ByVal value As String)
            TxtCodCon.Text = value
            NumSol = value
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
    Public Sub Buscar()
        'Me.CodigoPContrato = Me.TxtCodCon.Text
        Dim oP As New PSolicitudes
        Me.dtSolicitudes = oP.GetByPkAbog(Me.NumSol)
        Me.DtPCon.DataSource = Me.dtSolicitudes
        Me.DtPCon.DataBind()
        Me.Encontrado = IIf(dtSolicitudes.Rows.Count > 0, True, False)
   
    End Sub
#End Region

    Protected Sub DtPCon_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtPCon.DataBound

    End Sub

    Protected Sub TxtCodCon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodCon.TextChanged
        Me.NumSol = Me.TxtCodCon.Text
        Buscar()
        OnClick(sender)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.NumSol = Me.TxtCodCon.Text
        End If
    End Sub

    Protected Sub ConPSolicitudesPK1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPSolicitudes1.SelClicked
        CodigoPContrato = Me.ConPSolicitudes1.Cod_Sol
        Me.ModalPopupSolicitudes.Hide()
        'Buscar()
        'OnClick(sender)
    End Sub

    Protected Sub IBtnAbrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnAbrir.Click
        Buscar()
        OnClick(sender)
    End Sub

    Protected Sub IBtnBuscarSol_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnBuscarSol.Click
        Me.ModalPopupSolicitudes.Show()
    End Sub
End Class
