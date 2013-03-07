Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports MSWord = Microsoft.Office.Interop.Word
Imports System.Reflection
Imports Microsoft.Office.Core
Imports System.IO
Imports System.Net
Public Class GMinuta


#Region "Declaraciones"

    Public OpenedWord As Boolean
    Public wrdApp As MSWord.Application
    Public WithEvents wrdAppEvent As MSWord.Application
    Public WithEvents wrdAppEvent1 As MSWord.Application
    Public WithEvents wrdAppEvent2 As MSWord.Application
    Dim wrdDoc As MSWord._Document
    Dim oMissing As [Object] = System.Reflection.Missing.Value
    Dim oFalse As [Object] = False
    Dim Clave_Protect As String
    Dim lErrorG As Boolean
    Public Ultimo_Msg As String
    Dim pRutaDocGen As String
    Dim objent As New EntidadMin
    Dim docPDF() As Byte
    Public Property RutaDocGen As String
        Set(ByVal value As String)
            pRutaDocGen = value
        End Set
        Get
            Return pRutaDocGen
        End Get
    End Property
    Dim pCancelado As Boolean
    Property Cancelado As Boolean
        Set(ByVal value As Boolean)
            pCancelado = pCancelado
        End Set
        Get
            Return pCancelado
        End Get
    End Property

    Public pathTemporal As String
    Public pathTemporalPDF As String
    'Dim ws As ws_sircc.WS_Sircc_GMinutas
    Dim ws As New WS_Sircc_GMinutas
    Public Num_Proc As String
    Public Num_Pla As String
    Public Grupo As String
    Public ID As String
    Public Ide_Pla As String
    Dim progress As Integer = 0
    Public Editable As String
    Enum eoperacion
        Regenerar
        Generar
    End Enum
    Dim pEoperacion As eoperacion
    Property operacion As eoperacion
        Set(ByVal value As eoperacion)
            pEoperacion = value
        End Set
        Get
            Return pEoperacion
        End Get
    End Property
    'Dim username As String = mem
    'Private Property username As String
#End Region
    Sub New()
        'NOMBRE DE ARCHIVO TEMPORAL
        'Dim CrearNomArchivo As String = Path.ChangeExtension(Path.GetTempFileName(), ".doc")
        OpenedWord = False
        Cancelado = False
        Clave_Protect = Publico.Clave_Minuta
        '--- OJO
        objent.CargarDatos()
    End Sub
#Region "ProcesosxGrupo"


    Public Function GenerarMinuta() As Boolean
        Dim dt As DataTable
        Dim DocByte As Byte()
        If Me.operacion = eoperacion.Generar Then
            'SE VERIFICA SI YA SE GENERO UN DOCUMENTO DE ESE TIPO Y QUE ESTE ACTIVO
            If ws.GetExitMin(Num_Proc, Grupo) Then
                lErrorG = True
                Me.Cancelado = True
                Ultimo_Msg = "Se Canceló la Generación de Minuta, Existe Minuta activa, debe Anular "
                'bg.ReportProgress(progress)
                'bg.CancelAsync()
                '-----------------------------------------------OJO ESTO SI VA
                Return Not lErrorG
            End If
            If String.IsNullOrEmpty(Ide_Pla) Then
                lErrorG = True
                Me.Cancelado = True
                Ultimo_Msg = "No especificó Plantilla"
                'bg.ReportProgress(progress)
                'bg.CancelAsync()
                Return Not lErrorG
            End If
            dt = ws.GetPPlanbyPK(Ide_Pla)
            If IsDBNull(dt.Rows(0)("PLANTILLA")) Then
                lErrorG = True
                Me.Cancelado = True
                Ultimo_Msg = "No se encontro la plantilla, debe crearla antes de generar el Documento"
                'bg.ReportProgress(progress)
                'bg.CancelAsync()
                Return Not lErrorG
            End If
            DocByte = DirectCast(dt.Rows(0)("PLANTILLA"), Byte())
            Editable = dt.Rows(0)("EDITABLE").ToString
            Dim oFileStream As FileStream = Nothing
            pathTemporal = GMinuta.FolderEspecial & "\" + dt.Rows(0)("NOM_PLA") + "." + dt.Rows(0)("EXT")
            Dim ruta As String = Path.GetTempFileName()
            pathTemporal = Path.ChangeExtension(ruta, ".doc")
            pathTemporalPDF = Path.ChangeExtension(ruta, ".pdf")

            'Ultimo_Msg += pathTemporal + "<br>"
        Else
            dt = ws.GetMinBasePGID(Me.Num_Proc, Me.Grupo, Me.ID)
            DocByte = DirectCast(dt.Rows(0)("MinutaBase"), Byte())
            'pathTemporal = GMinuta.FolderEspecial & "\" + dt.Rows(0)("NUM_PROC").ToString + "_" + dt.Rows(0)("GRUPO").ToString + ".doc"

            Dim ruta As String = Path.GetTempFileName()
            pathTemporal = Path.ChangeExtension(ruta, ".doc")
            pathTemporalPDF = Path.ChangeExtension(ruta, ".pdf")

        End If
        Try
            CrearArchivo(pathTemporal, DocByte)
            '---------------------------------------------------
            progress = 10
            'bg.ReportProgress(progress)
            'If bg.CancellationPending = True Then
            '    Ultimo_Msg = "Se Canceló la Generación de Minuta"
            '    Me.Cancelado = True
            '    lErrorG = False
            '    Return False
            'End If
            '---------------------------------------------------
            Dim MinutaBytes As Byte() = CruzarDatos()
            Dim Msg_Ins_Min As String = ""
            Dim lError_Ins_Min As Boolean = False
            If Me.operacion = eoperacion.Generar Then
                ws.SetMinutaPG1(Num_Proc, Grupo, Editable, MinutaBytes, DocByte, msg_ins_min, lerror_ins_min, Me.docPDF)
            Else
                ws.RegenerarMinuta(Num_Proc, ID, Grupo, MinutaBytes)
            End If
            Ultimo_Msg += "Se Guarda Minuta en Base de Datos...."
            progress += 32
            If lerror_ins_min = False Then
                progress = 100
                lErrorG = False
                Ultimo_Msg += "Se Generó la Minuta Correctamente"
            Else
                lErrorG = lerror_ins_min
                Throw New Exception(Msg_Ins_Min)
            End If

        Catch ex As Exception
            Ultimo_Msg = ex.Message '+ ex.StackTrace
            lErrorG = True
        Finally
        End Try

        Return Not lErrorG
    End Function

    Function CruzarDatos() As Byte()
        Dim Enter As String = "<br>"
        'SE REQUIEREN DOS DATATABLE
        'datos que se imprimiran en el documento (aca seria asignar una tabla)
        Dim dtg As DataTable = ws.GetDatosGProc(Num_Proc, Grupo)
        'Listado de Campos de la Plantillas
        Dim dt As DataTable = ws.GetCamposPla("VGPROCESOSC")
        Dim imgLogo As String = objent.Ruta_Logo

        ' Create an instance of MSWord  and make it visible. 
        wrdApp = New MSWord.Application()
        OpenedWord = True

        wrdApp.Visible = False
        Dim oTemplate As Object = pathTemporal
        wrdDoc = wrdApp.Documents.Open(FileName:=oTemplate)


        '-----------------------------------------------------------
        Ultimo_Msg += "Se Abre la Plantilla" + Enter
        progress += 1
        'bg.ReportProgress(progress)
        '---------------------------------------------------
        wrdDoc.Unprotect(Me.Clave_Protect)
        Ultimo_Msg += "Se desportege la Plantilla" + Enter
        progress += 1
    
        'Dim wrdTable As MSWord.Table
        Dim logoCustom As MSWord.InlineShape = Nothing
        wrdApp.ActiveWindow.ActivePane.View.SeekView = MSWord.WdSeekView.wdSeekCurrentPageHeader
        Dim NFilas As Integer = 1, NColumnas As Integer = 2
        
        Dim Nom_Pla As String
        Dim Nom_Campo As String
        Dim Tip_Dato As String
        Dim Genera_Tabla As String
        Dim Es_Marcador As Boolean
        Dim Nom_Mark As String

        For Each Section As MSWord.Section In wrdDoc.Sections
            
            'CAMPOS
            Dim j As Integer = 1
            For k As Integer = 0 To dt.Rows.Count - 1
                Nom_Pla = dt.Rows(k)("Nom_Pla").ToString.Trim
                Nom_Campo = dt.Rows(k)("Nom_Cam").ToString
                Tip_Dato = dt.Rows(k)("Tip_Dat").ToString
                Genera_Tabla = dt.Rows(k)("GTabla").ToString
                j = 1
                Nom_Mark = "E_" + Nom_Pla + "_" + j.ToString.Trim
                Do While wrdDoc.Bookmarks.Exists(Nom_Mark)
                    wrdDoc.Bookmarks.Item(Nom_Mark).Range.Text = UCase(dtg.Rows(0)(Nom_Campo).ToString)
                    j = j + 1
                    Nom_Mark = "E_" + Nom_Pla + "_" + j.ToString.Trim
                Loop
            Next
            'AGREGAR IMAGEN
            j = 1
            Nom_Mark = "E_LOGO_" + j.ToString.Trim
            Do While wrdDoc.Bookmarks.Exists(Nom_Mark)
                logoCustom = wrdDoc.Bookmarks.Item(Nom_Mark).Range.InlineShapes.AddPicture(imgLogo)
                logoCustom.Width = 50
                logoCustom.Height = 50
                j = j + 1
                Nom_Mark = "E_LOGO_" + j.ToString.Trim
            Loop
            '----------------------------------------------ojo logo

        Next Section
        progress += 3
        Ultimo_Msg += "Se Combinó el Encabezado del Documento e Inserto Logo" + Enter
        'bg.ReportProgress(progress)
        wrdApp.ActiveWindow.ActivePane.View.SeekView = MSWord.WdSeekView.wdSeekMainDocument

        Dim p_cuota As Integer = dt.Rows.Count / 65
        For k As Integer = 0 To dt.Rows.Count - 1
            'dtg.Columns.Contains() si contiene la columna
            Nom_Pla = dt.Rows(k)("Nom_Pla").ToString.Trim
            Nom_Campo = dt.Rows(k)("Nom_Cam").ToString
            Tip_Dato = dt.Rows(k)("Tip_Dat").ToString
            Genera_Tabla = dt.Rows(k)("GTabla").ToString
            Es_Marcador = IIf(dt.Rows(k)("Marcador").ToString = "SI", True, False)

            If Not Es_Marcador Then
                If (Tip_Dato <> "T") AndAlso dtg.Columns.Contains(Nom_Campo) Then ' Si el campo existe como columna en la vista que contiene los datos
                    Dim replaceAll As Object = MSWord.WdReplace.wdReplaceAll
                    wrdApp.Selection.Find.ClearFormatting()
                    wrdApp.Selection.Find.Text = "{" + Nom_Pla + "}" 'Buscar bajo el parametro del nombre del campo en la plantilla
                    wrdApp.Selection.Find.Replacement.ClearFormatting()
                    Dim strRemp As String = MostrarCampo(dtg.Rows(0)(Nom_Campo).ToString, Tip_Dato)

                    If strRemp.Length <= 255 Then
                        wrdApp.Selection.Find.Replacement.Text = strRemp  
                        wrdApp.Selection.Find.Execute(Replace:=replaceAll)
                    Else
                        Ultimo_Msg += "El tamaño del campo es de " + strRemp.Length + " No se puede reemplazar" + Enter
                    End If
                    If Not wrdApp.Selection.Find.Found() Then
                        Ultimo_Msg += "No encontró el campo " + wrdApp.Selection.Find.Text + vbCrLf
                    End If
                ElseIf Tip_Dato = "T" And Genera_Tabla = "S" Then ' Si el campo existe como columna en la vista que contiene los datos
                    Dim oEncontrado As Boolean = False
                    Dim wdFindStop As Object = MSWord.WdFindWrap.wdFindStop
                    Dim replaceAll As Object = MSWord.WdReplace.wdReplaceAll
                    wrdApp.Selection.Find.ClearFormatting()
                    wrdApp.Selection.Find.Text = "{" + Nom_Pla + "}" 'Buscar bajo el parametro del nombre del campo en la plantilla
                    wrdApp.Selection.Find.Wrap = wdFindStop
                    wrdApp.Selection.Find.Forward = True ' Hacia Adelante
                    Dim tip_find As Integer = 1
                    Dim no_encontrado As Integer = 0
                    'Primero busca hacia adelante
                    Do While no_encontrado < 3
                        wrdApp.Selection.Find.Execute()
                        If wrdApp.Selection.Find.Found() Then
                            Dim Tabla As String = dt.Rows(k)("NTabla").ToString
                            Dim dtt As DataTable = ws.GetTablaGP(Tabla, Num_Proc, Grupo)
                            'If dtt.Rows.Count > 0 Then
                            Dim oTable As MSWord.Table
                            Dim wrdRng As MSWord.Range = wrdApp.Selection.Range() 'wrdDoc.Bookmarks.Item(oEndOfDoc).Range
                            Dim nc As Integer = dtt.Columns.Count
                            Dim nf As Integer = dtt.Rows.Count
                            Dim nf_adicional As Integer = 0
                            If dt.Rows(k)("Mostrar_Titulos").ToString = "SI" Then
                                nf_adicional = 1
                            End If
                            If nf = 0 Then
                                wrdRng.Text = ""
                            Else
                                oTable = wrdDoc.Tables.Add(wrdRng, nf + nf_adicional, nc - 2, oMissing, oMissing)
                                'SE AGREGA FORMATO DE TABLAS
                                Dim oPlantilla As New PPlantillas
                                Dim dtConcepto As DataTable
                                Dim dtConsulta As New DataTable
                                dtConsulta = oPlantilla.GetFormatoTabla(Tabla, Ide_Pla)

                                'oTable.Range.ParagraphFormat.SpaceAfter = 6
                                Dim f As Integer, c As Integer
                                ''Colocar Titulos
                                For c = 1 To nc - 2
                                    If dt.Rows(k)("Mostrar_Titulos").ToString = "SI" Then
                                        oTable.Cell(1, c).Range.Text = UCase(dtt.Columns(c + 1).ColumnName)
                                        oTable.Cell(1, c).Range.Font.Bold = True
                                        oTable.Cell(1, c).Range.Paragraphs.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter
                                    End If
                                    dtConcepto = oPlantilla.GetFormatoTabla(Tabla, Ide_Pla, dtt.Columns(c + 1).ColumnName)
                                    If dtConcepto.Rows.Count > 0 Then
                                        oTable.Columns(c).SetWidth(CInt(dtConcepto.Rows(0)("ANCHO").ToString), MSWord.WdRulerStyle.wdAdjustNone)
                                        oTable.Columns(c).Cells.VerticalAlignment = MSWord.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                                    End If
                                Next c
                                'Mostrar Datos
                                For f = 0 To nf - 1
                                    For c = 1 To nc - 2
                                        dtConcepto = oPlantilla.GetFormatoTabla(Tabla, Ide_Pla, dtt.Columns(c + 1).ColumnName)
                                        Dim tipoDato As String = "C"
                                        If dtConsulta.Rows.Count > 0 And dtConcepto.Rows.Count > 0 Then
                                            tipoDato = dtConcepto.Rows(0)("TIP_DAT").ToString
                                        End If
                                        Dim valor As String
                                        valor = dtt.Rows(f)(c + 1).ToString
                                        valor = MostrarCampo(valor, tipoDato)
                                        If tipoDato = "M" Then
                                            oTable.Cell(f + 1 + nf_adicional, c).Range.Paragraphs.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight
                                        Else
                                            oTable.Cell(f + 1 + nf_adicional, c).Range.Paragraphs.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphJustifyMed
                                            'wrdApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphJustify
                                        End If
                                        oTable.Cell(f + 1 + nf_adicional, c).Range.Text = valor
                                        ''SE AGREGO EL FORMATO DE TABLAS MAS O MENOS COMO SHIRLEY

                                        'Aquí la aplicación- inicializarla con la activa
                                        oTable.Cell(f + 1 + nf_adicional, c).Select()

                                        wrdApp.Selection.MoveDown()
                                        wrdApp.ActiveDocument.Select()
                                        wrdApp.Selection.MoveDown()
                                    Next
                                Next
                                'oTable.Borders(Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom).LineStyle = MSWord.WdLineStyle.wdLineStyleDot
                                oTable.Borders.Enable = IIf(dt.Rows(k)("Mostrar_Borde").ToString = "SI", True, False)
                                'End If
                                
                            End If
                        Else
                            wrdApp.Selection.Find.Forward = Not wrdApp.Selection.Find.Forward
                            no_encontrado = no_encontrado + 1
                        End If
                            tip_find += 1
                    Loop
                End If
            Else
                'ESTO SE HACE CUANDO LA CANTIDAD DE DATOS DEL CAMPO A CRUZAR ES DE MAS DE 255 CARACTERES
                ' LO MEJOR SE HACER TODO ASI, PERO ACA EL REEMPLAZA EL MARCADOR QUE SOLO PUEDE ESTAR EN UNA UBICACION
                If wrdDoc.Bookmarks.Exists(Nom_Pla) Then
                    wrdDoc.Bookmarks.Item(Nom_Pla).Range.Text = dtg.Rows(0)(Nom_Campo).ToString 'MostrarCampo(dtg.Rows(0)(Nom_Campo).ToString, Tip_Dato)
                End If
                'EN EL CASO DE LAS MINUTAS, EL OBJETO APARECE EN DOS OCASIONES Y PARA SALIR DEL PASO NOS TOCO COLOCAR ESTE CAMPO DE FORMA MANUAL
                'HABRIA QUE DEFINIR UN PROCESO PARA QUE ENCONTRARÁ MAS DE UN MARCADOR ASOCIADO A UN CAMPO
                Dim j As Integer = 1
                Nom_Mark = Nom_Pla + "_" + j.ToString.Trim
                Do While wrdDoc.Bookmarks.Exists(Nom_Mark)
                    wrdDoc.Bookmarks.Item(Nom_Mark).Range.Text = UCase(dtg.Rows(0)(Nom_Campo).ToString) 'MostrarCampo(dtg.Rows(0)(Nom_Campo).ToString, Tip_Dato)
                    j = j + 1
                    Nom_Mark = Nom_Pla + "_" + j.ToString.Trim
                Loop
            End If

            '----------------------------.-------------------------------------------------------
            progress += p_cuota
            Ultimo_Msg += "......Se combinó Campo [" + dt.Rows(k)("Nom_Pla").ToString.Trim + "]" + Enter
  
        Next k
        wrdDoc.Protect(Type:=MSWord.WdProtectionType.wdAllowOnlyReading, Password:=Me.Clave_Protect) ' Se bloquea el documento
        '-------------------------------------------------------------------------------------
        progress += 1
        Ultimo_Msg += "Se protege el documento...." + Enter
        '----------------------------------------------------------------
        'SE GUARDA DOCUMENTO
        wrdDoc.Save() ' Guarda los cambios en el documento actual
        Ultimo_Msg += "Guarda Cambios en documento temporal...." + Enter
        'ACTIVAR PARA EXPORTAR A PDF
        wrdDoc.SaveAs(FileName:=pathTemporalPDF, FileFormat:=MSWord.WdExportFormat.wdExportFormatPDF) ' Exporta el documento a PDF
        'Ultimo_Msg += "Se convirtio a PDF...." + Enter

        wrdDoc.Close()
        '..........................................
        progress += 2
        Ultimo_Msg += "Se genera documento temporal...." + Enter
        'bg.ReportProgress(progress)
        wrdApp.Quit()
        ' SE CONVIERTE A BYTE
        Dim oFileStream As FileStream = New FileStream(pathTemporal, FileMode.Open)
        Dim bR As New BinaryReader(oFileStream)
        Dim b() As Byte = bR.ReadBytes(oFileStream.Length)
        oFileStream.Close()

        'ACTIVAR PARA EXPORTAR A PDF
        Dim oFileStreamPDF As FileStream = New FileStream(pathTemporalPDF, FileMode.Open)
        Dim bRPDF As New BinaryReader(oFileStreamPDF)
        docPDF = bRPDF.ReadBytes(oFileStreamPDF.Length)
        oFileStreamPDF.Close()
        
        File.Delete(pathTemporal)
        File.Delete(pathTemporalPDF)
        Ultimo_Msg += "Se borrá archivo temporal...." + Enter
        Return b
    End Function

  
   
   
   

    Sub CrearArchivo(ByVal pathTemporal As String, ByVal doc As Byte())

        Dim oFileStream As FileStream = Nothing
        If File.Exists(pathTemporal) Then
            File.Delete(pathTemporal)
        End If
        oFileStream = New FileStream(pathTemporal, FileMode.Create)
        oFileStream.Write(doc, 0, doc.Length)
        oFileStream.Close()
        oFileStream = Nothing

    End Sub

#End Region

    Private Function MostrarCampo(ByVal Valor As String, ByVal Tipo As String) As String
        Dim Ret As String = Valor
        Select Case Tipo
            Case "M"
                Ret = FormatCurrency(Valor)
            Case "N"
                Ret = FormatNumber(Valor)
            Case "C"
                Ret = UCase(Valor)
        End Select
        Return Ret
    End Function
    Private Sub InsertLines(ByVal LineNum As Integer)
        Dim iCount As Integer
        ' Insert "LineNum" blank lines. 
        For iCount = 1 To LineNum
            wrdApp.Selection.TypeParagraph()
        Next
    End Sub
    'Sub OpenMinEditar()
    '    Dim dt As DataTable = ws.GetMinBasePGID(Me.Num_Proc, Me.Grupo, Me.ID)
    '    Dim Minuta As Byte() = DirectCast(dt.Rows(0)("MinutaBase"), Byte())
    '    pathTemporal = Util.FolderEspecial & "\" + Num_Proc + "_GRUPO" + Grupo + "_ID" + ID + ".doc"
    '    Try
    '        CrearArchivo(pathTemporal, Minuta)
    '        wrdAppEvent2 = New MSWord.Application()
    '        wrdAppEvent2.Visible = True
    '        wrdDoc = wrdAppEvent2.Documents.Open(pathTemporal)
    '        wrdDoc.Unprotect(Me.Clave_Protect)
    '        'wrdDoc.Protect(MSWord.WdProtectionType.wdAllowOnlyFormFields, oMissing, Me.Clave_Protect, oMissing, oMissing)
    '        'wrdDoc.PrintPreview()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Nom_Aplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private Sub DocumentBeforeClose2(ByVal doc As MSWord.Document, ByRef Cancel As Boolean) Handles wrdAppEvent2.DocumentBeforeClose
    '    Dim r As DialogResult
    '    r = MessageBox.Show("Desea Guardar los Cambios al Documento", Nom_Aplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '    If r = DialogResult.Yes Then
    '        MessageBox.Show("Se Guardaron los cambios con Éxito...", Nom_Aplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        'Se bloque nuevamente
    '        wrdDoc.Protect(MSWord.WdProtectionType.wdAllowOnlyReading, oMissing, Me.Clave_Protect, oMissing, oMissing)
    '        ''Guarda los Cambios en el Archivo
    '        wrdDoc.Save()
    '        wrdDoc.Close()
    '        Dim oFileStream As FileStream = New FileStream(pathTemporal, FileMode.Open)
    '        Dim bR As New BinaryReader(oFileStream)
    '        ws.RegenerarMin(Num_Proc, Me.ID, Me.Grupo, bR.ReadBytes(oFileStream.Length))
    '    Else
    '        wrdDoc.Close()
    '    End If
    'End Sub

    Shared ReadOnly Property FolderEspecial As String
        Get
            ' Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            Return Publico.RUTA_DOC_TMP ' Path.GetTempPath
        End Get
    End Property
End Class
