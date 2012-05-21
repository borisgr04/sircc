<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Dependencias.aspx.vb" Inherits="Dependencias_Dependencias" %>

<%@ Register src="../../CtrlUsr/Terceros/ConsultaTer.ascx" tagname="consultater" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <script type='text/javascript'>
// Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrarT"), 'click', CerrarModalTercero);
        }

        function CerrarModalTercero(ev) {
            ev.preventDefault();
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior');
            modalPopupBehavior2.hide();
        }
        function MostrarTerceros() {
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }
     
      function enviar(ced,rsocial,tip_ter)
         {
         document.aspnetForm.<%=Me.TxtIde.ClientID%>.value=ced;
         document.aspnetForm.<%=Me.TxtNomTer.ClientID%>.value=rsocial;
         __doPostBack("<%= button1.ClientID %>","");
         }
   

    </script>
<div class="demoarea">
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxtoolkit:toolkitscriptmanager>
    <br />
    <asp:Label id="Tit" runat="server" Width="388px" Text="CONFIGURACIÓN DE DEPENDENCIAS" 
                CssClass="Titulo"></asp:Label>
    <br />
    <asp:Label id="MsgResult" runat="server" skinid="MsgResult"   ></asp:Label>
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            
            <asp:GridView ID="GridView1" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="COD_DEP" DataSourceID="Objdec" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Código " SortExpression="COD_DEP">
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="False" 
                                CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LbCod" runat="server" Text='<%# Bind("COD_DEP") %>'>                                       &gt;</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre " SortExpression="Nom_Dep">
                        <FooterTemplate>
                        <asp:ImageButton id="lnkExportar" runat="server" Text="Exportar Datos a Excel" __designer:wfdid="w10" CausesValidation="False" CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32" Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton> 
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LbNom" runat="server" Text='<%# Bind("Nom_Dep") %>'>                                       &gt;</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Dep_Del" HeaderText="Delegada" 
                        SortExpression="Dep_Del" />
                    <asp:BoundField DataField="Dep_Abr" HeaderText="Abreviatura" 
                        SortExpression="Dep_Abr" />
                    <asp:BoundField DataField="ide_ter" HeaderText="Ide Encargado" 
                        SortExpression="ide_ter" />
                    <asp:BoundField DataField="nom_ter" HeaderText="Encargado" 
                        SortExpression="nom_ter" />                        
                    <asp:BoundField DataField="Norma_del" HeaderText="Norma Delegación" 
                        SortExpression="Norma_del" />
                        <asp:BoundField DataField="Email" HeaderText="Correo Electronico" 
                        SortExpression="Email" />
                    <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                    <ItemTemplate>
                            <asp:Label ID="LbEst" runat="server" Text='<%# Bind("Estado") %>'>                                       &gt;</asp:Label>
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
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Nuevo">Nuevo Registro</asp:LinkButton>
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            
            <br />
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="COD_DEP" 
                EnableModelValidation="True" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Código " SortExpression="COD_DEP">
                        <ItemTemplate>
                            <asp:Label ID="LbCod0" runat="server" Text='<%# Bind("COD_DEP") %>'>                                       &gt;</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre " SortExpression="Nom_Dep">
                        <ItemTemplate>
                            <asp:Label ID="LbNom0" runat="server" Text='<%# Bind("Nom_Dep") %>'>                                       &gt;</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Dep_Del" HeaderText="Delegada" 
                        SortExpression="Dep_Del" />
                    <asp:BoundField DataField="Dep_Abr" HeaderText="Abreviatura" 
                        SortExpression="Dep_Abr" />
                    <asp:BoundField DataField="ide_ter" HeaderText="Ide Encargado" 
                        SortExpression="ide_ter" />
                    <asp:BoundField DataField="nom_ter" HeaderText="Encargado" 
                        SortExpression="nom_ter" />
                    <asp:BoundField DataField="Norma_del" HeaderText="Norma Delegación" 
                        SortExpression="Norma_del" />
                    <asp:BoundField DataField="Email" HeaderText="Correo Electronico" 
                        SortExpression="Email" />
                    <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                        <ItemTemplate>
                            <asp:Label ID="LbEst0" runat="server" Text='<%# Bind("Estado") %>'>                                       &gt;</asp:Label>
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
            
        </asp:View>
        <asp:View ID="View2" runat="server">
            <TABLE>
                <tbody>
                    <tr>
                        <td colspan="5">
                            <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                            Código
                        </td>
                        <td style="WIDTH: 100px" colspan="3">
                            <asp:TextBox ID="TxtCod" runat="server"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 100px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TxtCod" ErrorMessage="Digite un Código" 
                                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                            <asp:Label ID="Label5" runat="server" __designer:wfdid="w25" Text="Nombre "></asp:Label>
                        </td>
                        <td style="WIDTH: 100px" colspan="3">
                            <asp:TextBox ID="TxtNom" runat="server" Width="266px"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 100px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtNom" ErrorMessage="Digite un Nombre " 
                                ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                            <asp:Label ID="Label1" runat="server" Text="Delegada"></asp:Label>
                        </td>
                        <td style="WIDTH: 100px" colspan="3">
                            <asp:DropDownList ID="CboDel" runat="server">
                                <asp:ListItem Selected="True" Value="N">NO</asp:ListItem>
                                <asp:ListItem Value="S">SI</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="WIDTH: 100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                            <asp:Label ID="Label2" runat="server" __designer:wfdid="w25" Text="Abreviatura"></asp:Label>
                        </td>
                        <td style="WIDTH: 100px" colspan="3">
                            <asp:TextBox ID="TxtAbr" runat="server" __designer:wfdid="w44"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                            Encargado</td>
                        <td style="WIDTH: 100px">
                            <asp:TextBox ID="TxtIde" runat="server"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 24px">
                            <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="..." />
                        </td>
                        <td style="WIDTH: 100px">
                            <asp:TextBox ID="TxtNomTer" ReadOnly="true" runat="server" Height="18px" Width="168px"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px; HEIGHT: 23px" valign="top">
                            Norma</td>
                        <td style="WIDTH: 100px; HEIGHT: 23px" colspan="3">
                            <asp:TextBox ID="TxtNorma" runat="server" Height="67px" TextMode="MultiLine" 
                                Width="250px"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 100px; HEIGHT: 23px">
                        </td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                            E-Mail</td>
                        <td style="WIDTH: 100px" colspan="3">
                            <asp:TextBox ID="TxtEmail" runat="server" Width="266px"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 100px">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="TxtEmail" ErrorMessage="Debe ingresar un e-mail válido" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ValidationGroup="Guardar" Display="None"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                            Estado</td>
                        <td style="WIDTH: 100px" colspan="3">
                            <asp:DropDownList ID="CboEst" runat="server">
                                <asp:ListItem Value="AC">ACTIVO</asp:ListItem>
                                <asp:ListItem Value="IN">INACTIVO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="WIDTH: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="TEXT-ALIGN: center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5" style="TEXT-ALIGN: center">
                            <asp:Button ID="BtnGuardar" runat="server" onclick="BtnGuardar_Click" 
                                Text="Guardar" ValidationGroup="Guardar" />
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" 
                                Text="Eliminar" />
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="BtnCancelar" runat="server" CausesValidation="False" 
                                Text="Volver" />
                            &nbsp;&nbsp;</td>
                    </tr>
                </tbody>
            </TABLE>
            </asp:View>
    </asp:MultiView>
                    <br />
    <asp:UpdatePanel ID="UpdatePanel4" 
        runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida-->
            <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" 
                style="DISPLAY: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" 
                BackgroundCssClass="modalBackground" 
                BehaviorID="programmaticModalPopupBehavior" DropShadow="True" 
                PopupControlID="programmaticPopup" 
                PopupDragHandleControlID="programmaticPopupDragHandle" 
                RepositionMode="RepositionOnWindowScroll" 
                TargetControlID="hiddenTargetControlForModalPopup">
            </ajaxToolkit:ModalPopupExtender>
            &nbsp;
            <asp:Panel ID="programmaticPopup" runat="server" CssClass="ModalPanel2" 
                Height="229%" Width="625px">
                <asp:Panel ID="programmaticPopupDragHandle" runat="Server" 
                    CssClass="BarTitleModal2" Height="30px">
                    <div style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
                        <div style="FLOAT: left">
                            Asignar Encargad</div>
                        <div style="FLOAT: right">
                            <input id="BtnCerrarT" type="button" value="X" />
&nbsp;</div>
                        o</div>
                </asp:Panel>
                &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
                &nbsp; &nbsp; &nbsp;&nbsp;
                <uc1:ConsultaTer ID="ConsultaTer" runat="server" Ret="AR" Tipo="AR" />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Button" style="visibility:hidden" />
                <br />
                <br />
            </asp:Panel>
        </contenttemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
                    <br />
    <asp:ObjectDataSource id="Objdec" runat="server" TypeName="Dependencias" 
                SelectMethod="GetRecordsDB" InsertMethod="Insert" 
                OldValuesParameterFormatString="original_{0}">
                <InsertParameters>
                    <asp:Parameter Name="cod_dep" Type="String" />
                    <asp:Parameter Name="nom_dep" Type="String" />
                    <asp:Parameter Name="dep_del" Type="String" />
                    <asp:Parameter Name="dep_abr" Type="String" />
                </InsertParameters>
            </asp:ObjectDataSource>
</div>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="Loading">
            <asp:Image SkinID="ImgProgress" runat="server" ID="ImgAjax"/> Cargando …
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
</asp:Content>


