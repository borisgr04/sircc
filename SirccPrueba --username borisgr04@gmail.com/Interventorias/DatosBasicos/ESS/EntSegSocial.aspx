<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="EntSegSocial.aspx.vb" Inherits="DatosBasicos_interventorias_EntSegSocial" %>

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

//    function CerrarModalEliminar(ev) {
//        ev.preventDefault();
//        var modalPopupBehavior2 = $find('programmaticModalPopupBehavior');
//        modalPopupBehavior2.hide();
//    }
//        
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
                Text="Entidades de Seguridad Social"></asp:Label><BR /><asp:Label id="MsgResult" 
                runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;<asp:GridView ID="grdInformes" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="Cod_Ent" DataSourceID="ObjEntSegSocial" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" ShowFooter="True" 
                Width="500px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Código" SortExpression="Cod_Ent">
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkNuevo" runat="server" __designer:wfdid="w10" 
                                CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Cod_Ent") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre" SortExpression="Nom_Ent"><FooterTemplate>
                        <asp:ImageButton id="lnkExportar" runat="server" Text="Exportar Datos a Excel" __designer:wfdid="w10" CausesValidation="False" CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32" Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton> 
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Nom_Ent") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo Entidad" SortExpression="NOM_TIP">
                        <ItemTemplate>
                            <asp:Label ID="LbEtapa" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("NOM_TIP") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Etapa">
                        <ItemTemplate>
                            <asp:Label ID="LbEst" runat="server" __designer:wfdid="w23" 
                                Text='<%# Bind("EST_Ent") %>'></asp:Label>
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
                    <asp:LinkButton ID="lnkNuevo" runat="server" 
                        CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            
            
             
            
            <asp:ObjectDataSource ID="ObjEntSegSocial" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecordsDB" 
                TypeName="EntSegSocial"></asp:ObjectDataSource>
            
</contenttemplate>
    </asp:UpdatePanel>&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button>

 <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp;&nbsp;
            <asp:Panel id="programmaticPopup2" runat="server" Width="661px" Height="449px" 
                CssClass="ModalPanel2">
                <asp:Panel id="programmaticPopupDragHandle2"
                 runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2" >
                 <div style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
                 <div style="FLOAT: left">
                            Entidades de Seguridad Social</DIV><DIV style="FLOAT: right">
                            <input id="BtnCerrar" type="button" value="X" /></DIV></DIV></asp:Panel>
                            <asp:Panel id="area" runat="Server" ScrollBars="Auto">
                            
                                <br />
                                <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                <br />
                                <table>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label2" runat="server" Text="Código"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtCod" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="TxtCod" ErrorMessage="Digite el Código">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            Nombre</td>
                        <td>
                            <asp:TextBox ID="TxtInf" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="TxtInf" ErrorMessage="Digite Nombre Entidad">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                                    <tr>
                                        <td style="width: 184px">
                                            Tipo Entidad</td>
                                        <td>
                                            <asp:DropDownList ID="cboTipoEnt" runat="server" DataSourceID="ObjTipo_Ent" 
                                                DataTextField="NOM_TIP" DataValueField="COD_TIP">
                                                <asp:ListItem Value="AC">Activa</asp:ListItem>
                                                <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                    
                   
                  
                                    <tr>
                                        <td style="width: 184px">
                                            Estado</td>
                                        <td>
                                            <asp:DropDownList ID="CboEstado" runat="server">
                                                <asp:ListItem Value="AC">Activa</asp:ListItem>
                                                <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                    <tr>
                        <td style="width: 184px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" />
                            <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" />
                            <INPUT id="BtnCancelar" type="button" value="Cancelar" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </TABLE>
                                <asp:ObjectDataSource ID="ObjTipo_Ent" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                    TypeName="Tipos_Entidades" >
                                    
                                </asp:ObjectDataSource>
                <br />
                </asp:Panel>
                &nbsp;<br /> </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
        
    </asp:UpdatePanel>

    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

