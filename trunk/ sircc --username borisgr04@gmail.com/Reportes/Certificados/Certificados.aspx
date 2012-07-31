<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Certificados.aspx.vb" Inherits="Reportes_Certificados_Certificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea"> 

    <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Ide Contratista"></asp:Label>
    <asp:TextBox ID="TxtIde" runat="server" AutoPostBack="True"></asp:TextBox>
    <ajaxToolkit:FilteredTextBoxExtender ID="TxtIde_FilteredTextBoxExtender" 
        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtIde">
    </ajaxToolkit:FilteredTextBoxExtender>
        <asp:TextBox ID="TxtNom" runat="server" Enabled="False" Width="300px"></asp:TextBox>
        <asp:Button ID="BtnCert" runat="server" Text="Generar Certificado" />
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
            <asp:GridView ID="grdContratos" runat="server" DataSourceID="ObjDTContratos" 
                EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkSel" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:GridView ID="grdCert" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjConsulta" EnableModelValidation="True" 
                DataKeyNames="Nro_Cert,Vig_Cert">
                <Columns>
                    <asp:BoundField DataField="Vig_Cert" HeaderText="Vigencia" />
                    <asp:BoundField DataField="Nro_Cert" HeaderText="N° Certificado" 
                        SortExpression="Nro_Cert" />
                    <asp:BoundField DataField="Fec_Cert" HeaderText="Fecha Certificado" 
                        SortExpression="Fec_Cert" />
                    <asp:BoundField DataField="LST_CONT" HeaderText="Contratos Certificados" />
                    <asp:BoundField DataField="NRO_IMP" HeaderText="N° Impresiones" 
                        SortExpression="NRO_IMP" />
                    <asp:BoundField DataField="UsAp" HeaderText="Usuario" SortExpression="UsAp" />
                    <asp:BoundField DataField="FREG" HeaderText="Fecha Generación" 
                        SortExpression="FREG" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>

    <br />
    <asp:ObjectDataSource ID="ObjConsulta" runat="server" SelectMethod="GetRecords" 
        TypeName="Cert_Contratos">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtIde" Name="ide_con" PropertyName="Text" />
        </SelectParameters>
    </asp:ObjectDataSource>

</div>
</asp:Content>

