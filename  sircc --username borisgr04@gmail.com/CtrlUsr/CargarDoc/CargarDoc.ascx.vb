
Partial Class Controles_CargarDoc
    Inherits CtrlUsrComun
    Dim cod_con As String = ""
    Public Property CodigoContrato() As String
        Get
            Return Cod_Con
        End Get
        Set(ByVal value As String)
            cod_con = value
        End Set
    End Property
    Public Sub Cargar_Documentos()
        Dim lError As Boolean = False

        If ChkCargar.Checked = True Then
            Dim obj As New DocContratos()
            If FileUpload1.HasFile Then
                Try
                    MsgResult.Text = obj.DocContratos(Me.CodigoContrato, Tip_Doc.SelectedValue, FileUpload1, txtObs.Text, "", Me.TxtFecEnt.SelectedValue)
                    lError = obj.lErrorG
                Catch ex As Exception
                    lError = True
                    MsgResult.Text = "ERROR: " & ex.Message.ToString()
                End Try
                MsgBox(MsgResult, obj.lErrorG)
            Else
                MsgResult.Text = "No has seleccionado ningún archivo"
                MsgBoxAlert(MsgResult, obj.lErrorG)
            End If

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
