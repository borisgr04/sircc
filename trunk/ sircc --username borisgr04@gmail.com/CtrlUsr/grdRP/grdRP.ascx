<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdRP.ascx.vb" Inherits="CtrlUsr_grdRP_grdRP" %>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
 CellPadding="4" DataKeyNames="nro_rp" 
    ForeColor="#333333" GridLines="None" 
                                ShowFooter="True" EnableModelValidation="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                  <asp:TemplateField HeaderText="N° Rp" SortExpression="Nro_Rp">
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewNro_Rp" runat="server"  Width="100%"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtNewNro_Rp_FilteredTextBoxExtender" 
                                                runat="server" 
                                                Enabled="True" 
                                                TargetControlID="txtNewNro_Rp" 
                                                FilterType="Numbers"
                                                ValidChars="">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LbNro_Rp" runat="server" Text='<%# Bind("Nro_Rp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Rp" SortExpression="Fec_Rp">
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewFec_Rp" runat="server"  Width="100%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtNewFec_Rp_CalendarExtender" 
                                                runat="server" Enabled="True" TargetControlID="txtNewFec_Rp">
                                            </ajaxToolkit:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LbFec_Rp" runat="server" Text='<%# Eval("Fec_Rp","{0:d}") %>'  ></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Valor Rp" SortExpression="Val_Rp">
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewVal_Rp" runat="server" Width="100%"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtNewVal_Rp_FilteredTextBoxExtender" 
                                                runat="server" 
                                                Enabled="True" 
                                                TargetControlID="txtNewVal_Rp" 
                                                FilterType="Custom, Numbers"
                                                ValidChars=".">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </FooterTemplate>
                                        <ItemTemplate >
                                            <asp:Label ID="Label29" runat="server" Text='<%# Bind("Val_Rp","{0:c}") %>' ></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Documento Soporte" SortExpression="Doc_Sop">
                                        <FooterTemplate>
                                            <asp:DropDownList ID="CboNewDoc_Sop" runat="server" AppendDataBoundItems="True" DataSourceID="ObjAdic" 
                                                    DataTextField="NRO_ADI" DataValueField="NRO_ADI">
                                    <asp:ListItem>Contrato</asp:ListItem>
                                </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Doc_Sop") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" 
                                                CommandName="AddNew" Text="Agregar..." ForeColor="White"></asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White"  />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        
                        
                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                        
                        <asp:ObjectDataSource ID="ObjAdic" runat="server" SelectMethod="GetRecords" 
                                TypeName="Adiciones">
                                <SelectParameters>
                                        <asp:SessionParameter Name="Cod_Con" SessionField="Cod_Con" Type="String" />
                                        
                                </SelectParameters>
                            </asp:ObjectDataSource>

                            