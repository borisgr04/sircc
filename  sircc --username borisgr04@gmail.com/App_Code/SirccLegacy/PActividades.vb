Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
''' <summary>
''' Mod el 15 de marzo, se agrego campo dia_nohabil a insert y update, se utiliza en datos basicos->pactividades y en cronograma para filtrar el tipo de validacióp
''' Boris G.
''' </summary>
''' <remarks></remarks>
<System.ComponentModel.DataObject()> _
Public Class PActividades
    Inherits BDDatos

    Sub New()
        Me.Tabla = "PActividades"
        Me.Vista = "vPActividades"
        Me.VistaDB = "VPActividadesDB"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista
        Me.CrearComando(querystring)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    ''' <summary>
    ''' Codigo de actividades que puede tener el proceso 
    ''' </summary>
    ''' <param name="Cod_Act"></param>
    ''' <param name="Num_Proc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal Cod_Act As String, ByVal Num_Proc As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where Cod_Act =:Cod_Act And Cod_Tpro =(Select Cod_Tpro From PContratos Where Pro_Sel_Nro=:Num_Proc)"
        'querystring += " AND cod_act NOT IN (Select Cod_Act FROM vpcronogramas WHERE num_proc = :Num_Proc AND NOT (est_act = '0004')) "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Cod_Act", Cod_Act)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyTproc(ByVal Cod_Tpro As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where Cod_Tpro=:Cod_Tpro Order by Orden"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyNum_Proc(ByVal Num_Proc As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.Vista + " Where Cod_Tpro =(Select Cod_Tpro From PContratos Where Pro_Sel_Nro=:Num_Proc) And Vigencia=:Vigencia"
        'querystring += " AND cod_act NOT IN (Select Cod_Act FROM vpcronogramas WHERE num_proc = :Num_Proc AND NOT (est_act = '0004')) "
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Vigencia", Right(Num_Proc, 4))
        'Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyNum_Proc(ByVal Num_Proc As String, ByVal Oper As String) As DataTable
        Me.Conectar()
        If Oper <> "nuevo" Then
            querystring = "SELECT * FROM " + Me.Vista + " Where Cod_Tpro =(Select Cod_Tpro From PContratos Where Pro_Sel_Nro=:Num_Proc) And Vigencia=:Vigencia"
            Me.CrearComando(querystring)
        Else
            querystring = "SELECT * FROM " + Me.Vista + " Where Cod_Tpro =(Select Cod_Tpro From PContratos Where Pro_Sel_Nro=:Num_Proc) And Vigencia=:Vigencia"
            querystring += " AND cod_act NOT IN (Select Cod_Act FROM vpcronogramas WHERE num_proc = :Num_Proc AND NOT (est_act = '0004')) "
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        End If
        Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Me.AsignarParametroCadena(":Vigencia", Right(Num_Proc, 4))
        'Me.AsignarParametroCadena(":Num_Proc", Num_Proc)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    'Public Function GetbyTprocCrono(ByVal Cod_Tpro As String) As DataTable
    '    Me.Conectar()
    '    querystring = "SELECT * FROM vPestados_Crono Where Cod_Tpro=:Cod_Tpro"
    '    Me.CrearComando(querystring)
    '    Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)
    '    Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
    '    Me.Desconectar()
    '    Return dataTb
    'End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecordsFil(ByVal fil1 As Boolean, ByVal vigencia As String, ByVal fil2 As Boolean, ByVal cod_tproc As String) As DataTable
        Me.Conectar()
        If fil1 And Not fil2 Then
            querystring = "SELECT * FROM " + Me.VistaDB + " WHERE vigencia=:vigencia Order by Orden"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":vigencia", vigencia)
        ElseIf Not fil1 And fil2 Then
            querystring = "SELECT * FROM " + Me.VistaDB + " WHERE Cod_Tpro=:Cod_Tpro Order by Orden"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Tpro", cod_tproc)
        ElseIf fil1 And fil2 Then
            querystring = "SELECT * FROM " + Me.VistaDB + " WHERE vigencia=:vigencia and Cod_Tpro=:Cod_Tpro Order by Orden"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":vigencia", vigencia)
            Me.AsignarParametroCadena(":Cod_Tpro", cod_tproc)
        Else
            querystring = "SELECT * FROM " + Me.VistaDB + " Order by Orden"
            Me.CrearComando(querystring)
        End If
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Cod_Act As String, ByVal Nom_Act As String, ByVal Cod_Tpro As String, ByVal vigencia As String, ByVal Cod_Tact As String, ByVal Orden As Integer, ByVal Ocupado As String, ByVal Estado As String, ByVal Obligatorio As String, ByVal Dia_NoHabil As String, ByVal notificar As String, ByVal MFecIni As String, ByVal MHorIni As String, ByVal MFecFin As String, ByVal MHorFin As String, ByVal Ubicacion As String) As String
        Me.Conectar()
        'Me.ComenzarTransaccion()
        Try
            querystring = "INSERT INTO PACTIVIDADES(Cod_Act, Nom_Act, Cod_Tpro, vigencia, Est_Proc, Orden, Ocupado, Estado, Obligatorio,dia_nohabil,notificar,MFECINI,MHORINI,MFECFIN,MHORFIN,Ubicacion)VALUES(:Cod_Act, :Nom_Act, :Cod_Tpro, :vigencia, :Cod_Tact, :Orden, :Ocupado, :Estado, :Obligatorio,:dia_nohabil,:notificar,:MFECINI,:MHORINI,:MFECFIN,:MHORFIN, :Ubicacion)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Act", Cod_Act)
            Me.AsignarParametroCadena(":Nom_Act", Nom_Act)
            Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)
            Me.AsignarParametroCadena(":vigencia", vigencia)
            Me.AsignarParametroCadena(":Cod_Tact", Cod_Tact)
            Me.AsignarParametroCadena(":Orden", Orden)
            Me.AsignarParametroCadena(":Ocupado", Ocupado)
            Me.AsignarParametroCadena(":Estado", Estado)
            Me.AsignarParametroCadena(":Obligatorio", Obligatorio)
            Me.AsignarParametroCadena(":dia_nohabil", Dia_NoHabil)
            Me.AsignarParametroCadena(":notificar", notificar)
            ''SE MODIFICA EL 8 DE ABRIL, SE AGREGA CAMPOS DE CONFIGURACION PARA MOSTRAR LAS FECHAS
            Me.AsignarParametroCadena(":MFECINI", MFecIni)
            Me.AsignarParametroCadena(":MHORINI", MHorIni)
            Me.AsignarParametroCadena(":MFECFIN", MFecFin)
            Me.AsignarParametroCadena(":MHORFIN", MHorFin)
            Me.AsignarParametroCadena(":Ubicacion", Ubicacion)


            Me.num_reg = Me.EjecutarComando()
            '           Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            '            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPKDB(ByVal Vig_Act As String, ByVal Cod_Act As String, ByVal Cod_Tpro As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM " + Me.VistaDB + " Where Vigencia=:Vig_Act And Cod_Act=:Cod_Act and Cod_Tpro=:Cod_Tpro"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Vig_Act", Vig_Act)
        Me.AsignarParametroCadena(":Cod_Act", Cod_Act)
        Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Update(ByVal Cod_Act_PK As String, ByVal Cod_Tpro_PK As String, ByVal Cod_Act As String, ByVal Nom_Act As String, ByVal Cod_Tpro As String, ByVal vigencia As String, ByVal Cod_Tact As String, ByVal Orden As Integer, ByVal Ocupado As String, ByVal Estado As String, ByVal Obligatorio As String, ByVal dia_nohabil As String, ByVal notificar As String, ByVal MFecIni As String, ByVal MHorIni As String, ByVal MFecFin As String, ByVal MHorFin As String, ByVal Ubicacion As String) As String
        Me.Conectar()
        Try
            ' Me.ComenzarTransaccion()
            querystring = "UPDATE PACTIVIDADES SET Cod_Act=:Cod_Act, Nom_Act=:Nom_Act,Cod_Tpro=:Cod_Tpro,  Est_Proc=:Cod_Tact, Orden=:Orden, Estado=:Estado, Ocupado=:Ocupado, Obligatorio=:Obligatorio,dia_nohabil=:dia_nohabil,notificar=:notificar,MFECINI=:MFECINI,MHORINI=:MHORINI,MFECFIN=:MFECFIN,MHORFIN=:MHORFIN,Ubicacion=:Ubicacion   WHERE vigencia=:vigencia And Cod_Act=:Cod_Act_PK and Cod_Tpro=:Cod_Tpro_PK"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Act", Cod_Act)
            Me.AsignarParametroCadena(":Nom_Act", Nom_Act)
            Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)
            Me.AsignarParametroCadena(":vigencia", vigencia)
            Me.AsignarParametroCadena(":Cod_Tact", Cod_Tact)
            Me.AsignarParametroCadena(":Orden", Orden)
            Me.AsignarParametroCadena(":Ocupado", Ocupado)
            Me.AsignarParametroCadena(":Estado", Estado)
            Me.AsignarParametroCadena(":Obligatorio", Obligatorio)
            Me.AsignarParametroCadena(":Cod_Act_PK", Cod_Act_PK)
            Me.AsignarParametroCadena(":Cod_Tpro_PK", Cod_Tpro_PK)
            Me.AsignarParametroCadena(":dia_nohabil", dia_nohabil)
            Me.AsignarParametroCadena(":notificar", notificar)

            ''SE MODIFICA EL 8 DE ABRIL, SE AGREGA CAMPOS DE CONFIGURACION PARA MOSTRAR LAS FECHAS
            Me.AsignarParametroCadena(":MFECINI", MFecIni)
            Me.AsignarParametroCadena(":MHORINI", MHorIni)
            Me.AsignarParametroCadena(":MFECFIN", MFecFin)
            Me.AsignarParametroCadena(":MHORFIN", MHorFin)

            Me.AsignarParametroCadena(":Ubicacion", Ubicacion)
            'Throw New Exception(Me._Comando.CommandText)
            Me.num_reg = Me.EjecutarComando()
            'Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + " Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            'Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Delete, True)> _
    Function Delete(ByVal Cod_Act As String, ByVal Cod_Tpro As String) As String
        Me.Conectar()
        Try
            Me.ComenzarTransaccion()
            querystring = "DELETE FROM PACTIVIDADES WHERE Cod_Act=:Cod_Act and Cod_Tpro=:Cod_Tpro"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":Cod_Act", Cod_Act)
            Me.AsignarParametroCadena(":Cod_Tpro", Cod_Tpro)

            Me.num_reg = Me.EjecutarComando()
            Me.ConfirmarTransaccion()
            Me.Msg = Me.MsgOk + "Filas Afectadas [" + Me.num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.Msg = "Error:" + ex.Message
            Me.CancelarTransaccion()
            Me.lErrorG = True
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
End Class
