<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ConAsignaciones.aspx.vb" Inherits="Procesos_Asignaciones_ConAsignaciones" %>

<%@ Register src="../../CtrlUsr/ConAsignacionesSP/ConAsigSP.ascx" tagname="ConAsigSP" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
        
        
    
        <uc1:ConAsigSP ID="ConAsigSP1" runat="server" />
        
        
    
    </div>
    </form>
</body>
</html>
