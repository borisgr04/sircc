<%@ Page Language="VB" AutoEventWireup="false" CodeFile="consulta.aspx.vb" Inherits="Mobile_Default" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="frmInput" runat="server">
    
 <%--    <mobile:SelectionList runat="server"  Title="Seleccione Vigencia"
            id="SLVigencia" />
   <mobile:SelectionList runat="server" Title="Seleccione Tipo"
            id="SlTipo" />--%>


    <mobile:Label ID="lblPrincipal" Runat="server" EnableViewState="False" >Código</mobile:Label>
        <mobile:TextBox ID="txtCodigo" Runat="server" Numeric="True" MaxLength="10"
            Size="10" Title="Código Contrato">
        </mobile:TextBox>
        <mobile:Command ID="cmdBuscar" Runat="server" OnClick="cmdBuscar_Click">Buscar</mobile:Command>
    </mobile:Form>
     <mobile:Form ID="frmResult" Runat="server" >
        <mobile:Label ID="lblHeadingResult" Runat="server" EnableViewState="False" 
            Wrapping="Wrap"></mobile:Label>
        <br />
        <br />
        <mobile:TextView ID="tvDetalle" Runat="server" EnableViewState="False" >
        </mobile:TextView>
        <mobile:Command ID="Command1" Runat="server" OnClick="cmdBack_Click">Back</mobile:Command>
      <mobile:ObjectList id="List1" runat="server" >
            <DeviceSpecific ID="DeviceSpecific1" Runat="server">
                <!-- See Web.config for filters -->
                <Choice Filter="isWML11" CommandStyle-Font-Bold="NotSet" />
                <Choice CommandStyle-Font-Bold="true" 
                    CommandStyle-Font-Name="Arial" />
            </DeviceSpecific>

            <Command Name="Reserve" Text="Reserve" />
            <Command Name="Buy" Text="Buy" />
        </mobile:ObjectList>
        <mobile:Command ID="cmdBack" Runat="server" OnClick="cmdBack_Click">Back</mobile:Command>
    </mobile:Form>
     <mobile:Form ID="frmError" Runat="server" >
        <mobile:Label ID="lblHeadingError" Runat="server" EnableViewState="False"
            Wrapping="Wrap"></mobile:Label>
        <br />
        <br />
        <mobile:TextView ID="tvError" Runat="server" EnableViewState="False" >
            No se encuentran registros con esos datos!
        </mobile:TextView>        
        <br />
        <mobile:Command ID="cmdHome" Runat="server" OnClick="cmdBack_Click">Home</mobile:Command>        
    </mobile:Form>
</body>
</html>
