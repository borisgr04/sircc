<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default"  %>

<%@ Register src="CtrlUsr/Inicial/Inicio.ascx" tagname="Inicio" tagprefix="uc1" %>
<%@ Register src="CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" tagname="ctrAyudIzql" tagprefix="uc2" %>


<%@ Register src="CtrlUsr/alert_Inf/Alert_Inf.ascx" tagname="Alert_Inf" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
    EnablePageMethods="true" EnableScriptGlobalization="True" EnableScriptLocalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="demoarea" style="text-align: left">
       <%--<asp:Image ID="ImgControl" runat="server" 
            AlternateText="No tiene imagenes asociadas" 
            ImageUrl="~/ashx/logo.ashx" />--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <uc3:Alert_Inf ID="Alert_Inf1" runat="server" />
            
        </ContentTemplate>
        </asp:UpdatePanel>
        
         <table style="width: 100%">
             <tr>
                 <td rowspan="6">
                     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                
                     
                
                     <br />
                   
                 </td>
                 <td valign="top">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td valign="top">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
         </table>
                   
</div>    

</asp:Content>

