<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdObligGP.ascx.vb" Inherits="CtrlUsr_grdOblig_grdObligGP" %>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
 CellPadding="4" DataKeyNames="Ide_Oblig" 
    ForeColor="#333333" GridLines="None" 
                                ShowFooter="True" Width="100%" 
    EnableModelValidation="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Obligaciones" SortExpression="Des_Oblig" HeaderStyle-HorizontalAlign="Left">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOblig" runat="server" Text='<%# Eval("Des_Oblig") %>' 
                                                Width="100%" Height="161px" TextMode="MultiLine"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewOblig" runat="server" TextMode="MultiLine" Width="100%" 
                                                Height="150px"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Des_Oblig") %>'></asp:Label>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                        <ItemStyle Width="1200px" HorizontalAlign="Justify" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="True" 
                                                CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                                CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" 
                                                CommandName="AddNew" Text="Guardar" ForeColor="White"></asp:LinkButton>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" 
                                                CommandName="Edit" Text="Editar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField HeaderText="" ShowDeleteButton="True" ShowHeader="True" 
                                        DeleteText="Eliminar" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                        
                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                        
                        

                        