﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AvisosActD.aspx.vb" Inherits="Consultas_AvisosActD_Default" %>
                  
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server" >
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true" EnableScriptGlobalization="True" EnablePartialRendering="true" >
    </ajaxToolkit:ToolkitScriptManager>
             
        <asp:Label ID="Label11" runat="server" CssClass="Titulo" 
            Text="Panel de procesos de contratación por dependencia"></asp:Label>
        <br />
        <br />

             
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
        Skin="Windows7" MultiPageID="RadMultiPage1" ReorderTabsOnSelect="True" 
        SelectedIndex="6">
    <Tabs>
        <telerik:RadTab runat="server" Value="asignar" Owner="RadTabStrip1" PageViewID="RpSolAsig" 
            Text="Solicitudes sin Asignar">
        </telerik:RadTab>
    <telerik:RadTab Text="Solicitudes por Recibir" Value="recibir" 
            PageViewID="RpSolRec">
    </telerik:RadTab>
        <telerik:RadTab runat="server" Owner="RadTabStrip1" Value="revisar" PageViewID="RpSolRev" 
            Text="Solicitudes por Revisar">
        </telerik:RadTab>
        <telerik:RadTab runat="server" PageViewID="RpSolAcep" Value="Aceptadas" 
            Text="Solicitudes Aceptadas">
        </telerik:RadTab>
        <telerik:RadTab runat="server" PageViewID="RpSolRech" Value="Rechazadas" 
            Text="Solicitudes Rechazadas">
        </telerik:RadTab>
    <telerik:RadTab Text="Actividades para Hoy" Value="hoy" PageViewID="RpActHoy" >
    </telerik:RadTab>
    <telerik:RadTab Text="Actividades Atrasadas" Value="atrazadas" 
            PageViewID="RpActAtra" Selected="True">
    </telerik:RadTab>
    <telerik:RadTab Text="Procesos a Cargo" Value="procesos" PageViewID="RpProcCar">
    </telerik:RadTab>
    </Tabs>
    </telerik:RadTabStrip>

                 
    <table style="width: 100%">
        <tr>
            <td style="width: 135px">
                <asp:Label ID="Label25" runat="server" CssClass="selectIndex" 
                    Text="Fecha Inicial"></asp:Label>
            </td>
            <td style="width: 145px">
                <asp:Label ID="Label26" runat="server" CssClass="selectIndex" 
                    Text="Fecha Final"></asp:Label>
            </td>
            <td style="width: 144px">
                <asp:Label ID="Label28" runat="server" CssClass="selectIndex" 
                    Text="N° Solicitud"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LbConcepto" runat="server" CssClass="selectIndex" 
                    Text="Concepto" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
               
        <tr>
            <td style="width: 135px">
                <asp:TextBox ID="TxtDesde" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtDesde_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtDesde" Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="width: 145px">
                <asp:TextBox ID="TxtHasta" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtHasta_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtHasta" Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="width: 144px">
                <asp:TextBox ID="TxtNSol" runat="server"></asp:TextBox>
            </td>
            <td>
                 <asp:ImageButton ID="ImageButton1" runat="server" SkinID="IBtnBuscar" />
            </td>
            <td>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Consultas/AvisosAct/AvisosAct2.aspx">Ir a Panel de Funcionario</asp:HyperLink>
             
                &nbsp;&nbsp;
                    <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl="~/Solicitudes/NuevaSolicitud/NuevaSolicitud.aspx">Nueva Solicitud</asp:HyperLink></td>
            <td>
                &nbsp;</td>
        </tr>
               
        <tr>
            <td style="width: 135px">
                &nbsp;</td>
            <td style="width: 145px">
                &nbsp;</td>
            <td colspan="3">
                <asp:Label ID="LBPrueba" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
               
    </table>

    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="4" 
        BorderStyle="None">

            <telerik:RadPageView ID="RpSolAsig" runat="server">
            <br />
            <asp:Label ID="Label1" runat="server" CssClass="SubTitulo" 
                Text="Solicitudes sin Asignar"></asp:Label>
                <br />
            <br />
        <asp:GridView ID="grdxRevisar" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" DataKeyNames="Cod_Sol" 
                EmptyDataText="No tiene solicitudes pendientes para revisar" 
                EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                        <ItemTemplate>
                            <asp:Label ID="LbCod1" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Cod_Sol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Objeto del Contrato" SortExpression="Obj_sol">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp1" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Obj_sol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dependencia a Cargo" SortExpression="Dep_Del">
                        <ItemTemplate>
                            <asp:Label ID="LbEst1" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Dep_Del") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dependencia que genera" 
                        SortExpression="Val_Prop">
                        <ItemTemplate>
                            <asp:Label ID="LbVal1" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Dep_Nec") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>
                <EmptyDataTemplate>
                    <br />
                    <asp:Label ID="Label3" runat="server" CssClass="infor" 
                        Text="No tiene Solicitudes pendientes para Asignar"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RpSolAcep" runat="server">
            <br />
            <asp:Label ID="Label9" runat="server" CssClass="SubTitulo" 
                Text="Solicitudes Aceptadas"></asp:Label>
                <br />
            <br />
        <asp:GridView ID="GvAcep" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" DataKeyNames="Cod_Sol" 
                EmptyDataText="No tiene solicitudes pendientes para revisar" 
                EnableModelValidation="True" SkinID="gridView">
                <Columns>
                    <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                        <ItemTemplate>
                            <asp:Label ID="LbCod1" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Cod_Sol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="N° del Proceso" SortExpression="Cod_Sol">
                        <ItemTemplate>
                            <asp:Label ID="LbNumP" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Proceso") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Objeto del Contrato" SortExpression="Obj_sol">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp1" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Obj_sol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ENCARGADO" HeaderText="Encargado" 
                    SortExpression="ENCARGADO" />
                    <asp:TemplateField HeaderText="Dependencia a Cargo" SortExpression="Dep_Del">
                        <ItemTemplate>
                            <asp:Label ID="LbEst1" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Dep_Del") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dependencia que genera" 
                        SortExpression="Val_Prop">
                        <ItemTemplate>
                            <asp:Label ID="LbVal1" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Dep_Nec") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>
                <EmptyDataTemplate>
                    <br />
                    <asp:Label ID="Label3" runat="server" CssClass="infor" 
                        Text="No tiene Solicitudes Aceptadas"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjSolAcep" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetSolAcep" 
                TypeName="AvisosActD">
                <SelectParameters>
                    <asp:SessionParameter Name="Vigencia" SessionField="Vigencia" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RpSolRech" runat="server">
            <br />
            <asp:Label ID="Label10" runat="server" CssClass="SubTitulo" 
                Text="Solicitudes Rechazadas"></asp:Label>
                <br />
            <br />
        <asp:GridView ID="GvRech" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" DataKeyNames="Cod_Sol" 
                EmptyDataText="No tiene solicitudes pendientes para revisar" 
                EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">

                        <ItemTemplate>
                            <asp:Label ID="LbCod1" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Cod_Sol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Objeto del Contrato" SortExpression="Obj_sol">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp1" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Obj_sol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ENCARGADO" HeaderText="Encargado" 
                    SortExpression="ENCARGADO" />
                    <asp:TemplateField HeaderText="Dependencia a Cargo" SortExpression="Dep_Del">
                        <ItemTemplate>
                            <asp:Label ID="LbEst1" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Dep_Del") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dependencia que genera" 
                        SortExpression="Val_Prop">
                        <ItemTemplate>
                            <asp:Label ID="LbVal1" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Dep_Nec") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>
                <EmptyDataTemplate>
                    <br />
                    <asp:Label ID="Label3" runat="server" CssClass="infor" 
                        Text="No tiene Solicitudes Rechazadas"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjSolRech" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetSolRech" 
                TypeName="AvisosActD">
                <SelectParameters>
                    <asp:SessionParameter Name="Vigencia" SessionField="Vigencia" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RpActHoy" runat="server">
            <br />
            <asp:Label ID="Label4" runat="server" CssClass="SubTitulo" 
                Text="Actividades para Hoy"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server"
        AllowSorting="True" EnableModelValidation="True" 
        DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False" 
             EmptyDataText="No tiene tareas pendientes para hoy">
        <Columns>
            <asp:BoundField DataField="Num_Proc" HeaderText="N° de Proceso" 
                SortExpression="Num_Proc" />
            <asp:BoundField DataField="ENCARGADO" HeaderText="Encargado" 
                SortExpression="ENCARGADO" />
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
        <EmptyDataTemplate>
        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No tiene Actividades Programadas para hoy "></asp:Label>
                    </EmptyDataTemplate>
    </asp:GridView>    
        </telerik:RadPageView>
        <telerik:RadPageView ID="RpActAtra" runat="server">
            <br />
            <asp:Label ID="Label5" runat="server" CssClass="SubTitulo" 
                Text="Actividade Atrasadas"></asp:Label>
            <br />
        <br />
            <asp:GridView ID="GridView2" runat="server"
        AllowSorting="True" EnableModelValidation="True" 
        DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Num_Proc" HeaderText="N° de Proceso" 
                SortExpression="Num_Proc" />
            <asp:BoundField DataField="ENCARGADO" HeaderText="Encargado" 
                SortExpression="ENCARGADO" />
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
        <EmptyDataTemplate>
        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No tiene Actividades Atrazadas "></asp:Label>
                    </EmptyDataTemplate>
    </asp:GridView>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RPSolRec" runat="server">
            <br />
            <asp:Label ID="Label6" runat="server" CssClass="SubTitulo" 
                Text="Solicitudes por Recibir"></asp:Label>
            <br />
        <br />
            <asp:GridView OnRowDataBound="GridView1_RowDataBound" 
                id="grdRecibir" runat="server" 
                DataKeyNames="Cod_Sol" 
                AutoGenerateColumns="False" 
                EmptyDataText="No tiene solicitudes pendientes para recibir" 
        AllowSorting="True" EnableModelValidation="True">
                <Columns>
    
                <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                    <ItemTemplate>
                <asp:Label id="LbCod0" runat="server" Text='<%# Bind("Cod_Sol") %>' 
                        __designer:wfdid="w9"></asp:Label> 
                </ItemTemplate>
                </asp:TemplateField>
                    <asp:BoundField DataField="Encargado" HeaderText="Encargado" 
                        SortExpression="Encargado" />
                <asp:TemplateField HeaderText="Objeto del Contrato" SortExpression="Obj_sol">
                    <ItemTemplate>
                <asp:Label id="Lbcimp0" runat="server" Text='<%# Bind("Obj_sol") %>' 
                            __designer:wfdid="w21"></asp:Label> 
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dependencia a Cargo" SortExpression="Dep_Del">
                    <ItemTemplate>
                <asp:Label id="LbEst0" runat="server" Text='<%# Bind("Dep_Del") %>' 
                            __designer:wfdid="w22"></asp:Label> 
                </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dependencia que Solicita" 
                        SortExpression="Dep_Nec">
                     <ItemTemplate>
                <asp:Label id="LbVal0" runat="server" Text='<%# Bind("Dep_Nec") %>' 
                            __designer:wfdid="w22"></asp:Label> 
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
        <telerik:RadPageView ID="RpSolRev" runat="server">
            <br />
            <asp:Label ID="Label7" runat="server" CssClass="SubTitulo" 
                Text="Solicitudes por Revisar"></asp:Label>
            <br />
        <br />
            <asp:GridView ID="grdRevisar" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" DataKeyNames="Cod_Sol" 
                    EmptyDataText="No tiene solicitudes pendientes para revisar" 
                    EnableModelValidation="True" Width="724px">
                    <Columns>
                        <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                            <ItemTemplate>
                                <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                    Text='<%# Bind("Cod_Sol") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Encargado" HeaderText="Encargado" 
                            SortExpression="Encargado" />
                        <asp:TemplateField HeaderText="Objeto del Contrato" SortExpression="Obj_sol">
                            <ItemTemplate>
                                <asp:Label ID="Lbcimp" runat="server" __designer:wfdid="w21" 
                                    Text='<%# Bind("Obj_sol") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dependencia a Cargo" SortExpression="Dep_Del">
                            <ItemTemplate>
                                <asp:Label ID="LbEst" runat="server" __designer:wfdid="w22" 
                                    Text='<%# Bind("Dep_Del") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dependencia que genera" 
                            SortExpression="Val_Prop">
                            <ItemTemplate>
                                <asp:Label ID="LbVal" runat="server" __designer:wfdid="w22" 
                                    Text='<%# Bind("Dep_Nec") %>'></asp:Label>
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
        <telerik:RadPageView ID="RpProcCar" runat="server">
            <br />
            <asp:Label ID="Label8" runat="server" CssClass="SubTitulo" 
                Text="Procesos a Cargo"></asp:Label>
            <br />
        <br />
            <asp:DataList ID="DtProcesosACargo" runat="server" CellPadding="4" ForeColor="#333333" 
        RepeatDirection="Horizontal" DataKeyField="Estado">
        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" 
            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Estado")%>' OnClick="Selecc_DTProc"
            ToolTip='Click para ver más'>
            <%# DataBinder.Eval(Container.DataItem, "Estado") %>(<b><%# DataBinder.Eval(Container.DataItem, "Cantidad") %></b>)</asp:LinkButton>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
   
    <asp:ObjectDataSource ID="ObjConPContratos" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetProcesosxDepDel" TypeName="AvisosActD">
     
        <SelectParameters>
            <asp:SessionParameter Name="Vigencia" SessionField="Vigencia" Type="String" />
        </SelectParameters>
     
    </asp:ObjectDataSource>
                <asp:GridView 
                id="grdProcACargo" runat="server" OnRowDataBound="GridView1_RowDataBound" 
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
    <asp:ObjectDataSource ID="ObjAvisosHoy" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvisosHoyD" 
        TypeName="AvisosActD" InsertMethod="Insert" UpdateMethod="Anular">
        <InsertParameters>
            <asp:Parameter Name="NUM_PROC" Type="String" />
            <asp:Parameter Name="COD_ACT" Type="String" />
            <asp:Parameter Name="NOM_ACT" Type="String" />
            <asp:Parameter Name="COD_TPRO" Type="String" />
            <asp:Parameter Name="FECHAI" Type="DateTime" />
            <asp:Parameter Name="HORAI" Type="Int32" />
            <asp:Parameter Name="FECHAF" Type="DateTime" />
            <asp:Parameter Name="HORAF" Type="Int32" />
            <asp:Parameter Name="UBICACION" Type="String" />
            <asp:Parameter Name="NOTAS" Type="String" />
            <asp:Parameter Name="DIAS_AVISO" Type="Int32" />
            <asp:Parameter Name="OCUPADO" Type="Boolean" />
            <asp:Parameter Name="Color" Type="String" />
            <asp:Parameter Name="Obligatorio" Type="Boolean" />
            <asp:Parameter Name="Est_Proc" Type="String" />
            <asp:Parameter Name="FEC_AVISO" Type="String" />
            <asp:Parameter Name="NOTIFICAR" Type="String" />
            <asp:Parameter Name="MIN_I" Type="String" />
            <asp:Parameter Name="MIN_F" Type="String" />
            <asp:Parameter Name="MFecIni" Type="String" />
            <asp:Parameter Name="MHorIni" Type="String" />
            <asp:Parameter Name="MFecFin" Type="String" />
            <asp:Parameter Name="MHorFin" Type="String" />
            <asp:Parameter Name="lstFechas" Type="Object" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ID_O" Type="String" />
            <asp:Parameter Name="OBS_SEG" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjSolxAsig" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetxAsig" 
        TypeName="AvisosActD">
        <SelectParameters>
            <asp:SessionParameter Name="Vigencia" SessionField="Vigencia" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjAtrasados" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvisosAtrasadosD" 
        TypeName="AvisosActD" InsertMethod="Insert" UpdateMethod="Anular">
        <InsertParameters>
            <asp:Parameter Name="NUM_PROC" Type="String" />
            <asp:Parameter Name="COD_ACT" Type="String" />
            <asp:Parameter Name="NOM_ACT" Type="String" />
            <asp:Parameter Name="COD_TPRO" Type="String" />
            <asp:Parameter Name="FECHAI" Type="DateTime" />
            <asp:Parameter Name="HORAI" Type="Int32" />
            <asp:Parameter Name="FECHAF" Type="DateTime" />
            <asp:Parameter Name="HORAF" Type="Int32" />
            <asp:Parameter Name="UBICACION" Type="String" />
            <asp:Parameter Name="NOTAS" Type="String" />
            <asp:Parameter Name="DIAS_AVISO" Type="Int32" />
            <asp:Parameter Name="OCUPADO" Type="Boolean" />
            <asp:Parameter Name="Color" Type="String" />
            <asp:Parameter Name="Obligatorio" Type="Boolean" />
            <asp:Parameter Name="Est_Proc" Type="String" />
            <asp:Parameter Name="FEC_AVISO" Type="String" />
            <asp:Parameter Name="NOTIFICAR" Type="String" />
            <asp:Parameter Name="MIN_I" Type="String" />
            <asp:Parameter Name="MIN_F" Type="String" />
            <asp:Parameter Name="MFecIni" Type="String" />
            <asp:Parameter Name="MHorIni" Type="String" />
            <asp:Parameter Name="MFecFin" Type="String" />
            <asp:Parameter Name="MHorFin" Type="String" />
            <asp:Parameter Name="lstFechas" Type="Object" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ID_O" Type="String" />
            <asp:Parameter Name="OBS_SEG" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ObjPSol" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetxRecibirD" 
            TypeName="AvisosActD">
            <SelectParameters>
            <asp:SessionParameter Name="Vigencia" SessionField="Vigencia" Type="String" />
        </SelectParameters>
        </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="ObjPSolRv" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetSolPenD" 
            TypeName="AvisosActD" InsertMethod="InsertHREV">
            <SelectParameters>
            <asp:SessionParameter Name="Vigencia" SessionField="Vigencia" Type="String" />
        </SelectParameters>
         <InsertParameters>
             <asp:Parameter Name="COD_SOL" Type="String" />
             <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
         </InsertParameters>
        </asp:ObjectDataSource>

      
    <asp:HiddenField ID="HdPNom_Est" runat="server" />
                         
     

    <asp:ObjectDataSource ID="ObjConPContratosD" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetProcbyDepDelEstado" TypeName="AvisosActD">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdPNom_Est" Name="Nom_Est" 
                PropertyName="Value" Type="String" />
            <asp:SessionParameter Name="Vigencia" SessionField="Vigencia" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
            
    </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>

