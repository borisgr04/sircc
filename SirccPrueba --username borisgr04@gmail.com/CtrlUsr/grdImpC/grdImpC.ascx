<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdImpC.ascx.vb" Inherits="CtrlUsr_grdImpC_grdImpC" %>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
 CellPadding="4" DataKeyNames="Nro_Imp,Cod_Sop" 
    ForeColor="#333333" GridLines="None" 
                                ShowFooter="True" EnableModelValidation="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                  <asp:TemplateField HeaderText="N° Impuesto">
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LbNro_Imp" runat="server" Text='<%# Bind("Nro_Imp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Impuesto">
                                        <FooterTemplate>
                                             <asp:DropDownList ID="CboNewImp" runat="server" DataSourceID="ObjImpuestos" 
                                                    DataTextField="NOM_IMP" DataValueField="NRO_IMP">
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LbNOM_IMP" runat="server" Text='<%# Eval("NOM_IMP") %>'  ></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Vigencia Liquidación">
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewVIGENCIA" runat="server" Width="100%"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtNewVIGENCIA_FilteredTextBoxExtender" 
                                                runat="server" 
                                                Enabled="True" 
                                                TargetControlID="txtNewVIGENCIA" 
                                                FilterType="Numbers">                                              
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("VIGENCIA") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="N° Liquidación">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NRO_COM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewNRO_COM" runat="server" Width="100%"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Valor Liquidación">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Valor") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtNewVALOR" runat="server" Width="100%"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Documento Soporte">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Cod_Sop") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="CboNewSopI" runat="server" AppendDataBoundItems="True" 
                                                    DataSourceID="ObjAdic" DataTextField="NRO_ADI" DataValueField="NRO_ADI">
                                                            <asp:ListItem>Contrato</asp:ListItem>
                                                    </asp:DropDownList>
                                        </FooterTemplate>
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

<asp:ObjectDataSource ID="ObjImpuestos" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
    TypeName="Impuestos">
</asp:ObjectDataSource>
                        

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




