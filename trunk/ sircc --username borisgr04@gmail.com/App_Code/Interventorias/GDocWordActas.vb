Imports Microsoft.VisualBasic
Imports MSWord = Microsoft.Office.Interop.Word
Imports System.Data

Public Class GDocWordActas
    Inherits GDocWord

    Protected Overrides Sub CrearTabla(ByRef oWord As MSWord.Application, ByRef oDoc As MSWord._Document, ByVal dtValoresTabla As DataTable, ByVal MostrarHeader As Boolean, ByVal MostrarBorde As Boolean)
        Dim oTable As MSWord.Table
        Dim wrdRng As MSWord.Range = oWord.Selection.Range()
        Dim Cols As Integer
        Dim Fila As Integer = dtValoresTabla.Rows.Count
        Dim nuevaFila As Integer = 0
        Dim GrupoActual As String
        Dim f As Integer, c As Integer
        Dim dtFiltro As New DataTable

        'No. de Columnas que se Quieren mostrar de la tabla
        If ColTabla = 0 Then
            Cols = dtValoresTabla.Columns.Count
        Else
            Cols = ColTabla
        End If

        If MostrarHeader Then
            nuevaFila = 1
        End If

        If Tagrupada = "S" Then
            'para agregar tantas filas como grupos existan
            dtFiltro = dtValoresTabla.DefaultView.ToTable(True, Tgrupo)
        End If

        oTable = oDoc.Tables.Add(wrdRng, Fila + nuevaFila + (dtFiltro.Rows.Count * 2), Cols, oMissing, oMissing)

        Dim oPlantilla As New PPlantillas
        Dim dtConcepto As DataTable
        Dim dtConsulta As New DataTable
        dtConsulta = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla)

        For c = 1 To Cols
            If MostrarHeader Then
                Dim tit As String = dtValoresTabla.Columns(c - 1).ColumnName
                oTable.Cell(1, c).Range.Text = Left(tit, 1).ToUpper + Right(tit.ToLower(), tit.Length - 1)
                oTable.Cell(1, c).Range.Font.Bold = True
                oTable.Cell(1, c).Range.Paragraphs.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter
            End If
            dtConcepto = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla, dtValoresTabla.Columns(c - 1).ColumnName)
            If dtConcepto.Rows.Count > 0 Then
                oTable.Columns(c).SetWidth(CInt(dtConcepto.Rows(0)("ANCHO").ToString), MSWord.WdRulerStyle.wdAdjustNone)
                oTable.Columns(c).Cells.VerticalAlignment = MSWord.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            End If
        Next
        'Llenar Tabla
        Dim tipoDato As String
        GrupoActual = ""
        For f = 0 To Fila - 1
            Dim encontrado As Boolean = False
            For c = 1 To Cols
                tipoDato = "C"
                dtConcepto = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla, dtValoresTabla.Columns(c - 1).ColumnName)
                If dtConsulta.Rows.Count > 0 And dtConcepto.Rows.Count > 0 Then
                    tipoDato = dtConcepto.Rows(0)("TIP_DAT").ToString
                End If
                Dim valor As String
                valor = dtValoresTabla.Rows(f)(c - 1).ToString
                valor = FormatearCampo(valor, tipoDato)
                If tipoDato = "M" Then
                    oTable.Cell(f + 1 + nuevaFila, c).Range.Paragraphs.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight
                End If
                If Tagrupada = "S" Then
                    If Not encontrado Then
                        If dtValoresTabla.Rows(f)(Tgrupo).ToString <> GrupoActual Then
                            encontrado = True
                            GrupoActual = dtValoresTabla.Rows(f)(Tgrupo).ToString
                            oTable.Cell(f + 1 + nuevaFila, c).Range.Text = ""
                            nuevaFila = nuevaFila + 1
                            oTable.Rows(f + 1 + nuevaFila).Select()
                            oTable.Cell(f + 1 + nuevaFila, c).Merge(oTable.Cell(f + 1 + nuevaFila, Cols))
                            oTable.Cell(f + 1 + nuevaFila, c).Range.Text = Tgrupo + ": " + GrupoActual
                            oTable.Cell(f + 1 + nuevaFila, c).Range.Font.Bold = True
                            nuevaFila = nuevaFila + 1
                        End If
                        oTable.Cell(f + 1 + nuevaFila, c).Range.Text = valor
                    Else
                        oTable.Cell(f + 1 + nuevaFila, c).Range.Text = valor
                    End If
                Else
                    oTable.Cell(f + 1 + nuevaFila, c).Range.Font.Bold = False
                    oTable.Cell(f + 1 + nuevaFila, c).Range.Text = valor
                End If
            Next
        Next
        oTable.Borders.Enable = MostrarBorde
    End Sub


End Class
