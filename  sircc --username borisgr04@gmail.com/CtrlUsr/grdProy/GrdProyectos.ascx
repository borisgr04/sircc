<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GrdProyectos.ascx.vb" Inherits="CtrlUsr_grdProy_WebUserControl" %>
<style type="text/css">
    .style1
    {
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="Proyectos"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1" colspan="3">
            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="Proyecto" DataSourceID="Proyectos" Width="774px">
                <Columns>
                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" 
                        SortExpression="Proyecto" />
                    <asp:BoundField DataField="Nombre_Proyecto" HeaderText="Nombre del Proyecto" 
                        SortExpression="Nombre_Proyecto" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="Proyectos" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                TypeName="PProyectos">
                <SelectParameters>
                    <asp:SessionParameter Name="Num_Proc" SessionField="DP.Cod_TProc" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
