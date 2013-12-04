<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="detTercero.aspx.vb" Inherits="Consultas_ContratosSGR_detTercero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="demoarea">

        <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Consulta de Terceros"></asp:Label>

    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="554px"
         CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" DataSourceID="ObjTerceros" 
         AutoGenerateRows="False">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="Tip_Ide" HeaderText="Tipo Identificación" />
            <asp:BoundField DataField="Ide_Ter" HeaderText="N° Identificación"/>
            <asp:BoundField DataField="Dv_Ter" HeaderText="Digito Verficación"/>
            <asp:BoundField DataField="Nom_Ter" HeaderText="Nombre/Razón Social"/>
            <asp:BoundField DataField="dir_ter" HeaderText="Dirección "/>
            <asp:BoundField DataField="tel_ter" HeaderText="Teléfono "/>
            <asp:BoundField DataField="ema_ter" HeaderText="Correo electrónico "/>
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderTemplate>
                                INFORMACIÓN DEL TERCERO
                            </HeaderTemplate>
    </asp:DetailsView>
    </div>
    <asp:ObjectDataSource ID="ObjTerceros" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetTercero" 
                TypeName="CtrConxProy">
                <SelectParameters>
                    <asp:QueryStringParameter Name="Ide_Ter" QueryStringField="ide_ter" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
</asp:Content>

