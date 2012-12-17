<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Asignaciones.aspx.vb" Inherits="Solicitudes_Asignaciones_Default" %>

<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTerxDep.ascx" TagName="consultaterxDep"
    TagPrefix="uc1" %>
<%@ Register Src="../../CtrlUsr/DepSolicitudes/DetPSolicitudes.ascx"
    TagName="DetPSolicitudes" TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/Solicitudes/DetPSolicitudesAll.ascx" TagName="DetPSolicitudesAll"
    TagPrefix="uc3" %>
<%@ Register Src="../../CtrlUsr/Progreso/Progress.ascx" TagName="Progress" TagPrefix="ucProg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <script type='text/javascript'>
// Add click handlers for buttons to show and hide modal popup on pageLoad
      function enviar(ced,rsocial,tip_ter)
         {
         document.aspnetForm.<%=Me.TxtIde.ClientID%>.value=ced;
         document.aspnetForm.<%=Me.TxtNomTer.ClientID%>.value=rsocial;
         __doPostBack("<%= BtnBuscar.ClientID %>","");
         }
    </script>
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
        <div>
            <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="2000" Enabled="false">
            </asp:Timer>
        </div>
        <div class="demoheading">
            Asignaciones de Solicitudes
        </div>
       
        <asp:UpdatePanel ID="UpdAsig" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <uc3:DetPSolicitudesAll ID="DetPSolicitudesAll1" runat="server" />
             <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Solicitudes/Asignaciones/ConAsignaciones.aspx" Target="_blank">Ver Carga de Trabajo</asp:HyperLink>

                <asp:Panel ID="Panel4" runat="server" Visible="False">
                    <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Asignar Abogado"></asp:Label>
                    <br />
                    <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                    <table>
                        <tbody>
                            <tr>
                                <td colspan="5">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ASIGNAR"
                                        SkinID="ValidationSummary1" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 165px">
                                    Identificación Funcionario<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server" ControlToValidate="TxtIde" ErrorMessage="Debe escoger un funcionario"
                                        ValidationGroup="ASIGNAR">*</asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="TxtIde" runat="server" AutoPostBack="True"></asp:TextBox>
                                </td>
                                <td style="width: 24px">
                                    <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="..." />
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="TxtNomTer" runat="server" Height="18px" ReadOnly="true" Width="260px"
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td style="width: 99px; text-align: center;">
                                    &nbsp;
                                    <asp:ImageButton ID="IBtnAsignar" runat="server" SkinID="IBtnAsig" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 165px">
                                    &nbsp;</td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                                <td style="width: 24px">
                                    &nbsp;</td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                                <td style="width: 167px; text-align: center;">
                                    &nbsp;</td>
                                <td style="width: 99px; text-align: center;">
                                    Asignar</td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    &nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="demoheading">
                        Historico de Asignaciones</div>
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjHUsuEnc" EnableModelValidation="True"
                        AutoGenerateColumns="False" Width="912px">
                        <Columns>
                            <asp:TemplateField HeaderText="Fecha de Asignación" SortExpression="Fec_Reg">
                                <ItemTemplate>
                                    <asp:Label ID="LbFec" runat="server" Text='<%# Bind("Fec_Reg") %>' __designer:wfdid="w9"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asignado Por...">
                                <ItemTemplate>
                                    <asp:Label ID="LbUsap" runat="server" Text='<%# Bind("AsignadoPor") %>' __designer:wfdid="w9"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Encargado Nuevo">
                                <ItemTemplate>
                                    <asp:Label ID="LbEncSig" runat="server" Text='<%# Bind("Enc_Siguiente") %>' __designer:wfdid="w9"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Encargado Anterior">
                                <ItemTemplate>
                                    <asp:Label ID="LbEncAnt" runat="server" Text='<%# Bind("Enc_Anterior") %>' __designer:wfdid="w9"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recibido">
                                <ItemTemplate>
                                    <asp:Label ID="LbRec" runat="server" Text='<%# Bind("Recibido") %>' __designer:wfdid="w9"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Observacion">
                                <ItemTemplate>
                                    <asp:Label ID="Lbobs" runat="server" Text='<%# Bind("Obs") %>' __designer:wfdid="w9"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            LA Solicitud no tiene ninguna Asignación Registrada.
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <br />
                </asp:Panel>
                <br />
                <asp:ObjectDataSource ID="ObjHUsuEnc" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetvHUsuEncargados" TypeName="PSolicitudes">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DetPSolicitudesAll1" Name="Cod_Sol" PropertyName="CodigoPContrato"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <br />
                <asp:Panel ID="PanelTerceros" runat="server" BackColor="White" Width="650px">
                    <asp:Panel ID="Panel3" runat="server" BorderColor="White" CssClass="BarTitleModal2"
                        Height="27px" Width="649px">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 136px">
                                    <asp:Label ID="Label12" runat="server" ForeColor="White" Text="Buscar Terceros" Font-Bold="True"></asp:Label>
                                </td>
                                <td style="width: 923px">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Btn_Cerrar" runat="server" Text="X" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
                        <uc1:consultaterxDep ID="consultaterxDep1" runat="server" />
                    </asp:Panel>
                </asp:Panel>
                <asp:Button Style="display: none" ID="Btn_Target" runat="server"></asp:Button>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" TargetControlID="Btn_Target"
                    BackgroundCssClass="modalBackground" PopupControlID="PanelTerceros" DropShadow="True"
                    CancelControlID="Btn_Cerrar" PopupDragHandleControlID="Panel3">
                </ajaxToolkit:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdPrgAsig" runat="server" AssociatedUpdatePanelID="UpdAsig">
            <ProgressTemplate>
                <ucProg:Progress ID="Progress1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>
