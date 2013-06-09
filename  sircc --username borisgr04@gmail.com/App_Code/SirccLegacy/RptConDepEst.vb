Imports Microsoft.VisualBasic

Public Class RptConDepEst
    Dim dep As String
    Dim est As String
    Dim can As String

    Property Dependencia As String
        Get
            Return dep
        End Get
        Set(value As String)
            dep = value
        End Set
    End Property
    Property Estado As String
        Get
            Return est
        End Get
        Set(value As String)
            est = value
        End Set
    End Property
    Property Cantidad As Decimal
        Get
            Return can
        End Get
        Set(value As Decimal)
            can = value
        End Set
    End Property


End Class
