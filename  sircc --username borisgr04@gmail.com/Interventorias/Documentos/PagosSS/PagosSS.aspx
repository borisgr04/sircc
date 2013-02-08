<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PagosSS.aspx.vb" Inherits="Interventorias_PagosSS_PagosSS" %>
<%@ Register src="../../CtrlUsr/DetContratosI/DetContratoI.ascx" tagname="DetContratoI" tagprefix="uc2" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>


<script type='text/javascript'>
    function eliminar() {
        return confirm('Confirme si quiere Eliminar el Registro?');
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
                    <uc2:DetContratoI ID="DtPCon" runat="server" />
                </div>

                    </ContentTemplate>
            
        </asp:UpdatePanel>
      <hr />
      <br />
        <asp:HiddenField ID="hdEstInicial" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
       
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="MetroTouch" 
                    MultiPageID="RadMultiPage1" SelectedIndex="0" >
            <Tabs>
                <telerik:RadTab runat="server" Text="Pagos de Seguridad Social " 
                    PageViewID="RadPageView1" >
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Nuevo / Edición" PageViewID="RadPageView2" 
                    Selected="True">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
            <telerik:RadPageView ID="RadPageView1" runat="server">
                <asp:Panel ID="PnlPIA" runat="server">
                <br />
                    <%--<fieldset>
                        <legend>2. Informes de Contratista</legend>
                    --%>    
                        <asp:LinkButton ID="lnkBtn" runat="server">Nuevo</asp:LinkButton>
                        <br />
                        <asp:GridView ID="grd" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="ID" EmptyDataText="No se encontraron Registros en la Base de Datos"
                            EnableModelValidation="True" ForeColor="#333333" GridLines="None" ShowFooter="True"
                            Width="700px" DataSourceID="ObjIntPagos">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="Id" SortExpression="Id"/>
                                <asp:BoundField DataField="Nom_Tip" HeaderText="Tipo Aporte" 
                                    SortExpression="Nom_Tip" />
                                <asp:BoundField DataField="PlanillaN" HeaderText="Planilla N°" 
                                    SortExpression="PlanillaN" />
                                <asp:BoundField DataField="Val_Apo" HeaderText="Valor Aporte" 
                                    SortExpression="Val_Apo" />
                                <asp:TemplateField HeaderText="Periodo" SortExpression="Mes_Pago">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Mes_Pago")+"-"+Eval("Year_Pago") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Tipo Planilla" DataField="Tipo_Pla" SortExpression="Tipo_Pla" />
                                <asp:TemplateField ShowHeader="False" HeaderText="Anular">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false"  OnClientClick="return eliminar();"
                                            CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" CommandArgument='<%# Eval("ID") %>'
                                            Text="Eliminar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png"
                                    Text="Editar" HeaderText="Editar" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                                    ShowSelectButton="True" HeaderText="Ver" />
                                <%--<asp:ButtonField ButtonType="Image" CommandName="Descargar" 
                                    HeaderText="Soportes" ImageUrl="~/images/BlueTheme/Descargar.png" 
                                    Text="Descargar Comprimidos en Zip" />--%>
                            </Columns>
                            <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjIntPagos" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                            TypeName="PagoSS">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdCodCon" Name="Cod_Con" PropertyName="Value" 
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <br />
                    <%--</fieldset>--%>
                </asp:Panel>
          
                </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server" Width="100%">
                <br />
                        <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label><br />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="g1" />
                        <asp:Label ID="MsgResult2" runat="server" SkinID="MsgResult"></asp:Label>&nbsp;&nbsp;&nbsp;<br />
                        <br />
                <table style=" width:500px">
                <tr>
                                <td style="text-align: center" >
                                    <asp:ImageButton ID="IBtnNuevo" runat="server" SkinID="IBtnNuevo" />
                                </td>
                                <td  style="text-align: center">
                                    <asp:ImageButton ID="IBtnEditar" runat="server" SkinID="IBtnEditar" />
                                </td>
                                <td style="text-align: center">
                                    <asp:ImageButton ID="IBtnGuardar" runat="server" SkinID="IBtnGuardar" OnClientClick="return Validar();" />
                                </td>
                                <td  style="text-align: center">
                                    <asp:ImageButton ID="IBtnCancelar" runat="server" SkinID="IBtnCancelar" />
                                </td>
                                <td  style="text-align: center">
                                    <asp:ImageButton ID="IbtnVolver" runat="server" />
                                </td>
                                <td >
                                    &nbsp;</td>
                                <td >
                                    &nbsp;&nbsp;
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center" >
                                    Nuevo</td>
                                <td  style="text-align: center">
                                    Editar</td>
                                <td style="text-align: center">
                                    Guardar</td>
                                <td  style="text-align: center">
                                    Cancelar</td>
                                <td  style="text-align: center">
                                    Volver</td>
                                <td >
                                    &nbsp;</td>
                                <td >
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            </table>
                            
                            
                            <br />
                            <table >
                            <tr>
                                <td>
                                    Id Pago</td>
                                <td>
                                    <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Planilla N°</td>
                                <td>
                                    <asp:TextBox ID="txtPlanillaN" runat="server"></asp:TextBox>
                                    
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tipo Planilla</td>
                                <td>
                                    <asp:DropDownList ID="CboTipPla" runat="server">
                                        <asp:ListItem Value="N">Normal</asp:ListItem>
                                        <asp:ListItem Value="C">Corrección</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                                <tr>
                                    <td>
                                        Periodo</td>
                                    <td>
                                        <telerik:RadMonthYearPicker ID="txtPeriodo" Runat="server">
                                            <DateInput DateFormat="MMMM' de 'yyyy" DisplayDateFormat="MMMM' de 'yyyy" 
                                                LabelWidth="40%">
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadMonthYearPicker>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            <tr>
                                <td>
                                    Tipo Aporte</td>
                                <td>
                                    <asp:DropDownList ID="cboTipoAporte" runat="server" DataSourceID="ObjTipEnt" 
                                        DataTextField="Nom_Tip" DataValueField="Cod_Tip">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Valor Aportes</td>
                                <td>
                                    <telerik:RadNumericTextBox ID="TxtValApor" runat="server" Culture="es-CO" 
                                        DataType="System.Int32" Skin="Default" Value="0" Width="125px">
                                        <NumberFormat DecimalDigits="2" ZeroPattern="$ n" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="TxtValApor" ErrorMessage="*" SetFocusOnError="True">Campo Requerido</asp:RequiredFieldValidator>

                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Observación</td>
                                <td>
                                    <asp:TextBox ID="TxtObs" runat="server" Height="76px" TextMode="MultiLine" 
                                        Width="345px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Soportes</td>
                                <td >
                                    <telerik:RadAsyncUpload ID="RUploadAnexos" runat="server" 
                                        MultipleFileSelection="Automatic">
                                         <Localization Select="Adjuntar" Remove="Eliminar" Cancel="Cancelar" />
                                    </telerik:RadAsyncUpload>
                                    
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:GridView ID="grdSoporte" runat="server" AutoGenerateColumns="False"  DataKeyNames="ID"
                                            DataSourceID="ObjSoport" EnableModelValidation="True" Width="400px" ShowHeader="False">
                                            <Columns>
                                                <asp:BoundField DataField="NomArc" HeaderText="NomArc" 
                                                    SortExpression="NomArc" />
                                                <asp:BoundField DataField="FEc_Reg" HeaderText="Fecha y Hora" 
                                                    SortExpression="FEc_Reg" />
                                                <asp:ButtonField ButtonType="Image" ImageUrl="~/images/BlueTheme/Descargar.png"  CommandName="Descargar"
                                                    Text="Descargar" />
                                                <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="IbtnEliminar" runat="server" CausesValidation="false"  OnClientClick="return eliminar();"
                                                        CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" CommandArgument='<%# Eval("ID") %>'
                                                        Text="Eliminar" />
                                                 </ItemTemplate>
                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                            <asp:ObjectDataSource ID="ObjTipEnt" runat="server" 
                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetTipoEntidad" 
                                            TypeName="PagoSS"></asp:ObjectDataSource>
                                            <asp:ObjectDataSource ID="ObjSoport" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetSoporte" 
                                    TypeName="InfContratista">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="Cod_Con" QueryStringField="Cod_Con" 
                                            Type="String" />
                                        <asp:ControlParameter ControlID="TxtId" Name="Num_Inf" PropertyName="Text" 
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            
                        </table></telerik:RadPageView>
        </telerik:RadMultiPage>
          </ContentTemplate>
            <%--<Triggers>
                <asp:PostBackTrigger ControlID="grdSoporte" />
            </Triggers>--%>
        </asp:UpdatePanel>
                        
                        
        
    </div>
</asp:Content>
