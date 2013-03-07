<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Adjudicacion.aspx.vb" Inherits="Procesos_Adjudicacion_Default" %>

<%@ Register src="../../CtrlUsr/DetPContratos/DetPContrato.ascx" tagname="DetPContrato" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
<ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxtoolkit:toolkitscriptmanager>
        <asp:Label ID="Label10" runat="server" CssClass="Titulo" 
            Text="Adjudicacion de Procesos"></asp:Label>

            <asp:UpdatePanel ID="UpdatePanel1"  UpdateMode="Conditional"
        runat="server" >
        <contenttemplate> 
    <uc1:DetPContrato ID="DetPContrato1" runat="server" />
     <asp:Panel ID="PanelvConP" runat="server" BackColor="White" Width="900px" Height="500px">
            <asp:Panel ID="Panel1" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
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

    <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
    <table style="width: 100%">
        <tr>
            <td style="width: 553px">
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="IbAdjudicar" runat="server" Width="28px" Height="29px" 
                    ImageUrl="~/images/mnProcesos/Text-Edit-icon128.png" ToolTip="Adjudicar" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Seleccione Proponente" 
                    Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView 
                id="GridView1" runat="server" Width="589px" ForeColor="#333333" 
                AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" 
                DataSourceID="ObjPProp" GridLines="None" CellPadding="4" 
                DataKeyNames="Ide_Prop" 
                AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
    <asp:TemplateField HeaderText="Seleccionar">
        <ItemTemplate>
            <asp:CheckBox ID="ChkProp" runat="server" Checked='<%# eval("est") %>'/>
        </ItemTemplate>
    </asp:TemplateField>
<asp:TemplateField HeaderText="Identificación" SortExpression="Ide_Prop">
    <ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("Ide_Prop") %>' 
        __designer:wfdid="w9"></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre del Proponente" SortExpression="Nom_Ter">
    <ItemTemplate>
<asp:Label id="Lbcimp" runat="server" Text='<%# Bind("Razon_Social") %>' 
            __designer:wfdid="w21"></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha de la Propuesta" SortExpression="Fec_Prop">
    <ItemTemplate>
<asp:Label id="LbEst" runat="server" Text='<%# Bind("Fec_Prop","{0:d}") %>' 
            __designer:wfdid="w22"></asp:Label> 
    </ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Valor de la Propuesta" SortExpression="Val_Prop">
     <ItemTemplate>
<asp:Label id="LbVal" runat="server" Text='<%# Bind("Val_Prop","{0:c}") %>' 
            __designer:wfdid="w22"></asp:Label> 
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Adjudicado" SortExpression="Adjudicado">
    <ItemTemplate>
<asp:Label id="LbAdj" runat="server" Text='<%# Bind("Adjudicado") %>' 
            __designer:wfdid="w22"></asp:Label> 
    </ItemTemplate>
    </asp:TemplateField>
                    </Columns>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                </asp:GridView> 
            </td>
        </tr>
       
    </table>
    <br />
     <asp:ObjectDataSource ID="ObjPProp" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyAdjudicado" 
            TypeName="PProponentes">
            <SelectParameters>
                <asp:ControlParameter ControlID="DetPContrato1" Name="Num_Proc" 
                    PropertyName="CodigoPContrato" Type="String" />
            </SelectParameters>
            </asp:ObjectDataSource>
    <br />
        <asp:Panel ID="PanelOperaciones" runat="server" BackColor="White" Width="379px">
            <asp:Panel ID="Panel4" runat="server" BorderColor="White"  CssClass="BarTitleModal2"
                Height="27px" Width="379px">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 1159px">
                            <asp:Label ID="Label18" runat="server" ForeColor="White" Text="Adjudicación" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <table style="width:376px;">
                <tr>
                    <td style="width: 123px">
                        &nbsp;</td>
                    <td style="width: 233px" colspan="2">
                        &nbsp;</td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label ID="Label19" runat="server" Text="Identificación"></asp:Label>
                    </td>
                    <td style="width: 233px" colspan="2">
                        <asp:TextBox ID="TxtIdPr" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label ID="Label16" runat="server" Text="Nombre del Proponente"></asp:Label>
                    </td>
                    <td style="width: 233px" colspan="2">
                        <asp:TextBox ID="Txt_nomPro" runat="server" Width="234px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label ID="Label17" runat="server" Text="Fecha de la Propuesta"></asp:Label>
                   
                    </td>
                    <td style="width: 233px" colspan="2">
                        <asp:TextBox ID="Txt_FecPro" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label ID="Label20" runat="server" Text="Valor de la Propuesta"></asp:Label>
                    </td>
                    <td style="width: 233px" colspan="2">
                        <asp:TextBox ID="Txt_ValPro" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Label ID="Label21" runat="server" Text="Fecha de Adjudicacion"></asp:Label>
                    <ajaxToolkit:CalendarExtender 
                            ID="CalFechaAdj" 
                            runat="server" 
                            TargetControlID="TxtFecAdj" 
                            Format="dd/MM/yyyy"> 
                    </ajaxToolkit:CalendarExtender>
                    </td>
                    <td style="text-align: left">
                    
                        <asp:TextBox ID="TxtFecAdj" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td colspan="2" style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        
                        <asp:Label ID="Label22" runat="server" Text="Observacion"></asp:Label>
                    </td>
                    <td rowspan="3" style="text-align: left">
                        <asp:TextBox ID="TxtObservaciones" runat="server" Height="55px" TextMode="MultiLine" 
                            Width="234px"></asp:TextBox>
                    </td>
                    <td colspan="2" style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        &nbsp;</td>
                    <td colspan="2" style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        &nbsp;</td>
                    <td colspan="2" style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="Btn_Adjudicar" runat="server" OnClick="Btn_Adjudicar_Click" 
                            Text="Adjudicar" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target" runat="server"></asp:Button>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" 
        runat="server"
        TargetControlID="Btn_Target" 
        PopupControlID="PanelOperaciones" 
        CancelControlID="BtnCerrar" 
        BackgroundCssClass="modalBackground" 
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>

                </contenttemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>

