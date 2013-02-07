<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ReporteRevision.aspx.vb" Inherits="Solicitudes_Revision_Default" %>

<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTerxDep.ascx" TagName="consultaterxDep"
    TagPrefix="uc1" %>
<%@ Register Src="../../CtrlUsr/DepSolicitudes/DetPSolicitudes.ascx" TagName="DetPSolicitudes"
    TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer"
    TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/Progreso/Progress.ascx" TagName="Progress" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdRevision" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="demoheading">
                    REVISIÓN DE SOLICITUDES...
                </div>
                <uc2:DetPSolicitudes ID="DetPSolicitudes1" runat="server" OnAceptarClicked="DetPSolicitudes1_OnAceptarClicked" />

                <br />

                <asp:Panel ID="Panel4" runat="server" Visible="False">
                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                        SelectedIndex="0">
                        <Tabs>
                            <telerik:RadTab runat="server" Selected="True" Text="Revisión">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Historial de Revisiones">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                        <telerik:RadPageView ID="RadPageView1" runat="server">
                        <br />
                            <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="CONCEPTO DE REVISIÓN"></asp:Label>
                            <br />
                            <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                            <br />
                            <table>
                                <tbody>
                                    <tr>
                                        <td colspan="6">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" SkinID="ValidationSummary1"
                                                ValidationGroup="V" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 95px">
                                            Fecha de Revisión
                                        </td>
                                        <td colspan="2" style="width: 2px">
                                            <asp:TextBox ID="TxtFechaRevision" runat="server" Style="text-transform: uppercase"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="width: 24px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 100px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 99px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 95px">
                                            Observación
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="TxtObs" runat="server" Height="88px" TextMode="MultiLine"
                                                Width="560px"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 95px">
                                            Concepto
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="CboConcepto" runat="server" Width="108px">
                                                <asp:ListItem Value="P">PENDIENTE</asp:ListItem>
                                                <asp:ListItem Value="A">ACEPTADO</asp:ListItem>
                                                <asp:ListItem Value="R">RECHAZADO</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td colspan="2">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CboConcepto"
                                                ErrorMessage="Debe Seleccionar Un Concepto " InitialValue="" ValidationGroup="V">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 95px">
                                            &nbsp;
                                        </td>
                                        <td style="text-align: center">
                                            <asp:ImageButton ID="IBtnGuardar" runat="server" SkinID="IBtnGuardar" />
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 95px">
                                            &nbsp;
                                        </td>
                                        <td style="text-align: center">
                                            Guardar
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="7">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="7" style="text-align: center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                     <tr>
                                        <td colspan="7">
                                            <asp:ObjectDataSource ID="ObjectHRev" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="GetHrev" TypeName="PSolicitudes">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="DetPSolicitudes1" Name="Cod_Sol" PropertyName="CodigoPContrato"
                                                        Type="String" />
                                                    <asp:Parameter Name="connect" Type="Boolean" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
                        <div style="min-height:400px" >
                       <br />
                        <asp:Label ID="SubT0" runat="server" CssClass="SubTitulo" Text="HISTORIAL DE REVISIONES"></asp:Label>
                              <asp:Label ID="MsgResult2" runat="server" SkinID="MsgResult"></asp:Label>
                            <br />
                      
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Cod_Sol,Id_HRev"
                                DataSourceID="ObjectHRev" Width="912px">
                                <Columns>
                                    <asp:BoundField DataField="Id_HRev" HeaderText="Id" SortExpression="Id_HRev" />
                                    <asp:TemplateField HeaderText="Código de la Solicitud" SortExpression="Cod_Sol">
                                        <ItemTemplate>
                                            <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" Text='<%# Bind("Cod_Sol") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha de Registro" SortExpression="Fecha_Recibido">
                                        <ItemTemplate>
                                            <asp:Label ID="LbFec" runat="server" __designer:wfdid="w9" Text='<%# Bind("Fecha_Recibido","{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Recibido Abogado" SortExpression="Fec_Rec_Abog">
                                        <ItemTemplate>
                                            <asp:Label ID="LbFec_Rec_Abog" runat="server" __designer:wfdid="w9" Text='<%# Bind("Fec_Rec_Abog","{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observacion Recibido" SortExpression="Obs_Recibido">
                                        <ItemTemplate>
                                            <asp:Label ID="LbEncSig" runat="server" __designer:wfdid="w9" Text='<%# Bind("Obs_Recibido_Abog") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha de Revision">
                                        <ItemTemplate>
                                            <asp:Label ID="LbEncAnt" runat="server" __designer:wfdid="w9" Text='<%# Bind("Fecha_Revisado","{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observacion Revision">
                                        <ItemTemplate>
                                            <asp:Label ID="LbRec" runat="server" __designer:wfdid="w9" Text='<%# Bind("Obs_Revisado") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Concepto de la Revision">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbobs" runat="server" __designer:wfdid="w9" Text='<%# Bind("Nom_Est") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Historico de Observaciones">
                                        <ItemTemplate>
                                            <asp:Label ID="LbhReV" runat="server" __designer:wfdid="w9" Text='<%# Bind("HObs_Revisado") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Abogado que Recibe" SortExpression="Nit_Abog_Recibe">
                                        <ItemTemplate>
                                            <asp:Label ID="LbAbog" runat="server" Text='<%# Bind("Encargado") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="N° Proceso" SortExpression="Pro_Sel_Nro">
                                        <ItemTemplate>
                                            <asp:Label ID="LbNumPro" runat="server" Text='<%# Bind("Pro_Sel_Nro") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Image" CommandName="mail" HeaderText="Reenviar Notificación"
                                        ImageUrl="~/images/mnProcesos/email-send-icon.png" Text="Reenviar Notificación">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                    <asp:HyperLinkField DataNavigateUrlFields="Cod_Sol,Id_Hrev" DataNavigateUrlFormatString="RptRv.aspx?Cod_Sol={0}&amp;Id_Hrev={1}&amp;dest=word"
                                        HeaderText="Imprimir Notificación" Target="_blank" Text="Exportar a Word" />
                                    <asp:HyperLinkField DataNavigateUrlFields="Cod_Sol,Id_Hrev" DataNavigateUrlFormatString="RptRv.aspx?Cod_Sol={0}&amp;Id_Hrev={1}&amp;dest=html"
                                        HeaderText="Imprimir Notificación" Target="_blank" Text="Imprimir" />
                                </Columns>
                                <EmptyDataTemplate>
                                    No hay conceptos de revisión en el sistema
                                </EmptyDataTemplate>
                            </asp:GridView>

                             </div>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                    <br />
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DetPSolicitudes1" EventName="AceptarClicked" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdPrg" runat="server" AssociatedUpdatePanelID="UpdRevision">
            <ProgressTemplate>
                <uc1:Progress ID="Progress1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>
