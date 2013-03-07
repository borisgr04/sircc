<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Copy of Login.aspx.vb" Inherits="Login" EnableTheming="True" %>
<%@ OutputCache Location="None" VaryByParam="None" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="images/icono/favicon.ico">
    <link rel="icon" type="image/gif" href="images/icono/animated_favicon1.gif">
    <style type="text/css">
        .style2
        {
            width: 84px;
            text-align: right;
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>       
    <div class="demoarea" style="text-align: left; top:0px"  >
        <table cellpadding="0" cellspacing="0" class="TbCenter">
            <tr>
                <td class="header"  style="height: 65px; " colspan="3">
                    <div style="left: 10px; width: 50px; position: relative; top: -28px;
                               height: 1px">
                        </div>
                       <div style="z-index: 106; left: 10px; width: 50px; position: relative; top: 8px;">
                        <asp:Image ID="Image1" runat="server" SkinID="ImgLogo"  style="width: 46px; height: 40px; top:-30px;" />
                       </div>
                       <div style="z-index: 106; left: -19px; width: 70px; position: relative; float:right; top: -17px;">
                        <asp:Image ID="Image5" runat="server" 
                            ImageUrl="~/images/BlueTheme/LogoEmpresa.png" Width="100%" />    
                       </div>
                       <div style="z-index: 106; left: 77px; width: 760px; position: relative; top: -30px;
                               height: 10px"><asp:Label runat="server" ID="LbNomProg" Font-Size="Larger"> 
                               SIRCC&reg 2011 - Sistema de Radicación y Control de Contratos</asp:Label>
                       </div>
                       
                    </div>
                                        </td>
            </tr>
            <tr>
                    <td style="width: 5px;" class="TbFondoI" valign="top">
                        </td>
                    <td>
                    <div style="text-align: center; width:430px; height: 98px;"  class="LogContenido">
                        <br />
                    <asp:Label ID="Label4" runat="server" CssClass="LogTitulo"></asp:Label><br />
                        <br />
                        
                        <asp:Label ID="Label6" runat="server" Text="Sistema de Información de Registro y Control de Contratos"></asp:Label>
                        
                        <br />
                    <br />
                        &nbsp;<div>
                        </div>
                        </div>
                        
                    <br />
                    <br />
                    

                    <div  style="text-align: justify; width:475px ; height: 214px;" >
                        
                    </div>
                    <br />
                    &nbsp;<asp:Image ID="Image3" runat="server"  ImageUrl="~/images/Login/Img_gob.jpg"
                        Width="70%" Height="70%" /></td>
                <td style="width: 213px; text-align: justify; height: 466px;" class="TbFondo" valign="top">
                        <br />
                        <br />
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
    <table style="WIDTH: 250px; text-align: right;"  cellpadding="2" border="0">
    <tbody>
    <tr>
        <td colspan="2" align="left"><br />
        &nbsp;</TD>
    </tr>
    <tr>
        <td class="LogTitulo" colspan="2" align="left" style="text-align: center" 
            valign="top">
        CONTROL DE ACCESO &nbsp;
            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Login/Password.png" /></TD></TR><TR><TD style="WIDTH: 84px; text-align: right; height: 30px;" align="left"><asp:Label id="Label1" runat="server" Text="Usuario" Font-Bold="False"></asp:Label></TD>
            <TD style="text-align: left; width: 302px; height: 30px;" align="left">
            <asp:TextBox id="TxtUsername" runat="server" Width="142px"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtUsername" ErrorMessage="El Nombre de Usuario es Requeirdo" Display="Dynamic">*</asp:RequiredFieldValidator></TD></TR>
    <tr>
        <td style="width: 84px; text-align: right" align="left">
            <asp:Label id="Label2" runat="server" Text="Contraseña" Font-Bold="False"></asp:Label></td>
        <td style="text-align: left; width: 302px;" align="left">
            <asp:TextBox id="TxtClave" runat="server" Width="141px" TextMode="Password" autocomplete="off" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TxtClave" ErrorMessage="La Contraseña es requerida" Display="Dynamic">*
            </asp:RequiredFieldValidator></td>
    </tr>
    <tr>
       <td align="left" class="style2">
           Módulo</TD>
        <td style="text-align: left; width: 302px;" align="left">
            <asp:DropDownList ID="CboMod" runat="server" DataTextField="Nom_Mod" 
                DataValueField="Cod_Mod" DataSourceID="ObjModulos" Width="142px">
            </asp:DropDownList>
        </TD>
     </TR>
        <tr>
            <td align="left" style="WIDTH: 84px; text-align: right;">
                <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Vigencia"></asp:Label>
            </td>
            <td align="left" style="text-align: left; width: 302px;">
                <asp:DropDownList ID="CmbVigencia" runat="server" Width="142px" 
                    DataSourceID="ObjVigencias" DataTextField="Year_Vig" 
                    DataValueField="Year_Vig">
                </asp:DropDownList>
            </td>
        </tr>
     <tr>
         <td style="WIDTH: 84px;" align="left" colspan="2">
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                 Font-Bold="False" DisplayMode="SingleParagraph" />
             <asp:Label ID="msgResult" runat="server" Font-Bold="False" Height="30px" 
                 Text="" Visible="True" Width="100%"></asp:Label>
         </TD>
      </TR>
        <tr>
            <td align="left" colspan="2" style="text-align: center;">
                <asp:LoginView ID="LoginView1" runat="server">
                    <RoleGroups>
                        <asp:RoleGroup>
                        </asp:RoleGroup>
                    </RoleGroups>
                    <LoggedInTemplate>
                        No puedes acceder a esta opción
                    </LoggedInTemplate>
                </asp:LoginView>
            </td>
        </tr>
    <tr>
        <td align="left" style="width: 84px; height: 28px;"> </td>
        <td align="left" style="width: 89px; height: 28px;"> <asp:Button id="cmdEnviar" runat="server" Text="Iniciar Sesión" OnClick="cmdEnviar_Click"></asp:Button></td>
    </tr>
        <tr>
            <td align="left" colspan="2" style="height: 28px; text-align: center">
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/Publico/RecupClave.aspx" Visible="False">¿Ha olvidado su contraseña?</asp:HyperLink></td>
        </tr>
    </TBODY>
    </TABLE> 
                
<!--- -->
    <%--<ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Digite Nombre de Usuario" runat="server" TargetControlID="TxtUsername" WatermarkCssClass="watermarked">
    </ajaxToolkit:TextBoxWatermarkExtender><ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender2" watermarkText="Contraseña" runat="server" TargetControlID="TxtClave" WatermarkCssClass="watermarked">
    </ajaxToolkit:TextBoxWatermarkExtender>--%>
   
         </contenttemplate>
        </asp:UpdatePanel>
                  
            </td>
     </tr>
            
      <tr>
                <td colspan="3">   
                    <asp:Image ID="Image4" runat="server"  SkinId="ImgFoot" Width="100%" Height="40px" /></td>
         </tr>
        
        &nbsp; &nbsp;&nbsp;&nbsp;<asp:ObjectDataSource ID="ObjVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Vigencias"></asp:ObjectDataSource>
        &nbsp;&nbsp;
        <asp:ObjectDataSource ID="ObjModulos" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Modulos"></asp:ObjectDataSource>
                
    </form>
</body>
</html>
