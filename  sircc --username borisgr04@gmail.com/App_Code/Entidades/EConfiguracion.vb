Imports Microsoft.VisualBasic

Public Class EConfiguracion
    Private _Propiedad As String
    Private _Valor As String
    
    Public Property Propiedad As String
        Get
            Return _Propiedad
        End Get
        Set(value As String)
            _Propiedad = value
        End Set
    End Property

    Public Property Valor As String
        Get
            Return _Valor
        End Get
        Set(value As String)
            _Valor = value
        End Set
    End Property
End Class
