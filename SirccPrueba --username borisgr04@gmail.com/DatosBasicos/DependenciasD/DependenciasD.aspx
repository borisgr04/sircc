<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="DependenciasD.aspx.vb" Inherits="DependenciasD_DependenciasD" %>

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

         function confirmSubmit(mycheckbox) {
             return  confirm("Desar Modificar el Manejo de Procesos");
        }
    </script>
<div class="demoarea">
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxtoolkit:toolkitscriptmanager>
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" 
        runat="server" UpdateMode="Conditional">
        <contenttemplate>
        
    <asp:Label id="Tit" runat="server" Width="388px" Text="CONFIGURACIÓN DE DEPENDENCIAS" 
                CssClass="Titulo"></asp:Label>
    <br />
    <asp:Label id="MsgResult" runat="server" SkinID="MsgResult" 
        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ></asp:Label>
    
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            
            <br />
            <asp:Label ID="Label1" runat="server" 
                Text="Buscar (Código, Nombre, Abreviatura,Encargado)"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TxtBuscar" runat="server" Height="21px" Width="371px"></asp:TextBox>
            <asp:DropDownList ID="CboClase" runat="server" Visible="False">
                <asp:ListItem Value="T">Seleccione Filtro por Tipo</asp:ListItem>
                <asp:ListItem Value="D">Con Delegacion para Contratar</asp:ListItem>
                <asp:ListItem Value="N">Sin Delegación para Contratar</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:ImageButton ID="ImageButton2" runat="server" SkinID="IBtnBuscar" />
            <br />
            <br />
            <br />
            <br />
            
            <asp:GridView ID="GridView1" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="COD_DEP" DataSourceID="Objdec" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                EnableModelValidation="True" Width="100%" ShowFooter="True">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="Cod_Dep" HeaderText="Código" 
                        SortExpression="Cod_Dep" />
                    <asp:TemplateField HeaderText="Nombre " SortExpression="Nom_Dep">
                        <FooterTemplate>
                        <asp:ImageButton id="lnkExportar" runat="server" Text="Exportar Datos a Excel" __designer:wfdid="w10" CausesValidation="False" CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32" Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton> 
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LbNom" runat="server" Text='<%# Bind("Nom_Dep") %>'>                                       &gt;</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Dep_Abr" HeaderText="Abreviatura" 
                        SortExpression="Dep_Abr" />
                    <asp:BoundField DataField="Dep_Del" HeaderText="Delegada" 
                        SortExpression="Dep_Del" />
                    <asp:BoundField DataField="ide_ter" HeaderText="Ide Encargado" 
                        SortExpression="ide_ter" />
                    <asp:BoundField DataField="nom_ter" HeaderText="Encargado" 
                        SortExpression="nom_ter" />                        
                    <asp:BoundField DataField="Norma_del" HeaderText="Norma Delegación" 
                        SortExpression="Norma_del" />
                    <asp:ButtonField ButtonType="Image" CommandName="nuevo" 
                        ImageUrl="~/images/mnProcesos/administrator-icon24.png" 
                        Text="Agregar Abogados" HeaderText="Vincular " >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" 
                        HeaderText="Consultar" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        
            
            <asp:GridView ID="GridView3" runat="server" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="COD_DEP" 
                EnableModelValidation="True" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="100%">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="Cod_Dep" HeaderText="Código" 
                        SortExpression="Cod_Dep" />
                    <asp:TemplateField HeaderText="Nombre " SortExpression="Nom_Dep">
                        <ItemTemplate>
                            <asp:Label ID="LbNom0" runat="server" Text='<%# Bind("Nom_Dep") %>'>                                       &gt;</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Dep_Abr" HeaderText="Abreviatura" 
                        SortExpression="Dep_Abr" />
                    <asp:BoundField DataField="ide_ter" HeaderText="Ide Encargado" 
                        SortExpression="ide_ter" />
                    <asp:BoundField DataField="nom_ter" HeaderText="Encargado" 
                        SortExpression="nom_ter" />
                    <asp:BoundField DataField="Norma_del" HeaderText="Norma Delegación" 
                        SortExpression="Norma_del" />
                </Columns>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />
        
            
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID_HDEP" DataSourceID="ObjFunDep" EnableModelValidation="True" 
                Width="95%">
                <Columns>
                    <asp:BoundField DataField="Ide_Ter" HeaderText="Identitificación" 
                        SortExpression="Ide_Ter" />
                    <asp:BoundField DataField="Nom_Ter" HeaderText="Apellidos y Nombre" 
                        SortExpression="Nom_Ter" />
                    <asp:BoundField DataField="fec_asignacion" HeaderText="Fecha Asignación" 
                        SortExpression="fec_asignacion" />
                    <asp:BoundField DataField="fec_retiro" HeaderText="Fecha Retiro" 
                        SortExpression="fec_retiro" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" 
                        SortExpression="Estado" />
                    <asp:BoundField DataField="Vinculado_Por" HeaderText="Usuario que lo Vinculo" 
                        SortExpression="Vinculado_Por" />
                    <asp:BoundField DataField="DesVinculado_Por" HeaderText="Usuario que lo Retira" 
                        SortExpression="DesVinculado_Por" />
                    <asp:TemplateField HeaderText="Maneja Procesos">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkAsig_proc" runat="server"  Enabled="false"    
                                Checked='<%# Util.SI_NO(Eval("Asig_Proc")) %>'  
                                />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Retirar" ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ID_HDEP") %>' 
                                CommandName="retirar" ImageUrl="~/images/Operaciones/Sign-Delete-icon.png" OnClick="Retirar_Vin" 
                                Text="Retirar" />
                            <ajaxToolkit:ConfirmButtonExtender ID="ImageButton1_ConfirmButtonExtender" 
                                runat="server" 
                                ConfirmText="Confirme que desea Retirar Usuario de la Dependencia." 
                                Enabled="True" TargetControlID="ImageButton1">
                            </ajaxToolkit:ConfirmButtonExtender>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" CommandName="editar" 
                        ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" 
                        HeaderText="Editar" />
                </Columns>
            </asp:GridView>
          
            <asp:ObjectDataSource ID="ObjFunDep" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetVinculados" TypeName="Dependencias" DeleteMethod="Delete">
                <DeleteParameters>
                    <asp:Parameter Name="cod_dep" Type="String" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="GridView1" Name="Cod_Dep" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
             
            </asp:ObjectDataSource>
            <br />
            
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table>
                <tbody>
                    <tr>
                        <td colspan="6">
                            <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                SkinID="ValidationSummary1" />
                        </td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                            Funcionario</td>
                        <td style="WIDTH: 100px">
                            <asp:TextBox ID="TxtIde" runat="server" AutoPostBack="True"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 24px">
                            <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="..." />
                        </td>
                        <td style="WIDTH: 100px">
                            <asp:TextBox ID="TxtNomTer" ReadOnly="true" runat="server" Height="18px" Width="168px"></asp:TextBox>
                        </td>
                        <td style="WIDTH: 100px">
                            <asp:CheckBox ID="ChkAsigProc" runat="server" Text="Maneja Procesos" 
                                Width="150px" />
                        </td>
                        <td style="WIDTH: 100px">
                            <asp:CheckBox ID="ChkCord" runat="server" Text="Revisa Procesos" />
                        </td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                        </td>
                        <td style="WIDTH: 100px" colspan="3">
                        </td>
                        <td style="WIDTH: 100px">
                            &nbsp;</td>
                        <td style="WIDTH: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="WIDTH: 98px">
                        </td>
                        <td style="WIDTH: 100px" colspan="3">
                        </td>
                        <td style="WIDTH: 100px">
                            &nbsp;</td>
                        <td style="WIDTH: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="TEXT-ALIGN: center">
                            <asp:Button ID="BtnAsignar" runat="server" 
                                Text="Guardar" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnCancelar" runat="server" CausesValidation="False" 
                                Text=" Volver " />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    </tr>
                </tbody>
            </TABLE>
            </asp:View>
    </asp:MultiView>
                    <br />

                    </contenttemplate>
        </asp:UpdatePanel>
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
                            Asignar Encargado</div>
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
                SelectMethod="GetRecords" 
                OldValuesParameterFormatString="original_{0}" 
        DeleteMethod="Delete" InsertMethod="AsignarAbogado">
                <DeleteParameters>
                    <asp:Parameter Name="cod_dep" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Cod_Dep" Type="String" />
                    <asp:Parameter Name="Ide_Ter" Type="String" />
                    <asp:Parameter Name="ASig_Proc" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtBuscar" Name="busc" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
</div>
</asp:Content>


