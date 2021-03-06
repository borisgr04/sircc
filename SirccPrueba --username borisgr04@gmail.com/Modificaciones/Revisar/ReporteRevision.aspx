﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ReporteRevision.aspx.vb" Inherits="SolicitudesAdi_Revision_Default" %>

<%@ Register src="../../CtrlUsr/Terceros/ConsultaTerxDep.ascx" tagname="consultaterxDep" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/DepSolicitudes/DetPSolicitudes.ascx" tagname="DetPSolicitudes" tagprefix="uc2" %>
<%@ Register src="../../CtrlUsr/Terceros/ConsultaTer.ascx" tagname="ConsultaTer" tagprefix="uc2" %>
<%@ Register src="../../CtrlUsr/Progreso/Progress.ascx" tagname="Progress" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/DetcontratosAdi/DetContratoAdi.ascx" tagname="DetContratoAdi" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">


    <div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdRevision" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div class="demoheading">
            REVISIÓN DE SOLICITUDES...
        </div>
        <uc3:DetContratoAdi ID="DetContratoAdi1" runat="server" />
                <asp:Panel ID="Panel4" runat="server" Visible="False">
                <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" 
                                        Text="EMITIR CONCEPTO DE REVISIÓN"></asp:Label>
                                        <br />
                                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
          
                    <TABLE>
                        <tbody>
                               <tr>
                                <td colspan="6">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        SkinID="ValidationSummary1" ValidationGroup="V" />
                                   </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 95px">
                                    Fecha de Revisión</td>
                                <td colspan="2" style="WIDTH: 2px">
                                    <asp:TextBox ID="TxtFechaRevision" runat="server" AutoCompleteType="Disabled" 
                                        style="text-transform :uppercase" Enabled="False"></asp:TextBox>
                                </td>
                                <td style="WIDTH: 24px">
                                    &nbsp;</td>
                                <td style="WIDTH: 100px">
                                    &nbsp;</td>
                                <td style="WIDTH: 99px">
                                    &nbsp;</td>
                                <td style="WIDTH: 99px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 95px">
                                    Observación</td>
                                <td colspan="2">
                                    <asp:TextBox ID="TxtObs" runat="server" AutoPostBack="True" Height="88px" 
                                        TextMode="MultiLine" 
                                        Width="560px"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 95px">
                                    Concepto</td>
                                <td>
                                    <asp:DropDownList ID="CboConcepto" runat="server" Width="108px">
                                        <asp:ListItem Value="P">PENDIENTE</asp:ListItem>
                                        <asp:ListItem Value="A">ACEPTADO</asp:ListItem>
                                        <asp:ListItem Value="R">RECHAZADO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="CboConcepto" ErrorMessage="Debe Seleccionar Un Concepto " 
                                        InitialValue="P" ValidationGroup="V">*</asp:RequiredFieldValidator>
                                </td>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 95px">
                                    &nbsp;</td>
                                <td style="text-align: center">
                                    <asp:ImageButton ID="IBtnGuardar" runat="server" Height="33px" 
                                        ImageUrl="~/images/Operaciones/save.png" SkinID="IBtnGuardar" 
                                        style="text-align: center" ValidationGroup="V" Width="34px" />
                                </td>
                                <td colspan="2">
                                    &nbsp;</td>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 95px">
                                    &nbsp;</td>
                                <td style="text-align: center">
                                    Guardar</td>
                                <td colspan="2">
                                    &nbsp;</td>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="7" style="text-align: center">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <asp:Label ID="SubT0" runat="server" CssClass="SubTitulo" 
                                        Text="HISTORIAL DE REVISIONES"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        DataSourceID="ObjectHRev" Width="912px" 
                                        DataKeyNames="Num_Sol_Adi,Id_HRev" EnableModelValidation="True">
                                        <Columns>
                                            <asp:BoundField DataField="Id_HRev" HeaderText="Id" SortExpression="Id_HRev" />
                                            <asp:TemplateField HeaderText="Código de la Solicitud" 
                                                SortExpression="Num_Sol_Adi">
                                <ItemTemplate>
                                    <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                        Text='<%# Bind("Num_Sol_Adi") %>'></asp:Label> 
                                            </ItemTemplate>
                                            
                                            
                                </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha de Registro" 
                                                SortExpression="Fec_Recibido">
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
                                            <asp:ButtonField HeaderText="Reenviar Notificación" 
                                                Text="Reenviar Notificación" ButtonType="Image" CommandName="mail" 
                                                ImageUrl="~/images/mnProcesos/email-send-icon.png" >
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:ButtonField>
                                            <asp:HyperLinkField DataNavigateUrlFields="Num_Sol_Adi,Id_Hrev" 
                                                DataNavigateUrlFormatString="RptRv.aspx?Num_Sol_Adi={0}&Id_Hrev={1}&dest=word" 
                                                HeaderText="Imprimir Notificación" Target="_blank" Text="Exportar a Word" />
                                            <asp:HyperLinkField DataNavigateUrlFields="Num_Sol_Adi,Id_Hrev" 
                                                DataNavigateUrlFormatString="RptRv.aspx?Num_Sol_Adi={0}&Id_Hrev={1}&dest=html" 
                                                HeaderText="Imprimir Notificación" Target="_blank" Text="Imprimir" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No hay conceptos de revisión en el sistema
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="ObjectHRev" runat="server"  
                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetHrev" 
                                        TypeName="Sol_Adiciones" InsertMethod="InsertHREV">
                                        <InsertParameters>
                                            <asp:Parameter Name="NUM_SOL_ADI" Type="String" />
                                            <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
                                        </InsertParameters>
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DetContratoAdi1" Name="Num_Sol_Adi" 
                                                PropertyName="IdSolAdi" Type="String" />
                                            <asp:Parameter Name="connect" Type="Boolean" />
                                        </SelectParameters>
                                  
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </tbody>
                    </TABLE>
    </asp:Panel>
        
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DetContratoAdi1" EventName="AceptarClicked" />
        </Triggers>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="UpdPrg" runat="server" AssociatedUpdatePanelID="UpdRevision">
                <progresstemplate>
                    <uc1:Progress ID="Progress1" runat="server" />
                </progresstemplate>
</asp:UpdateProgress> 
        </div>
</asp:Content>

