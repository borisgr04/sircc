<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdProyC.ascx.vb" Inherits="CtrlUsr_grdOblig_grdProyC" %>
                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" DataKeyNames="Proyecto" EnableModelValidation="True" 
                                ForeColor="#333333" GridLines="None" 
    ShowFooter="True" Width="100%">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Proyecto" SortExpression="Proyecto">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNro_Cdp" runat="server" Text='<%# Eval("Proyecto")  %>' 
                                                Width="100%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewProyecto" runat="server" Width="100%"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LbProyecto" runat="server" Text='<%# Bind("Proyecto") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre del Proyecto" SortExpression="Nombre_Proyecto">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNombre_Proyecto" runat="server" Text='<%# Eval("Nombre_Proyecto") %>' 
                                                Width="100%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LbNombre_Proyecto" runat="server" Text='<%# Eval("Nombre_Proyecto") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="80%" />
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
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
<asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

                            
                        
                        

                        