<%@ Application Language="VB" %>
<%@ Import Namespace="System.Diagnostics" %>
<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        
        Dim m As DBMenu = New DBMenu
        Dim mc As MembershipUserCollection = Membership.FindUsersByName("admin")
        If mc.Count = 0 Then
            Membership.CreateUser("admin", "sircc2011.")
            Mail.EnviarAuto("Creación de Usuario Inicial:" + Now.ToLongTimeString, "admin")
        End If
        m.GenerarRoles()
        
    End Sub
    
    Private Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs) 
        
        
        
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Dim Err As String = "Errores Capturados eN el Evento Application_Error " & _
                            System.Environment.NewLine & _
                            "Url de Error : " & Request.Url.ToString() & _
                            System.Environment.NewLine & _
                            "Mensaje de Error: " & objErr.Message.ToString() & _
                            System.Environment.NewLine & _
                            "Seguimiento de la Pila:" & objErr.StackTrace.ToString()
        Mail.EnviarAuto("Error:[" + Membership.GetUser.UserName + "]" + Now.ToLongTimeString, ConstruirMensaje)
        
        EventLog.WriteEntry("SIRCC2011", Err, EventLogEntryType.Error)
        'Session("LastError") = err
       
        ''Server.ClearError()
        'additional actions...
    
        
        
    End Sub
       
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Construye un mensaje de error personalizado para mandarlo por correo.
    ''' </summary>
    ''' <returns>Texto con el mensaje generado.</returns>
    ''' -----------------------------------------------------------------------------
    Function ConstruirMensaje() As String
        Dim strMessage As New StringBuilder()

        On Error Resume Next

        strMessage.Append("<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"">")
        strMessage.Append("<html>")
        strMessage.Append("<head>")
        strMessage.Append("<title>Error en " + Publico.Nombre_App + " </title>")
        strMessage.Append("<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"">")
        strMessage.Append("<style type=""text/css"">")
        strMessage.Append("<!--")
        strMessage.Append(".basix {")
        strMessage.Append("font-family: Verdana, Arial, Helvetica, sans-serif;")
        strMessage.Append("font-size: 12px;")
        strMessage.Append("}")
        strMessage.Append(".header1 {")
        strMessage.Append("font-family: Verdana, Arial, Helvetica, sans-serif;")
        strMessage.Append("font-size: 12px;")
        strMessage.Append("font-weight: bold;")
        strMessage.Append("color: #000099;")
        strMessage.Append("}")
        strMessage.Append(".tlbbkground1 {")
        strMessage.Append("background-color:  #000099;")
        strMessage.Append("}")
        strMessage.Append("-->")
        strMessage.Append("</style>")
        strMessage.Append("</head>")
        strMessage.Append("<body>")
        strMessage.Append("<table width=""85%"" border=""0"" align=""center"" cellpadding=""5"" cellspacing=""1"" class=""tlbbkground1"">")
        strMessage.Append("<tr bgcolor=""#eeeeee"">")
        strMessage.Append("<td colspan=""2"" class=""header1"">Error en " + Publico.Nombre_App + "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>Fecha y Hora</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & System.DateTime.Now & " EST</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>Cliente WEB</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Request.ServerVariables("HTTP_USER_AGENT") & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>Dirección IP</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Request.ServerVariables("REMOTE_ADDR") & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>Versión</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>Página</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Request.Url.AbsoluteUri & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>Usuario</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Context.User.Identity.Name.ToString & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>Message</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Server.GetLastError().InnerException.ToString() & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>InnerException</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Server.GetLastError().Message.ToString() & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>Source</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Server.GetLastError().Source.ToString() & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>StackTrace</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Server.GetLastError().StackTrace.ToString() & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>TargetSite</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Server.GetLastError.TargetSite.ToString & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("<tr>")
        strMessage.Append("<td width=""100"" align=""right"" bgcolor=""#eeeeee"" class=""header1"" nowrap>Data</td>")
        strMessage.Append("<td bgcolor=""#FFFFFF"" class=""basix"">" & Server.GetLastError.Data.Item(0).ToString & "</td>")
        strMessage.Append("</tr>")
        strMessage.Append("</table>")
        strMessage.Append("</body>")
        strMessage.Append("</html>")

        Return strMessage.ToString
    End Function
   
</script>