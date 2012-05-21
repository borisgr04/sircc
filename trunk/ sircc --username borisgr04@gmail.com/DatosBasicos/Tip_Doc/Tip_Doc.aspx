<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="Tip_Doc.aspx.vb" Inherits="DatosBasicos_Tip_Doc_Default" %>

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
                Text="Tipos de Documentos"></asp:Label><BR /><asp:Label id="MsgResult" 
                runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td style="width: 96px">
                        <asp:Label ID="Label7" runat="server" Text="Filtrar por Etapas"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="Cmb_Fil_Eta" runat="server" AutoPostBack="True" 
                            DataSourceID="Etapas" DataTextField="Nom_Eta" DataValueField="Cod_Eta" 
                            Width="225px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                
            </table>
            <br />
            <asp:GridView ID="GridView1" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="COD_TIP" DataSourceID="ObjTipos" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="500px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Código" SortExpression="Cod_Tip">
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkNuevo" runat="server" __designer:wfdid="w10" 
                                CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("COD_TIP") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre del Tipo" SortExpression="Des_Tip"><FooterTemplate>
                        <asp:ImageButton id="lnkExportar" runat="server" Text="Exportar Datos a Excel" __designer:wfdid="w10" CausesValidation="False" CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32" Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton> 
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("DES_TIP") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                        <ItemTemplate>
                            <asp:Label ID="LbEst" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("ESTADO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Etapa" SortExpression="Etapa">
                        <ItemTemplate>
                            <asp:Label ID="LbEtapa" runat="server" __designer:wfdid="w23" 
                                Text='<%# Bind("ETAPA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                        ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                    <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                        ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:LinkButton ID="lnkNuevo" runat="server" __designer:wfdid="w10" 
                        CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="COD_TIP" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="500px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Código" SortExpression="Cod_Tip">
                        <ItemTemplate>
                            <asp:Label ID="LbCod0" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("COD_TIP") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre del Tipo" SortExpression="Des_Tip">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp0" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("DES_TIP") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Est_Tip">
                        <ItemTemplate>
                            <asp:Label ID="LbEst0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Est_tip") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Etapa" SortExpression="Etapa">
                        <ItemTemplate>
                            <asp:Label ID="LbEtapa0" runat="server" __designer:wfdid="w23" 
                                Text='<%# Bind("NOM_ETA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:LinkButton ID="lnkNuevo1" runat="server" __designer:wfdid="w10" 
                        CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />
            <asp:ObjectDataSource id="ObjTipos" runat="server" TypeName="Tip_Doc" 
                SelectMethod="GetbyEtapa" InsertMethod="Insert" 
                OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
                <UpdateParameters>
                    <asp:Parameter Name="Cod_Tip_O" Type="String" />
                    <asp:Parameter Name="Cod_Tip" Type="String" />
                    <asp:Parameter Name="Des_Tip" Type="String" />
                    <asp:Parameter Name="Est_Tip" Type="String" />
                    <asp:Parameter Name="Cod_Etapa" Type="String" />
                </UpdateParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="Cmb_Fil_Eta" DefaultValue="01" Name="Cod_Eta" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <InsertParameters>
                    <asp:Parameter Name="Cod_Tip" Type="String" />
                    <asp:Parameter Name="Des_Tip" Type="String" />
                    <asp:Parameter Name="Est_Tip" Type="String" />
                    <asp:Parameter Name="Cod_Etapa" Type="String" />
                </InsertParameters>
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
            <asp:Panel id="programmaticPopup2" runat="server" Width="409px" Height="330px" 
                CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
                    <DIV style="padding: 5px; VERTICAL-ALIGN: middle; width: 401px;"><DIV style="FLOAT: left">
                Tipos de Contratos</DIV><DIV style="FLOAT: right">
                            <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE 
                    align="center"><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR>
        <TR><TD colSpan=3>
            <asp:ValidationSummary id="ValidationSummary1" runat="server">
                    </asp:ValidationSummary></TD></TR>
        <TR><TD style="WIDTH: 98px">
                <asp:Label id="Label4" runat="server" Width="143px" Text="Código" 
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
                        <asp:DropDownList ID="CboEst" runat="server" Width="105px">
                            <asp:ListItem Value="AC">Activo</asp:ListItem>
                            <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                        </asp:DropDownList>
                    </TD><TD style="WIDTH: 100px; HEIGHT: 18px">&#160;</TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 19px">
                    <asp:Label ID="Label6" runat="server" Text="Etapa"></asp:Label>
                    </TD><TD style="WIDTH: 100px; HEIGHT: 19px">
                        <asp:DropDownList ID="Cbo_Eta" runat="server" DataSourceID="Etapas" 
                        DataTextField="NOM_ETA" DataValueField="COD_ETA" Width="134px">
                            <asp:ListItem Value="AC">Activo</asp:ListItem>
                            <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                        </asp:DropDownList>
                    <asp:ObjectDataSource ID="Etapas" runat="server" InsertMethod="Insert" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                        TypeName="Etapas" UpdateMethod="Update">
                        <UpdateParameters>
                            <asp:Parameter Name="Cod_Eta_O" Type="String" />
                            <asp:Parameter Name="Cod_Eta" Type="String" />
                            <asp:Parameter Name="Nom_Eta" Type="String" />
                            <asp:Parameter Name="Estado" Type="String" />
                        </UpdateParameters>
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        <InsertParameters>
                            <asp:Parameter Name="Cod_Tip" Type="String" />
                            <asp:Parameter Name="Des_Tip" Type="String" />
                            <asp:Parameter Name="Estado" Type="String" />
                        </InsertParameters>
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                    </asp:ObjectDataSource>
            </TD>
            <TD style="WIDTH: 100px; HEIGHT: 19px">
                &nbsp;</TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD>
            <TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="WIDTH: 98px"></TD>
            <TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR>
            <TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar">
                    </asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar">
                    </asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp;</asp:Panel>
            &nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>

    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

