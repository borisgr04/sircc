<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ImprimirCrono.aspx.vb" Inherits="Procesos_Programacion_ImprimirCrono" %>
<%@ Register src="../../CtrlUsr/CalenProg/CCalenProgl.ascx" tagname="CCalenProgl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering=true 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
     <div class="demoheading">CRONOGRAMA DEL PROCESO DE CONTRATACIÓN</div>

      
        <asp:UpdatePanel ID="UpdPCon" runat="server" UpdateMode="Conditional">        
         <ContentTemplate>
             
        <uc1:CCalenProgl ID="CCalenProgl1" runat="server" />

         </ContentTemplate>
            <triggers>
                   <asp:AsyncPostBackTrigger ControlID="CCalenProgl1" EventName="CambiarEstProc" />
            </triggers>
        </asp:UpdatePanel> 
    <br />
              
    </div>
    
    
    </form>
</body>
</html>
