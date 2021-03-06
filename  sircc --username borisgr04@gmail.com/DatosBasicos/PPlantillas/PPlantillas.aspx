﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PPlantillas.aspx.vb" Inherits="DatosBasicos_PPlantillas_PPlantillas" %>
<%@ Register src="../../CtrlUsr/Progreso/Progress.ascx" tagname="Progress" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <script type='text/javascript'>
    // Add click handlers for buttons to show and hide modal popup on pageLoad
    function pageLoad() {
        $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);
       // $addHandler($get("BtnCancelar"), 'click', CerrarModalTercero);
    }
    function CerrarModalTercero(ev) {
        ev.preventDefault();
        var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
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
        <asp:Label ID="Label1" runat="server" 
                Text="Buscar (Tipo, Nombre o Clase)"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TxtBuscar" runat="server" Height="21px" Width="371px"></asp:TextBox>
            <asp:ImageButton ID="IBtnBuscar" runat="server" SkinID="IBtnBuscar" />
            <br />
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
                AllowPaging="True" EnableModelValidation="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
    <asp:BoundField DataField="Ide_Pla" HeaderText="Id" SortExpression="Ide_Pla" />
    <asp:BoundField DataField="TIPO_PLANTILLA" HeaderText="Tipo" 
        SortExpression="TIPO_PLANTILLA" />
    <asp:BoundField DataField="Nom_Pla" HeaderText="Nombre " 
        SortExpression="Nom_Pla" />
    <asp:BoundField DataField="ext" HeaderText="Extensión" SortExpression="Ext" />
    <asp:BoundField DataField="Clase" HeaderText="Clase" 
        SortExpression="Clase" />
    <asp:BoundField DataField="est_pla" HeaderText="Estado" 
        SortExpression="est_pla" />
    <asp:ButtonField ButtonType="Image" CommandName="download" 
        ImageUrl="~/images/2012/Files-Download-File-icon.png" Text="Descagar" />
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
<asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
            <asp:ObjectDataSource id="ObjPPlantillas" runat="server" TypeName="PPlantillas" 
                SelectMethod="GetRecords" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtBuscar" Name="busc" PropertyName="Text" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    <asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; 
            <asp:Panel id="programmaticPopup2" runat="server" Width="657px" Height="504px" 
                CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
                    <DIV style="padding: 5px; VERTICAL-ALIGN: middle; width: 648px;"><DIV style="FLOAT: left">
                            Plantillas</DIV><DIV style="FLOAT: right">
                            <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>
                &nbsp;<asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                <table style="width:99%;">
                    <tr>
                        <td colspan="8">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ValidationGroup="Guardar" SkinID="ValidationSummary1" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px" colspan="2">
                            <asp:Label ID="Label9" runat="server" Text="Código"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="TxtCod" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 140px" colspan="2">
                            <asp:Label ID="Label15" runat="server" Text="Tipo"></asp:Label>
                        </td>
                        <td colspan="6">
                            <asp:DropDownList ID="CboTipPla" runat="server" DataSourceID="ObjTipPlantillas" 
                                DataTextField="nom_tippla" DataValueField="id_tippla">
                               
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px" colspan="2">
                            <asp:Label ID="Label17" runat="server" Text="Clase de Contratación"></asp:Label>
                            (Solo para Minutas)</td>
                        <td colspan="6">
                            <asp:DropDownList ID="CboSTip" runat="server" CssClass="txt" 
                                DataSourceID="ObjSubTipos" DataTextField="Nom_STip" DataValueField="Cod_STip" 
                                ToolTip="Proceso PreContractual">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px" colspan="2">
                            <asp:Label ID="Label11" runat="server" Text="Nombre"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="TxtNom" runat="server" 
                                 Width="198px"></asp:TextBox>
                        </td>
                        <td colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtNom" Display="None" ErrorMessage="Debe digitar El Nombre" 
                                ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px" colspan="2">
                            <asp:Label ID="Label16" runat="server" Text="Extensión"></asp:Label>
                        </td>
                        <td style="width: 109px" colspan="2">
                            <asp:DropDownList ID="CboExt" runat="server">
                                <asp:ListItem Value="DOC">*.Doc</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 91px" colspan="2">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td style="width: 140px" colspan="2">
                            <asp:Label ID="Label14" runat="server" Text="Estado"></asp:Label>
                        </td>
                        <td colspan="4" style="width: 109px">
                            <asp:DropDownList ID="CboEst" runat="server">
                                <asp:ListItem Value="AC">Activo</asp:ListItem>
                                <asp:ListItem Value="IN">Inacitvo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 91px" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 140px" colspan="2">
                            <asp:Label ID="Label13" runat="server" Text="Plantilla"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                      
                    </tr>
                    <tr>
                        <td colspan="8" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            &nbsp;&nbsp;&nbsp;</td>
                        <td colspan="2" style="text-align: center">
                            <asp:ImageButton ID="BtnGuardar" runat="server" SkinID="IBtnGuardar" />
                        </td>
                        <td colspan="2" style="text-align: center">
                            <asp:ImageButton ID="BtnEliminar" runat="server" SkinID="IBtnEliminar" />
                        </td>
                        <td colspan="2" style="text-align: center">
                            <asp:ImageButton ID="BtnCancelar" runat="server" SkinID="IBtnCancelar" OnClientClick="CerrarModalTercero(this)" />
                        </td>
                        <td style="text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td colspan="2" style="text-align: center">
                            Guardar</td>
                        <td colspan="2" style="text-align: center">
                            Anular</td>
                        <td colspan="2" style="text-align: center">
                            Cancelar</td>
                        <td style="text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="8" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>&nbsp;&nbsp; 
            <asp:ObjectDataSource ID="ObjSubTipos" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="SubTipos" InsertMethod="Insert" UpdateMethod="Update">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjTipPlantillas" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="TipPlantillas"></asp:ObjectDataSource>
</contenttemplate>
    </asp:UpdatePanel>
      <asp:UpdateProgress ID="UpdPrg" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <uc1:Progress ID="Progress1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

