Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Ionic.Zip
Imports System.Collections.Generic
Imports System.Security.Permissions

<DataObjectAttribute()> _
Public Class DocContratos
    Inherits BDDatos

    Public doc_act As String
    Private Ruta_Zip As String = Publico.Ruta_Doc
    Private vRuta_Zip As String = Publico.vRuta_Doc

    Private Const CONTENT_PDF As String = "application/pdf" ' PDF
    Private Const CONTENT_ZIP As String = "application/x-zip-compressed" ' ZIP

    'Private oBD As BDDatos = New BDDatos

    ''' <summary>
    '''  Retorna los todos los registros de la tabla de la Base de datos, segun el filtro especificado
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetbyPk(ByVal ID As String) As DataTable
        querystring = "SELECT * FROM Doc_Contratos Where ID=:ID "
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ID", ID)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    ''' <summary>
    '''  Retorna los todos los registros de la tabla de la Base de datos, segun el filtro especificado
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDoc(ByVal ID As String) As DataTable
        querystring = "SELECT * FROM vDoc_Cont_Nom Where ID=:ID "
        Me.Conectar()
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":ID", ID)
        Dim dataSet As DataTable = Me.EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    ''' <summary>
    '''  Retorna los todos los registros de la tabla de la Base de datos, segun el filtro especificado
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDoc(ByVal ID As String, ByVal PagIni As Integer, ByVal PagFin As Integer) As Byte()
        Dim dt As DataTable = Me.GetDoc(ID)
        Dim SalPDF As Byte() = {}
        If dt.Rows.Count > 0 Then
            ' SalPDF = PdfManipulation2.ExtractPdfPage(DirectCast(dt.Rows(0)("DOCUMENTO"), Byte()), PagIni, PagFin)
        End If
        Return SalPDF
    End Function

    Public Function DocContratos(ByVal cod_con As String, ByVal TIP_DOC As String, ByVal fup As FileUpload, ByVal obs_con As String, ByVal ETAPA As String, ByVal fec_doc As Date) As String
        Dim tbCon As New DataTable
        Me.lErrorG = True
        Conectar()
        ComenzarTransaccion()
        If fup.HasFile Then
            Me.Doc = Trim(cod_con & "_" & fup.FileName.Replace(" ", "_"))
        Else
            Me.Doc = ""
            lErrorG = True
            Return "Error no seleccionó ningún documento"
        End If
        Try
            Dim success As Boolean = False
            Dim imgStream As Stream = fup.PostedFile.InputStream
            Dim imgLength As Integer = fup.PostedFile.ContentLength
            Dim imgContentType As String = fup.PostedFile.ContentType
            Dim imgFileName As String = fup.PostedFile.FileName
            Dim Ext As String = Extraer(imgFileName, ".")


            If (imgContentType = CONTENT_PDF) Or (imgContentType = CONTENT_ZIP) Then

                'Cargar Imagen
                Dim ImageContent As [Byte]() = New Byte(imgLength - 1) {}
                Dim intStatus As Integer
                intStatus = imgStream.Read(ImageContent, 0, imgLength)

                querystring = "INSERT INTO DOC_CONTRATOS (TIP_DOC, NOM_DOC, OBS_DOC, COD_CON, USUARIO,FEC_DOC, FEC_REG,ETAPA,DOCUMENTO,EXT) VALUES ('" & TIP_DOC & "', '" & Me.Doc & "', '" & obs_con & "', '" & cod_con & "', '" & Me.usuario & "',TO_DATE('" + fec_doc.ToShortDateString + "','dd/mm/yyyy'), SYSDATE,'" + ETAPA + "',:DOCUMENTO,'" + Ext + "') "
                CrearComando(querystring)

                AsignarParametroBLOB("DOCUMENTO", ImageContent)

                EjecutarComando()
                'f.InsAud(BDDatos.dbConnection, t, "CONTRATOS", "Anexo de Doc Digitalizado del Contrato-" + cod_con + "-" + TIP_DOC, Me.usuario)

                ConfirmarTransaccion()

                Msg = MsgOk + "<br><b>Tamaño del Archivo:</b> " & FormatNumber(imgLength / 1024).ToString & " kb - <b>Tipo del Archivo: </b>" + imgContentType
                Me.lErrorG = False
            Else
                msg = "Sólo se permiten Archivos <b>(*.PDF)</b> y Archivo <b>(*.ZIP)</b>"
                Me.lErrorG = True
            End If
        Catch ex As Exception
            CancelarTransaccion()
            msg = ex.Message
            Me.lErrorG = True
        Finally
            Desconectar()
        End Try


        Return msg

    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDoc_Contratos(ByVal cod_con As String) As DataTable
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT * FROM  vdoc_contratosac where cod_con=:cod_con"
        CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod_con)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return datat
    End Function
    
    Public Sub New()
        'ConfigurationManager.AppSettings("RUTA_DOC")
    End Sub

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
            'Establish the database connection
            Conectar()
            'define the sql to perform the database insert
            querystring = "select FileName,id,documento,cod_con from vDoc_Cont_Nom where cod_con  = '" + cod_con.Trim + "'"
            CrearComando(querystring)

            'Execute the SQL Statement
            Dim dt As DataTable = EjecutarConsultaDataTable()
            Dim RutaC As String = Me.Ruta_Zip + cod_con.Trim + ".zip"
            Dim vRutaC As String = vRuta_Zip + cod_con.Trim + ".zip"
            If File.Exists(RutaC) Then
                File.Delete(RutaC)
            End If
            Dim zip As New ZipFile(RutaC)

            Dim i As Integer = 0
            For rg As Integer = 0 To dt.Rows.Count - 1
                i = i + 1
                Dim b() As Byte = DirectCast(dt.Rows(rg)("documento"), Byte())
                zip.AddEntry(dt.Rows(rg)("FileName"), b)
            Next
            zip.Comment = "Export De la base de datos SIRCC"
            zip.Save()
            Msg = "Se Generó El Paquete Comprimido (*.Zip) <br> <a href='" + vRutaC + "'  > Click Para Descargar</a> Generado a las: " + Now.ToString
            lErrorG = False
        Catch ex As Ionic.Zip.ZipException
            Msg = "zip:" + ex.Message
            lErrorG = True
        Catch ex As Exception
            Msg = "Ex:" + ex.Message
            lErrorG = True
        Finally
            'Close the database connection
            Desconectar()
        End Try

        Return Msg
    End Function



    Public Function Generar_Zip_Byte(ByVal cod_con As String) As Byte()
        Dim ByteZip() As Byte = {}
        Try
            'Establish the database connection
            Conectar()
            'define the sql to perform the database insert
            querystring = "select FileName,id,documento,cod_con from vDoc_Cont_Nom where cod_con  = '" + cod_con.Trim + "'"
            CrearComando(querystring)

            'Execute the SQL Statement
            Dim dt As DataTable = EjecutarConsultaDataTable()
            Dim RutaC As String = Me.Ruta_Zip + cod_con.Trim + ".zip"
            Dim vRutaC As String = vRuta_Zip + cod_con.Trim + ".zip"
            If File.Exists(RutaC) Then
                File.Delete(RutaC)
            End If
            Dim zip As New ZipFile()


            Dim i As Integer = 0
            For rg As Integer = 0 To dt.Rows.Count - 1
                i = i + 1
                Dim b() As Byte = DirectCast(dt.Rows(rg)("documento"), Byte())
                zip.AddEntry(dt.Rows(rg)("FileName"), b)
            Next
            zip.Comment = "Export De la base de datos SIRCC"

            Dim ms As New MemoryStream
            zip.Save(ms)
            ByteZip = ms.ToArray()
            Msg = "Se Generó El Paquete Comprimido (*.Zip) <br> <a href='" + vRutaC + "'  > Click Para Descargar</a> Generado a las: " + Now.ToString
            lErrorG = False
        Catch ex As Ionic.Zip.ZipException
            Msg = "zip:" + ex.Message
            lErrorG = True
        Catch ex As Exception
            Msg = "Ex:" + ex.Message
            lErrorG = True

        Finally
            'Close the database connection
            Desconectar()
        End Try

        Return ByteZip
    End Function



    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCant_Doc_Contratos(ByVal cod_con As String) As Integer
        Conectar()
        Dim datat As New DataTable
        querystring = "SELECT Count(*) As C FROM  vdoc_contratosac where cod_con=:cod_con"
        CrearComando(querystring)
        AsignarParametroCadena(":cod_con", cod_con)
        datat = EjecutarConsultaDataTable()
        Desconectar()
        Return CInt(datat.Rows(0)("C"))
    End Function

End Class
