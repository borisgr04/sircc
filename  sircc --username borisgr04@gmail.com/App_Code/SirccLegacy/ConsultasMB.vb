Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class ConsultasMB
    Inherits BDDatos



#Region "Solicitudes"
    ''' <summary>
    ''' Consulta Solicitudes por dependencia que genera la necesidad, relacionada con un usuario especifico
    ''' </summary>
    ''' <param name="FechaInicial"> Desde</param>
    ''' <param name="FechaFinal">Hasta</param>
    ''' <param name="Dep_Sol">Dependencia Solicitante</param>
    ''' <returns>Registro de Solicitudes </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetSolPorDepNec(ByVal FechaInicial As Date, ByVal FechaFinal As Date, ByVal Dep_Sol As String, ByVal Estado As String) As DataTable
        Me.Conectar()
        If Estado = "TODAS" Then
            querystring = "SELECT * FROM vpsolicitudes WHERE dep_sol='" + Dep_Sol + "' and fecha_recibido between to_date('" + FechaInicial.ToShortDateString + "','dd/mm/yyyy') and to_date('" + FechaFinal.ToShortDateString + "','dd/mm/yyyy')  "
            Me.CrearComando(querystring)
        Else
            querystring = "SELECT * FROM vpsolicitudes WHERE dep_sol='" + Dep_Sol + "' and fecha_recibido between to_date('" + FechaInicial.ToShortDateString + "','dd/mm/yyyy') and to_date('" + FechaFinal.ToShortDateString + "','dd/mm/yyyy') and Concepto=:Concepto "
            Me.CrearComando(querystring)
            AsignarParametroCadena(":Concepto", Estado)
        End If

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Historico de Revision de la Solicitud
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolHRev(ByVal Cod_Sol As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VpSolicitudeshrev WHERE COD_SOL=:COD_SOL ORDER BY ID_HREV"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":COD_SOL", Cod_Sol)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
#End Region


#Region "Procesos - PContratos"
    ''' <summary>
    ''' Consulta PContratos por dependencia que genera la necesidad 
    ''' </summary>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Shared Function GetPConPorDepNec(ByVal Vigencia As String, ByVal Dep_Con As String, ByVal Cod_Tpro As String, ByVal Estado As String, ByVal Num_Pro As String) As DataTable

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
        Dim p As New PContratos
        Dim dataTb As DataTable = p.GetRecords(cFiltro)

        Return dataTb
    End Function


    ''' <summary>
    ''' Retorna Listado de Posbles estados en los que puede estar un Proceso
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Shared Function GetPEstados() As DataTable
        Dim obj As New PEstados()
        Return obj.GetRecords()
    End Function

    ''' <summary>
    ''' Retorna Listado de Modalidad de Procesos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Shared Function GetTiposProc() As DataTable
        Dim obj As New TiposProc()
        Return obj.GetRecords()
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Shared Function GetProcbyPK(ByVal Num_Proc As String) As DataTable
        Dim obj As New PContratos()
        Return obj.GetByPk(Num_Proc)
    End Function
    ''' <summary>
    ''' Retorna Cronograma de Actividades del Proceso
    ''' </summary>
    ''' <param name="Num_Proc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Shared Function GetPCrono(ByVal Num_Proc As String) As DataTable
        Dim obj As New PCronogramas
        Return obj.GetRecords(Num_Proc)
    End Function

#End Region


#Region "General"
    ''' <summary>
    ''' Dependencias para Usuario Usuario Actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDepbyUser(ByVal Username As String) As DataTable
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()
        'Dim s As String = "SELECT * FROM Terceros WHERE ter_est='AC' And upper(Ter_usu)='" + UCase(User) + "'"
        Dim queryString As String = "SELECT * FROM VDEPTER WHERE COD_DEP<>'00' And ide_ter_abo=:ide_ter_abo ORDER BY NOM_DEP"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":ide_ter_abo", Username)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
#End Region
End Class
