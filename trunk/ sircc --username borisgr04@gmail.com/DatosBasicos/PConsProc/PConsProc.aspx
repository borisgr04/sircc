<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PConsProc.aspx.vb" EnableEventValidation="false"  Inherits="DatosBasicos_PCons_Proc_Default" %>

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
<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" Text="Consecutivo de Procesos"></asp:Label><BR />
                <asp:Label id="MsgResult" runat="server" SkinID="MsgResult" ></asp:Label>&nbsp;&nbsp;&nbsp;
                <table style="width:100%;">
                <tr>
                    <td style="width: 72px">
                        <asp:Label ID="Label17" runat="server" CssClass="selectIndex" Text="Vigencia"></asp:Label>
                    </td>
                    <td style="width: 171px">
                        <asp:DropDownList ID="CboFilVig0" runat="server" AutoPostBack="True" 
                            DataSourceID="Vigencias0" DataTextField="year_vig" DataValueField="year_vig" 
                            Width="111px">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="Vigencias0" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                            TypeName="Vigencias"></asp:ObjectDataSource>
                    </td>
                    <td style="width: 121px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 72px">
                        &nbsp;</td>
                    <td style="width: 171px">
                        &nbsp;</td>
                    <td style="width: 121px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:GridView 
                id="GridView1" runat="server" Width="753px" ForeColor="#333333" 
                AllowSorting="True" OnRowDataBound="GridView1_RowDataBound1" 
                DataSourceID="ObjTipos" GridLines="None" CellPadding="4" ShowFooter="True" 
                OnRowCommand="GridView1_RowCommand" DataKeyNames="Vigencia,Dep_Del,Tip_Proc" 
                AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Vigencia" SortExpression="Vigencia"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w10" CausesValidation="False" CommandName="Nuevo"></asp:LinkButton> 
</FooterTemplate>

<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("Vigencia") %>' __designer:wfdid="w9"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Dependencia" SortExpression="Dep_Del">
    <FooterTemplate>
        <asp:ImageButton ID="lnkExportar" runat="server" __designer:wfdid="w10" 
            CausesValidation="False" CommandName="Exportar" Height="32" 
            ImageUrl="~/images/Operaciones/excel.png" Text="Exportar Datos a Excel" 
            ToolTip="Exportar Datos a Excel" Width="32" />
    </FooterTemplate>
    <ItemTemplate>
<asp:Label id="Lbcimp" runat="server" Text='<%# Bind("Dep_Del") %>' __designer:wfdid="w21"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Nombre de la Dependencia" SortExpression="Nom_Dep"><ItemTemplate>
<asp:Label id="LbEst" runat="server" Text='<%# Bind("Nom_Dep") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Abreviatura Dependencia" SortExpression="Dep_Abr"><ItemTemplate>
<asp:Label id="LbEst3" runat="server" Text='<%# Bind("Dep_Abr") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Tipo de Proceso" SortExpression="Tip_Proc">
    <ItemTemplate>
<asp:Label id="LbVig" runat="server" Text='<%# Bind("Tip_Proc") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Nombre del Tipo de Proceso" SortExpression="Nom_TProc">
    <ItemTemplate>
<asp:Label id="LbNomTact" runat="server" Text='<%# Bind("Nom_TProc") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Abreviatura Tipo de Proceso" SortExpression="abre_tproc"><ItemTemplate>
<asp:Label id="LbEst2" runat="server" Text='<%# Bind("abre_tproc") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
 <asp:TemplateField HeaderText="Valor Inicial" SortExpression="Inicial">
    <ItemTemplate>
<asp:Label id="LbOrden" runat="server" Text='<%# Bind("Inicial") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Valor Siguiente" SortExpression="Siguiente">
    <ItemTemplate>
<asp:Label id="LbSig" runat="server" Text='<%# Bind("Siguiente") %>' __designer:wfdid="w22"></asp:Label> 
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
                AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="Vigencia,Dep_Del,Tip_Proc" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="753px">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Vigencia" SortExpression="Vigencia">
                        <ItemTemplate>
                            <asp:Label ID="LbCod0" runat="server" __designer:wfdid="w9" 
                                Text='<%# Bind("Vigencia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dependencia" SortExpression="Dep_Del">
                        <ItemTemplate>
                            <asp:Label ID="Lbcimp0" runat="server" __designer:wfdid="w21" 
                                Text='<%# Bind("Dep_Del") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre de la Dependencia" 
                        SortExpression="Nom_Dep">
                        <ItemTemplate>
                            <asp:Label ID="LbEst4" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Nom_Dep") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Abreviatura Dependencia" 
                        SortExpression="Dep_Abr">
                        <ItemTemplate>
                            <asp:Label ID="LbEst5" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Dep_Abr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo de Proceso" SortExpression="Tip_Proc">
                        <ItemTemplate>
                            <asp:Label ID="LbVig0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Tip_Proc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre del Tipo de Proceso" 
                        SortExpression="Nom_TProc">
                        <ItemTemplate>
                            <asp:Label ID="LbNomTact0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Nom_TProc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Abreviatura Tipo de Proceso" 
                        SortExpression="abre_tproc">
                        <ItemTemplate>
                            <asp:Label ID="LbEst6" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("abre_tproc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Inicial" SortExpression="Inicial">
                        <ItemTemplate>
                            <asp:Label ID="LbOrden0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Inicial") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Siguiente" SortExpression="Siguiente">
                        <ItemTemplate>
                            <asp:Label ID="LbSig0" runat="server" __designer:wfdid="w22" 
                                Text='<%# Bind("Siguiente") %>'></asp:Label>
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
            <asp:ObjectDataSource id="ObjTipos" runat="server" TypeName="Cons_Proc" 
                SelectMethod="GetRecordsFill" 
                OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
                <UpdateParameters>
                    <asp:Parameter Name="Vigencia_PK" Type="String" />
                    <asp:Parameter Name="Dep_Del_PK" Type="String" />
                    <asp:Parameter Name="Cod_Tpro_PK" Type="String" />
                    <asp:Parameter Name="Vigencia" Type="String" />
                    <asp:Parameter Name="Dep_Del" Type="String" />
                    <asp:Parameter Name="Cod_Tpro" Type="String" />
                    <asp:Parameter Name="Inicial" Type="Int32" />
                    <asp:Parameter Name="Siguiente" Type="Int32" />
                </UpdateParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="CboFilVig0" DefaultValue="2011" 
                        Name="vigencia" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
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
            <asp:Panel id="programmaticPopup2" runat="server" Width="413px" Height="319px" 
                CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
                    <DIV style="padding: 5px; VERTICAL-ALIGN: middle; width: 401px;"><DIV style="FLOAT: left">
                            Consecutivos de Procesos</DIV><DIV style="FLOAT: right">
                            <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>
                &nbsp;<asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                <table style="width:100%;">
                    <tr>
                        <td colspan="3">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ValidationGroup="Guardar" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 95px">
                            <asp:Label ID="Label9" runat="server" Text="Vigencia"></asp:Label>
                        </td>
                        <td style="width: 236px">
                            <asp:DropDownList ID="CboFilVig" runat="server" 
                                DataSourceID="Vigencias" DataTextField="year_vig" DataValueField="year_vig" 
                                Width="111px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="Vigencias" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                TypeName="Vigencias"></asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 95px">
                            <asp:Label ID="Label11" runat="server" Text="Dependencia"></asp:Label>
                        </td>
                        <td style="width: 236px">
                            <asp:DropDownList ID="CboTproc" runat="server" DataSourceID="Dependencia" 
                                DataTextField="Nom_Dep" DataValueField="Cod_Dep" Width="232px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="Dependencia" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelegadas" 
                                TypeName="Dependencias" DeleteMethod="Delete" 
                                InsertMethod="AsignarAbogado" UpdateMethod="DAsignarAbogado">
                                <DeleteParameters>
                                    <asp:Parameter Name="cod_dep" Type="String" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Cod_Dep" Type="String" />
                                    <asp:Parameter Name="Ide_Ter" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ID_HDEP" Type="String" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 95px">
                            <asp:Label ID="Label13" runat="server" Text="Tipo de Proceso"></asp:Label>
                        </td>
                        <td style="width: 236px">
                            <asp:DropDownList ID="CboTact" runat="server" DataSourceID="TipProc" 
                                DataTextField="Nom_TProc" DataValueField="Cod_TProc" Width="232px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="TipProc" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                                TypeName="TiposProc" InsertMethod="Insert" UpdateMethod="Update">
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
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 95px">
                            <asp:Label ID="Label14" runat="server" Text="Valor Inicial"></asp:Label>
                        </td>
                        <td style="width: 236px">
                            <asp:TextBox ID="TxtValIni" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender 
                            TargetControlID="TxtValIni" 
                            FilterType="Numbers" 
                            runat="server" 
                            ID="FilteredTextBoxExtender1">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TxtValIni" Display="None" 
                                ErrorMessage="Debe digitar el Valor Inicial" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 95px">
                            <asp:Label ID="Label16" runat="server" Text="Valor Siguiente"></asp:Label>
                        </td>
                        <td style="width: 236px">
                            <asp:TextBox ID="TxtValSig" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="TxtValSig_FilteredTextBoxExtender" 
                                runat="server" FilterType="Numbers" TargetControlID="TxtValSig">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtValSig" Display="None" 
                                ErrorMessage="digitar el valor siguiente" 
                                ValidationGroup="Dim curObj As ScriptManager = ScriptManager.GetCurrent(Page)"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <asp:Button ID="BtnGuardar" runat="server" onclick="BtnGuardar_Click" 
                                Text="Guardar" ValidationGroup="Guardar" />
                            &nbsp;<asp:Button ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" 
                                Text="Eliminar" />
                            &nbsp;
                            <input ID="BtnCancelar" type="button" value="Cancelar" /> 
                            </td>
                    </tr>
                </table>
            </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>

    </asp:Content>

