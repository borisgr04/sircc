Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class ConGProcesos
    Inherits PContratos

    Sub New()
        MyBase.new()
    End Sub

    ''' <summary>
    ''' Consulta de Contratos por llave primaria x TODOS LOS CAMPOS
    ''' </summary>
    ''' <param name="Num_Proc"></param>
    ''' <param name="Grupo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkC(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        querystring = "SELECT * FROM VGPROCESOSC where Pro_Sel_Nro=:Num_Proc AND GRUPO=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkC_Plantillas(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        querystring = "SELECT * FROM VGPROCESOSC_Plantillas where Pro_Sel_Nro=:Num_Proc AND GRUPO=:Grupo"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Procesos para el Usuario Actual
    ''' </summary>
    ''' <returns>Tabla Estado, Cantidad </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Filtro As String) As DataTable
        Return MyBase.GetRecords(Filtro)
    End Function

    ''' <summary>
    ''' Procesos para el Usuario Actual
    ''' </summary>
    ''' <returns>Tabla Estado, Cantidad </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetMisProcesos() As DataTable
        Me.Conectar()
        querystring = "Select nom_est Estado,count(*) Cantidad from vpcontratos where usuencargado=:usuencargado group by nom_est Order by Count(*)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuencargado", Me.usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    ''' <summary>
    '''  Actual OJO REVISAR/SOLO PROCESOS SIN TERMINAR
    ''' </summary>
    ''' <returns>Tabla Estado, Cantidad </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxDepDel(ByVal Dep_PCon As String) As DataTable
        Me.Conectar()
        querystring = "Select * from vgprocesos where FINAL = 'NO' And  Dep_PCon=:Dep_PCon"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Dep_PCon", Dep_PCon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    '''  Carga de Trabajo Procesos y Solicitudes sin terminar
    ''' </summary>
    ''' <returns>Tabla Estado, Cantidad </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCargaPSxDel(ByVal Dep_PCon As String) As DataTable
        Me.Conectar()
        querystring = "Select * from vCargaPS  where  Dep_PCon=:Dep_PCon"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Dep_PCon", Dep_PCon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' COnsulta de Estado para el Usuario Actual en el estado correpondienes
    ''' </summary>
    ''' <param name="Nom_Est"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMisProcbyEstado(ByVal Nom_Est As String) As DataTable
        querystring = "SELECT * FROM " + Vista + " Where Nom_Est=:Nom_Est And usuencargado=:usuencargado"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":usuencargado", Me.usuario)
        Me.AsignarParametroCadena(":Nom_Est", Nom_Est)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    ''' <summary>
    ''' Retorna Procesos lista para Generar Minuta . Estado= Definitivo, para el usuario especificado
    ''' </summary>
    ''' <param name="Username"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMisProcbyGMinuta(ByVal Username As String) As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        querystring = "SELECT Pro_Sel_Nro ""N° Proceso"", Grupo ""Grupo"",Obj_Con ""Objeto"", Nom_Tip ""Tipo de Documento"",Nom_Stip ""Clase"" FROM VGPROCESOSC Where Estado='DF' And ide_encargado=:usuencargado"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":usuencargado", Username)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMisProcTramite(ByVal Username As String) As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        querystring = "SELECT Pro_Sel_Nro ""N° Proceso"", Grupo ""Grupo"",Obj_Con ""Objeto"", Nom_Tip ""Tipo de Documento"",Nom_Stip ""Clase"" FROM VGPROCESOSC Where Estado='TR' And ide_encargado=:usuencargado"
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuencargado", Username)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMisProcbyGMinutaCord(ByVal Username As String) As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        querystring = "SELECT Pro_Sel_Nro ""N° Proceso"", Grupo ""Grupo"",Obj_Con ""Objeto"", Nom_Tip ""Tipo de Documento"",Nom_Stip ""Clase"" FROM VGPROCESOSC Where Estado='DF' And Dep_PCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Username)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMisProcbyGMinutaCord() As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        querystring = "SELECT Pro_Sel_Nro ""N° Proceso"", Grupo ""Grupo"",Obj_Con ""Objeto"", Nom_Tip ""Tipo de Documento"",Nom_Stip ""Clase"", Encargado FROM VGPROCESOSC Where Estado='DF' And Dep_PCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    ''' <summary>
    ''' Retorna Procesos lista para Generar Minuta . Estado= Definitivo, para el usuario actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMisProcbyGMinuta() As DataTable
        Return GetMisProcbyGMinuta(Me.usuario)
    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 23 MARZO DE 2011
    ''' MODIFICACION:
    ''' FUNCION PARA LLENAR EL DATASET DEL REPORTE PCONTRATOSCORD
    ''' </summary>
    ''' <param name="Filtro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsRep(ByVal Filtro As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        If Filtro <> "" Then
            Dim queryString As String = "SELECT * FROM VPContratosRep Where " + Filtro
            Me.CrearComando(queryString)
            dataTb = Me.EjecutarConsultaDataTable()
        Else
            dataTb = New DataTable
        End If
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 23 MARZO DE 2011
    ''' MODIFICACION:
    ''' FUNCION PARA LLENAR EL DATASET DEL REPORTE PCONTRATOSCORD
    ''' </summary>
    ''' <param name="Filtro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsxEncRep(ByVal Filtro As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        If Filtro <> "" Then
            Dim queryString As String = "SELECT * FROM VPContratosRep Where usuencargado=:usuencargado and " + Filtro
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":usuencargado", Me.usuario)
            dataTb = Me.EjecutarConsultaDataTable()
        Else
            dataTb = New DataTable
        End If
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ GONZALEZ
    ''' FECHA: 28 DE MARZO DE 2011/Por BOris el 13 de Febrero de 2013
    ''' </summary>
    ''' <param name="Num_PCon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkRad(ByVal Num_PCon As String, ByVal Grupo As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        Grupo = IIf(String.IsNullOrEmpty(Grupo), "1", Grupo)
        querystring = "SELECT * FROM VPContratosRep where Pro_Sel_Nro=:NUm_Pcon And Grupo=:Grupo "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Me.AsignarParametroCadena(":Grupo", Grupo)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Procesos para el Usuario Actual
    ''' </summary>
    ''' <returns>Tabla Estado, Cantidad </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetTabla(ByVal iTabla As String, ByVal iNum_Proc As String, ByVal iGrupo As String) As DataTable
        querystring = "SELECT * FROM " + iTabla + " Where Num_Proc=:Num_Proc And  Grupo=:Grupo"
        Me.Conectar()
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Num_Proc", iNum_Proc)
        AsignarParametroCadena(":Grupo", iGrupo)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

End Class
