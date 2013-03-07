<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdPolC.ascx.vb" Inherits="CtrlUsr_grdPolC_grdPolC" %>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CellPadding="4"
    DataKeyNames="Id_Pol,Cod_Pol" EnableModelValidation="True" ForeColor="#333333"
    GridLines="None" Width="100%">
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:BoundField DataField="COD_POL" HeaderText="Id" SortExpression="COD_POL" />
        <asp:BoundField DataField="NOM_POL" HeaderText="Tipo de Amparo" SortExpression="NOM_POL" />
        <asp:BoundField DataField="NOM_ASE" HeaderText="Aseguradora" SortExpression="NOM_ASE" />
        <asp:BoundField DataField="NRO_POL" DataFormatString="{0:g}" HeaderText="Nº Poliza"
            SortExpression="NRO_POL" />
        <asp:BoundField DataField="FEC_INI" DataFormatString="{0:d}" HeaderText="Fecha Inicial"
            SortExpression="FEC_INI" />
        <asp:BoundField DataField="FEC_POL" DataFormatString="{0:d}" HeaderText="Fecha Vencimiento"
            SortExpression="FEC_POL" />
        <asp:BoundField DataField="VAL_POL" DataFormatString="{0:N}" HeaderText="Valor Poliza"
            SortExpression="VAL_POL" />
        <asp:BoundField DataField="COD_ASE" HeaderText="COD_ASE" SortExpression="COD_ASE"
            Visible="False" />
        <asp:BoundField DataField="COD_CON" HeaderText="COD_CON" SortExpression="COD_CON"
            Visible="False" />
        <asp:BoundField DataField="TIP_POL" HeaderText="Legalización" />
        <asp:BoundField DataField="ID_POL" HeaderText="ID_POL" Visible="False" />
        <asp:CommandField DeleteText="Eliminar" 
            SelectImageUrl="~/images/2012/eliminar.png" ShowDeleteButton="True" />
    </Columns>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
<br />
<fieldset id="fspol">
        <legend>Registro de Polizas de Garantia </legend>
        <table>
            <tr>
                <td colspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Label ID="Label1" runat="server" CssClass="SubTitulo" Text="Registre Nuevo Amparo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 174px" class="STitulos" colspan="3">
                    Tipo de Amparo
                </td>
                <td class="STitulos" colspan="3">
                    Aseguradora
                </td>
            </tr>
            <tr>
                <td style="width: 174px; height: 10px" valign="top" colspan="3">
                    <asp:DropDownList ID="CboPol" runat="server" DataValueField="COD_POL" DataTextField="NOM_POL"
                        DataSourceID="ObjPol" CssClass="txt">
                    </asp:DropDownList>
                </td>
                <td style="height: 10px" valign="top" colspan="3">
                    <asp:DropDownList ID="CboAseg" runat="server" DataValueField="COD_ASE" DataTextField="NOM_ASE"
                        DataSourceID="ObjAseg" CssClass="txt">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 188px" class="STitulos">
                    Fecha Inicial (dd/mm/aaaa)
                </td>
                <td style="width: 188px" class="STitulos">
                    Fecha Vencimiento (dd/mm/aaaa)
                </td>
                <td style="width: 188px" class="STitulos">
                    Poliza Nº
                </td>
                <td style="width: 188px" class="STitulos">
                    Valor
                </td>
                <td style="width: 107px" class="STitulos">
                    Tipo
                </td>
                <td class="STitulos" style="width: 190px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 188px; height: 10px">
                    <asp:TextBox ID="TxtFlim" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TxtFlim_CalendarExtender" runat="server" Enabled="True"
                        TargetControlID="TxtFlim">
                    </ajaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TxtFlim" ErrorMessage="*" ValidationGroup="pol"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 188px; height: 10px">
                    <asp:TextBox ID="TxtFlim2" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TxtFlim2_CalendarExtender" runat="server" Enabled="True"
                        TargetControlID="TxtFlim2">
                    </ajaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtFlim2" ErrorMessage="*" ValidationGroup="pol"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TxtFlim" ControlToValidate="TxtFlim2" 
                        ErrorMessage="Fecha de Vencimiento debe ser Mayor a Fecha Final" 
                        Operator="GreaterThan" ValidationGroup="pol">*</asp:CompareValidator>
                </td>
                <td style="width: 188px; height: 10px">
                    <asp:TextBox ID="TxtNPol" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TxtNPol" ErrorMessage="N° Poliza es Requerido" 
                        ValidationGroup="pol">*</asp:RequiredFieldValidator>
                </td>
                <td style="width: 188px; ">
                    <telerik:RadNumericTextBox ID="TxtValP" runat="server" Culture="es-CO" Type="Currency"
                        Width="125px">
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TxtValP" ErrorMessage="Valor es Requerido" 
                        ValidationGroup="pol">*</asp:RequiredFieldValidator>
                </td>
                <td style="width: 107px; height: 10px" valign="top">
                    <asp:DropDownList ID="cboTipPol" runat="server">
                        <asp:ListItem Selected="True" Value="I">Inicial</asp:ListItem>
                        <asp:ListItem Value="A">Ampliación</asp:ListItem>
                        <asp:ListItem Value="M">Modificación</asp:ListItem>
                        <asp:ListItem Value="R">Reducción</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 190px; height: 10px" valign="top">
                    <asp:Button ID="BtnGuardar" runat="server" CausesValidation="False" CssClass="txt"
                        Text="Agregar" ValidationGroup="pol" />
                </td>
            </tr>
            <tr>
                <td style="width: 188px; height: 10px" colspan="2">
                    &nbsp;
                </td>
                <td style="width: 188px; height: 10px">
                    &nbsp;
                </td>
                <td style="width: 107px; height: 10px" valign="top">
                    &nbsp;
                </td>
                <td style="width: 190px; height: 10px" valign="top">
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="True" ShowSummary="False" ValidationGroup="pol" />
    </fieldset>
<asp:ObjectDataSource ID="ObjPol" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetRecords" TypeName="Polizas"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjImp_Contratos" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetRecords" TypeName="Imp_Contratos">
    <SelectParameters>
        <asp:SessionParameter Name="Cod_Con" SessionField="Cod_Con" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjAdic" runat="server" SelectMethod="GetRecords" TypeName="Adiciones">
    <SelectParameters>
        <asp:SessionParameter Name="Cod_Con" SessionField="Cod_Con" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjAseg" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetRecords" TypeName="Aseguradoras"></asp:ObjectDataSource>
