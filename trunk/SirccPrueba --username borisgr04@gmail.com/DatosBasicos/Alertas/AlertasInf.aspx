<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="AlertasInf.aspx.vb" Inherits="DatosBasicos_Alertas_AlertasInf" %>

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
                Text="Alertas - Informes"></asp:Label><BR /><asp:Label id="MsgResult" 
                runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:Label 
                ID="Label12" runat="server" Text="Vigencia"></asp:Label>
            &nbsp;<asp:DropDownList ID="CboVig0" runat="server" AutoPostBack="True" 
                DataSourceID="Vigencias0" DataTextField="year_vig" DataValueField="year_vig" 
                Width="111px">
            </asp:DropDownList>
            &nbsp;<asp:Button ID="Button1" runat="server" Text="..." />
            <asp:GridView 
                id="grdInformes" runat="server" Width="500px" ForeColor="#333333" 
                AllowSorting="True" 
                DataSourceID="ObjAlertasInf" GridLines="None" CellPadding="4" 
                ShowFooter="True" DataKeyNames="Codigo" 
                AutoGenerateColumns="False" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" AllowPaging="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
    <asp:TemplateField HeaderText="Vigencia" SortExpression="Vigencia">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Vigencia") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Vigencia") %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate>
            <asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CausesValidation="False" CommandName="Nuevo"></asp:LinkButton> 
        </FooterTemplate>

    </asp:TemplateField>
    <asp:BoundField DataField="Codigo" HeaderText="Código" 
        SortExpression="Codigo" />
    <asp:BoundField DataField="Informes" HeaderText="Nombre Informe" 
        SortExpression="Informes" />
    <asp:BoundField DataField="FechaI" HeaderText="Fecha Inicial" 
        SortExpression="FechaI" DataFormatString="{0:d}" />
    <asp:BoundField DataField="FechaF" HeaderText="Fecha Final" 
        SortExpression="FechaF" DataFormatString="{0:d}" />
    <asp:BoundField DataField="Recordatorio" DataFormatString="{0:d}" 
        HeaderText="Fecha PreInforme" SortExpression="Recordatorio" />
    <asp:BoundField DataField="Estado" HeaderText="Estado" 
        SortExpression="Estado" />
    <asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>

                <EmptyDataTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Nuevo" 
                        onclick="LinkButton3_Click">Nuevo Registro</asp:LinkButton>
                </EmptyDataTemplate>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
            <asp:ObjectDataSource ID="Vigencias0" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Vigencias"></asp:ObjectDataSource>
            <br />
            <asp:ObjectDataSource id="ObjAlertasInf" runat="server" TypeName="Alertas" 
                SelectMethod="GetRecords" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="CboVig0" Name="Vigencia" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
</contenttemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="grdInformes" />
        </Triggers>
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
                            Alertas&nbsp; de Informes</DIV><DIV style="FLOAT: right">
                            <input id="BtnCerrar" type="button" value="X" /></DIV></DIV></asp:Panel>
                            <asp:Panel id="area" runat="Server" ScrollBars="Auto">
                            
                                <br />
                                <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                                <br />
                                <table>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label9" runat="server" Text="Vigencia"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="CboVig" runat="server" AutoPostBack="True" 
                                DataSourceID="Vigencias0" DataTextField="year_vig" DataValueField="year_vig" 
                                Width="111px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label2" runat="server" Text="Código"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtCod" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label3" runat="server" Text="Nombre del Informes"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtInf" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="TxtInf" ErrorMessage="Digite Codigo Impuesto">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label8" runat="server" Text="Destinatario"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtDest" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                ControlToValidate="TxtDest" ErrorMessage="Escriba entidad destino">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtDes" runat="server" Height="53px" TextMode="MultiLine" 
                                Width="426px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="TxtDes" ErrorMessage="Digite Descrpción del Informe">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label11" runat="server" Text="Fecha Inicial"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtFecIni" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="TxtFecIni_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtFecIni">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="TxtFecIni" ErrorMessage="Digite Fecha Inicial del Periodo">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label6" runat="server" Text="Fecha Final"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtFecFin" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="TxtFecFin_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtFecFin">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="TxtFecFin" 
                                ErrorMessage="Digite Fecha Final del Periodo del Informe">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            Recordatorio</td>
                        <td>
                            <asp:TextBox ID="TxtRec" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="TxtRec_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtRec">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="TxtRec" ErrorMessage="Fecha de Recordatorio">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                                    <tr>
                                        <td style="width: 184px">
                                            Estado</td>
                                        <td>
                                            <asp:DropDownList ID="CboEstado" runat="server">
                                                <asp:ListItem Value="AC">Activa</asp:ListItem>
                                                <asp:ListItem Value="EN">Entregado</asp:ListItem>
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
                            <INPUT id="BtnCancelar" type=button value="Cancelar" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </TABLE>
                <br />
                </asp:Panel>
                &nbsp;<br /> </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
        
    </asp:UpdatePanel>

    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

