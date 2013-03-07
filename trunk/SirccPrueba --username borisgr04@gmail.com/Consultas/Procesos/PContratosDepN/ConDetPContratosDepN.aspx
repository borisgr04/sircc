<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConDetPContratosDepN.aspx.vb" Inherits="Consultas_ConDetPContratosDepN" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

     <div class="demoheading">REPORTE DE SOLICITUDES</div>
        
        <table style="width:100%;">
            <tr>
                <td style="width: 788px">
                        <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" 
                            CellPadding="4" DataKeyNames="Pro_Sel_Nro" 
                            EnableModelValidation="True" Font-Size="X-Small" ForeColor="#333333" 
                            GridLines="None" Height="84px" Width="95%" DataSourceID="ObjPcont">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <Fields>
                                <asp:BoundField DataField="Nom_TProc" HeaderText="Tipo de Proceso" 
                                    SortExpression="Nom_TProc" />
                                <asp:BoundField DataField="PRO_SEL_NRO" HeaderText="N° Proceso " 
                                    SortExpression="PRO_SEL_NRO" >
                                    <ItemStyle Font-Bold="True" Font-Size="Medium" />
                                     </asp:BoundField>
                                <asp:BoundField DataField="OBJ_CON" HeaderText="Objeto" 
                                    SortExpression="OBJ_CON" />
                                <asp:BoundField DataField="PLA_EJE_CON" HeaderText="Plazo de Ejecución" 
                                    SortExpression="PLA_EJE_CON" />
                                <asp:BoundField DataField="VAL_CON" DataFormatString="{0:c}" 
                                    HeaderText="Valor " SortExpression="VAL_CON" />
                                <asp:BoundField DataField="Dep_Nec" 
                                    HeaderText="Dependencia que Genera la Necesidad" SortExpression="Dep_Nec" />
                                <asp:BoundField DataField="Dep_Del" 
                                    HeaderText="Dependencia a Cargo del Proceso" SortExpression="Dep_Del" />
                                <asp:BoundField DataField="Encargado" 
                                    HeaderText="Funcionario Encargado" SortExpression="Encargado" />
                                <asp:BoundField DataField="Nom_Est" 
                                    HeaderText="Estado del Proceso" SortExpression="Nom_Est" >
                                <ItemStyle Font-Bold="True" Font-Size="Medium" />
                                </asp:BoundField>
                            </Fields>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderTemplate>
                                INFORMACIÓN DETALLADA DEL PROCESO DE CONTRATACIÓN
                            </HeaderTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:DetailsView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 788px">
                    &nbsp;</td>
                <td>
                    <asp:LinkButton ID="LinkButton2" runat="server">Regresar</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="width: 788px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="SubTitulo" 
                        Text="Contratos Generados por el Proceso"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
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
            <tr>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataKeyNames="Pro_Sel_Nro,Grupo" DataSourceID="ObjProc" 
                        EmptyDataText="La Solicitud no ha Generado Proceso" 
                        EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                        Width="227px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Pro_Sel_Nro" HeaderText="Proceso Generado" />
                            <asp:BoundField DataField="Grupo" HeaderText="Grupo" />
                            <asp:CommandField ButtonType="Image" 
                                SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjProc" runat="server" InsertMethod="InsertP" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetLikeNProc" 
                        TypeName="GProcesos">
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
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HFCod_Sol" Name="Num_PCon" PropertyName="Value" 
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
            <asp:ObjectDataSource ID="ObjPcont" runat="server" InsertMethod="InsertP" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetByPk" 
                TypeName="PContratos">
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
                <SelectParameters>
                    <asp:ControlParameter ControlID="HFCod_Sol" Name="Num_PCon" 
                        PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjectHRev" runat="server"  
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetHrev" 
                                        TypeName="PSolicitudes" 
            InsertMethod="InsertHREV">
                                        <InsertParameters>
                                            <asp:Parameter Name="COD_SOL" Type="String" />
                                            <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
                                        </InsertParameters>
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="HFCod_Sol" Name="Cod_Sol" 
                                                PropertyName="Value" Type="String" />
                                            <asp:Parameter Name="connect" Type="Boolean" />
                                        </SelectParameters>
                                  
                                    </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjSol" runat="server" 
            InsertMethod="InsertHREV" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetByPkDepNec" TypeName="PSolicitudes">
                                    <InsertParameters>
                                        <asp:Parameter Name="COD_SOL" Type="String" />
                                        <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="HFCod_Sol" Name="Cod_Sol" PropertyName="Value" 
                                            Type="String" />
                                        <asp:Parameter Name="connect" Type="Boolean" />
                                    </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="HFCod_Sol" runat="server" />
        <br />

     </div>
</asp:Content>