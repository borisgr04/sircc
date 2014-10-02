Imports Microsoft.VisualBasic

Public Class CtrDocPContratos

    Public Function SetDocumento(doc As EDocumentoWPDto) As String

        Dim obj As New DocPContratosDAO

        Dim Msg As String = obj.Insert(doc)

        Return Msg
    End Function

    Public Function UpdDocumento(doc As EDocumentoWPDto) As String

        Dim obj As New DocPContratosDAO

        Dim Msg As String = obj.UpdateMinuta(doc)

        Return Msg
    End Function
End Class


