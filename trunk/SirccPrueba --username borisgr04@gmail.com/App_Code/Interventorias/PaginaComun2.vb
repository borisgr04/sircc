Imports Microsoft.VisualBasic

Partial Public Class PaginaComun
    Inherits System.Web.UI.Page
    Property CodCon As String
        Get
            Return Session("CodCon")
        End Get
        Set(ByVal value As String)
            Session("CodCon") = value
        End Set
    End Property

    Property OperS As String
        Get
            Return Session("OperS")
        End Get
        Set(ByVal value As String)
            Session("OperS") = value
        End Set
    End Property
    Property Oper2 As String
        Get
            Return ViewState("Oper2")
        End Get
        Set(ByVal value As String)
            ViewState("Oper2") = value
        End Set
    End Property

    Property NoID As String
        Get
            Return ViewState("NoID")
        End Get
        Set(ByVal value As String)
            ViewState("NoID") = value
        End Set
    End Property

    Protected Function cssEnabled(ByVal v As Boolean) As String
        Return IIf(Not v, "disabledImageButton", "")
    End Function

    Sub EnabledIBtn(Ibtn As ImageButton, v As Boolean)
        Ibtn.Enabled = v
        Ibtn.CssClass = cssEnabled(v)
    End Sub
End Class
