<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConDocContratosE.ascx.vb" Inherits="Controles_ConDocContratosE" %>
<style type="text/css">


.Titulos
{
    background-color:#EBEBEB;
    height: 30px;
    color:#3A4C87;
    font-weight:bolder;
}

td
{
    height:10px;
    empty-cells:show;
    text-align:left;
    vertical-align:top;
        }

    .style1
    {
        width: 150px;
    }
    
</style>


<br />

<asp:Label ID="MsgR" runat="server" SkinID="MsgResult"></asp:Label>
    <table id="Table2" >
        <tr>
            <td class="style1" >
                <asp:ImageButton ID="IBtnDescargar" runat="server" 
                    ImageUrl="~/images/BlueTheme/Descargar.png" />
            </td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" >
                <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
            </td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" >
                Descargar Todo</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 21px" colspan="7">
    <asp:GridView ID="GridView1" runat="server"
        DataSourceID="ObjDoc" CellPadding="4" Width="100%" ToolTip="Listado de Documentos Anexos al Contrato" 
                    AllowSorting="True" DataKeyNames="ID" ForeColor="#333333" GridLines="None" 
                    AutoGenerateColumns="False" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Nom_Eta" HeaderText="Etapa" 
                SortExpression="Nom_Eta" />
            <asp:BoundField DataField="Nom_Documento" HeaderText="Documento" 
                SortExpression="Nom_Documento" />
            <asp:BoundField DataField="Observacion" HeaderText="Observación" 
                SortExpression="Observacion" />
            <asp:BoundField DataField="Fecha_Documento" HeaderText="Fecha Documento" 
                Visible="False" />
            <asp:BoundField DataField="Tamaño" HeaderText="Tamaño en KB" 
                SortExpression="Tamaño">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Fec_REg" HeaderText="Fecha de Cargue" 
                SortExpression="fec_reg" />
            <asp:CommandField ShowSelectButton="True" ButtonType="Image" 
                SelectImageUrl="~/images/mnProcesos/open-icon32.png" />
            <asp:ButtonField ButtonType="Image" CommandName="eliminar" 
                ImageUrl="~/images/Operaciones/delete2.png" Text="Button" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
            </td>
        </tr>
    </table>


                <asp:ObjectDataSource ID="ObjDoc" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDoc_Contratos" 
                    TypeName="DocContratos">
                    <SelectParameters>
                        <asp:SessionParameter Name="cod_con" SessionField="Cod_Con" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <br />
    &nbsp;