Imports Microsoft.VisualBasic

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
Public Class GPdf

    Private _TextoMinuta As String
    Property TextoMinuta() As String
        Get
            Return _TextoMinuta
        End Get
        Set(ByVal value As String)
            _TextoMinuta = value
        End Set
    End Property

    Public Sub GenerarPDF(ByVal Cod_Sol As String, ByVal Hrev_Id As String)

        Dim obj As New NotificacionesEmail
        Dim minuta As String = obj.GetPDF_Notificar_RevisionSol(Cod_Sol, Hrev_Id)
        Pdf(minuta)

    End Sub

    Public Function GenerarHTML(ByVal Cod_Sol As String, ByVal Hrev_Id As String) As String

        Dim obj As New NotificacionesEmail
        Dim texto As String = obj.GetPDF_Notificar_RevisionSol(Cod_Sol, Hrev_Id)
        Return texto

    End Function

    Sub Pdf(ByVal Contenido As String)
        Dim pdfDoc As New Document(iTextSharp.text.PageSize.LETTER)
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream("C:\Oficio.pdf", FileMode.Create))
        'Dim ev As New itsEvents2
        'ev.Header = "<b>CONTRATO DE PRESTACION DE SERVICIOS PROFESIONALES No</b> <br>"
        'ev.Header += "<b>CONTRATISTA:</b> BORIS ARTURO GONZALEZ RIVERA .NIT/C.C. 7.573.361<br><br>"
        'pdfWrite.SetMargins(30, 30, 10, 20)
        'pdfWrite.PageEvent = ev
        pdfDoc.Open()
        Dim ms As MemoryStream = New MemoryStream(ASCIIEncoding.Default.GetBytes(Contenido))
        For i = 1 To 1
            Using sReader As TextReader = New StreamReader(ms)
                Dim list As Generic.List(Of IElement) = HTMLWorker.ParseToList(sReader, New StyleSheet())
                For Each elm As IElement In list
                    pdfDoc.Add(elm)
                Next
            End Using
        Next i
        pdfDoc.Close()
    End Sub

End Class

Public Class itsEvents2
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
        'Dim oImagen As iTextSharp.text.Image
        'Dim coordenadaX As Single = 10.5
        'Dim coordenadaY As Single = 10.5

        'oImagen = iTextSharp.text.Image.GetInstance("C:\SirccV0\SIRCC\images\Binary\ejemplo.jpg")
        'oImagen.ScaleToFit(160, 80)
        'oImagen.SetAbsolutePosition(coordenadaX, coordenadaY)
        'Me.Header += Convert.ToString(writer.PageNumber) + "/"

        'document.Add(oImagen)
        Me.Header = Me.Header + "<div  align='justify'>"
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
