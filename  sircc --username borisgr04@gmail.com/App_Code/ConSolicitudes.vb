Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Public Class ConSolicitudes
    Inherits PSolicitudes
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolicitudes(ByVal filtro As String) As DataTable
        Return GetSolByAbog(filtro)
    End Function
  

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolCord(ByVal Filtro As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        If Filtro <> "" Then
            'querystring = "SELECT vps.*,(SELECT Count(*) as Cantidad FROM(vpcronogramasdt) WHERE is_final = 'NO' and DATETIMEF <sysdate  and Num_Proc=vps.proceso) Act_Atrasadas FROM VPSOLICITUDES vps WHERE " + Filtro
            querystring = " Select * from vpsolicitudes_inf where " + Filtro
            Me.CrearComando(querystring)
            dataTb = Me.EjecutarConsultaDataTable()
        Else
            dataTb = New DataTable()
        End If
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByPKRep(ByVal cod_sol As String) As DataTable
        Return MyBase.GetByPk(cod_sol)
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetHrevRep(ByVal cod_sol As String) As DataTable
        Return MyBase.GetHrev(cod_sol)
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolPen(ByVal Username As String) As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        querystring = "SELECT * From VPSolicitudes Where Recibido='S' And Concepto='P' And id_Abog_Enc=:usuencargado"
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuencargado", Username)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolPenD() As DataTable
        'Dim queryString As String = "SELECT * FROM " + Vista + " Where Estado='TR' And usuencargado=:usuencargado"
        querystring = "SELECT * From VPSolicitudes Where Recibido='S' And Concepto='P' And Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", Me.usuario)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSolPen() As DataTable
        Return GetSolPen(Me.usuario)
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByDepNecxFec(ByVal RECIBIDO As String, ByVal Desde As Date, ByVal Hasta As Date, Optional ByVal Cod_Sol As String = "") As DataTable
        Dim dataTb As DataTable = New DataTable
        Me.Conectar()
        Select Case RECIBIDO
            Case 1
                If String.IsNullOrEmpty(Cod_Sol) Then
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Recibido='N' And Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    'Me.AsignarParametroCadena(":Recibido", "N")
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Recibido='N' And Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Cod_Sol LIKE :Cod_Sol"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    ' Me.AsignarParametroCadena(":Recibido", "N")
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
            Case 2
                If String.IsNullOrEmpty(Cod_Sol) Then
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Recibido='S' And Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    ' Me.AsignarParametroCadena(":Recibido", "S")
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Recibido='S' And Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Cod_Sol LIKE :Cod_Sol"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    ' Me.AsignarParametroCadena(":Recibido", "S")
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
            Case 4
                If String.IsNullOrEmpty(Cod_Sol) Then
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Recibido='S' And Concepto='P' And Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
                    Me.CrearComando(querystring)
                    ' Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Recibido='S' And Concepto='P' And Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Cod_Sol LIKE :Cod_Sol"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
            Case 3
                If String.IsNullOrEmpty(Cod_Sol) Then
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Recibido='S' And Concepto!='P' And Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)

                    'Throw New Exception(Me.vComando.CommandText)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Recibido='S' And Concepto!='P' And Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Cod_Sol LIKE :Cod_Sol"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
                    'Throw New Exception(vComando.CommandText)
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
            Case 5
                If String.IsNullOrEmpty(Cod_Sol) Then
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy')"
                    Me.CrearComando(querystring)
                    ' Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Cod_Sol LIKE :Cod_Sol"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
            Case 6
                If String.IsNullOrEmpty(Cod_Sol) Then
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Id_Abog_Enc is not null"
                    Me.CrearComando(querystring)
                    ' Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Cod_Sol LIKE :Cod_Sol and Id_Abog_Enc is not null"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
            Case 7
                If String.IsNullOrEmpty(Cod_Sol) Then
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Id_Abog_Enc is null"
                    Me.CrearComando(querystring)
                    ' Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    dataTb = Me.EjecutarConsultaDataTable()
                Else
                    querystring = "SELECT * From VPSOLICITUDESHREV Where Dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario ) And FEC_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') and Cod_Sol LIKE :Cod_Sol and Id_Abog_Enc is null"
                    Me.CrearComando(querystring)
                    'Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
                    Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
                    Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
                    Me.AsignarParametroCadena(":usuario", Me.usuario)
                    Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
                    dataTb = Me.EjecutarConsultaDataTable()
                End If
        End Select
        Me.Desconectar()
        Return dataTb
    End Function

End Class

