Imports Microsoft.VisualBasic

Public Class EContratos
    Private _Cod_Con As String
    Private _Ide_Con As String
    Private _Obj_Con As String
    Private _Nom_Ter As String

    Public Property Cod_Con As String
        Get
            Return _Cod_Con
        End Get
        Set(value As String)
            _Cod_Con = value
        End Set
    End Property
    Public Property Obj_Con As String
        Get
            Return _Obj_Con
        End Get
        Set(value As String)
            _Obj_Con = value
        End Set
    End Property
    Public Property Ide_Con As String
        Get
            Return _Ide_Con
        End Get
        Set(value As String)
            _Ide_Con = value
        End Set
    End Property
    Public Property Nom_Ter As String
        Get
            Return _Nom_Ter
        End Get
        Set(value As String)
            _Nom_Ter = value
        End Set
    End Property
End Class
