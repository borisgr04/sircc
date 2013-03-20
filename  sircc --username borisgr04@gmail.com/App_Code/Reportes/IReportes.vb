Imports Microsoft.VisualBasic
Imports System.Data

Public Interface IReportes
    Property Filtro As String
    Function GenerarReporte() As String
End Interface
