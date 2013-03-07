<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CronogramasDepP.aspx.vb" Inherits="Consultas_CronogramasDepP_Default" %>

<%@ Register src="../../CtrlUsr/CalenProg/CCalenProgl.ascx" tagname="CCalenProgl" tagprefix="uc1" %>



<%@ Register src="../../CtrlUsr/FiltroPCon/FiltroPConP.ascx" tagname="FiltroPConP" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering=true 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
     <div class="demoheading">CRONOGRAMA DEL PROCESO DE CONTRATACIÓN</div>
     
        
        <uc2:FiltroPConP ID="FiltroPConP1" runat="server" />
     
        
        <uc1:CCalenProgl ID="CCalenProgl1" runat="server" />
    
    </div>
</asp:Content>

