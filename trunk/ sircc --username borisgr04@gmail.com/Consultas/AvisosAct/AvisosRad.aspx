<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AvisosRad.aspx.vb" Inherits="Consultas_AvisosAct_AvisosRad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true" EnablePartialRendering="true" >
    </ajaxToolkit:ToolkitScriptManager>

<div class="demoheading">Recordatorios Hoy </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
        AllowSorting="True" DataSourceID="ObjAvisosHoy" EnableModelValidation="True" 
        DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Num_Proc" HeaderText="N° de Proceso" 
                SortExpression="Num_Proc" />
            <asp:BoundField DataField="Nom_Act" HeaderText="Actividad" 
                SortExpression="Nom_Act" />
            <asp:BoundField DataField="DateTimeI" HeaderText="Fecha y Hora Inicial" 
                SortExpression="DateTimeI" />
            <asp:BoundField DataField="Notas" HeaderText="Notas" SortExpression="Notas" />
            <asp:BoundField DataField="Ocupado" HeaderText="Ocupado" 
                SortExpression="Ocupado" />
            <asp:BoundField DataField="Nom_Est" HeaderText="Estado" 
                SortExpression="Nom_Est" />
            <asp:CommandField ShowSelectButton="True" ButtonType="Image" 
                SelectImageUrl="~/images/BlueTheme/Select.png" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjAvisosHoy" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvisosHoy" 
        TypeName="PCronogramas"></asp:ObjectDataSource>

        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" 
        AllowSorting="True" CellSpacing="0" DataSourceID="ObjAtrasados" 
        GridLines="None" Skin="Windows7">
            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                <Selecting AllowRowSelect="True" />
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
<MasterTableView AutoGenerateColumns="False" DataSourceID="ObjAtrasados">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="Num_Proc" 
            FilterControlAltText="Filter column column" HeaderText="N° de Proceso" 
            SortExpression="Num_Proc" UniqueName="column">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Nom_Act" 
            FilterControlAltText="Filter column1 column" HeaderText="Actividad" 
            SortExpression="Nom_Act" UniqueName="column1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DateTimeI" 
            FilterControlAltText="Filter column2 column" HeaderText="Fecha Inicio" 
            SortExpression="DateTimeI" UniqueName="column2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Notas" 
            FilterControlAltText="Filter column3 column" HeaderText="Notas" 
            SortExpression="Notas" UniqueName="column3">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Ocupado" 
            FilterControlAltText="Filter column4 column" HeaderText="Marcado como Ocupado" 
            SortExpression="Ocupado" UniqueName="column4">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Nom_est" 
            FilterControlAltText="Filter column5 column" HeaderText="Estado" 
            SortExpression="Nom_Est" UniqueName="column5">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>

        <div class="demoheading">Recordatorios Anteriores </div>
<br />
<asp:GridView ID="GridView2" runat="server" AllowPaging="True"
        AllowSorting="True" DataSourceID="ObjAtrasados" EnableModelValidation="True" 
        DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Num_Proc" HeaderText="N° de Proceso" 
                SortExpression="Num_Proc" />
            <asp:BoundField DataField="Nom_Act" HeaderText="Actividad" 
                SortExpression="Nom_Act" />
            <asp:BoundField DataField="DateTimeI" HeaderText="Fecha y Hora Inicial" 
                SortExpression="DateTimeI" />
            <asp:BoundField DataField="Notas" HeaderText="Notas" SortExpression="Notas" />
            <asp:BoundField DataField="Ocupado" HeaderText="Ocupado" 
                SortExpression="Ocupado" />
            <asp:BoundField DataField="Nom_Est" HeaderText="Estado" 
                SortExpression="Nom_Est" />
            <asp:CommandField ShowSelectButton="True" ButtonType="Image" 
                SelectImageUrl="~/images/BlueTheme/Select.png" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:ObjectDataSource ID="ObjAtrasados" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvisosAtrasados" 
        TypeName="PCronogramas"></asp:ObjectDataSource>

        </div>
</asp:Content>

