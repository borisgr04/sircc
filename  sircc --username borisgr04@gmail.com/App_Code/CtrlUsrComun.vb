Imports Microsoft.VisualBasic

Public Class CtrlUsrComun
    Inherits System.Web.UI.UserControl
    Property Oper() As String
        Get
            Return ViewState("Oper")
        End Get
        Set(ByVal value As String)
            ViewState("Oper") = value
        End Set
    End Property

    Property Pk1() As String
        Get
            Return ViewState("Pk1")
        End Get
        Set(ByVal value As String)
            ViewState("Pk1") = value
        End Set
    End Property


    Protected ReadOnly Property Vigencia_Cookie() As String
        Get
            Return Request.Cookies(Publico.Cookie)("Vigencia")
        End Get
    End Property

    'Protected Sub MsgBox(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)

    '    msg.Height = alto
    '    msg.Width = ancho

    '    msg.Visible = True
    '    msg.CssClass = IIf(lError = True, "NotOk", "Ok")

    'End Sub

    'Protected Sub MsgBox(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
    '    'msg.Height = alto
    '    'msg.Width = ancho
    '    msg.Visible = True
    '    'msg.CssClass = IIf(lError = True, "NotOk", "Ok")
    '    msg.ForeColor = IIf(lError = True, Drawing.Color.Red, Drawing.Color.Blue)

    'End Sub

    Protected Sub MsgBoxV(ByRef msg As Label, ByVal lError As Boolean)
        msg.Height = 100
        msg.Width = 600
        msg.CssClass = IIf(lError = True, "NotOk", "Ok")
    End Sub

    Protected Sub MsgBoxLQ(ByRef msg As Label, ByVal lError As Boolean)

        msg.CssClass = IIf(lError = True, "NotOk", "Ok")

    End Sub

    Protected Overloads Sub MsgBox(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        'msg.Height = alto
        'msg.Width = ancho
        'msg.Height = "100%"
        msg.Visible = True
        msg.Text = "<P style='text-align:justify;'>" + msg.Text + "</P>"
        'msg.CssClass = IIf(lError = True, "NotOk", "Ok")
        'msg.ForeColor = IIf(lError = True, Drawing.Color.Red, Drawing.Color.Blue)
        If lError = True Then
            MsgBoxError(msg, lError)
        Else
            MsgBoxExito(msg, lError)
        End If

    End Sub

    Protected Overloads Sub MsgBoxLimpiar(ByRef msg As Label)
        msg.CssClass = ""
        msg.Text = ""
    End Sub

    Protected Sub MsgBoxAlert(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        msg.CssClass = "alerta"
    End Sub

    Protected Sub MsgBoxInfo(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        msg.CssClass = "infor"
    End Sub

    Protected Sub MsgBoxExito(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        msg.CssClass = "exito"
    End Sub
    Protected Sub MsgBoxError(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        msg.CssClass = "error"
    End Sub

    Protected Function SI_NO(ByVal Valor As String) As Boolean
        Return IIf(Valor = "SI", True, False)
    End Function

End Class
