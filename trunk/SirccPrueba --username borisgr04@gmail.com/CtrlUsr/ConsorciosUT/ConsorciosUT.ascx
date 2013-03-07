<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConsorciosUT.ascx.vb" Inherits="CtrlUsr_ConsorciosUT_ConsorciosUT" %>
<%@ Register src="~/CtrlUsr/AdmTercero/UpdAdmTerceros.ascx" tagname="UpdAdmTerceros" tagprefix="uc1" %>
<%@ Register src="~/CtrlUsr/Consorcios/UpdConConsorcios.ascx" tagname="UpdConConsorcios" tagprefix="uc2" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
        <br />
        
        <asp:Label id="Tit" runat="server" Width="392px" CssClass="Titulo" 
            Text="Consorcios y/o Uniones Temporales"></asp:Label><br />
            <asp:Label id="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;
            <br/>&nbsp;&nbsp;&nbsp;
        <asp:Panel ID="PnlConUT" runat="server">
    
        <table style="width: 100%">
        <tr>
            <td style="width: 44px">
                <asp:Label ID="Label21" runat="server" Text="Contrato"></asp:Label>
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="Nit"  ></asp:Label>
            </td>
            <td style="width: 24px">
                &nbsp;</td>
            <td>
                Nombre o Razón Social</td>
        </tr>
        <tr>
            <td style="width: 44px">
                <asp:Label ID="TxtCodCon" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td style="width: 100px">
                <asp:Label ID="TxtNitCSUT" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td style="width: 24px">
                &nbsp;</td>
            <td>
                <asp:Label ID="TxtNomCSUT" runat="server" Font-Bold="true" Width="307px"></asp:Label>
            </td>
        </tr>
            <tr>
                <td style="width: 44px">
                    <asp:ImageButton ID="IBtnNuevoMiembro" runat="server" SkinID="IBtnNuevo" />
                </td>
                <td style="width: 100px">
                    &nbsp;</td>
                <td style="width: 24px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        <tr>
            <td style="width: 44px">
                Nuevo Miembro</td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 24px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        
        <tr>
            <td colspan="4">

                <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" 
                EnableModelValidation="True" 
                Height="130px" Width="574px" 
                OnRowCommand="GridView1_RowCommand"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                AllowSorting="True" CellPadding="4" DataKeyNames="Id_Miembros" 
                    EmptyDataText="No se encontraron miembros Asociados al Consorcios y/o Unión Temporal" 
                    ShowFooter="True" DataSourceID="ObjMiembros">
                    <Columns>
                        <asp:BoundField DataField="Id_Miembros" HeaderText="Identificación" />
                        <asp:BoundField DataField="Nom_Miembro" HeaderText="Nombre" />
                        <asp:BoundField DataField="Porc_Part" HeaderText="% Participación" />
                        <asp:BoundField DataField="Id_Estado" HeaderText="Estado" />
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/images/Operaciones/delete2.png" 
                            Text="Eliminar" CommandName="Eliminar" />
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/images/Operaciones/Edit2.png" 
                            Text="Editar" CommandName="Editar" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjMiembros" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyTer" 
                    TypeName="ConsorciosxC" >
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtNitCSUT" Name="IDE_TER" PropertyName="Text" 
                            Type="String" />
                    </SelectParameters>
                    
                </asp:ObjectDataSource>
                </td>
        </tr>
        
    </table>
        
        
        <uc1:UpdAdmTerceros ID="UpdAdmTerceros1" runat="server" />
        
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
                        <asp:TextBox ID="Txt_Id" runat="server" Width="114px" Enabled="False"></asp:TextBox>
                        <asp:Button ID="BtnBuscar" runat="server" Text="..." />
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
                        <asp:Label ID="Label16" runat="server" Text="Nombre del Miembro"></asp:Label>
                    </td>
                    <td style="width: 240px">
                        <asp:TextBox ID="Txt_nom" runat="server" Width="234px" Enabled="False"></asp:TextBox>
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
                        <asp:TextBox ID="TxtPp_m" runat="server" Width="114px" TargetControlID="TxtPp_m"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                            runat="server" FilterType="Custom, Numbers" TargetControlID="TxtPp_m" ValidChars=","> 
                        </ajaxToolkit:FilteredTextBoxExtender>
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

        </asp:Panel>
        
    

</ContentTemplate>
</asp:UpdatePanel>
