Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<WebService(Namespace:="http://www.byasystems.com.co/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Servicios
    Inherits SW_Comun
    ''' <summary>
    ''' Consulta de Consolidados de Contratos por Dependencias Suscritos en el periodo especificado
    ''' </summary>
    ''' <param name="FechaInicial"></param>
    ''' <param name="FechaFinal"></param>
    ''' <param name="DepNec"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function Consulta(ByVal FechaInicial As Date, ByVal FechaFinal As Date, ByVal DepNec As String) As DataTable
        Dim obj As New PContratos
        Return obj.GetCPorDepNec(FechaInicial, FechaFinal, DepNec)
    End Function



End Class