<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Proyectos.aspx.vb" EnableEventValidation="false" Inherits="DatosBasicos_Proyectos_Default" %>

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
    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>--%>
&nbsp;
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
        <div >
            <asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" 
                Text="Proyectos"></asp:Label><BR /><asp:Label id="MsgResult" runat="server" 
                SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
            <asp:Label ID="Label11" runat="server" Text="Vigencia"></asp:Label>
            <asp:DropDownList ID="CmbVig" runat="server" DataSourceID="odsVigencias" DataTextField="YEAR_VIG" 
                    DataValueField="YEAR_VIG">
                    </asp:DropDownList>
            <asp:Label ID="Label12" runat="server" Text="Nombre/Número"></asp:Label>
            <asp:TextBox ID="TxtBuscar" runat="server" Width="387px"></asp:TextBox>
            <asp:Button ID="BtnBuscar" runat="server" ValidationGroup="NoValidar"
                Text="Buscar" />
                </div>
                <br />
            <asp:GridView ID="GridView1" runat="server" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="Proyecto" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound1" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                Width="782px" AllowPaging="True">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Vigencia" SortExpression="Vigencia"><FooterTemplate><asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="False" 
                                CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton></FooterTemplate><ItemTemplate><asp:Label ID="LbCod" runat="server" Text='<%# Bind("Vigencia") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Proyecto" SortExpression="Proyecto"><FooterTemplate>
                    <%--<asp:ImageButton ID="lnkExportar" runat="server" CausesValidation="False" 
                                CommandName="Exportar" Height="32" ImageUrl="~/images/Operaciones/excel.png" 
                                Text="Exportar Datos a Excel" ToolTip="Exportar Datos a Excel" Width="32" />--%>
                                </FooterTemplate><ItemTemplate><asp:Label ID="Lbcimp" runat="server" Text='<%# Bind("Proyecto") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre de Proyecto" SortExpression="Nombre_Proyecto"><ItemTemplate><asp:Label ID="LbEst" runat="server" Text='<%# Bind("Nombre_Proyecto") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de Radicacion" SortExpression="Fecha_Rad"><ItemTemplate><asp:Label ID="LbCodAux" runat="server" Text='<%# Bind("Fecha_Rad","{0:d}") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Comite" SortExpression="Comite"><ItemTemplate><asp:Label ID="LbCodFor" runat="server" Text='<%# Bind("Comite") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor" SortExpression="Valor"><ItemTemplate><asp:Label ID="LbCodCon" runat="server" Text='<%# Bind("Valor") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Estado"><ItemTemplate><asp:Label ID="LbEstado" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                        ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                    <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                        ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:LinkButton ID="lnkNuevo" runat="server" 
                        CausesValidation="False" CommandName="Nuevo" Text="Nuevo Registro"></asp:LinkButton>
                </EmptyDataTemplate>
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />
            <asp:ImageButton ID="IbtnNuevo" runat="server" SkinID="IBtnNuevo" 
                ValidationGroup="NoValidar" />
            <br />
            <asp:ObjectDataSource id="ObjProyectos" runat="server" TypeName="Proyectos" 
                SelectMethod="GetProyectos" 
                OldValuesParameterFormatString="original_{0}" InsertMethod="Insert" 
                UpdateMethod="Update">
                
                <SelectParameters>
                    <asp:ControlParameter ControlID="CmbVig" Name="Vigencia" 
                        PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="TxtBuscar" Name="Proyecto" PropertyName="Text" 
                        Type="String" />
                </SelectParameters>
                
            </asp:ObjectDataSource>
            
        </asp:View>
        <asp:View ID="View2" runat="server">

        <TABLE 
                    align="center"><TBODY>
        <TR><TD colSpan=3>
            <asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR>
        <TR><TD colSpan=3>
            <asp:ValidationSummary id="ValidationSummary1" runat="server">
                    </asp:ValidationSummary></TD></TR>
        <TR><TD style="WIDTH: 162px">
                <asp:Label ID="Label4" runat="server" Text="Vigencia" 
                        Width="143px"></asp:Label></TD>
            <TD style="WIDTH: 513px">
                <asp:TextBox ID="TxtCodNew" runat="server" Width="107px"></asp:TextBox></TD>
            <TD style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtCodNew" ErrorMessage="Digite  Codigo ">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 162px; HEIGHT: 23px">
                <asp:Label id="Label1" runat="server" Width="126px" Text="Proyecto"></asp:Label></TD>
            <TD style="WIDTH: 513px; HEIGHT: 23px">
                    <asp:TextBox ID="txt_proy" runat="server" Width="229px"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtNomProy" ErrorMessage="Digite Codigo ">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 162px; HEIGHT: 18px">
                    <asp:Label ID="Label5" runat="server" Text="Nombre del Proyecto"></asp:Label>
                    </TD><TD style="WIDTH: 513px; HEIGHT: 18px">
                    <asp:TextBox ID="txtNomProy" runat="server" Width="433px" Height="69px" 
                TextMode="MultiLine"></asp:TextBox>
                    </TD><TD style="WIDTH: 100px; HEIGHT: 18px">
                        
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtNomProy" ErrorMessage="Digite Codigo ">*</asp:RequiredFieldValidator>
                    </TD></TR>
        <TR><TD style="WIDTH: 162px; HEIGHT: 19px">
                <asp:Label ID="Label6" runat="server" Text="Fecha de Radicacion"></asp:Label>
            </TD><TD style="WIDTH: 513px; HEIGHT: 19px">
                <asp:TextBox ID="Txt_Fec_Rad" runat="server" Width="107px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        Format="dd/MM/yyyy" TargetControlID="Txt_Fec_Rad">
                </ajaxToolkit:CalendarExtender>
            </TD>
            <TD style="WIDTH: 100px; HEIGHT: 19px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtNomProy" ErrorMessage="Digite Codigo Impuesto">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 162px">
                <asp:Label ID="Label7" runat="server" Text="Comite"></asp:Label>
            </TD>
            <TD style="WIDTH: 513px">
                <asp:TextBox ID="Txt_comite" runat="server" Width="107px"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="WIDTH: 162px">
                <asp:Label ID="Label8" runat="server" Text="Valor"></asp:Label>
            </TD>
            <TD style="WIDTH: 513px">
                <telerik:RadNumericTextBox ID="Txt_Val" Runat="server">
                </telerik:RadNumericTextBox>
            </TD><TD style="WIDTH: 100px"></TD></TR>
        <TR>
            <TD style="WIDTH: 162px">
                    <asp:Label ID="Label10" runat="server" Text="Estado"></asp:Label>
                    </TD><TD style="WIDTH: 513px">
                <asp:DropDownList ID="Cmb_Estado" runat="server" Width="107px">
                    <asp:ListItem Value="PRIORIZADO">PRIORIZADO</asp:ListItem>
                    <asp:ListItem Value="EN EJECUCIÓN">EN EJECUCIÓN</asp:ListItem>
                    <asp:ListItem Value="PRIORIZADO SIN RECURSOS">PRIORIZADO SIN RECURSOS</asp:ListItem>
                    <asp:ListItem Value="REMITIDO A SECTORIAL">REMITIDO A SECTORIAL</asp:ListItem>
                    <asp:ListItem Value="CONTRATADO">CONTRATADO</asp:ListItem>
                    <asp:ListItem Value="EJECUTADO">EJECUTADO</asp:ListItem>
                    <asp:ListItem Value="PRECONTRACTUAL">PRECONTRACTUAL</asp:ListItem>
                    <asp:ListItem Value="VIABILIZADO SECTORIAL">VIABILIZADO SECTORIAL</asp:ListItem>
                    <asp:ListItem Value="REFORMULADO">REFORMULADO</asp:ListItem>
                    <asp:ListItem Value="LICITACION ADJUDICADA">LICITACION ADJUDICADA</asp:ListItem>
                    </asp:DropDownList>
            </TD><TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="TEXT-ALIGN: center" colspan=3>
            &nbsp;</TD></TR>
        <tr><td colspan="3" style="TEXT-ALIGN: center"><asp:Button ID="BtnGuardar" 
                runat="server" onclick="BtnGuardar_Click" Text="Guardar">
                    </asp:Button>
            &#160;<asp:Button ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" 
                Text="Eliminar">
                    </asp:Button>  
            <input id="BtnCancelar" type="button" value="Cancelar" /> 
            <asp:Button ID="BtnVolver" runat="server" Text="Volver" />
            </td></tr>
        <tr><td colspan="3" style="TEXT-ALIGN: center">&#160;</td></tr></TBODY></TABLE>
        </asp:View>
    </asp:MultiView>

<asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetRecords"
                        TypeName="Vigencias" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>            
</asp:Content>

