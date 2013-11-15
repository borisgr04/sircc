<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="AvisosAct2.aspx.vb" Inherits="Consultas_AvisosAct_AvisosAct2" %>

<%@ Register src="../../CtrlUsr/Progreso/Progress.ascx" tagname="Progress" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <telerik:RadScriptManager ID="ToolkitScriptManager1" runat="server" 
        EnableTheming="True">
    </telerik:RadScriptManager>
    
    <div class="demoarea" style="padding:10px">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <asp:Label ID="LbTitulos" CssClass="Titulo" runat="server" 
                    Text="Panel de Procesos de Contratación por Funcionario"></asp:Label>
                <hr />
                <table style="width:30%;">
                    <tr>
                        <td style="text-align: center">
                            <asp:ImageButton ID="IBtnNuevo" runat="server" SkinID="IBtnNuevo" />
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="IBtnPanelD" runat="server" SkinID="IBtnPanelD" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:HyperLink ID="HyperLink2" runat="server" 
                                NavigateUrl="~/Solicitudes/NuevaSolicitud/NuevaSolicitud.aspx">Nueva Solicitud</asp:HyperLink>
                        </td>
                        <td style="text-align: center">
                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                NavigateUrl="~/Consultas/AvisosActD/AvisosActD.aspx">Panel de Coordinador</asp:HyperLink>
                        </td>
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
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="0" Skin="Windows7"
                    MultiPageID="RadMultiPage1">
                    <Tabs>
                        <telerik:RadTab runat="server" Owner="RadTabStrip1" Value="hoy" 
                            Text="Actividades Hoy " PageViewID="RadPageView1" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Owner="RadTabStrip1"  Value="atrazadas"
                            Text="Actividades Atrazadas" PageViewID="RadPageView2">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Owner="RadTabStrip1" Value="sinrecibir" 
                            Text="Solicitudes Sin Recibir" PageViewID="RadPageView3">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Owner="RadTabStrip1"  Value="sinrevisar"
                            Text="Solicitudes Pendientes" PageViewID="RadPageView4">
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
                        <asp:GridView ID="grdAvisosHoy" runat="server" AllowSorting="True" DataSourceID="ObjAvisosHoy"
                            EnableModelValidation="True" DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False"
                            EmptyDataText="No tiene tareas pendientes para hoy">
                            <Columns>
                                <asp:BoundField DataField="Num_Proc" HeaderText="N° de Proceso" SortExpression="Num_Proc" />
                                <asp:BoundField DataField="Nom_Act" HeaderText="Actividad" SortExpression="Nom_Act" />
                                <asp:BoundField DataField="DateTimeI" HeaderText="Fecha y Hora Inicial" SortExpression="DateTimeI" />
                                <asp:BoundField DataField="Notas" HeaderText="Notas" SortExpression="Notas" />
                                <asp:BoundField DataField="Ocupado" HeaderText="Ocupado" SortExpression="Ocupado" />
                                <asp:BoundField DataField="Nom_Est" HeaderText="Estado" SortExpression="Nom_Est" />
                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/BlueTheme/Select.png" />
                            </Columns>
                        </asp:GridView>

                     
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server">
                        <br />
                        <asp:GridView ID="grdAtrazadas" runat="server" AllowSorting="True" DataSourceID="ObjAtrasados"
                            EnableModelValidation="True" DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Num_Proc" HeaderText="N° de Proceso" SortExpression="Num_Proc" />
                                <asp:BoundField DataField="Nom_Act" HeaderText="Actividad" SortExpression="Nom_Act" />
                                <asp:BoundField DataField="DateTimeI" HeaderText="Fecha y Hora Inicial" SortExpression="DateTimeI" />
                                <asp:BoundField DataField="Notas" HeaderText="Notas" SortExpression="Notas" />
                                <asp:BoundField DataField="Ocupado" HeaderText="Ocupado" SortExpression="Ocupado" />
                                <asp:BoundField DataField="Nom_Est" HeaderText="Estado" SortExpression="Nom_Est" />
                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/BlueTheme/Select.png" />
                            </Columns>
                        </asp:GridView>
                        
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView3" runat="server">
                    <asp:GridView 
                id="grdRecibir" runat="server" DataSourceID="ObjPSol" 
                DataKeyNames="Cod_Sol" 
                AutoGenerateColumns="False" 
                EmptyDataText="No tiene solicitudes pendientes para recibir" 
        AllowSorting="True" EnableModelValidation="True">
                <Columns>
    
                <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                    <ItemTemplate>
                <asp:Label id="LbCod0" runat="server" Text='<%# Bind("Cod_Sol") %>' 
                        ></asp:Label> 
                </ItemTemplate>
                </asp:TemplateField>
                    <asp:BoundField DataField="Encargado" HeaderText="Encargado" 
                        SortExpression="Encargado" />
                <asp:TemplateField HeaderText="Objeto del Contrato" SortExpression="Obj_sol">
                    <ItemTemplate>
                <asp:Label id="Lbcimp0" runat="server" Text='<%# Bind("Obj_sol") %>' 
                            ></asp:Label> 
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dependencia a Cargo" SortExpression="Dep_Del">
                    <ItemTemplate>
                <asp:Label id="LbEst0" runat="server" Text='<%# Bind("Dep_Del") %>' 
                            ></asp:Label> 
                </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dependencia que Solicita" 
                        SortExpression="Dep_Nec">
                     <ItemTemplate>
                <asp:Label id="LbVal0" runat="server" Text='<%# Bind("Dep_Nec") %>' 
                            ></asp:Label> 
                </ItemTemplate>
                    </asp:TemplateField>
    
                    <asp:TemplateField HeaderText="Fecha de Registro" 
                            SortExpression="FECHA_REGISTRO">
                          <ItemTemplate>
                            <asp:Label ID="LbFR" runat="server" 
                                Text='<%# Bind("FECHA_REGISTRO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha Asignación" SortExpression="FEC_ASIGNADO">
                        <ItemTemplate>
                            <asp:Label ID="LbFEC_ASIGNADO" runat="server" 
                                Text='<%# Bind("FEC_ASIGNADO") %>'></asp:Label>
                        </ItemTemplate>
                </asp:TemplateField>
    
                <asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" 
                        ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
    
                </Columns>
                <EmptyDataTemplate>
                <br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No tiene Solicitudes pendientes por Recibir"></asp:Label>
                    </EmptyDataTemplate>
        </asp:GridView>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView4" runat="server">
                        <asp:GridView ID="grdRevisar" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" DataKeyNames="Cod_Sol" DataSourceID="ObjPSolRv"
                    EmptyDataText="No tiene solicitudes pendientes para revisar" 
                    EnableModelValidation="True" >
                    <Columns>
                        <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                            <ItemTemplate>
                                <asp:Label ID="LbCod" runat="server" 
                                    Text='<%# Bind("Cod_Sol") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Encargado" SortExpression="Encargado" >
                        <ItemTemplate>
                                <asp:Label ID="LbEncar" runat="server" 
                                    Text='<%# Bind("encargado") %>'></asp:Label>
                         </ItemTemplate>
                         </asp:TemplateField>
                        <asp:TemplateField HeaderText="Objeto del Contrato" SortExpression="Obj_sol">
                            <ItemTemplate>
                                <asp:Label ID="Lbcimp" runat="server" 
                                    Text='<%# Bind("Obj_sol") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dependencia a Cargo" SortExpression="Dep_Del">
                            <ItemTemplate>
                                <asp:Label ID="LbEst" runat="server" 
                                    Text='<%# Bind("Dep_Del") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dependencia que genera" 
                            SortExpression="Val_Prop">
                            <ItemTemplate>
                                <asp:Label ID="LbVal" runat="server" 
                                    Text='<%# Bind("Dep_Nec") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Fecha de Registro" 
                            SortExpression="FECHA_RECIBIDO">
                          <ItemTemplate>
                            <asp:Label ID="LbFR" runat="server" 
                                Text='<%# Bind("FECHA_REGISTRO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de Asignación" 
                            SortExpression="FEC_ASIGNADO">
                          <ItemTemplate>
                            <asp:Label ID="LbFA" runat="server" 
                                Text='<%# Bind("FEC_ASIGNADO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        
                    <asp:TemplateField HeaderText="Fecha de Recibido Encargado" 
                            SortExpression="FEC_REC_ABOG">
                          <ItemTemplate>
                            <asp:Label ID="LbFRA" runat="server" 
                                Text='<%# Bind("FEC_REC_ABOG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observación Recibido" 
                            SortExpression="OBSERVACION_RECIBIDO">
                          <ItemTemplate>
                            <asp:Label ID="LbOR" runat="server" 
                                Text='<%# Bind("OBSERVACION_RECIBIDO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de Revisión" 
                            SortExpression="FECHA_REVISADO">
                          <ItemTemplate>
                            <asp:Label ID="LbFRV" runat="server" 
                                Text='<%# Bind("FECHA_REVISADO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Observación Revisión" 
                            SortExpression="obs_revisado">
                          <ItemTemplate>
                            <asp:Label ID="Lbobs" runat="server" 
                                Text='<%# Bind("obs_revisado") %>'></asp:Label>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                    </Columns>
                    <EmptyDataTemplate>
                    <br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No tiene Solicitudes pendientes por Revisar"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView5" runat="server">
                        <div style="float:right">
                        <asp:LinkButton ID="lnkVerTodos" runat="server">Ver Todos</asp:LinkButton>
                        
                        <asp:HyperLink ID="hlProcesos" Target="_blank" 
                                NavigateUrl="~/Reportes/PanelProcesosE/PanelReporteE.aspx" runat="server">Panel de Procesos</asp:HyperLink>
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
                        <asp:GridView 
                id="grdProcACargo" runat="server" DataSourceID="ObjConPContratosD"
                DataKeyNames="Pro_Sel_Nro" 
                AutoGenerateColumns="False" 
                EmptyDataText="No tiene procesos a cargo" 
                EnableModelValidation="True" AllowSorting="True" Width="100%">
<Columns>
    <asp:BoundField DataField="Pro_Sel_Nro" HeaderText="N° de Proceso" 
        SortExpression="Pro_Sel_Nro" />
    <asp:BoundField DataField="Encargado" HeaderText="Encargado" 
        SortExpression="Encargado" />
    <asp:BoundField DataField="Nom_TProc" HeaderText="Tipo de Procesos" 
        SortExpression="Nom_TProc" />
    <asp:BoundField HeaderText="Objeto a Contratar" SortExpression="Obj_Con" 
        DataField="Obj_Con" >
    </asp:BoundField>
    <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia-Necesidad" 
        SortExpression="Dep_Nec" />
    <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia-A Cargo" 
        SortExpression="Dep_Del" />
    
    <asp:BoundField HeaderText="Tipo" SortExpression="TIPDOCUMENTO" 
        DataField="TIPDOCUMENTO" >
    </asp:BoundField>
    
    <asp:BoundField HeaderText="Sub Tipo" SortExpression="NOMSTIP" 
        DataField="NOMSTIP" >
    </asp:BoundField>

    <asp:BoundField HeaderText="Estado del Proceso" SortExpression="NOM_EST" 
        DataField="NOM_EST" >
    </asp:BoundField>

    <asp:ButtonField ButtonType="Image" CommandName="hojaRutas" HeaderText="Hoja de Ruta" 
                                    ImageUrl="~/images/2013/listcheck.png" Text="Diligenciar Hoja de Ruta" />
    <asp:ButtonField ButtonType="Image" CommandName="crono" HeaderText="Cronograma" 
        ImageUrl="~/images/mnProcesos/Calendar-icon24.png" Text="Cronograma">
    <ItemStyle HorizontalAlign="Center" />
    </asp:ButtonField>
    <asp:ButtonField ButtonType="Image" CommandName="documentos" HeaderText="Documentos"
                                    ImageUrl="~/images/2012/archivo.png" Text="Documentos Precontractuales" />
    <asp:ButtonField ButtonType="Image" Visible="false" CommandName="dbproc" 
        HeaderText="Datos del Proceso" ImageUrl="~/images/Operaciones/Edit.png">
    <ItemStyle HorizontalAlign="Center" />
    </asp:ButtonField>
    
</Columns>
<EmptyDataTemplate>
<br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No se encontraron registros "></asp:Label>
                    </EmptyDataTemplate>
</asp:GridView> 
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <br />
                <br />
                <br />
                <asp:ObjectDataSource ID="ObjConPContratos" runat="server" 
                    OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetMisProcesos" TypeName="AvisosAct" InsertMethod="InsertP">
                    <SelectParameters>
                        <asp:SessionParameter Name="vigencia" SessionField="vigencia" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjAvisosHoy" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetAvisosHoy" TypeName="PCronogramas"></asp:ObjectDataSource>
                <br />
                <asp:ObjectDataSource ID="ObjAtrasados" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetAvisosAtrasados" TypeName="PCronogramas"></asp:ObjectDataSource>
                
                <asp:ObjectDataSource ID="ObjPSol" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetByAbog" TypeName="PSolicitudes"></asp:ObjectDataSource>

                <asp:ObjectDataSource ID="ObjPSolRv" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetSolPen" TypeName="ConSolicitudes" >
                   
                </asp:ObjectDataSource>
                <br />
                <asp:HiddenField ID="HdPNom_Est" runat="server" />
                <asp:ObjectDataSource ID="ObjConPContratosD" runat="server"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetMisProcbyEstado"
                    TypeName="AvisosAct">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HdPNom_Est" Name="Nom_Est" PropertyName="Value"
                            Type="String" />
                        <asp:SessionParameter Name="Vigencia" SessionField="vigencia" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" >
                    <ProgressTemplate>
                        <uc1:Progress ID="Progress1" runat="server" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
