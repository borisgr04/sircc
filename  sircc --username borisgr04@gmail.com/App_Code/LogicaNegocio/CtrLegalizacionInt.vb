Imports Microsoft.VisualBasic
Imports System.Data

Public Class CtrLegalizacionInt
    Implements IMsg

    Dim _Msg As String
    Dim _lErrorG As Boolean
    Dim obj As New Interventores_Contrato

    Public Property lErrorG As Boolean Implements IMsg.lErrorG
        Get
            Return _lErrorG
        End Get
        Set(value As Boolean)
            _lErrorG = value
        End Set
    End Property

    Public Property Msg As String Implements IMsg.Msg
        Get
            Return _Msg
        End Get
        Set(value As String)
            _Msg = value
        End Set
    End Property

    Public Overloads Function GetRecords(ByVal Cod_Con As String) As DataTable

        Return obj.GetRecords(Cod_Con)
    End Function
    Public Function Delete(ByVal Cod_Con As String, ByVal Ide_Int As String) As String

        Return obj.Delete(Cod_Con, Ide_Int)
    End Function
    Public Function Update(IE As EInterventores_Contrato) As String
        Return obj.Update(IE.Cod_Con, IE.Ide_Int, IE.Est_Int, IE.Obs_Int, IE.Tip_Int)
    End Function

    Public Function getContrato(Cod_Con As String) As EContratos
        Dim od As New CContratos
        Return od.GetbyCodCon(Cod_Con)
    End Function

End Class
