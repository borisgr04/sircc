Imports Microsoft.VisualBasic

Public Class EInterventores_Contrato
    
    Private _cod_con As String
    Private _ide_int As String
    Private _est_int As String
    Private _obs_int As String
    Private _tip_int As String
    Private _Cod_ConInt As String


    Public Property Cod_Con As String
        Get
            Return _cod_con
        End Get
        Set(value As String)
            _cod_con = value
        End Set
    End Property

    Public Property Ide_Int As String
        Get
            Return _ide_int
        End Get
        Set(value As String)
            _ide_int = value
        End Set
    End Property

    Public Property Est_Int As String
        Get
            Return _est_int
        End Get
        Set(value As String)
            _est_int = value
        End Set
    End Property
    Public Property Obs_Int As String
        Get
            Return _obs_int
        End Get
        Set(value As String)
            _obs_int = value
        End Set
    End Property
    Public Property Tip_Int As String
        Get
            Return _tip_int
        End Get
        Set(value As String)
            _tip_int = value
        End Set
    End Property
    Public Property Cod_ConInt As String
        Get
            Return _Cod_ConInt
        End Get
        Set(value As String)
            _Cod_ConInt = value
        End Set
    End Property

End Class
