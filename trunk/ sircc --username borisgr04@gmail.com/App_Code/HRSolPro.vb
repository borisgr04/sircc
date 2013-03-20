Imports Microsoft.VisualBasic

Public Class HRSolPro
    Private _oper As String
    Private _fec_Doc As Date
    Private _ide_Doc As String
    Private _cod_Sol As String
    Private _Cod_Tip As String


    Public Property Oper As String
        Get
            Return _oper
        End Get
        Set(value As String)
            _oper = value
        End Set
    End Property

    Public Property Cod_Tip As String
        Get
            Return _Cod_Tip
        End Get
        Set(value As String)
            _Cod_Tip = value
        End Set
    End Property

    Public Property Fec_Doc As Date
        Get
            Return _fec_Doc
        End Get
        Set(value As Date)
            _fec_Doc = value
        End Set
    End Property

    Public Property Ide_Doc As String
        Get
            Return _ide_Doc
        End Get
        Set(value As String)
            _ide_Doc = value
        End Set
    End Property

    Public Property Cod_Sol As String
        Get
            Return _cod_Sol
        End Get
        Set(value As String)
            _cod_Sol = value
        End Set
    End Property
End Class
