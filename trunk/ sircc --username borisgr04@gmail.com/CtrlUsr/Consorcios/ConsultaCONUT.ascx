<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConsultaCONUT.ascx.vb" Inherits="CtrlUsr_ConsultaCONUT" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="width: 573px; height: 10px">
    <tr>
        <td style="width: 100px">
            &nbsp;&nbsp; Nit/Nombre</td>
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
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Tipo Doc" SortExpression="IDE_TER">
                            <ItemTemplate>
                                <asp:Label ID="LbNom" runat="server" Text='<%# Bind("IDE_TER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="N° Identificación" SortExpression="NOM_TER">
                            <ItemTemplate>
                                <asp:Label ID="LbUni1" runat="server" Text='<%# Bind("NOM_TER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre" SortExpression="DIR_TER">
                            <ItemTemplate>
                                <asp:Label ID="LbUni2" runat="server" Text='<%# Bind("DIR_TER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Teléfono" SortExpression="TEL_TER">
                            <ItemTemplate>
                                <asp:Label ID="LbBar" runat="server" Text='<%# Bind("TEL_TER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" SortExpression="EMA_TER">
                            <ItemTemplate>
                                <asp:Label ID="LbNor" runat="server" Text='<%# Bind("EMA_TER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="16px" />
                            <ItemTemplate>
                                
                                <div onclick='javascript:enviarCSUT(&#039;<%# Eval("ide_ter") %>&#039;,&#039;<%# Eval("NOM_TER") %>&#039;,&#039;<%= Me.Ret %>&#039;);' 
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
<asp:ObjectDataSource ID="ObjTerceros" runat="server" 
    SelectMethod="GetConsorcios" TypeName="Terceros" DeleteMethod="Delete" 
    InsertMethod="AsignarAbogado" OldValuesParameterFormatString="original_{0}">
    <DeleteParameters>
        <asp:Parameter Name="Ide_ter" Type="String" />
    </DeleteParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="TxtFilNom" Name="busc" PropertyName="Text" Type="String" />
        <asp:Parameter Name="tipo" Type="String" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="Id_Ter" Type="String" />
        <asp:Parameter Name="Id_Miembro" Type="String" />
        <asp:Parameter Name="Id_Estado" Type="String" />
    </InsertParameters>
</asp:ObjectDataSource>
