'Imports Microsoft.VisualBasic
'Public Delegate Sub OnRefresProgress(ByVal str As String, ByVal numexp As String)
'Public Delegate Sub OnRefresProgressEnd()
'Public Delegate Sub OnException(ByVal msg As String)

'Public Class ProcesoLento
'    Public listavalores As List(Of String) = Nothing
'    Public Event OnRefresProgress As OnRefresProgress
'    Public Event OnRefresProgressEnd As OnRefresProgressEnd
'    Public Event OnException As OnException
'    Protected Sub ThrowRefresProgress(ByVal cont As String, ByVal numexp As String)
'        RaiseEvent OnRefresProgress(cont, numexp)
'    End Sub
'    Protected Sub ThrowRefresProgressEnd()
'        RaiseEvent OnRefresProgressEnd()
'    End Sub
'    Protected Sub ThrowOnException(ByVal msg As String)
'        RaiseEvent OnException(msg)
'    End Sub
'    Public Sub ProcessDelete()
'        Try
'            System.Threading.Thread.Sleep(500)
'            Dim cont As Integer = 0
'            For Each str As String In listavalores
'                ThrowRefresProgress(String.Format("{0}.{1}", str, cont), 1)
'                'Procesar(str)
'                System.Threading.Thread.Sleep(50)
'                cont += 1
'            Next
'            ThrowRefresProgress("Fin", 100)
'            ThrowRefresProgressEnd()
'        Catch ex As Exception
'            ThrowOnException(ex.Message)
'        End Try
'    End Sub
'End Class
