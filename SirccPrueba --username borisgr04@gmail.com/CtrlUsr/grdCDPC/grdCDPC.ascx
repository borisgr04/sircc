<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdCDPC.ascx.vb" Inherits="CtrlUsr_grdCDPC_grdCDPC" %>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
 CellPadding="4" DataKeyNames="nro_cdp" 
    ForeColor="#333333" GridLines="None" 
                                ShowFooter="True" EnableModelValidation="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                  <asp:TemplateField HeaderText="N° CDP" SortExpression="Nro_Cdp">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNro_Cdp" runat="server" Text='<%# Eval("Nro_Cdp")  %>' 
                                                Width="100%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewNro_Cdp" runat="server"  Width="100%"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtNewNro_Cdp_FilteredTextBoxExtender" 
                                                runat="server" 
                                                Enabled="True" 
                                                TargetControlID="txtNewNro_Cdp" 
                                                FilterType="Numbers"
                                                ValidChars="">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LbNro_Cdp" runat="server" Text='<%# Bind("Nro_Cdp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha CDP" SortExpression="Fec_Cdp">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFec_Cdp" runat="server" Text='<%# Eval("Fec_Cdp") %>' 
                                                Width="100%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewFec_Cdp" runat="server"  Width="100%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtNewFec_Cdp_CalendarExtender" 
                                                runat="server" Enabled="True" TargetControlID="txtNewFec_Cdp">
                                            </ajaxToolkit:CalendarExtender>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LbFec_Cdp" runat="server" Text='<%# Eval("Fec_Cdp","{0:d}") %>'  ></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Valor CDP" SortExpression="Val_Cdp">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtVal_Cdp" runat="server" Text='<%# Eval("Val_Cdp") %>' 
                                                Width="100%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewVal_Cdp" runat="server" Width="100%"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtNewVal_Cdp_FilteredTextBoxExtender" 
                                                runat="server" 
                                                Enabled="True" 
                                                TargetControlID="txtNewVal_Cdp" 
                                                FilterType="Custom, Numbers"
                                                ValidChars=".">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Val_Cdp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
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
                        <p>
                        <asp:Label ID="MsgResult" runat="server"></asp:Label>
                        </p>