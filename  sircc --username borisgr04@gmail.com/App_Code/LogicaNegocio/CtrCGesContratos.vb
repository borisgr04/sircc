Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

<System.ComponentModel.DataObject()> _
Public Class CtrCGesContratos
    Dim d As New CContratos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecords(cFil As vContratosInt) As DataTable
        Return d.GetRecords(cFil)
    End Function

End Class
