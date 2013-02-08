<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
 CodeFile="InfParciales.aspx.vb" Inherits="Interventorias_Documentos_InfParciales" %>

<%@ Register src="../../CtrlUsr/DetContratosI/DetContratoI.ascx" tagname="DetContratoI" tagprefix="uc1" %>

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

        .style1
        {
            width: 10px;
        }

        .style2
        {
            width: 28px;
        }

    </style>

     <script type='text/javascript'>
         function CalPorcEjec(sender, EventArgs) {
             var TxtPorEjePer = $find('<%=Me.TxtPorEjePer.ClientID%>');
             var TxtPorEjeAnt = $find('<%=Me.TxtPorEjeAnt.ClientID%>');
             var TxtPorEjeAcum = $find('<%=Me.TxtPorEjeAcum.ClientID%>');
             TxtPorEjeAcum.set_value(TxtPorEjePer.get_value() + TxtPorEjeAnt.get_value());
         }
         function CalNVisitas(sender, EventArgs) {
             var TxtNVisPer = $find('<%=Me.TxtNVisPer.ClientID%>');
             var TxtNVisAnt = $find('<%=Me.TxtNVisAnt.ClientID%>');
             var TxtNVisAcum = $find('<%=Me.TxtNVisAcum.ClientID%>');
             TxtNVisAcum.set_value(TxtNVisPer.get_value() + TxtNVisAnt.get_value());
         }
         function CalPagos(sender, EventArgs) {
             var TxtValAutPag = $find('<%=Me.TxtValAutPag.ClientID%>');
             var TxtSaldo = $find('<%=Me.TxtSaldo.ClientID%>');
             var TxtSaldoAnterior = $find('<%=Me.TxtSaldoAnterior.ClientID%>');
             if (TxtSaldoAnterior.get_value() < TxtValAutPag.get_value()) {
                 TxtValAutPag.set_value(0);
                 TxtSaldo.set_value(TxtSaldoAnterior.get_value() - TxtValAutPag.get_value());
                 alert('Valor Autorizado es Superior al Valor del Saldo');
             }
             else {
                 TxtSaldo.set_value(TxtSaldoAnterior.get_value() - TxtValAutPag.get_value());
             }

             
         }
         
        </script>
    <div class="demoarea">
        <asp:HiddenField ID="hdCodCon" runat="server" />
        .<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="GESTIÓN DE CONTRATOS"></asp:Label>
                
                <div style="height: 120px; overflow: auto">
                    <uc1:DetContratoI ID="DtPCon" runat="server" />
                </div>

                    </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lBtnGenerar" />
            </Triggers>
        </asp:UpdatePanel>
      <hr />
      <br />
        <asp:HiddenField ID="hdEstInicial" runat="server" />
       <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
        
                <fieldset >
                <legend> 1. Datos Iniciales de Acta de Inicio</legend>
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
                            <td class="barraH" style="text-align: center">
                                <asp:ImageButton ID="IbtnSegSoc" runat="server" />
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
                                <asp:DropDownList ID="CboPlantilla" runat="server" DataSourceID="ObjPlantillas" 
                                    DataTextField="Nom_Pla" DataValueField="Ide_Pla">
                                </asp:DropDownList>
                            </td>
                            <td class="barraH" style="text-align: center">
                                <asp:ImageButton ID="lBtnGenerar" runat="server" Height="32px" 
                                    SkinID="IBtnRoles" Width="32px" />
                            </td>
                            <td class="barraH" style="text-align: center">
                                <asp:ImageButton ID="IBtnVerDoc" runat="server" SkinID="IBtnEditBase" />
                            </td>
                            <td style="text-align: center" class="barraH">
                                <asp:ImageButton ID="lBtnAtras" runat="server" Height="32px" SkinID="IBtnCancelar"
                                    Width="32px"  />
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
                                SegSocial</td>
                            <td style="text-align: center">
                                <asp:Label ID="LbValidar" runat="server" Text="Validar"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LbRevertir" runat="server" Text="Revertir"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                Plantilla</td>
                            <td style="text-align: center">
                                Generar
                            </td>
                            <td style="text-align: center">
                                Ver</td>
                            <td style="text-align: center">
                                Atras
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td colspan="5" 
                                style="text-align: left; empty-cells: show; vertical-align: top;">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ppal" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="height: 21px">
                                <asp:TextBox ID="LbFS" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="LbDocFS" runat="server"></asp:Label>
                                Ultima Fecha:
                                <asp:Label ID="MsgResult" runat="server" Height="30px" Width="90%"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Documento
                            </td>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                <asp:Label ID="LbEst1" runat="server" CssClass="Titulo"> INFORME/ACTA PARCIAL DE PAGO</asp:Label>
                                &nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                No. Documento
                            </td>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                <asp:TextBox ID="TxtNoDocumento" runat="server" Enabled="False" EnableTheming="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="STitulos">
                            <td>
                                Periodo del Informe</td>
                            <td>
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Fecha Inicial</td>
                            <td>
                                &nbsp;</td>
                            <td >
                                <telerik:RadDatePicker ID="TxtFecPIni" Runat="server" Skin="Windows7">
                                    <Calendar Skin="Windows7" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                        LabelWidth="40%">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td >
                                Fecha Final</td>
                            <td>
                                <telerik:RadDatePicker ID="TxtFecPFin" Runat="server" Skin="Windows7">
                                    <Calendar Skin="Windows7" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                        LabelWidth="40%">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr class="STitulos">
                            <td >
                                % Avance</td>
                            <td>
                                &nbsp;</td>
                            <td >
                                Periodo</td>
                            <td class="style2" >
                                Anterior</td>
                            <td >
                                Acumulado</td>
                        </tr>
                        <tr>
                            <td>
                                % Avance Fisico
                            </td>
                            <td>
                                &nbsp;</td>
                            <td >
                                <telerik:RadNumericTextBox ID="TxtPorEjePer" Runat="server" 
                                    Culture="es-CO" DbValueFactor="1" LabelWidth="64px" Skin="Default" 
                                    Type="Percent" Value="0" Width="160px" MaxValue="100" MinValue="0">
                                    <NumberFormat ZeroPattern="n"   />
                                    <ClientEvents OnValueChanged="CalPorcEjec" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td >
                                <telerik:RadNumericTextBox ID="TxtPorEjeAnt" Runat="server" 
                                    Culture="es-CO" DbValueFactor="1" LabelWidth="64px" Skin="Default" 
                                    Type="Percent" Value="0" Width="160px" Enabled="False">
                                    <NumberFormat ZeroPattern="n" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td >
                                <telerik:RadNumericTextBox ID="TxtPorEjeAcum" Runat="server" 
                                    Culture="es-CO" DbValueFactor="1" LabelWidth="64px" Skin="Default" 
                                    Type="Percent" Value="0" Width="160px" Enabled="False">
                                    <NumberFormat ZeroPattern="n" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                N° Visitas</td>
                            <td>
                                &nbsp;</td>
                            <td >
                                <telerik:RadNumericTextBox ID="TxtNVisPer" Runat="server" Culture="es-CO" 
                                    DbValueFactor="1" LabelWidth="64px" Skin="Default" Value="0" Width="160px" 
                                    MinValue="0">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="0" />
                                    <ClientEvents OnValueChanged="CalNVisitas" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td >
                                <telerik:RadNumericTextBox ID="TxtNVisAnt" Runat="server" Culture="es-CO"  
                                    DbValueFactor="1" LabelWidth="64px" Skin="Default" Value="0" Width="160px" 
                                    Enabled="False">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td >
                                <telerik:RadNumericTextBox ID="TxtNVisAcum" Runat="server" Culture="es-CO" 
                                    DbValueFactor="1" LabelWidth="64px" Skin="Default" Value="0" Width="160px" 
                                    Enabled="False">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr class="STitulos">
                            <td>
                                Financiero</td>
                            <td>
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                            <td >
                                Saldo Actual</td>
                            <td >
                                Saldo por Autorizar</td>
                        </tr>
                        <tr>
                            <td>
                                Valor Autorizado a Pagar</td>
                            <td>
                                &nbsp;</td>
                            <td class="style1">
                                <telerik:RadNumericTextBox ID="TxtValAutPag" Runat="server" 
                                    Culture="es-CO" DbValueFactor="1" LabelWidth="64px" Skin="Default" 
                                    Type="Currency" Value="0" Width="160px" MinValue="0">
                                    <NumberFormat ZeroPattern="$ n" />
                                    <ClientEvents OnValueChanged="CalPagos" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style2">
                                <telerik:RadNumericTextBox ID="TxtSaldoAnterior" Runat="server" 
                                    Culture="es-CO" DbValueFactor="1" Enabled="False" LabelWidth="64px" 
                                    Skin="Default" Type="Percent" Value="0" Width="160px">
                                    <NumberFormat ZeroPattern="n" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style1">
                                <telerik:RadNumericTextBox ID="TxtSaldo" Runat="server" 
                                    Culture="es-CO" DbValueFactor="1" Enabled="False" LabelWidth="64px" 
                                    Skin="Default" Type="Percent" Value="0" Width="160px">
                                    <NumberFormat ZeroPattern="n" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr class="STitulos">
                            <td>
                                Anticipo</td>
                            <td>
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                                Saldo Amortización</td>
                            <td class="style1">
                                Saldo por Amortizar</td>
                        </tr>
                        <tr>
                            <td>
                                Amortizar</td>
                            <td>
                                &nbsp;</td>
                            <td class="style1">
                                <telerik:RadNumericTextBox ID="TxtValAmort" Runat="server" Culture="es-CO" 
                                    DbValueFactor="1" LabelWidth="64px" MinValue="0" Skin="Default" Type="Currency" 
                                    Value="0" Width="160px">
                                    <NumberFormat ZeroPattern="$ n" />
                                    <ClientEvents OnValueChanged="CalPagos" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style2">
                                <telerik:RadNumericTextBox ID="TxtSalAmor" Runat="server" Culture="es-CO" 
                                    DbValueFactor="1" LabelWidth="64px" MinValue="0" Skin="Default" Type="Currency" 
                                    Value="0" Width="160px" Enabled="False">
                                    <NumberFormat ZeroPattern="$ n" />
                                    <ClientEvents OnValueChanged="CalPagos" />
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style1">
                                <telerik:RadNumericTextBox ID="TxtSalxAmor" Runat="server" Culture="es-CO" 
                                    DbValueFactor="1" LabelWidth="64px" MinValue="0" Skin="Default" Type="Currency" 
                                    Value="0" Width="160px" Enabled="False">
                                    <NumberFormat ZeroPattern="$ n" />
                                    <ClientEvents OnValueChanged="CalPagos" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Total a Pagar</td>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                <telerik:RadNumericTextBox ID="TxtTotPag" Runat="server" Culture="es-CO" 
                                    DbValueFactor="1" LabelWidth="64px" MinValue="0" Skin="Default" Type="Currency" 
                                    Value="0" Width="160px">
                                    <NumberFormat ZeroPattern="$ n" />
                                    <ClientEvents OnValueChanged="CalPagos" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                Fecha del Informe/Acta</td>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                <telerik:RadDatePicker ID="TxtFecAct" Runat="server" Skin="Windows7">
                                    <Calendar Skin="Windows7" UseColumnHeadersAsSelectors="False" 
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                        LabelWidth="40%">
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Observación
                            </td>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtObs" runat="server" TextMode="MultiLine" Width="421px" 
                                    Height="107px">.</asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr>
                            <td >
                                Estado Documento</td>
                            <td>
                                &nbsp;</td>
                            <td colspan="3" >
                                <asp:Label ID="LbEstado" runat="server"></asp:Label>
                                <asp:ObjectDataSource ID="ObjPlantillas" runat="server" InsertMethod="Insert" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetPlantillas" 
                                    TypeName="ActasSupervision" UpdateMethod="Update">
                                    <InsertParameters>
                                        <asp:Parameter Name="cod_con" Type="String" />
                                        <asp:Parameter Name="est_ini" Type="String" />
                                        <asp:Parameter Name="est_fin" Type="String" />
                                        <asp:Parameter Name="fec_ent" Type="DateTime" />
                                        <asp:Parameter Name="tfil" Type="String" />
                                        <asp:Parameter Name="obs" Type="String" />
                                        <asp:Parameter Name="val_pago" Type="Decimal" />
                                        <asp:Parameter Name="nvisitas" Type="Int32" />
                                        <asp:Parameter Name="por_eje_fis" Type="Decimal" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="02" Name="Est_Fin" Type="String" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="ID" Type="String" />
                                        <asp:Parameter Name="fec_ent" Type="DateTime" />
                                        <asp:Parameter Name="Obs" Type="String" />
                                        <asp:Parameter Name="val_pago" Type="Decimal" />
                                        <asp:Parameter Name="nvisitas" Type="Int32" />
                                        <asp:Parameter Name="por_eje_fis" Type="Decimal" />
                                    </UpdateParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </fieldset>
                    </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="IBtnVerDoc" />
            </Triggers>
        </asp:UpdatePanel>   
    </div>
</asp:Content>
