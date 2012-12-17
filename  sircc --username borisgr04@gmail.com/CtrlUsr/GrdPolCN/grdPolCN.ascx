<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdPolCN.ascx.vb" Inherits="CtrlUsr_grdPolC_grdPolCN" %>
                        <p>
                            <asp:GridView ID="grd" runat="server" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Pol,Cod_Pol" 
                                EnableModelValidation="True" ForeColor="#333333" 
                                GridLines="None" 
                                Width="100%">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="COD_POL" HeaderText="Id" SortExpression="COD_POL" />
                                    <asp:BoundField DataField="NOM_POL" HeaderText="Tipo de Amparo" 
                                        SortExpression="NOM_POL" />
                                    <asp:BoundField DataField="NOM_ASE" HeaderText="Aseguradora" 
                                        SortExpression="NOM_ASE" />
                                    <asp:BoundField DataField="NRO_POL" DataFormatString="{0:g}" 
                                        HeaderText="Nº Poliza" SortExpression="NRO_POL" />
                                    <asp:BoundField DataField="FEC_POL" DataFormatString="{0:d}" 
                                        HeaderText="Fecha Vencimiento" SortExpression="FEC_POL" />
                                    <asp:BoundField DataField="VAL_POL" DataFormatString="{0:N}" 
                                        HeaderText="Valor Poliza" SortExpression="VAL_POL" />
                                    <asp:BoundField DataField="COD_ASE" HeaderText="COD_ASE" 
                                        SortExpression="COD_ASE" Visible="False" />
                                    <asp:BoundField DataField="COD_CON" HeaderText="COD_CON" 
                                        SortExpression="COD_CON" Visible="False" />
                                    <asp:BoundField DataField="TIP_POL" HeaderText="Legalización" />
                                    <asp:BoundField DataField="ID_POL" HeaderText="ID_POL" Visible="False" />
                                    <asp:CommandField DeleteText="Eliminar" SelectImageUrl="~/images/eliminar.png" 
                                        ShowDeleteButton="True" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <table>
                            <tr><td  colspan="5">&nbsp;</td>
                                </tr>
                            <tr><td colspan="5">
                                <asp:Label ID="Label1" runat="server" CssClass="SubTitulo" 
                                    Text="Registre Nuevo Amparo"></asp:Label>
                                </td>
                                </tr>
                            <tr><td style="WIDTH: 174px" class="STitulos" colspan="2">Tipo de Amparo</td>
            <td 
                        class="STitulos" colspan=3>Aseguradora</TD></TR>
        <tr><td style="WIDTH: 174px; HEIGHT: 10px" vAlign="top" colspan="2"><asp:DropDownList id="CboPol" 
                runat="server" DataValueField="COD_POL" DataTextField="NOM_POL" 
                DataSourceID="ObjPol" CssClass="txt">
                            </asp:DropDownList></TD>
            <TD style="HEIGHT: 10px" 
                        vAlign=top colSpan=3>
                <asp:DropDownList id="CboAseg" runat="server" DataValueField="COD_ASE" 
                    DataTextField="NOM_ASE" DataSourceID="ObjAseg" CssClass="txt">
                            </asp:DropDownList></TD></TR><TR>
            <TD style="WIDTH: 188px" class="STitulos">Fecha Vencimiento 
                (dd/mm/aaaa)</TD>
            <TD style="WIDTH: 188px" class="STitulos">Poliza Nº</TD>
            <TD style="WIDTH: 188px" class="STitulos">Valor</TD>
            <TD style="WIDTH: 107px" class="STitulos">Tipo</TD>
            <td class="STitulos" style="WIDTH: 190px">
                &nbsp;</td>
        </TR>
        <TR><TD style="WIDTH: 188px; HEIGHT: 10px"><asp:TextBox ID="TxtFlim" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="TxtFlim_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="TxtFlim">
            </ajaxToolkit:CalendarExtender>
            </TD>
            <TD style="WIDTH: 188px; HEIGHT: 10px">
                <asp:TextBox ID="TxtNPol" runat="server"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 188px; HEIGHT: 10px">
                <asp:TextBox ID="TxtValP" runat="server"></asp:TextBox>
                 <ajaxToolkit:FilteredTextBoxExtender ID="txtNewValP_FilteredTextBoxExtender" 
                                                runat="server" 
                                                Enabled="True" 
                                                TargetControlID="TxtValP" 
                                                FilterType="Custom, Numbers"
                                                ValidChars=".">     </ajaxToolkit:FilteredTextBoxExtender>
            </TD>
            <TD style="WIDTH: 107px; HEIGHT: 10px" valign=top>
                <asp:DropDownList ID="cboTipPol" runat="server">
                    <asp:ListItem Selected="True" Value="I">Inicial</asp:ListItem>
                    <asp:ListItem Value="A">Ampliación</asp:ListItem>
                    <asp:ListItem Value="M">Modificación</asp:ListItem>
                    <asp:ListItem Value="R">Reducción</asp:ListItem>
                </asp:DropDownList>
            </TD>
            <td style="WIDTH: 190px; HEIGHT: 10px" valign="top">
                <asp:Button ID="BtnGuardar" runat="server" CausesValidation="False" CssClass="txt" 
                    Text="Agregar" />
            </td>
        </TR>
        <TR><TD style="WIDTH: 188px; HEIGHT: 10px" colspan="2">
                &nbsp;</TD>
            <TD style="WIDTH: 188px; HEIGHT: 10px">
                &nbsp;</TD>
            <TD style="WIDTH: 107px; HEIGHT: 10px" vAlign=top>
                &nbsp;</TD>
            <td style="WIDTH: 190px; HEIGHT: 10px" valign="top">
                &nbsp;</td>
        </TR>
                            </table>
                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

<asp:ObjectDataSource ID="ObjPol" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyPk" 
    TypeName="PolizasContratos">
    <SelectParameters>
        <asp:ControlParameter ControlID="HiddenField1" Name="Num_Proc" 
            PropertyName="Value" Type="String" />
        <asp:ControlParameter ControlID="HiddenField2" Name="Grupo" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                        </p>

<asp:ObjectDataSource ID="ObjImp_Contratos" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
    TypeName="Imp_Contratos">
    <SelectParameters>
            <asp:SessionParameter Name="Cod_Con" SessionField="Cod_Con" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
 <asp:ObjectDataSource ID="ObjAdic" runat="server" SelectMethod="GetRecords" TypeName="Adiciones">
    <SelectParameters>
        <asp:SessionParameter Name="Cod_Con" SessionField="Cod_Con" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>




<asp:ObjectDataSource ID="ObjAseg" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
    TypeName="Aseguradoras">
</asp:ObjectDataSource>
                        




