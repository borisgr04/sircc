<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Certificados.aspx.vb" Inherits="Reportes_Certificados_Certificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Label ID="Label2" runat="server" CssClass="Titulo" Text="CERTIFICACIONES DE CONTRATOS/CONVENIIOS"></asp:Label>
        <br />
        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
        <br />
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Identificación Contratista"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TxtIde" runat="server" AutoPostBack="True"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="TxtIde_FilteredTextBoxExtender" runat="server"
                        Enabled="True" FilterType="Numbers" TargetControlID="TxtIde">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </td>
                <td>
                    <asp:TextBox ID="TxtNom" runat="server" Enabled="False" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="IBtnBuscar" runat="server" SkinID="IBtnBuscar" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    Consultar
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Generar Imagen" Visible="False" />
        <br />
        <asp:ObjectDataSource ID="ObjPlantillas" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetPlantillas" TypeName="Cert_Contratos"></asp:ObjectDataSource>
        <br />
        <asp:ObjectDataSource ID="ObjDTContratos" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCertificado" TypeName="Contratos">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtIde" Name="Ide_Con" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Windows7" MultiPageID="RadMultiPage1"
            SelectedIndex="0">
            <Tabs>
                <telerik:RadTab runat="server" Text="Crear Certificados" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Historico de Certificaciones">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
            <telerik:RadPageView ID="RadPageView1" runat="server">
            <br />
                <table>
                    <tr>
                        <td>
                            Seleccione Plantilla
                        </td>
                        <td>
                            <asp:DropDownList ID="CboPlantilla" runat="server" DataSourceID="ObjPlantillas" DataTextField="Nom_Pla"
                                DataValueField="Ide_Pla">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="IBtnCert" runat="server" ImageUrl="~/images/2012/reports-icon.png" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Certificar
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <div style="overflow: auto; width: 1000px; height: 100%">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <asp:CheckBox ID="chTodos" runat="server" AutoPostBack="True" Text="Seleccionar Todos"  />
                                <asp:GridView ID="grdContratos" runat="server" DataSourceID="ObjDTContratos" EnableModelValidation="True"
                                    DataKeyNames="Numero">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkSel" runat="server" ToolTip='<%# GetObjeto(Eval("Numero")) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                
                                </ContentTemplate>    
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server">
                <br />
                <h3>Histórico de Certificaciones</h3><br />
                <asp:GridView ID="grdCert" runat="server" AutoGenerateColumns="False" DataSourceID="ObjConsulta"
                    EnableModelValidation="True" DataKeyNames="Nro_Cert,Vig_Cert,Cod_Serie">
                    <Columns>
                        <asp:BoundField DataField="Vig_Cert" HeaderText="Vigencia" />
                        <asp:BoundField DataField="Nro_Cert" HeaderText="N° Certificado" SortExpression="Nro_Cert" />
                        <asp:BoundField DataField="Cod_Serie" HeaderText="Código Verificación" SortExpression="Cod_Serie">
                        </asp:BoundField>
                        <asp:BoundField DataField="Fec_Cert" HeaderText="Fecha Certificado" SortExpression="Fec_Cert"  />
                        <asp:BoundField DataField="LST_CONT" HeaderText="Contratos Certificados" />
                        <%--<asp:BoundField DataField="NRO_IMP" HeaderText="N° Impresiones" SortExpression="NRO_IMP" />--%>
                        <asp:BoundField DataField="UsAp" HeaderText="Usuario" SortExpression="UsAp" />
                        <asp:BoundField DataField="FREG" HeaderText="Fecha Generación" SortExpression="FREG" />
                        <%--<asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/2012/pdf-icon.png" />--%>
                    </Columns>
                </asp:GridView>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
        <br />
        <asp:ObjectDataSource ID="ObjConsulta" runat="server" SelectMethod="GetRecords" TypeName="Cert_Contratos"
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtIde" Name="Ide_Con" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
