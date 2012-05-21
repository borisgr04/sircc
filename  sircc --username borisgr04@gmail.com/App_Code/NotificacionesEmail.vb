Imports Microsoft.VisualBasic
Imports System.Data
Public Class NotificacionesEmail

    Public lErrorG As Boolean
    Dim Msg As String
    Public Function Notificar_Cambio_Estado_Actividad(ByVal ID As String) As String

        Dim p As New PCronogramas
        Dim dt As DataTable = p.GetByPKparaNot(ID)
        If dt.Rows.Count > 0 Then
            Dim Body As String = Cargar_Plantilla(dt, "NOTSEGACT")
            Dim Asunto As String = String.Format("Notificación Proceso N° {0}", dt.Rows(0)("Num_Proc").ToString)
            Dim para As String = dt.Rows(0)("EMail_Dep_Nec").ToString
            Dim CC As String = dt.Rows(0)("EMail_Dep_Del").ToString
            Dim BCC As String = dt.Rows(0)("Ema_Enc").ToString
            Msg = Mail.EnviarNot(para, Asunto, Body, CC, BCC)
            lErrorG = Mail.lerrorG
            Return (Msg + "<BR/> Envio " + Now.ToString)
        Else
            lErrorG = True
            Return "No se encontro registro"
        End If

    End Function

    Public Function GetPDF_Notificar_RevisionSol(ByVal Cod_Sol As String, ByVal Id_HRev As String) As String
        Dim p As New PSolicitudes
        Dim dt As DataTable = p.GetHrevNot(Cod_Sol, Id_HRev)
        Dim Body As String = Cargar_Plantilla(dt, "NOTREVSOL")
        Return Body
    End Function
    Public Function Notificar_TestMail(ByVal Cod_Dep As String) As String
        Dim d As New Dependencias
        Dim dt As DataTable = d.GetbyPK(Cod_Dep)
        Dim Body As String = Cargar_Plantilla(dt, "NOTTEST")
        Dim Asunto As String = String.Format("Test de Notificaciones - SIRCC - CORREOS Hora:" + Now.ToLongTimeString)
        Dim CC As String = Mail._MailAdmin
        Dim Para As String = dt.Rows(0)("EMAIL").ToString
        Msg = Mail.EnviarNot(Para, Asunto, Body, CC) + "<BR/> Enviado a  " + Para + "-" + Now.ToString
        lErrorG = Mail.lerrorG
        Return Msg
    End Function

    Public Function Notificar_RevisionSol(ByVal Cod_Sol As String, ByVal Id_HRev As String) As String
        Dim p As New PSolicitudes
        Dim dt As DataTable = p.GetHrevNot(Cod_Sol, Id_HRev)
        Dim Body As String = Cargar_Plantilla(dt, "NOTREVSOL")
        Dim Asunto As String = String.Format("Concepto de Revisión Solicitud N° {0}", dt.Rows(0)("Cod_Sol").ToString)
        Dim CC As String = dt.Rows(0)("EMail_Dep_Del").ToString
        Msg = Mail.EnviarNot(dt.Rows(0)("EMail_Dep_Nec").ToString, Asunto, Body, CC) + "<BR/> Envio " + Now.ToString
        Return Msg
    End Function

    Public Function Cargar_Plantilla(ByVal datos As DataTable, ByVal Nomb_Plantilla As String) As String
        Dim obj As CorreosE = New CorreosE
        Dim dtc As DataTable = obj.GetPorNomb(Nomb_Plantilla)
        Dim m As String = ""
        If dtc.Rows.Count > 0 Then
            m = dtc.Rows(0)("Corr_Body").ToString
            For i As Integer = 0 To datos.Columns.Count - 1
                m = m.Replace("{" + datos.Columns(i).ColumnName + "}", datos.Rows(0)(i).ToString)
            Next
            m = m.Replace("{FECHA_HOY}", Format(Today, "dd MMMM yyyy"))
            m = m.Replace("{FECHA_Y_HORA}", Now.ToString)
        End If
        Return m
    End Function

End Class
