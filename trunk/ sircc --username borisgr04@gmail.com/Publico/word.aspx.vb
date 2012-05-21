Imports System.IO
Imports System.Threading

'Public Delegate Sub OnRefresProgress(ByVal str As String, ByVal numexp As String)
'Public Delegate Sub OnRefresProgressEnd()
'Public Delegate Sub OnException(ByVal msg As String)

Partial Class Publico_word
    Inherits System.Web.UI.Page
    Dim GM As New GMinuta

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim GM As New GMinuta
        GM.operacion = GMinuta.eoperacion.Generar
        GM.Num_Proc = "CCDD-SGR-0018-2011"
        GM.Grupo = 1
        GM.Ide_Pla = 9
        GM.GenerarMinuta()
        Label1.Text = GM.Ultimo_Msg

    End Sub

    Protected Sub Btn3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn3.click

        'GetCurrentThreadInfo(Thread.CurrentThread)
        'Dim t As New Thread(AddressOf LongTimeTask)
        't.Start()
        'GetCurrentThreadInfo(t)

    End Sub
   

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim oFileStream As FileStream = New FileStream("c:\MINUTAPRUEBAxxx.DOC", FileMode.Open)
        Me.Button2.Text = "OK"
        Dim bR As New BinaryReader(oFileStream)
        Dim b() As Byte = bR.ReadBytes(oFileStream.Length)
        oFileStream.Close()
        Response.AddHeader("content-disposition", "attachment; filename=Prueba.doc")
        Response.BinaryWrite(b)
        Response.End()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim curObj As ScriptManager = ScriptManager.GetCurrent(Page)
        If curObj IsNot Nothing Then
            curObj.RegisterPostBackControl(Me.Button2)
        End If

    End Sub



End Class

