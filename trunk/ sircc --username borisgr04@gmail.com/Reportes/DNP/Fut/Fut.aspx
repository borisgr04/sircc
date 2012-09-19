<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Fut.aspx.vb" Inherits="Reportes_DNP_FUT" %>
<%@ Register src="../../../CtrlUsr/AdmTercero/AdmTercero.ascx" tagname="AdmTercero" tagprefix="uc3" %>
<%@ Register src="../../../CtrlUsr/Terceros/ConsultaTerS.ascx" tagname="ConsultaTerS" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    
    
<table style="width: 99%;" cellpadding="5" 
        cellspacing="5" rules="none">
        <%--<tr>
            <td class="Titulos" colspan="4" style="text-align: center">
                DIGITE EL TITULO DEL REPORTE</td>
        </tr>
        <tr>
            <td colspan="4" style="height: 10px; width: 177px; text-align: center;">
                <asp:TextBox ID="txtTitulo" runat="server" Width="600px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>--%>
        <tr>
        <td colspan="4">
        <asp:Label id="Tit" runat="server" CssClass="Titulo" > REPORTE FUT REGALIAS </asp:Label>
        </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                &nbsp;<asp:ImageButton ID="IBtnExportExcel" runat="server" SkinID="IBtnExcel" />
                <br />
                Exportar<br />
                <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
            </td>
        </tr>
    </table>
<table cellpadding="2">
        <tr>
            <td class="STitulos" colspan="4" >
                ESCOJA LOS CAMPOS DEL FILTRO DE CONTRATOS</td>
        </tr>
        <tr>
            <td style="width: 177px">
                <asp:CheckBox ID="ChkVig" runat="server" Text="Vigencia" Font-Bold="False" /></td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                <asp:Label ID="msgSug" runat="server"></asp:Label>
            </td>
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
                            DataTextField="NOM_STIP" DataSourceID="ObjSubTipos" >
                </asp:DropDownList> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="CboTip" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 24px" valign="top">
                <asp:CheckBox ID="ChkFecSus" runat="server" Text="Fecha de Suscripción" 
                    ToolTip="Fecha de Suscripción del Contrato" Width="133px" Font-Bold="False" 
                    Checked="True" /></td>
            <td style="width: 150px; height: 24px" valign="top">
                <asp:CheckBox ID="ChkEst" runat="server" Font-Bold="False" Text="Estado" />
            </td>
            <td style="width: 161px; height: 24px" valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 177px; height: 24px" valign="top">
                Desde
                <asp:TextBox ID="TxtFecSus1" runat="server"></asp:TextBox>
                <cc1:CalendarExtender 
                            ID="CalTxtFecSus1" 
                            runat="server" 
                            TargetControlID="TxtFecSus1" 
                            Format="dd/MM/yyyy"> 
                            </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TxtFecSus1" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td style="height: 24px" valign="top">
                Hasta<asp:TextBox ID="TxtFecSus2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TxtFecSus2" ErrorMessage="*"></asp:RequiredFieldValidator>
                <cc1:CalendarExtender 
                            ID="CalTxtFecSus2" 
                            runat="server" 
                            TargetControlID="TxtFecSus2" 
                            Format="dd/MM/yyyy"> 
                            </cc1:CalendarExtender>
            </td>
            <td colspan="2" style="height: 24px" valign="top">
                <asp:DropDownList ID="CboEst" runat="server" DataSourceID="ObjEstActas" 
                    DataTextField="nom_est" DataValueField="cod_est" Font-Size="8pt">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 24px" valign="top">
                <asp:CheckBox ID="ChkDep" runat="server" Font-Bold="False" 
                    Text="Dependencia que Genera la Necesidad" />
            </td>
            <td style="width: 161px; height: 24px" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 24px;" colspan="3" valign="top">
                <asp:DropDownList ID="CboDep" runat="server" DataSourceID="ObjDep" 
                    DataTextField="NOM_DEP" DataValueField="COD_DEP" Font-Size="8pt">
                </asp:DropDownList>
            </td>
            <td style="width: 161px; height: 24px;" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="height: 24px" valign="top">
                <asp:CheckBox ID="ChkPDep" runat="server" Font-Bold="False" 
                    Text="Dependencia a cargo del proceso" />
            </td>
            <td style="width: 161px; height: 24px" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="height: 24px" valign="top">
                <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                    DataTextField="NOM_DEP" DataValueField="COD_DEP" Font-Size="8pt">
                </asp:DropDownList>
            </td>
            <td style="width: 161px; height: 24px" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px">
                &nbsp;</td>
            <td style="width: 126px">
            </td>
            <td style="width: 150px">
                </td>
            <td style="width: 161px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 177px; height: 10px;">
                &nbsp;</td>
            <td style="width: 126px; height: 10px;">
                &nbsp;</td>
            <td style="width: 150px; height: 10px;">
                &nbsp;</td>
            <td style="width: 161px; height: 10px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="height: 10px;">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjContratosF20" 
                    EnableModelValidation="True" EnableTheming="False" SkinID="SinFormato" >
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjContratosF20" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetSql" 
        TypeName="Reportes">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdSql" Name="cSql" PropertyName="Value" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
            </td>
        </tr>
    </table>

    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="IBtnExportExcel" />
        </Triggers>
    </asp:UpdatePanel>
    
    
    <div style="visibility:hidden" >
        <asp:HiddenField ID="HdSql" runat="server" />
        </div>
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

                <asp:ObjectDataSource ID="ObjEstActas" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                    TypeName="EstadosC"></asp:ObjectDataSource>

</div>
</asp:Content>

