<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CronogramasEnc.aspx.vb" Inherits="Consultas_CronogramasEnc_Default" %>

<%@ Register src="../../CtrlUsr/CalenProg/CCalenProgl.ascx" tagname="CCalenProgl" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/FiltroPCon/FiltroPConE.ascx" tagname="FiltroPConE" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering=true 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
     <div class="demoheading">CRONOGRAMA DEL PROCESO DE CONTRATACIÓN</div>
        <uc2:FiltroPConE ID="FiltroPConE1" runat="server" />
        
        <uc1:CCalenProgl ID="CCalenProgl1" runat="server" />
    
    </div>
</asp:Content>

