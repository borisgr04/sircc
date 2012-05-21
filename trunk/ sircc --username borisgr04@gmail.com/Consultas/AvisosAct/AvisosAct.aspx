<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AvisosAct.aspx.vb" Inherits="Consultas_AvisosAct_Default" %>
                  
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server" >
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true" EnablePartialRendering="true" >
    </ajaxToolkit:ToolkitScriptManager>
             
    <br />
             
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table cellpadding="10px" >
<tr>
<td><div class="demoheading">Actividades Pendientes para Hoy </div>
 <div id="DIV2"  style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            >
         <asp:GridView ID="GridView1" runat="server"
        AllowSorting="True" DataSourceID="ObjAvisosHoy" EnableModelValidation="True" 
        DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False" 
             EmptyDataText="No tiene tareas pendientes para hoy">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Image" 
                SelectImageUrl="~/images/BlueTheme/Select.png" />
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
        </Columns>
        <EmptyDataTemplate>
        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No tiene Actividades Programadas para hoy "></asp:Label>
                    </EmptyDataTemplate>
    </asp:GridView>
    </div></td>
<td>
<div class="demoheading">Actividades Atrasadas y/o en Curso </div>
<div id="DIV1"  style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            >
<asp:GridView ID="GridView2" runat="server"
        AllowSorting="True" DataSourceID="ObjAtrasados" EnableModelValidation="True" 
        DataKeyNames="Num_Proc,ID" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Image" 
                SelectImageUrl="~/images/BlueTheme/Select.png" />
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
        </Columns>
        <EmptyDataTemplate>
        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No tiene Actividades Atrazadas "></asp:Label>
                    </EmptyDataTemplate>
    </asp:GridView>
    </div>
</td>
</tr>
<tr>
<td>
  <div class="demoheading">Solicitudes Pendientes por Recibir </div>
        <div id="DIV3"  style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            >
                <asp:GridView OnRowDataBound="GridView1_RowDataBound" 
                id="grdRecibir" runat="server" Width="724px" 
                DataSourceID="ObjPSol" 
                DataKeyNames="Cod_Sol" 
                AutoGenerateColumns="False" 
                EmptyDataText="No tiene solicitudes pendientes para recibir" 
        AllowSorting="True" EnableModelValidation="True">
                <Columns>
    
                <asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" 
                        ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
                <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                    <ItemTemplate>
                <asp:Label id="LbCod0" runat="server" Text='<%# Bind("Cod_Sol") %>' 
                        __designer:wfdid="w9"></asp:Label> 
                </ItemTemplate>
                </asp:TemplateField>
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
    
                </Columns>
                <EmptyDataTemplate>
                <br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No tiene Solicitudes pendientes por Recibir"></asp:Label>
                    </EmptyDataTemplate>
        </asp:GridView> 
        </div>
</td>
<td>
   <div class="demoheading">Solicitudes Pendientes por Revisar </div>
   <div id="DIV4"  style="z-index: 101; overflow: auto; width: 439px;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            >
                <asp:GridView ID="grdRevisar" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" DataKeyNames="Cod_Sol" DataSourceID="ObjPSolRv" 
                    EmptyDataText="No tiene solicitudes pendientes para revisar" 
                    EnableModelValidation="True" Width="724px">
                    <Columns>
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="Código" SortExpression="Cod_Sol">
                            <ItemTemplate>
                                <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                    Text='<%# Bind("Cod_Sol") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                    </Columns>
                    <EmptyDataTemplate>
                    <br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No tiene Solicitudes pendientes por Revisar"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
        </div>
</td>
</tr>
<tr>
<td colspan=2>
  <div class="demoheading">
              Procesos a cargo
    </div>
    <asp:DataList ID="DtProcesosACargo" runat="server" CellPadding="4" ForeColor="#333333" 
        RepeatDirection="Horizontal" DataKeyField="Estado" 
        DataSourceID="ObjConPContratos">
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
   
    <asp:ObjectDataSource ID="ObjConPContratos" runat="server" 
        InsertMethod="InsertP" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetMisProcesos" TypeName="Con_PContratos">
     
    </asp:ObjectDataSource>
      
        <div id="DIV5"  style="z-index: 101; overflow: auto; width: 100%;
                    height: 187px; background-color: transparent; border-bottom-style: outset" 
                            >
                <asp:GridView 
                id="grdProcACargo" runat="server" OnRowDataBound="GridView1_RowDataBound" 
                DataSourceID="ObjConPContratosD" 
                DataKeyNames="Pro_Sel_Nro" 
                AutoGenerateColumns="False" 
                EmptyDataText="No tiene procesos a cargo" 
                EnableModelValidation="True" AllowSorting="True" Width="100%">
<Columns>
    
    <asp:ButtonField ButtonType="Image" CommandName="crono" HeaderText="Cronograma" 
        ImageUrl="~/images/mnProcesos/Calendar-icon24.png" Text="Cronograma">
    <ItemStyle HorizontalAlign="Center" />
    </asp:ButtonField>
    <asp:ButtonField ButtonType="Image" CommandName="dbproc" 
        HeaderText="Datos del Proceso" ImageUrl="~/images/Operaciones/Edit.png">
    <ItemStyle HorizontalAlign="Center" />
    </asp:ButtonField>
    <asp:BoundField DataField="Pro_Sel_Nro" HeaderText="N° de Proceso" 
        SortExpression="Pro_Sel_Nro" />
    <asp:BoundField DataField="Nom_TProc" HeaderText="Tipo de Procesos" 
        SortExpression="Nom_TProc" />
    <asp:BoundField HeaderText="Objeto a Contratar" SortExpression="Obj_Con" 
        DataField="Obj_Con" >
    
    </asp:BoundField>
    
    <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia-Necesidad" 
        SortExpression="Dep_Nec" />
    <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia-A Cargo" 
        SortExpression="Dep_Del" />
    
</Columns>
<EmptyDataTemplate>
<br />
                        <asp:Label ID="Label2" runat="server" CssClass="infor" 
                            Text="No se encontraron registros "></asp:Label>
                    </EmptyDataTemplate>
</asp:GridView> 

        </div></td>
</tr>
</table>
 
    <asp:ObjectDataSource ID="ObjAvisosHoy" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvisosHoy" 
        TypeName="PCronogramas"></asp:ObjectDataSource>

    <br />
    <asp:ObjectDataSource ID="ObjAtrasados" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvisosAtrasados" 
        TypeName="PCronogramas"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="ObjPSol" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByAbog" 
            TypeName="PSolicitudes">
        </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="ObjPSolRv" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetSolPen" 
            TypeName="ConSolicitudes" InsertMethod="InsertHREV">
         <InsertParameters>
             <asp:Parameter Name="COD_SOL" Type="String" />
             <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
         </InsertParameters>
        </asp:ObjectDataSource>

      
    <br />
  
  
    <asp:HiddenField ID="HdPNom_Est" runat="server" />
                         
     

    <asp:ObjectDataSource ID="ObjConPContratosD" runat="server" 
        InsertMethod="InsertP" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetMisProcbyEstado" TypeName="Con_PContratos">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdPNom_Est" Name="Nom_Est" 
                PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>

