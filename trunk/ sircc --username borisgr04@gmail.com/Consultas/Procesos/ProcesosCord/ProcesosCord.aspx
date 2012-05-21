<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ProcesosCord.aspx.vb" Inherits="Consultas_Procesos_ProcesosCord_ProcesosCord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="demoarea">
        <asp:Label ID="Label1" runat="server" Text="Procesos de la Dependencia listos para generar Minuta" CssClass="Titulo"></asp:Label>

        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
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
                            &nbsp;</td>
                        <td>
                            <span>
                             <asp:Label ID="Label2" runat="server" Text="Filtrar: " CssClass="SubTitulo"></asp:Label>
                            <telerik:RadFilter ID="RadFilter1" runat="server" 
                                AddExpressionToolTip="Agregar Filtro" AddGroupToolTip="Agregar Grupo" 
                                CssClass="RadFilter RadFilter_Default " Culture="es-ES" 
                                FilterContainerID="RadGrid1" ShowApplyButton="True" Skin="Web20" ApplyButtonText="Buscar">
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
                        <td>
                            &nbsp;</td>
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
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    CellSpacing="0" DataSourceID="ObjProc" GridLines="None" Skin="WebBlue">
                    <MasterTableView DataSourceID="ObjProc">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="N° Proceso" 
                                FilterControlAltText="Filter column column" HeaderText="Nº de Proceso" 
                                UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Grupo" 
                                FilterControlAltText="Filter column1 column" HeaderText="Grupo" 
                                UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Objeto" 
                                FilterControlAltText="Filter column2 column" HeaderText="Objeto" 
                                UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Tipo de Documento" 
                                FilterControlAltText="Filter column3 column" HeaderText="Tipo de Documento" 
                                UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Clase" 
                                FilterControlAltText="Filter column4 column" HeaderText="Clase" 
                                UniqueName="column4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Encargado" 
                                FilterControlAltText="Filter column5 column" HeaderText="Encargado" 
                                UniqueName="column5">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                <asp:ObjectDataSource ID="ObjProc" runat="server" InsertMethod="InsertP" 
                    OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetMisProcbyGMinutaCord" TypeName="ConGProcesos">
                    <InsertParameters>
                        <asp:Parameter Name="COD_TPRO" Type="String" />
                        <asp:Parameter Name="OBJ_CON" Type="String" />
                        <asp:Parameter Name="DEP_CON" Type="String" />
                        <asp:Parameter Name="DEP_PCON" Type="String" />
                        <asp:Parameter Name="VIG_CON" Type="Decimal" />
                        <asp:Parameter Name="TIP_CON" Type="String" />
                        <asp:Parameter Name="STIP_CON" Type="String" />
                        <asp:Parameter Name="FEC_RECIBIDO" Type="DateTime" />
                        <asp:Parameter Name="NUM_SOL" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>

