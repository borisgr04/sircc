<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Modificar.aspx.vb"
 Inherits="Modificaciones_Modificar_Solicitud" %>

<%@ Register src="../../CtrlUsr/DetContratos/DetContrato.ascx" tagname="DetContrato" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Solicitud de Modificación a Contratos"></asp:Label>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:DetContrato ID="DetContrato1" runat="server" />
            <br />
            <br />
            <table style="width: 100%">
                <tr>
                    <td style="width: 41px">
                        <asp:ImageButton ID="IBtnNuevo" runat="server" Height="32px" 
                            ImageUrl="~/images/Operaciones/New1.png" Width="32px" Visible="False" />
                    </td>
                    <td style="width: 115px">
                        <asp:DropDownList ID="CboNumSol" runat="server" DataSourceID="ObjSolAdi" 
                            DataTextField="Nom_Tip" DataValueField="Num_Sol_Adi" Height="16px" 
                            Width="170px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 47px">
                        <asp:ImageButton ID="IBtnAbrir" runat="server" Height="32px" 
                            ImageUrl="~/images/mnProcesos/open-icon32.png" Width="32px" />
                    </td>
                    <td class="style4" style="width: 33px">
                        <asp:ImageButton ID="IBtnEditar" runat="server" Height="32px" 
                            ImageUrl="~/images/Operaciones/Edit2.png" Width="32px" />
                    </td>
                    <td style="width: 43px">
                        <asp:ImageButton ID="IBtnGuardar" runat="server" Height="32px" 
                            SkinID="IBtnGuardar" ValidationGroup="Guardar" Width="32px" />
                        <ajaxToolkit:ConfirmButtonExtender ID="IBtnGuardar_ConfirmButtonExtender" 
                            runat="server" ConfirmText="Confirme si desea Guardar los Cambios?" 
                            Enabled="True" TargetControlID="IBtnGuardar">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </td>
                    <td class="style1" style="width: 44px">
                        <asp:ImageButton ID="IBtnCancelar" runat="server" Height="32px" 
                            ImageUrl="~/images/mnProcesos/undo.png" Width="32px" />
                    </td>
                    <td style="width: 87px; text-align: center">
                        <asp:ImageButton ID="BtnReabrir" runat="server" Enabled="False" Height="32px" 
                            ImageUrl="~/images/Operaciones/actualizar.png" Width="32px" 
                            Visible="False" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 41px">
                        &nbsp;</td>
                    <td style="width: 115px">
                        &nbsp;</td>
                    <td style="width: 47px">
                        Abrir</td>
                    <td class="style4" style="width: 33px">
                        Editar</td>
                    <td style="width: 43px">
                        Guardar</td>
                    <td class="style1" style="width: 44px">
                        Cancelar</td>
                    <td style="width: 87px; text-align: center">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
            <br />
            <table style="width:100%;">
                <tr>
                    <td style="width: 124px">
                        &nbsp;</td>
                    <td style="width: 350px">
                        &nbsp;</td>
                    <td style="width: 139px">
                        <asp:Label ID="Label21" runat="server" CssClass="selectIndex" Text="Estado"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        &nbsp;</td>
                    <td style="width: 350px">
                        &nbsp;</td>
                    <td style="width: 139px">
                        <asp:Label ID="LblEstado" runat="server" CssClass="SubTitulo"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        <asp:Label ID="Label2" runat="server" Text="Tipo de Modificación"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="CboTipMod" runat="server" AutoPostBack="True" 
                            DataSourceID="ObjTipAdic" DataTextField="NOM_TIP" DataValueField="COD_TIP">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        <asp:Label ID="Label3" runat="server" Text="Fecha de Recibido"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TxtFechaRecibido" 
                            ErrorMessage="Debe seleccionar o escribir una fecha valida" 
                            ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtFechaRecibido" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalFechaRecibido" runat="server" 
                            Format="dd/MM/yyyy" TargetControlID="TxtFechaRecibido">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 124px">
                        <asp:Label ID="Label4" runat="server" Text="Observación"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtObservacion" runat="server" Height="66px" 
                            TextMode="MultiLine" Width="509px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label22" runat="server" CssClass="selectIndex" 
                            Text="Encargado: "></asp:Label>
                        <asp:Label ID="LblEncargado" runat="server" CssClass="SubTitulo"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:Panel ID="PanelOperaciones" runat="server" BackColor="White" Width="379px">
                <asp:Panel ID="Panel4" runat="server" BackColor="Blue" BorderColor="White" 
                    CssClass="BarTitleModal2" Height="27px" Width="376px">
                    <table style="width:100%;">
                        <tr>
                            <td style="width: 900px">
                                <asp:Label ID="Label18" runat="server" Font-Bold="True" ForeColor="White" 
                                    Text="Reabrir Solicitud"></asp:Label>
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
                        <td style="width: 233px">
                            &nbsp;</td>
                        <td style="width: 3px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 123px">
                            <asp:Label ID="Label17" runat="server" Text="Fecha"></asp:Label>
                        </td>
                        <td style="width: 233px">
                            <asp:UpdatePanel ID="UpdFecReAbrir" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="Txt_FecRec" runat="server" Width="114px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="Txt_FecRec_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="Txt_FecRec">
                                    </ajaxToolkit:CalendarExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 3px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 123px">
                            <asp:Label ID="Label20" runat="server" Text="Observacion"></asp:Label>
                        </td>
                        <td style="width: 233px">
                            <asp:TextBox ID="Txt_ObsRec" runat="server" Height="85px" TextMode="MultiLine" 
                                Width="228px"></asp:TextBox>
                        </td>
                        <td style="width: 3px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <asp:Button ID="Btn_Guardar" runat="server" 
                                Text="Guardar" />
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
            <asp:ObjectDataSource ID="ObjTipAdic" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Tipo_Adciones"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjSolAdi" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Sol_Adiciones">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DetContrato1" Name="Cod_Con" 
                        PropertyName="Cod_Con" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>    
</asp:Content>

