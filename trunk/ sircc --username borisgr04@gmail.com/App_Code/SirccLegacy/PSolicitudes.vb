Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

<System.ComponentModel.DataObject()> _
Public Class PSolicitudes
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

    Public Sub New()
        Me.Tabla = "PSolicitudes"
        Me.Vista = "VPSolicitudes"
    End Sub

    ''' <summary>
    ''' Retorna solicitudes de las dependencias acargo del usuario actual, Busca una solo solicitud con el codigo q se envia
    ''' </summary>
    ''' <param name="Cod_Sol"></param>
    ''' <param name="connect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPk(ByVal Cod_Sol As String, Optional ByVal connect As Boolean = True) As DataTable

        Me.Num_PSol = Num_PSol
        If connect Then
            Me.Conectar()
        End If
        querystring = "SELECT * FROM VPSolicitudes where Cod_Sol=:Cod_Sol And dep_pSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo )"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        If connect Then
            Me.Desconectar()
        End If

        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxDepDel() As DataTable

        Me.Num_PSol = Num_PSol
        Me.Conectar()
        querystring = "SELECT * FROM VPSolicitudes where dep_pSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo )"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 23 FEBRERO DE 2011, MODIFICADO 5 DE MARZO DEL 2011 POR BORIS GONZALEZ
    ''' MODIFICACION: SE AGREGÓ LA FUNCION
    ''' GetByPkAbog ESTA FUNCION UNA SOLA SOLICITUDES DE UN ABOGADO, CON UN CODIGO ESPECIFICO
    ''' QUE YA HALLAN SIDO RECIBIDAS. SOLO DEVUELVE UNA SOLICITUD.
    ''' SE UNA EN Control DetPSolicitudes y en Revisar
    ''' </summary>
    ''' <param name="Cod_Sol"></param>
    ''' <param name="connect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkAbog(ByVal Cod_Sol As String, Optional ByVal connect As Boolean = True) As DataTable

        Me.Num_PSol = Num_PSol
        'If connect Then
        Me.Conectar()
        'End If

        querystring = "SELECT * FROM VPSolicitudes where Cod_Sol=:Cod_Sol and Id_Abog_Enc=:Encargado and Recibido='S'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        Me.AsignarParametroCadena(":Encargado", Me.usuario)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        'If connect Then
        Me.Desconectar()
        'End If

        Return dataTb

    End Function

    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 23 FEBRERO DE 2011, MODIFICADO 5 DE MARZO DEL 2011 POR BORIS GONZALEZ
    ''' MODIFICACION: SE AGREGÓ LA FUNCION
    ''' GetByPkAbog ESTA FUNCION UNA SOLA SOLICITUDES DE UN ABOGADO, CON UN CODIGO ESPECIFICO
    ''' QUE YA HALLAN SIDO RECIBIDAS. SOLO DEVUELVE UNA SOLICITUD.
    ''' SE UNA EN Control DetPSolicitudes y en Revisar
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByAbogxRV() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VPSolicitudes where Id_Abog_Enc=:Encargado and Recibido='S'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Encargado", Me.usuario)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb

    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 23 FEBRERO DE 2011, MODIFICADO 5 DE MARZO DEL 2011 POR BORIS GONZALEZ
    ''' MODIFICACION: SE AGREGÓ LA FUNCION
    ''' GetByPkAbog ESTA FUNCION UNA SOLA SOLICITUDES DE UN ABOGADO, CON UN CODIGO ESPECIFICO
    ''' QUE YA HALLAN SIDO RECIBIDAS. SOLO DEVUELVE UNA SOLICITUD.
    ''' SE UNA EN Control DetPSolicitudes y en Revisar
    ''' Se agrega para ver todas las solicitudes por revisar de las dependencias delegadas del usuario  actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByxRVD() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VPSolicitudes where DEP_PSOL In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:Usuario ) and Recibido='S'"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Usuario", Me.usuario)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb

    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA MODIFICACION: 18 FEB 2011
    ''' MODIFICACION:
    ''' SE AGREGO LA FUNCION GETHREV
    ''' </summary>
    ''' <param name="Cod_Sol"></param>
    ''' <param name="connect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetHrev(ByVal Cod_Sol As String, Optional ByVal connect As Boolean = True) As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Num_PSol = Num_PSol
        'If connect Then
        Me.Conectar()
        'End If
        querystring = "SELECT * FROM vhrevisado where Cod_Sol=:Cod_Sol"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        'If connect Then
        Me.Desconectar()
        'End If

        Return dataTb

    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 23 FEBRERO DE 2011
    ''' MODIFICACION: SE MODIFICO LA CONSULTA SQL PARA QUE SOLO MUESTRE LAS
    ''' SOLICITUDES QUE YA FUERON RECIBIDAS., USUARIO ACTUAL LIKE.
    ''' </summary>
    ''' <param name="Cod_Sol"></param>
    ''' <param name="connect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetSol(ByVal Cod_Sol As String, Optional ByVal connect As Boolean = True) As DataTable
        Me.Num_PSol = Num_PSol
        'If connect Then
        Me.Conectar()
        'End If
        Dim dataTb As DataTable = New DataTable
        If Not String.IsNullOrEmpty(Cod_Sol) Then
            querystring = "select * from vpsolicitudes WHERE (UPPER(COD_SOL) LIKE UPPER(:Cod_Sol) or UPPER(Obj_Sol) like UPPER(:Obj_Sol)) AND Id_Abog_Enc=:Usuario and Recibido='S'"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + Cod_Sol + "%")
            Me.AsignarParametroCadena(":Obj_Sol", "%" + Cod_Sol + "%")
            Me.AsignarParametroCadena(":Usuario", Me.usuario)
            dataTb = Me.EjecutarConsultaDataTable()
        End If

        'If connect Then
        Me.Desconectar()
        'End If

        Return dataTb

    End Function
    ''' <summary>
    ''' Retorna Todas las Solicitudes Asociadas a las dependencias que estan acargo del tercero/Usuario Actual
    ''' </summary>
    ''' <param name="Cod_Sol"></param>
    ''' <param name="connect"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAllSol(ByVal Cod_Sol As String, ByVal Vig_Sol As String, Optional ByVal connect As Boolean = True) As DataTable
        'Me.Desconectar()
        Me.Num_PSol = Num_PSol
        'If connect Then
        Me.Conectar()
        'End If
        If Cod_Sol <> "" Then
            querystring = "select * from vpsolicitudes WHERE (UPPER(COD_SOL) LIKE UPPER(:Cod_Sol) or UPPER(Obj_Sol) like UPPER(:Obj_Sol)) And Vig_Sol=:Vig_Sol  And dep_pSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + Cod_Sol + "%")
            Me.AsignarParametroCadena(":Obj_Sol", "%" + (Cod_Sol) + "%")
            Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)
            Me.AsignarParametroCadena(":Vig_Sol", Vig_Sol)

        Else
            querystring = "select * from vpsolicitudes WHERE 1=0 "
            Me.CrearComando(querystring)
        End If

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        'If connect Then
        Me.Desconectar()
        'End If

        Return dataTb


    End Function
    ''' <summary>
    ''' Retorna las solicitudes no recibidas del usuario actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByAbogado(ByVal usuario As String) As DataTable
        Me.Num_PSol = Num_PSol

        Me.Conectar()

        querystring = "SELECT * FROM vPSOLICITUDES WHERE Recibido='N' and Id_Abog_Enc=:Id_Abog_Enc"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Id_Abog_Enc", usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb
    End Function

    ''' <summary>
    ''' Retorna las solicitudes no recibidas DE LA DEPENDENCIA DEL USUARIO ACTUAL
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxRecibirD() As DataTable
        Me.Num_PSol = Num_PSol

        Me.Conectar()

        querystring = "SELECT * FROM vPSOLICITUDES WHERE Recibido='N' and Dep_PSol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:usuario )"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":usuario", usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByAbog() As DataTable
        Return GetByAbogado(Me.usuario)
    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC YOVANNY MARTINEZ GONZALEZ
    ''' FECHA: 28 MARZO DE 2011
    ''' MODIFICACION: SE AGREGO FUNCION GetSolByAbog LA CUAL ES 
    ''' UTILIZADA EN CONSOLICITUDES
    ''' </summary>
    ''' <param name="Filtro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetSolByAbog(ByVal Filtro As String) As DataTable
        Dim dataTB As DataTable
        Me.Conectar()
        If Filtro <> "" Then
            querystring = "SELECT * FROM VPSOLICITUDES WHERE Id_Abog_Enc=:Id_Abog_Enc and " + Filtro
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
            dataTB = Me.EjecutarConsultaDataTable()
        Else
            dataTB = New DataTable
        End If
        Me.Desconectar()
        Return dataTB
    End Function

    ''' <summary>
    ''' Retorna las solicitudes a cargo del usuario actual dependenciendo de su estado de RECIBIDO
    ''' Se usó en el Formulario de RECIBIR  
    ''' </summary>
    ''' <param name="RECIBIDO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByAbog(ByVal RECIBIDO As String) As DataTable
        Me.Num_PSol = Num_PSol

        Me.Conectar()

        querystring = "SELECT * FROM VPSOLICITUDESHREV WHERE Recibido=:Recibido and Id_Abog_Enc=:Id_Abog_Enc "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
        Me.AsignarParametroCadena(":Recibido", RECIBIDO)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb
    End Function

    ''' <summary>
    ''' Retorna la solicitud con todos los campos para enviarla por correo
    ''' </summary>
    ''' <param name="Id_Hrev"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetHrevNot(ByVal Cod_Sol As String, ByVal Id_Hrev As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VPSolHRevNot WHERE Id_Hrev=:Id_Hrev And Cod_Sol=:Cod_Sol  "
        Me.CrearComando(querystring)

        Me.AsignarParametroCadena(":Id_Hrev", Id_Hrev)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    '''  Retorna las solicitudes a cargo del usuario actual dependenciendo de su estado de RECIBIDO, en un periodio de fecha
    ''' </summary>
    ''' <param name="RECIBIDO">SI (S) o (NO)</param>
    ''' <param name="Desde">Fecha Inicial del Periodo</param>
    ''' <param name="Hasta">Fecha Final del Periodo</param>
    ''' <param name="Cod_Sol">Es opcional, para buscar una solicitud,se puede emplear % para aplicar el LIke</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
  
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByAbogxFec(ByVal RECIBIDO As String, ByVal Desde As Date, ByVal Hasta As Date, Optional ByVal Cod_Sol As String = "", Optional ByVal Concepto As String = "") As DataTable

        Me.Num_PSol = Num_PSol
        Me.Conectar()
        If String.IsNullOrEmpty(Cod_Sol) Then
            querystring = "SELECT * FROM VPSOLICITUDESHREV WHERE Recibido=:Recibido and Id_Abog_Enc=:Id_Abog_Enc And FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Concepto Like :Concepto order by FECHA_RECIBIDO desc"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
            Me.AsignarParametroCadena(":Recibido", RECIBIDO)
            Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
            Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
            Me.AsignarParametroCadena(":Concepto", "%" + UCase(Concepto) + "%")
        Else
            querystring = "SELECT * FROM VPSOLICITUDESHREV WHERE Recibido=:Recibido and Id_Abog_Enc=:Id_Abog_Enc And FECHA_RECIBIDO BETWEEN TO_DATE(:F1,'dd/mm/yyyy') AND TO_DATE(:F2,'dd/mm/yyyy') And Cod_Sol Like :Cod_Sol And Concepto Like :Concepto order by FECHA_RECIBIDO desc"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Id_Abog_Enc", Me.usuario)
            Me.AsignarParametroCadena(":Recibido", RECIBIDO)
            Me.AsignarParametroCadena(":F1", Desde.ToShortDateString)
            Me.AsignarParametroCadena(":F2", Hasta.ToShortDateString)
            Me.AsignarParametroCadena(":Cod_Sol", "%" + UCase(Cod_Sol) + "%")
            Me.AsignarParametroCadena(":Concepto", "%" + UCase(Concepto) + "%")
            '
        End If


        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCPorDepNec(ByVal FechaInicial As Date, ByVal FechaFinal As Date, ByVal dep_con As String) As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Num_PSol = Num_PSol
        Me.Conectar()
        'querystring '= "SELECT   dependencia, COUNT (*) cantidad,  SUM (valor_adicion (numero) + val_apo_gob) valor FROM vcontratosc2 WHERE vig_con = 2010 and ESTADO<>'Anulado' and dep_con='" + dep_con + "' and fec_sus_con between to_date('" + FechaInicial.ToShortDateString + "','dd/mm/yyyy') and to_date('" + FechaFinal.ToShortDateString + "','dd/mm/yyyy')  GROUP BY dependencia Order by dependencia desc "
        querystring = "SELECT   nom_tproc, COUNT (*) cantidad, SUM (valor_adicion (numero) + val_apo_gob) valor FROM vcontratosc2 WHERE vig_con = 2010 and ESTADO<>'Anulado' and dep_con='" + dep_con + "' and fec_sus_con between to_date('" + FechaInicial.ToShortDateString + "','dd/mm/yyyy') and to_date('" + FechaFinal.ToShortDateString + "','dd/mm/yyyy')  GROUP BY nom_tproc Order by nom_tproc desc"

        Me.CrearComando(queryString)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb

    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetLikeNProc(ByVal Num_PCoN As String) As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Num_PSol = Num_PCoN
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VPCONTRATOS where Pro_Sel_Nro Like :NUm_Pcon"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":NUm_Pcon", "%" + Num_PCon + "%")
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    
    ''' <summary>
    ''' Get Procesos Asignados a Terceros
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxTerceros(ByVal Ide_Ter As String, ByVal Filtro As String) As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()

        If Not String.IsNullOrEmpty(Filtro) Then
            querystring = "SELECT * From vPContratos Where UsuEncargado=:UsuEncargado And " + Filtro + " Order by fec_reg "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":UsuEncargado", Ide_Ter)
            'Throw New Exception(querystring)
        Else
            querystring = "SELECT * From vPContratos Where UsuEncargado=:UsuEncargado  Order by fec_reg "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":UsuEncargado", Ide_Ter)
        End If
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    ''' <summary>
    ''' Get Procesos Asignados a Usuario Actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxUsuario(ByVal Filtro As String) As DataTable
        Return GetxTerceros(Me.usuario, Filtro)
    End Function

    ''' <summary>
    ''' GetvHUsuEncargados-Historial de Usuarios Encargados
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetvHUsuEncargados(ByVal Cod_Sol As String) As DataTable

        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vhusuenc_psol Where Num_PSol=:Cod_Sol Order by fec_reg desc "
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA MODIFICACION: 17 FEB 2011
    ''' MODIFICACION:
    ''' SE ELIMINO EL PARAMETRO FECHA RECIBIDO DE LA FUNCION INSERT
    ''' SE CREO LA FUNCION INSERTHREV Y SE AGREGO A LA FUNCION INSERT ORIGINAL
    ''' </summary>
    ''' <param name="DEP_SOL"></param>
    ''' <param name="DEP_PSOL"></param>
    ''' <param name="VIG_SOL"></param>
    ''' <param name="TIP_CON"></param>
    ''' <param name="STIP_CON"></param>
    ''' <param name="COD_TPRO"></param>
    ''' <param name="OBJ_SOL"></param>
    ''' <param name="FECHA_RECIBIDO"></param>
    ''' <param name="NUM_PLA"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal DEP_SOL As String, ByVal DEP_PSOL As String, _
                           ByVal VIG_SOL As String, _
                           ByVal TIP_CON As String, ByVal STIP_CON As String, _
                           ByVal COD_TPRO As String, ByVal OBJ_SOL As String, _
                           ByVal FECHA_RECIBIDO As Date, ByVal NUM_PLA As String, ByVal PPTO As Decimal) As String

        Me.Conectar()

        Try
            Me.ComenzarTransaccion()
            Me.CrearNumSol(DEP_PSOL, VIG_SOL)
            querystring = "Insert Into PSOLICITUDES (COD_SOL, DEP_SOL, DEP_PSOL, VIG_SOL, TIP_CON, STIP_CON, COD_TPRO, OBJ_SOL, NUM_PLA,FEC_RECIBIDO, VAL_CON) Values(:Cod_Sol, :DEP_SOL, :DEP_PSOL,  :VIG_SOL,  :TIP_CON, :STIP_CON, :COD_TPRO, :OBJ_SOL, :NUM_PLA,TO_DATE(:FEC_RECIBIDO,'dd/mm/yyyy'), :VAL_CON)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
            Me.AsignarParametroCadena(":OBJ_SOL", OBJ_SOL)
            Me.AsignarParametroCadena(":FEC_RECIBIDO", FECHA_RECIBIDO.ToShortDateString)
            Me.AsignarParametroCadena(":DEP_SOL", DEP_SOL)
            Me.AsignarParametroCadena(":VIG_SOL", VIG_SOL)
            Me.AsignarParametroCadena(":TIP_CON", TIP_CON)
            Me.AsignarParametroCadena(":STIP_CON", STIP_CON)
            Me.AsignarParametroCadena(":DEP_PSOL", DEP_PSOL)
            Me.AsignarParametroCadena(":NUM_PLA", NUM_PLA)
            Me.AsignarParametroCadena(":Cod_Sol", Me.Num_PSol)
            Me.AsignarParametroDecimal(":VAL_CON", PPTO)

            'ID_ABOG_ENC
            Me.num_reg = Me.EjecutarComando()
            InsertHREV(Me.Num_PSol, FECHA_RECIBIDO)
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "] - " + Me.Num_PSol
            lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try

        Return Me.Msg

    End Function
    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ GONZALEZ
    ''' FECHA: 18 DE FEBRERO DE 2011
    ''' MODIFICACION:
    ''' SE AGREGO LA LA FUNCION InsertHREV CON SOBRECARGA, ESTA FUNCION SE DEBE LLAMAR AL CREAR LA SOLICITUD
    ''' </summary>
    ''' <param name="COD_SOL"></param>
    ''' <param name="FECHA_RECIBIDO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function InsertHREV(ByVal COD_SOL As String, ByVal FECHA_RECIBIDO As Date) As String
        
        querystring = "Insert Into HREVISADO (COD_SOL, FECHA_RECIBIDO) Values(:Cod_Sol, to_date(:FECHA_RECIBIDO, 'dd/mm/yyyy'))"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":FECHA_RECIBIDO", FECHA_RECIBIDO)
        Me.AsignarParametroCadena(":Cod_Sol", COD_SOL)

        Me.num_reg = Me.EjecutarComando()
        Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "] - " + Me.Num_PSol
        lErrorG = False
        
        Return Me.Msg
    End Function

    Public Function InsertHREV(ByVal COD_SOL As String, ByVal FECHA_RECIBIDO As Date, ByVal OBSERVACION As String) As String
        Me.Conectar()
        Try
            querystring = "Insert Into HREVISADO (COD_SOL, FECHA_RECIBIDO, OBSERVACION_RECIBIDO,FEC_ASIGNADO) Values(:Cod_Sol, to_date(:FECHA_RECIBIDO,'dd/mm/yyyy'), :OBSERVACION,SYSDATE)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":FECHA_RECIBIDO", FECHA_RECIBIDO.ToShortDateString)
            Me.AsignarParametroCadena(":OBSERVACION", OBSERVACION)
            Me.AsignarParametroCadena(":Cod_Sol", COD_SOL)
            Me.num_reg = Me.EjecutarComando()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "] - " + Me.Num_PSol
            lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try

        Return Me.Msg
    End Function

    Private Sub CrearNumSol(ByVal cod_dep As String, ByVal vig_con As String)
        Dim dep As Dependencias = New Dependencias
        dep.Conexion = Me.Conexion
        Dim Abr As String = dep.GetAbreviatura(cod_dep)
        If Not String.IsNullOrEmpty(Abr) Then
            Me.Num_PSol = vig_con.ToString + "-" + dep.GetAbreviatura(cod_dep) + "-" + Me.GetCons(cod_dep).ToString.PadLeft(4, "0")
        Else
            Me.Num_PSol = ""
            lErrorG = True
            Msg = "La Dependencia No tiene Abrevitura Asignada, Informe al Administrador del Sistema"
            Throw New Exception(Msg)
        End If

    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCons(ByVal DEP_PSOL As String, Optional ByVal connectar As Boolean = False) As String
        Dim vig As New Vigencias
        'If connectar = True Then
        'Me.Conectar()
        'End If
        vig.Conexion = Me.Conexion
        Dim queryString As String = "SELECT (NVL(MAX(NUM_SOL),0)+1) as Num_Sol_New FROM PSOLICITUDES WHERE VIG_SOL=:VIG_SOL AND DEP_PSOL=:DEP_PSOL"
        Me.CrearComando(queryString)
        Me.AsignarParametroCadena(":VIG_SOL", vig.GetActiva_s)
        Me.AsignarParametroCadena(":DEP_PSOL", DEP_PSOL)

        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        'If connectar = True Then
        'Me.Desconectar()
        'End If

        Return CInt(dataTb.Rows(0)("Num_Sol_New"))

    End Function


    Public Function Update(ByVal COD_SOL_PK As String, ByVal DEP_SOL As String, ByVal DEP_PSOL As String, _
                           ByVal VIG_SOL As String, _
                           ByVal TIP_CON As String, ByVal STIP_CON As String, _
                           ByVal COD_TPRO As String, ByVal OBJ_SOL As String, _
                           ByVal FECHA_RECIBIDO As Date, ByVal NUM_PLA As String, ByVal PPTO As Decimal) As String
        Me.Conectar()

        Try
            Me.ComenzarTransaccion()
            querystring = "Update Psolicitudes SET VAL_CON=:VAL_CON, COD_TPRO=:COD_TPRO, OBJ_SOL=:OBJ_SOL, DEP_SOL=:DEP_SOL, TIP_CON=:TIP_CON, STIP_CON=:STIP_CON, DEP_PSOL=:DEP_PSOL, NUM_PLA=:NUM_PLA WHERE COD_SOL=:COD_SOL_PK"

            Me.CrearComando(querystring)
            Me.Num_PSol = COD_SOL_PK

            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
            Me.AsignarParametroCadena(":OBJ_SOL", OBJ_SOL)

            Me.AsignarParametroCadena(":DEP_SOL", DEP_SOL)
            Me.AsignarParametroCadena(":TIP_CON", TIP_CON)
            Me.AsignarParametroCadena(":STIP_CON", STIP_CON)
            Me.AsignarParametroCadena(":DEP_PSOL", DEP_PSOL)
            'Me.AsignarParametroCadena(":FECHA_RECIBIDO", FECHA_RECIBIDO.ToShortDateString)
            Me.AsignarParametroCadena(":NUM_PLA", NUM_PLA)
            Me.AsignarParametroCadena(":COD_SOL_PK", Me.Num_PSol)
            Me.AsignarParametroDecimal(":VAL_CON", PPTO)


            'Throw New Exception(Me._Comando.CommandText)

            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()

        End Try

        Me.Desconectar()


        Return Me.Msg

    End Function
    ''' <summary>
    ''' ASIGANCION DE USUARIOS ENCARGADOS (ABOGADOS A PROCESOS DE CONTRATACION)
    ''' </summary>
    ''' <param name="COD_SOL_PK"></param>
    ''' <param name="ID_ABOG_ENC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Asignar_Usuario_Encargado(ByVal COD_SOL_PK As String, ByVal ID_ABOG_ENC As String) As String
        'Me.Desconectar()

        'Me.Conectar()
        Me.Conectar()

        If ID_ABOG_ENC.Trim.Length = 0 Then
            Me.Msg = "El funcionario no puede esta vacio"
            Me.lErrorG = True
            Return Msg
        End If
        'BDSProvider.BDSProvider._Conexion.Open()
        Try
            Me.ComenzarTransaccion()
            querystring = "Update PSOLICITUDES SET ID_ABOG_ENC=:ID_ABOG_ENC WHERE COD_SOL=:COD_SOL_PK"
            Me.CrearComando(querystring)
            Me.Num_PSol = COD_SOL_PK
            Me.AsignarParametroCadena(":ID_ABOG_ENC", ID_ABOG_ENC)
            Me.AsignarParametroCadena(":COD_SOL_PK", COD_SOL_PK)
            Me.num_reg = Me.EjecutarComando()

            'Nuevo Insertado en 2013, Boris Gonzalez para prueba 'no aplico porque el modelo de datos
            'querystring = "SELECT FECHA_RECIBIDO FROM HREVISADO WHERE COD_SOL=:COD_SOL_PK AND ID_HREV=(SELECT MAX(ID_HREV) from Hrevisado where COD_SOL=:COD_SOL_PK)"
            'Me.CrearComando(querystring)
            'Me.AsignarParametroCadena(":COD_SOL_PK", COD_SOL_PK)
            'Me.AsignarParametroCadena(":COD_SOL_PK", COD_SOL_PK)
            'Dim dataTb As DataTable = EjecutarConsultaDataTable()
            'Me.num_reg = Me.EjecutarComando()
            'InsertHREV(COD_SOL_PK, dataTb.Rows(0)("FECHA_RECIBIDO"))
            'Fin de Insercion, se modifico el Triggers
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True

        End Try

        Me.Desconectar()


        Return Me.Msg

    End Function


    Private Function Asignar_Usuario_EncargadoP(ByVal COD_SOL_PK As String, ByVal ID_ABOG_ENC As String) As String

        querystring = "Update PSOLICITUDES SET ID_ABOG_ENC=:ID_ABOG_ENC WHERE COD_SOL=:COD_SOL_PK"
        Me.CrearComando(querystring)
        Me.Num_PSol = COD_SOL_PK
        Me.AsignarParametroCadena(":ID_ABOG_ENC", ID_ABOG_ENC)
        Me.AsignarParametroCadena(":COD_SOL_PK", COD_SOL_PK)
        Me.num_reg = Me.EjecutarComando()
        Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
        Return Me.Msg

    End Function

    ''' <summary>
    ''' RESPONSABLE: ERIC MARTINEZ
    ''' FECHA: 18 FEB 2011
    ''' MODIFICACION:
    ''' SE MODIFICO LA CONSULTA SQL PARA QUE GUARDE EN LA TABLA HREVISADO
    ''' SE AGREGO EL PARAMETRO COD_SOL_PK1
    ''' </summary>
    ''' <param name="COD_SOL_PK"></param>
    ''' <param name="Fecha_Revision"></param>
    ''' <param name="obs"></param>
    ''' <param name="concepto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Revision(ByVal COD_SOL_PK As String, ByVal Fecha_Revision As String, ByVal obs As String, ByVal concepto As String, ByVal id_Hrev As String) As String
        Dim proc As New PContratos
        Dim dt As DataTable
        dt = GetByPk(COD_SOL_PK)
        Dim is_commit As Boolean = False
        Try
            Me.Conectar()
            proc.Conexion = Me.Conexion
            Me.ComenzarTransaccion()
            'querystring = "Update HREVISADO SET Fecha_Revisado=to_date(:Fecha_Revision,'dd/mm/yyyy'), Obs_Revisado=Obs_Revisado||' '||:obs, Concepto_Revisado=:concepto, Recibido_Abog='S' WHERE (COD_SOL=:COD_SOL_PK AND ID_HREV=(SELECT MAX(ID_HREV) from Hrevisado where COD_SOL=:COD_SOL_PK1))"
            querystring = "Update HREVISADO SET Fecha_Revisado=sysdate,Obs_Revisado=:OBS, HObs_Revisado='Usuario:'||Nit_Abog_Recibe||' - ' ||to_char(sysdate,'dd/mm/yyyy HH24:MI:SS')||' '||:OBS||'<br><hr>'||HObs_Revisado, Concepto_Revisado=:CONCEPTO, Recibido_Abog='S' WHERE COD_SOL=:COD_SOL_PK AND ID_HREV=:ID_HREV"

            Me.CrearComando(querystring)
            Me.Num_PSol = COD_SOL_PK

            'Me.AsignarParametroCadena(":Fecha_Revision", Fecha_Revision)
            Me.AsignarParametroCadena(":OBS", obs)
            Me.AsignarParametroCadena(":OBS", obs)
            Me.AsignarParametroCadena(":CONCEPTO", concepto)
            Me.AsignarParametroCadena(":COD_SOL_PK", COD_SOL_PK)
            Me.AsignarParametroCadena(":ID_HREV", id_Hrev)

            Me.num_reg = Me.EjecutarComando()
            Dim msgNot As String = ""
            If concepto = "A" Then
                proc.InsertP(dt.Rows(0).Item("Cod_Tpro").ToString, dt.Rows(0).Item("Obj_Sol").ToString, dt.Rows(0).Item("Dep_sol").ToString, dt.Rows(0).Item("Dep_Psol").ToString, dt.Rows(0).Item("Vig_sol").ToString, dt.Rows(0).Item("Tip_Con").ToString, dt.Rows(0).Item("Stip_Con").ToString, CDate(dt.Rows(0).Item("Fecha_Recibido").ToString), COD_SOL_PK, dt.Rows(0).Item("Val_Con").ToString)
                proc.Asignar_Usuario_EncargadoP(proc.Num_PCon, dt.Rows(0).Item("Id_Abog_Enc").ToString)
                Num_Proc = proc.Num_PCon
            End If

            Me.ConfirmarTransaccion()
            Me.Msg = " " + Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "] " + msgNot
            Me.lErrorG = False

            is_commit = True
            If concepto = "R" Then
                Dim nr As New NotificacionesEmail
                msgNot = nr.Notificar_RevisionSol(COD_SOL_PK, id_Hrev)
                msgNot = "<BR/>Resultado Envio de Notificación :" + msgNot
                Me.Msg = Me.Msg + msgNot
            End If

            
        Catch ex As Exception
            Me.Msg += "Error:" + ex.Message '+ ex.StackTrace
            If Not is_commit Then
                Me.CancelarTransaccion()
            End If
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try

        

        Return Me.Msg

    End Function

    Public Function Enviar_Notificacion(ByVal De As String, ByVal Para As String, ByVal Asunto As String, ByVal Body_Mensaje As String, ByVal Adjuntos() As String) As String
        Dim csmtp As New Conf_Smtp
        csmtp.CargarConf(de)
        MailSend.Port = csmtp.Puerto
        MailSend.Host = csmtp.Host
        MailSend.EnableSsl = csmtp.EnableSSL
        MailSend.TimeOut = csmtp.TimeOut
        MailSend.UserName = De
        Return MailSend.MailEnviar(Para, Asunto, Body_Mensaje, Adjuntos)
    End Function

    Public Function Recibir(ByVal COD_SOL_PK As String, ByVal Observacion As String) As String

        If Observacion.Trim.Length = 0 Then
            Me.Msg = "La observacion no puede estar vacia"
            Me.lErrorG = True
            Return Msg
        End If

        Try
            Me.Conectar()
            Me.ComenzarTransaccion()
            querystring = "Update HREVISADO SET Fec_Rec_Abog=sysdate, Obs_Recibido_Abog=:Observacion, Recibido_Abog='S', Nit_Abog_Recibe=:ID_ABOG WHERE (COD_SOL=:COD_SOL_PK AND ID_HREV=(SELECT MAX(ID_HREV) from Hrevisado where COD_SOL=:COD_SOL_PK1))"

            Me.CrearComando(querystring)
            Me.Num_PSol = COD_SOL_PK

            'Me.AsignarParametroCadena(":Fecha_Revision", Today.ToShortDateString)
            Me.AsignarParametroCadena(":Observacion", Observacion)
            Me.AsignarParametroCadena(":COD_SOL_PK", COD_SOL_PK)
            Me.AsignarParametroCadena(":COD_SOL_PK1", COD_SOL_PK)
            Me.AsignarParametroCadena(":ID_ABOG", Me.usuario)

            'Throw New Exception(_Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()

            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message '+ ex.StackTrace.ToString
            Me.CancelarTransaccion()
            Me.lErrorG = True
        End Try
        Me.Desconectar()
        Return Me.Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetxFiltro(ByVal filAsig As Boolean, ByVal Asignacion As String, ByVal filEstado As Boolean, ByVal Estado As String, ByVal filConcepto As Boolean, ByVal Concepto As String, Optional ByVal connect As Boolean = True) As DataTable
        Me.Num_PSol = Num_PSol
        If connect Then
            Me.Conectar()
        End If
        If Not filAsig And Not filConcepto And Not filEstado Then

        ElseIf Not filAsig And Not filConcepto And filEstado Then
            If Estado = "RECIBIDO" Then
                querystring = "SELECT * FROM PSOLICITUDES WHERE RECIBIDO IS NOT NULL"
                Me.CrearComando(querystring)
            Else
                querystring = "SELECT * FROM PSOLICITUDES WHERE ID_ABOG_ENC IS NULL"
                Me.CrearComando(querystring)
            End If
        ElseIf Not filAsig And filConcepto And Not filEstado Then
            querystring = "SELECT * FROM PSOLICITUDES WHERE CONCEPTO=:Concepto"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Concepto", Concepto)
        ElseIf Not filAsig And filConcepto And filEstado Then
            If Estado = "RECIBIDO" Then
                querystring = "SELECT * FROM PSOLICITUDES WHERE RECIBIDO IS NOT NULL and CONCEPTO=:Concepto"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Concepto", Concepto)
            Else
                querystring = "SELECT * FROM PSOLICITUDES WHERE RECIBIDO IS NULL AND CONCEPTO=:Concepto"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":Concepto", Concepto)
            End If
        ElseIf filAsig And Not filConcepto And Not filEstado Then
            If Asignacion = "ASIGNADO" Then
                querystring = "SELECT * FROM PSOLICITUDES WHERE ID_ABOG_ENC IS NOT NULL"
                Me.CrearComando(querystring)
            Else
                querystring = "SELECT * FROM PSOLICITUDES WHERE ID_ABOG_ENC IS NULL"
                Me.CrearComando(querystring)
            End If
        ElseIf filAsig And Not filConcepto And filEstado Then
            If Asignacion = "ASIGNADO" And Estado = "RECIBIDO" Then
                querystring = "SELECT * FROM PSOLICITUDES WHERE ID_ABOG_ENC IS NOT NULL and RECIBIDO is NOT NULL "
                Me.CrearComando(querystring)
            ElseIf Asignacion = "ASIGNADO" And Estado = "NO RECIBIDO" Then
                querystring = "SELECT * FROM PSOLICITUDES WHERE ID_ABOG_ENC IS NOT NULL and RECIBIDO is NULL "
                Me.CrearComando(querystring)
            Else
                querystring = "SELECT * FROM PSOLICITUDES WHERE ID_ABOG_ENC IS NULL"
                Me.CrearComando(querystring)
            End If
        ElseIf filAsig And filConcepto And Not filEstado Then

        Else


        End If
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        If connect Then
            Me.Desconectar()
        End If

        Return dataTb

    End Function
    Public Overloads Function ObtenerCorreos(ByVal Cod_Sol As String, Optional ByVal connect As Boolean = True) As DataTable
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        'Me.Desconectar()
        Me.Num_PSol = Num_PSol
        querystring = "SELECT * FROM EMAILDEPENDENCIASOL WHERE Solicitud=:Cod_Sol"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPkDepNec(ByVal Cod_Sol As String, Optional ByVal connect As Boolean = True) As DataTable

        Me.Num_PSol = Num_PSol

        Me.Conectar()

        querystring = "SELECT * FROM VPSolicitudes where Cod_Sol=:Cod_Sol And dep_Sol In (SELECT cod_dep FROM vDepDelTer WHERE ide_ter_abo=:ide_ter_abo )"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Sol", Cod_Sol)
        Me.AsignarParametroCadena(":ide_ter_abo", Me.usuario)
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()

        Me.Desconectar()


        Return dataTb

    End Function

    Public Function Anular(ByVal COD_SOL_PK As String, OBS_REVISADO As String) As String
        Dim ID_HREV, Concepto, Recibido As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "SELECT Concepto, Id_Hrev, Recibido FROM vPSOLICITUDES  WHERE COD_SOL=:COD_SOL_PK"
            CrearComando(querystring)
            Me.AsignarParametroCadena(":COD_SOL_PK", COD_SOL_PK)
            Dim dt As DataTable = EjecutarConsultaDataTable()
            If dt.Rows.Count > 0 Then
                ID_HREV = dt.Rows(0)("ID_HREV")
                Concepto = dt.Rows(0)("Concepto")
                Recibido = dt.Rows(0)("Recibido")
                If Concepto = "P" And Recibido = "N" Then
                    querystring = "Update hrevisado SET Concepto_Revisado='X',  OBS_REVISADO=:OBS_REVISADO,Fecha_Revisado=sysdate WHERE COD_SOL=:COD_SOL_PK And ID_HREV=:ID_HREV"
                    Me.CrearComando(querystring)
                    Me.AsignarParametroCadena(":OBS_REVISADO", OBS_REVISADO)
                    Me.AsignarParametroCadena(":COD_SOL_PK", COD_SOL_PK)
                    Me.AsignarParametroCadena(":ID_HREV", ID_HREV)
                    Me.num_reg = Me.EjecutarComando()
                    Me.ConfirmarTransaccion()
                    Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
                    Me.lErrorG = False
                Else
                    Me.Msg = "La Solicitud no se puede Anular, Ya ha sido Asignada"
                    Me.lErrorG = True
                End If
            Else
                Me.Msg = "No se encontró la Solicitud"
                Me.lErrorG = True
            End If
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        End Try
        Me.Desconectar()


        Return Me.Msg

    End Function

End Class
