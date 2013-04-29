Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class Dependencias
    Inherits BDDatos
    Public Sub New()
        Me.Tabla = "dependencia"
        Me.Vista = "vdependencia2"
        Me.VistaDB = "Vdependencia2DB"
        'SELECT "COD_DEP", "NOM_DEP" FROM sircc.vdepdel ORDER BY "NOM_DEP"
        'SELECT "COD_DEP", "NOM_DEP" FROM "DEPENDENCIA" ORDER BY "NOM_DEP"
    End Sub


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecordsDB() As DataTable
        Dim queryString As String = "SELECT * FROM  Vdependencia2DB Order by Nom_Dep"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal busc As String) As DataTable
        busc = IIf(busc <> "", "%" + UCase(busc) + "%", "")
        Dim queryString As String = "SELECT * FROM  vdependencia2 Where (COD_DEP like :busc) OR (upper(NOM_DEP) like :busc) OR (upper(DEP_ABR) like :busc) OR (upper(NOM_TER) like :busc) Order by Nom_Dep"
        Me.Conectar()
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":busc", busc)
        Me.AsignarParametroCadena(":busc", busc)
        Me.AsignarParametroCadena(":busc", busc)
        Me.AsignarParametroCadena(":busc", busc)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
    ''' <summary>
    ''' Dependencias con Opcion de Filtro
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Dim queryString As String = "SELECT * FROM  vdependencia2 Order by Nom_Dep"
        Me.Conectar()
        Me.CrearComando(queryString)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet

    End Function
   
    ''' <summary>
    ''' Dependencias a Delegadas Asignadas a Usuario Actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDelbyUser() As DataTable
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()
        'Dim s As String = "SELECT * FROM Terceros WHERE ter_est='AC' And upper(Ter_usu)='" + UCase(User) + "'"
        Dim queryString As String = "SELECT * FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo ORDER BY NOM_DEP"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

  
  
    ''' <summary>
    ''' Consulta dependencias a Cargo del Tercero/Usuario Actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetNecbyUser() As DataTable
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado

        Me.Conectar()
        querystring = "Select * from vdepnec_usu where ide_ter_abo=:ide_ter_abo ORDER BY NOM_DEP"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDelegadas() As DataTable
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()
        'Dim s As String = "SELECT * FROM Terceros WHERE ter_est='AC' And upper(Ter_usu)='" + UCase(User) + "'"
        Dim queryString As String = "SELECT * FROM vdepdel ORDER BY NOM_DEP"
        Me.CrearComando(queryString)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
   Public Function GetAbreviatura(ByVal cod_dep As String, Optional ByVal connectar As Boolean = False) As String
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        If connectar = True Then
            Me.Conectar()
        End If

        'Dim s As String = "SELECT * FROM Terceros WHERE ter_est='AC' And upper(Ter_usu)='" + UCase(User) + "'"
        Dim queryString As String = "select dep_abr from dependencia where cod_dep=:cod_dep"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":cod_dep", cod_dep)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        If connectar = True Then
            Me.Desconectar()
        End If
        Return dataTb.Rows(0)("dep_abr").ToString

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
     Public Function GetbyPK(ByVal cod_dep As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "select * from Vdependencia2DB where cod_dep=:cod_dep "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":cod_dep", cod_dep)
        Dim dt As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt

    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 23 FEB 2011
    ''' MODIFICACION:
    ''' SE AGREGO EL PARAMETRO EMAIL A LA FUNCION INSER PARA GUARDAR CORREO
    ''' </summary>
    ''' <param name="cod_dep"></param>
    ''' <param name="nom_dep"></param>
    ''' <param name="dep_del"></param>
    ''' <param name="dep_abr"></param>
    ''' <param name="ide_ter"></param>
    ''' <param name="norma_del"></param>
    ''' <param name="Email"></param>
    ''' <param name="Estado"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal cod_dep As String, ByVal nom_dep As String, ByVal dep_del As String, ByVal dep_abr As String, ByVal ide_ter As String, ByVal norma_del As String, ByVal Email As String, ByVal cargo_enc As String, ByVal Estado As String) As String
        Me.Conectar()
        Try
            Dim queryString As String = "Insert Into dependencia (cod_dep, nom_dep, dep_del, dep_abr,ide_ter,norma_del, Email,cargo_enc, Estado)Values(:cod_dep, :nom_dep, :dep_del, :dep_abr,:ide_ter,:norma_del, :Email,cargo_enc, :Estado)"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":cod_dep", cod_dep)
            Me.AsignarParametroCadena(":nom_dep", nom_dep)
            Me.AsignarParametroCadena(":dep_del", dep_del)
            Me.AsignarParametroCadena(":dep_abr", dep_abr)
            Me.AsignarParametroCadena(":ide_ter", ide_ter)
            Me.AsignarParametroCadena(":norma_del", norma_del)
            Me.AsignarParametroCadena(":Email", Email)
            Me.AsignarParametroCadena(":cargo_enc", cargo_enc)
            Me.AsignarParametroCadena(":Estado", Estado)


            Me.num_reg = EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False

        Catch ex As Exception
            Me.Msg = "Error: " + ex.Message
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg

    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 23 FEB 2011
    ''' MODIFICACION:
    ''' SE AGREGO EL PARAMETRO EMAIL A LA FUNCION UPDATE PARA MODIFICAR CORREO
    ''' </summary>
    ''' <param name="pk1_cod_dep"></param>
    ''' <param name="cod_dep"></param>
    ''' <param name="nom_dep"></param>
    ''' <param name="dep_del"></param>
    ''' <param name="dep_abr"></param>
    ''' <param name="ide_ter"></param>
    ''' <param name="norma_del"></param>
    ''' <param name="Email"></param>
    ''' <param name="Estado"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal pk1_cod_dep As String, ByVal cod_dep As String, ByVal nom_dep As String, ByVal dep_del As String, ByVal dep_abr As String, ByVal ide_ter As String, ByVal norma_del As String, ByVal Email As String, ByVal cargo_enc As String, ByVal Estado As String, Optional ByVal connect As Boolean = True) As String
        If connect Then
            Me.Conectar()
        End If

        Try
            Dim queryString As String = "Update dependencia Set cargo_enc=:cargo_enc,cod_dep=:cod_dep, nom_dep=:nom_dep, dep_del=:dep_del, dep_abr=:dep_abr, ide_ter=:ide_ter,norma_del=:norma_del, Email=:Email, Estado=:Estado Where cod_dep=:pk1_cod_dep"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":cod_dep", cod_dep)
            Me.AsignarParametroCadena(":nom_dep", nom_dep)
            Me.AsignarParametroCadena(":dep_del", dep_del)
            Me.AsignarParametroCadena(":dep_abr", dep_abr)
            Me.AsignarParametroCadena(":ide_ter", ide_ter)
            Me.AsignarParametroCadena(":norma_del", norma_del)
            Me.AsignarParametroCadena(":Email", Email)
            Me.AsignarParametroCadena(":Estado", Estado)
            Me.AsignarParametroCadena(":cargo_enc", cargo_enc)
            Me.AsignarParametroCadena(":pk1_cod_dep", pk1_cod_dep)
            Me.num_reg = EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "] - "
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error: " + ex.Message
            Me.lErrorG = True
        Finally
            If connect Then
                Me.Desconectar()
            End If
        End Try

        Return Msg

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)> _
Public Function Delete(ByVal cod_dep As String) As String
        Me.Conectar()
        Try
            Dim queryString As String = "Delete From dependencia Where cod_dep=:cod_dep"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":cod_dep", cod_dep)
            Me.num_reg = EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "] - "
        Catch ex As Exception
            Me.Msg = "Error: " + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg

    End Function

    ''' <summary>
    ''' Dependencias a Delegadas Asignadas a Usuario Actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDelbySoloUser() As DataTable
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()
        'Dim s As String = "SELECT * FROM Terceros WHERE ter_est='AC' And upper(Ter_usu)='" + UCase(User) + "'"
        Dim queryString As String = "SELECT * FROM vDepDelTer WHERE COD_DEP<>'00' And ide_ter_abo=:ide_ter_abo ORDER BY NOM_DEP"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' Asignar Abogado a Dependencia
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function AsignarAbogado(ByVal Cod_Dep As String, ByVal Ide_Ter As String, ByVal ASig_Proc As String, ByVal Coordinador As String, Optional ByVal Conect As Boolean = True) As String
        If Conect Then
            Me.Conectar()
        End If
        Try
            Dim queryString As String = "Insert Into HDEP_ABOGADOS(Cod_Dep,Ide_Ter,Asig_Proc,Coordinador)Values(:Cod_Dep,:Ide_Ter,:Asig_Proc,:Coordinador)"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":Cod_Dep", Cod_Dep)
            Me.AsignarParametroCadena(":Ide_Ter", Ide_Ter)
            Me.AsignarParametroCadena(":Asig_Proc", ASig_Proc)
            Me.AsignarParametroCadena(":Coordinador", Coordinador)
            Me.num_reg = EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error: " + ex.Message
            Me.lErrorG = True
        Finally
            If Conect Then
                Me.Desconectar()
            End If
        End Try
        Return Msg
    End Function
    ''' <summary>
    ''' Evalua los procesos pendientes a cargo de un funcionario o contratista
    ''' </summary>
    ''' <param name="ID_HDEP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ProcesosActxDepxUsu(ByVal ID_HDEP As String) As Integer
        querystring = "SELECT COUNT (*) Cant FROM vpcontratos WHERE FINAL = 'NO' AND (dep_pcon,usuencargado) In (Select cod_dep,ide_ter From hdep_abogados Where Id_Hdep=:ID_HDEP)"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":ID_HDEP", ID_HDEP)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Dim cant_proc As Integer = CInt(dt.Rows(0)("Cant"))
        Return cant_proc
    End Function
    ''' <summary>
    ''' Evalua la cantidad de solicitudes a cargo de un funcionario o contratista
    ''' </summary>
    ''' <param name="ID_HDEP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SolicitudesActxDepxUsu(ByVal ID_HDEP As String) As Integer
        querystring = "select COUNT (*) Cant from vpsolicitudes where  Concepto='P' And (dep_psol,id_abog_enc) In (Select cod_dep,ide_ter From hdep_abogados Where Id_Hdep=:ID_HDEP)"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":ID_HDEP", ID_HDEP)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Dim cant_sol As Integer = CInt(dt.Rows(0)("Cant"))
        Return cant_sol
    End Function

    ''' <summary>
    ''' Retirar Usuario Vinculado a Dependencia
    ''' </summary>
    ''' <param name="ID_HDEP"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function DAsignarAbogado(ByVal ID_HDEP As String, Optional ByVal connect As Boolean = True) As String
        If connect Then
            Me.Conectar()
        End If

        Try
            'ComenzarTransaccion()
            Dim Sw As Boolean = False
            Dim cant_proc As Integer = ProcesosActxDepxUsu(ID_HDEP)
            'Se cambia Temporarlmente para 
            'If cant_proc > 0 Then
            '    Msg = "El Usuario Tiene (" + cant_proc.ToString + ") Procesos a Cargo sin Finalizar.   "
            '    Sw = True
            'End If
            'Dim cant_sol As Integer = SolicitudesActxDepxUsu(ID_HDEP)
            'If cant_sol > 0 Then
            '    Msg += IIf(Msg <> "", "<br/>", "") + "El Usuario Tiene (" + cant_proc.ToString + ") Solicitudes a Cargo sin Revisar.   "
            '    Sw = True
            'End If
            'If Sw = True Then
            '    lErrorG = True
            '    Throw New Exception(Msg)
            'End If
            Dim queryString As String = "UPDATE HDEP_ABOGADOS SET ESTADO='IN' WHERE ID_HDEP=:ID_HDEP"
            Me.CrearComando(queryString)
            Me.AsignarParametroCadena(":ID_HDEP", ID_HDEP)
            Me.num_reg = EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            'Me.ConfirmarTransaccion()
            lErrorG = False

        Catch ex As Exception
            Me.Msg = "Error: " + ex.Message
            lErrorG = True
            ' Me.CancelarTransaccion()
        Finally
            If connect Then
                Me.Desconectar()
            End If
        End Try
        Return Msg

    End Function
    ''' <summary>
    ''' Retorna Lista de Abogados Habilitados
    ''' </summary>
    ''' <param name="Cod_Dep"></param>
    ''' <param name="SoloActivos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetAbogados(ByVal Cod_Dep As String, ByVal SoloActivos As Boolean) As DataTable

        Me.Conectar()
        querystring = "SELECT * FROM VHDEP_SOLOABOGADOS WHERE Cod_Dep=:Cod_Dep"

        querystring = IIf(SoloActivos, querystring + " And Estado='AC'", querystring)

        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Dep", Cod_Dep)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCoordinadores() As DataTable

        Me.Conectar()
        querystring = "SELECT * FROM VHDEP_SOLOABOGADOS WHERE (Cod_Dep in (select cod_dep from hdep_abogados where ide_ter=:Usuario)) And Coordinador='SI'"

        'querystring = IIf(SoloActivos, querystring + " And Estado='AC'", querystring)

        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Usuario", Me.usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetAbogados(ByVal Cod_Dep As String) As DataTable

        Return GetAbogados(Cod_Dep, False)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetVinculados(ByVal Cod_Dep As String) As DataTable

        Return GetVinculados(Cod_Dep, False)

    End Function
    ''' <summary>
    ''' Modificar el parametro de Asignación de Procesos
    ''' </summary>
    ''' <param name="ID_HDEP"></param>
    ''' <param name="ASIG_PROC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal ID_HDEP As String, ByVal ASIG_PROC As String, ByVal Coordinador As String, Optional ByVal connect As Boolean = True) As String
        If connect Then
            Me.Conectar()
        End If

        Try
            'Me.ComenzarTransaccion()
            Dim queryString As String = "UPDATE HDEP_ABOGADOS SET ESTADO='AC',ASIG_PROC=:ASIG_PROC, Coordinador=:Coordinador WHERE ID_HDEP=:ID_HDEP"
            Me.CrearComando(queryString)

            Me.AsignarParametroCadena(":ASIG_PROC", ASIG_PROC)
            Me.AsignarParametroCadena(":ID_HDEP", ID_HDEP)
            Me.AsignarParametroCadena(":Coordinador", Coordinador)

            Me.num_reg = EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            'Me.ConfirmarTransaccion()
            lErrorG = False

        Catch ex As Exception
            Me.Msg = "Error: " + ex.Message
            lErrorG = True
            'Me.CancelarTransaccion()
        Finally
            If connect Then
                Me.Desconectar()
            End If
        End Try
        Return Msg

    End Function
    ''' <summary>
    ''' Retorna Lista de Terceros Vinculados a la Dependencia
    ''' </summary>
    ''' <param name="Cod_Dep"></param>
    ''' <param name="SoloActivos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetVinculados(ByVal Cod_Dep As String, ByVal SoloActivos As Boolean) As DataTable

        Me.Conectar()
        querystring = "SELECT * FROM VHDEP_ABOGADOS WHERE Cod_Dep=:Cod_Dep"

        querystring = IIf(SoloActivos, querystring + " And Estado='AC'", querystring)

        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Dep", Cod_Dep)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    ''' <summary>
    ''' Retorna Fila del Vinculado asociado al Id 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetVinculado(ByVal Id_Hdep As String) As DataTable

        Me.Conectar()
        querystring = "SELECT * FROM vHDEP_ABOGADOS WHERE ID_HDEP=:ID_HDEP"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ID_HDEP", Id_Hdep)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function



End Class



