<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdLegC.ascx.vb" Inherits="CtrlUsr_grdLegC_grdLegC" %>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
 CellPadding="4" DataKeyNames="DOCUMENTO" 
    ForeColor="#333333" GridLines="None" 
                                ShowFooter="True" EnableModelValidation="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                     <asp:TemplateField HeaderText="DOCUMENTO">
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("DOCUMENTO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FECHA DE LEGALIZACIÓN">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelNT" runat="server" Text='<%# Bind("FEC_APR_POL","{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditFec_Apr_Pol" runat="server"  Text='<%# Bind("FEC_APR_POL","{0:d}") %>'></asp:TextBox>

                                            <ajaxToolkit:CalendarExtender ID="txtEditFec_Apr_Pol_CalendarExtender" 
                                                runat="server" Enabled="True" TargetControlID="txtEditFec_Apr_Pol">
                                            </ajaxToolkit:CalendarExtender>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LEGALIZADO">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("LEGALIZADO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:dropdownlist ID="CboEditLegalizado" runat="server" text='<%# Bind("LEGALIZADO") %>' >
                                        <asp:ListItem Value="S" Text="SI"></asp:ListItem>
                                        <asp:ListItem Value="N" Text="NO"></asp:ListItem>
                                        </asp:dropdownlist>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DOCUMENTO INICIAL">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("COD_CON") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TIPO DOCUMENTO">
                                        <ItemTemplate>
                                            <asp:Label ID="lbEditTipo" runat="server" Text='<%# Bind("TIPO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                   
                                     <asp:TemplateField HeaderText="EXENTO DE POLIZA">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("EXENPOL") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:dropdownlist ID="CboExPol" runat="server" text='<%# Bind("EXENPOL") %>' >
                                        <asp:ListItem Value="S" Text="SI"></asp:ListItem>
                                        <asp:ListItem Value="N" Text="NO"></asp:ListItem>
                                        </asp:dropdownlist>
                                        </EditItemTemplate>
                                     </asp:TemplateField>
                                        
                                     <asp:TemplateField ShowHeader="False">
                                         <EditItemTemplate>
                                             <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                 CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                             &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                 CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                         </EditItemTemplate>
                                         <ItemTemplate>
                                             <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                 CommandName="Edit" Text="Editar"></asp:LinkButton>
                                         </ItemTemplate>
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






