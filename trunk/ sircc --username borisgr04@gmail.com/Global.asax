<%@ Application Language="VB" %>
<%@ Import Namespace="System.Diagnostics" %>
<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        
        Dim m As DBMenu = New DBMenu
        'Dim mc As MembershipUserCollection = Membership.FindUsersByName("admin")
        'If mc.Count = 0 Then
            'Membership.CreateUser("admin", "sircc2011.")
            'Mail.EnviarAuto("Creación de Usuario Inicial" + Now.ToLongTimeString, "admin")
        'End If
        m.GenerarRoles()
        
    End Sub
    
    Private Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs) 
        
        'EventLog.WriteEntry("Test Web", "MESSAGE: " + ex.Message + "\nSOURCE: " + ex.Source + "\nFORM: " + Request.Form.ToString() + "\nQUERYSTRING: " + Request.QueryString.ToString() + "\nTARGETSITE: " + ex.TargetSite + "\nSTACKTRACE: " + ex.StackTrace, EventLogEntryType.Error)
       
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Dim Err As String = "Errores Capturados eN el Evento Application_Error " & _
                            System.Environment.NewLine & _
                            "Url de Error : " & Request.Url.ToString() & _
                            System.Environment.NewLine & _
                            "Mensaje de Error: " & objErr.Message.ToString() & _
                            System.Environment.NewLine & _
                            "Seguimiento de la Pila:" & objErr.StackTrace.ToString()
        Mail.EnviarAuto("Error:[" + Membership.GetUser.UserName + "]" + Now.ToLongTimeString, Err)
        
        EventLog.WriteEntry("SIRCC2011", Err, EventLogEntryType.Error)
        'Session("LastError") = err
       
        ''Server.ClearError()
        'additional actions...
    
        
        
    End Sub
       
</script>