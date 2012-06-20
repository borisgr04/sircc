<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" EnableTheming="false" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Inicio Sesiòn</title>
 <link rel="Stylesheet" href="login.css" type="text/css" media="all" />
         
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>  
    <div class="arab"></div>
      <div id="cajas">
          <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/NvaCaja.png" 
              Height="332px" Width="413px" />
       
           <div class="usuario"> <img src="imagenes/Usuario.png" alt="Usuario" 
                   style="height: 246px; width: 230px"/></div>
         
          <div id="UsuarioL"></div> <div class="logo">
          <img src="imagenes/Nombre.png" alt="Usuario" 
                   style="height: 163px; width: 401px; margin-top: 0px;"/></div>

        <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
        
          <table  class="tablitas" >
          
          <tr>
          <td><label>Usuario:</label> </td>
          <td>
                <asp:TextBox ID="TxtUsername" runat="server" Width="135"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUsername" ErrorMessage="El Nombre de Usuario es Requeirdo" Display="Dynamic">*</asp:RequiredFieldValidator>
          </td>

          </tr>
            <tr>
          <td>
         Contraseña:
          </td>
          <td> <asp:TextBox ID="TxtClave" runat="server" Width="135" TextMode="Password" autocomplete="off"></asp:TextBox>
                      <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TxtClave" ErrorMessage="La Contraseña es requerida" Display="Dynamic">*
                        </asp:RequiredFieldValidator></td>

          </tr>
          <tr>
          <td><label>M&oacute;dulo:</label> </td>
          <td>
          <asp:DropDownList ID="CboMod" runat="server" DataTextField="Nom_Mod" 
                                        DataValueField="Cod_Mod" DataSourceID="ObjModulos"  Width="140px">
                                    </asp:DropDownList>
          </td>

          </tr>
          <tr>
          <td><label>Vigencia:</label> </td>
          <td>
            <asp:DropDownList ID="CmbVigencia" runat="server" Width="140px" 
                    DataSourceID="ObjVigencias" DataTextField="Year_Vig" 
                    DataValueField="Year_Vig"></asp:DropDownList>
          </td>
          </tr>
           <tr>
                  <td colspan="2">
                      <asp:LoginView ID="LoginView1" runat="server" >
                    <RoleGroups>
                        <asp:RoleGroup>
                        </asp:RoleGroup>
                    </RoleGroups>
                    <LoggedInTemplate>
                        <span style="color:Red"> No puedes acceder a esta opción</span> 
                    </LoggedInTemplate>
                </asp:LoginView>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                 Font-Bold="False" DisplayMode="List"/>
             <asp:label ID="msgResult" runat="server" Font-Bold="False" Height="30px" 
                 Text="" Visible="True" Width="100%"/>

                      </td>

                  </tr>
          </table>
          <div class="imagenboton">
          <asp:button id="cmdEnviar" runat="server" Text="Ingresar" OnClick="cmdEnviar_Click"/>
          </div>
          
             
            </contenttemplate>
        </asp:UpdatePanel>
     </div>
   <asp:ObjectDataSource ID="ObjVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Vigencias"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjModulos" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Modulos"></asp:ObjectDataSource>
    </form>
    
       </body>
</html>


    
     
        
        
</body>
