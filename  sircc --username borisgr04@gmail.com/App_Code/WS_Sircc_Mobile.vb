Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://www.byasystems.com.co/", _
 Description:="SIRCC Mobile  - B&A Systems Servicios Web")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WS_Sircc_Mobile
    Inherits SW_Comun


    ''' <summary>
    ''' Retorna las Opciones del Menu para Dispositivos Mobiles.     Ing Boris González Rivera. 9 Marzo 2011
    ''' </summary>
    ''' <param name="Username"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="Retorna Opciones habilitadas para el Usuario")> _
    Public Function GetMenu(ByVal Username As String) As DataTable
        Dim obj As New MenuMB
        Return obj.GetbyUser(Username)
    End Function

    ''' <summary>
    ''' Consulta Solicitudes por dependencia que genera la necesidad, relacionada con un usuario especifico
    ''' </summary>
    ''' <param name="FechaInicial"> Desde</param>
    ''' <param name="FechaFinal">Hasta</param>
    ''' <param name="Dep_Sol">Dependencia Solicitante</param>
    ''' <returns>Registro de Solicitudes </returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="Devuelve Listado de Solitudes de acuerdo a los parametros")> _
    Public Function GetSolPorDepNec(ByVal FechaInicial As String, ByVal FechaFinal As String, ByVal Dep_Sol As String, ByVal Estado As String) As DataTable
        Dim obj As New ConsultasMB
        Return obj.GetSolPorDepNec(CDate(FechaInicial), CDate(FechaFinal), Dep_Sol, Estado)
    End Function
    ''' <summary>
    ''' Historico de Revision de la Solicitud
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="Devuelve, Historico de Revisiones de Una solicitud ")> _
    Public Function GetSolHRev(ByVal Cod_Sol As String) As DataTable
        Dim obj As New ConsultasMB
        Return obj.GetSolHRev(Cod_Sol)
    End Function


#Region "Procesos"


    ''' <summary>
    ''' Consulta de PContratos 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="Devuelve, Procesos de acuerdo a los paramtros")> _
    Public Function GetPConPorDepNec(ByVal Vigencia As String, ByVal Dep_Con As String, ByVal Cod_Tpro As String, ByVal Estado As String, ByVal Num_Pro As String) As DataTable
        Return ConsultasMB.GetPConPorDepNec(Vigencia, Dep_Con, Cod_Tpro, Estado, Num_Pro)
    End Function

    <WebMethod(Description:="Devuelve, Procesos de acuerdo a los paramtros")> _
    Public Function GetPConString(ByVal Vigencia As String, ByVal Dep_Con As String, ByVal Cod_Tpro As String, ByVal Estado As String, ByVal Num_Pro As String) As String

        Dim cFiltro As String = ""
        ''Fijos
        Util.AddFiltro(cFiltro, "Vig_Con = " + Vigencia + "")
        Util.AddFiltro(cFiltro, "Dep_Con = '" + Dep_Con + "'")
        If (Cod_Tpro <> "TP00") And Not String.IsNullOrEmpty(Cod_Tpro) Then
            Util.AddFiltro(cFiltro, "Cod_Tpro = '" + Cod_Tpro + "'")
        End If
        If (Estado <> "00") And Not String.IsNullOrEmpty(estado) Then
            Util.AddFiltro(cFiltro, "Est_Con = '" + Estado + "'")
        End If
        If Num_Pro <> "" Then
            Util.AddFiltro(cFiltro, "Pro_Sel_Nro Like '%" + Num_Pro + "%'")
        End If

        Return cfiltro

    End Function


    ''' <summary>
    ''' Retorna Estados de Procesos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="Retorna Estados de Procesos")> _
    Public Function GetPEstados() As DataTable
        Return ConsultasMB.GetPEstados()
    End Function

    ''' <summary>
    ''' Retorna modalidades de contratacción
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:=" Retorna modalidades de contratacción")> _
    Public Function GetTiposProc() As DataTable
        Return ConsultasMB.GetTiposProc()
    End Function
    ''' <summary>
    ''' Procesos por Numero de Procesos
    ''' </summary>
    ''' <param name="Num_Proc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:=" Procesos por Numero de Procesos")> _
    Public Function ProcByPk(ByVal Num_Proc As String) As DataTable
        Return ConsultasMB.GetProcbyPK(Num_Proc)
    End Function

    ''' <summary>
    ''' Procesos por Numero de Procesos
    ''' </summary>
    ''' <param name="Num_Proc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:=" Procesos por Numero de Procesos")> _
    Public Function PCrono(ByVal Num_Proc As String) As DataTable
        Return ConsultasMB.GetPCrono(Num_Proc)
    End Function
#End Region
End Class