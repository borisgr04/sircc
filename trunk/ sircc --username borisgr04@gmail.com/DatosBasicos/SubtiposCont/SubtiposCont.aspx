<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="SubtiposCont.aspx.vb" Inherits="DatosBasicos_SubTiposCont_Default" %>

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
                Text="Subtipos de Contratos"></asp:Label><BR /><asp:Label id="MsgResult" 
                runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<br />
            <table style="width:100%;">
                <tr>
                    <td style="width: 144px">
                        <asp:Label ID="Label9" runat="server" Text="Filtrar por Tipos de Contrato"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="Cmb_Fil_Tip_Con" runat="server" AutoPostBack="True" 
                            DataSourceID="ObjTiposCont" DataTextField="Nom_Tip" DataValueField="Cod_Tip" 
                            Width="174px">
                        </asp:DropDownList>
                        <asp:Button ID="Button1" runat="server" Text="Filtrar" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                
            </table>
            <br />
            <asp:GridView ID="GridView1" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="Cod_Stip" DataSourceID="ObjTipos" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="572px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Código" SortExpression="Cod_Stip">
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkNuevo" runat="server" __designer:wfdid="w10" 
                                CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Cod_Stip") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre del Subtipo" SortExpression="Nom_Stip"><FooterTemplate>
                        <asp:ImageButton id="lnkExportar" runat="server" Text="Exportar Datos a Excel" __designer:wfdid="w10" CausesValidation="False" CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32" Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton> 
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Nom_Stip") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo de Contrato" SortExpression="Nom_Tip">
                        <ItemTemplate>
                            <asp:Label ID="LbEst" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Nom_Tip") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Codigo Auxiliar" SortExpression="Cla_Con_Dep">
                        <ItemTemplate>
                            <asp:Label ID="LbCodAux" runat="server" __designer:wfdid="w23" 
                                Text='<%# Bind("Cla_Con_Dep") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Codigo Formulario" SortExpression="CRT_F20_1A">
                        <ItemTemplate>
                            <asp:Label ID="LbCodFor" runat="server" __designer:wfdid="w24" 
                                Text='<%# Bind("CRT_F20_1A") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Codigo Contraloria" SortExpression="CLA_CON_DP">
                        <ItemTemplate>
                            <asp:Label ID="LbCodCon" runat="server" __designer:wfdid="w25" 
                                Text='<%# Bind("CLA_CON_DP") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                    <ItemTemplate>
                            <asp:Label ID="LbEstado" runat="server" __designer:wfdid="w26" 
                                Text='<%# Bind("ESTADO") %>'></asp:Label>
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
            <asp:ObjectDataSource id="ObjTipos" runat="server" TypeName="SubTipos" 
                SelectMethod="GetByTipoDB" 
                OldValuesParameterFormatString="original_{0}" UpdateMethod="Update" 
                InsertMethod="Insert">
                <InsertParameters>
                    <asp:Parameter Name="Cod_Stip" Type="String" />
                    <asp:Parameter Name="Nom_Stip" Type="String" />
                    <asp:Parameter Name="Cod_Tip" Type="String" />
                    <asp:Parameter Name="Cla_Con_Dep" Type="String" />
                    <asp:Parameter Name="Crt_F20_1A" Type="String" />
                    <asp:Parameter Name="Cla_Con_Dp" Type="String" />
                    <asp:Parameter Name="estado" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="Cmb_Fil_Tip_Con" DefaultValue="" 
                        Name="cod_tip" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Cod_Stip_O" Type="String" />
                    <asp:Parameter Name="Cod_Stip" Type="String" />
                    <asp:Parameter Name="Nom_Stip" Type="String" />
                    <asp:Parameter Name="Cod_Tip" Type="String" />
                    <asp:Parameter Name="Cla_Con_Dep" Type="String" />
                    <asp:Parameter Name="Crt_F20_1A" Type="String" />
                    <asp:Parameter Name="Cla_Con_Dp" Type="String" />
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
            <asp:Panel id="programmaticPopup2" runat="server" Width="413px" Height="358px" 
                CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
                    <DIV style="padding: 5px; VERTICAL-ALIGN: middle; width: 400px;"><DIV style="FLOAT: left">
                            Subtipos de Contratos</DIV><DIV style="FLOAT: right">
                            <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE 
                    align="center"><TBODY>
        <TR><TD colSpan=3>
            <asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR>
        <TR><TD colSpan=3>
            <asp:ValidationSummary id="ValidationSummary1" runat="server">
                    </asp:ValidationSummary></TD></TR>
        <TR><TD style="WIDTH: 162px">
                <asp:Label ID="Label4" runat="server" __designer:wfdid="w19" Text="Codigo" 
                        Width="143px"></asp:Label></TD>
            <TD style="WIDTH: 513px">
                <asp:TextBox ID="TxtCodNew" runat="server" Width="229px"></asp:TextBox></TD>
            <TD style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtCodNew" ErrorMessage="Digite  Codigo ">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 162px; HEIGHT: 23px">
                <asp:Label id="Label1" runat="server" Width="126px" Text="Nombre"></asp:Label></TD>
            <TD style="WIDTH: 513px; HEIGHT: 23px">
                    <asp:TextBox ID="txtNomNew" runat="server" Width="229px"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtNomNew" ErrorMessage="Digite Codigo Impuesto">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 162px; HEIGHT: 18px">
                    <asp:Label ID="Label5" runat="server" Text="Tipo"></asp:Label>
                    </TD><TD style="WIDTH: 513px; HEIGHT: 18px">
                <asp:DropDownList ID="CboTip" 
                        runat="server" CssClass="txt" DataSourceID="ObjTiposCont" 
                        DataTextField="NOM_TIP" DataValueField="COD_TIP" Height="18px">
                        </asp:DropDownList>
                    </TD><TD style="WIDTH: 100px; HEIGHT: 18px">
                        
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtNomNew" ErrorMessage="Digite Codigo Impuesto">*</asp:RequiredFieldValidator>
                    </TD></TR>
        <TR><TD style="WIDTH: 162px; HEIGHT: 19px">
                <asp:Label ID="Label6" runat="server" Text="Codigo Auxiliar"></asp:Label>
            </TD><TD style="WIDTH: 513px; HEIGHT: 19px">
                <asp:TextBox ID="Txt_Cod_Aux" runat="server" Width="107px"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 100px; HEIGHT: 19px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtNomNew" ErrorMessage="Digite Codigo Impuesto">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 162px">
                <asp:Label ID="Label7" runat="server" Text="Codigo Formato Contraloria"></asp:Label>
            </TD>
            <TD style="WIDTH: 513px">
                <asp:TextBox ID="Txt_Cod_For_Con" runat="server" Width="107px"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="WIDTH: 162px">
                <asp:Label ID="Label8" runat="server" Text=" Código Contraloria Departamental"></asp:Label>
            </TD>
            <TD style="WIDTH: 513px">
                <asp:TextBox ID="Txt_Cod_Con_Dep" runat="server" Width="107px"></asp:TextBox>
            </TD><TD style="WIDTH: 100px"></TD></TR>
        <TR>
            <TD style="WIDTH: 162px">
                    <asp:Label ID="Label10" runat="server" Text="Estado"></asp:Label>
                    </TD><TD style="WIDTH: 513px">
                <asp:DropDownList ID="Cmb_Estado" runat="server" Width="107px">
                    <asp:ListItem Value="AC">ACTIVO</asp:ListItem>
                    <asp:ListItem Value="IN">INACTIVO</asp:ListItem>
                    </asp:DropDownList>
            </TD><TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="TEXT-ALIGN: center" colSpan=3>
            &nbsp;</TD></TR>
        <tr><td colspan="3" style="TEXT-ALIGN: center"><asp:Button ID="BtnGuardar" 
                runat="server" onclick="BtnGuardar_Click" Text="Guardar">
                    </asp:Button>
            &#160;<asp:Button ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" 
                Text="Eliminar">
                    </asp:Button>  <input id="BtnCancelar" type="button" value="Cancelar" /> </td></tr>
        <tr><td colspan="3" style="TEXT-ALIGN: center">&#160;</td></tr></TBODY></TABLE>&nbsp;<asp:ObjectDataSource 
                    ID="ObjTiposCont" runat="server" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetRecords" TypeName="Tipos" InsertMethod="Insert" 
                    UpdateMethod="Update">
                    <UpdateParameters>
                        <asp:Parameter Name="Cod_Tip_O" Type="String" />
                        <asp:Parameter Name="Cod_Tip" Type="String" />
                        <asp:Parameter Name="Nom_Tip" Type="String" />
                        <asp:Parameter Name="Est_Tip" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Cod_Tip" Type="String" />
                        <asp:Parameter Name="Nom_Tip" Type="String" />
                        <asp:Parameter Name="Est_Tip" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                AssociatedUpdatePanelID="UpdatePanel2">
                <progresstemplate>
                    <div class="Loading">
                        <asp:Image ID="ImgAjax" runat="server" SkinID="ImgProgress" />
                        Cargando …
                    </div>
                </progresstemplate>
            </asp:UpdateProgress>
    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>
     
