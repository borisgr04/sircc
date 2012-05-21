<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdAdiC.ascx.vb" Inherits="CtrlUsr_grdAdiC_grdAdiC" %>
                            <style type="text/css">
                                .style1
                                {
                                    width: 135px;
                                }
                                .style2
                                {
                                    height: 11px;
                                    width: 135px;
                                }
                                .style4
                                {
                                    height: 11px;
                                    width: 236px;
                                }
                                .style5
                                {
                                    width: 236px;
                                }
                            </style>
                            <p>
                                &nbsp;</p>
                            <asp:GridView ID="grd" runat="server" AllowSorting="True" 
                                AutoGenerateColumns="False" CellPadding="4" 
    DataKeyNames="NRO_ADI" ForeColor="#333333" 
                                GridLines="None" ShowFooter="True">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="N° Documento" >
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NRO_ADI") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tipo Documento" >
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("NOM_tip") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha de Suscripción" >
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" 
                                                Text='<%# Bind("FEC_SUS_ADI", "{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plazo de Ejecución" >
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("PLA_EJE_ADI") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Valor Adición" >
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("VAL_ADI", "{0:c}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="Obser" HeaderText="Observación" />
                                                                        
                                    
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White"  />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>


                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

<br />

<TABLE width="100%"><TBODY><TR><TD style="TEXT-ALIGN: center" class="Titulos" 
        colSpan=5>
    <asp:Label ID="Label7" runat="server" CssClass="SubTitulos" 
        Text="RADICACIÓN DE ADICIONES"></asp:Label>
    </TD></TR><TR><TD style="TEXT-ALIGN: center" class="Titulos" colSpan=5>
                                <asp:Label ID="LbNro_Adi" runat="server" BackColor="Navy" Font-Bold="True" 
                                    Font-Size="12pt" ForeColor="White"></asp:Label>
    </TD></TR><TR><TD style="TEXT-ALIGN: center" class="Titulos" colSpan=5>
        &nbsp;</TD></TR><TR><TD class="style1">Tipo de Documento</TD><TD class="style5">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        DataSourceID="ObjTipAdic" DataTextField="NOM_TIP" DataValueField="COD_TIP">
    </asp:DropDownList>
    </TD><TD class="style5">
            &nbsp;</TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR>
    <TD class="style2">Plazo Adición (Días)</TD><TD class="style4">
        <asp:TextBox ID="TxtPla" runat="server">0</asp:TextBox>
        <ajaxToolkit:FilteredTextBoxExtender ID="TxtPla_FilteredTextBoxExtender" 
            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtPla">
        </ajaxToolkit:FilteredTextBoxExtender>
        </TD><TD class="style4">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TxtPla" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
        </TD><TD style="HEIGHT: 11px" colSpan=2>
        &nbsp;</TD></TR>
    <tr>
        <td class="style1">
            Valor Adición($)</td>
        <td class="style5">
            <asp:TextBox ID="TxtVal" runat="server">0</asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="TxtVal_FilteredTextBoxExtender" 
                runat="server" Enabled="True" FilterType="Custom, Numbers" 
                TargetControlID="TxtVal" ValidChars=".">
            </ajaxToolkit:FilteredTextBoxExtender>
        </td>
        <td class="style5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TxtVal" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
        </td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Fecha de Suscripción</td>
        <td class="style5">
            <asp:TextBox ID="TxtFec" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="TxtFec_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="TxtFec">
            </ajaxToolkit:CalendarExtender>
        </td>
        <td class="style5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TxtFec" 
                ErrorMessage="Es Obligatorio la Fecha de Suscripción"></asp:RequiredFieldValidator>
        </td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Observación</td>
        <td class="style5">
            <asp:TextBox ID="TxtObs" runat="server" Height="68px" TextMode="MultiLine" 
                Width="409px"></asp:TextBox>
        </td>
        <td class="style5">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="5" style="HEIGHT: 10px; TEXT-ALIGN: center">
            <asp:Button ID="BtnRadicar" runat="server" Text="Radicar" />
            <ajaxToolkit:ConfirmButtonExtender ID="BtnRadicar_ConfirmButtonExtender" 
                runat="server" 
                ConfirmText="Confirme Fecha de Suscripción, Plazo y Valor. ¿Confirme si desea radicar la Adición?" 
                Enabled="True" TargetControlID="BtnRadicar">
            </ajaxToolkit:ConfirmButtonExtender>
        </td>
    </tr>
    </TBODY></TABLE>
<asp:DetailsView ID="dtTAdiciones" runat="server" AutoGenerateRows="False" 
    CellPadding="4" ForeColor="#333333" GridLines="None" 
    Height="50px" Width="295px" EnableModelValidation="True" >
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <Fields>
        <asp:BoundField DataField="Total Adicionado" DataFormatString="{0:c}" 
            HeaderText="Total Adicionado" SortExpression="Total Adicionado" />
        <asp:BoundField DataField="Plazo Total" HeaderText="Plazo Total" 
            SortExpression="Plazo Total" />
        <asp:BoundField DataField="% Adición" HeaderText="% Adición" 
            SortExpression="% Adición" />
    </Fields>
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderTemplate>
        INFORMACIÓN CONSOLIDADA DE ADICIONES
    </HeaderTemplate>
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:DetailsView>

<asp:ObjectDataSource ID="ObjTipAdic" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
    TypeName="Tipo_Adciones">
</asp:ObjectDataSource>
                            
                        






