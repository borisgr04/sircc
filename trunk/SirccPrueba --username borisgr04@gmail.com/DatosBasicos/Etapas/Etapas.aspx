<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Etapas.aspx.vb" EnableEventValidation="false" Inherits="DatosBasicos_TiposCont_Default" %>

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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" Text="Etapas"></asp:Label><BR />
            <asp:Label id="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:GridView 
                id="GridView1" runat="server" Width="500px" ForeColor="#333333" 
                AllowSorting="True" OnRowDataBound="GridView1_RowDataBound1" 
                DataSourceID="ObjTipos" GridLines="None" CellPadding="4" ShowFooter="True" 
                OnRowCommand="GridView1_RowCommand" DataKeyNames="Cod_Eta" 
                AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Código" SortExpression="Cod_Eta"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w10" CausesValidation="False" CommandName="Nuevo"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("Cod_Eta") %>' __designer:wfdid="w9"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre del Tipo" SortExpression="Nom_Eta"><FooterTemplate>
<asp:ImageButton id="lnkExportar" runat="server" Text="Exportar Datos a Excel" __designer:wfdid="w10" CausesValidation="False" CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32" Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton> 
</FooterTemplate><ItemTemplate>
<asp:Label id="Lbcimp" runat="server" Text='<%# Bind("Nom_Eta") %>' __designer:wfdid="w21"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Estado" SortExpression="Estado"><ItemTemplate>
<asp:Label id="LbEst" runat="server" Text='<%# Bind("Estado") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>

                <EmptyDataTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Nuevo">Nuevo Registro</asp:LinkButton>
                </EmptyDataTemplate>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Cod_Eta" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="500px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Código" SortExpression="Cod_Eta">
                        <ItemTemplate>
                            <asp:Label ID="LbCod0" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Cod_Eta") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre del Tipo" SortExpression="Nom_Eta">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp0" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Nom_Eta") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                        <ItemTemplate>
                            <asp:Label ID="LbEst0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Nuevo">Nuevo Registro</asp:LinkButton>
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />
            <asp:ObjectDataSource id="ObjTipos" runat="server" TypeName="Etapas" 
                SelectMethod="GetRecordsDB" InsertMethod="Insert" 
                OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
                <InsertParameters>
                    <asp:Parameter Name="Cod_Eta" Type="String" />
                    <asp:Parameter Name="Nom_Eta" Type="String" />
                    <asp:Parameter Name="Estado" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Cod_Eta_O" Type="String" />
                    <asp:Parameter Name="Cod_Eta" Type="String" />
                    <asp:Parameter Name="Nom_Eta" Type="String" />
                    <asp:Parameter Name="Estado" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->
</contenttemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Gridview1" />
        </Triggers>
    </asp:UpdatePanel>&nbsp;
    <asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; 
            <asp:Panel id="programmaticPopup2" runat="server" Width="409px" Height="304px" 
                CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
                    <DIV style="padding: 5px; VERTICAL-ALIGN: middle; width: 401px;"><DIV style="FLOAT: left">
                            Etapas</DIV><DIV style="FLOAT: right">
                            <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE 
                    align="center"><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR>
        <TR><TD colSpan=3>
            <asp:ValidationSummary id="ValidationSummary1" runat="server">
                    </asp:ValidationSummary></TD></TR>
        <TR><TD style="WIDTH: 98px">
                <asp:Label id="Label4" runat="server" Width="143px" Text="Tipo" 
                    __designer:wfdid="w19"></asp:Label></TD>
            <TD style="WIDTH: 100px"><asp:TextBox ID="TxtCodNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtCodNew" ErrorMessage="Digite  Codigo ">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 23px">
                <asp:Label id="Label1" runat="server" Width="126px" Text="Nombre"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                    <asp:TextBox ID="txtNomNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtNomNew" ErrorMessage="Digite Codigo Impuesto">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 18px">
                    <asp:Label ID="Label5" runat="server" Text="Estado"></asp:Label>
                    </TD><TD style="WIDTH: 100px; HEIGHT: 18px">
                        <asp:DropDownList ID="CboEst" runat="server">
                            <asp:ListItem Value="AC">Activo</asp:ListItem>
                            <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                        </asp:DropDownList>
                    </TD><TD style="WIDTH: 100px; HEIGHT: 18px">&#160;</TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 19px">
                &nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 19px">&nbsp;</TD>
            <TD style="WIDTH: 100px; HEIGHT: 19px">
                &nbsp;</TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD>
            <TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="WIDTH: 98px"></TD>
            <TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR>
            <TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar">
                    </asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar">
                    </asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp;</asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>

    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

