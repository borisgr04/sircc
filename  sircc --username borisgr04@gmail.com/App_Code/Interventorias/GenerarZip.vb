Imports Microsoft.VisualBasic
Imports System.IO
Imports Ionic.Zip

Public Class GenerarZip
    Private Shared Ruta_Zip As String = Publico.Ruta_Doc
    Private Shared vRuta_Zip As String = Publico.vRuta_Doc
    Private Shared lErrorG As Boolean
    Public Shared Msg As String

    Public Shared Function Generar_Zip_Byte(Nom_Zip As String, lstArc As List(Of ArchivosT)) As ArchivosT
        Dim ByteZip() As Byte = {}
        Dim rArc As New ArchivosT
        rArc.NomArchivo = Nom_Zip + ".zip"
        rArc.Content = "APPLICATION/ZIP"
        Try
            Dim RutaC As String = Ruta_Zip + Nom_Zip + ".zip"
            Dim vRutaC As String = vRuta_Zip + Nom_Zip + ".zip"
            If File.Exists(RutaC) Then
                File.Delete(RutaC)
            End If
            Dim zip As New ZipFile()
            Dim i As Integer = 0
            For Each rg In lstArc
                i += 1
                zip.AddEntry(i.ToString + "-" + rg.NomArchivo, rg.SoporteB)
            Next
            zip.Comment = "Export De la base de datos SIRCC"
            Dim ms As New MemoryStream
            zip.Save(ms)
            rArc.SoporteB = ms.ToArray()
            lErrorG = False
            If File.Exists(RutaC) Then
                File.Delete(RutaC)
            End If
            Msg = "Se Generó El Paquete Comprimido (*.Zip)" ' <br> <a href='" + vRutaC + "'  > Click Para Descargar</a> Generado a las: " + Now.ToString
            Return rArc
            'Se elimina despues de Creado


        Catch ex As Ionic.Zip.ZipException
            Msg = "zip:" + ex.Message

            lErrorG = True
        Catch ex As Exception
            Msg = "Ex:" + ex.Message

            lErrorG = True
        Finally

        End Try

        Return rArc
    End Function
End Class
