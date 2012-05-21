<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConContratista.aspx.vb" Inherits="Consultas_ConContratista" %>
<%@ Register src="../../CtrlUsr/Progreso/Progress.ascx" tagname="Progress" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Consulta de Documentos"></asp:Label>
    <br />
    <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width:100%;">
                    <tr>
                        <td colspan="4">
                         <span>
                             <asp:Label ID="Label2" runat="server" Text="Filtrar: " CssClass="SubTitulo"></asp:Label>
                            <telerik:RadFilter ID="RadFilter1" runat="server" 
                                AddExpressionToolTip="Agregar Filtro" AddGroupToolTip="Agregar Grupo" 
                                CssClass="RadFilter RadFilter_Default " Culture="es-ES" 
                                FilterContainerID="RadGrid4" ShowApplyButton="False" Skin="Web20">
                                <Localization FilterFunctionBetween="Entre" FilterFunctionContains="Contiene" 
                                    FilterFunctionDoesNotContain="No Contiene" FilterFunctionEndsWith="Termina en" 
                                    FilterFunctionEqualTo="Igual a" FilterFunctionGreaterThan="Mayor que" 
                                    FilterFunctionGreaterThanOrEqualTo="Mayor o igual que" 
                                    FilterFunctionIsEmpty="Es vacío" FilterFunctionIsNull="Es nulo" 
                                    FilterFunctionLessThan="Menor que" 
                                    FilterFunctionLessThanOrEqualTo="Menor o igual que" 
                                    FilterFunctionNotBetween="No está entre" FilterFunctionNotEqualTo="Diferente" 
                                    FilterFunctionNotIsEmpty="No es vacío" FilterFunctionNotIsNull="No es nulo" 
                                    FilterFunctionStartsWith="Comienza con" GroupOperationAnd="Y" 
                                    GroupOperationNotAnd="No Y" GroupOperationNotOr="No O" GroupOperationOr="O" />
                            </telerik:RadFilter>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <telerik:RadButton ID="RadButton1" runat="server" Skin="Web20" 
                                Text="Aplicar Filtro">
                            </telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <span>
                            <div class="filterDiv">
                            </div>
                            <telerik:RadGrid ID="RadGrid4" runat="server" AllowAutomaticDeletes="True" 
                                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AllowPaging="True" 
                                AutoGenerateColumns="False" CellSpacing="0" DataSourceID="ObjCon" 
                                GridLines="None" ShowStatusBar="True" Skin="Web20" Width="855px">
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <AlternatingItemStyle BackColor="#9CAAC1" />
                                <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                                    DataSourceID="ObjCon" 
                                    NoMasterRecordsText="No se encontraron registros para mostrar" 
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
                                        <telerik:GridBoundColumn ColumnEditorID="GridTextBoxColumnEditor20" 
                                            DataField="Vig_Con" FilterControlAltText="Filter Fecha column" 
                                            HeaderText="Vigencia" ReadOnly="true" SortExpression="Vig_Con" UniqueName="Vigencia">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn ColumnEditorID="GridTextBoxColumnEditor10" 
                                            DataField="Numero" FilterControlAltText="Filter Fecha column" 
                                            HeaderText="Número" ReadOnly="true" SortExpression="Numero" UniqueName="Fecha">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Obj_Con" 
                                            FilterControlAltText="Filter column3 column" HeaderText="Objeto" 
                                            UniqueName="column3">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Val_Con" DataFormatString="{0:c}" 
                                            FilterControlAltText="Filter column column" HeaderText="Valor del Contrato" 
                                            UniqueName="column">
                                            <ItemStyle Width="100px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Pla_Eje_Con" 
                                            FilterControlAltText="Filter column1 column" 
                                            HeaderText="Plazo de Ejecución(Días)" UniqueName="column1">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Ide_Contratistas" 
                                            FilterControlAltText="Filter column2 column" 
                                            HeaderText="Identificación del Contratista" UniqueName="column2">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Nom_Contratista" 
                                            FilterControlAltText="Filter column4 column" HeaderText="Contratista" 
                                            UniqueName="column4">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Dir_Contratista" 
                                            FilterControlAltText="Filter column5 column" HeaderText="Dirección" 
                                            UniqueName="column5">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Tel_Contratista" 
                                            FilterControlAltText="Filter column6 column" HeaderText="Telefono" 
                                            UniqueName="column6">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Ema_Contratista" 
                                            FilterControlAltText="Filter column7 column" HeaderText="Correo Electronico" 
                                            UniqueName="column7">
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
                                    <Scrolling AllowScroll="True" SaveScrollPosition="True" 
                                        UseStaticHeaders="True" />
                                </ClientSettings>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                            <asp:ObjectDataSource ID="ObjCon" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetConContratista" 
                                TypeName="Con_DocContratos"></asp:ObjectDataSource>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
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
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress3" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel1">
                    <progresstemplate>
                   <uc3:Progress ID="Progress5" runat="server" />
                    </progresstemplate>
                    </asp:UpdateProgress>  
        <br />
    <br />
         </div>    
</asp:Content>

