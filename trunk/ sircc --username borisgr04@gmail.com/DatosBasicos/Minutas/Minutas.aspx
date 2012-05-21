<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Minutas.aspx.vb" Inherits="DatosBasicos_Minutas_Minutas" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="HTMLEditor" %>

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
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxtoolkit:toolkitscriptmanager>
    &nbsp; &nbsp;&nbsp; &nbsp;
    <br />
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" Text="CONFIGURACIÓN DE MINUTAS" 
                CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" 
        runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="GridView1" runat="server" __designer:wfdid="w2" 
                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                        CellPadding="4" DataKeyNames="CMIN_CODI" DataSourceID="ObjTabla" 
                        EmptyDataText="No se encontraron Registros en la Base de Datos" 
                        ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" 
                        OnRowDataBound="GridView1_RowDataBound1" 
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="20" 
                        ShowFooter="True" Width="626px">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="Codigo " SortExpression="CORR_CODI">
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkNuevo" runat="server" __designer:wfdid="w3" 
                                        CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LbCodi" runat="server" __designer:wfdid="w19" 
                                        Text='<%# Bind("CMIN_CODI") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre " SortExpression="CORR_NOMB">
                                <ItemTemplate>
                                    <asp:Label ID="Lbnomb" runat="server" __designer:wfdid="w4" 
                                        Text='<%# Bind("CMIN_NOMB") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Campos de la Vista" SortExpression="CORR_CAMP">
                                <ItemTemplate>
                                    <asp:Label ID="Lbcamp" runat="server" __designer:wfdid="w20" 
                                        Text='<%# Bind("CMIN_CAMP") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre de la Vista" SortExpression="CORR_VISTA">
                                <ItemTemplate>
                                    <asp:Label ID="Lbvista" runat="server" __designer:wfdid="w21" 
                                        Text='<%# Bind("CMIN_VISTA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                                ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                            <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                                ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                            <asp:ButtonField CommandName="Plantilla" Text="Plantilla" />
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
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <contenttemplate>
                            <!-- Mensaje de Salida-->
                            <br />
                            <asp:Button ID="hiddenTargetControlForModalPopup2" runat="server" 
                                style="DISPLAY: none" />
                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupTer" runat="server" 
                                BackgroundCssClass="modalBackground" 
                                BehaviorID="programmaticModalPopupBehavior2" DropShadow="True" 
                                PopupControlID="programmaticPopup2" 
                                PopupDragHandleControlID="programmaticPopupDragHandle2" 
                                RepositionMode="RepositionOnWindowScroll" 
                                TargetControlID="hiddenTargetControlForModalPopup2">
                            </ajaxToolkit:ModalPopupExtender>
                            &nbsp;&nbsp;
                            <asp:Panel ID="programmaticPopup2" runat="server" CssClass="ModalPanel2" 
                                Height="580px" Width="709px">
                                <asp:Panel ID="programmaticPopupDragHandle2" runat="Server" 
                                    CssClass="BarTitleModal2" Height="30px" Width="697px">
                                    <div style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
                                        <div style="FLOAT: left">
                                            Correos</div>
                                        <div style="FLOAT: right">
                                            <input ID="BtnCerrar" type="button" value="X" />
                                        </div>
                                    </div>
                                </asp:Panel>
                                &nbsp;<TABLE>
                                    <tbody>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 98px">
                                                Codigo del Correo</td>
                                            <td style="WIDTH: 100px">
                                                <asp:TextBox ID="TxtcodiNew" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="WIDTH: 457px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                    ControlToValidate="TxtcodiNew" ErrorMessage="Digite  Codigo de Correo">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 98px; HEIGHT: 23px">
                                                <asp:Label ID="Label1" runat="server" Text="Nombre del Correo" Width="126px"></asp:Label>
                                            </td>
                                            <td style="WIDTH: 100px; HEIGHT: 23px">
                                                <asp:TextBox ID="txtnombNew" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="WIDTH: 457px; HEIGHT: 23px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                    ControlToValidate="txtnombNew" ErrorMessage="Digite  Nombre del Correo">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 98px; HEIGHT: 18px">
                                                <asp:Label ID="Label2" runat="server" Text="Nombre del Modulo" Width="117px"></asp:Label>
                                            </td>
                                            <td style="WIDTH: 100px; HEIGHT: 18px">
                                                <asp:TextBox ID="txtdatoNew" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="WIDTH: 457px; HEIGHT: 18px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                    ControlToValidate="txtdatoNew" ErrorMessage="Digite Nombre del Modulo">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 98px; HEIGHT: 18px">
                                                <asp:Label ID="Label3" runat="server" Text="Cuerpo de la Minuta"></asp:Label>
                                            </td>
                                            <td style="WIDTH: 100px; HEIGHT: 18px">
                                                &nbsp;</td>
                                            <td style="WIDTH: 457px; HEIGHT: 18px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="HEIGHT: 19px" valign="top">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 98px; HEIGHT: 19px">
                                                <asp:Label ID="Label4" runat="server" __designer:wfdid="w13" 
                                                    Text="Campos de la Vista"></asp:Label>
                                            </td>
                                            <td style="WIDTH: 100px; HEIGHT: 19px">
                                                <asp:TextBox ID="txtcampNew" runat="server" __designer:wfdid="w14"></asp:TextBox>
                                            </td>
                                            <td style="WIDTH: 457px; HEIGHT: 19px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                    __designer:wfdid="w17" ControlToValidate="txtcampNew" 
                                                    ErrorMessage="Digite el Campo de la Vista">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 98px; HEIGHT: 19px">
                                                <asp:Label ID="Label5" runat="server" __designer:wfdid="w13" 
                                                    Text="Nombre de la Vista"></asp:Label>
                                            </td>
                                            <td style="WIDTH: 100px; HEIGHT: 19px">
                                                <asp:TextBox ID="txtvistaNew" runat="server" __designer:wfdid="w16"></asp:TextBox>
                                            </td>
                                            <td style="WIDTH: 457px; HEIGHT: 19px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                    __designer:wfdid="w18" ControlToValidate="txtvistaNew" 
                                                    ErrorMessage="Digite el Nombre de la Vista">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 98px; HEIGHT: 19px">
                                            </td>
                                            <td style="WIDTH: 100px; HEIGHT: 19px">
                                                &nbsp;</td>
                                            <td style="WIDTH: 457px; HEIGHT: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="WIDTH: 98px">
                                            </td>
                                            <td style="WIDTH: 100px">
                                            </td>
                                            <td style="WIDTH: 457px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="TEXT-ALIGN: center">
                                                <asp:Button ID="BtnGuardar" runat="server" onclick="BtnGuardar_Click" 
                                                    Text="Guardar" />
                                                &nbsp;<asp:Button ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" 
                                                    Text="Eliminar" />
                                                &nbsp;
                                                <input ID="BtnCancelar" type="button" value="Cancelar" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </TABLE>
                                &nbsp;
                            </asp:Panel>
                            &nbsp;&nbsp;
                        </contenttemplate>
                    </asp:UpdatePanel>
                </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <table>
                        <tr>
                        <td rowspan="3" style="width: 798px">
                        <HTMLEditor:Editor ID="Editor1" runat="server" AutoFocus="true" Height="700px" 
                            Width="95%" />
                            d
                            </td>
                            <td style="height: 30px">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>Procesos</asp:ListItem>
                                    <asp:ListItem>Terceros</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            </tr>
                            <tr>
                            <td>&nbsp;
                            
                                <br />
                                <ul>
                                <li><a onclick ="window.clipboardData.setData('Text', '{CONTRATISTA}');alert('Pegue el campo'); " >CONTRATISTA</a></li>
                                <li><a onclick ="window.clipboardData.setData('Text', '{IDE_CONTRATISTA}');alert('Pegue el campo'); " >IDE_CONTRATISTA</a></li>
                                <li><a onclick ="window.clipboardData.setData('Text', '{OBJETO_CONTRATO}');alert('Pegue el campo'); " >OBJETO</a></li>
                                <li><a onclick ="window.clipboardData.setData('Text', '{DEPENDENCIA_NEC}');alert('Pegue el campo'); " >DEPENDENCIA_NEC</a></li>
                                <li><a onclick ="window.clipboardData.setData('Text', '{OBLIGACIONES}');alert('Pegue el campo'); " >OBLIGACIONES</a></li>
                                </ul>
                            </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:Button ID="BtnGuardarM" runat="server" Text="Guardar" />
                        <asp:Button ID="BtnCan" runat="server" Text="Cancelar" />
                    </asp:View>
            </asp:MultiView>
&nbsp;&nbsp;<asp:ObjectDataSource id="ObjTabla" runat="server" TypeName="CMinutas" 
                SelectMethod="GetRecords" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp;&nbsp;<asp:HiddenField id="hOper" runat="server"></asp:HiddenField>
            &nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;<BR />
    
    &nbsp;&nbsp;&nbsp;&nbsp;<br />

    </div>
</asp:Content>


