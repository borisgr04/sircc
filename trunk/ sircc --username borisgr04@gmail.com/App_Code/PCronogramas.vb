Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.Common
''' <summary>
''' Se agrega consulta con email para la notificaciones.,GetByPKparaNot
''' Se modifica fec_aviso, y se agrega campos notificar, min_i, min_f 23 de marzo 2011 - Boris G
''' </summary>
''' <remarks></remarks>
<System.ComponentModel.DataObject()> _
Public Class PCronogramas
    Inherits BDDatos
    Dim _NActividadesOcup As Integer
    Public Property NActividadesOcup As Integer
        Set(ByVal value As Integer)
            _NActividadesOcup = value
        End Set
        Get
            Return _NActividadesOcup
        End Get
    End Property


    ''' <summary>
    ''' Consulta de Actividades del Cronograma por Numero de Proceso
    ''' </summary>
    ''' <param name="Num_ProC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Num_ProC As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPCronogramas Where NUM_PROC=:NUM_PROC"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUM_PROC", Num_ProC)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Consulta de Actividades del Cronograma por Numero de Proceso Xa Reporte
    ''' </summary>
    ''' <param name="Num_ProC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsRPT(ByVal Num_ProC As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPCronogramasRPT Where NUM_PROC=:NUM_PROC"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUM_PROC", Num_ProC)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Consulta de Actividades del Cronograma por Numero de Proceso x Usuario especifico  20 Abr 2011
    ''' </summary>
    ''' <returns>Las Actividades que no se han terminado</returns>
    ''' <remarks></remarks>
    ''' 
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAvisosHoy(ByVal Usuario As String) As DataTable
        Me.Conectar()
        'querystring = "SELECT Num_Proc 'N° Proceso',Nom_Act 'Actividad',FechaI 'Fecha Inicial', Des_HorI 'Hora Inicial', Notas,Ocupado,Nom_Est 'Estado',Cod_Act,ID FROM vPCronogramas Where usuencargado=:Usuario and IS_FINAL='NO' and fecha_aviso<=sysdate"
        querystring = "SELECT * FROM vPCronoAvisosHoy Where usuencargado=:Usuario "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Usuario", Usuario)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Consulta de Actividades del Cronograma por Numero de Proceso x Delegación 26 de Mayo de 2011
    ''' </summary>
    ''' <returns>Las Actividades que no se han terminado</returns>
    ''' <remarks></remarks>
    ''' 
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

    ''' <summary>
    ''' Consulta de Actividades del Cronograma por Numero de Proceso x Usuario Actual 20 Abril
    ''' </summary>
    ''' <returns>Las Actividades que no se han terminado</returns>
    ''' <remarks></remarks>
    ''' 
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAvisosHoy() As DataTable
        Return GetAvisosHoy(Me.usuario)
    End Function

    ''' <summary>
    ''' Consulta de Actividades del Cronograma por Numero de Proceso
    ''' </summary>
    ''' <returns>Las Actividades que no se han terminado</returns>
    ''' <remarks></remarks>
    ''' 
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAvisosAtrasados() As DataTable
        Return GetAvisosAtrasados(Me.usuario)
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAvisosAtrasados(ByVal usuario As String) As DataTable
        Me.Conectar()
        'querystring = "SELECT Num_Proc 'N° Proceso',Nom_Act 'Actividad',FechaI 'Fecha Inicial', Des_HorI 'Hora Inicial', Notas,Ocupado,Nom_Est 'Estado',Cod_Act,ID FROM vPCronogramas Where usuencargado=:Usuario and IS_FINAL='NO' and fecha_aviso<=sysdate"
        querystring = "SELECT * FROM vPCronoAvisos Where usuencargado=:Usuario "
        Me.CrearComando(querystring)
        AsignarParametroCadena(":Usuario", usuario)
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

    '

    ''' <summary>
    ''' Primer Evento
    ''' </summary>
    ''' <param name="Num_ProC"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetFechaPrimerEvento(ByVal Num_ProC As String) As Date
        Dim dt As DataTable = GetRecords(Num_ProC)
        If dt.Rows.Count > 0 Then
            Return CDate(dt.Rows(0)("FechaI"))
        Else
            Return Now
        End If
    End Function

    ''' <summary>
    ''' Primer evento por filtro
    ''' </summary>
    ''' <param name="Filtro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetFechaPrimerEventobyFiltro(ByVal Filtro As String) As Date
        Dim dt As DataTable = GetbyFiltro(Filtro)
        If dt.Rows.Count > 0 Then
            Return CDate(dt.Rows(0)("FechaI"))
        Else
            Return Now
        End If
    End Function


    Function ValidarFechaAct(ByVal Num_Proc As String, ByVal FechaI As Date) As Boolean
        Me.Conectar()
        querystring = "select FechaRecibido from pcontratos where pro_sel_nro=:NUM_PROC"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":NUM_PROC", Num_Proc)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        If dt.Rows.Count > 0 Then
            Dim fp As Date = dt.Rows(0)("FechaRecibido")
            If fp > FechaI Then
                Msg = "Las actividades del Cronograma deben ser superior a la fecha de registro del proceso " + fp.ToShortDateString
                Return False
            Else
                Return True
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' Insertar Actividad en Cronograma
    ''' </summary>
    
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal NUM_PROC As String, ByVal COD_ACT As String, ByVal NOM_ACT As String, ByVal COD_TPRO As String, ByVal FECHAI As Date, ByVal HORAI As Integer, ByVal FECHAF As Date, ByVal HORAF As Integer, ByVal UBICACION As String, ByVal NOTAS As String, ByVal DIAS_AVISO As Integer, ByVal OCUPADO As Boolean, ByVal Color As String, ByVal Obligatorio As Boolean, ByVal Est_Proc As String, ByVal FEC_AVISO As String, ByVal NOTIFICAR As String, ByVal MIN_I As String, ByVal MIN_F As String, ByVal MFecIni As String, ByVal MHorIni As String, ByVal MFecFin As String, ByVal MHorFin As String, ByVal ORDEN As Integer, ByVal lstFechas As List(Of Date)) As String

        Dim lOcupado As String = Util.invSI_NO(OCUPADO)
        Dim lOblig As String = Util.invSI_NO(Obligatorio)

        Me.Conectar()
        Me.ComenzarTransaccion()
        Try

        
            querystring = "Insert Into PCronogramas(COD_ACT ,NOM_ACT, COD_TPRO,FECHAI,HORAI ,FECHAF,HORAF ,UBICACION,NOTAS,DIAS_AVISO,OCUPADO,NUM_PROC,COLOR,OBLIGATORIO,EST_PROC,FEC_AVISO,NOTIFICAR,MIN_I,MIN_F,MFECINI,MHORINI,MFECFIN,MHORFIN,Orden)"
            querystring += "Values(:COD_ACT ,:NOM_ACT ,:COD_TPRO,to_date(:FECHAI,'dd/mm/yyyy'),:HORAI ,to_date(:FECHAF,'dd/mm/yyyy'),:HORAF ,:UBICACION,:NOTAS,:DIAS_AVISO,:OCUPADO,:NUM_PROC,:COLOR,:OBLIGATORIO,:EST_PROC,to_date(:FEC_AVISO,'dd/mm/yyyy'),:NOTIFICAR,:MIN_I,:MIN_F,:MFECINI,:MHORINI,:MFECFIN,:MHORFIN,:ORDEN)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":NUM_PROC", NUM_PROC)
            Me.AsignarParametroCadena(":COD_ACT", COD_ACT)
            Me.AsignarParametroCadena(":NOM_ACT", NOM_ACT)

            Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
            Me.AsignarParametroCadena(":FECHAI", FECHAI)
            Me.AsignarParametroEntero(":HORAI", HORAI)
            Me.AsignarParametroCadena(":FECHAF", FECHAF)
            Me.AsignarParametroEntero(":HORAF", HORAF)
            Me.AsignarParametroCadena(":NOTAS", NOTAS)
            Me.AsignarParametroEntero(":DIAS_AVISO", DIAS_AVISO)
            Me.AsignarParametroCadena(":UBICACION", UBICACION)
            Me.AsignarParametroCadena(":OCUPADO", lOcupado)
            Me.AsignarParametroCadena(":COLOR", Color)
            Me.AsignarParametroCadena(":OBLIGATORIO", lOblig)
            Me.AsignarParametroCadena(":EST_PROC", Est_Proc)

            '' SE MODIFICA PARA AGREGAR TIPO DE NOTIFICACION Y CAMBIO A FECHA DE AVISO, AGREGAR MINUTOS
            'FEC_AVISO,NOTIFICAR,MIN_I,MIN_F /23 MARZO BORIS
            Me.AsignarParametroCadena(":FEC_AVISO", FEC_AVISO)
            Me.AsignarParametroCadena(":NOTIFICAR", NOTIFICAR)
            Me.AsignarParametroCadena(":MIN_I", MIN_I)
            Me.AsignarParametroCadena(":MIN_F", MIN_F)

            ''SE MODIFICA EL 8 DE ABRIL, SE AGREGA CAMPOS DE CONFIGURACION PARA MOSTRAR LAS FECHAS
            Me.AsignarParametroCadena(":MFECINI", MFecIni)
            Me.AsignarParametroCadena(":MHORINI", MHorIni)
            Me.AsignarParametroCadena(":MFECFIN", MFecFin)
            Me.AsignarParametroCadena(":MHORFIN", MHorFin)
            Me.AsignarParametroCadena(":ORDEN", ORDEN)

            Me.num_reg = Me.EjecutarComando()
            For Each f In lstFechas
                querystring = "Insert into PCRONO_DIAS (FECHA)VALUES( to_date(:FECHA,'dd/mm/yyyy'))"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":FECHA", f)
                Me.EjecutarComando()
            Next
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "] - "
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

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal ID_O As String, ByVal COD_ACT As String, ByVal NOM_ACT As String, ByVal COD_TPRO As String, ByVal FECHAI As Date, ByVal HORAI As Integer, ByVal FECHAF As Date, ByVal HORAF As Integer, ByVal UBICACION As String, ByVal NOTAS As String, ByVal DIAS_AVISO As Integer, ByVal OCUPADO As Boolean, ByVal Color As String, ByVal Obligatorio As Boolean, ByVal Est_Proc As String, ByVal FEC_AVISO As String, ByVal NOTIFICAR As String, ByVal MIN_I As String, ByVal MIN_F As String, ByVal MFecIni As String, ByVal MHorIni As String, ByVal MFecFin As String, ByVal MHorFin As String, ByVal lstFechas As List(Of Date)) As String
        Dim lOcupado As String = Util.invSI_NO(OCUPADO)
        Dim lOblig As String = Util.invSI_NO(Obligatorio)

        Me.Conectar()
        ComenzarTransaccion()
        Try

            querystring = "Update PCronogramas Set COD_ACT=:COD_ACT ,NOM_ACT=:NOM_ACT ,COD_TPRO=:COD_TPRO,FECHAI=to_date(:FECHAI,'dd/mm/yyyy'),HORAI=:HORAI  ,FECHAF=to_date(:FECHAF,'dd/mm/yyyy'),HORAF=:HORAF ,UBICACION=:UBICACION,NOTAS=:NOTAS,DIAS_AVISO=:DIAS_AVISO,OCUPADO=:OCUPADO,OBLIGATORIO=:OBLIGATORIO,EST_PROC=:EST_PROC, COLOR=:COLOR,FEC_AVISO=to_date(:FEC_AVISO,'dd/mm/yyyy'),NOTIFICAR=:NOTIFICAR,MIN_I=:MIN_I,MIN_F=:MIN_F,MFECINI=:MFECINI,MHORINI=:MHORINI,MFECFIN=:MFECFIN,MHORFIN=:MHORFIN  "
            querystring += " WHERE ID=:ID_O"
            Me.CrearComando(querystring)

            Me.AsignarParametroCadena(":ID_O", ID_O)
            Me.AsignarParametroCadena(":COD_ACT", COD_ACT)
            Me.AsignarParametroCadena(":NOM_ACT", NOM_ACT)
            Me.AsignarParametroCadena(":COD_TPRO", COD_TPRO)
            Me.AsignarParametroCadena(":FECHAI", FECHAI)
            Me.AsignarParametroEntero(":HORAI", HORAI)
            Me.AsignarParametroCadena(":FECHAF", FECHAF)
            Me.AsignarParametroEntero(":HORAF", HORAF)
            Me.AsignarParametroCadena(":NOTAS", NOTAS)
            Me.AsignarParametroEntero(":DIAS_AVISO", DIAS_AVISO)
            Me.AsignarParametroCadena(":UBICACION", UBICACION)
            Me.AsignarParametroCadena(":OCUPADO", lOcupado)
            Me.AsignarParametroCadena(":COLOR", Color)
            Me.AsignarParametroCadena(":OBLIGATORIO", lOblig) 'OBLIGATORIO,EST_PROC=:EST_PROC
            Me.AsignarParametroCadena(":EST_PROC", Est_Proc)

            '' SE MODIFICA PARA AGREGAR TIPO DE NOTIFICACION Y CAMBIO A FECHA DE AVISO, AGREGAR MINUTOS
            'FEC_AVISO,NOTIFICAR,MIN_I,MIN_F /23 MARZO BORIS
            Me.AsignarParametroCadena(":FEC_AVISO", FEC_AVISO)
            Me.AsignarParametroCadena(":NOTIFICAR", NOTIFICAR)
            Me.AsignarParametroCadena(":MIN_I", MIN_I)
            Me.AsignarParametroCadena(":MIN_F", MIN_F)

            ''SE MODIFICA EL 8 DE ABRIL, SE AGREGA CAMPOS DE CONFIGURACION PARA MOSTRAR LAS FECHAS
            Me.AsignarParametroCadena(":MFECINI", MFecIni)
            Me.AsignarParametroCadena(":MHORINI", MHorIni)
            Me.AsignarParametroCadena(":MFECFIN", MFecFin)
            Me.AsignarParametroCadena(":MHORFIN", MHorFin)

            Me.num_reg = Me.EjecutarComando()

            querystring = "Delete From PCrono_Dias WHERE ID_CRONO=:ID_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":ID_O", ID_O)
            Me.EjecutarComando()
            For Each f In lstFechas
                querystring = "Insert into PCRONO_DIAS (FECHA)VALUES( to_date(:FECHA,'dd/mm/yyyy'))"
                Me.CrearComando(querystring)
                Me.AsignarParametroCadena(":FECHA", f)
                Me.EjecutarComando()
            Next
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "] - "
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try

        Return Me.Msg
    End Function
    ''' <summary>
    ''' Actualizar Estado de La Actividad 
    ''' </summary>
    ''' <param name="ID_O"></param>
    ''' <param name="EST_ACT"></param>
    ''' <param name="OBS_SEG"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function UpdateEst(ByVal ID_O As String, ByVal EST_ACT As String, ByVal OBS_SEG As String, ByVal Notificar As Boolean) As String
        Dim nt As New NotificacionesEmail
        Me.Conectar()
        ComenzarTransaccion()
        Try
            querystring = "Update PCronogramas Set EST_ACT=:EST_ACT, OBS_SEG=:OBS_SEG  WHERE ID=:ID_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":ID_O", ID_O)
            Me.AsignarParametroCadena(":EST_ACT", EST_ACT)
            Me.AsignarParametroCadena(":OBS_SEG", OBS_SEG)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()

            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]  "
            lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        If (Not lErrorG) AndAlso Notificar = True Then
            Msg = Msg + "<br>" + nt.Notificar_Cambio_Estado_Actividad(ID_O)
        End If
        Return Me.Msg
    End Function
    '
    ''' <summary>
    ''' Consulta de Cronograma por ID (Pk)
    ''' </summary>
    ''' <param name="ID">Identificador unico de la actividad del cronograma</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Function GetbyPk(ByVal ID As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPCronogramasDT Where ID=:ID"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ID", ID)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Function GetbyFechas(ByVal ID As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM PCRONO_DIAS Where ID_CRONO=:ID"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ID", ID)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCronograma(ByVal Finicial As Date, ByVal Ffinal As Date, ByVal Num_Proc As String) As DataTable
        Me.Conectar()
        querystring = "Select * from vpcronogramas_dias where fecha between to_date(:fi,'dd/mm/yyyy') and to_date(:ff,'dd/mm/yyyy') and Num_Proc=:Num_Proc"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":fi", Finicial.ToShortDateString)
        Me.AsignarParametroCadena(":ff", Ffinal.ToShortDateString)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Consulta de Cronograma para calendario por fechas y filtro
    ''' </summary>
    ''' <param name="Finicial"></param>
    ''' <param name="Ffinal"></param>
    ''' <param name="Filtro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCronogramabyFiltro(ByVal Finicial As Date, ByVal Ffinal As Date, ByVal Filtro As String) As DataTable
        Me.Conectar()
        querystring = "Select * from vpcronogramas_dias where fecha between to_date(:fi,'dd/mm/yyyy') and to_date(:ff,'dd/mm/yyyy') " + IIf(Filtro.Length > 0, " And " + Filtro, "")
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":fi", Finicial.ToShortDateString)
        Me.AsignarParametroCadena(":ff", Ffinal.ToShortDateString)
        'Throw New Exception(Me._Comando.CommandText)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Consulta de Actividades del Cronograma por Filtro
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetbyFiltro(ByVal Filtro As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPCronogramas  " + IIf(Filtro.Length > 0, " Where " + Filtro, "")
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    ''' <summary>
    ''' Anular Actividad
    ''' </summary>
    ''' <param name="ID_O"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Anular(ByVal ID_O As String, ByVal OBS_SEG As String) As String
        Me.Conectar()
        Try
            querystring = "Update PCronogramas Set Anulado='S', OBS_SEG=:OBS_SEG WHERE ID=:ID_O"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":ID_O", ID_O)
            Me.AsignarParametroCadena(":OBS_SEG", OBS_SEG)
            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "] - "
            lErrorG = False
        Catch ex As Exception
            Me.Msg = ex.Message
            lErrorG = True
            Me.CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try

        Return Me.Msg
    End Function

    Public Function IsValid_Marcar_Ocupados(ByVal FechaI As Date, ByVal HoraI As Integer, ByVal FechaF As Date, ByVal HoraF As Integer) As Boolean
        Conectar()
        _NActividadesOcup = 0
        querystring = "Validar_MarcarOcupado"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroFecha("iFechai", FechaI)
        AsignarParametroInt("iHorai", HoraI)
        AsignarParametroFecha("iFechaf", FechaF)
        AsignarParametroInt("iHoraf", HoraF)
        AsignarParametroCad("Usuario", Me.usuario)
        EjecutarComando()
        Desconectar()
        _NActividadesOcup = CInt(preturn.Value.ToString())
        If _NActividadesOcup > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Validacion Nueva Version 24 de marzo de 2011 Boris G
    ''' </summary>
    ''' <param name="FechaI">Fecha Inicial</param>
    ''' <param name="HoraI">Hora en Formato H24:MI</param>
    ''' <param name="FechaF">FEcha Final</param>
    ''' <param name="HoraF">Hora en Formato H24:MI</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValid_Marcar_Ocupados(ByVal FechaI As Date, ByVal HoraI As String, ByVal FechaF As Date, ByVal HoraF As String) As Boolean
        Conectar()
        _NActividadesOcup = 0
        querystring = "Validar_MarcarOcupadoC"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroFecha("iFechai", FechaI)
        AsignarParametroCad("iHorai", HoraI)
        AsignarParametroFecha("iFechaf", FechaF)
        AsignarParametroCad("iHoraf", HoraF)
        AsignarParametroCad("Usuario", Me.usuario)
        EjecutarComando()
        Desconectar()
        _NActividadesOcup = CInt(preturn.Value.ToString())
        If _NActividadesOcup > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Validacion Nueva Version 24 de marzo de 2011 Boris G, al editar una actividad
    ''' </summary>
    ''' <param name="FechaI">Fecha Inicial</param>
    ''' <param name="HoraI">Hora en Formato H24:MI</param>
    ''' <param name="FechaF">FEcha Final</param>
    ''' <param name="HoraF">Hora en Formato H24:MI</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValid_Marcar_Ocupados2(ByVal FechaI As Date, ByVal HoraI As String, ByVal FechaF As Date, ByVal HoraF As String, ByVal iID As Integer) As Boolean
        Conectar()
        _NActividadesOcup = 0
        querystring = "Validar_MarcarOcupadoC2"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroFecha("iFechai", FechaI)
        AsignarParametroCad("iHorai", HoraI)
        AsignarParametroFecha("iFechaf", FechaF)
        AsignarParametroCad("iHoraf", HoraF)
        AsignarParametroCad("Usuario", Me.usuario)
        AsignarParametroInt("iID", iID)
        EjecutarComando()
        Desconectar()
        _NActividadesOcup = CInt(preturn.Value.ToString())
        If _NActividadesOcup > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' REtorna pcontratos con email de dep_del, dep_nec y ema_enc
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByPKparaNot(ByVal ID As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VPCRONOGRAMAS02 where ID=:ID"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ID", ID)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class
