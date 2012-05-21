<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default"  %>

<%@ Register src="CtrlUsr/Inicial/Inicio.ascx" tagname="Inicio" tagprefix="uc1" %>
<%@ Register src="CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" tagname="ctrAyudIzql" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <telerik:RadScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True" EnableTheming="True">
    </telerik:RadScriptManager>
    <div class="demoarea" style="text-align: left">
  <h3>
  <br />

    <asp:Image ID="Image3" runat="server"  ImageUrl="~/images/Login/Img_gob.jpg" 
          Height="50px" Width="137px"
         />&nbsp;</h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        </asp:UpdatePanel>
        <h3>
        &nbsp;&nbsp;</h3>
    
     
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
     
    
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
                     
</div>    

</asp:Content>

