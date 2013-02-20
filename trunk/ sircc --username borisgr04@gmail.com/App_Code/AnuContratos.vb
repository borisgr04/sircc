Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class AnuContratos
    Inherits EstContratos


    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Overloads Function Insert(ByVal cod_con As String, ByVal est_ini As String, ByVal est_fin As String, ByVal fec_ent As Date, ByVal obs As String) As String
        MyBase.Insert(cod_con, est_ini, est_fin, fec_ent, "", obs, 0, 0, 0)
        Return Msg
    End Function


    Public Overloads Function Update(ByVal ID As String, ByVal fec_ent As Date, ByVal Obs As String) As String
        Return MyBase.Update(ID, fec_ent, Obs, 0, 0, 0)
    End Function

End Class
