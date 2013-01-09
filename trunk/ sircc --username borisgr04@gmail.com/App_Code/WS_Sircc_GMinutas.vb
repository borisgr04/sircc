Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports Microsoft.VisualBasic



' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://www.byasystems.com.co/", _
     Description:="SIRCC GMinutas  - B&A Systems Servicios Web")> _
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WS_Sircc_GMinutas
    Inherits SW_Comun

    '<WebMethod(Description:="Devuelve, Plantillas por Tipo de Procesos/Modalidad ")> _
    'Public Function GetPPlanbyTproc(ByVal Cod_Tproc As String) As DataTable
    '    Dim p As New PPlantillas
    '    Return p.GetRecords(Cod_Tproc)
    'End Function
#Region "Plantillas"
    <WebMethod(Description:="Devuelve, Plantillas por Ide_Pla ")> _
    Public Function GetPPlanbyPK(ByVal Ide_Pla As String) As DataTable
        Dim p As New PPlantillas
        Return p.GetbyPK(Ide_Pla)
    End Function

    <WebMethod(Description:="Devuelve, Plantilla Disponibles para el Proceso especificado ")> _
    Public Function GetPPlanbyNumProc(ByVal Num_Proc As String) As DataTable
        Dim p As New PPlantillas
        Return p.GetbyNumProc(Num_Proc)
    End Function

    <WebMethod(Description:="Devuelve, Plantilla Disponibles para el Proceso especificado ")> _
    Public Function GetPlantillasDoc() As DataTable
        Dim p As New PPlantillas
        Return p.GetPlantillasDoc()
    End Function
    '

    <WebMethod(Description:="Devuelve, Tabla con Campos a Cruzar en las Plantilla ")> _
    Public Function GetCamposPla(ByVal Vista As String) As DataTable
        Dim p As New PPlantillas_Campos
        Return p.GetRecords(Vista)
    End Function

    <WebMethod(Description:="Devuelve, Plantilla Disponibles para el Proceso y Grupo - Especificado  ")> _
    Public Function GetPPlanbyNumProcG(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Dim p As New PPlantillas
        Return p.GetbyNumProc(Num_Proc, Grupo)
    End Function
    <WebMethod(Description:="Devuelve, Plantilla Disponibles para el Proceso y Grupo - Especificado  ")> _
    Public Function InsertAPP(ByVal TIP_PLA As String, ByVal Nom_Pla As String, ByVal ruta As String, ByVal Cod_TPro As String, ByVal Est_Pla As String, ByVal Clave As String) As String
        Dim p As New PPlantillas
        Return p.InsertAPP(TIP_PLA, Nom_Pla, ruta, Cod_TPro, Est_Pla, Clave)
    End Function
    <WebMethod(Description:="Devuelve, Plantilla Disponibles para el Proceso y Grupo - Especificado  ")> _
    Public Function GetTipos() As DataTable
        Dim p As New Tipos
        Return p.GetRecords()
    End Function
    <WebMethod(Description:="Devuelve, Plantilla Disponibles para el Proceso y Grupo - Especificado  ")> _
    Public Function GetSubTipos(ByVal codtip As String) As DataTable
        Dim p As New SubTipos
        Return p.GetByTipo(codtip)
    End Function
#End Region

#Region "Procesos"
    <WebMethod(Description:="Devuelve, Procesos Listos Para Generar Minuta ")> _
    Public Function GetMisProcbyGMinuta(ByVal Username As String) As DataTable
        Dim p As New Con_PContratos
        Return p.GetMisProcbyGMinuta(Username)
    End Function

    <WebMethod(Description:="Devuelve, Procesos Listos Para Generar Minuta ")> _
    Public Function GetMisProcbyDocumentos(ByVal Username As String) As DataTable
        Dim p As New Con_PContratos
        Return p.GetMisProcbyDocumentos(Username)
    End Function

    <WebMethod(Description:="Devuelve, Datos  de un Proceso ")> _
    Public Function GetDatosProc(ByVal Num_Proc As String) As DataTable
        Dim p As New Con_PContratos
        Return p.GetByPkC(Num_Proc)
    End Function
    <WebMethod(Description:="Devuelve, Tablas Asociadas a Proceso ")> _
    Public Function GetTabla(ByVal Tabla As String, ByVal Num_Proc As String) As DataTable
        Dim Obj As New Con_PContratos
        Return Obj.GetTabla(Tabla, Num_Proc)
    End Function
#End Region

#Region "Procesos-Grupos"

    <WebMethod(Description:="Devuelve, Clave Generar Minutas ")> _
    Public Function GetClave() As String
        Return Publico.Clave_Minuta
    End Function

    <WebMethod(Description:="Devuelve, Procesos Listos Para Generar Minuta ")> _
    Public Function GetMisGProcbyGMinuta(ByVal Username As String) As DataTable
        Dim p As New ConGProcesos
        Return p.GetMisProcbyGMinuta(Username)
    End Function
    <WebMethod(Description:="Devuelve, Procesos en Tramite ")> _
    Public Function GetMisGProcTramite(ByVal Username As String) As DataTable
        Dim p As New ConGProcesos
        Return p.GetMisProcTramite(Username)
    End Function
    <WebMethod(Description:="Devuelve, Procesos Listos Para Generar Minuta de la dependencia")> _
    Public Function GetMisGProcbyGMinutaCord(ByVal Username As String) As DataTable
        Dim p As New ConGProcesos
        Return p.GetMisProcbyGMinutaCord(Username)
    End Function
    <WebMethod(Description:="Actualiza los datos de las plantillas creadas")> _
   Public Function UpdateDatosPlantilla(ByVal TIP_PLA As String, ByVal NOM_PLA As String, ByVal COD_TPRO As String, ByVal EST_PLA As String, ByVal CLAVE As String, ByVal EDITABLE As String, ByVal Ide_Pla As String) As String
        Dim p As New PPlantillas
        Return p.UpdateCampos(TIP_PLA, NOM_PLA, COD_TPRO, EST_PLA, CLAVE, EDITABLE, Ide_Pla)
    End Function
    <WebMethod(Description:="Devuelve, Datos  de un Proceso ")> _
    Public Function GetDatosGProc(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Dim p As New ConGProcesos
        Return p.GetByPkC(Num_Proc, Grupo)
    End Function
    <WebMethod(Description:="Devuelve, Tablas Asociadas a ProcesoxGrupo ")> _
    Public Function GetTablaGP(ByVal Tabla As String, ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Dim Obj As New ConGProcesos
        Return Obj.GetTabla(Tabla, Num_Proc, Grupo)
    End Function
    <WebMethod(Description:="Devuelve, Tablas Asociadas a ProcesoxGrupo ")> _
    Public Function GetTablaP(ByVal Tabla As String, ByVal Num_Proc As String) As DataTable
        Dim Obj As New Con_PContratos
        Return Obj.GetTabla(Tabla, Num_Proc)
    End Function
    <WebMethod(Description:="Devuelve, Minutas Generadas a un ProcesoxGrupo ")> _
    Public Function GetMinutas(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Dim obj As New PGContratosM
        Return obj.GetbyPG(Num_Proc, Grupo)
    End Function
    <WebMethod(Description:="Devuelve, Doc Generadas a un ProcesoxGrupo ")> _
    Public Function GetDocumentos(ByVal Num_Proc As String) As DataTable
        Dim obj As New DocPContratos
        Return obj.GetbyPG(Num_Proc)
    End Function

    <WebMethod(Description:="Registra Minuta a un ProcesoxGrupo ")> _
    Public Sub SetMinutaPG(ByVal Num_Proc As String, ByVal Grupo As String, ByVal Minuta As Byte(), ByRef Msg As String, ByRef lErrorG As Boolean)
        Dim obj As New PGContratosM
        Msg = obj.Insert(Num_Proc, Grupo, Minuta)
        lErrorG = obj.lErrorG
    End Sub
    <WebMethod(Description:="Registra Documento a un Proceso ")> _
    Public Sub SetDocumento(ByVal Num_Proc As String, ByVal Minuta As Byte(), ByVal MinutaBase As Byte(), ByVal Tip_Doc As String, ByVal Editable As String, ByRef Msg As String, ByRef lErrorG As Boolean, ByVal Nombre As String)
        Dim obj As New DocPContratos
        Msg = obj.Insert(Num_Proc, Minuta, MinutaBase, Tip_Doc, Editable, Nombre)
        lErrorG = obj.lErrorG
    End Sub
    <WebMethod(Description:="Registra Documento a un Proceso ")> _
    Public Sub SetDocumento2(ByVal Num_Proc As String, ByVal Minuta As Byte(), ByVal MinutaBase As Byte(), ByVal Tip_Doc As String, ByVal Editable As String, ByRef Msg As String, ByRef lErrorG As Boolean, ByVal Nombre As String, ByVal Fec_Doc As Date)
        Dim obj As New DocPContratos
        Msg = obj.Insert(Num_Proc, Minuta, MinutaBase, Tip_Doc, Editable, Nombre, Fec_Doc)
        lErrorG = obj.lErrorG
    End Sub

    <WebMethod(Description:="Registra Minuta a un ProcesoxGrupo ")> _
    Public Sub SetMinutaPG1(ByVal Num_Proc As String, ByVal Grupo As String, ByVal Editable As String, ByVal Minuta As Byte(), ByVal MinutaBase As Byte(), ByRef Msg As String, ByRef lErrorG As Boolean)
        Dim obj As New PGContratosM
        Msg = obj.Insert1(Num_Proc, Grupo, Editable, Minuta, MinutaBase)
        lErrorG = obj.lErrorG
    End Sub

    <WebMethod(Description:="Devuelve, Minutas en Bytes ")> _
    Public Function GetMinutasPGID(ByVal Num_Proc As String, ByVal Grupo As String, ByVal ID As Integer) As Byte()
        Dim obj As New PGContratosM
        Return obj.GetMinuta(Num_Proc, Grupo, ID)
    End Function

    <WebMethod(Description:="Devuelve, Minutas en Bytes ")> _
    Public Function GetOpenMinuta(ByVal Num_Proc As String, ByVal Grupo As String) As Byte()
        Dim obj As New PGContratosM
        Return obj.GetMinuta(Num_Proc, Grupo)
    End Function

    <WebMethod(Description:="Devuelve, Doc en Bytes ")> _
    Public Function GetDocumentosPGID(ByVal Num_Proc As String, ByVal ID As Integer) As Byte()
        Dim obj As New DocPContratos
        Return obj.GetDocumento(Num_Proc, ID)
    End Function
    <WebMethod(Description:="Devuelve, Doc en Bytes ")> _
    Public Function GetDocBasePGID(ByVal Num_Proc As String, ByVal ID As Integer) As DataTable
        Dim obj As New DocPContratos
        Return obj.GetDocBase(Num_Proc, ID)
    End Function
    <WebMethod(Description:="Devuelve, Minutas en Bytes ")> _
    Public Function GetMinBasePGID(ByVal Num_Proc As String, ByVal Grupo As String, ByVal ID As Integer) As DataTable
        Dim obj As New PGContratosM
        'Throw New Exception(Num_Proc + "," + Grupo + "," + ID.ToString)
        Return obj.GetDocBase(Num_Proc, Grupo, ID)
    End Function
    <WebMethod(Description:="Devuelve, Minutas Base del Registro Activo ")> _
    Public Function GetMinBasePGAC(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Dim obj As New PGContratosM
        'Throw New Exception(Num_Proc + "," + Grupo + "," + ID.ToString)
        Return obj.GetDocBaseAC(Num_Proc, Grupo)
    End Function
    <WebMethod(Description:="Devuelve, Minutas en Bytes ")> _
    Public Function GetPlantillaPpal(ByRef plantilla As Byte()) As Boolean
        Dim obj As New MinutaPPal
        Return obj.GetMinuta(plantilla)
    End Function

    <WebMethod(Description:="Devuelve, Si Existen Minutas Activas ")> _
    Public Function GetExitMin(ByVal Num_Proc As String, ByVal Grupo As String) As Boolean
        Dim obj As New PGContratosM
        Return obj.GetExitsAC(Num_Proc, Grupo)
    End Function
    <WebMethod(Description:="Devuelve, Si Existen Doc Activas ")> _
    Public Function GetExitDoc(ByVal Num_Proc As String, ByVal TipDocumento As String) As Boolean
        Dim obj As New DocPContratos
        Return obj.GetExitsAC(Num_Proc, TipDocumento)
    End Function

    <WebMethod(Description:="Devuelve, Si Existen Minutas Activas ")> _
    Public Sub Anular(ByVal Num_Proc As String, ByVal Grupo As String, ByVal ID As Integer, ByRef Msg As String, ByRef lErrorG As Boolean)
        Dim obj As New PGContratosM
        Msg = obj.Anular(Num_Proc, Grupo, ID)
        lErrorG = obj.lErrorG
    End Sub
    <WebMethod(Description:="Devuelve, Si Existen Minutas Activas ")> _
    Public Sub AnularDoc(ByVal Num_Proc As String, ByVal ID As Integer, ByRef Msg As String, ByRef lErrorG As Boolean)
        Dim obj As New DocPContratos
        Msg = obj.Anular(Num_Proc, ID)
        lErrorG = obj.lErrorG
    End Sub
    <WebMethod(Description:="Devuelve, Solicitudes por RECIBIR ")> _
    Public Function GetbyAbog(ByVal Username As String) As DataTable
        Dim p As New PSolicitudes
        Return p.GetByAbogado(Username)
    End Function
    <WebMethod(Description:="Devuelve, Avisos Pendientes Para Hoy ")> _
    Public Function GetAvisosHoy(ByVal Username As String) As DataTable
        Dim p As New PCronogramas
        Return p.GetAvisosHoy(Username)
    End Function
    <WebMethod(Description:="Devuelve, Avisos Atrazados ")> _
    Public Function GetAvisosAtrasados(ByVal Username As String) As DataTable
        Dim p As New PCronogramas
        Return p.GetAvisosAtrasados(Username)
    End Function
    <WebMethod(Description:="Devuelve, Solicitudes sin revisar")> _
    Public Function GetSolPendientes(ByVal Username As String) As DataTable
        Dim p As New ConSolicitudes
        Return p.GetSolPen(Username)
    End Function
    <WebMethod(Description:="Devuelve, Plantilla Disponibles para el Proceso y Grupo - Especificado  ")> _
    Public Function Insert1(ByVal TIP_PLA As String, ByVal Nom_Pla As String, ByVal Cod_TPro As String, ByVal Est_Pla As String, ByVal CLAVE As String, ByVal EDITABLE As String) As String
        Dim p As New PPlantillas
        Return p.Insert1(TIP_PLA, Nom_Pla, Cod_TPro, Est_Pla, CLAVE, EDITABLE)
    End Function
    <WebMethod(Description:="Devuelve, Plantilla Disponibles para el Proceso y Grupo - Especificado  ")> _
    Public Function UpdatePlantilla(ByVal Ide_Pla As String, ByVal Plantilla As [Byte]()) As String
        Dim p As New PPlantillas
        Return p.Update(Ide_Pla, Plantilla)
    End Function
    <WebMethod(Description:="Actualiza Minuta Base de los Documentos")> _
    Public Function RegenerarDoc(ByVal Ide_Pla As String, ByVal ID As String, ByVal Plantilla As [Byte]()) As String
        Dim p As New DocPContratos
        Return p.Update(Ide_Pla, ID, Plantilla)
    End Function
    <WebMethod(Description:="Actualiza Minuta Final de los Documentos")> _
    Public Function RegenerarDocF(ByVal Ide_Pla As String, ByVal ID As String, ByVal Plantilla As [Byte]()) As String
        Dim p As New DocPContratos
        Return p.UpdateDoc(Ide_Pla, ID, Plantilla)
    End Function

    'UpdatePBaseMinAC
    <WebMethod(Description:="Actualiza Plantilla Base de Minuta ACTIVA  ")> _
    Public Function UpdateMinPBaseMinAC(ByVal Num_Proc As String, ByVal Grupo As String, ByVal Plantilla As [Byte]()) As String
        Dim p As New PGContratosM
        Return p.UpdatePBaseMinAC(Num_Proc, Grupo, Plantilla)
    End Function
    <WebMethod(Description:="Actualiza la Minuta Cruzada ")> _
    Public Function UpdateMinutaAC(ByVal Num_Proc As String, ByVal grupo As String, ByVal Plantilla As [Byte]()) As String
        Dim p As New PGContratosM
        Return p.UpdateMinutaAC(Num_Proc, grupo, Plantilla)
    End Function

    <WebMethod(Description:="Actualiza la Minuta Cruzada ")> _
    Public Function RegenerarMinuta(ByVal Num_Proc As String, ByVal id As String, ByVal grupo As String, ByVal Plantilla As [Byte]()) As String
        Dim p As New PGContratosM
        Return p.Regenerar(Num_Proc, id, grupo, Plantilla)
    End Function

    <WebMethod(Description:="Devuelve, Actualiza Minuta  ")> _
    Public Function RegenerarMin(ByVal Ide_Pla As String, ByVal ID As String, ByVal Grupo As String, ByVal Plantilla As [Byte]()) As String
        Dim p As New PGContratosM
        Return p.Update(Ide_Pla, ID, Grupo, Plantilla)
    End Function
    '<WebMethod(Description:="Devuelve, Actualiza Minuta del Documento del Proceso ")> _
    'Public Function RegenerarMinuta(ByVal Ide_Pla As String, ByVal ID As String, ByVal grupo As String, ByVal Plantilla As [Byte]()) As String
    '    Dim p As New PGContratosM
    '    Return p.Regenerar(Ide_Pla, ID, grupo, Plantilla)
    'End Function

    <WebMethod(Description:="Devuelve, Plantilla Disponibles para el Proceso y Grupo - Especificado  ")> _
    Public Function Regenerar(ByVal Ide_Pla As String, ByVal ID As String, ByVal Plantilla As [Byte]()) As String
        Dim p As New DocPContratos
        Return p.Regenerar(Ide_Pla, ID, Plantilla)
    End Function

    <WebMethod(Description:="Devuelve, Solicitudes plantillas")> _
    Public Function GetPlantillas() As DataTable
        Dim p As New PPlantillas
        Return p.GetPlantillas()
    End Function
    <WebMethod(Description:="Devuelve, Plantilla en Bytes ")> _
    Public Function GetPlantillabyPK(ByVal id_pla As String) As Byte()
        Dim obj As New PPlantillas
        Return obj.GetPlantillabyPK(id_pla)
    End Function
    <WebMethod(Description:="Devuelve, Tipo de Plantillas")> _
    Public Function GetTipPlantillas() As DataTable
        Dim p As New TipPlantillas
        Return p.GetRecords()
    End Function
    <WebMethod(Description:="Inhabilita Minuta especificada  ")> _
    Public Function Inhabilitar(ByVal Ide_Pla As String) As String
        Dim p As New PPlantillas
        Return p.Inhabilitar(Ide_Pla)
    End Function
    <WebMethod(Description:="Devuelve, Plantilla en Bytes y un valor si existe o no")> _
    Public Function GetPlantillabyPK1(ByVal id_pla As String, ByRef plantilla As Byte()) As Boolean
        Dim obj As New PPlantillas
        Return obj.GetPlantillabyPK(id_pla, plantilla)
    End Function

    <WebMethod(Description:="Devuelve, de forma encriptado con TSHAK")> _
    Public Function Encript(ByVal Variable As String, ByVal Valor As String) As String
        Dim querystringSeguro As New TSHAK.Components.SecureQueryString(New Byte() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8})
        querystringSeguro(Variable) = Valor
        Return HttpUtility.UrlEncode(querystringSeguro.ToString())
    End Function
#End Region
End Class