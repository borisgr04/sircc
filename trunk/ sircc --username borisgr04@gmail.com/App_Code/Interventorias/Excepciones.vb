Imports Microsoft.VisualBasic

Public Class BgrExcepciones
    Inherits ApplicationException
    '''
    ''' Construye una instancia en base a un mensaje de error y la una excepción original.
    '''
    ''' El mensaje de error.
    ''' La excepción original.
    Public Sub New(ByVal mensaje As String, ByVal original As Exception)
        MyBase.New(mensaje, original)
    End Sub
    '''
    ''' Construye una instancia en base a un mensaje de error.
    '''
    ''' El mensaje de error.
    Public Sub New(ByVal mensaje As String)
        MyBase.New(mensaje)
    End Sub

    
End Class