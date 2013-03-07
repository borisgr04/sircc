<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdIntC.ascx.vb" Inherits="CtrlUsr_grdIntC_grdIntC" %>
<%@ Register src="../Terceros/ConsultaTer.ascx" tagname="consultater" tagprefix="uc1" %>

<%@ Register src="../AdmTercero/AdmTercero.ascx" tagname="AdmTercero" tagprefix="uc2" %>

   <asp:UpdatePanel ID="UpdatePanel4" 
        runat="server" UpdateMode="Conditional">
        <contenttemplate>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
 CellPadding="4" DataKeyNames="Ide_Int" 
    ForeColor="#333333" GridLines="None" 
                                ShowFooter="True" EnableModelValidation="True" 
    Width="100%">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                     <asp:TemplateField HeaderText="Identificación">
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Ide_Int") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelNT" runat="server" Text='<%# Bind("Nom_Ter") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tipo">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("NTip_Int") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="CboEditTip_Int" runat="server" Text='<%# Bind("Tip_Int") %>'   >
                                                            <asp:ListItem Value="S" Text="Interno - (Supervisor)"></asp:ListItem>
                                                            <asp:ListItem Value="I" Text="Externo"></asp:ListItem>
                                                    </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observación">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Obs_Int") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:TextBox ID="txtEditObs_Int" runat="server" Width="100%" TextMode="MultiLine" Text='<%# Bind("Obs_Int") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle Width="300px"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Est_Int") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="CboEditEst_int" runat="server" AppendDataBoundItems="True" >
                                                            <asp:ListItem Value="AC" Text="Activo"></asp:ListItem>
                                                            <asp:ListItem Value="IN" Text="Inactivo"></asp:ListItem>
                                                    </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                   
                                     <asp:CommandField CancelText="Cancelar" EditText="Editar" ShowEditButton="True"  CausesValidation="False" 
                                         UpdateText="Actualizar" />
                                   
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" 
                                                CommandName="AddNew" Text="Agregar..." ForeColor="White"></asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White"  />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                      
                            <table >
                                <tr>
                                    <td class="style2" colspan="5">
                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" ><asp:Label ID="Label1" runat="server" CssClass="SubTitulo" 
                                    Text="Registre Interventor"></asp:Label>
                                        </td>
                                </tr>
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td >
                                        &nbsp;</td>
                                    <td >
                                        &nbsp;</td>
                                    <td >
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="Label10" runat="server" Text="Identificación"></asp:Label>
                                    </td>
                                    <td class="style2">
                                        <asp:TextBox ID="txtIde" runat="server" AutoPostBack="True"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtNewIde_Int_FilteredTextBoxExtender" 
                                                runat="server" 
                                                Enabled="True" 
                                                TargetControlID="txtIde" 
                                                FilterType="Numbers">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    <td >
                            <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="..." />
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtNom" runat="server" Enabled="False" Width="279px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtIde" 
                                            ErrorMessage="Debe especificar un Interventor/Supervisor"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:Label ID="Label11" runat="server" Text="Tipo"></asp:Label>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="CboNewTip_Int" runat="server"  >
                                            <asp:ListItem Value="S" Text="Interno(Supervisor)"></asp:ListItem>
                                            <asp:ListItem Value="I" Text="Externo"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td >
                                        &nbsp;</td>
                                    <td >
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:Label ID="Label12" runat="server" Text="Observación"></asp:Label>
                                    </td>
                                    <td colspan=3 >
                                        <asp:TextBox ID="txtNewObs_Int" runat="server" Width="100%" 
                                            TextMode="MultiLine" >.</asp:TextBox>
                                    </td>
                                 
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center" >
                                        <asp:Button ID="BtnAgregar" runat="server" style="text-align: center" 
                                            Text="Agregar" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            
   
<!-- Mensaje de Salida-->
            <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" 
                style="DISPLAY: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" 
              CancelControlID="BtnCerrarT"
                BackgroundCssClass="modalBackground" 
                BehaviorID="programmaticModalPopupBehavior" DropShadow="True" 
                PopupControlID="programmaticPopup" 
                PopupDragHandleControlID="programmaticPopupDragHandle" 
                RepositionMode="RepositionOnWindowScroll" 
                TargetControlID="hiddenTargetControlForModalPopup">
            </ajaxToolkit:ModalPopupExtender>
            &nbsp;
            <asp:Panel ID="programmaticPopup" runat="server" CssClass="ModalPanel2" 
                 Width="625px">
                <asp:Panel ID="programmaticPopupDragHandle" runat="Server" 
                    CssClass="BarTitleModal2" Height="30px">
                    <div style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
                        <div style="FLOAT: left">
                            Consulta Terceros</div>
                        <div style="FLOAT: right">
                            <asp:Button ID="BtnCerrarT" runat="server" Text="X" />
&nbsp;</div>
                        </div>
                </asp:Panel>
                 <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
                 <%--<uc1:ConsultaTer ID="ConsultaTer" runat="server" Ret="AR" Tipo="AR" />--%>

                     <uc2:AdmTercero ID="AdmTercero1" runat="server" />

           </asp:Panel>
                
                <br />
                <asp:Button ID="Button1" runat="server" Text="Button" style="visibility:hidden" />
                <br />
                <br />
            </asp:Panel>
        </contenttemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    
    






