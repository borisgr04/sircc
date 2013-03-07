<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConsultaTerxDep.ascx.vb" Inherits="CtrlUsr_ConsultaTerxDep" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="width: 573px; height: 10px">
    <tr>
        <td style="width: 100px">
            Nit/Nombre</td>
        <td colspan="1" style="width: 290px">
            <asp:TextBox ID="TxtFilNom" runat="server" Width="277px"> 
</asp:TextBox>
        
        </td>
        <td colspan="1" style="width: 53px">
            <asp:ImageButton ID="BtnBuscar" runat="server" AccessKey="b" AlternateText="Buscar"
                CausesValidation="False" CommandName="Buscar" ImageUrl="~/images/Operaciones/search2.png"
                OnClick="BtnBuscar_Click" /></td>
        <td style="width: 49px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td colspan="1" style="width: 290px">
        </td>
        <td colspan="1" style="width: 53px">
            Buscar</td>
        <td style="width: 49px">
            </td>
    </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataKeyNames="IDE_TER" DataSourceID="ObjTerceros" 
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" 
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                    EnableModelValidation="True" Width="516px">
                    <Columns>
                        <asp:TemplateField HeaderText="N° Identificación" SortExpression="Ide_Ter">
                            <ItemTemplate>
                                <asp:Label ID="LbUni1" runat="server" Text='<%# Bind("IDE_TER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre y Apellidos" SortExpression="NOM_TER">
                            <ItemTemplate>
                                <asp:Label ID="LbNom" runat="server" Text='<%# Bind("NOM_TER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="16px" />
                            <ItemTemplate>
                                
                                <div onclick='javascript:enviar(&#039;<%# Eval("ide_ter") %>&#039;,&#039;<%# Eval("NOM_TER") %>&#039;,&#039;<%= Me.Ret %>&#039;);' 
                                    onmouseout="this.style.cursor = 'auto'" 
                                    onmouseover="this.style.cursor = 'hand'" 
                                    title="Enviar Registro" style="height: 32px; width: 32px;"  > 
                                    <asp:Image ID="Image1" runat="server" SkinID="ImgSel" /> 
                                    </div>
                                 
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <br />
                        <asp:Label ID="Label1" runat="server" CssClass="NoData" 
                            Text="No se encontraron registros" Width="166px"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
</table>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:HiddenField ID="HiddenField1" runat="server" Value="Tipo" />
<asp:ObjectDataSource ID="ObjTerceros" runat="server" SelectMethod="GetTercerosxDep" TypeName="Terceros">
    <SelectParameters>
        <asp:ControlParameter ControlID="TxtFilNom" Name="busc" PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="HiddenField1" Name="Cod_Dep" PropertyName="Value" />
    </SelectParameters>
</asp:ObjectDataSource>
