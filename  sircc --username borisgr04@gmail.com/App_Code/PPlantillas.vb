Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Ionic.Zip
Imports System.Collections.Generic
Imports System.Security.Permissions

<DataObjectAttribute()> _
Public Class PPlantillas
    Inherits BDDatos

    Public doc_act As String
    Private ruta_zip As String

    Private Const CONTENT_PDF As String = "application/pdf" ' PDF
    Private Const CONTENT_ZIP As String = "application/x-zip-compressed" ' ZIP
    Private Const CONTENT_DOC As String = "application/msword" ' DOC
    Private Const Ext_Doc As String = "doc" ' DOC

    Public Sub New()
        'Me.ruta_zip = ConfigurationManager.AppSettings("RUTA_DOC")

        Me.Vista = "VPPLANTILLAS"
        Me.VistaDB = "VPPLANTILLASDB"

    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal busc As String) As DataTable
        busc = IIf(busc <> "", "%" + UCase(busc) + "%", "")
        Dim queryString As String = "SELECT * FROM  vpplantillasdb  Where (Upper(tipo_plantilla) like :busc) OR (upper(NOM_PLA) like :busc) OR (upper(Clase) like :busc) OR (upper(IdE_pLA) like :busc) Order by IdE_pLA"
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
    
    Public Function Insert(ByVal TIP_PLA As String, ByVal Nom_Pla As String, ByVal dContent As [Byte](), ByVal Ext_Pla As String, ByVal Cod_TPro As String, ByVal Est_Pla As String, ByVal CLAVE As String) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            If UCase(Ext_Pla) = UCase(Ext_Doc) Then
                querystring = "INSERT INTO PPLANTILLAS (PLANTILLA,TIP_PLA, NOM_PLA,  EXT, EST_PLA, COD_STIP,CLAVE) VALUES ( :PLANTILLA,:TIP_PLA, :NOM_PLA, :EXT, :EST_PLA, :COD_TPROC,:CLAVE) "
                CrearComando(querystring)
                AsignarParametroBLOB(":PLANTILLA", dContent)
                AsignarParametroCad(":TIP_PLA", TIP_PLA)
                AsignarParametroCad(":NOM_PLA", Nom_Pla)
                AsignarParametroCad(":EXT", Ext_Pla)
                AsignarParametroCad(":EST_PLA", Est_Pla)
                AsignarParametroCad(":COD_TPRO", Cod_TPro)
                AsignarParametroCad(":CLAVE", CLAVE)
                num_reg = EjecutarComando()
                'Throw New Exception(Me._Comando.CommandText)
                ConfirmarTransaccion()
                Msg = MsgOk + "<br><b>Tamaño del Archivo:</b> " & FormatNumber(dContent.Length / 1024).ToString & " kb - "
                Me.lErrorG = False
            Else
                Msg = "Sólo se permiten Archivos <b>(*.DOC) </b>" + Ext_Pla
                Me.lErrorG = True
            End If
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function

    Public Function Delete(ByVal Ide_pla As String) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "DELETE FROM PPLANTILLAS WHERE Ide_pla=:Ide_pla"
            CrearComando(querystring)
            AsignarParametroCad(":Ide_pla", Ide_pla)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = MsgOk + "Registro Eliminados " + num_reg.ToString
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function

    Public Function Update(ByVal Ide_pla As String, ByVal dContent As [Byte]()) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE PPLANTILLAS SET PLANTILLA=:PLANTILLA WHERE Ide_pla=:Ide_pla"
            CrearComando(querystring)
            AsignarParametroBLOB(":PLANTILLA", dContent)
            AsignarParametroCad(":Ide_pla", Ide_pla)
            num_reg = EjecutarComando()
            'Throw New Exception(Me._Comando.CommandText)
            ConfirmarTransaccion()
            Msg = MsgOk + "Tamaño del Archivo: " & FormatNumber(dContent.Length / 1024).ToString & " kb - "
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function
    Public Function Inhabilitar(ByVal Ide_pla As String) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE PPLANTILLAS SET Est_Pla='IN' WHERE Ide_pla=:Ide_pla"
            CrearComando(querystring)
            AsignarParametroCad(":Ide_pla", Ide_pla)
            num_reg = EjecutarComando()
            'Throw New Exception(Me._Comando.CommandText)
            ConfirmarTransaccion()
            Msg = MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function
    Public Function Insert1(ByVal TIP_PLA As String, ByVal Nom_Pla As String, ByVal Cod_TPro As String, ByVal Est_Pla As String, ByVal CLAVE As String, ByVal EDITABLE As String) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "INSERT INTO PPLANTILLAS (TIP_PLA, NOM_PLA,  EXT, EST_PLA, COD_STIP, CLAVE, EDITABLE) VALUES (:TIP_PLA, :NOM_PLA, :EXT, :EST_PLA, :COD_TPROC,:CLAVE,:EDITABLE) "
            CrearComando(querystring)
            AsignarParametroCad(":TIP_PLA", TIP_PLA)
            AsignarParametroCad(":NOM_PLA", Nom_Pla)
            AsignarParametroCad(":EXT", "doc")
            AsignarParametroCad(":EST_PLA", Est_Pla)
            AsignarParametroCad(":COD_TPRO", Cod_TPro)
            AsignarParametroCad(":CLAVE", CLAVE)
            AsignarParametroCad(":EDITABLE", EDITABLE)
            'Throw New Exception(Me.vComando.CommandText)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function
    Public Function UpdateCampos(ByVal TIP_PLA As String, ByVal Nom_Pla As String, ByVal Cod_TPro As String, ByVal Est_Pla As String, ByVal CLAVE As String, ByVal EDITABLE As String, ByVal Ide_pla As String) As String
        Dim tbCon As New DataTable
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE PPLANTILLAS SET TIP_PLA=:TIP_PLA, NOM_PLA=:NOM_PLA,  EXT=:EXT, EST_PLA=:EST_PLA, COD_STIP=:COD_TPRO, CLAVE=:CLAVE, EDITABLE=:EDITABLE WHERE Ide_pla=:Ide_pla"
            CrearComando(querystring)
            AsignarParametroCad(":TIP_PLA", TIP_PLA)
            AsignarParametroCad(":NOM_PLA", Nom_Pla)
            AsignarParametroCad(":EXT", "doc")
            AsignarParametroCad(":EST_PLA", Est_Pla)
            AsignarParametroCad(":COD_TPRO", Cod_TPro)
            AsignarParametroCad(":CLAVE", CLAVE)
            AsignarParametroCad(":EDITABLE", EDITABLE)
            AsignarParametroCad(":Ide_pla", Ide_pla)
            'Throw New Exception(Me.vComando.CommandText)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function
    Public Function Insert(ByVal TIP_PLA As String, ByVal Nom_Pla As String, ByVal fup As FileUpload, ByVal Ext_Pla As String, ByVal Cod_TPro As String, ByVal Est_Pla As String, ByVal Clave As String) As String
        Dim tbCon As New DataTable
        Me.lErrorG = True
        If Not fup.HasFile Then
            lErrorG = True
            Return "Error no seleccionó ningún documento"
        End If
        Try
            Dim success As Boolean = False
            Dim dStream As Stream = fup.PostedFile.InputStream
            Dim dLength As Integer = fup.PostedFile.ContentLength
            Dim dContentType As String = fup.PostedFile.ContentType
            Dim dFileName As String = fup.PostedFile.FileName
            Dim Ext As String = Extraer(dFileName, ".")
            If (dContentType = CONTENT_DOC) And Ext = Ext_Doc Then
                'Cargar Imagen
                Dim dContent As [Byte]() = New Byte(dLength - 1) {}
                Dim intStatus As Integer
                intStatus = dStream.Read(dContent, 0, dLength)
                Insert(TIP_PLA, Nom_Pla, dContent, Ext_Pla, Cod_TPro, Est_Pla, Clave)
                If lErrorG = True Then
                    Throw New Exception(Msg)
                Else
                    Me.lErrorG = False
                End If
                Msg += String.Format("<br/> <b>Extensión:</b> {0} <b>Tipo de Contenido:</b> {1}", Ext_Doc, dContentType)
            Else
                Msg = String.Format("Sólo se permiten Archivos <b>(*.DOC) </b><br/> Extensión {0} <br/>Contenido {1}", UCase(Ext_Doc), dContentType)
                Me.lErrorG = True
            End If
        Catch ex As Exception
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg

    End Function

    Public Function Update(ByVal Ide_Pla As String, ByVal TIP_PLA As String, ByVal Nom_Pla As String, ByVal fup As FileUpload, ByVal Ext_Pla As String, ByVal Cod_TPro As String, ByVal Est_Pla As String) As String
        Dim tbCon As New DataTable
        Me.lErrorG = True
        Conectar()

        Try
            ComenzarTransaccion()
            'Solo Actualizacion de Datos
            If Not fup.HasFile Then
                querystring = "UPDATE PPLANTILLAS SET  TIP_PLA=:TIP_PLA, NOM_PLA=:NOM_PLA,  EXT=:EXT, EST_PLA=:EST_PLA, COD_STIP=:COD_TPRO WHERE IDE_PLA=:IDE_PLA"
                CrearComando(querystring)
                AsignarParametroCad(":TIP_PLA", TIP_PLA)
                AsignarParametroCad(":NOM_PLA", Nom_Pla)
                AsignarParametroCad(":EXT", "doc")
                AsignarParametroCad(":EST_PLA", Est_Pla)
                AsignarParametroCad(":COD_TPRO", Cod_TPro)
                AsignarParametroCad(":IDE_PLA", Ide_Pla)
                num_reg = EjecutarComando()
                Msg = MsgOk + " - " + num_reg.ToString + " No se actualizó la Plantilla"
                Me.lErrorG = False
                ConfirmarTransaccion()
                Return Msg
            Else
                Dim success As Boolean = False
                Dim dStream As Stream = fup.PostedFile.InputStream
                Dim dLength As Integer = fup.PostedFile.ContentLength
                Dim dContentType As String = fup.PostedFile.ContentType
                Dim dFileName As String = fup.PostedFile.FileName
                Dim Ext As String = Extraer(dFileName, ".")
                If (dContentType = CONTENT_DOC) And Ext = Ext_Doc Then
                    'Cargar Imagen
                    Dim dContent As [Byte]() = New Byte(dLength - 1) {}
                    Dim intStatus As Integer
                    intStatus = dStream.Read(dContent, 0, dLength)
                    querystring = "UPDATE PPLANTILLAS SET PLANTILLA=:PLANTILLA, TIP_PLA=:TIP_PLA, NOM_PLA=:NOM_PLA,  EXT=:EXT, EST_PLA=:EST_PLA, COD_STIP=:COD_TPRO WHERE IDE_PLA=:IDE_PLA"
                    CrearComando(querystring)
                    AsignarParametroBLOB(":PLANTILLA", dContent)
                    AsignarParametroCad(":TIP_PLA", TIP_PLA)
                    AsignarParametroCad(":NOM_PLA", Nom_Pla)
                    AsignarParametroCad(":EXT", "doc")
                    AsignarParametroCad(":EST_PLA", Est_Pla)
                    AsignarParametroCad(":COD_TPRO", Cod_TPro)
                    AsignarParametroCad(":IDE_PLA", Ide_Pla)

                    num_reg = EjecutarComando()

                    Msg += String.Format("<br/> <b>Extensión:</b> {0} <b>Tipo de Contenido:</b> {1}", Ext_Doc, dContentType)
                Else
                    Msg = "Sólo se permiten Archivos <b>(*.DOC) </b>"
                End If
                ConfirmarTransaccion()
                lErrorG = False
            End If
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        Finally
            Desconectar()
        End Try
        Return Msg

    End Function

    Public Function Insert2(ByVal TIP_PLA As String, ByVal Nom_Pla As String, ByVal fup As FileUpload, ByVal Ext_Pla As String, ByVal Cod_TPro As String, ByVal Est_Pla As String, ByVal Clave As String) As String

        Dim tbCon As New DataTable
        Me.lErrorG = True
        If Not fup.HasFile Then
            lErrorG = True
            Return "Error no seleccionó ningún documento"
        End If
        Conectar()
        ComenzarTransaccion()
        Try
            Dim success As Boolean = False
            Dim dStream As Stream = fup.PostedFile.InputStream
            Dim dLength As Integer = fup.PostedFile.ContentLength
            Dim dContentType As String = fup.PostedFile.ContentType
            Dim dFileName As String = fup.PostedFile.FileName
            Dim Ext As String = Extraer(dFileName, ".")
            If (dContentType = CONTENT_DOC) And Ext = Ext_Doc Then
                'Cargar Imagen
                Dim dContent As [Byte]() = New Byte(dLength - 1) {}
                Dim intStatus As Integer
                intStatus = dStream.Read(dContent, 0, dLength)
                querystring = "INSERT INTO PPLANTILLAS (PLANTILLA,TIP_PLA, NOM_PLA,  EXT, EST_PLA, COD_TPROC,CLAVE) VALUES (:PLANTILLA,:TIP_PLA, :NOM_PLA,  :EXT, :EST_PLA, :COD_TPROC,:CLAVE) "
                CrearComando(querystring)
                AsignarParametroBLOB("PLANTILLA", dContent)
                AsignarParametroCad(":TIP_PLA", TIP_PLA)
                AsignarParametroCad(":NOM_PLA", Nom_Pla)
                AsignarParametroCad(":EXT", Ext)
                AsignarParametroCad(":EST_PLA", Est_Pla)
                AsignarParametroCad(":COD_TPRO", Cod_TPro)
                AsignarParametroCad(":CLAVE", Clave)
                num_reg = EjecutarComando()
                ConfirmarTransaccion()
                Msg = MsgOk + "<br><b>Tamaño del Archivo:</b> " & FormatNumber(dLength / (1024)).ToString & " kb - <b>Tipo del Archivo: </b>" + dContentType
                Me.lErrorG = False
            Else
                Msg = "Sólo se permiten Archivos <b>(*.DOC) </b>"
                Me.lErrorG = True
            End If
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function
    Public Function InsertAPP(ByVal TIP_PLA As String, ByVal Nom_Pla As String, ByVal ruta As String, ByVal Cod_TPro As String, ByVal Est_Pla As String, ByVal Clave As String) As String

        Dim tbCon As New DataTable
        Me.lErrorG = True
        If ruta = "" Then
            lErrorG = True
            Return "Error no seleccionó ningún documento"
        End If
        Conectar()
        ComenzarTransaccion()
        Try
            Dim success As Boolean = False
            Dim fls As FileStream
            fls = New FileStream(ruta, FileMode.Open, FileAccess.Read)
            Dim blob(0 To fls.Length - 1) As Byte
            fls.Read(blob, 0, System.Convert.ToInt32(fls.Length))
            fls.Close()
            Dim Ext As String = Extraer(ruta, ".")
            'Cargar Imagen
            'Dim dContent As [Byte]() = New Byte(dLength - 1) {}
            'Dim intStatus As Integer
            'intStatus = dStream.Read(dContent, 0, dLength)
            querystring = "INSERT INTO PPLANTILLAS (PLANTILLA,TIP_PLA, NOM_PLA,  EXT, EST_PLA, COD_STIP,CLAVE) VALUES (:PLANTILLA,:TIP_PLA, :NOM_PLA,  :EXT, :EST_PLA, :COD_TPROC,:CLAVE) "
            CrearComando(querystring)
            AsignarParametroBLOB("PLANTILLA", blob)
            AsignarParametroCad(":TIP_PLA", TIP_PLA)
            AsignarParametroCad(":NOM_PLA", Nom_Pla)
            AsignarParametroCad(":EXT", Ext)
            AsignarParametroCad(":EST_PLA", Est_Pla)
            AsignarParametroCad(":COD_TPRO", Cod_TPro)
            AsignarParametroCad(":CLAVE", Clave)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Msg = (blob.Length / (1024)).ToString
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function
    ''' <summary>
    ''' Consulta de Plantillas Por Tipos de Procesos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPlantillas() As DataTable
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT * FROM VPPLANTILLASC"
        CrearComando(querystring)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return datat
    End Function

    ''' <summary>
    ''' Consulta de Plantillas Por Tipos de Procesos
    ''' </summary>
    ''' <param name="Num_Proc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetbyNumProc(ByVal Num_Proc As String, ByVal Grupo As String) As DataTable
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT * FROM VPPLANTILLAS WHERE COD_STIP=(Select Stip_Con From GProcesos Where Pro_Sel_Nro=:Pro_Sel_Nro And Grupo=:Grupo)"
        CrearComando(querystring)
        AsignarParametroCadena(":Pro_Sel_Nro", Num_Proc)
        AsignarParametroCadena(":Grupo", Grupo)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return datat
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPlantillasDoc() As DataTable
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT * FROM VPPLANTILLAS WHERE Tip_Pla<>'01'"
        CrearComando(querystring)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return datat
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetbyNumProc(ByVal Num_Proc As String) As DataTable
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT * FROM VPPLANTILLAS WHERE COD_STIP=(Select Stip_Con From pcontratos Where Pro_Sel_Nro=:Pro_Sel_Nro) And Tip_Pla<>'01'"
        CrearComando(querystring)
        AsignarParametroCadena(":Pro_Sel_Nro", Num_Proc)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return datat
    End Function
    Function Extraer(ByVal Path As String, ByVal Caracter As String) As String
        Dim ret As String
        If Caracter = "." And InStr(Path, Caracter) = 0 Then
            Return ""
        End If
        ret = Right(Path, Len(Path) - InStrRev(Path, Caracter))
        Extraer = ret
    End Function
    ' \\ -- Extraer solo la ruta sin el archivo mediante la función Left e InstrRev   
    Function getPath(ByVal sPath As String, ByVal Caracter As String) As String
        Dim gp As String = ""
        If sPath <> "" And Caracter <> "" Then
            gp = Left(sPath, InStrRev(sPath, Caracter))
        End If
        Return gp
    End Function

    Public Function Generar_Zip(ByVal cod_con As String) As String
        Try
            ' Establish the database connection
            Conectar()
            ' define the sql to perform the database insert
            querystring = "select FileName,id,documento,cod_con from vDoc_Cont_Nom where cod_con  = '" + cod_con.Trim + "'"
            CrearComando(querystring)
            ' Execute the SQL Statement
            Dim dt As DataTable = EjecutarConsultaDataTable()
            Dim zip As New ZipFile(Me.ruta_zip + cod_con.Trim + ".zip")
            Dim i As Integer = 0
            For rg As Integer = 0 To dt.Rows.Count - 1
                i = i + 1
                Dim b() As Byte = DirectCast(dt.Rows(rg)("documento"), Byte())
                zip.AddEntry(dt.Rows(rg)("FileName"), b)
            Next
            zip.Comment = "Export De la base de datos"
            zip.Save()
        Catch ex As Ionic.Zip.ZipException
            Msg = "zip:" + ex.Message
        Catch ex As Exception
            Msg = "Ex:" + ex.Message
        Finally
            'Close the database connection
            Desconectar()
        End Try
        Return Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPK(ByVal ide_pla As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vPPlantillasC Where Ide_Pla=:Ide_Pla"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Ide_Pla", ide_pla)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function GetPlantillabyPK(ByVal ide_pla As String) As Byte()
        Me.Conectar()
        querystring = "SELECT Plantilla FROM vPPlantillasC Where Ide_Pla=:Ide_Pla"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Ide_Pla", ide_pla)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        Dim Plantilla As Byte() = DirectCast(dataTb.Rows(0)("Plantilla"), Byte())
            Me.Desconectar()
            Return Plantilla
    End Function
    Public Function GetPlantillabyPK(ByVal ide_pla As String, ByRef Plantilla As Byte()) As Boolean
        Me.Conectar()
        querystring = "SELECT * FROM vPPlantillasC Where Ide_Pla=:Ide_Pla"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":Ide_Pla", ide_pla)
        Dim dataTb As DataTable = Me.EjecutarConsultaDataTable()
        If IsDBNull(dataTb.Rows(0)("Plantilla")) Then
            Me.Desconectar()
            Return False
        Else
            Plantilla = DirectCast(dataTb.Rows(0)("Plantilla"), Byte())
            Me.Desconectar()
            Return True
        End If
    End Function

    Public Function GetFormatoTabla(ByVal nomTabla As String, ByVal idPlantilla As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS_FORMATO_TABLAS WHERE IDE_PLA=:IDE_PLA AND NTABLA=:NTABLA"
        CrearComando(querystring)
        AsignarParametroCadena(":IDE_PLA", idPlantilla)
        AsignarParametroCadena(":NTABLA", nomTabla)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetFormatoTabla(ByVal nomTabla As String, ByVal idPlantilla As String, ByVal NomCampo As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS_FORMATO_TABLAS WHERE IDE_PLA=:IDE_PLA AND NTABLA=:NTABLA AND NOM_CAM =:NOM_CAM"
        CrearComando(querystring)
        AsignarParametroCadena(":IDE_PLA", idPlantilla)
        AsignarParametroCadena(":NTABLA", nomTabla)
        AsignarParametroCadena(":NOM_CAM", NomCampo)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

  

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorIde(ByVal IDE_PLA As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS WHERE IDE_PLA = :IDE_PLA"
        CrearComando(querystring)
        AsignarParametroCadena(":IDE_PLA", IDE_PLA)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    
End Class
