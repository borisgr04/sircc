<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="false" CodeFile="TiposProc.aspx.vb" Inherits="DatosBasicos_TiposProc_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <script type='text/javascript'>
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            //$addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);
            $addHandler($get("BtnCancelar"), 'click', CerrarModalTercero);
        }
        function CerrarModalTercero(ev) {
            ev.preventDefault();
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }

        function CerrarModalEliminar(ev) {
            ev.preventDefault();
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior');
            modalPopupBehavior2.hide();
        }
        
    </script>
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </ajaxToolkit:ToolkitScriptManager>
        &nbsp; &nbsp;
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                &nbsp;<asp:Label ID="Tit" runat="server" Width="486px" CssClass="Titulo" Text="Tipos de Procesos/Modalidades de Contratación"></asp:Label><br />
                <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                &nbsp;<asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="Cod_Tproc" DataSourceID="ObjTipos" EmptyDataText="No se encontraron Registros en la Base de Datos"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound="GridView1_RowDataBound1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    ShowFooter="True" Width="688px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Código" SortExpression="Cod_Tproc">
                            <FooterTemplate>
                                <asp:LinkButton ID="lnkNuevo" runat="server" __designer:wfdid="w10" CausesValidation="False"
                                    CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LbCod" runat="server" Text='<%# Bind("Cod_Tproc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre del Proceso" SortExpression="Nom_Tproc">
                            <FooterTemplate>
                                <asp:ImageButton ID="lnkExportar" runat="server" Text="Exportar Datos a Excel" 
                                    CausesValidation="False" CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png"
                                    Height="32" Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Lbcimp" runat="server" Text='<%# Bind("Nom_Tproc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Abreviatura" SortExpression="Abre_Tproc">
                            <ItemTemplate>
                                <asp:Label ID="LbEst" runat="server" Text='<%# Bind("Abre_Tproc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" SortExpression="Esta_Tproc">
                            <ItemTemplate>
                                <asp:Label ID="LbCodAux" runat="server" Text='<%# Bind("Esta_Tproc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Modalidad F20" SortExpression="Ctr_F20_1A">
                            <ItemTemplate>
                                <asp:Label ID="LbForContra" runat="server" Text='<%# Bind("Ctr_F20_1A") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Procedimiento F20" SortExpression="Cod_Ctr">
                            <ItemTemplate>
                                <asp:Label ID="LbCodContra" runat="server"  Text='<%# Bind("Cod_Ctr") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png"
                            Text="Eliminar" />
                        <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png"
                            Text="Editar" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                            ShowSelectButton="True" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="False"
                            CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="Cod_Tproc" EmptyDataText="No se encontraron Registros en la Base de Datos"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound="GridView1_RowDataBound1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    ShowFooter="True" Width="688px">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Código" SortExpression="Cod_Tproc">
                            <ItemTemplate>
                                <asp:Label ID="LbCod0" runat="server" __designer:wfdid="w9" Text='<%# Bind("Cod_Tproc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre del Proceso" SortExpression="Nom_Tproc">
                            <ItemTemplate>
                                <asp:Label ID="Lbcimp0" runat="server" __designer:wfdid="w21" Text='<%# Bind("Nom_Tproc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Abreviatura" SortExpression="Abre_Tproc">
                            <ItemTemplate>
                                <asp:Label ID="LbEst0" runat="server" __designer:wfdid="w22" Text='<%# Bind("Abre_Tproc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" SortExpression="Esta_Tproc">
                            <ItemTemplate>
                                <asp:Label ID="LbCodAux0" runat="server" __designer:wfdid="w23" Text='<%# Bind("Esta_Tproc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Modalidad F20" SortExpression="Ctr_F20_1A">
                            <ItemTemplate>
                                <asp:Label ID="LbForContra0" runat="server" __designer:wfdid="w23" Text='<%# Bind("Ctr_F20_1A") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Procedimiento F20" SortExpression="Cod_Ctr">
                            <ItemTemplate>
                                <asp:Label ID="LbCodContra0" runat="server" __designer:wfdid="w23" Text='<%# Bind("Cod_Ctr") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:LinkButton ID="lnkNuevo1" runat="server" __designer:wfdid="w10" CausesValidation="False"
                            CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjTipos" runat="server" TypeName="TiposProc" SelectMethod="GetRecordsDB"
                    OldValuesParameterFormatString="original_{0}" InsertMethod="Insert" UpdateMethod="Update">
                    <InsertParameters>
                        <asp:Parameter Name="Cod_Tproc" Type="String" />
                        <asp:Parameter Name="Nom_Tproc" Type="String" />
                        <asp:Parameter Name="Abre_Tproc" Type="String" />
                        <asp:Parameter Name="Esta_Tproc" Type="String" />
                        <asp:Parameter Name="Cod_Ctr" Type="String" />
                        <asp:Parameter Name="Ctr_F20_1A" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Cod_Tproc_O" Type="String" />
                        <asp:Parameter Name="Cod_Tproc" Type="String" />
                        <asp:Parameter Name="Nom_Tproc" Type="String" />
                        <asp:Parameter Name="Abre_Tproc" Type="String" />
                        <asp:Parameter Name="Esta_Tproc" Type="String" />
                        <asp:Parameter Name="Cod_Ctr" Type="String" />
                        <asp:Parameter Name="Ctr_F20_1A" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="Gridview1" />
            </Triggers>
        </asp:UpdatePanel>
        &nbsp;
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <!-- Mensaje de Salida-->
                <br />
                <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup2" runat="server">
                </asp:Button>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2"
                    PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground"
                    BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll"
                    TargetControlID="hiddenTargetControlForModalPopup2">
                </ajaxToolkit:ModalPopupExtender>
                &nbsp;&nbsp;
                <asp:Panel ID="programmaticPopup2" runat="server" Width="531px" Height="317px" 
                    CssClass="ModalPanel2">
                    <asp:Panel ID="programmaticPopupDragHandle2" runat="Server" Width="531px" Height="30px"
                        CssClass="BarTitleModal2">
                        <div style="padding: 5px; vertical-align: middle; width: 520px;">
                            <div style="float: left">
                                &nbsp;Procesos/Modalidad</div>
                            <div style="float: right">
                                <input id="BtnCerrar" type="button" value="X" /></div>
                        </div>
                    </asp:Panel>
                    &nbsp;<table align="center">
                        <tbody>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 166px">
                                    <asp:Label ID="Label4" runat="server" __designer:wfdid="w19" Text="Codigo" Width="143px"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="TxtCodNew" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCodNew"
                                        ErrorMessage="Digite  Codigo ">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 166px; height: 23px">
                                    <asp:Label ID="Label1" runat="server" Width="126px" Text="Nombre"></asp:Label>
                                </td>
                                <td style="width: 100px; height: 23px">
                                    <asp:TextBox ID="txtNomNew" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px; height: 23px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNomNew"
                                        ErrorMessage="Requerido">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 166px; height: 18px">
                                    <asp:Label ID="Label5" runat="server" Text="Abreviatura Proceso"></asp:Label>
                                </td>
                                <td style="width: 100px; height: 18px">
                                    <asp:TextBox ID="Txt_Abre_Tproc" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px; height: 18px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNomNew"
                                        ErrorMessage="Requerido">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 166px; height: 19px">
                                    <asp:Label ID="Label6" runat="server" Text="Estado"></asp:Label>
                                </td>
                                <td style="width: 100px; height: 19px">
                                    <asp:DropDownList ID="CboEst" runat="server" Width="106px">
                                        <asp:ListItem Value="AC">Activo</asp:ListItem>
                                        <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px; height: 19px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNomNew"
                                        ErrorMessage="Digite Codigo Impuesto">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 166px">
                                    <asp:Label ID="Label8" runat="server" Text="Modalidad F20" ToolTip="F20"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="Txt_Cod_Con_Dep" runat="server" Width="298px"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 166px">
                                    <asp:Label ID="Label7" runat="server" Text="Procedimiento F20"></asp:Label>
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="Txt_Cod_For_Con" runat="server" Width="294px"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 166px">
                                </td>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="3">
                                    <asp:Button ID="BtnGuardar" OnClick="BtnGuardar_Click" runat="server" Text="Guardar">
                                    </asp:Button>
                                    &nbsp;<asp:Button ID="BtnEliminar" OnClick="BtnEliminar_Click" runat="server" Text="Eliminar">
                                    </asp:Button>
                                    <input id="BtnCancelar" type="button" value="Cancelar" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    &nbsp;</asp:Panel>
                &nbsp;&nbsp;
            </ContentTemplate>
        </asp:UpdatePanel>
    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>
