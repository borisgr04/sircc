Imports Microsoft.VisualBasic
Imports System.Data

<System.ComponentModel.DataObject()> _
Public Class CtrGesContratos
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

    Public Function TieneInterventor(ByVal Cod_Con As String) As Boolean
        Dim ic As New Interventores_Contrato
        Dim tieneInt As Boolean = (ic.GetRecords(Cod_Con).Rows.Count > 0)
        lErrorG = ic.lErrorG
        If Not tieneInt = True Then
            lErrorG = True
            Msg = "El Contrato, no tiene asignado interventor en el Sistema. <br> Comuniquese con el Administrador de SIRCC. "
        End If
        Return tieneInt
    End Function

    Public Function Insert(ByVal cod_con As String, ByVal est_ini As String, ByVal est_fin As String, ByVal fec_ent As Date, ByVal tfil As String, ByVal obs As String, ByVal val_pago As Decimal, ByVal nvisitas As Integer, ByVal por_eje_fis As Decimal) As String
        Dim ec As New EstContratos
        If TieneInterventor(cod_con) Then
            Msg = ec.Insert(cod_con, est_ini, est_fin, fec_ent, tfil, obs, val_pago, nvisitas, por_eje_fis)
            lErrorG = ec.lErrorG
        End If
        Return Msg
    End Function

    Public Function Update(ByVal ID As String, ByVal fec_ent As Date, ByVal Obs As String, ByVal val_pago As Decimal, ByVal nvisitas As Integer, ByVal por_eje_fis As Decimal) As String
        Dim ec As New EstContratos
        Msg = ec.Update(ID, fec_ent, Obs, val_pago, nvisitas, por_eje_fis)
        lErrorG = ec.lErrorG
        Return Msg
    End Function

    Public Function Anular(ByVal ID As String) As String
        Dim ec As New EstContratos
        Msg = ec.Anular(ID)
        lErrorG = ec.lErrorG
        Return Msg
    End Function

    Public Function GetbyPk(ByVal ID As String) As System.Data.DataTable
        Dim ec As New EstContratos
        Return ec.GetbyPk(ID)
    End Function

End Class
