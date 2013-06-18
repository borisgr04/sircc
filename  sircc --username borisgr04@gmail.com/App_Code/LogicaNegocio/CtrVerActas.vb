Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class CtrVerActas
    Dim d As New CEstContratos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function getActabyID(Id As String) As DataTable
        Return d.getActabyID(Id)
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function getUltimoID() As String
        Return d.getUltimoID()
    End Function

End Class
