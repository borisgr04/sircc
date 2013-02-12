<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PActividades.aspx.vb" Inherits="DatosBasicos_PActividades_Default" %>
<%@ Register Src="../../CtrlUsr/Progreso/Progress.ascx" TagName="Progress" TagPrefix="ucProg" %>
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
            &nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" Text="Actividades"></asp:Label><BR />
            <asp:Label id="MsgResult" runat="server" Height="100%" SkinID="MsgResult"></asp:Label>
            &nbsp;&nbsp;&nbsp;<br />
            <table style="width:100%;">
                <tr>
                    <td style="width: 72px">
                        <asp:Label ID="Label15" runat="server" CssClass="SubTitulo" Text="Filtrar"></asp:Label>
                    </td>
                    <td style="width: 171px">
                        &nbsp;</td>
                    <td style="width: 121px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 72px">
                        <asp:CheckBox ID="Chk_Vig" runat="server" CssClass="selectIndex" 
                            Text="Vigencia" AutoPostBack="True" />
                    </td>
                    <td style="width: 171px">
                        <asp:DropDownList ID="CboFilVig" runat="server" DataSourceID="Vigencias" 
                            DataTextField="year_vig" DataValueField="year_vig" Width="111px" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 121px">
                        <asp:CheckBox ID="Chk_Tproc" runat="server" CssClass="selectIndex" 
                            Text="Tipos de Proceso" AutoPostBack="True" />
                    </td>
                    <td>
                        <asp:DropDownList ID="CboFilTproc" runat="server" DataSourceID="TipProc" 
                            DataTextField="Nom_Tproc" DataValueField="Cod_Tproc" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="LnkNuevo" runat="server">Nueva Actividad</asp:LinkButton>
                    </td>
                    <td style="width: 121px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:GridView 
                id="GridView1" runat="server" Width="100%" ForeColor="#333333" 
                AllowSorting="True" OnRowDataBound="GridView1_RowDataBound1" 
                DataSourceID="ObjTipos" GridLines="None" CellPadding="4" ShowFooter="True" 
                OnRowCommand="GridView1_RowCommand" DataKeyNames="Cod_Act,Cod_Tpro" 
                AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                EmptyDataText="No se encontraron Registros en la Base de Datos">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Código" SortExpression="Cod_Act"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w10" CausesValidation="False" CommandName="Nuevo"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("Cod_Act") %>' __designer:wfdid="w9"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Vigencia" SortExpression="Vigencia">
    <FooterTemplate>
        <asp:ImageButton ID="lnkExportar" runat="server" __designer:wfdid="w10" 
            CausesValidation="False" CommandName="Exportar" Height="32" 
            ImageUrl="~/images/Operaciones/excel.png" Text="Exportar Datos a Excel" 
            ToolTip="Exportar Datos a Excel" Width="32" />
    </FooterTemplate>
    <ItemTemplate>
<asp:Label id="LbVig" runat="server" Text='<%# Bind("Vigencia") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
    </asp:TemplateField>
<asp:TemplateField HeaderText="Tipo de Proceso" SortExpression="Nom_Tproc"><ItemTemplate>
<asp:Label id="LbEst" runat="server" Text='<%# Bind("Nom_Tproc") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Nombre de la Actividad" SortExpression="Nom_Act"><ItemTemplate>
<asp:Label id="Lbcimp" runat="server" Text='<%# Bind("Nom_Act") %>' __designer:wfdid="w21"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Estado" SortExpression="Nom_Est">
    <ItemTemplate>
<asp:Label id="LbNomTact" runat="server" Text='<%# Bind("Nom_Est") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
    </asp:TemplateField>
       <asp:TemplateField HeaderText="Orden" SortExpression="Orden">
    <ItemTemplate>
<asp:Label id="LbOrden" runat="server" Text='<%# Bind("Orden") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
    <ItemTemplate>
<asp:Label id="LbEstado" runat="server" Text='<%# Bind("Estado") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Obligatorio" SortExpression="Obligatorio">
    <ItemTemplate>
<asp:Label id="LbObli" runat="server" Text='<%# Bind("Obligatorio") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Ocupado" SortExpression="Ocupado">
    <ItemTemplate>
<asp:Label id="LbOcupa" runat="server" Text='<%# Bind("Ocupado") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="dia_nohabil" HeaderText="Dia no Hábil" 
        SortExpression="dia_nohabil" />
    <asp:BoundField DataField="Notificar" HeaderText="Notificar" 
        SortExpression="Notificar" />
<asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Cod_Act,Cod_Tpro" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="100%">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Código" SortExpression="Cod_Act">
                        <ItemTemplate>
                            <asp:Label ID="LbCod0" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Cod_Act") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vigencia" SortExpression="Vigencia">
                        <ItemTemplate>
                            <asp:Label ID="LbVig0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Vigencia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo de Proceso" SortExpression="Nom_Tproc">
                        <ItemTemplate>
                            <asp:Label ID="LbEst0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Nom_Tproc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre de la Actividad" SortExpression="Nom_Act">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp0" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Nom_Act") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Nom_Est">
                        <ItemTemplate>
                            <asp:Label ID="LbNomTact0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Nom_Est") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Orden" SortExpression="Orden">
                        <ItemTemplate>
                            <asp:Label ID="LbOrden0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Orden") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                        <ItemTemplate>
                            <asp:Label ID="LbEstado0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Obligatorio" SortExpression="Obligatorio">
                        <ItemTemplate>
                            <asp:Label ID="LbObli0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Obligatorio") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ocupado" SortExpression="Ocupado">
                        <ItemTemplate>
                            <asp:Label ID="LbOcupa0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Ocupado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="dia_nohabil" HeaderText="Dia no Hábil" 
                        SortExpression="dia_nohabil" />
                    <asp:BoundField DataField="Notificar" HeaderText="Notificar" 
                        SortExpression="Notificar" />
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
            <asp:ObjectDataSource id="ObjTipos" runat="server" TypeName="PActividades" 
                SelectMethod="GetRecordsFil" 
                OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
                <UpdateParameters>
                    <asp:Parameter Name="Cod_Act_PK" Type="String" />
                    <asp:Parameter Name="Nom_Act_PK" Type="String" />
                    <asp:Parameter Name="Cod_Tpro_PK" Type="String" />
                    <asp:Parameter Name="Cod_Tact_PK" Type="String" />
                    <asp:Parameter Name="Cod_Act" Type="String" />
                    <asp:Parameter Name="Nom_Act" Type="String" />
                    <asp:Parameter Name="Cod_Tpro" Type="String" />
                    <asp:Parameter Name="vigencia" Type="String" />
                    <asp:Parameter Name="Cod_Tact" Type="String" />
                    <asp:Parameter Name="Orden" Type="Int32" />
                </UpdateParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="Chk_Vig" Name="fil1" PropertyName="Checked" 
                        Type="Boolean" />
                    <asp:ControlParameter ControlID="CboFilVig" Name="vigencia" 
                        PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="Chk_Tproc" Name="fil2" PropertyName="Checked" 
                        Type="Boolean" />
                    <asp:ControlParameter ControlID="CboFilTproc" Name="cod_tproc" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="Vigencias" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Vigencias"></asp:ObjectDataSource>
            <!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->
</contenttemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Gridview1" />
        </Triggers>
    </asp:UpdatePanel>&nbsp;
    <asp:UpdatePanel id="UpdatePanel2"
        runat="server" UpdateMode="Conditional"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; 
            <asp:Panel id="programmaticPopup2" runat="server" Width="560px" Height="600px" 
                CssClass="ModalPanel2" style="margin-left:40px;"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
                    <DIV style="padding: 5px; VERTICAL-ALIGN: middle; width: 548px;"><DIV style="FLOAT: left">
                            Actividades</DIV><DIV style="FLOAT: right">
                            <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>
                
                <div style="padding:20px;">
                &nbsp;<asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                <table>
                    <tr>
                        <td colspan="5">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ValidationGroup="Guardar" SkinID="ValidationSummary1" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 124px">
                            <asp:Label ID="Label12" runat="server" Text="Vigencia"></asp:Label>
                        </td>
                        <td style="width: 236px" colspan="3">
                            <asp:DropDownList ID="CboVig" runat="server" AutoPostBack="True" 
                                DataSourceID="Vigencias" DataTextField="year_vig" DataValueField="year_vig" 
                                Width="111px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 122px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 124px">
                            <asp:Label ID="Label11" runat="server" Text="Modalidad"></asp:Label>
                        </td>
                        <td colspan="3" style="width: 236px">
                            <asp:DropDownList ID="CboTproc" runat="server" DataSourceID="TipProc" 
                                DataTextField="Nom_TProc" DataValueField="Cod_TProc" Width="232px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="TipProc" runat="server" InsertMethod="Insert" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                TypeName="TiposProc" UpdateMethod="Update">
                                <UpdateParameters>
                                    <asp:Parameter Name="Cod_Tproc_O" Type="String" />
                                    <asp:Parameter Name="Cod_Tproc" Type="String" />
                                    <asp:Parameter Name="Nom_Tproc" Type="String" />
                                    <asp:Parameter Name="Abre_Tproc" Type="String" />
                                    <asp:Parameter Name="Esta_Tproc" Type="String" />
                                    <asp:Parameter Name="Cod_Ctr" Type="String" />
                                    <asp:Parameter Name="Ctr_F20_1A" Type="String" />
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Cod_Tproc" Type="String" />
                                    <asp:Parameter Name="Nom_Tproc" Type="String" />
                                    <asp:Parameter Name="Abre_Tproc" Type="String" />
                                    <asp:Parameter Name="Esta_Tproc" Type="String" />
                                    <asp:Parameter Name="Cod_Ctr" Type="String" />
                                    <asp:Parameter Name="Ctr_F20_1A" Type="String" />
                                </InsertParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td style="width: 122px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 124px">
                            <asp:Label ID="Label9" runat="server" Text="Codigo"></asp:Label>
                        </td>
                        <td colspan="3" style="width: 236px">
                            <asp:TextBox ID="TxtCodNew" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 122px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TxtCodNew" Display="None" 
                                ErrorMessage="Debe Digitar el Codigo" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 124px">
                            <asp:Label ID="Label10" runat="server" Text="Nombre"></asp:Label>
                        </td>
                        <td style="width: 236px" colspan="3">
                            <asp:TextBox ID="TxtNomNew" runat="server" Height="43px" TextMode="MultiLine" 
                                Width="100%" ></asp:TextBox>
                        </td>
                        <td style="width: 122px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtNomNew" ErrorMessage="Debe Digitar el Nombre" 
                                ValidationGroup="Guardar" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 124px">
                            <asp:Label ID="Label13" runat="server" Text="Estado del Proceso"></asp:Label>
                        </td>
                        <td style="width: 236px" colspan="3">
                            <asp:DropDownList ID="CboTact" runat="server" DataSourceID="TipAct" 
                                DataTextField="Nom_Est" DataValueField="Cod_Est" Width="232px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="TipAct" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                TypeName="PEstados"></asp:ObjectDataSource>
                        </td>
                        <td style="width: 122px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 124px">
                            Lugar y Caracteristica(predeterminado)</td>
                        <td colspan="3" style="width: 236px">
                            <asp:TextBox ID="TxtUbi" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                        <td style="width: 122px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 124px">
                            <asp:Label ID="Label14" runat="server" Text="Orden"></asp:Label>
                        </td>
                        <td style="width: 236px" colspan="3">
                            <asp:TextBox ID="TxtOrden" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            TargetControlID="TxtOrden" 
                            FilterType="Numbers" 
                            runat="server" 
                            ID="FilteredTextBoxExtender1">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td style="width: 122px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TxtOrden" ErrorMessage="Debe digitar el orden" 
                                ValidationGroup="Guardar" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 124px">
                            <asp:Label ID="Label16" runat="server" Text="Ocupado"></asp:Label>
                        </td>
                        <td style="width: 236px">
                            <asp:DropDownList ID="CboOcupado" runat="server">
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 236px">
                            &nbsp;</td>
                        <td style="width: 236px">
                            &nbsp;</td>
                        <td style="width: 122px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left; width: 124px;">
                            <asp:Label ID="Label17" runat="server" Text="Estado"></asp:Label>
                            </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="CboEstado" runat="server">
                                <asp:ListItem Value="AC">ACTIVO</asp:ListItem>
                                <asp:ListItem Value="IN">INACTIVO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            Mostrar Fecha Inicial</td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="CboMFI" runat="server">
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: center; width: 122px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left; width: 124px;">
                            <asp:Label ID="Label18" runat="server" Text="Obligatorio"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="CboObligatorio" runat="server">
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            Mostrar Hora Inicial</td>
                        <td style="text-align: left">
                        <asp:DropDownList ID="CboMHI" runat="server">
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;</td>
                        <td style="text-align: center; width: 122px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left; width: 124px;">
                            <asp:Label ID="Label19" runat="server" Text="Dia no hábil"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="Cbodia_nohabil" runat="server" 
                                ToolTip="Indica si es permitido un dia no hábil">
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem Selected="True">NO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            Mostrar Fecha Final</td>
                        <td style="text-align: left">
                        <asp:DropDownList ID="CboMFF" runat="server">
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;</td>
                        <td style="text-align: center; width: 122px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left; width: 124px;">
                            <asp:Label ID="Label20" runat="server" Text="Notificar"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="CboNotificar" runat="server" 
                                ToolTip="Indica que al finalizar la actividad se enviará una notificación">
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem Selected="True">NO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            Mostrar Hora Final</td>
                        <td style="text-align: left">
                        <asp:DropDownList ID="CboMHF" runat="server">
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;</td>
                        <td style="text-align: center; width: 122px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align: center">
                            <asp:Button ID="BtnGuardar" runat="server" onclick="BtnGuardar_Click" 
                                Text="Guardar" ValidationGroup="Guardar" />
                            &nbsp;<asp:Button ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" 
                                Text="Eliminar" />
                            &nbsp;
                            <input ID="BtnCancelar" type="button" value="Cancelar" />
                        </td>
                    </tr>
                </table>
                </div>
            </asp:Panel> 
</contenttemplate>
    </asp:UpdatePanel>
  <asp:UpdateProgress ID="UpdPrgAsig" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <ucProg:Progress ID="Progress1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
          <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
                <ucProg:Progress ID="Progress2" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

