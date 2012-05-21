<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConRubros.ascx.vb" Inherits="CtrlUsr_Rubros_ConRubros" %>
<%@ Register src="../FiltroPCon/FiltroPCon.ascx" tagname="FiltroPCon" tagprefix="uc1" %>

<style type="text/css">
    .style1
    {
        width: 61px;
    }
    .style2
    {
        width: 86px;
    }
    .style3
    {
        width: 167px;
    }
    .style4
    {
        width: 361px;
    }
</style>

<asp:UpdatePanel ID="UpdateAct" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                 <ContentTemplate>
<div style="padding-left:5%; padding-bottom:5%; padding-right:5%; padding-top:2%;">
    <br />
    <table style="width: 90%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Vigencia</td>
            <td class="style2">
                <asp:Label ID="LbVigencia" runat="server"></asp:Label>
            </td>
            <td class="style3">
                Rubro o Nombre </td>
            <td class="style4">
                <asp:TextBox ID="TxtFil" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton ID="IbtnBucar" runat="server" Height="32px" 
                    SkinID="IBtnBuscar" ValidationGroup="NoValida" Width="32px" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td colspan="4">
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="grdProcesos" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" DataSourceID="ObjRubros" 
        EnableModelValidation="True" Width="90%" DataKeyNames="Cod_Rub,Des_Rub" 
        AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Cod_Rub" HeaderText="Código" 
                SortExpression="Cod_Rub" />
            <asp:BoundField DataField="Des_Rub" HeaderText="Descripcion" 
                SortExpression="Des_Rub" />
            <asp:BoundField DataField="Vigencia" HeaderText="Vigencia" 
                SortExpression="Vigencia" />
            <asp:CommandField ButtonType="Image" 
                SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjRubros" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Rubros">
   
        <SelectParameters>
            <asp:ControlParameter ControlID="LbVigencia" Name="Vigencia" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TxtFil" Name="Rubro" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>            

</ContentTemplate></asp:UpdatePanel>            
