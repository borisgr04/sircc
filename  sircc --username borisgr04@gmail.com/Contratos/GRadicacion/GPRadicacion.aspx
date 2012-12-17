<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GPRadicacion.aspx.vb" Inherits="Procesos_RadicarProc_GRadicacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../../CtrlUsr/ConPContratosR/ConPContratosR.ascx" tagname="ConPContratos" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    
    <asp:UpdatePanel ID="UpdRad" runat="server">
        <ContentTemplate>
            <table style="width: 73%;">
                <tr>
                    <td colspan="7" style="height: 21px">
                        <asp:CheckBox ID="ChkVerRadicacion" runat="server" AutoPostBack="True" 
                            Text="Ver Númeración" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="height: 21px">
                        <asp:GridView ID="GridView2" runat="server" DataSourceID="ObjCons" 
                            EnableModelValidation="True">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="height: 21px">
                        <asp:Label ID="lbClase0" runat="server" CssClass="Titulo" Font-Bold="True">DATOS DEL PROCESO A RADICAR</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 93px; height: 21px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 180px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 82px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 26px;">
                        &nbsp;</td>
                    <td style="height: 21px; width: 128px;">
                        Fecha de Radicación</td>
                    <td style="height: 21px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 220px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 93px; height: 21px">
                        <asp:Label ID="Label1" runat="server" Text="Código del Proceso"></asp:Label>
                    </td>
                    <td style="height: 21px; width: 180px">
                        <asp:TextBox ID="TxtNumProc" runat="server" AutoPostBack="True" Width="177px"></asp:TextBox>
                    </td>
                    <td style="height: 21px; width: 82px">
                        <asp:DropDownList ID="CboGrupos" runat="server" AutoPostBack="True" 
                            DataSourceID="ObjGrupos" DataTextField="Grupos" DataValueField="Grupo" 
                            Width="100px">
                        </asp:DropDownList>
                    </td>
                    <td style="height: 21px; width: 26px;">
                        <asp:ImageButton ID="BtnBuscar" runat="server" SkinID="IBtnBuscar" />
                    </td>
                    <td style="height: 21px; width: 128px;">
                        <asp:TextBox ID="TxtFecRad" runat="server" Font-Bold="True" Font-Size="Small" 
                            Width="127px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="FecRad" runat="server" Format="dd/MM/yyyy" 
                            TargetControlID="TxtFecRad">
                        </ajaxToolkit:CalendarExtender>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                            FilterType="Numbers, Custom" TargetControlID="TxtFecRad" ValidChars="/">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td style="height: 21px">
                        <asp:ImageButton ID="BtnRadicar" runat="server" Height="32px" 
                            SkinID="IBtnRadCont" />
                    </td>
                    <td style="height: 21px; width: 220px;">
                        <asp:ImageButton ID="IBtnMinuta" runat="server" SkinID="IBtnMinuta" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px" colspan="2">
                        &nbsp;</td>
                    <td style="height: 21px; width: 82px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 26px;">
                        Buscar</td>
                    <td style="height: 21px; width: 128px;">
                        &nbsp;</td>
                    <td style="height: 21px">
                        Radicar</td>
                    <td style="height: 21px; width: 220px;">
                        &nbsp;Minuta</td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 21px">
                        <asp:Label ID="lbClase" runat="server" CssClass="Titulo" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="height: 21px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 220px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 21px">
                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                    </td>
                    <td style="height: 21px; width: 220px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                    <div style="height:400px; overflow:auto">
                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                            CellPadding="4" DataSourceID="ObjPcont" EnableModelValidation="True" 
                            ForeColor="#333333" GridLines="None" HeaderText="Datos del Proceso Contractual" 
                            Height="50px" Width="653px">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <EditRowStyle BackColor="#999999" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <Fields>
                                <asp:BoundField DataField="Vig_Con" HeaderText="Vigencia" />
                                <asp:BoundField DataField="Pro_Sel_Nro" HeaderText="Proceso N°">
                                <ItemStyle Font-Size="Medium" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Contratista" HeaderText="Adjudicado a:" />
                                <asp:BoundField DataField="Obj_Con" HeaderText="Objeto del Contrato" />
                                <asp:BoundField DataField="PLAZOEJECUCION" HeaderText="Plazo de Ejecución" />
                                <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia de la Necesidad" />
                                <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia a Cargo" />
                                <asp:BoundField DataField="Nom_TProc" HeaderText="Modalidad de Contratación" />
                                <asp:BoundField DataField="Nom_Tip" HeaderText="Documento Contractual" />
                                <asp:BoundField DataField="Lug_Eje" HeaderText="Lugar de ejecución" />
                                <asp:BoundField DataField="Val_Con" DataFormatString="{0:c}" 
                                    HeaderText="Valor del Contrato" />
                                <asp:BoundField DataField="Val_Apo_Gob" DataFormatString="{0:c}" 
                                    HeaderText="Valor Aportes Propios" />
                                <asp:BoundField DataField="Encargado" HeaderText="Encargado" />
                                <asp:BoundField DataField="Nom_Estado" HeaderText="Estado" />
                            </Fields>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="Medium" 
                                ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        </asp:DetailsView>
                     </div>
                    </td>
                    <td valign="top" style="width: 220px">
                        &nbsp;</td>
                </tr>
            </table>
            <table style="width: 73%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:ObjectDataSource ID="ObjCons" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetCons" 
                TypeName="Vigencias">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hdVigencias" Name="Vig" PropertyName="Value" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="hdVigencias" runat="server" />
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Ide_Prop" 
                DataSourceID="ObjContratista" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                Width="589px" Caption="CONTRATISTA(S)">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Identificación" SortExpression="Ide_Prop">
                        <ItemTemplate>
                            <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Ide_Prop") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre del Proponente" SortExpression="Nom_Ter">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Razon_Social") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de la Propuesta" SortExpression="Fec_Prop">
                        <ItemTemplate>
                            <asp:Label ID="LbEst" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Fec_Prop","{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor de la Propuesta" SortExpression="Val_Prop">
                        <ItemTemplate>
                            <asp:Label ID="LbVal" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Val_Prop","{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Adjudicado" SortExpression="Adjudicado">
                        <ItemTemplate>
                            <asp:Label ID="LbAdj" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Adjudicado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjContratista" runat="server" DeleteMethod="Delete" 
                InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetbyAdjuicado" TypeName="GPProponentes" UpdateMethod="Adjudicar">
              
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtNumProc" Name="Num_Proc" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
              
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjPcont" runat="server" InsertMethod="InsertP" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetByPkRad" 
                TypeName="ConGProcesos">
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
                    <asp:ControlParameter ControlID="TxtNumProc" Name="Num_PCon" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="CboGrupos" Name="Grupo" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
<br />
        </ContentTemplate>
    </asp:UpdatePanel>
        <asp:ObjectDataSource ID="ObjGrupos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyProc" 
            TypeName="Grupos">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtNumProc" Name="Num_Proc" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <br />
    <asp:Panel ID="PanelvConP" runat="server" BackColor="White" Width="900px" Height="500px">
            <asp:Panel ID="Panel6" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
                Height="27px" Width="100%" >
                <table style="width:100%;">
                    <tr>
                        <td style="width: 1159px">
                            <asp:Label ID="LbTitModal" runat="server" ForeColor="White" Text=" Consulta de Procesos a Cargo" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar2" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
            <uc4:ConPContratos ID="ConPContratos1" runat="server" />
            
            </asp:Panel>
             </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target2" runat="server"></asp:Button>
           <ajaxToolkit:ModalPopupExtender ID="ModalPopupConP" 
        runat="server"
        TargetControlID="Btn_Target2" 
        PopupControlID="PanelvConP" 
        CancelControlID="BtnCerrar2" 
        BackgroundCssClass="modalBackground"
        PopupDragHandleControlID="Panel4" 
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>   
</div>
</asp:Content>

