﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="AsigAntInv.aspx.vb" Inherits="Contratos_GesContratos_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <script type='text/javascript'>
        function CalculatePor() {
            var val1 = document.getElementById('<%= txtvalor.ClientID%>').value;
            if (val1 != "") {

                var valTotal = document.getElementById('<%= TxtValPago.ClientID%>').value;
                var valorporcentaje = ((parseFloat(val1)) * 100) / parseFloat(valTotal);
                document.getElementById('<%= txtporcentaje.ClientID%>').value = valorporcentaje.toFixed(1);

            }

        }
        function CalculateVal() {

            var valorporcentaje = document.getElementById('<%= txtporcentaje.ClientID%>').value;
            if (valorporcentaje != "") {
                var valTotal = document.getElementById('<%= TxtValPago.ClientID%>').value;
                var valor1 = ((parseFloat(valorporcentaje)) * parseFloat(valTotal)) / (100);
                document.getElementById('<%= txtvalor.ClientID%>').value = valor1.toFixed(0);
            }


        }
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);
            $addHandler($get("BtnCancelar"), 'click', CerrarModalTercero);
        }
        function CerrarModalTercero(ev) {
            ev.preventDefault();
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }
        
    </script>
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
    <div class="demoarea">
        <asp:HiddenField ID="hdCodCon" runat="server" />
        .<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="GESTIÓN DE CONTRATOS"></asp:Label>
                
                <div style="height: 120px; overflow: auto">
                    <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" CellPadding="4"
                        DataKeyNames="Cod_Tpro" EnableModelValidation="True" Font-Size="Small" ForeColor="#333333"
                        GridLines="None" Height="84px" Width="95%" EmptyDataText="El contrato, no se encuentra en el estado correspondiente para hacer plan de anticipo&quot;">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EmptyDataTemplate>
                            <br />
                            El Contrato no existe o pertenece a una Delegación de la cual no esta autorizado.
                        </EmptyDataTemplate>
                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <Fields>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                            <asp:BoundField DataField="Numero" HeaderText="Número" SortExpression="Numero">
                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Size="Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OBJ_CON" HeaderText="Objeto" SortExpression="OBJ_CON" />
                            <asp:BoundField DataField="CONTRATISTA" HeaderText="Contratista" SortExpression="CONTRATISTA" />
                            <asp:BoundField DataField="FEC_SUS_CON" DataFormatString="{0:d}" HeaderText="Fecha de Suscripción"
                                SortExpression="FEC_SUS_CON" />
                            <asp:BoundField DataField="Valor_Total_Prop" DataFormatString="{0:c}" HeaderText="Valor Total   ">
                                <ItemStyle Font-Bold="True" Font-Size="Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PLAZO_TOTAL" HeaderText="Plazo de Ejecución Total" />
                            <asp:BoundField DataField="VAL_CON" DataFormatString="{0:c}" HeaderText="Valor Inicial  " />
                            <asp:BoundField DataField="PLA_EJE_CON" HeaderText="Plazo de Ejecución Inicial" />
                            <asp:BoundField DataField="NRO_ADI" HeaderText="Cantidad de Adiciones " />
                            <asp:BoundField DataField="VAL_ADI" DataFormatString="{0:c}" HeaderText="Valor Adicionado " />
                            <asp:BoundField DataField="PLA_ADI" HeaderText="Plazo de Ejecución Adicional" />
                            <asp:BoundField DataField="Valor_Total_Doc" DataFormatString="{0:c}" HeaderText="Valor Total del Contrato/Convenio" />
                            <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" HeaderText="Fecha de Acta de Inicio" />
                            <asp:BoundField DataField="fec_apr_pol" DataFormatString="{0:d}" HeaderText="Fecha Legalización" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="Dependencia" HeaderText="Dependencia que Genera la Necesidad"
                                SortExpression="Dependencia" />
                            <asp:BoundField DataField="DependenciaP" HeaderText="Dependencia a Cargo del Proceso"
                                SortExpression="DependenciaP" />
                            <asp:BoundField DataField="Abogado" HeaderText="Proyectó" />
                            <asp:BoundField DataField="RevisadoPor" HeaderText="Revisado Por" />
                        </Fields>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderTemplate>
                            INFORMACIÓN DETALLADA DEL CONTRATO
                        </HeaderTemplate>
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:DetailsView>
                    <asp:ObjectDataSource ID="ObjContratos" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetByPkF" TypeName="Contratos">
                        <SelectParameters>
                            <asp:ControlParameter Name="Cod_Con"  ControlID="hdCodCon" PropertyName="Value" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>

                    </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lBtnGenerar" />
            </Triggers>
        </asp:UpdatePanel>
      
       <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
        
                <fieldset >
                <legend> 1. Datos Iniciales de Plan de Inversión del Anticipo</legend>
                <asp:Panel ID="Panel1" runat="server">
                    <table style="padding-top:30px">
                        <tr>
                            <td style="width: 41px" class="barraH">
                                &nbsp;
                            </td>
                            <td style="text-align: center" class="barraH">
                                <asp:ImageButton ID="lBtnEditar" runat="server" Height="32px" Width="32px" SkinID="IBtnEditar" />
                            </td>
                            <td style="text-align: center" class="barraH">
                                <asp:ImageButton ID="IBtnGuardar" runat="server" Height="32px" Width="32px" SkinID="IBtnGuardar" />
                            </td>
                            <td style="text-align: center" class="barraH">
                                <asp:ImageButton ID="lBtnCancelar" runat="server" Height="32px" Width="32px" SkinID="IBtnCancelar" />
                            </td>
                            <td style="text-align: center" class="barraH">
                                <asp:ImageButton ID="IBtnValidar" runat="server" Height="32px" SkinID="BtnAprobar"
                                    Width="32px" />
                            </td>
                            <td style="text-align: center" class="barraH">
                                <asp:ImageButton ID="IBtnRevertir" runat="server" Height="32px" SkinID="BtnDesaprobar"
                                    Width="32px" />
                            </td>
                            <td style="text-align: center" class="barraH">
                                <asp:ImageButton ID="lBtnGenerar" runat="server" Height="32px" Width="32px" SkinID="IBtnMinuta" />
                            </td>
                            <td style="text-align: center" class="barraH">
                                <asp:ImageButton ID="lBtnAtras" runat="server" Height="32px" SkinID="IBtnMinuta"
                                    Width="32px" ImageUrl="~/images/Operaciones/Backward-32.png" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 41px">
                                &nbsp;
                            </td>
                            <td style="text-align: center">
                                Editar
                            </td>
                            <td style="text-align: center">
                                Guardar
                            </td>
                            <td style="text-align: center">
                                Cancelar
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LbValidar" runat="server" Text="Validar"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LbRevertir" runat="server" Text="Revertir"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                Generar
                            </td>
                            <td style="text-align: center">
                                Atras
                            </td>
                            <td style="text-align: center" class="style2">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td colspan="6" style="text-align: left; empty-cells: show; vertical-align: top;">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ppal" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 21px">
                                <asp:Label ID="MsgResult" runat="server" Height="30px" Width="90%"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                No. Documento
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TxtNoDocumento" runat="server" Enabled="False" EnableTheming="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Documento
                            </td>
                            <td colspan="5">
                                <asp:Label ID="LbEst1" runat="server"> PLAN DE INVERSIÓN Y ANTICIPOS</asp:Label>
                                &nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha Documento
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtFecDoc" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                    TargetControlID="txtFecDoc">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:CalendarExtender ID="txtFecDoc_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtFecDoc">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFecDoc"
                                    ErrorMessage="Selecciones la Fecha del Documento" ValidationGroup="ppal">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Observación
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtObs" runat="server" TextMode="MultiLine" Width="421px">.</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Valor Anticipo
                            </td>
                            <td colspan="3">
                                <%--<asp:TextBox ID="TxtValPago" runat="server">0</asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="TxtValPago_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Custom, Numbers" TargetControlID="TxtValPago" ValidChars=".">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                                <telerik:RadNumericTextBox ID="TxtValPago" runat="server" AutoPostBack="True" 
                                    Culture="es-CO" Height="19px" Skin="Default" Value="0" Width="125px">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                Estado Documento
                            </td>
                            <td >
                                <asp:Label ID="LbEstado" runat="server"></asp:Label>
                                &nbsp;
                            </td>
                            <td style="text-align: center">
                                &nbsp;
                            </td>
                            <td style="text-align: center">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </fieldset>
                    </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lBtnGenerar" />
            </Triggers>
        </asp:UpdatePanel>   
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Panel ID="PnlPIA" runat="server">
                
                <fieldset >
                <legend > 2. Items del Plan de Inversión del Anticipo</legend>
                <asp:Label ID="MsgResult2" runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                <br />
                <asp:GridView ID="grdInformes" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="COD_INVAN" EmptyDataText="No se encontraron Registros en la Base de Datos"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None" ShowFooter="True"
                    Width="500px">
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
                                <asp:Label ID="Lbcimp" runat="server" Text='<%# Bind("VAL_INVAN") %>'></asp:Label>
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
                                        DataTextField="NOM_INVAN" DataValueField="COD_INVAN" Width="128px">
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
