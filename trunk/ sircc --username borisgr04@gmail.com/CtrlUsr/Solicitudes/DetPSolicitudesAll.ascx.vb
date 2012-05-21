Imports System.Data
Partial Class Controles_DetPSolicitudesAll
    Inherits System.Web.UI.UserControl

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
    ''' Concepto de Revisión
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Concepto() As String
        Get
            If Me.dtSolicitudes.Rows.Count > 0 Then
                Return Me.dtSolicitudes.Rows(0).Item("Concepto").ToString
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
    ''' <summary>
    ''' Tipo de Proceso
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TProc() As String
        Get
            Return Me.dtSolicitudes.Rows(0).Item("Cod_Tproc").ToString
        End Get
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

    Private Property NumSol As String
        Set(ByVal value As String)
            ViewState("Num_Sol") = value
            Session("Num_Sol") = value
            Buscar()

            OnClick(TxtCod)
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
            TxtCod.Text = value
            NumSol = value
        End Set
    End Property
#End Region

#Region "Métodos del control"
    ''' <summary>
    ''' Ejecuta el metodo buscar tomando como paramentro, el texto escrito en el texbox
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Buscar()
        Dim oP As New PSolicitudes
        'Me.CodigoPContrato = TxtCod.Text
        Me.dtSolicitudes = oP.GetByPk(NumSol)
        Me.DtPCon.DataSource = Me.dtSolicitudes
        Me.DtPCon.DataBind()
        Me.Encontrado = IIf(dtSolicitudes.Rows.Count > 0, True, False)
    End Sub
#End Region

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        Buscar()
        OnClick(sender)
    End Sub
    Protected Sub DtPCon_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtPCon.DataBound

    End Sub

    Protected Sub TxtCod_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCod.TextChanged
        'Buscar()
        'OnClick(sender)
        NumSol = TxtCod.Text
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.NumSol = Me.TxtCod.Text
        End If
    End Sub

    Protected Sub BtnBuscarSol_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscarSol.Click
        Me.ModalPopupSolicitudes.Show()
    End Sub

    Protected Sub ConPSolicitudesPK1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConPSolicitudesPK1.SelClicked

        CodigoPContrato = Me.ConPSolicitudesPK1.Cod_Sol
        'Buscar()
        'UpdCSol.Update()
        Me.ModalPopupSolicitudes.Hide()
        'OnClick(sender)
    End Sub
End Class
