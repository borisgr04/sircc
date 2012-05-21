<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Entidad.aspx.vb" Inherits="DatosBasicos_Entidad_Default" %>

<%@ Register src="../../CtrlUsr/Consorcios/ConsultaCONUT.ascx" tagname="ConsultaCONUT" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/Terceros/ConsultaTer.ascx" tagname="ConsultaTer" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Label id="Tit" runat="server" Width="392px" CssClass="Titulo" 
            Text="Entidad"></asp:Label><BR __designer:mapid="27" />
            <asp:Label id="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
        <table style="width: 95%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td style="width: 66px">
                    &nbsp;</td>
                <td style="text-align: right">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/images/Operaciones/Edit2.png" style="text-align: right" 
                        ToolTip="Editar" />
                </td>
            </tr>
        </table>
        <asp:DetailsView ID="DvEnt" 
            runat="server" AutoGenerateRows="False" 
                            CellPadding="4" DataKeyNames="Cod_SecPrincipal" 
                            EnableModelValidation="True" Font-Size="Medium" ForeColor="#333333" 
                            GridLines="None" Height="84px" Width="95%" 
            DataSourceID="ObjectEntidad">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <Fields>
                                <asp:BoundField DataField="Cod_SecPrincipal" HeaderText="Código de la Entidad" 
                                    SortExpression="Cod_SecPrincipal" />
                                <asp:BoundField DataField="Nom_SecPrincipal" HeaderText="Nobre de la Sede Principal" 
                                    SortExpression="Nom_SecPrincipal" />
                                <asp:BoundField DataField="Nit" HeaderText="Nit" 
                                    SortExpression="Nit" />
                                <asp:BoundField DataField="Representante_Legal" HeaderText="Representante Legal" 
                                    SortExpression="Representante_Legal" />
                                <asp:BoundField DataField="Telefono" HeaderText="Telefono" 
                                    SortExpression="Telefono" />
                                <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
                                <asp:BoundField DataField="Email" 
                                    HeaderText="Correo Electronico" SortExpression="Email" />
                                <asp:BoundField DataField="Direccion" 
                                    HeaderText="Dirección" SortExpression="Direccion" />
                                <asp:BoundField DataField="Pais" 
                                    HeaderText="Pais" SortExpression="Pais" />
                                <asp:BoundField DataField="Departamento" HeaderText="Departamento" SortExpression="Departamento"/>
                                <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" SortExpression="Ciudad"/>
                                <asp:BoundField DataField="Municipio" HeaderText="Eslogan" SortExpression="Municipio"/>
                                
                            </Fields>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderTemplate>
                                INFORMACIÓN DETALLADA DE LA ENTIDAD
                            </HeaderTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:DetailsView>
        <br />
        <asp:Image ID="ImgControl" runat="server" 
            AlternateText="No tiene imagenes asociadas" 
            ImageUrl="~/ashx/logo.ashx" />
        <asp:ObjectDataSource ID="ObjectEntidad" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Entidad"></asp:ObjectDataSource>
        <br />
        <asp:Panel ID="PanelOperaciones" runat="server" BackColor="White" Width="638px">
            <asp:Panel ID="Panel4" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
                Height="27px" Width="637px">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 56px">
                            <asp:Label ID="Label14" runat="server" ForeColor="White" Text="Entidad" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar" runat="server" Text="X" Width="20px" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <table style="width:630px;">
                <tr>
                    <td style="width: 99px" colspan="2">
                        &nbsp;</td>
                    <td colspan="6">
                        &nbsp;</td>
                    <td style="width: 112px">
                        &nbsp;</td>
                    <td style="width: 186px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
                        <asp:Label ID="Label15" runat="server" Text="Código"></asp:Label>
                    </td>
                    <td style="width: 99px">
                        <asp:TextBox ID="Txt_Cod" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label16" runat="server" Text="Nombre de la Sede Principal"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="Txt_nom" runat="server" Width="253px"></asp:TextBox>
                    </td>
                    <td style="width: 112px">
                        &nbsp;</td>
                    <td style="width: 186px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
                        <asp:Label ID="Label17" runat="server" Text="NIT"></asp:Label>
                    </td>
                    <td style="width: 99px">
                        <asp:TextBox ID="Txt_Nit" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label18" runat="server" Text="Representante Legal"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="Txt_Rep_Legal" runat="server" Width="253px"></asp:TextBox>
                    </td>
                    <td style="width: 112px">
                        &nbsp;</td>
                    <td style="width: 186px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
                        <asp:Label ID="Label19" runat="server" Text="Telefono"></asp:Label>
                    </td>
                    <td style="width: 99px">
                        <asp:TextBox ID="Txt_Tel" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td style="width: 344px">
                        <asp:Label ID="Label20" runat="server" Text="Fax"></asp:Label>
                    </td>
                    <td colspan="2" style="width: 344px">
                        <asp:TextBox ID="Txt_Fax" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 381px">
                        <asp:Label ID="Label21" runat="server" Text="E Mail"></asp:Label>
                    </td>
                    <td style="width: 400px">
                        <asp:TextBox ID="Txt_Correo" runat="server" Width="163px"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 99px">
                        <asp:Label ID="Label22" runat="server" Text="Dirección"></asp:Label>
                    </td>
                    <td style="width: 99px">
                        <asp:TextBox ID="Txt_Dir" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label23" runat="server" Text="País"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Txt_Pais" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label24" runat="server" Text="Departamento"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="Txt_Dep" runat="server" Width="163px"></asp:TextBox>
                    </td>
                    <td style="width: 112px">
                        &nbsp;</td>
                    <td style="width: 186px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center; height: 23px;">
                        <asp:Label ID="Label25" runat="server" Text="Ciudad"></asp:Label>
                    </td>
                    <td style="text-align: center; height: 23px;">
                        <asp:TextBox ID="Txt_Ciudad" runat="server" Width="114px"></asp:TextBox>
                    </td>
                    <td style="text-align: center; height: 23px;">
                        <asp:Label ID="Label26" runat="server" Text="Eslogan"></asp:Label>
                    </td>
                    <td colspan="7" style="text-align: left; height: 23px;">
                        <asp:TextBox ID="Txt_Eslogan" runat="server" Width="365px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; height: 23px;">
                        <asp:Label ID="Label27" runat="server" Text="Logo"></asp:Label>
                    </td>
                    <td colspan="9" style="text-align: left; height: 23px;">
                        <asp:FileUpload ID="FuLogo" runat="server" Height="16px" Width="180px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="10" style="text-align: center">
                        <asp:Button ID="Btn_Guardar" runat="server" OnClick="Btn_Guardar_Click" 
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
</div>
</asp:Content>

