<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdAdiC.ascx.vb" Inherits="CtrlUsr_grdAdiC_grdAdiC" %>
<br /><br />
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

<br />
                            

                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

<telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="0" 
    Skin="Windows7" MultiPageID="RadMultiPage1">
    <Tabs>
        <telerik:RadTab runat="server" Text="Radicación" Selected="True">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Histórico de Modificatorios">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage ID="RadMultiPage1" Runat="server" SelectedIndex="0">
    <telerik:RadPageView ID="RadPageView1" runat="server">
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <TABLE width="100%"><TBODY><TR>
    <TD style="TEXT-ALIGN: center" class="Titulos" 
        colSpan=10>
    <asp:Label ID="Label7" runat="server" CssClass="SubTitulo" 
        Text="RADICACIÓN DE ADICIONES"></asp:Label>
    </TD></TR><TR><TD style="TEXT-ALIGN: center" class="Titulos" colSpan=10>
                                <asp:Label ID="LbNro_Adi" runat="server" BackColor="Navy" Font-Bold="True" 
                                    Font-Size="12pt" ForeColor="White"></asp:Label>
    </TD></TR><TR><TD style="TEXT-ALIGN: center" class="Titulos" colSpan=10>
        &nbsp;</TD></TR><TR><TD class="style1" colspan="2">Tipo de Documento</TD>
        <TD class="style5" colspan="2">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        DataSourceID="ObjTipAdic" DataTextField="NOM_TIP" DataValueField="COD_TIP">
    </asp:DropDownList>
    </TD><TD class="style5" colspan="2">
            &nbsp;</TD><TD style="WIDTH: 100px" colspan="2"></TD>
        <TD style="WIDTH: 100px" colspan="2"></TD></TR><TR>
    <TD class="style2" colspan="2">Plazo Adición (Días)</TD><TD class="style4" 
        colspan="2">
        <telerik:RadNumericTextBox ID="TxtPla" Runat="server" Culture="es-CO" 
            DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
        </telerik:RadNumericTextBox>
        </TD><TD class="style4" colspan="2">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TxtPla" ErrorMessage="Campo requerido" 
            ValidationGroup="rad"></asp:RequiredFieldValidator>
        </TD><TD style="HEIGHT: 11px" colSpan=4>
        &nbsp;</TD></TR>
    <tr>
        <td class="style1" colspan="2">
            Valor Adición($)</td>
        <td class="style5" colspan="2">
            <telerik:RadNumericTextBox ID="TxtVal" Runat="server" Culture="es-CO" 
                DbValueFactor="1" LabelWidth="64px" Type="Currency" Value="0" Width="160px">
<NumberFormat ZeroPattern="$ n"></NumberFormat>
            </telerik:RadNumericTextBox>
        </td>
        <td class="style5" colspan="2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TxtVal" ErrorMessage="Campo requerido" 
                ValidationGroup="rad"></asp:RequiredFieldValidator>
        </td>
        <td colspan="4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1" colspan="2">
            Fecha de Suscripción</td>
        <td class="style5" colspan="2">
            <asp:TextBox ID="TxtFec" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="TxtFec_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="TxtFec">
            </ajaxToolkit:CalendarExtender>
        </td>
        <td class="style5" colspan="2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TxtFec" 
                ErrorMessage="Es Obligatorio la Fecha de Suscripción" 
                ValidationGroup="rad"></asp:RequiredFieldValidator>
        </td>
        <td colspan="4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1" colspan="2">
            Observación/Objeto del Documento</td>
        <td class="style5" colspan="2">
            <asp:TextBox ID="TxtObs" runat="server" Height="68px" TextMode="MultiLine" 
                Width="409px"></asp:TextBox>
        </td>
        <td class="style5" colspan="2">
            &nbsp;</td>
        <td colspan="4">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="10" style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            <asp:ImageButton ID="BtnGuardar" runat="server" SkinID="IBtnGuardar" />
        </td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            Guardar</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td style="HEIGHT: 10px; TEXT-ALIGN: center">
            &nbsp;</td>
    </tr>
    </TBODY></TABLE>
        
        &nbsp;&nbsp;&nbsp;
    </telerik:RadPageView>
<telerik:RadPageView ID="RadPageView2" runat="server">
    
    &nbsp;&nbsp;&nbsp;
    <br />
    
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label8" runat="server" CssClass="SubTitulo" 
        Text="LISTADO DE MODIFICATORIOS"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;
    <br />
    
    &nbsp;&nbsp;&nbsp;
    <asp:GridView ID="grd" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="NRO_ADI" EnableModelValidation="True" ShowFooter="True" Width="100%"><Columns><asp:TemplateField HeaderText="N° Documento"><ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("NRO_ADI") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField><asp:TemplateField HeaderText="Tipo Documento"><ItemTemplate><asp:Label ID="Label6" runat="server" Text='<%# Bind("NOM_tip") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField><asp:TemplateField HeaderText="Fecha de Suscripción"><ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%# Bind("FEC_SUS_ADI", "{0:d}") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField><asp:TemplateField HeaderText="Plazo de Ejecución"><ItemTemplate><asp:Label ID="Label3" runat="server" Text='<%# Bind("PLA_EJE_ADI") %>'></asp:Label>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField><asp:TemplateField HeaderText="Valor Adición"><ItemTemplate><asp:Label ID="Label4" runat="server" Text='<%# Bind("VAL_ADI", "{0:c}") %>'></asp:Label>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField><asp:TemplateField HeaderText="Observación" ItemStyle-Width="50%"><EditItemTemplate><asp:TextBox ID="txtEditObs" runat="server" Rows="4" Text='<%# Bind("Obser") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Obser") %>'></asp:Label>
        </ItemTemplate>
        <ItemStyle Width="50%" />
        </asp:TemplateField><asp:ButtonField ButtonType="Image" CommandName="editar" ImageUrl="~/images/2012/edit.png" Text="Editar" Visible="False" /><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:ImageButton ID="IbtnEliminar" runat="server" CausesValidation="false" CommandArgument='<%# Right(Eval("Nro_Adi"),2) %>' CommandName="eliminar" ImageUrl="~/images/Operaciones/delete2.png" OnClientClick="return confirm('Confirme si quiere Eliminar el Registro?');" Text="Eliminar" visible='<%#IIF((DataBinder.Eval(Container.DataItem, "Ult")="1"),True,False)%>' />
        </ItemTemplate>
        </asp:TemplateField><asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    


</telerik:RadPageView>
</telerik:RadMultiPage>

<br />


<asp:ObjectDataSource ID="ObjTipAdic" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
    TypeName="Tipo_Adciones">
</asp:ObjectDataSource>
                            
                        






