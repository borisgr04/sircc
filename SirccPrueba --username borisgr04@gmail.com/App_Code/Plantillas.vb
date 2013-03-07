Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports MSWord = Microsoft.Office.Interop.Word
Imports System.Reflection
Imports Microsoft.Office.Core


Public Class Plantillas
    Dim wrdApp As MSWord.Application
    Dim wrdDoc As MSWord._Document
    Dim oMissing As [Object] = System.Reflection.Missing.Value
    Dim oFalse As [Object] = False

    Public Sub GenerarMinuta()
        ' Create an instance of MSWord  and make it visible. 
        '----------
        'wrdApp = New MSWord.Application()
        'Dim missing As Object
        'missing = System.Reflection.Missing.Value
        'wrdDoc = wrdApp.Documents.Add(missing, missing, missing, missing)
        'wrdDoc.Activate()
        'wrdApp.Selection.TypeText("Texto que se va insertar")
        'Dim oNuevoDoc As Object = "c:\Contrato4.docx"
        'wrdDoc.SaveAs(oNuevoDoc)
        'wrdApp.Application.Quit(missing, missing)
        '-----------
        System.IO.File.Copy("C:\contrato.doc", "C:\ejemploX.doc")

        wrdApp = New MSWord.Application()
        wrdApp.Visible = True
        Dim missing As Object
        missing = System.Reflection.Missing.Value
        Dim oTemplate As Object = "C:\ejemploX.doc"
        wrdDoc = wrdApp.Documents.Open(oTemplate, oMissing, oMissing, oMissing, oMissing, oMissing, _
         oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)
        Dim replaceAll As Object = MSWord.WdReplace.wdReplaceAll
        wrdApp.Selection.Find.ClearFormatting()
        wrdApp.Selection.Find.Text = "{CONTRATISTA}"
        wrdApp.Selection.Find.Replacement.ClearFormatting()
        wrdApp.Selection.Find.Replacement.Text = "SHIRLEY TATIANA PITTA PICON"
        wrdApp.Selection.Find.Execute(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, _
         oMissing, oMissing, oMissing, oMissing, replaceAll, oMissing, _
         oMissing, oMissing, oMissing)

        wrdApp.Selection.Find.ClearFormatting()
        wrdApp.Selection.Find.Text = "{CONTRATANTE}"
        wrdApp.Selection.Find.Replacement.ClearFormatting()
        wrdApp.Selection.Find.Replacement.Text = "GUSTAVO CORDOBA MARQUEZ"
        wrdApp.Selection.Find.Execute(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, _
         oMissing, oMissing, oMissing, oMissing, replaceAll, oMissing, _
         oMissing, oMissing, oMissing)

        wrdApp.Selection.Find.ClearFormatting()
        wrdApp.Selection.Find.Text = "{EMPRESA}"
        wrdApp.Selection.Find.Replacement.ClearFormatting()
        wrdApp.Selection.Find.Replacement.Text = "SISTEMAS ASOCIADOS"
        wrdApp.Selection.Find.Execute(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, _
         oMissing, oMissing, oMissing, oMissing, replaceAll, oMissing, _
         oMissing, oMissing, oMissing)

        wrdApp.Selection.Find.ClearFormatting()
        wrdApp.Selection.Find.Text = "{NIT}"
        wrdApp.Selection.Find.Replacement.ClearFormatting()
        wrdApp.Selection.Find.Replacement.Text = "890890890-8"
        wrdApp.Selection.Find.Execute(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, _
         oMissing, oMissing, oMissing, oMissing, replaceAll, oMissing, _
         oMissing, oMissing, oMissing)

        wrdApp.Selection.Find.ClearFormatting()
        wrdApp.Selection.Find.Text = "{VALOR}"
        wrdApp.Selection.Find.Replacement.ClearFormatting()
        wrdApp.Selection.Find.Replacement.Text = "$ 4.600.000"
        wrdApp.Selection.Find.Execute(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, _
         oMissing, oMissing, oMissing, oMissing, replaceAll, oMissing, _
         oMissing, oMissing, oMissing)
        wrdDoc.Save()
        wrdDoc = Nothing
        wrdApp.Application.Quit(missing, missing)


        
       
    End Sub
End Class

