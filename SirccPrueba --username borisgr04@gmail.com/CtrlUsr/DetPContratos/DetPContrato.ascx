<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DetPContrato.ascx.vb" Inherits="Controles_DetPContrato" %>
<style type="text/css">


td
{
    height:10px;
    empty-cells:show;
    text-align:left;
    vertical-align:top;
        }

.txt
{
    font-size: 9pt;
}
</style>
            <table style="width: 610px">
                <tr>
                    <td style="width: 509px; height: 14px; text-align: center">
                        <asp:ObjectDataSource ID="ObjPContratos" runat="server"  
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByPkMod" 
                            TypeName="PContratos" InsertMethod="InsertP">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtCodCon" Name="Num_PCon" PropertyName="Text" 
                                    Type="String" />
                            </SelectParameters>
                            <InsertParameters>
                                <asp:Parameter Name="COD_TPRO" Type="String" />
                                <asp:Parameter Name="OBJ_CON" Type="String" />
                                <asp:Parameter Name="DEP_CON" Type="String" />
                                <asp:Parameter Name="DEP_PCON" Type="String" />
                                <asp:Parameter Name="VIG_CON" Type="Decimal" />
                                <asp:Parameter Name="TIP_CON" Type="String" />
                                <asp:Parameter Name="STIP_CON" Type="String" />
                                <asp:Parameter Name="FEC_RECIBIDO" Type="DateTime" />
                                <asp:Parameter Name="NUM_SOL" Type="String" />
                            </InsertParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td colspan="1" style="width: 509px; height: 14px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 509px; height: 14px; text-align: center;">
                        &nbsp; <strong>N°PROCESO</strong></td>
                    <td colspan="1" style="width: 509px; height: 14px">
                        <asp:TextBox ID="TxtCodCon" runat="server" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="IbtnBuscar" runat="server" 
                            ImageUrl="~/images/Operaciones/Search.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 14px; text-align: center;">
                        <asp:Label ID="MsgResult" runat="server" Height="30px" Visible="False" 
                            Width="90%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" 
                            CellPadding="4" DataKeyNames="Cod_Tpro" 
                            EnableModelValidation="True" Font-Size="X-Small" ForeColor="#333333" 
                            GridLines="None" Height="84px" Width="95%">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <Fields>
                                <asp:BoundField DataField="Nom_TProc" HeaderText="Tipo de Proceso" 
                                    SortExpression="Nom_TProc" />
                                <asp:BoundField DataField="PRO_SEL_NRO" HeaderText="N° Proceso " 
                                    SortExpression="PRO_SEL_NRO" >
                                    <ItemStyle Font-Bold="True" Font-Size="Medium" />
                                     </asp:BoundField>
                                <asp:BoundField DataField="OBJ_CON" HeaderText="Objeto" 
                                    SortExpression="OBJ_CON" />
                                <asp:BoundField DataField="PLA_EJE_CON" HeaderText="Plazo de Ejecución" 
                                    SortExpression="PLA_EJE_CON" />
                                <asp:BoundField DataField="VAL_CON" DataFormatString="{0:c}" 
                                    HeaderText="Valor " SortExpression="VAL_CON" />
                                <asp:BoundField DataField="Dep_Nec" 
                                    HeaderText="Dependencia que Genera la Necesidad" SortExpression="Dep_Nec" />
                                <asp:BoundField DataField="Dep_Del" 
                                    HeaderText="Dependencia a Cargo del Proceso" SortExpression="Dep_Del" />
                                <asp:BoundField DataField="Encargado" 
                                    HeaderText="Funcionario Encargado" SortExpression="Encargado" />
                                <asp:BoundField DataField="Nom_Est" 
                                    HeaderText="Estado del Proceso" SortExpression="Nom_Est" >
                                <ItemStyle Font-Bold="True" Font-Size="Medium" />
                                </asp:BoundField>
                            </Fields>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderTemplate>
                                INFORMACIÓN DETALLADA DEL PROCESO DE CONTRATACIÓN
                            </HeaderTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:DetailsView>
                    </td>
                </tr>
            </table>
        



                

    
    