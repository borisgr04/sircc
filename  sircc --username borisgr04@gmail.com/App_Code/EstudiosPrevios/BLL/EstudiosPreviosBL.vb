Imports Microsoft.VisualBasic

Public Class EstudiosPreviosBL

    Public Function GetTercero(Ide_Ter As String) As ETerceros

        Dim t As New TercerosDAO
        t.GetAll()

    End Function
    
End Class
