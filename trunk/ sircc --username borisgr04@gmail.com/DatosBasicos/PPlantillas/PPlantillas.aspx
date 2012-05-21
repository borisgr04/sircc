<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PPlantillas.aspx.vb" Inherits="DatosBasicos_PPlantillas_PPlantillas" %>
<%@ Register src="../../CtrlUsr/Progreso/Progress.ascx" tagname="Progress" tagprefix="uc1" %>
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
                Text="Cargue de Plantillas  *.Doc"></asp:Label><BR />&nbsp;<asp:ImageButton ID="BtnNuevo" runat="server" Height="32px" SkinID="IBtnNuevo" 
                Width="32px" />
            <br />
            <asp:Label id="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
            <asp:GridView 
                id="GridView1" runat="server" Width="95%" ForeColor="#333333" 
                AllowSorting="True" OnRowDataBound="GridView1_RowDataBound1" 
                DataSourceID="ObjPPlantillas" GridLines="None" CellPadding="4" ShowFooter="True" 
                OnRowCommand="GridView1_RowCommand" DataKeyNames="Ide_Pla" 
                AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                EmptyDataText="No se encontraron Registros en la Base de Datos">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
    <asp:BoundField DataField="Ide_Pla" HeaderText="Id" SortExpression="Ide_Pla" />
    <asp:BoundField DataField="Tip_Pla" HeaderText="Tipo" 
        SortExpression="Tip_Pla" />
    <asp:BoundField DataField="Nom_Pla" HeaderText="Nombre " 
        SortExpression="Nom_Pla" />
    <asp:BoundField DataField="ext" HeaderText="Extensión" SortExpression="Ext" />
    <asp:BoundField DataField="Nom_Tproc" HeaderText="Modalidad" 
        SortExpression="Nom_Tproc" />
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
<asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
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
            <asp:ObjectDataSource id="ObjPPlantillas" runat="server" TypeName="PPlantillas" 
                SelectMethod="GetRecordsDB" 
                OldValuesParameterFormatString="original_{0}">
            </asp:ObjectDataSource>
            <br />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    <asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; 
            <asp:Panel id="programmaticPopup2" runat="server" Width="656px" Height="350px" 
                CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
                    <DIV style="padding: 5px; VERTICAL-ALIGN: middle; width: 648px;"><DIV style="FLOAT: left">
                            Plantillas</DIV><DIV style="FLOAT: right">
                            <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>
                &nbsp;<asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                <table style="width:99%;">
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ValidationGroup="Guardar" SkinID="ValidationSummary1" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            <asp:Label ID="Label9" runat="server" Text="Código"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TxtCod" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            <asp:Label ID="Label15" runat="server" Text="Tipo"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="CboTipPla" runat="server">
                                <asp:ListItem>MINUTA INICIAL</asp:ListItem>
                                <asp:ListItem>OTROSI ADICION</asp:ListItem>
                                <asp:ListItem>OTROSI MODIFICATORIO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            <asp:Label ID="Label17" runat="server" Text="Modalidad de Contratación"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="CboTproc" runat="server" CssClass="txt" 
                                DataSourceID="ObjTipoProc" DataTextField="Nom_TProc" DataValueField="Cod_TProc" 
                                ToolTip="Proceso PreContractual">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            <asp:Label ID="Label11" runat="server" Text="Nombre"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TxtNom" runat="server" 
                                 Width="198px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtNom" Display="None" ErrorMessage="Debe digitar El Nombre" 
                                ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            <asp:Label ID="Label16" runat="server" Text="Extensión"></asp:Label>
                        </td>
                        <td style="width: 109px">
                            <asp:DropDownList ID="CboExt" runat="server">
                                <asp:ListItem Value="DOC">*.Doc</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 91px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            <asp:Label ID="Label14" runat="server" Text="Estado"></asp:Label>
                        </td>
                        <td colspan="2" style="width: 109px">
                            <asp:DropDownList ID="CboEst" runat="server">
                                <asp:ListItem Value="AC">Activo</asp:ListItem>
                                <asp:ListItem Value="IN">Inacitvo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 91px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            <asp:Label ID="Label13" runat="server" Text="Plantilla"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                      
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            <asp:Label ID="Label18" runat="server" Text="Contraseña" 
                                ToolTip="Contraseña de Bloqueo del Documento "></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TxtCon" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TxtCon" 
                                ErrorMessage="Se requiere un contraseña por seguridad" 
                                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="TxtCon" ControlToValidate="TxtCon2" 
                                ErrorMessage="Las Contraseñas deben coincidir" ValidationGroup="Guardar">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">
                            <asp:Label ID="Label19" runat="server" Text="Confirmar Contraseña" 
                                ToolTip="Contraseña de Bloqueo del Documento "></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TxtCon2" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TxtCon2" 
                                ErrorMessage="Se requiere un contraseña por seguridad" 
                                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
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
            <asp:ObjectDataSource ID="ObjTipoProc" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="TiposProc"></asp:ObjectDataSource>
</contenttemplate>
    </asp:UpdatePanel>
      <asp:UpdateProgress ID="UpdPrg" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <uc1:Progress ID="Progress1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

