Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class AvisosActD
    Inherits BDDatos

    Private _Num_PSol As String
    Property Num_PSol() As String
        Get
            Return _Num_PSol
        End Get
        Set(ByVal value As String)
            _Num_PSol = value
        End Set
    End Property

    Private _Num_Proc As String
    Property Num_Proc() As String
        Get
            Return _Num_Proc
        End Get
        Set(ByVal value As String)
            _Num_Proc = value
        End Set
    End Property

    Private _Fec_Ini As String
    Property Fec_Ini() As String
        Get
            Return _Fec_Ini
        End Get
        Set(ByVal value As String)
            _Fec_Ini = value
        End Set
    End Property

    Private _Fec_Fin As String
    Property Fec_Fin() As String
        Get
            Return _Fec_Fin
        End Get
        Set(ByVal value As String)
            _Fec_Fin = value
        End Set
    End Property

    
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxAsig(ByVal Vigencia As String) As DataTable
        'Me.Num_PSol = Num_PSol

        Me.Conectar()
        If Not String.IsNullOrEmpty(Me.Num_PSol) Then
            querystring = "SELECT * FROM vPSOLICITUDES WHERE (Vig_Sol=:Vig_Sol and Id_Abog_Enc is null and Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )) And FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Cod_Sol like :Cod_Sol"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Num_PSol) + "%")
        Else
            querystring = "SELECT * FROM vPSOLICITUDES WHERE (Vig_Sol=:Vig_Sol and Id_Abog_Enc is null and Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )) And FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
            Me.CrearComando(querystring)
        End If
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":Vig_Sol", Vigencia)
        Me.AsignarParametroCadena(":F1", Fec_Ini)
        Me.AsignarParametroCadena(":F2", Fec_Fin)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb
    End Function

    ''' <summary>
    '''  Retorna las solicitudes a cargo del usuario actual dependenciendo de su estado de RECIBIDO, en un periodio de fecha
    ''' </summary>
    ''' <param name="RECIBIDO">SI (S) o (NO)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByDepxFec(ByVal RECIBIDO As String, Optional ByVal Concepto As String = "") As DataTable

        Me.Conectar()
        If String.IsNullOrEmpty(Num_PSol) Then
            querystring = "SELECT * FROM VPSOLICITUDESHREV WHERE Recibido=:Recibido and FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Concepto Like :Concepto And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) order by FECHA_RECIBIDO desc"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":usuario", Me.usuario)
            Me.AsignarParametroCadena(":Recibido", RECIBIDO)
            Me.AsignarParametroCadena(":F1", Me.Fec_Ini)
            Me.AsignarParametroCadena(":F2", Me.Fec_Fin)
            Me.AsignarParametroCadena(":Concepto", "%" + UCase(Concepto) + "%")
        Else
            querystring = "SELECT * FROM VPSOLICITUDESHREV WHERE Recibido=:Recibido And FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Cod_Sol Like :Cod_Sol And Concepto Like :Concepto And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) Order by FECHA_RECIBIDO desc"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":usuario", Me.usuario)
            Me.AsignarParametroCadena(":Recibido", RECIBIDO)
            Me.AsignarParametroCadena(":F1", Me.Fec_Ini)
            Me.AsignarParametroCadena(":F2", Me.Fec_Fin)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Num_PSol) + "%")
            Me.AsignarParametroCadena(":Concepto", "%" + UCase(Concepto) + "%")
            '
        End If
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb
    End Function



    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxRecibirD(ByVal Vigencia As String) As DataTable
        'Me.Num_PSol = Num_PSol

        Me.Conectar()
        If Not String.IsNullOrEmpty(Me.Num_PSol) Then
            querystring = "SELECT * FROM vPSOLICITUDES WHERE (Vig_Sol=:Vig_Sol and Recibido='N' and Id_Abog_Enc is not null and Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )) And FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Cod_Sol like :Cod_Sol"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Num_PSol) + "%")
        Else
            querystring = "SELECT * FROM vPSOLICITUDES WHERE (Vig_Sol=:Vig_Sol and Recibido='N' and Id_Abog_Enc is not null and Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )) And FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
            Me.CrearComando(querystring)
        End If
        Me.AsignarParametroCadena(":F1", Fec_Ini)
        Me.AsignarParametroCadena(":F2", Fec_Fin)
        Me.AsignarParametroCadena(":usuario", usuario)
        Me.AsignarParametroCadena(":Vig_Sol", Vigencia)
        'Throw New Exception(vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAvisosHoyD() As DataTable
        Me.Conectar()
        'querystring = "SELECT Num_Proc 'N° Proceso',Nom_Act 'Actividad',FechaI 'Fecha Inicial', Des_HorI 'Hora Inicial', Notas,Ocupado,Nom_Est 'Estado',Cod_Act,ID FROM vPCronogramas Where usuencargado=:Usuario and IS_FINAL='NO' and fecha_aviso<=sysdate"
        querystring = "SELECT * FROM vPCronoAvisosHoy Where DEP_PCON In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:Usuario ) "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Usuario", Me.usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAvisosAtrasadosD() As DataTable
        Me.Conectar()
        'querystring = "SELECT Num_Proc 'N° Proceso',Nom_Act 'Actividad',FechaI 'Fecha Inicial', Des_HorI 'Hora Inicial', Notas,Ocupado,Nom_Est 'Estado',Cod_Act,ID FROM vPCronogramas Where usuencargado=:Usuario and IS_FINAL='NO' and fecha_aviso<=sysdate"
        Me.Conectar()
        'querystring = "SELECT Num_Proc 'N° Proceso',Nom_Act 'Actividad',FechaI 'Fecha Inicial', Des_HorI 'Hora Inicial', Notas,Ocupado,Nom_Est 'Estado',Cod_Act,ID FROM vPCronogramas Where usuencargado=:Usuario and IS_FINAL='NO' and fecha_aviso<=sysdate"
        If Not String.IsNullOrEmpty(Me.Num_Proc) Then
            querystring = "SELECT * FROM vPCronoAvisos Where DEP_PCON In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:Usuario ) And FECHAI BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Pro_Sel_Nro like :Cod_Pro"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Pro", "%" + UCase(Num_Proc) + "%")
        Else
            querystring = "SELECT * FROM vPCronoAvisos Where DEP_PCON In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:Usuario ) And FECHAI BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') "
            Me.CrearComando(querystring)
        End If
        AsignarParametroCadena(":Usuario", Me.usuario)
        Me.AsignarParametroCadena(":F1", Fec_Ini)
        Me.AsignarParametroCadena(":F2", Fec_Fin)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolPenD(ByVal Vigencia As String) As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        querystring = "SELECT * From VPSolicitudes Where Vig_Sol=:Vig_Sol and Recibido='S' And Concepto='P' And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":Vig_Sol", Vigencia)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolAcep(ByVal Vigencia As String) As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        Me.Conectar()
        If Not String.IsNullOrEmpty(Me.Num_PSol) Then
            querystring = "SELECT * From VPSolicitudes Where Concepto='A' And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario) And FECHA_REVISADO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Cod_Sol Like :Cod_Sol"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Num_PSol) + "%")
        Else
            querystring = "SELECT * From VPSolicitudes Where Concepto='A' And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario) And FECHA_REVISADO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
            Me.CrearComando(querystring)
        End If
        Me.AsignarParametroCadena(":F1", Fec_Ini)
        Me.AsignarParametroCadena(":F2", Fec_Fin)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        'Me.AsignarParametroCadena(":Vig_Sol", Vigencia)
        'Throw New Exception(vComando.CommandText)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolRech(ByVal Vigencia As String) As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        Me.Conectar()

        If Not String.IsNullOrEmpty(Me.Num_PSol) Then
            querystring = "SELECT * From VPSolicitudes Where Concepto='R' And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FECHA_REVISADO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Cod_Sol Like :Cod_Sol"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Num_PSol) + "%")
        Else
            querystring = "SELECT * From VPSolicitudes Where Concepto='R' And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FECHA_REVISADO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
            Me.CrearComando(querystring)
        End If
        Me.AsignarParametroCadena(":F1", Fec_Ini)
        Me.AsignarParametroCadena(":F2", Fec_Fin)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        'Me.AsignarParametroCadena(":Vig_Sol", Vigencia)
        'Throw New Exception(vComando.CommandText)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetProcbyDepDelEstado(ByVal Nom_Est As String, ByVal Vigencia As String) As DataTable
        Dim queryString As String = "SELECT * FROM vPContratos Where final='NO' and Nom_Est=:Nom_Est And Dep_pcon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FECHARECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":F1", Fec_Ini)
        Me.AsignarParametroCadena(":F2", Fec_Fin)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        'Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Me.AsignarParametroCadena(":Nom_Est", Nom_Est)
        'Throw New Exception(vComando.CommandText)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCProcesosxDepDel(ByVal Vigencia As String) As DataTable
        Me.Conectar()
        querystring = "Select count(*) Cantidad from vpcontratos where final='NO' and Dep_PCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FECHARECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":F1", Fec_Ini)
        Me.AsignarParametroCadena(":F2", Fec_Fin)
        'Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetProcesosxDepDel(ByVal Vigencia As String) As DataTable
        Me.Conectar()
        querystring = "Select nom_est Estado,count(*) Cantidad from vpcontratos where final='NO' and Dep_PCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FECHARECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') group by nom_est Order by Count(*)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":F1", Fec_Ini)
        Me.AsignarParametroCadena(":F2", Fec_Fin)
        'Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetProcxDepDel(ByVal Vigencia As String) As DataTable
        Me.Conectar()
        querystring = "Select * from vpcontratos where final='NO' and Dep_PCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FECHARECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":F1", Fec_Ini)
        Me.AsignarParametroCadena(":F2", Fec_Fin)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        'Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
