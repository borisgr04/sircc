<%@ Page Title="" Language="VB" MasterPageFile="~/MPPublic.master" AutoEventWireup="false" CodeFile="ContratosP.aspx.vb" Inherits="Publico_ContratosP" %>

<%@ Register src="../CtrlUsr/FiltroCon/FiltroCon.ascx" tagname="FiltroCon" tagprefix="uc1" %>

<%@ Register src="../CtrlUsr/FiltroConP/FiltroConP.ascx" tagname="FiltroConP" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Departamento del Cesar. Contratacion"></asp:Label>
    <br />
        <uc2:FiltroConP ID="FiltroConP1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label2" runat="server" SkinID="MsgResult" Text="Label"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="Numero" 
                    EmptyDataText="No se encontraron Registros en la Base de Datos." 
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                    Width="890px" AllowPaging="True" PageSize="5">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Vig_Con" HeaderText="Vigencia" />
                        <asp:BoundField DataField="Numero" HeaderText="Numero" />
                        <asp:BoundField DataField="Contratista" HeaderText="Contratista" />
                        <asp:BoundField DataField="Obj_Con" HeaderText="Objeto" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:ButtonField ButtonType="Image" CommandName="Descargar" HeaderText="Minuta" 
                            ImageUrl="~/images/Operaciones/pdf1.png" Text="Button">
                        <ControlStyle Height="32px" Width="32px" />
                        <ItemStyle Height="32px" Width="32px" />
                        </asp:ButtonField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    <br />
        <asp:ObjectDataSource ID="ObjContratos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetContratos" 
            TypeName="ConsultaPubliContratos">
            <SelectParameters>
                <asp:ControlParameter ControlID="FiltroConP1" Name="Filtro" 
                    PropertyName="Filtro" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

