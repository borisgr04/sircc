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
<%--                <iframe src="http://docs.google.com/gview?url=http://sircc.gobcesar.gov.co/ashx/verCert.ashx?nro_cert=1&vig_cert=2012&CVXX=201208103216080700001&embedded=true"
style="width:500px; height:400px;" frameborder="0"></iframe>   
<iframe src="http://docs.google.com/viewer?url=http%3A%2F%2F190.254.21.92%3A8020%2Fashx%2FverCert.ashx%3Fnro_cert%3D1%26vig_cert%3D2012%26CVXX%3D201208103216080700001&embedded=true" width="600" height="780" style="border: none;"></iframe>
--%>
</div>    

</asp:Content>

