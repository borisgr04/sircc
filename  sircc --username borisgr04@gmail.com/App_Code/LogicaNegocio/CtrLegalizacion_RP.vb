Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class CtrLegalizacion_RP
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
    Public Overloads Function GetRecords(ByVal Cod_Con As String) As DataTable
        Return rp.GetRecords(Cod_Con)
    End Function

    Public Function GetbyPk(ByVal Cod_Con As String, ByVal Nro_Rp As String) As DataTable
        Return GetbyPk(Cod_Con, Nro_Rp)
    End Function

    Public Function Insert(ByVal Cod_Con As String, ByVal Nro_Rp As String, ByVal Fec_Rp As Date, ByVal Val_RP As Decimal, ByVal Vigencia As String, ByVal Doc_Sop As String) As String

        Dim cdp As New CDP_Contratos
        Dim dt As DataTable = cdp.GetRecords(Cod_Con)
        If dt.Rows.Count > 0 Then
            Msg = rp.Insert(Cod_Con, Nro_Rp, Fec_Rp, Val_RP, Vigencia, Doc_Sop)
            lErrorG = rp.lErrorG
        Else
            Msg = "No ha registrado CDP para el Contrato. Por favor Registrar CDP"
            lErrorG = True
        End If

        Return Msg
    End Function

    Public Function Delete(ByVal Cod_Con As String, ByVal Nro_rp As String) As String
        Msg = rp.Delete(Cod_Con, Nro_rp)
        lErrorG = rp.lErrorG
        Return Msg
    End Function

End Class
