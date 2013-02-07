<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="InfContratista.aspx.vb" Inherits="Interventorias_InfContratista_InfContratista" %>
<%@ Register src="../CtrlUsr/DetContratosI/DetContratoI.ascx" tagname="DetContratoI" tagprefix="uc2" %>

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
                <telerik:RadTab runat="server" Text="Historico de Informes " 
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
                        <br />
                        <asp:GridView ID="grdInformes" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="Num_Inf" EmptyDataText="No se encontraron Registros en la Base de Datos"
                            EnableModelValidation="True" ForeColor="#333333" GridLines="None" ShowFooter="True"
                            Width="700px" DataSourceID="ObjInfContratista">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="N° Informe" SortExpression="NUM_INF">
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="False" CommandName="Nuevo"
                                            Text="Nuevo Registro"></asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LbCod" runat="server" Text='<%# Bind("NUM_INF") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Inicial" SortExpression="FEC_INI">
                                    <FooterTemplate>
                                     <%--   <asp:ImageButton ID="lnkExportar" runat="server" Text="Exportar Datos a Excel" CausesValidation="False"
                                            CommandName="Exportar" ImageUrl="~/images/Operaciones/excel.png" Height="32"
                                            Width="32" ToolTip="Exportar Datos a Excel"></asp:ImageButton>--%>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LbFEC_INI" runat="server" Text='<%# Bind("FEC_INI","{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Final" SortExpression="FEC_FIN">
                                    <ItemTemplate>
                                        <asp:Label ID="LbPorc" runat="server" Text='<%# Bind("FEC_FIN","{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Anexos (Páginas)" SortExpression="CAN_HOJ">
                                    <ItemTemplate>
                                        <asp:Label ID="LbEst" runat="server" Text='<%# Bind("CAN_HOJ") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" HeaderText="Anular">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false"  OnClientClick="return eliminar();"
                                            CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" CommandArgument='<%# Eval("NUM_INF") %>'
                                            Text="Eliminar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png"
                                    Text="Editar" HeaderText="Editar" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                                    ShowSelectButton="True" HeaderText="Ver" />
                                <asp:ButtonField ButtonType="Image" CommandName="Descargar" 
                                    HeaderText="Soportes" ImageUrl="~/images/BlueTheme/Descargar.png" 
                                    Text="Descargar Comprimidos en Zip" />
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
                        <asp:ObjectDataSource ID="ObjInfContratista" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                            TypeName="InfContratista">
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
                                <td  style="text-align: left">
                                    &nbsp;</td>
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
                                <td  style="text-align: left">
                                    &nbsp;</td>
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
                                    N° Informe
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtNInf" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Fecha Informe
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtFecInf" runat="server" MaxLength="4" Width="128px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="TxtFecInf_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="TxtFecInf">
                                    </ajaxToolkit:CalendarExtender>
                                    
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Fecha Inicial</td>
                                <td>
                                    <asp:TextBox ID="TxtFecIni" runat="server" Width="128px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                        TargetControlID="TxtFecIni">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Fecha Final</td>
                                <td>
                                    <asp:TextBox ID="TxtFecFin" runat="server" Width="128px" MaxLength="4"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                        TargetControlID="TxtFecFin">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Anexos(Páginas)</td>
                                <td>
                                    <telerik:RadNumericTextBox ID="TxtAnexo" runat="server" Culture="es-CO"
                                        Height="19px" Skin="Default" Value="0" Width="125px" 
                                        DataType="System.Int32" >
                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                    </telerik:RadNumericTextBox>

                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Descripción del Informe</td>
                                <td>
                                    <asp:TextBox ID="TxtDesInf" runat="server" Height="76px" TextMode="MultiLine" 
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
                                            <asp:ObjectDataSource ID="ObjSoport" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetSoporte" 
                                    TypeName="InfContratista">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="Cod_Con" QueryStringField="Cod_Con" 
                                            Type="String" />
                                        <asp:ControlParameter ControlID="TxtNInf" Name="Num_Inf" PropertyName="Text" 
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
