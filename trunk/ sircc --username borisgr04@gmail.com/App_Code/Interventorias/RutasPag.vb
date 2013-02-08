Imports Microsoft.VisualBasic



Public Class RutasPag

    Dim rutasPag As New Dictionary(Of String, String)

    Shared _ObjSingleton As RutasPag

    Public Shared Function GetInstance() As RutasPag
        If _ObjSingleton Is Nothing Then
            _ObjSingleton = New RutasPag
        End If
        Return _ObjSingleton
    End Function

    Private Sub New()
        rutasPag.Add("00", "/Interventorias/PanelSupervision/PanelSupervision.aspx")
        rutasPag.Add("01", "/Interventorias/Documentos/ActaInicio/ActaInicio.aspx")
        rutasPag.Add("08", "/Interventorias/Documentos/AsigAntInv/AsigAntInv.aspx")
        rutasPag.Add("02", "/Interventorias/Documentos/InfParciales/InfParciales.aspx")
        rutasPag.Add("99", "/Interventorias/Documentos/PagosSS/PagosSS.aspx")
    End Sub

    Function GetRuta(ByVal Destino As String) As String
        Try
            Return rutasPag.Item(Destino)
        Catch ex As Exception
            Return "#"
        End Try

    End Function
End Class
