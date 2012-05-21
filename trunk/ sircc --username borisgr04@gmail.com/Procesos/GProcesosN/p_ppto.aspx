<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="p_ppto.aspx.vb" Inherits="Procesos_GProcesosN_p_ppto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
     <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
    </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>

    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
        CellSpacing="0" DataSourceID="ObjGP_Ppto" AllowAutomaticUpdates="True" AllowAutomaticInserts="true" 
        GridLines="None">
        <PagerStyle Mode="NextPrevAndNumeric" />

<MasterTableView DataSourceID="ObjGP_Ppto" CommandItemDisplay="TopAndBottom" DataKeyNames="Id_Item">
<Columns>
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                        <ItemStyle CssClass="MyImageButton" />
                    </telerik:GridEditCommandColumn>
                    <telerik:GridBoundColumn DataField="Nom_Item" HeaderText="Nombre del Item" SortExpression="Nom_Item"
                        UniqueName="Nom_Item" ColumnEditorID="GridTextBoxColumnNom_Item">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Tipo_Item"
                        HeaderText="Tipo_Item" 
                        UniqueName="Tipo_Item" ColumnEditorID="GridDropDownColumnTipo_Item">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Unidad"
                        HeaderText="Unidad de Medida"
                        UniqueName="Cod_Unidad" ColumnEditorID="GridDropDownColumnUnidad">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad"
                        UniqueName="Cantidad" ColumnEditorID="GridTextBoxColumnCantidad">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Valor_Unit" HeaderText="Valor_Unitario" SortExpression="Valor_Unit"
                        UniqueName="Valor_Unit" ColumnEditorID="GridTextBoxColumnValor_Unit">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Porc_Iva" HeaderText="Porcentaje Iva" SortExpression="Porc_Iva"
                        UniqueName="Porc_Iva" ColumnEditorID="GridTextBoxColumnPorc_Iva">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Valor_Parcial" HeaderText="Valor_Parcial" SortExpression="Valor_Parcial"
                        UniqueName="Valor_Parcial" ColumnEditorID="GridTextBoxColumnValor_Parcial">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ConfirmText="Eliminar este Item?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Eliminar" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                        UniqueName="DeleteColumn">
                        <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton" />
                    </telerik:GridButtonColumn>

</Columns>
<CommandItemSettings ExportToPdfText="Export to PDF" ShowExportToPdfButton="true"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

<EditFormSettings ColumnNumber="2" CaptionDataField="Nom_Item" CaptionFormatString="Edit properties of Product {0}" InsertCaption="New Product">
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>

    <br />

    <telerik:RadGrid ID="RadGrid2" runat="server" AllowAutomaticDeletes="True" 
        AllowAutomaticInserts="True" AllowAutomaticUpdates="True" 
        AutoGenerateEditColumn="True" CellSpacing="0" DataSourceID="ObjGP_Ppto" 
        GridLines="None">
<MasterTableView DataSourceID="ObjGP_Ppto" CommandItemDisplay="TopAndBottom" DataKeyNames="Id_Item">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>

    <br />

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>

    <asp:ObjectDataSource ID="ObjGP_Ppto" runat="server" SelectMethod="GetRecords" 
        TypeName="GP_Ppto" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
        <InsertParameters>
            <asp:Parameter Name="Num_Proc" Type="String" />
            <asp:Parameter Name="Grupo" Type="String" />
            <asp:Parameter Name="Nom_Item" Type="String" />
            <asp:Parameter Name="Tipo_Item" Type="String" />
            <asp:Parameter Name="Unidad" Type="String" />
            <asp:Parameter Name="Cantidad" Type="Decimal" />
            <asp:Parameter Name="Valor_Unit" Type="Decimal" />
            <asp:Parameter Name="Porcentaje_IVA" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Num_Proc" Type="String" />
            <asp:Parameter Name="Grupo" Type="String" />
            <asp:Parameter Name="Nom_Item" Type="String" />
            <asp:Parameter Name="Tipo_Item" Type="String" />
            <asp:Parameter Name="Unidad" Type="String" />
            <asp:Parameter Name="Cantidad" Type="Decimal" />
            <asp:Parameter Name="Valor_Unit" Type="Decimal" />
            <asp:Parameter Name="Porcentaje_IVA" Type="Decimal" />
            <asp:Parameter Name="Original_Id_Item" Type="String" />
            <asp:Parameter Name="Porc_Iva" Type="String" />
            <asp:Parameter Name="Valor_Parcial" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTipoItem" runat="server" SelectMethod="GetRecords" 
        TypeName="Tipo_Item"></asp:ObjectDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjGP_Ppto" 
        EnableModelValidation="True">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>

