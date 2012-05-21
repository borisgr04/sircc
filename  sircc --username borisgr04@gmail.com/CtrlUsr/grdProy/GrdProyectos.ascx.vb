Imports System.Data
Partial Class CtrlUsr_grdProy_WebUserControl
    Inherits CtrlUsrComun
#Region "Eventos del control"

    Public Event Guardar As EventHandler

    Public Property Num_Proy() As String
        Get
            Return ViewState("Num_Proy")
        End Get
        Set(ByVal value As String)
            ViewState("Num_Proy") = value
        End Set
    End Property
    Protected Overridable Sub OnClick(ByVal sender As Object)
        RaiseEvent Guardar(sender, New EventArgs())
    End Sub
#End Region
    Property Tabla_Vacia() As Boolean
        Get
            Return ViewState("_tObligVacia")
        End Get
        Set(ByVal value As Boolean)
            ViewState("_tObligVacia") = value
        End Set
    End Property

    Property Tabla() As DataTable
        Get
            Return DirectCast(ViewState("_tOblig"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            ViewState("_tOblig") = value
        End Set
    End Property

    Property Enabled() As Boolean
        Get
            Return Me.grd.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me.grd.Enabled = value
        End Set
    End Property

    Private obj As New PProyectos
End Class
