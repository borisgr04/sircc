<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConProyectos.ascx.vb" Inherits="CtrlUsr_grdProyectos_ConProyectos" %>
<%@ Register src="../FiltroPCon/FiltroPCon.ascx" tagname="FiltroPCon" tagprefix="uc1" %>

<style type="text/css">
    .style1
    {
        width: 291px;
    }
    .style3
    {
        width: 72px;
    }
    .style4
    {
        height: 71px;
        text-align: left;
    }
    .style6
    {
        width: 26px;
    }
    .style8
    {
        width: 385px;
    }
</style>

<asp:UpdatePanel ID="UpdateAct" runat="server" UpdateMode="Conditional">
                 <ContentTemplate>
<div style="padding-left:5%; padding-bottom:5%; padding-right:5%; padding-top:2%;">
    <table style="width:100%;">
        <tr>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text="Proyecto"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="TxtFiltrar" runat="server" Width="283px" AutoPostBack="True"></asp:TextBox>
            </td>
            <td class="style6">
                <asp:ImageButton ID="IbtnBucar" runat="server" Height="32px" 
                    SkinID="IBtnBuscar" ValidationGroup="NoValida" Width="32px" />
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" colspan="4">
                <asp:GridView ID="grdProcesos" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" DataKeyNames="Proyecto,Nombre_Proyecto" DataSourceID="ObjProyectos" 
                    EmptyDataText="No hay Proyectos Disponibles" EnableModelValidation="True" 
                    Width="90%">
                    <Columns>
                        <asp:BoundField DataField="Vigencia" HeaderText="Vigencia" 
                            SortExpression="Vigencia" />
                        <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" 
                            SortExpression="Proyecto" />
                        <asp:BoundField DataField="Nombre_Proyecto" HeaderText="Nombre del Proyecto" 
                            SortExpression="Nombre_Proyecto" />
                        <asp:BoundField DataField="Fecha_Rad" HeaderText="Fecha de Radicación" 
                            SortExpression="Fecha_Rad" />
                        <asp:BoundField DataField="Comite" HeaderText="Comite" 
                            SortExpression="Comite" />
                        <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjProyectos" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetProyectos" 
        TypeName="Proyectos">
   
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFiltrar" Name="Proyecto" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>            

</ContentTemplate>
                 <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="grdProcesos" 
                         EventName="SelectedIndexChanged" />
                 </Triggers>
</asp:UpdatePanel>            
