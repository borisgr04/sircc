Imports Microsoft.VisualBasic
Imports System.Data

Public Class CReporteFactory
    Implements IReportFactory

    Private Shared mIntance As CReporteFactory

    Private Sub New()

    End Sub

    Shared ReadOnly Property Intance As CReporteFactory
        Get
            If mIntance Is Nothing Then
                mIntance = New CReporteFactory
            End If
            Return mIntance
        End Get
    End Property
    Public Function CreateReport(Cod_Rep As String, Filtro As String) As IReportes Implements IReportFactory.CreateReport

        Select Case Cod_Rep
            Case "FUT_2012_1"
                Return New cRptFUT_2012_1
            Case Else
                Throw New Exception("Objeto No Implementado")
        End Select

    End Function
End Class
