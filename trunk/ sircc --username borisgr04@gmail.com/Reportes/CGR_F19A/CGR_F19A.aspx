<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CGR_F19A.aspx.vb" Inherits="Reportes_CGR_F19A_Default" %>
<%@ Register src="../../CtrlUsr/AdmTercero/AdmTercero.ascx" tagname="AdmTercero" tagprefix="uc3" %>
<%@ Register src="../../CtrlUsr/Terceros/ConsultaTerS.ascx" tagname="ConsultaTerS" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<script type='text/javascript'>
    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        //label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
    // Add click handlers for buttons to show and hide modal popup on pageLoad
    function pageLoad() {
        //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
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

  

    </script>
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    
<table style="background-color: lavender; width: 99%;" cellpadding="5" 
        cellspacing="5" rules="none">
        <tr>
            <td class="Titulos" colspan="4" style="text-align: center">
                DIGITE EL TITULO DEL REPORTE</td>
        </tr>
        <tr>
            <td colspan="4" style="height: 10px; width: 177px; text-align: center;">
                <asp:TextBox ID="txtTitulo" runat="server" Width="600px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Button ID="Generar_Reporte" runat="server" Text="Generar Reporte" /></td>
        </tr>
    </table>
<table cellpadding="2">
        <tr>
            <td class="Titulos" colspan="4">
                ESCOJA LOS CAMPOS DEL FILTRO DE CONTRATOS</td>
            <td class="Titulos">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:CheckBox ID="ChkVig" runat="server" Text="Vigencia" Font-Bold="False" /></td>
            <td style="width: 126px">
            </td>
            <td style="width: 150px">
            </td>
            <td style="width: 161px">
            </td>
            <td style="width: 161px">
                Agrupar por</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:TextBox ID="TxtVig" runat="server"></asp:TextBox>
            </td>
            <td style="width: 126px">
            </td>
            <td style="width: 150px">
                <asp:CheckBox ID="ChkAnul" runat="server" Font-Bold="False" 
                    Text="Incluir Anulados" />
            </td>
            <td style="width: 161px">
                &nbsp;</td>
            <td style="width: 161px">
                <asp:CheckBox ID="ChkGDep" runat="server" Text="Dependencias" />
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:CheckBox ID="ChkNum" runat="server" Text="Nº Contrato" Font-Bold="False" /></td>
            <td style="width: 126px">
                <asp:CheckBox ID="chkTip" runat="server" Text="Tipo Contrato" Font-Bold="False" /></td>
            <td style="width: 150px">
                <asp:CheckBox ID="ChkStip" runat="server" Text="SubTipo" Font-Bold="False" /></td>
            <td style="width: 161px">
                </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 21px" valign="top">
                <asp:TextBox ID="TxtNCon" runat="server"></asp:TextBox>
            </td>
            <td style="width: 126px; height: 21px" valign="top">
                <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" DataSourceID="ObjTiposCont"
                    DataTextField="NOM_TIP" DataValueField="COD_TIP" Font-Size="8pt">
                </asp:DropDownList></td>
            <td style="height: 21px" valign="top" colspan="2">
                <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
<asp:DropDownList id="cboStip" runat="server" Font-Size="8pt" DataValueField="COD_STIP" 
                            DataTextField="NOM_STIP" DataSourceID="ObjSubTipos" __designer:wfdid="w9">
                </asp:DropDownList> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="CboTip" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>&nbsp;</td>
            <td style="height: 21px" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 24px" valign="top">
                <asp:CheckBox ID="ChkFecSus" runat="server" Text="Fecha de Suscripción" ToolTip="Fecha de Suscripción del Contrato" Width="208px" Font-Bold="False" /></td>
            <td style="width: 150px; height: 24px" valign="top">
            </td>
            <td style="width: 161px; height: 24px" valign="top">
            </td>
            <td style="width: 161px; height: 24px" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 24px" valign="top">
                <asp:TextBox ID="TxtFecSus1" runat="server"></asp:TextBox>
            </td>
            <td colspan="2" style="height: 24px" valign="top">
                <asp:TextBox ID="TxtFecSus2" runat="server"></asp:TextBox>
            </td>
            <td style="width: 161px; height: 24px" valign="top">
            </td>
            <td style="width: 161px; height: 24px" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 24px" valign="top">
                <asp:CheckBox ID="ChkFecR" runat="server" Text="Fecha de Registro" ToolTip="Fecha de Suscripción del Contrato" Width="208px" Font-Bold="False" /></td>
            <td colspan="2" style="height: 24px" valign="top">
            </td>
            <td style="width: 161px; height: 24px" valign="top">
            </td>
            <td style="width: 161px; height: 24px" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 24px" valign="top">
                <asp:TextBox ID="TxtFecReg1" runat="server"></asp:TextBox>
            </td>
            <td colspan="2" style="height: 24px" valign="top">
                <asp:TextBox ID="TxtFecReg2" runat="server"></asp:TextBox>
            </td>
            <td style="width: 161px; height: 24px" valign="top">
            </td>
            <td style="width: 161px; height: 24px" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:CheckBox ID="ChkEst" runat="server" Text="Estado" Font-Bold="False" /></td>
            <td style="width: 126px">
                </td>
            <td colspan="2">
                <asp:CheckBox ID="ChkDep" runat="server" 
                    Text="Dependencia que Genera la Necesidad" Font-Bold="False" /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:DropDownList ID="CboEst" runat="server" Font-Size="8pt">
                </asp:DropDownList></td>
            <td style="width: 126px">
                </td>
            <td colspan="2">
                <asp:DropDownList ID="CboDep" runat="server" DataSourceID="ObjDep" DataTextField="NOM_DEP"
                    DataValueField="COD_DEP" Font-Size="8pt">
                </asp:DropDownList></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                &nbsp;</td>
            <td style="width: 126px">
                &nbsp;</td>
            <td colspan="2">
                <asp:CheckBox ID="ChkPDep" runat="server" Font-Bold="False" 
                    Text="Dependencia a cargo del proceso" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                &nbsp;</td>
            <td style="width: 126px">
                &nbsp;</td>
            <td colspan="2">
                <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                    DataTextField="NOM_DEP" DataValueField="COD_DEP" Font-Size="8pt">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                </td>
            <td style="width: 126px"><asp:CheckBox ID="ChkSec" runat="server" Text="Sector Destino" Font-Bold="False" /></td>
            <td style="width: 150px"><asp:CheckBox ID="ChkProy" runat="server" Text="Proyecto" Font-Bold="False" /></td>
            <td style="width: 161px">
            </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                </td>
            <td style="width: 126px">
                <asp:DropDownList ID="Cbosec" runat="server" DataSourceID="ObjSector"
                    DataTextField="NOM_SEC" DataValueField="COD_SEC" Font-Size="8pt">
            </asp:DropDownList>
            </td>
            <td style="width: 150px">
                <asp:TextBox ID="Proyecto" runat="server"></asp:TextBox></td>
            <td style="width: 161px">
                </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:CheckBox ID="ChkCon" runat="server" Text="Constratista" Font-Bold="False" /></td>
            <td style="width: 126px">
            </td>
            <td style="width: 150px">
                </td>
            <td style="width: 161px">
            </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:TextBox ID="TxtIde" runat="server" Font-Size="8pt"></asp:TextBox>&nbsp;<asp:Button ID="BtnBCon" 
                    runat="server" CausesValidation="False" 
                    Text="..." />
            </td>
            <td style="width: 126px">
                <asp:TextBox ID="TxtNom" runat="server" ReadOnly="True" Width="200px" Font-Size="8pt"></asp:TextBox></td>
            <td style="width: 150px">
                </td>
            <td style="width: 161px">
                </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:CheckBox ID="ChkInt" runat="server" Text="Interventor" Font-Bold="False" /></td>
            <td style="width: 126px">
            </td>
            <td style="width: 150px">
            </td>
            <td style="width: 161px">
            </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:TextBox ID="TxtIdeInt" runat="server" Font-Size="8pt"></asp:TextBox>
                <asp:Button ID="BtnBInt" runat="server" CausesValidation="False" Text="..." />
            </td>
            <td style="width: 126px">
                <asp:TextBox ID="TxtNomInt" runat="server" ReadOnly="True" Width="200px" Font-Size="8pt"></asp:TextBox></td>
            <td style="width: 150px">
            </td>
            <td style="width: 161px">
            </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:CheckBox ID="ChkProc" runat="server" Text="Tipo de Proceso" Font-Bold="False" /></td>
            <td style="width: 126px">
            </td>
            <td style="width: 150px">
            </td>
            <td style="width: 161px">
            </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:DropDownList ID="CboTproc" runat="server" CssClass="txt" DataSourceID="ObjTipoProc"
                    DataTextField="NOM_TPROC" DataValueField="COD_TPROC" 
                    ToolTip="Proceso Precontractual">
                </asp:DropDownList></td>
            <td style="width: 126px">
            </td>
            <td style="width: 150px">
            </td>
            <td style="width: 161px">
            </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 10px">
                <asp:CheckBox ID="ChkPla" runat="server" Text="Planeación Precontractual" Font-Bold="False" /></td>
            <td style="width: 126px; height: 10px">
                <asp:CheckBox ID="ChkValC" runat="server" Text="Valor del Contrato/Convenio" Width="197px" Font-Bold="False" /></td>
            <td style="width: 150px; height: 10px">
            </td>
            <td style="width: 161px; height: 10px">
            </td>
            <td style="width: 161px; height: 10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 10px">
                <asp:TextBox ID="txtPla" runat="server"></asp:TextBox></td>
            <td style="width: 126px; height: 10px">
                De:<asp:TextBox ID="TxtValC1" runat="server"></asp:TextBox></td>
            <td style="width: 150px; height: 10px">
                Hasta:<asp:TextBox ID="TxtValC2" runat="server"></asp:TextBox></td>
            <td style="width: 161px; height: 10px">
            </td>
            <td style="width: 161px; height: 10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 10px">
                <asp:CheckBox ID="ChkRubros" runat="server" Text="Rubro Presupuestal" Font-Bold="False" /></td>
            <td style="width: 126px; height: 10px">
            </td>
            <td style="width: 150px; height: 10px">
            </td>
            <td style="width: 161px; height: 10px">
            </td>
            <td style="width: 161px; height: 10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 9px">
                <asp:TextBox ID="TxtRub" runat="server" CssClass="txt" Width="103px"></asp:TextBox>
                <input id="BtnRubros" onclick="return BtnRubros_onclick('conRubros2.aspx')" style="height: 21px"
                    title="Asignar Rubros" type="button" value="..." /></td>
            <td style="width: 126px; height: 9px">
                <asp:TextBox ID="TxtDesp" runat="server" CssClass="txt" Enabled="False" Width="148px"></asp:TextBox></td>
            <td style="width: 150px; height: 9px">
            </td>
            <td style="width: 161px; height: 9px">
            </td>
            <td style="width: 161px; height: 9px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 10px">
                <asp:CheckBox ID="ChkObj" runat="server" Text="Objeto" Font-Bold="False" /></td>
            <td style="width: 126px; height: 10px">
            </td>
            <td style="width: 150px; height: 10px">
            </td>
            <td style="width: 161px; height: 10px">
            </td>
            <td style="width: 161px; height: 10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="height: 10px">
                <asp:TextBox ID="TxtObj" runat="server" TextMode="MultiLine" Width="600px"></asp:TextBox></td>
            <td style="height: 10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 10px;">
                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox></td>
            <td style="width: 126px; height: 10px;">
                &nbsp;</td>
            <td style="width: 150px; height: 10px;">
                </td>
            <td style="width: 161px; height: 10px;">
                </td>
            <td style="width: 161px; height: 10px;">
                &nbsp;</td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> 
<ajaxToolkit:ModalPopupExtender id="ModalPopup" 
runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
            </ajaxToolkit:ModalPopupExtender> 
            <asp:Panel id="programmaticPopup" runat="server" Width="800px" Height="600px" CssClass="ModalPanel2" ScrollBars="Auto" >
            <asp:Panel id="programmaticPopupDragHandle" runat="Server" Width="97%" Height="30px" CssClass="BarTitleModal2" >
            <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
            <DIV style="FLOAT: left">
                Buscar Tercero </DIV>
             <DIV style="FLOAT: right" __designer:dtid="1407383473487880"  >
            <INPUT id="hideModalPopupViaClientButton" type=button value="X" __designer:dtid="1407383473487881" /></DIV></DIV></asp:Panel>
                <panel id="pnCuadroInterno" runat="Server" ScrollBars="Auto" >
                    
                    <BR />

                    <uc1:ConsultaTerS ID="ConsultaTerS1" runat="server" />
                </panel>
              </asp:Panel> 
            
     <asp:ObjectDataSource ID="ObjTipoProc" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="TiposProc"></asp:ObjectDataSource>
            
    <asp:ObjectDataSource ID="ObjTiposCont" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Tipos"></asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="ObjSubTipos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByTipo" 
            TypeName="SubTipos">
            <SelectParameters>
                <asp:ControlParameter ControlID="CboTip" Name="cod_tip" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjDep" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Dependencias"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbyUser" 
            TypeName="Dependencias" >
            </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjSector" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Sector">
    </asp:ObjectDataSource>
</div>
</asp:Content>

