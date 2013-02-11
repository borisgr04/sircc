Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class AvisosActD
    Inherits BDDatos

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxAsig(ByVal Vigencia As String) As DataTable
        'Me.Num_PSol = Num_PSol

        Me.Conectar()

        querystring = "SELECT * FROM vPSOLICITUDES WHERE Vig_Sol=:Vig_Sol and Id_Abog_Enc is null and Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":Vig_Sol", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxRecibirD(ByVal Vigencia As String) As DataTable
        'Me.Num_PSol = Num_PSol

        Me.Conectar()

        querystring = "SELECT * FROM vPSOLICITUDES WHERE Vig_Sol=:Vig_Sol and Recibido='N' and Id_Abog_Enc is not null and Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.CrearComando(querystring)
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
        querystring = "SELECT * FROM vPCronoAvisos Where DEP_PCON In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:Usuario ) "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Usuario", Me.usuario)
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
        querystring = "SELECT * From VPSolicitudes Where Vig_Sol=:Vig_Sol And Concepto='A' And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":Vig_Sol", Vigencia)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolRech(ByVal Vigencia As String) As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        querystring = "SELECT * From VPSolicitudes Where Vig_Sol=:Vig_Sol And Concepto='R' And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":Vig_Sol", Vigencia)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetProcbyDepDelEstado(ByVal Nom_Est As String, ByVal Vigencia As String) As DataTable
        Dim queryString As String = "SELECT * FROM vPContratos Where Vig_Con=:Vig_Con and Nom_Est=:Nom_Est And Dep_pcon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Me.AsignarParametroCadena(":Nom_Est", Nom_Est)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetProcesosxDepDel(ByVal Vigencia As String) As DataTable
        Me.Conectar()
        querystring = "Select nom_est Estado,count(*) Cantidad from vpcontratos where Vig_Con=:Vig_Con and Dep_PCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) group by nom_est Order by Count(*)"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetProcxDepDel(ByVal Vigencia As String) As DataTable
        Me.Conectar()
        querystring = "Select * from vpcontratos where Vig_Con=:Vig_Con and Dep_PCon In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Me.AsignarParametroCadena(":Vig_Con", Vigencia)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
