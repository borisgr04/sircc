<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="AvisosAct2.aspx.vb" Inherits="Consultas_AvisosAct_AvisosAct2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <telerik:RadScriptManager ID="ToolkitScriptManager1" runat="server" 
        EnableTheming="True">
    </telerik:RadScriptManager>
    
    <div class="demoarea" style="padding:10px">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <asp:Label ID="LbTitulos" CssClass="Titulo" runat="server" Text="Panel de Procesos de Contratación"></asp:Label>
                <hr />
                <br />
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="0" Skin="Windows7"
                    MultiPageID="RadMultiPage1">
                    <Tabs>
                        <telerik:RadTab runat="server" Owner="RadTabStrip1" Value="hoy" 
                            Text="Actividades Hoy " PageViewID="RadPageView1">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Owner="RadTabStrip1"  Value="atrazadas"
                            Text="Actividades Atrazadas" PageViewID="RadPageView2">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Owner="RadTabStrip1" Value="sinrecibir" 
                            Text="Solicitudes Sin Recibir" PageViewID="RadPageView3">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Owner="RadTabStrip1"  Value="sinrevisar"
                            Text="Solicitudes Sin Revisar" PageViewID="RadPageView4">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Procesos a Cargo" Value="procesos" 
                            PageViewID="RadPageView5" Selected="True">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <br />
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RadPageView1" runat="server">
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" DataSourceID="ObjAvisosHoy"
                            EnableModelValidation="True" DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False"
                            EmptyDataText="No tiene tareas pendientes para hoy">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/BlueTheme/Select.png" />
                                <asp:BoundField DataField="Num_Proc" HeaderText="N° de Proceso" SortExpression="Num_Proc" />
                                <asp:BoundField DataField="Nom_Act" HeaderText="Actividad" SortExpression="Nom_Act" />
                                <asp:BoundField DataField="DateTimeI" HeaderText="Fecha y Hora Inicial" SortExpression="DateTimeI" />
                                <asp:BoundField DataField="Notas" HeaderText="Notas" SortExpression="Notas" />
                                <asp:BoundField DataField="Ocupado" HeaderText="Ocupado" SortExpression="Ocupado" />
                                <asp:BoundField DataField="Nom_Est" HeaderText="Estado" SortExpression="Nom_Est" />
                            </Columns>
                        </asp:GridView>

                     <%--   <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                            CellSpacing="0" DataSourceID="ObjAvisosHoy" GridLines="None" Skin="Windows7">
                            <MasterTableView DataSourceID="ObjAvisosHoy">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Num_Proc" 
                                        FilterControlAltText="Filter column column" HeaderText="N° Proceso" 
                                        SortExpression="Num_Proc" UniqueName="column">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nom_Act" 
                                        FilterControlAltText="Filter column1 column" HeaderText="Actividad" 
                                        SortExpression="Nom_Act" UniqueName="column1">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nom_Est" 
                                        FilterControlAltText="Filter column2 column" HeaderText="Estado" 
                                        SortExpression="Nom_Est" UniqueName="column2">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DateTimeI" 
                                        FilterControlAltText="Filter column3 column" HeaderText="Fecha y Hora Inicial" 
                                        SortExpression="DateTimeI" UniqueName="column3">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Notas" 
                                        FilterControlAltText="Filter column4 column" HeaderText="Notas" 
                                        SortExpression="Notas" UniqueName="column4">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Ocupado" 
                                        FilterControlAltText="Filter column5 column" HeaderText="Ocupado" 
                                        SortExpression="Ocupado" UniqueName="column5">
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
                        </telerik:RadGrid>--%>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server">
                        <br />
                        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" DataSourceID="ObjAtrasados"
                            EnableModelValidation="True" DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/BlueTheme/Select.png" />
                                <asp:BoundField DataField="Num_Proc" HeaderText="N° de Proceso" SortExpression="Num_Proc" />
                                <asp:BoundField DataField="Nom_Act" HeaderText="Actividad" SortExpression="Nom_Act" />
                                <asp:BoundField DataField="DateTimeI" HeaderText="Fecha y Hora Inicial" SortExpression="DateTimeI" />
                                <asp:BoundField DataField="Notas" HeaderText="Notas" SortExpression="Notas" />
                                <asp:BoundField DataField="Ocupado" HeaderText="Ocupado" SortExpression="Ocupado" />
                                <asp:BoundField DataField="Nom_Est" HeaderText="Estado" SortExpression="Nom_Est" />
                            </Columns>
                        </asp:GridView>
                        <%--<telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" 
                            CellSpacing="0" DataSourceID="ObjAtrasados" GridLines="None" 
                            Skin="Windows7"  DataKeyNames="Num_Proc,ID">
                            <MasterTableView DataSourceID="ObjAtrasados">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Num_Proc" 
                                        FilterControlAltText="Filter column column" HeaderText="N° Proceso" 
                                        SortExpression="Num_Proc" UniqueName="column">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nom_Act" 
                                        FilterControlAltText="Filter column1 column" HeaderText="Actividad" 
                                        SortExpression="Nom_Act" UniqueName="column1">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nom_Est" 
                                        FilterControlAltText="Filter column2 column" HeaderText="Estado" 
                                        SortExpression="Nom_Est" UniqueName="column2">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DateTimeI" 
                                        FilterControlAltText="Filter column3 column" HeaderText="Fecha y Hora Inicial" 
                                        SortExpression="DateTimeI" UniqueName="column3">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Notas" 
                                        FilterControlAltText="Filter column4 column" HeaderText="Notas" 
                                        SortExpression="Notas" UniqueName="column4">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Ocupado" 
                                        FilterControlAltText="Filter column5 column" HeaderText="Ocupado" 
                                        SortExpression="Ocupado" UniqueName="column5">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="select" 
                                        ConfirmDialogType="RadWindow" FilterControlAltText="Filter column6 column" 
                                        ImageUrl="~/images/BlueTheme/Select.png" UniqueName="column6">
                                    </telerik:GridButtonColumn>
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
                        </telerik:RadGrid>--%>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView3" runat="server">
                        <asp:GridView OnRowDataBound="GridView1_RowDataBound" ID="grdRecibir" runat="server"
                            Width="724px" DataSourceID="ObjPSol" DataKeyNames="Cod_Sol" AutoGenerateColumns="False"
                            EmptyDataText="No tiene solicitudes pendientes para recibir" AllowSorting="True"
                            EnableModelValidation="True">
                            <Columns>
                                <asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True"
                                    ButtonType="Image"></asp:CommandField>
                                <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                                    <ItemTemplate>
                                        <asp:Label ID="LbCod0" runat="server" Text='<%# Bind("Cod_Sol") %>' __designer:wfdid="w9"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Objeto del Contrato" SortExpression="Obj_sol">
                                    <ItemTemplate>
                                        <asp:Label ID="Lbcimp0" runat="server" Text='<%# Bind("Obj_sol") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dependencia a Cargo" SortExpression="Dep_Del">
                                    <ItemTemplate>
                                        <asp:Label ID="LbEst0" runat="server" Text='<%# Bind("Dep_Del") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dependencia que Solicita" SortExpression="Dep_Nec">
                                    <ItemTemplate>
                                        <asp:Label ID="LbVal0" runat="server" Text='<%# Bind("Dep_Nec") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView4" runat="server">
                        <asp:GridView ID="grdRevisar" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            DataKeyNames="Cod_Sol" DataSourceID="ObjPSolRv" EmptyDataText="No tiene solicitudes pendientes para revisar"
                            EnableModelValidation="True" Width="724px">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                                    ShowSelectButton="True" />
                                <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                                    <ItemTemplate>
                                        <asp:Label ID="LbCod" runat="server" text='<%# Bind("Cod_Sol") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Objeto del Contrato" SortExpression="Obj_sol">
                                    <ItemTemplate>
                                        <asp:Label ID="Lbcimp" runat="server" Text='<%# Bind("Obj_sol") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dependencia a Cargo" SortExpression="Dep_Del">
                                    <ItemTemplate>
                                        <asp:Label ID="LbEst" runat="server"  Text='<%# Bind("Dep_Del") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dependencia que genera" SortExpression="Val_Prop">
                                    <ItemTemplate>
                                        <asp:Label ID="LbVal" runat="server"  Text='<%# Bind("Dep_Nec") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView5" runat="server">
                    <div style="float:right">
                        <asp:LinkButton ID="lnkVerTodos" runat="server">Ver Todos</asp:LinkButton>
                        </div>
                        <asp:DataList ID="DtProcesosACargo" runat="server" CellPadding="4" ForeColor="#333333"
                            RepeatDirection="Horizontal" DataKeyField="Estado" DataSourceID="ObjConPContratos">
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Estado")%>'
                                    OnClick="Selecc_DTProc" ToolTip='Click para ver más'>
            <%# DataBinder.Eval(Container.DataItem, "Estado") %>(<b><%# DataBinder.Eval(Container.DataItem, "Cantidad") %></b>)</asp:LinkButton>
                            </ItemTemplate>
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        </asp:DataList>
                        <asp:GridView ID="grdProcACargo" runat="server" OnRowDataBound="GridView1_RowDataBound"
                            DataSourceID="ObjConPContratosD" DataKeyNames="Pro_Sel_Nro" AutoGenerateColumns="False"
                            EmptyDataText="No tiene procesos a cargo" EnableModelValidation="True" AllowSorting="True"
                            Width="100%">
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="crono" HeaderText="Cronograma" ImageUrl="~/images/mnProcesos/Calendar-icon24.png"
                                    Text="Cronograma">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Image" CommandName="dbproc" HeaderText="Datos del Proceso"
                                    ImageUrl="~/images/Operaciones/Edit.png">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Image" CommandName="documentos" HeaderText="Documentos"
                                    ImageUrl="~/images/2012/archivo.png" Text="Documentos Precontractuales" />
                                <asp:BoundField DataField="Pro_Sel_Nro" HeaderText="N° de Proceso" SortExpression="Pro_Sel_Nro" />
                                <asp:BoundField DataField="Nom_TProc" HeaderText="Tipo de Procesos" SortExpression="Nom_TProc" />
                                <asp:BoundField HeaderText="Objeto a Contratar" SortExpression="Obj_Con" DataField="Obj_Con">
                                </asp:BoundField>
                                <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia-Necesidad" SortExpression="Dep_Nec" />
                                <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia-A Cargo" SortExpression="Dep_Del" />
                            </Columns>
                        </asp:GridView>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <br />
                <br />
                <br />
                <asp:ObjectDataSource ID="ObjConPContratos" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetMisProcesos" TypeName="Con_PContratos">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjAvisosHoy" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetAvisosHoy" TypeName="PCronogramas"></asp:ObjectDataSource>
                <br />
                <asp:ObjectDataSource ID="ObjAtrasados" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetAvisosAtrasados" TypeName="PCronogramas"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjPSol" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetByAbog" TypeName="PSolicitudes"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjPSolRv" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetSolPen" TypeName="ConSolicitudes" InsertMethod="InsertHREV">
                    <InsertParameters>
                        <asp:Parameter Name="COD_SOL" Type="String" />
                        <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:HiddenField ID="HdPNom_Est" runat="server" />
                <asp:ObjectDataSource ID="ObjConPContratosD" runat="server" InsertMethod="InsertP"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetMisProcbyEstado"
                    TypeName="Con_PContratos">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HdPNom_Est" Name="Nom_Est" PropertyName="Value"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
