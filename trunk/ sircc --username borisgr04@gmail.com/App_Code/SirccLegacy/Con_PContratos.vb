Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Con_PContratos
    Inherits PContratos

    Sub New()
        MyBase.new()
    End Sub

    ''' <summary>
    ''' Consulta de Contratos por llave primaria x TODOS LOS CAMPOS
    ''' </summary>
    ''' <param name="Num_PCon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkC(ByVal Num_PCon As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        'falta VPCONTRATOS
        querystring = "SELECT * FROM VPCONTRATOS where Pro_Sel_Nro=:NUm_Pcon"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
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
    Public Overloads Function GetTabla(ByVal iTabla As String, ByVal Num_Proc As String) As DataTable
        querystring = "SELECT * FROM  " + iTabla + " Where Num_Proc='" + Num_Proc + "'"
        Me.Conectar()
        Me.CrearComando(querystring)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
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
    ''' Procesos para el Usuario Actual
    ''' </summary>
    ''' <returns>Tabla Estado, Cantidad </returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetProcesosxDepDel() As DataTable
        Me.Conectar()
        querystring = "Select nom_est Estado,count(*) Cantidad from vpcontratos where Dep_PCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) group by nom_est Order by Count(*)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
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
        querystring = "Select * from vpcontratos where FINAL = 'NO' And  Dep_PCon=:Dep_PCon"
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
        Me.Conectar()
        If String.IsNullOrEmpty(Nom_Est) Then
            Dim queryString As String = "SELECT * FROM " + Vista + " Where usuencargado=:usuencargado"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":usuencargado", Me.usuario)
        Else
            Dim queryString As String = "SELECT * FROM " + Vista + " Where Nom_Est=:Nom_Est And usuencargado=:usuencargado"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":usuencargado", Me.usuario)
            Me.AsignarParametroCadena(":Nom_Est", Nom_Est)
        End If
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    ''' <summary>
    ''' COnsulta de Estado para Dep Del del Usuario Actual en el estado correpondienes
    ''' </summary>
    ''' <param name="Nom_Est"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetProcbyDepDelEstado(ByVal Nom_Est As String) As DataTable
        Dim queryString As String = "SELECT * FROM " + Vista + " Where Nom_Est=:Nom_Est And Dep_pcon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
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
        Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":usuencargado", Username)
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
    ''' Reporte Mensual de Procesos
    ''' </summary>
    ''' <param name="fechaI"></param>
    ''' <param name="fechaF"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsRepMes(ByVal fechaI As String, ByVal fechaF As String, ByVal dep_pcon As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        'If Filtro <> "" Then
        Dim queryString As String = "Select * From vpcontratosrep  Where dep_pcon=:dep_pcon And est_con Not In ('CE','TA') Or Pro_Sel_Nro In (Select Num_Proc From VPCRONOGRAMAS WHERE EST_PROC IN ('CE','TA') AND FECHAF BETWEEN to_date(:fechaI,'dd/mm/yyyy') AND to_date(:fechaF,'dd/mm/yyyy'))   "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":fechaI", fechaI)
        Me.AsignarParametroCadena(":fechaF", fechaF)
        Me.AsignarParametroCadena(":dep_pcon", dep_pcon)
        'Throw New Exception(Me.vComando.CommandText)
        'Throw New Exception(CDate(fechaI) + "-" + CDate(fechaF))
        dataTb = Me.EjecutarConsultaDataTable()

        'Else
        'dataTb = New DataTable
        'End If
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsRep1(ByVal Filtro As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        If Filtro <> "" Then
            Dim queryString As String = "SELECT * FROM VPContratosRep1 Where " + Filtro
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
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsxEncRep1(ByVal Filtro As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        If Filtro <> "" Then
            Dim queryString As String = "SELECT * FROM VPContratosRep1 Where usuencargado=:usuencargado and " + Filtro
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
    ''' FECHA: 28 DE MARZO DE 2011
    ''' </summary>
    ''' <param name="Num_PCon"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkRad(ByVal Num_PCon As String) As DataTable
        Me.Num_PCon = Num_PCon
        Me.Conectar()
        querystring = "SELECT * FROM VPCONTRATOSREP where Pro_Sel_Nro=:NUm_Pcon"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUm_Pcon", Num_PCon)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

	    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMisProcbyDocumentos(ByVal Username As String) As DataTable
        Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado!='RA' And usuencargado=:usuencargado"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":usuencargado", Username)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByDepNecxFec(Optional ByVal Cod_Sol As String = "") As DataTable
        Dim dataTb As DataTable = New DataTable
        Me.Conectar()

        If String.IsNullOrEmpty(Cod_Sol) Then
            querystring = "SELECT * From VPCONTRATOS Where Dep_Con In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
            Me.CrearComando(querystring)
            'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
            'Me.AsignarParametroCadena(":Recibido", "N")
            ' Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
            'Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
            Me.AsignarParametroCadena(":usuario", Me.usuario)
            'Throw New Exception(vComando.CommandText)
            dataTb = Me.EjecutarConsultaDataTable()
        Else
            querystring = "SELECT * From VPCONTRATOS Where Dep_Con In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) and Pro_Sel_Nro LIKE :Cod_Sol"
            Me.CrearComando(querystring)
            'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
            ' Me.AsignarParametroCadena(":Recibido", "N")
            'Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
            'Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
            Me.AsignarParametroCadena(":usuario", Me.usuario)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
            dataTb = Me.EjecutarConsultaDataTable()
        End If
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Reporte Mensual de Procesos
    ''' </summary>
    ''' <param name="fechaI"></param>
    ''' <param name="fechaF"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsRepMes(ByVal lstMod As String, ByVal fechaI As String, ByVal fechaF As String, ByVal dep_pcon As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()

        If lstMod <> "" Then
            Dim queryString As String = "Select * From vpcontratosrep  Where (Cod_TPro In (" + lstMod + ") And dep_pcon=:dep_pcon And est_con Not In ('CE','TA')) Or(Cod_TPro In (" + lstMod + ") And Pro_Sel_Nro In (Select Num_Proc From VPCRONOGRAMAS WHERE EST_PROC IN ('CE','TA') AND FECHAF BETWEEN to_date(:fechaI,'dd/mm/yyyy') AND to_date(:fechaF,'dd/mm/yyyy')))   "
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":fechaI", fechaI)
            Me.AsignarParametroCadena(":fechaF", fechaF)
            Me.AsignarParametroCadena(":dep_pcon", dep_pcon)

            'Throw New Exception(Me.vComando.CommandText)
            'Throw New Exception(CDate(fechaI) + "-" + CDate(fechaF))
            dataTb = Me.EjecutarConsultaDataTable()
        Else
            dataTb = New DataTable
        End If
        Me.Desconectar()
        Return dataTb
    End Function

End Class
