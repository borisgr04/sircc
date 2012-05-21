<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PEstadosAct.aspx.vb" Inherits="DatosBasicos_PEstados_Act_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

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
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" 
                Text="Estados de las Actividades"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:GridView 
                id="GridView1" runat="server" Width="753px" ForeColor="#333333" 
                AllowSorting="True" OnRowDataBound="GridView1_RowDataBound1" 
                DataSourceID="ObjTipos" GridLines="None" CellPadding="4" ShowFooter="True" 
                OnRowCommand="GridView1_RowCommand" DataKeyNames="Cod_Est" 
                AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Codigo" SortExpression="Cod_Est"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w10" CausesValidation="False" CommandName="Nuevo"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("Cod_Est") %>' __designer:wfdid="w9"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre del Estado" SortExpression="Nom_Est">
    <FooterTemplate>
        <asp:ImageButton ID="lnkExportar" runat="server" __designer:wfdid="w10" 
            CausesValidation="False" CommandName="Exportar" Height="32" 
            ImageUrl="~/images/Operaciones/excel.png" Text="Exportar Datos a Excel" 
            ToolTip="Exportar Datos a Excel" Width="32" />
    </FooterTemplate>
    <ItemTemplate>
<asp:Label id="Lbcimp" runat="server" Text='<%# Bind("Nom_Est") %>' __designer:wfdid="w21"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
    <asp:ImageField 
    HeaderText="Imagen" 
    DataImageUrlField="imagen"
    InsertVisible="False"
    NullDisplayText="Imagen no disponible" 
    ReadOnly="true" NullImageUrl="~/Docs/imgpact/noDisponible.jpg">
    <ControlStyle Height="48px" Width="48px" />
    </asp:ImageField>
<asp:TemplateField HeaderText="Color" SortExpression="Color"><ItemTemplate>
<asp:Label id="LbCol" runat="server" Text='<%# Bind("Color") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>    
<asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>

                <EmptyDataTemplate>
                    <asp:LinkButton ID="lnkNuevo" runat="server" __designer:wfdid="w10" 
                        CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                </EmptyDataTemplate>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Cod_Est" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="753px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Codigo" SortExpression="Cod_Est">
                        <ItemTemplate>
                            <asp:Label ID="LbCod0" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Cod_Est") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre del Estado" SortExpression="Nom_Est">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp0" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Nom_Est") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ImageField DataImageUrlField="imagen" HeaderText="Imagen" 
                        InsertVisible="False" NullDisplayText="Imagen no disponible" 
                        NullImageUrl="~/Docs/imgpact/noDisponible.jpg" ReadOnly="true">
                        <ControlStyle Height="48px" Width="48px" />
                    </asp:ImageField>
                    <asp:TemplateField HeaderText="Color" SortExpression="Color">
                        <ItemTemplate>
                            <asp:Label ID="LbCol0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Color") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />
            <asp:ObjectDataSource id="ObjTipos" runat="server" TypeName="PEstadosAct" 
                SelectMethod="GetRecords" 
                OldValuesParameterFormatString="original_{0}">
            </asp:ObjectDataSource>
</contenttemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Gridview1" />
        </Triggers>
    </asp:UpdatePanel>&nbsp;
    <asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; 
            <asp:Panel id="programmaticPopup2" runat="server" Width="413px" Height="289px" 
                CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
                    <DIV style="padding: 5px; VERTICAL-ALIGN: middle; width: 401px;"><DIV style="FLOAT: left">
                            Estado Actividad</DIV><DIV style="FLOAT: right">
                            <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>
                &nbsp;<asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                <table style="width:100%;">
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ValidationGroup="Guardar" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 51px">
                            <asp:Label ID="Label9" runat="server" Text="Código"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TxtCod" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TxtCod" Display="None" ErrorMessage="Debe Digitar el Codigo" 
                                ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 51px">
                            <asp:Label ID="Label11" runat="server" Text="Nombre"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TxtNom" runat="server" Width="198px" 
                            onkeyup = "this.value=this.value.toUpperCase()"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                Display="None" ErrorMessage="Debe digitar El Nombre" 
                                ValidationGroup="Guardar" ControlToValidate="TxtNom"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 51px">
                            <asp:Label ID="Label14" runat="server" Text="Color"></asp:Label>
                        </td>
                        <td style="width: 109px">
                            <asp:TextBox ID="TxtColor" runat="server"></asp:TextBox>
                            <ajaxToolkit:ColorPickerExtender ID="ColorPickerExtender1" runat="server" 
                                PopupButtonID="BtnColor" TargetControlID="TxtColor">
                            </ajaxToolkit:ColorPickerExtender>
                        </td>
                        <td style="width: 91px">
                            <asp:ImageButton ID="BtnColor" runat="server" 
                                ImageUrl="~/images/Operaciones/paleta.png" Width="17px" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 51px">
                            <asp:Label ID="Label13" runat="server" Text="Imagen"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 51px">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <asp:Button ID="BtnGuardar" runat="server" onclick="BtnGuardar_Click" 
                                Text="Guardar" ValidationGroup="Guardar" />
                            &nbsp;<asp:Button ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" 
                                Text="Eliminar" />
                            &nbsp;
                            <input ID="BtnCancelar" type="button" value="Cancelar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>

    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

