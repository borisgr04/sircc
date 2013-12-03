<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="lContratos.aspx.vb" Inherits="Consultas_ContratosSGR_lContratos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </ajaxToolkit:ToolkitScriptManager>
    <asp:GridView ID="GridView1" runat="server"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="Cod_Con"
                    EmptyDataText="No se encontraron Registros en la Base de Datos"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None"
                    OnRowDataBound="GridView1_RowDataBound1"
                    Width="845px" AllowPaging="True" DataSourceID="ObjProyectos">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Obj_Con" HeaderText="Objeto" />
                        <asp:HyperLinkField DataNavigateUrlFields="cod_con" DataNavigateUrlFormatString="contratos.aspx?Numero={0}" DataTextField="cod_con" HeaderText="Ver Detalles" />
                    </Columns>
                    
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>

                <asp:ObjectDataSource ID="ObjProyectos" runat="server" TypeName="CtrConxProy"
                    SelectMethod="GetContratos" OldValuesParameterFormatString="original_{0}"  >
                    <SelectParameters>
                        <asp:QueryStringParameter Name="Proyecto" QueryStringField="proyecto" Type="String" />
                    </SelectParameters>

                </asp:ObjectDataSource>
</asp:Content>

