Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class CtrConsxRP
    Implements IMsg
    Dim _Msg As String
    Dim _lErrorG As Boolean

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

    Dim rp As New RP_Contratos
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxNroRp(ByVal Nro_Rp As String) As DataTable
        Return rp.GetxNroRp(Nro_Rp)
    End Function



End Class
