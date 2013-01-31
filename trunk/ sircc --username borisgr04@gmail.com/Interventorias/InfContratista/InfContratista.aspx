﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="InfContratista.aspx.vb" Inherits="Interventorias_InfContratista_InfContratista" %>

<%@ Register src="../../CtrlUsr/DetContratosI/DetContratoI.ascx" tagname="DetContratoI" tagprefix="uc1" %>

<%@ Register src="../CtrlUsr/DetContratosI/DetContratoI.ascx" tagname="DetContratoI" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
 
    <style type="text/css">
        .barraH{padding-left: 10px;padding-right:10px;}
    
.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

    </style>
<%--
     <script type='text/javascript'>
        function CalculatePor() {
            var val1 = document.getElementById('<%= txtvalor.ClientID%>').value;
            if (val1 != "") {

                var valTotal = document.getElementById('<%= TxtValPago.ClientID%>').value;
                var valorporcentaje = ((parseFloat(val1)) * 100) / parseFloat(valTotal);
                document.getElementById('<%= txtporcentaje.ClientID%>').value = valorporcentaje.toFixed(1);

            }

        }
        </script>--%>
    <div class="demoarea">
        <asp:HiddenField ID="hdCodCon" runat="server" />
        .<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="GESTIÓN DE CONTRATOS"></asp:Label>
                
                <div style="height: 120px; overflow: auto">
                    <uc2:DetContratoI ID="DetContratoI1" runat="server" />
                </div>

                    </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lBtnGenerar" />
            </Triggers>
        </asp:UpdatePanel>
      <hr />
      <br />
        <asp:HiddenField ID="hdEstInicial" runat="server" />
       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Panel ID="PnlPIA" runat="server">
                    <fieldset>
                        <legend>2. Items del Plan de Inversión del Anticipo</legend>
                        <asp:Label ID="MsgResult2" runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                        <br />
                        <asp:GridView ID="grdInformes" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="COD_INVAN" EmptyDataText="No se encontraron Registros en la Base de Datos"
                            EnableModelValidation="True" ForeColor="#333333" GridLines="None" ShowFooter="True"
                            Width="700px">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Descripción" SortExpression="NOM_INVAN">
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="False" CommandName="Nuevo"
                                            Text="Nuevo Registro"></asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LbCod" runat="server" Text='<%# Bind("NOM_INVAN") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valor" SortExpression="VAL_INVAN">
                                    <FooterTemplate>
                                        <asp:ImageButton ID="lnkExportar" runat="server" Text="Exportar Datos a Excel" CausesValidation="False"
                                            CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32"
                                            Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Lbcimp" runat="server" Text='<%# Bind("VAL_INVAN","{0:c}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Porcentaje" SortExpression="VPorcent">
                                    <ItemTemplate>
                                        <asp:Label ID="LbPorc" runat="server" Text='<%# Bind("VPorcent") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado" SortExpression="EST_INVAN_CONT">
                                    <ItemTemplate>
                                        <asp:Label ID="LbEst" runat="server" Text='<%# Bind("EST_INVAN_CONT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png"
                                    Text="Eliminar" />
                                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png"
                                    Text="Editar" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                                    ShowSelectButton="True" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="False" CommandName="Nuevo"
                                    Text="Nuevo Registro"></asp:LinkButton>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <br />
                    </fieldset>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="grdInformes" />
            </Triggers>
        </asp:UpdatePanel>
        &nbsp;
        <asp:ObjectDataSource ID="ObjActaAnticipos" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetbyID" TypeName="ActaAnticipo" InsertMethod="Insert" UpdateMethod="Update">
            <SelectParameters>
                <asp:SessionParameter Name="ID" SessionField="NoID" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp;<asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <!-- Mensaje de Salida-->
                <br />
                <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup2" runat="server">
                </asp:Button>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2"
                    PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground"
                    BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll"
                    TargetControlID="hiddenTargetControlForModalPopup2">
                </ajaxToolkit:ModalPopupExtender>
                &nbsp;&nbsp;&nbsp;
                <asp:Panel ID="programmaticPopup2" runat="server" Width="661px" Height="447px" CssClass="ModalPanel2">
                    <asp:Panel ID="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px"
                        CssClass="BarTitleModal2">
                        <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                            padding-top: 5px">
                            <div style="float: left">
                                PLAN DE INVERSIÓN Y ANTICIPOS</div>
                            <div style="float: right">
                                <input id="BtnCerrar" type="button" value="X" /></div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="area" runat="Server" ScrollBars="Auto">
                        <br />
                        <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="g1" />
                        <br />
                        <table>
                            <tr>
                                <td style="width: 184px">
                                    Valor del Anticipo Disponible
                                </td>
                                <td>
                                    <asp:Label ID="lbValorD" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 184px">
                                    Plan Anticipo
                                </td>
                                <td>
                                    <asp:DropDownList ID="CboPlanAnticipo" runat="server" DataSourceID="ObjPlanAnticipos"
                                        DataTextField="NOM_INVAN" DataValueField="COD_INVAN" Width="450px">
                                        <asp:ListItem Value="AC">Activa</asp:ListItem>
                                        <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 184px">
                                    <asp:Label ID="Label3" runat="server" Text="Valor"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtvalor" runat="server" Width="128px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtvalor"
                                        ErrorMessage="Digite el Valor" ValidationGroup="g1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 184px">
                                    Porcentaje
                                </td>
                                <td>
                                    <asp:TextBox ID="txtporcentaje" runat="server" Width="128px" MaxLength="4"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtporcentaje"
                                        ErrorMessage="Digite el Porcentaje" ValidationGroup="g1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 184px">
                                    Estado
                                </td>
                                <td>
                                    <asp:DropDownList ID="CboEstado" runat="server">
                                        <asp:ListItem Value="AC">Activa</asp:ListItem>
                                        <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 184px">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="BtnGuardarPinv" runat="server" Text="Guardar" ValidationGroup="g1" />
                                    <asp:Button ID="BtnEliminarPinv" runat="server" Text="Eliminar" />
                                    <input id="BtnCancelar" type="button" value="Cancelar" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                    </asp:Panel>
                    &nbsp;<br />
                    <asp:ObjectDataSource ID="ObjPlanAnticipos" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetRecordsDB" TypeName="PlanAnticipos"></asp:ObjectDataSource>
                </asp:Panel>
                &nbsp;&nbsp;
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
