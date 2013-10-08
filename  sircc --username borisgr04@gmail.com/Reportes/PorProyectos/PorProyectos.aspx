<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PorProyectos.aspx.vb" Inherits="Reportes_PorProyectos_PorProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    <div >
            <asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" 
                Text="Proyectos"></asp:Label><BR /><asp:Label id="MsgResult" runat="server" 
                SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
            <asp:Label ID="Label11" runat="server" Text="Vigencia"></asp:Label>
            <asp:DropDownList ID="CmbVig" runat="server" DataSourceID="odsVigencias" DataTextField="YEAR_VIG" 
                    DataValueField="YEAR_VIG">
                    </asp:DropDownList>

            <asp:Label ID="Label12" runat="server" Text="Nombre/Número"></asp:Label>
            <asp:TextBox ID="TxtBuscar" runat="server" Width="387px"></asp:TextBox>
            <asp:Button ID="BtnBuscar" runat="server" ValidationGroup="NoValidar"
                Text="Buscar" />
                </div>
                <asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetRecords"
                        TypeName="Vigencias" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>            
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>

