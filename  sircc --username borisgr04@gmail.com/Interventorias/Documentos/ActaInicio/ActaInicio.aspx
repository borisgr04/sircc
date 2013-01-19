<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ActaInicio.aspx.vb" Inherits="Interventorias_Documentos_ActaInicio" %>

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
                                Documento
                            </td>
                            <td colspan="5">
                                <asp:Label ID="LbEst1" runat="server" CssClass="Titulo"> ACTA DE INICIO</asp:Label>
                                &nbsp;&nbsp;&nbsp;
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
                                Fecha de Inicio
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtFecDoc"  runat="server" AutoPostBack="True"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtFecDoc_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtFecDoc">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFecDoc"
                                    ErrorMessage="Seleccione la Fecha del Documento" ValidationGroup="ppal">*</asp:RequiredFieldValidator>
                               Ultima Fecha: <asp:Textbox ID="LbFS" runat="server" ReadOnly="true"  ></asp:Textbox> <asp:Label ID="LbDocFS" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Plazo de Ejecución
                            </td>
                            <td colspan="5">
                                <asp:Label ID="LbPlazoEje" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha de Finalización
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TxtFecFin" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalTxtFecFin" runat="server" Enabled="True"
                                    TargetControlID="TxtFecFin">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFecFin"
                                    ErrorMessage="Seleccione la Fecha del Documento" ValidationGroup="ppal">*</asp:RequiredFieldValidator>
                                <asp:CheckBox ID="ChkCalcular" runat="server" Text="Calcular Fecha" />
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
                            <td >
                                Estado Documento
                            </td>
                            <td >
                                <asp:Label ID="LbEstado" runat="server"></asp:Label>
                                &nbsp;
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
                                        <asp:Parameter DefaultValue="01" Name="Est_Fin" Type="String" />
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
                <asp:PostBackTrigger ControlID="IBtnVerDoc" />
            </Triggers>
        </asp:UpdatePanel>   
    </div>
</asp:Content>
