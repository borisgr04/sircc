<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConConsorcios.aspx.vb" Inherits="Consultas_ConConsorcios_ConConsorcios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <br />
    <asp:Label ID="Label2" runat="server" CssClass="Titulo" 
        Text="Consulta de Terceros en Consorcios y Uniones Temporales"></asp:Label>
    <br />
        <br />
    <asp:Label ID="Label1" runat="server" Text="Buscar"></asp:Label>
    <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
    <asp:Button ID="BtnConsultar" runat="server" Text="Consultar" />
        <br />
        <br />
    <asp:GridView ID="grdConsorcios" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="COD_CON" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="IDE_TER" HeaderText="ID Consorcio/UT" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre Consorcio/UT" />
            <asp:BoundField DataField="ID_Miembros" HeaderText="ID Miembro" />
            <asp:BoundField DataField="Miembro" HeaderText="Nombre Miembro" />
            <asp:BoundField DataField="COD_CON" HeaderText="Contratos N°" />
            <asp:BoundField DataField="PORC_PART" HeaderText="Porcentaje" />
            <asp:BoundField DataField="Obj_Con" HeaderText="Objeto del Contrato" />
            <asp:CommandField SelectText="Ver Detalle" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
&nbsp;
    </div>
</asp:Content>

