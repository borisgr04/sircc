<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NroConVig.aspx.vb" Inherits="DatosBasicos_NroConVig_Default" %>

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
&nbsp;<asp:Label id="Tit" runat="server" Width="376px" CssClass="Titulo" 
                Text="Vigencias"></asp:Label><BR /><asp:Label id="MsgResult" 
                runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:GridView 
                ID="GridView1" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Year_Vig,Cod_Tip" 
                DataSourceID="ObjTipos" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="688px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Vigencia">
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkNuevo" runat="server" __designer:wfdid="w10" 
                                CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LbCod" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Year_Vig") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo" SortExpression="Nom_Tip"><FooterTemplate>
                    <asp:ImageButton id="lnkExportar" runat="server" Text="Exportar Datos a Excel" __designer:wfdid="w10" CausesValidation="False" CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32" Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton> 
                    </FooterTemplate><ItemTemplate>
                    <asp:Label id="Lbcimp" runat="server" Text='<%# Bind("Nom_Tip") %>' __designer:wfdid="w21"></asp:Label> 
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nro_Ini_Con" 
                        HeaderText="Numero Inicial" />
                    <asp:BoundField DataField="Nro_Act_Con" 
                        HeaderText="Numero Actual" />
                    <asp:BoundField DataField="Por_Adi_Vig" DataFormatString="{0:p}" 
                        HeaderText="Porcentaje de Adición" />
                    <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                        ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                    <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                        ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Nuevo">Nuevo Registro</asp:LinkButton>
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Year_Vig,Cod_Tip" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="688px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Vigencia">
                        <ItemTemplate>
                            <asp:Label ID="LbCod0" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Year_Vig") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo" SortExpression="Nom_Tip">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp0" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Nom_Tip") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nro_Ini_Con" HeaderText="Numero Inicial" />
                    <asp:BoundField DataField="Nro_Act_Con" HeaderText="Numero Actual" />
                    <asp:BoundField DataField="Por_Adi_Vig" DataFormatString="{0:p}" 
                        HeaderText="Porcentaje de Adición" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Nuevo">Nuevo 
                    Registro</asp:LinkButton>
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />
            <asp:ObjectDataSource id="ObjTipos" runat="server" TypeName="NroCon" 
                SelectMethod="GetRecordsDB" 
                OldValuesParameterFormatString="original_{0}">
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
            <asp:Panel id="programmaticPopup2" runat="server" Width="413px" Height="407px" 
                CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
                    <DIV style="padding: 5px; VERTICAL-ALIGN: middle; width: 400px;"><DIV style="FLOAT: left">
                            Vigencias</DIV><DIV style="FLOAT: right">
                            <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE 
                    align="center"><TBODY>
        <TR><TD colSpan=3>
            <asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR>
        <TR><TD colSpan=3>
            <asp:ValidationSummary id="ValidationSummary1" runat="server" 
                SkinID="ValidationSummary1" ValidationGroup="Guardar">
                    </asp:ValidationSummary></TD></TR>
        <TR><TD style="WIDTH: 166px">
                <asp:Label ID="Label4" runat="server" __designer:wfdid="w19" Text="Vigencia" 
                        Width="143px"></asp:Label></TD>
            <TD style="WIDTH: 100px"><asp:TextBox ID="TxtCodNew" runat="server" style="text-transform :uppercase"></asp:TextBox></TD>
            <TD style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtCodNew" ErrorMessage="Digite  Codigo " 
                    ValidationGroup="Guardar">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 166px; HEIGHT: 23px">
                <asp:Label id="Label6" runat="server" Text="Tipo de Contrato"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                    <asp:DropDownList ID="CboTip" runat="server" DataSourceID="ObjCTipos" 
                        DataTextField="Nom_Tip" DataValueField="Cod_Tip" Width="106px">
                        <asp:ListItem Value="ABIERTA">ABIERTA</asp:ListItem>
                        <asp:ListItem Value="CERRADA">CERRADA</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjCTipos" runat="server" InsertMethod="Insert" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                        TypeName="Tipos" UpdateMethod="Update">
                        <InsertParameters>
                            <asp:Parameter Name="Cod_Tip" Type="String" />
                            <asp:Parameter Name="Nom_Tip" Type="String" />
                            <asp:Parameter Name="Est_Tip" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Cod_Tip_O" Type="String" />
                            <asp:Parameter Name="Cod_Tip" Type="String" />
                            <asp:Parameter Name="Nom_Tip" Type="String" />
                            <asp:Parameter Name="Est_Tip" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    </TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                    &nbsp;</TD></TR>
        <TR><TD style="WIDTH: 166px; HEIGHT: 18px">
                    <asp:Label ID="Label1" runat="server" Text="Número Inicial" Width="126px"></asp:Label>
                    </TD><TD style="WIDTH: 100px; HEIGHT: 18px">
                <asp:TextBox ID="TxtNumI" runat="server" Width="107px"></asp:TextBox>
                    </TD><TD style="WIDTH: 100px; HEIGHT: 18px">
                        
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TxtNumI" 
                        ErrorMessage="Seleccione la Fecha de Finalización de la Vigencia" 
                        ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </TD></TR>
        <TR><TD style="WIDTH: 166px; HEIGHT: 19px">
                <asp:Label ID="Label5" runat="server" Text="Número Actual"></asp:Label>
            </TD><TD style="WIDTH: 100px; HEIGHT: 19px">
                        <asp:TextBox ID="TxtNumAct" runat="server" Width="107px"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 100px; HEIGHT: 19px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TxtNumAct" 
                        ErrorMessage="Seleccione la Fcha de Inicio de la Vigencia" 
                        ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </TD></TR>
        <TR><TD style="WIDTH: 166px">
                <asp:Label ID="Label7" runat="server" Text="Porcentaje de Adiciones"></asp:Label>
            </TD>
            <TD style="WIDTH: 100px">
                <telerik:RadNumericTextBox ID="TxtPor" Runat="server" 
                    Culture="es-CO" DataType="System.Decimal" Type="Percent" Width="125px">
                </telerik:RadNumericTextBox>
            </TD>
            <TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="WIDTH: 166px">
                <asp:Label ID="Label8" runat="server" Text="Radicacion Automatica" 
                    Visible="False"></asp:Label>
            </TD>
            <TD style="WIDTH: 100px">
                <asp:DropDownList ID="CboRadAut" runat="server" Width="106px" Visible="False">
                    <asp:ListItem Value="1">SI</asp:ListItem>
                    <asp:ListItem Value="0">NO</asp:ListItem>
                </asp:DropDownList>
            </TD><TD style="WIDTH: 100px"></TD></TR>
        <TR>
            <TD style="WIDTH: 166px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" 
                onclick="BtnGuardar_Click" runat="server" Text="Guardar" 
                ValidationGroup="Guardar"></asp:Button>
            &nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar">
                    </asp:Button>  <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp;</asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>

    &nbsp;&nbsp;&nbsp;&nbsp;</asp:Content>

