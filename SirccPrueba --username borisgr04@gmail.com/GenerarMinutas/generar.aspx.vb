﻿
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.html

Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

'Imports Oracle.DataAccess.Client



Partial Class Minutas_generar
    Inherits System.Web.UI.Page

    Protected Sub BtnPdf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPdf.Click

        Dim obj As CMinutas = New CMinutas
        ' comando insert
        Dim datat As DataTable = obj.GetByPk("01")
        Dim minuta As String = datat.Rows(0)("cmin_body")
        minuta = minuta.Replace("{CONTRATISTA}", "BORIS ARTURO GONZALEZ RIVERA")
        minuta = minuta.Replace("{IDE_CONTRATISTA}", "7573361")
        minuta = minuta.Replace("{OBJETO_CONTRATO}", "PRESTACION DE SERVICIOS PROFESIONALES PAA PRESTAR APOYO A LA SECRETARIA GENERAL EN LA OFICINA DE INFORMATICA EN EL DESARROLLO DE ACTIVIADES DE ADMINISTRACION DE LAS APLICACIONES Y HERRAMIENTAS INFORMATICAS DE LA GOBENRACION DEL CESAR")
        Response.Write(minuta)
        Pdf(minuta)
    End Sub

    Sub Pdf(ByVal Contenido As String)
        Dim pdfDoc As New Document(iTextSharp.text.PageSize.LETTER)

        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream("C:\SirccV0\SIRCC\Docs\Minuta.pdf", FileMode.Create))
        Dim ev As New itsEvents
        ev.Header = "<b>CONTRATO DE PRESTACION DE SERVICIOS PROFESIONALES No</b> <br>"
        ev.Header += "<b>CONTRATISTA:</b> BORIS ARTURO GONZALEZ RIVERA .NIT/C.C. 7.573.361<br><br>"
        pdfWrite.SetMargins(30, 30, 10, 20)
        pdfWrite.PageEvent = ev
        pdfDoc.Open()
        'DE ARCHIVO
        '------------------------------
        'Dim strHTMLpath As String = Server.MapPath("pliegoLIC.asp")
        'Dim fs As FileStream = New FileStream(strHTMLpath, FileMode.Open)
        Dim ms As MemoryStream = New MemoryStream(ASCIIEncoding.Default.GetBytes(Contenido))
        'ms.SetLength(fs.Length)
        'fs.Read(ms.GetBuffer(), 0, fs.Length)
        'ms.Flush()
        'fs.Close()
        '-----------------------


        For i = 1 To 1
            'pdfDoc.Add(New Paragraph("Hola Mundo Página [" + i.ToString + "]"))
            'Dim strHTMLpath As String = Server.MapPath("MyHTML.html")

            'Using sReader As TextReader = New StreamReader(strHTMLpath, Encoding.Default)
            Using sReader As TextReader = New StreamReader(ms)
                Dim list As Generic.List(Of IElement) = HTMLWorker.ParseToList(sReader, New StyleSheet())
                For Each elm As IElement In list
                    pdfDoc.Add(elm)
                Next
            End Using

            'pdfDoc.NewPage()
        Next i

        pdfDoc.Close()
    End Sub

End Class
Public Class itsEvents
    Inherits PdfPageEventHelper
    Private _Header As [String]

    Protected total As PdfTemplate
    Protected helv As BaseFont
    Private settingFont As Boolean = False

    Public Overrides Sub OnOpenDocument(ByVal writer As PdfWriter, ByVal document As Document)
        total = writer.DirectContent.CreateTemplate(100, 100)
        total.BoundingBox = New Rectangle(-20, -20, 100, 100)
        helv = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED)
    End Sub


    Public Property Header() As [String]
        Get
            Return _Header
        End Get
        Set(ByVal value As [String])
            _Header = value
        End Set
    End Property
    Public Overrides Sub OnStartPage(ByVal writer As PdfWriter, ByVal document As Document)

        'Dim p As New Paragraph()
        'p.Add("CONTRATO DE PRESTACION DE SERVICIOS PROFESIONALES No ")
        'p.Add(Me.Header)
        ''DateTime.Now.ToString() 
        'p.Add("Página N°" + Convert.ToString(writer.PageNumber))
        Dim oImagen As iTextSharp.text.Image
        'Dim coordenadaX As Single = 10.5
        'Dim coordenadaY As Single = 10.5
        oImagen = iTextSharp.text.Image.GetInstance("C:\SirccV0\SIRCC\images\Binary\ejemplo.jpg")
        oImagen.ScaleToFit(160, 80)
        'oImagen.SetAbsolutePosition(coordenadaX, coordenadaY)
        'Me.Header += Convert.ToString(writer.PageNumber) + "/"

        document.Add(oImagen)

        Dim ms As MemoryStream = New MemoryStream(ASCIIEncoding.Default.GetBytes(Me.Header))
        Using sReader As TextReader = New StreamReader(ms)
            Dim list As Generic.List(Of IElement) = HTMLWorker.ParseToList(sReader, New StyleSheet())
            For Each elm As IElement In list
                document.Add(elm)
            Next
        End Using

        ''document.Add(p)
        'p.SpacingBefore = 20
        'p.SpacingAfter = 50


    End Sub
    Public Overrides Sub OnEndPage(ByVal writer As PdfWriter, ByVal document As Document)
        'Dim p As New Paragraph(Convert.ToString(Header) & " " & DateTime.Now.ToString() & " " & Convert.ToString(writer.PageNumber))
        'document.Add(p)
        'p.SpacingBefore = 10
        Dim cb As PdfContentByte = writer.DirectContent
        cb.SaveState()
        Dim text As String = "Página " + writer.PageNumber.ToString & " de "
        Dim textBase As Single = document.Bottom - 20
        Dim textSize As Single = 12
        'helv.GetWidthPoint(text, 12); 
        cb.BeginText()
        cb.SetFontAndSize(helv, 12)
        'If (writer.PageNumber Mod 2) = 1 Then 'Impar
        '    cb.SetTextMatrix(document.Left, textBase)
        '    cb.ShowText(text)
        '    cb.EndText()
        '    cb.AddTemplate(total, document.Left + 5 * textSize, textBase)
        'Else 'Par
        Dim adjust As Single = helv.GetWidthPoint("0", 12)
        cb.SetTextMatrix(document.Right - 5.5 * textSize - adjust, textBase)
        cb.ShowText(text)
        cb.EndText()
        cb.AddTemplate(total, document.Right - adjust, textBase)
        'End If
        cb.RestoreState()

    End Sub
    Public Overrides Sub OnCloseDocument(ByVal writer As PdfWriter, ByVal document As Document)
        total.BeginText()
        total.SetFontAndSize(helv, 12)
        total.SetTextMatrix(0, 0)
        Dim pageNumber As Integer = writer.PageNumber - 1
        total.ShowText(Convert.ToString(pageNumber))
        total.EndText()
    End Sub

End Class