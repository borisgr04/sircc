﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ContratosxProy.aspx.vb" Inherits="Consultas_ContratosSGR_ContratosxProy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
            <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </ajaxToolkit:ToolkitScriptManager>
     <div>
         <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Consulta de Proyectos"></asp:Label>
         <br />
         <hr />
         <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Consultas/ContratosSGR/ProyectosF12.aspx" runat="server">Formato F12</asp:HyperLink>
         <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Consultas/ContratosSGR/ProyectosF18.aspx" runat="server">Formato F18</asp:HyperLink>
         <hr />
         <br />
         
                    <asp:Label ID="Label11" runat="server" Text="Vigencia"></asp:Label>
                    <asp:DropDownList ID="CmbVig" runat="server" DataSourceID="odsVigencias" DataTextField="YEAR_VIG"
                        DataValueField="YEAR_VIG">
                    </asp:DropDownList>
                    <asp:DropDownList ID="CboTipPro" runat="server">
                        <asp:ListItem Text="Todas" Value=""></asp:ListItem>
                        <asp:ListItem Text="Recursos Propios" Value="RP"></asp:ListItem>
                        <asp:ListItem Text="Sistema General de Regalias" Value="SGR"></asp:ListItem>
                    </asp:DropDownList>
                     <asp:Label ID="Label12" runat="server" Text="Nombre/Número"></asp:Label>
                    <asp:TextBox ID="TxtBuscar" runat="server" Width="387px"></asp:TextBox>
                    <asp:CheckBox ID="ChkHascto" runat="server" Checked="true"/>Con Contrato asociados
                    <asp:Button ID="BtnBuscar" runat="server" ValidationGroup="NoValidar"
                        Text="Buscar" />
                </div>
                <br />
                <br />
                
                <br />
                <asp:GridView ID="GridView1" runat="server"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="Proyecto"
                    EmptyDataText="No se encontraron Registros en la Base de Datos"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None"
                    OnRowDataBound="GridView1_RowDataBound1"
                    Width="90%" >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Vigencia" HeaderText="Vigencia" />
                        <asp:HyperLinkField DataNavigateUrlFields="Proyecto" DataNavigateUrlFormatString="lContratos.aspx?Proyecto={0}" DataTextField="Proyecto" HeaderText="Ver Contratos" />

                        <asp:BoundField DataField="Nombre_Proyecto" HeaderText="Nombre de Proyecto" />
                        <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:c}" />
                        <asp:BoundField DataField="CantxCont" HeaderText="Cantidad de Contratos" />
                        
                        <asp:CommandField ShowSelectButton="True" SelectText="Ver Contratos" />
                    </Columns>
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>

                
    <asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetRecords"
        TypeName="Vigencias" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
</asp:Content>

