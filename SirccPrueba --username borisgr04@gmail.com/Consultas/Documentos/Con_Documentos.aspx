<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Con_Documentos.aspx.vb" Inherits="Consultas_Documentos_Con_Documentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Consulta de Documentos"></asp:Label>
    <br />
    <br />
        <table style="width:100%;">
            <tr>
                <td colspan="3">
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Width="857px"
                SelectedIndex="2" MultiPageID="RadMultiPage1" Skin="Web20">
                <Tabs>
                    <telerik:RadTab Text="Documentos por Fecha">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Documentos por Contrato">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Documentos por Tipo de Contrato" Selected="True">
                    </telerik:RadTab>
                </Tabs>
    </telerik:RadTabStrip>
                </td>
            </tr>
            <tr>
                <td colspan="3">
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="2" Height="400px"
                Width="857px" CssClass="multiPage">
                <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="corporatePageView">
                
                    <span>
                    <telerik:RadGrid ID="RadGrid4" runat="server" AllowAutomaticDeletes="True" 
                        AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AllowPaging="True" 
                        AutoGenerateColumns="False" CellSpacing="0" DataSourceID="ObjDocFec" 
                        GridLines="None" ShowStatusBar="True" Skin="Web20" Width="855px">
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <AlternatingItemStyle BackColor="#9CAAC1" />
                        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                            NoMasterRecordsText="No existen Items registrados para el presupuesto del Proceso" 
                            ShowFooter="true" Width="100%">
                            <CommandItemSettings ExportToExcelText="Exportar a Excel" 
                                ExportToPdfText="Exportar a PDF" ShowAddNewRecordButton="false" 
                                ShowExportToExcelButton="true" ShowExportToPdfButton="true" 
                                ShowRefreshButton="false" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn ColumnEditorID="GridTextBoxColumnEditor10" 
                                    DataField="Fecha" FilterControlAltText="Filter Fecha column" HeaderText="Fecha" 
                                    ReadOnly="true" SortExpression="Fecha" UniqueName="Fecha">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn Aggregate="Sum" DataField="Documentos" 
                                    FilterControlAltText="Filter column column" 
                                    FooterText="Total Documentos Digitalizados: " 
                                    HeaderText="Documentos Digitalizados" UniqueName="column">
                                    <ItemStyle Width="100px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <FooterStyle ForeColor="DodgerBlue" />
                        </MasterTableView>
                        <HeaderStyle Width="200px" />
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                </Scrolling>
                            </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    </span>
                
                    <asp:ObjectDataSource ID="ObjDocFec" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocFec" 
                        TypeName="Con_DocContratos"></asp:ObjectDataSource>
                
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="RadPageView2" CssClass="productsPageView">
                    
                    <span>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <span>Vigencia</span></td>
                            <td>
                                <span>
                                <asp:DropDownList ID="CmbVigencia" runat="server" DataSourceID="ObjVigencias" 
                                    DataTextField="Year_Vig" DataValueField="Year_Vig" Width="142px">
                                </asp:DropDownList>
                                </span>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <span>
                                <asp:ObjectDataSource ID="ObjVigencias" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                    TypeName="Vigencias"></asp:ObjectDataSource>
                                </span>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <telerik:RadGrid ID="RadGrid5" runat="server" AllowAutomaticDeletes="True" 
                        AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AllowPaging="True" 
                        AutoGenerateColumns="False" CellSpacing="0" DataSourceID="ObjDocCon" 
                        GridLines="None" ShowStatusBar="True" Skin="Web20" Width="855px">
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <AlternatingItemStyle BackColor="#9CAAC1" />
                        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                            NoMasterRecordsText="No existen Items registrados para el presupuesto del Proceso" 
                            ShowFooter="true" Width="100%">
                            <CommandItemSettings ExportToExcelText="Exportar a Excel" 
                                ExportToPdfText="Exportar a PDF" ShowAddNewRecordButton="false" 
                                ShowExportToExcelButton="true" ShowExportToPdfButton="true" 
                                ShowRefreshButton="false" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn ColumnEditorID="GridTextBoxColumnEditor10" 
                                    DataField="Contrato" FilterControlAltText="Filter Fecha column" 
                                    HeaderText="Contrato" ReadOnly="true" SortExpression="Fecha" UniqueName="Fecha">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn Aggregate="Sum" DataField="DocumentosAdjuntos" 
                                    FilterControlAltText="Filter column column" 
                                    FooterText="Total Documentos Digitalizados: " 
                                    HeaderText="Documentos Digitalizados" UniqueName="column">
                                    <ItemStyle Width="100px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <FooterStyle ForeColor="DodgerBlue" />
                        </MasterTableView>
                        <HeaderStyle Width="200px" />
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True">
                                </Scrolling>
                            </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    </span>
                    
                    <asp:ObjectDataSource ID="ObjDocCon" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocCon" 
                        TypeName="Con_DocContratos"></asp:ObjectDataSource>
                    
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="RadPageView3" CssClass="servicesPageView">
                    
                    <telerik:RadGrid ID="RadGrid3" runat="server" Skin="Web20">
                    </telerik:RadGrid>
                    
                </telerik:RadPageView>
            </telerik:RadMultiPage>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    <br />
         </div>    
</asp:Content>

