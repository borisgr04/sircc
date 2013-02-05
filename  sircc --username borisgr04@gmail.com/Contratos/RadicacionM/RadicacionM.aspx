<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RadicacionM.aspx.vb" Inherits="Contratos_RadicacionM_Default" %>

<%@ Register Src="../../CtrlUsr/ConsorciosUT/ConsorciosUT.ascx" TagName="ConsorciosUT"
    TagPrefix="uc4" %>
<%@ Register Src="../../CtrlUsr/ConsorciosUT/ConMiembros.ascx" TagName="ConMiembros"
    TagPrefix="uc5" %>
<%--<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>--%>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="../../CtrlUsr/grdProyC/grdProyC.ascx" TagName="grdProyC" TagPrefix="uc1" %>
<%@ Register Src="../../CtrlUsr/grdCDPC/grdCDPC.ascx" TagName="grdCDPC" TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/AdmTercero/AdmTercero.ascx" TagName="AdmTercero"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <%--<ajaxToolkit:ConfirmButtonExtender ID="BtnAct_ConfirmButtonExtender" 
                    runat="server" 
                    ConfirmText="Revise los datos modificados. ¿Confirme si desea Guardar los Cambios Realizados?" 
                    Enabled="True" TargetControlID="BtnAct">
                </ajaxToolkit:ConfirmButtonExtender>--%>
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function BtnCon_onclick(url) {
            window.open(url, 'wcon', 'fullscreen=no,status=no,scrollbars=yes,resizable=yes,width=700,height=400');
        }
        function Solo_Numeros() {
            var key = window.event.keyCode;
            if (!((key >= 48 && key <= 57) || (key == 46))) {
                window.event.keyCode = 0;
            }
        }


        function mayusculas(input) {
            var x = input.value;
            input.value = x.toUpperCase();
        }
        // ]]>
    </script>
    <script type='text/javascript'>
        function cancelClick() {
            var label = $get('ctl00_SampleContent_LbRpt');
        }
        function pageLoad() {
            $addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);
        }


        function showModalPopupViaClient(ev) {
            ev.preventDefault();
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }

        function hideModalPopupViaClient(ev) {
            ev.preventDefault();
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }

        function enviar(tdoc, ced, dv, rsocial, tip_ter) {

        }
    </script>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="demoarea">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Label ID="MsgResult" runat="server" Height="30px" Text="Label" Visible="False"
                    Width="80%"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                    Width="90%" SkinID="ValidationSummary1" />
                <table border="0" width="90%">
                    <tr>
                        <td class="Titulos" colspan="6" style="height: 13px">
                            <asp:Label ID="Label18" runat="server" CssClass="Titulo" Text="RADICACIÓN"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 15px; text-align: right">
                            <table style="width: 666px">
                                <tbody>
                                    <tr>
                                        <td style="width: 400px; height: 10px">
                                            <asp:Label ID="Label19" runat="server" CssClass="Caption" Font-Bold="True" Text="Ulitma Radicación"></asp:Label>
                                        </td>
                                        <td style="width: 101px; height: 10px">
                                            <asp:Label ID="TxtUId" runat="server" Font-Bold="True" Font-Size="Medium" Width="147px"></asp:Label>
                                        </td>
                                        <td style="width: 10px; height: 10px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 400px; height: 10px">
                                            <asp:Label ID="TxtUFs" runat="server" Font-Bold="True" Font-Size="Medium" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    </table>

                    <table width="90%">
                                <tr>
                                    <td style="width: 238px; ">
                                    <ajaxToolkit:ConfirmButtonExtender ID="BtnGuardar_ConfirmButtonExtender" runat="server"
                                ConfirmOnFormSubmit="True" ConfirmText="Confirme FECHA DE SUSCRIPCIÓN. ¿Desea Radicar el Contrato/Convenio?"
                                Enabled="True" TargetControlID="IBtnGuardar">
                            </ajaxToolkit:ConfirmButtonExtender>
                            
                                        <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" DataSourceID="ObjTiposCont"
                                            DataTextField="NOM_TIP" DataValueField="COD_TIP"  Width="209px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 200px; ">
                                        <strong>Número</strong>
                                    </td>
                                    <td style="width: 100px; ">
                                        <asp:TextBox ID="TxtCodCon" runat="server" Width="110px" Font-Bold="True" Font-Size="12pt"
                                            AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td style="width: 100px; ">
                                        &nbsp;<asp:ImageButton ID="IBtnAbrir" CausesValidation="false" runat="server" SkinID="IBtnAbrir" />
                                    </td>
                                    <td style="width: 100px; ">
                                        <asp:ImageButton ID="IBtnNuevo" runat="server" CausesValidation="False" SkinID="IBtnNuevo" />
                                    </td>
                                    <td style="width: 100px; ">
                                        <asp:ImageButton ID="IBtnEditar" runat="server" SkinID="IBtnEditar" CausesValidation="False" />
                                    </td>
                                    <td style="width: 100px; ">
                                        &nbsp;
                                    </td>
                                    <td style="width: 100px; ">
                                        <asp:ImageButton ID="IBtnGuardar" runat="server" SkinID="IBtnGuardar" />
                                    </td>
                                    <td style="width: 130px; ">
                                        <asp:ImageButton ID="IBtnCancelar" runat="server" SkinID="IBtnCancelar" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 238px; ">
                                        &nbsp;</td>
                                    <td style="width: 200px; ">
                                        &nbsp;
                                    </td>
                                    <td style="width: 100px; height: 10px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 100px; height: 10px">
                                        Abrir
                                    </td>
                                    <td style="width: 100px; height: 10px">
                                        Nuevo
                                    </td>
                                    <td style="width: 100px; height: 10px">
                                        Editar
                                    </td>
                                    <td style="width: 100px; height: 10px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 100px; height: 10px">
                                        Guardar
                                    </td>
                                    <td style="width: 130px; height: 10px">
                                        Cancelar
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px" colspan="9">
                                        <asp:Label ID="TipoRad" runat="server" CssClass="SubTitulo" Visible="False" 
                                            Width="100%"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                    <div  <%--style="overflow:auto; height:400px"--%>>
                    <table>
                    <tr>
                        <td class="TbLogin" colspan="3" style="height: 15px">
                            SubTipo de Contrato
                        </td>
                        <td class="STitulos" colspan="3" style="height: 15px">
                            Fecha de Suscripción<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                ControlToValidate="TxtFsus" ErrorMessage="Digite Fecha de Suscripción" Width="52px">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="3" style="height: 15px">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="cboStip" runat="server" DataValueField="COD_STIP" DataTextField="NOM_STIP"
                                        DataSourceID="ObjSubTipos" Width="80%">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="CboTip" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td colspan="3" style="height: 15px">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="TxtFsus" runat="server" Font-Bold="True" Font-Size="12pt" Width="135px"></asp:TextBox>
                                    (dd/mm/aaaa)
                                    <ajaxToolkit:CalendarExtender ID="TxtFsus_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="TxtFsus">
                                    </ajaxToolkit:CalendarExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="CboTip" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>

                    
                    <tr>
                        <td class="STitulos" colspan="3" style="height: 15px">
                            Objeto del Contrato
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtObj"
                                ErrorMessage="Digite Objeto del Contrato/Convenio" Width="16px">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="STitulos" colspan="3" style="height: 15px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:TextBox ID="TxtObj" runat="server" CssClass="txt" Height="68px" TextMode="MultiLine"
                                Width="100%"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 14px" class="STitulos">
                            Contratista<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="TxtIde" ErrorMessage="Seleccione Contratista" Width="52px">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 14px">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 141px">
                                        <asp:TextBox ID="TxtIde" runat="server" AutoPostBack="True" CssClass="txt" Width="121px"></asp:TextBox>
                                    </td>
                                    <td style="width: 32px">
                                        <asp:Button ID="BtnBCon" runat="server" CausesValidation="False" Text="..." />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNom" runat="server" CssClass="txt" ReadOnly="True" Width="100%"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="TxtIde_FilteredTextBoxExtender1" runat="server"
                                            Enabled="True" FilterType="Numbers" TargetControlID="TxtIdeRlc" ValidChars="">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="STitulos" colspan="5">
                                        Representante Legal del Contrato<asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                                            runat="server" ControlToValidate="TxtIdeRlc" ErrorMessage="Seleccione Representante Legal"
                                            Width="22px">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 141px">
                                        <asp:TextBox ID="TxtIdeRlc" runat="server" CssClass="txt" Width="119px"></asp:TextBox>
                                    </td>
                                    <td style="width: 32px">
                                        <asp:Button ID="BtnBRlc" runat="server" CausesValidation="False" Text="..." />
                                    </td>
                                    <td>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="TxtIde_FilteredTextBoxExtender" runat="server"
                                            Enabled="True" FilterType="Numbers" TargetControlID="txtide" ValidChars="">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:TextBox ID="TxtNomRlc" runat="server" CssClass="txt" ReadOnly="True" Width="100%"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" valign="top" class="STitulos">
                            Dependencia que Genera la Necesidad<asp:Label ID="Label6" runat="server" ForeColor="Red"
                                Text="*" Width="13px"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" valign="top">
                            <asp:DropDownList ID="CboDep" runat="server" CssClass="txt" DataSourceID="ObjDep"
                                DataTextField="NOM_DEP" DataValueField="COD_DEP" 
                                ToolTip="Dependeica que tiene la necesidad o requerimiento de Contratación">
                                <asp:ListItem>-------------o-----------------</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="STitulos" colspan="3" valign="top">
                            Dependencia a cargo del Proceso Contractual<asp:RequiredFieldValidator ID="RequiredFieldValidator21"
                                runat="server" ControlToValidate="CboDepP" ErrorMessage="Es necesario especificar la Dependencia Delegada">*</asp:RequiredFieldValidator>
                            &nbsp;
                        </td>
                        <td class="STitulos" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" valign="top">
                            <asp:DropDownList ID="CboDepP" runat="server" CssClass="txt" DataSourceID="ObjDepDel"
                                DataTextField="NOM_DEP" DataValueField="COD_DEP" 
                                ToolTip="Dependencia encargada del proceso de Contratación y Minuta">
                                <asp:ListItem>-------------o-----------------</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="STitulos"  colspan="6" valign="top">
                            Dependencia que realizará la Supervisión &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" valign="top">
                            <asp:DropDownList ID="CboDepSup" runat="server" CssClass="txt" DataSourceID="ObjDep"
                                DataTextField="NOM_DEP" DataValueField="COD_DEP" 
                                ToolTip="Dependencia que realizará el Proceso de Seguimiento, Interventoria/Supervisión al Contrato">
                                <asp:ListItem>-------------o-----------------</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        </tr>
                        <tr>
                            <td style="height: 10px" valign="top" colspan="6">
                                <table width="100%">
                                    <tr class="STitulos">
                                        <td>
                                            Valor Total<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                ControlToValidate="TxtVal" ErrorMessage="Valor del Contrato requerido" Height="16px"
                                                Width="16px">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            Aportes Propios<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                ControlToValidate="TxtValProp" ErrorMessage="Aportes Propios Requeridos" Height="16px"
                                                Width="16px">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            Aportes Otros
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadNumericTextBox ID="TxtVal" runat="server" AutoPostBack="True" Culture="es-CO"
                                                Height="19px" Skin="Default" Value="0" Width="125px">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="TxtValProp" runat="server" AutoPostBack="True" Culture="es-CO"
                                                Height="19px" Skin="Default" Value="0" Width="125px">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="TxtValOtros" runat="server" Culture="es-CO" Height="19px"
                                                Skin="Default" Value="0" Width="125px">
                                            </telerik:RadNumericTextBox>
                                            <asp:Label ID="LbMsg" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkAnticipo" runat="server" Text="Pacto Anticipo" Width="100%" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                    </tr>
                    <tr>
                        <td class="STitulos" colspan="6" style="height: 10px;" valign="top">
                            Plazo de Ejecución(días)
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TxtPla"
                                ErrorMessage="Plazo de Ejecución Requerido" Height="16px" Width="16px">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px" valign="top" colspan="6">
                            <asp:UpdatePanel ID="UpdPlazo" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="TxtPla" runat="server" Width="108px"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                    FilterType="Numbers" TargetControlID="TxtPla">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="CboTPlazo" runat="server" AutoPostBack="true" DataSourceID="Tipo_Plazos"
                                                    DataTextField="Nom_Pla" DataValueField="Cod_TPla" Width="92px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtPlazo2" runat="server" Text="0" Width="70px"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                    FilterType="Numbers" TargetControlID="TxtPlazo2">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="CboTPlazo3" runat="server" DataSourceID="ObjTipoPlazo2" DataTextField="Nom_Pla"
                                                    DataValueField="Cod_TPla" Width="92px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ChkAgotarPpto" runat="server" Text="Hasta Agotar Presupuesto" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:ObjectDataSource ID="Tipo_Plazos" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetRecords" TypeName="Tipo_Plazos"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjTipoPlazo2" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetByTipo1" TypeName="Tipo_Plazos">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="CboTPlazo" Name="tipo" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="STitulos" style="height: 15px; ">
                            Modalidad de Contratación
                        </td>
                        <td class="STitulos" style="height: 15px; width: 115px;">
                            N° Proceso
                        </td>
                        <td class="STitulos" style="height: 15px; width: 92px;">
                            Plan.PreContractual
                        </td>
                        <td class="STitulos" colspan="2" style="height: 15px">
                            &nbsp;
                        </td>
                        <td class="STitulos" style="width: 146px; height: 15px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 11px; width: 115px;">
                            <asp:DropDownList ID="CboTproc" runat="server" CssClass="txt" DataSourceID="ObjTipoProc"
                                DataTextField="NOM_TPROC" DataValueField="COD_TPROC" ToolTip="Proceso PreContractual">
                            </asp:DropDownList>
                        </td>
                        <td style="height: 11px; width: 115px;">
                            <asp:TextBox ID="TxtNProc" runat="server" Width="142px"></asp:TextBox>
                        </td>
                        <td style="height: 11px; width: 92px;">
                            <asp:TextBox ID="TxtPlapre" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td colspan="2" style="height: 11px">
                            <asp:CheckBox ID="ChkUM" runat="server" Text="Urgencia Manifiesta" Width="157px"
                                Visible="False" />
                        </td>
                        <td style="width: 146px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 115px; height: 10px" valign="top" class="STitulos">
                            Sector Destino
                        </td>
                        <td class="STitulos" style="width: 115px; height: 10px" valign="top">
                            N° Proyecto
                        </td>
                        <td style="height: 10px" valign="top" class="STitulos" colspan="3">
                            Forma Contractual &nbsp;&nbsp;
                        </td>
                        <td class="STitulos">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 115px; height: 8px" valign="top">
                            <asp:DropDownList ID="CboSec" runat="server" CssClass="txt" DataSourceID="ObjSector"
                                DataTextField="NOM_SEC" DataValueField="COD_SEC">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 115px; height: 8px" valign="top">
                            <asp:TextBox ID="TxtPro" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td style="width: 92px; height: 8px" valign="top">
                            <asp:DropDownList ID="CboFor" runat="server" CssClass="txt" ToolTip="Forma Contractual">
                                <asp:ListItem>CON FORMALIDAD</asp:ListItem>
                                <asp:ListItem>SIN FORMALIDAD</asp:ListItem>
                                <asp:ListItem Selected="True" Value="-----o-----">-------o--------</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" style="height: 8px" valign="top">
                            <asp:CheckBox ID="ChkEC" runat="server" Text="Estudio de Conveniencia" 
                                Visible="False" Width="160px" />
                        </td>
                        <td style="width: 146px">
                        </td>
                    </tr>
                    <tr>
                        <td class="STitulos" style="width: 115px; height: 10px" colspan="2">
                            N° de Empleos
                        </td>
                        <td class="STitulos" style="width: 92px; height: 10px">
                            &nbsp;&nbsp;
                        </td>
                        <td class="STitulos" style="height: 10px" colspan="2">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td style="width: 146px" class="STitulos">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 115px; height: 10px" colspan="2">
                            <asp:TextBox ID="TxtNEmpleos" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="TxtNEmpleos_FilteredTextBoxExtender" runat="server"
                                Enabled="True" FilterType="Numbers" TargetControlID="TxtNEmpleos">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td style="height: 10px" colspan="3">
                            <asp:CheckBox ID="ChkApo" runat="server" Text="Personal de Apoyo" />
                        </td>
                        <td style="width: 146px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 10px" valign="top">
                            <table cellpadding="10" width="100%">
                                <tr class="STitulos">
                                    <td>
                                        MUNICIPIOS Y/O CORREGIMIENTOS
                                    </td>
                                    <td>
                                        CERTIFICADO DE DISPONIBILIDAD PPTAL
                                    </td>
                                    <td>
                                        PROYECTOS
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="DIV1" language="javascript" style="z-index: 101; overflow: auto; width: 237px;
                                            height: 187px; background-color: transparent; border-bottom-style: outset" title="MUNICPIOS">
                                            <asp:DataList ID="DataList1" runat="server" CellPadding="4" CellSpacing="5" CssClass="txt"
                                                DataKeyField="COD_MUN" DataSourceID="ObjConMun" ForeColor="#333333" GridLines="Vertical"
                                                Height="40px" RepeatColumns="1" Width="202px">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <ItemTemplate>
                                                    &nbsp;<asp:CheckBox ID="chknommun" runat="server" Checked='<%# eval("est") %>' Text='<%# Eval("NOM_MUN") %>' />
                                                    <asp:TextBox ID="txtcodmun" runat="server" Text='<%# Eval("COD_MUN") %>' Visible="False"
                                                        Width="197px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <uc2:grdCDPC ID="grdCDPC1" runat="server" Visible="False" />
                                    </td>
                                    <td valign="top">
                                        <uc1:grdProyC ID="grdProyC1" runat="server" Visible="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:LinkButton ID="LnkMiembros" runat="server">Editar Miembros</asp:LinkButton>
                                        <uc5:ConMiembros ID="ConMiembros1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 115px; height: 10px" valign="top" colspan="2">
                        </td>
                        <td colspan="3" style="height: 10px" valign="top">
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 146px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 115px; height: 10px;" valign="top" colspan="2">
                            &nbsp;
                        </td>
                        <td style="height: 10px" valign="top" colspan="3">
                        </td>
                        <td style="width: 146px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 9px">
                            <asp:TextBox ID="TxtCsor" runat="server" Height="60px" TextMode="MultiLine" Width="90%"
                                Visible="False"></asp:TextBox>
                        </td>
                        <td colspan="2" style="height: 9px">
                        </td>
                        <td style="width: 146px; height: 9px">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" colspan="4">
                        </td>
                        <td style="height: 15px; width: 15px;">
                        </td>
                        <td style="width: 146px; height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 15px">
                            &nbsp;&nbsp;
                        </td>
                        <td style="width: 15px; height: 15px">
                        </td>
                        <td style="width: 146px; height: 15px">
                        </td>
                        <td style="height: 15px; margin-left: 40px;">
                        </td>
                    </tr>
                </table>
                    </div>
                <ajaxToolkit:FilteredTextBoxExtender ID="TxtIde_FilteredTextBoxExtender0" runat="server"
                    Enabled="True" FilterType="Numbers" TargetControlID="txtide" ValidChars="">
                </ajaxToolkit:FilteredTextBoxExtender>
                <br />
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="IBtnGuardar" />
            </Triggers>
        </asp:UpdatePanel>
        <!-- Mensaje de Salida-->
        <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup" runat="server">
        </asp:Button>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" BackgroundCssClass="modalBackground"
            BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
            PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" Width="693px" Height="555px" CssClass="ModalPanel2"
            ScrollBars="Auto">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Width="97%" Height="30px"
                CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                    padding-top: 5px">
                    <div style="float: left">
                        Buscar Tercero
                    </div>
                    <div style="float: right" >
                        <input id="hideModalPopupViaClientButton" type="button" value="X"/></div>
                </div>
            </asp:Panel>
            <panel id="pnCuadroInterno" runat="Server" scrollbars="Auto">
                    <uc3:AdmTercero ID="AdmTercero1" runat="server" />
                    <BR />
                </panel>
        </asp:Panel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
            <ProgressTemplate>
                <div class="Loading">
                    <asp:Image ID="ImgAjax" runat="server" SkinID="ImgProgress" />
                    Cargando …
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:ObjectDataSource ID="ObjTipoProc" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="TiposProc"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTiposCont" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Tipos"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjSubTipos" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetByTipo" TypeName="SubTipos">
            <SelectParameters>
                <asp:ControlParameter ControlID="CboTip" Name="cod_tip" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjDep" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Dependencias"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjConMun" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetConMun" TypeName="Contratos">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCodCon" Name="cod_con" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjDepDel" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDelbyUser" TypeName="Dependencias"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjSector" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Sector"></asp:ObjectDataSource>
    </div>
</asp:Content>
