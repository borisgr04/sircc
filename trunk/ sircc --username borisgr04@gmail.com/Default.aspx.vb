Imports System.Data
Partial Class _Default
    Inherits PaginaComun


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.SetTitulo()

        Dim t As New Terceros

        If t.GetIsAsig_Proc() Then
            Redireccionar_Pagina("/Consultas/AvisosAct/AvisosAct2.aspx")
        End If

        'Profile


        
    End Sub
End Class
