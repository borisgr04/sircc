Imports Microsoft.VisualBasic
Imports System.Data

Public Interface IReportFactory
    Function CreateReport(Cod_Rep As String, Filtro As String) As IReportes
End Interface
