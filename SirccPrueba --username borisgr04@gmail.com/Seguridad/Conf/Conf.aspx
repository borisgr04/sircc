<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Conf.aspx.vb" Inherits="Seguridad_Conf_Conf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    <asp:Label ID="Label1" runat="server" Text="Sentencia"></asp:Label>
        <br />
        <br />
        <br />
    <asp:TextBox ID="TxtSql" runat="server" TextMode="MultiLine" Height="132px" 
            Width="715px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Ejecutar Select" />
    <asp:GridView ID="grdResult" runat="server" DataSourceID="ObjSql" 
            EnableModelValidation="True">
    </asp:GridView>
        <asp:ObjectDataSource ID="ObjSql" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetSelect" 
            TypeName="BDDatos">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtSql" Name="Sql" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    <asp:TextBox ID="TxtSql0" runat="server" TextMode="MultiLine" Height="132px" 
            Width="715px"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Ejecutar Sentencia" />
        <br />
        <asp:Label ID="LbResult" runat="server"></asp:Label>
</div>
</asp:Content>

