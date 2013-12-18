<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="ProyectosF12.aspx.vb" Inherits="Consultas_ContratosSGR_ProyectosF12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
            <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </ajaxToolkit:ToolkitScriptManager>
     <div>
         <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="FORMATO F12"></asp:Label>
         <br />
         <br />
                    <asp:Label ID="Label11" runat="server" Text="Vigencia"></asp:Label>
                    <asp:DropDownList ID="CmbVig" runat="server" DataSourceID="odsVigencias" DataTextField="YEAR_VIG"
                        DataValueField="YEAR_VIG">
                    </asp:DropDownList>
                    <asp:Button ID="BtnBuscar" runat="server" ValidationGroup="NoValidar" Text="Buscar" />
                    <asp:Button ID="BtnExport" runat="server" ValidationGroup="NoValidar" Text="Exportar" />
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
                    Width="845px" >
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Vigencia" HeaderText="Vigencia" />
                        <asp:HyperLinkField DataNavigateUrlFields="Proyecto" DataNavigateUrlFormatString="lContratos.aspx?Proyecto={0}" DataTextField="Proyecto" HeaderText="Ver Contratos" />
                        <asp:BoundField DataField="Nombre_Proyecto" HeaderText="Nombre de Proyecto" />
                        <asp:BoundField DataField="Valor" HeaderText="Valor Proyecto" DataFormatString="{0:c}" />
                        <asp:BoundField DataField="CantxCont" HeaderText="Cantidad de Contratos" />
                        <asp:BoundField DataField="fechainicio" HeaderText="Fecha Inicial" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="fechafinal" HeaderText="Fecha Final" DataFormatString="{0:d}" />
                        
                        <asp:BoundField DataField="Valor_Contratado" HeaderText="Valor Contratado" DataFormatString="{0:c}"  />
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

