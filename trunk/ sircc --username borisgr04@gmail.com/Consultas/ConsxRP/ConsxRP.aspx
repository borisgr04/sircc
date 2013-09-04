<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConsxRP.aspx.vb" Inherits="Consultas_ConsxRP_ConsxRP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">

    <asp:Label ID="Label1" runat="server" Text="Número de Registro Presupuestal"></asp:Label>
    <asp:TextBox ID="TxtNroRp" runat="server"></asp:TextBox>
    <asp:Button ID="BtnCons" runat="server" CssClass="button_example" 
        Text="Consultar" />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
 CellPadding="4" DataKeyNames="nro_rp" 
    ForeColor="#333333" GridLines="None" 
                                ShowFooter="True" EnableModelValidation="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="Cod_Con" HeaderText="N° Contrato" 
                                        SortExpression="Cod_Con" />
                                  <asp:TemplateField HeaderText="N° Rp" SortExpression="Nro_Rp">
                                        
                                        <ItemTemplate>
                                            <asp:Label ID="LbNro_Rp" runat="server" Text='<%# Bind("Nro_Rp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Rp" SortExpression="Fec_Rp">
                                        
                                        <ItemTemplate>
                                            <asp:Label ID="LbFec_Rp" runat="server" Text='<%# Eval("Fec_Rp","{0:d}") %>'  ></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="Vigencia" HeaderText="Vigencia" />
                                     <asp:TemplateField HeaderText="Valor Rp" SortExpression="Val_Rp">
                                        
                                        <ItemTemplate >
                                            <asp:Label ID="Label29" runat="server" Text='<%# Bind("Val_Rp","{0:c}") %>' ></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Documento Soporte" SortExpression="Doc_Sop">
                                        
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Doc_Sop") %>'></asp:Label>
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
                        
                        
</div>
</asp:Content>

