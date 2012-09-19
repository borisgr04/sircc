<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Certificados.aspx.vb" Inherits="Reportes_Certificados_Certificados" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea"> 

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Label ID="Label2" runat="server" CssClass="Titulo" 
            Text="CERTIFICACIONES DE CONTRATOS/CONVENIIOS"></asp:Label>
        <br />

    <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

    <br />
        <table >
            <tr>
                <td colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Identificación Contratista"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/images/2012/search-b-icon.png" />
                </td>
                <td>
                    <asp:ImageButton ID="IBtnCert" runat="server" 
                        ImageUrl="~/images/2012/reports-icon.png" />
                </td>
            </tr>
            <tr>
                <td>
    <asp:TextBox ID="TxtIde" runat="server" AutoPostBack="True"></asp:TextBox>
    <ajaxToolkit:FilteredTextBoxExtender ID="TxtIde_FilteredTextBoxExtender" 
        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtIde">
    </ajaxToolkit:FilteredTextBoxExtender>
                </td>
                <td>
        <asp:TextBox ID="TxtNom" runat="server" Enabled="False" Width="300px"></asp:TextBox>
                </td>
                <td>
                    Consultar</td>
                <td>
                    Certificar</td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Generar Imagen" Visible="False" />
        <asp:Button ID="Button2" runat="server" Text="Generar Cristal" 
            Visible="False" />
    <br />
    <br />
    <asp:ObjectDataSource ID="ObjDTContratos" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetCertificado" 
        TypeName="Contratos">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtIde" Name="Ide_Con" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:RadioButtonList ID="RdCert" runat="server" RepeatDirection="Horizontal" 
            AutoPostBack="True">
        <asp:ListItem Value="0" Selected="True">Generar</asp:ListItem>
        <asp:ListItem Value="1">Ver Certificados</asp:ListItem>
    </asp:RadioButtonList>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <table >
                <tr>
                    <td >
                    <div style="overflow:scroll; width:680px">
                        <asp:GridView ID="grdContratos" runat="server" DataSourceID="ObjDTContratos" 
                            EnableModelValidation="True" DataKeyNames="Numero">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkSel" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" 
                                    SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        </div>
                    </td>
                    <td valign="top">
                        <strong>Objeto </strong>
                        <br />
                        <asp:TextBox ID="TxtObj" runat="server" Height="100%" TextMode="MultiLine" 
                            Width="257px" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:GridView ID="grdCert" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjConsulta" EnableModelValidation="True" 
                DataKeyNames="Nro_Cert,Vig_Cert,Cod_Serie">
                <Columns>
                    <asp:BoundField DataField="Vig_Cert" HeaderText="Vigencia" />
                    <asp:BoundField DataField="Nro_Cert" HeaderText="N° Certificado" 
                        SortExpression="Nro_Cert" />
                    <asp:BoundField DataField="Cod_Serie" HeaderText="Código Verificación" 
                        SortExpression="Cod_Serie"></asp:BoundField>
                    <asp:BoundField DataField="Fec_Cert" HeaderText="Fecha Certificado" 
                        SortExpression="Fec_Cert" />
                    <asp:BoundField DataField="LST_CONT" HeaderText="Contratos Certificados" />
                    <asp:BoundField DataField="NRO_IMP" HeaderText="N° Impresiones" 
                        SortExpression="NRO_IMP" />
                    <asp:BoundField DataField="UsAp" HeaderText="Usuario" SortExpression="UsAp" />
                    <asp:BoundField DataField="FREG" HeaderText="Fecha Generación" 
                        SortExpression="FREG" />
                    <asp:CommandField ShowSelectButton="True" ButtonType="Image" 
                        SelectImageUrl="~/images/2012/pdf-icon.png" />
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>

    <br />
    <asp:ObjectDataSource ID="ObjConsulta" runat="server" SelectMethod="GetRecords" 
        TypeName="Cert_Contratos" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtIde" Name="Ide_Con" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</div>
</asp:Content>

