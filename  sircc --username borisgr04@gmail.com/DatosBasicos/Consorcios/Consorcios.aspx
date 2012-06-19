<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Consorcios.aspx.vb" Inherits="DatosBasicos_CSUT_Default" %>

<%@ Register src="../../CtrlUsr/Consorcios/ConsultaCONUT.ascx" tagname="ConsultaCONUT" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/Terceros/ConsultaTer.ascx" tagname="ConsultaTer" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<script type='text/javascript'>
function enviarCSUT(ced,rsocial,tip_ter)
         {
         document.aspnetForm.<%=Me.TxtNitCSUT.ClientID%>.value=ced;
         document.aspnetForm.<%=Me.txtNomCSUT.ClientID%>.value=rsocial;
         __doPostBack("<%= button1.ClientID %>","");
         }

         function enviar(ced,rsocial,tip_ter)
         {
         document.aspnetForm.<%=Me.TxtIde.ClientID%>.value=ced;
         document.aspnetForm.<%=Me.TxtNomTer.ClientID%>.value=rsocial;
         __doPostBack("<%= button1.ClientID %>","");
         }
         
               
</script>
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        
        <asp:Label id="Tit" runat="server" Width="392px" CssClass="Titulo" 
            Text="Consorcios y/o Uniones Temporales"></asp:Label><BR />
            <asp:Label id="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;
            <BR 
                 />&nbsp;<table style="width: 100%">
        <tr>
            <td style="width: 44px">
                <asp:Label ID="Label2" runat="server" Text="Nit"></asp:Label>
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="TxtNitCSUT" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
            <td style="width: 24px">
                <asp:Button ID="Button1" runat="server" Text="..." />
            </td>
            <td colspan="5">
                <asp:TextBox ID="TxtNomCSUT" runat="server" ReadOnly="True" Width="307px" 
                    Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 44px">
                &nbsp;</td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 24px">
                &nbsp;</td>
            <td colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" 
                EnableModelValidation="True" 
                Height="130px" Width="574px" 
                DataSourceID="ObjMiembros" 
                OnRowCommand="GridView1_RowCommand"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                AllowSorting="True" CellPadding="4" DataKeyNames="Id_Miembro" 
                    EmptyDataText="No se encontraron registros en la Base de Datos" 
                    ShowFooter="True">
                    <Columns>
                        <asp:BoundField DataField="Id_Miembro" HeaderText="Identificación" />
                        <asp:BoundField DataField="Nom_Miembro" HeaderText="Nombre" />
                        <asp:BoundField DataField="Porc_Part" HeaderText="% Participación" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/images/Operaciones/delete2.png" 
                            Text="Eliminar" CommandName="Eliminar" />
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/images/Operaciones/Edit2.png" 
                            Text="Editar" CommandName="Editar" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjMiembros" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyTer" 
                    TypeName="Consorcios" InsertMethod="Insert" UpdateMethod="Update">
                    <InsertParameters>
                        <asp:Parameter Name="Ide_Ter" Type="String" />
                        <asp:Parameter Name="Id_Miembro" Type="String" />
                        <asp:Parameter Name="Id_Estado" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtNitCSUT" Name="IDE_TER" PropertyName="Text" 
                            Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Ide_Ter_O" Type="String" />
                        <asp:Parameter Name="Ide_Ter" Type="String" />
                        <asp:Parameter Name="Id_Miembro" Type="String" />
                        <asp:Parameter Name="Id_Estado" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 44px">
                <asp:Label ID="Label18" runat="server" CssClass="SubTitulo" Text="Agregar"></asp:Label>
            </td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 24px">
                &nbsp;</td>
            <td colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 44px">
                                        <asp:Label ID="Label10" runat="server" Text="Identificación"></asp:Label>
                                    </td>
            <td style="width: 100px">
                                        <asp:TextBox ID="txtIde" runat="server" AutoPostBack="True"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtNewIde_Int_FilteredTextBoxExtender" 
                                                runat="server" 
                                                Enabled="True" 
                                                TargetControlID="txtIde" 
                                                FilterType="Numbers">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
            <td style="width: 24px">
                            <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="..." />
                                    </td>
            <td style="width: 314px">
                                        <asp:TextBox ID="txtNomTer" runat="server" 
                    Enabled="False" Width="307px"></asp:TextBox>
                                    </td>
            <td style="width: 44px">
                                        &nbsp;</td>
            <td style="width: 40px">
                                        &nbsp;</td>
            <td style="width: 63px">
                                        &nbsp;</td>
            <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtIde" 
                                            ErrorMessage="Debe seleccionar la identificacion del miembro..." 
                                            ValidationGroup="AgregarGroup"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                            ControlToCompare="txtIde" ControlToValidate="TxtNitCSUT" 
                                            ErrorMessage="No puede agregar el Consorcio o Union Temporal como un miembro de él mismo..." 
                                            Operator="NotEqual" ValidationGroup="AgregarGroup"></asp:CompareValidator>
                                    </td>
        </tr>
        <tr>
            <td colspan="2">
                                        <asp:Label ID="Label13" runat="server" Text="Estado"></asp:Label>
                                    </td>
            <td style="width: 24px">
                            &nbsp;</td>
            <td style="width: 314px">
                                        <asp:Label ID="Label19" runat="server" Text="Porcentaje de Participación"></asp:Label>
                                    </td>
            <td style="width: 44px">
                                        &nbsp;</td>
            <td style="width: 40px">
                                        &nbsp;</td>
            <td style="width: 63px">
                                        &nbsp;</td>
            <td>
                                        &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                                        <asp:DropDownList ID="CmbEst" runat="server" Width="92px">
                                            <asp:ListItem Value="AC">ACTIVO</asp:ListItem>
                                            <asp:ListItem Value="IN">INACTIVO</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
            <td style="width: 24px">
                            &nbsp;</td>
            <td style="width: 314px">
                                        <asp:TextBox ID="TxtPP" runat="server"></asp:TextBox>
                                    </td>
            <td style="width: 44px">
                                        &nbsp;</td>
            <td style="width: 40px">
                                        &nbsp;</td>
            <td style="width: 63px">
                                        &nbsp;</td>
            <td>
                                        &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5" style="text-align: center">
                                        <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" 
                                            ValidationGroup="AgregarGroup" />
                                    </td>
            <td style="width: 40px">
                                        &nbsp;</td>
            <td style="width: 63px">
                                        &nbsp;</td>
            <td>
                                        &nbsp;</td>
        </tr>
    </table>
        <br />
        <asp:Panel ID="PanelPopup" runat="server" BackColor="White" Width="650px">
            <asp:Panel ID="Panel2" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
                Height="27px" Width="649px">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 438px">
                            <asp:Label ID="Label11" runat="server" ForeColor="White" 
                                Text="Buscar Consorcio y/o Union Temporal" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrarT" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <uc1:ConsultaCONUT ID="ConsultaCONUT1" runat="server" />
            
            
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" 
        runat="server" 
        TargetControlID="Button1"
        BackgroundCssClass="modalBackground"
        PopupControlID="PanelPopup"
        CancelControlID="BtnCerrarT" 
        DropShadow="True" 
        PopupDragHandleControlID="Panel2">
        </ajaxToolkit:ModalPopupExtender>
        <br />
        <asp:Panel ID="PanelTerceros" runat="server" BackColor="White" Width="650px">
            <asp:Panel ID="Panel3" runat="server" BorderColor="White" CssClass="BarTitleModal2"
                Height="27px" Width="649px">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 136px">
                            <asp:Label ID="Label12" runat="server" ForeColor="White" Text="Buscar Terceros" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="Btn_Cerrar" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <uc2:ConsultaTer ID="ConsultaTer1" runat="server" />
                    
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" 
        runat="server"
        TargetControlID="BtnBuscar"
        BackgroundCssClass="modalBackground"
        PopupControlID="PanelTerceros" 
        DropShadow="True"
        CancelControlID="Btn_Cerrar"
        PopupDragHandleControlID="Panel3">
        </ajaxToolkit:ModalPopupExtender>  
        <br />
        <asp:Panel ID="PanelOperaciones" runat="server" BackColor="White" Width="357px">
            <asp:Panel ID="Panel4" runat="server" BorderColor="White" CssClass="BarTitleModal2"  
                Height="27px" Width="354px">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 1159px">
                            <asp:Label ID="Label14" runat="server" ForeColor="White" Text=" Consorcio y/o Union Temporal" 
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
            <table style="width:356px;">
                <tr>
                    <td style="width: 99px">
                        &nbsp;</td>
                    <td style="width: 240px">
                        &nbsp;</td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
                        <asp:Label ID="Label15" runat="server" Text="Identificación"></asp:Label>
                    </td>
                    <td style="width: 240px">
                        <asp:TextBox ID="Txt_Id" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
                        <asp:Label ID="Label16" runat="server" Text="Nombre del Miembro"></asp:Label>
                    </td>
                    <td style="width: 240px">
                        <asp:TextBox ID="Txt_nom" runat="server" Width="234px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
                        <asp:Label ID="Label17" runat="server" Text="Estado"></asp:Label>
                    </td>
                    <td style="width: 240px">
                        <asp:DropDownList ID="CmbEstado" runat="server" Width="92px">
                            <asp:ListItem Value="AC">ACTIVO</asp:ListItem>
                            <asp:ListItem Value="IN">INACTIVO</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
                        <asp:Label ID="Label20" runat="server" Text="% de Participación"></asp:Label>
                    </td>
                    <td style="width: 240px">
                        <asp:TextBox ID="TxtPp_m" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:Button ID="Btn_Guardar" runat="server" Text="Guardar" OnClick="Btn_Guardar_Click" />
                        <asp:Button ID="Btn_Eliminar" runat="server" Text="Eliminar" OnClick="Btn_Eliminar_Click" />
                        <asp:Button ID="Btn_Cancelar" runat="server" Text="Cancelar" />
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
         
</div>
</asp:Content>

