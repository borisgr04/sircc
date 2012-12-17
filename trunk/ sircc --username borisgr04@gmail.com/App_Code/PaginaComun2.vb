Imports Microsoft.VisualBasic

Partial Public Class PaginaComun
    Property CodCon As String
        Get
            Return Session("CodCon")
        End Get
        Set(ByVal value As String)
            Session("CodCon") = value
        End Set
    End Property
End Class
