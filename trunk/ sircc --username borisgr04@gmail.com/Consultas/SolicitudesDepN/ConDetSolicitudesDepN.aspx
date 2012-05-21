<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConDetSolicitudesDepN.aspx.vb" Inherits="Consultas_ConDetSolicitudesDepN" %>

<%@ Register src="../../CtrlUsr/FiltroSol/FiltroSolP.ascx" tagname="FiltroSolP" tagprefix="uc1" %>
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
                            CellPadding="4" DataKeyNames="Cod_Sol" EnableModelValidation="True" 
                            Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="84px" 
                            Width="91%" DataSourceID="ObjSol">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <EmptyDataTemplate>
                                <asp:Label ID="MsgResult" runat="server" CssClass="alerta" SkinID="MsgResult" 
                                    Text="No se encontraro la solicitud en la base de datos "></asp:Label>
                            </EmptyDataTemplate>
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <Fields>
                                <asp:BoundField DataField="Cod_Sol" HeaderText="Número de la Solicitud" 
                                    SortExpression="Cod_Sol">
                                <ItemStyle Font-Bold="True" Font-Size="Medium" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOM_TPROC" HeaderText="Modalidad de Contratación" 
                                    SortExpression="NOM_TPROC" />
                                <asp:BoundField DataField="OBJ_SOL" HeaderText="Objeto" 
                                    SortExpression="OBJ_SOL" />
                                <asp:BoundField DataField="Dep_Nec" 
                                    HeaderText="Dependencia que Genera la Necesidad" 
                                    SortExpression="Dep_Nec" />
                                <asp:BoundField DataField="DEP_DEL" 
                                    HeaderText="Dependencia a Cargo del Proceso" SortExpression="DEP_DEL" />
                                <asp:BoundField DataField="Encargado" HeaderText="Funcionario Encargado" 
                                    SortExpression="Encargado" />
                                <asp:BoundField DataField="EST_CONCEPTO" HeaderText="Concepto de Revisión" />
                            </Fields>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderTemplate>
                                INFORMACIÓN DETALLADA DE LA SOLICITUD
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="SubTitulo" 
                        Text="Historial de Revisiones de la Solicitud"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        DataSourceID="ObjectHRev" Width="912px" 
                                        DataKeyNames="Cod_Sol,Id_HRev" 
                        EnableModelValidation="True">
                                        <Columns>
                                            <asp:BoundField DataField="Id_HRev" HeaderText="Id" SortExpression="Id_HRev" />
                                            <asp:TemplateField HeaderText="Código de la Solicitud" SortExpression="Cod_Sol">
                                <ItemTemplate>
                                    <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                        Text='<%# Bind("Cod_Sol") %>'></asp:Label> 
                                            </ItemTemplate>
                                            
                                            
                                </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha de Registro" 
                                                SortExpression="Fecha_Recibido">
                            <ItemTemplate>
                            <asp:Label ID="LbFec" runat="server" __designer:wfdid="w9" 
                                    Text='<%# Bind("Fecha_Recibido","{0:d}") %>'></asp:Label> 
                                            </ItemTemplate>
                                            
                                            
                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha Recibido Abogado" 
                                                SortExpression="Fec_Rec_Abog">
                            <ItemTemplate>
                            <asp:Label ID="LbFec_Rec_Abog" runat="server" __designer:wfdid="w9" 
                                    Text='<%# Bind("Fec_Rec_Abog","{0:d}") %>'></asp:Label> 
                                            </ItemTemplate>
                                            
                                            
                            </asp:TemplateField>
                                         
                                            <asp:TemplateField HeaderText="Observacion Recibido" 
                                                SortExpression="Obs_Recibido">
                            <ItemTemplate>
                            <asp:Label ID="LbEncSig" runat="server" __designer:wfdid="w9" 
                                    Text='<%# Bind("Obs_Recibido_Abog") %>'></asp:Label> 
                                            </ItemTemplate>
                                            
                                            
                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha de Revision">
                            <ItemTemplate>
                            <asp:Label ID="LbEncAnt" runat="server" __designer:wfdid="w9" 
                                    Text='<%# Bind("Fecha_Revisado","{0:d}") %>'></asp:Label> 
                                            </ItemTemplate>
                                            
                                            
                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Observacion Revision">
                            <ItemTemplate>
                            <asp:Label ID="LbRec" runat="server" __designer:wfdid="w9" 
                                    Text='<%# Bind("Obs_Revisado") %>'></asp:Label> 
                                            </ItemTemplate>
                                            
                                            
                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Concepto de la Revision">
                            <ItemTemplate>
                            <asp:Label ID="Lbobs" runat="server" __designer:wfdid="w9" 
                                    Text='<%# Bind("Nom_Est") %>'></asp:Label> 
                                            </ItemTemplate>
                                            
                                            
                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Abogado que Recibe" 
                                                SortExpression="Nit_Abog_Recibe">
                                                <ItemTemplate>
                            <asp:Label ID="LbAbog" runat="server" Text='<%# Bind("Encargado") %>'></asp:Label> 
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="N° Proceso" 
                                                SortExpression="Pro_Sel_Nro">
                                                <ItemTemplate>
                                           <asp:Label ID="LbNumPro" runat="server" Text='<%# Bind("Pro_Sel_Nro") %>'></asp:Label> 
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                                
                                            <asp:HyperLinkField DataNavigateUrlFields="Cod_Sol,Id_Hrev" 
                                                DataNavigateUrlFormatString="RptRv.aspx?Cod_Sol={0}&Id_Hrev={1}&dest=word" 
                                                HeaderText="Imprimir Notificación" Target="_blank" 
                                                Text="Exportar a Word" />
                                            <asp:HyperLinkField DataNavigateUrlFields="Cod_Sol,Id_Hrev" 
                                                DataNavigateUrlFormatString="RptRv.aspx?Cod_Sol={0}&Id_Hrev={1}&dest=html" 
                                                HeaderText="Imprimir Notificación" Target="_blank" Text="Imprimir" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No hay conceptos de revisión en el sistema
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    </td>
                <td>
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
                        Text="Proceso Generado por la Solicitud"></asp:Label>
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
                        CellPadding="4" DataKeyNames="Pro_Sel_Nro" DataSourceID="ObjProc" 
                        EmptyDataText="La Solicitud no ha Generado Proceso" 
                        EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="227px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Pro_Sel_Nro" HeaderText="Proceso Generado" />
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
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetBySol" 
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
                            <asp:ControlParameter ControlID="HFCod_Sol" Name="Cod_Sol" PropertyName="Value" 
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
        <br />
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