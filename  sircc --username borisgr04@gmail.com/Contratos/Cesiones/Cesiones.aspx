<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Cesiones.aspx.vb" Inherits="Contratos_Cesiones_Default" %>

<%@ Register src="../../CtrlUsr/DetContratos/DetContrato.ascx" tagname="DetContrato" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/AdmTercero/AdmTercero.ascx" tagname="admtercero" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

<uc1:DetContrato ID="DetContrato1" runat="server" />
<br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table ID="TABLE1">
                <tr>
                    <td class="Titulos" colspan="2" style="text-align: center">
                        CESIÓN DE CONTRATOS</td>
                    <td class="Titulos" style="text-align: center; width: 33px;">
                        &nbsp;</td>
                    <td class="Titulos" style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 21px">
                        <asp:Label ID="MsgResult" runat="server" Height="30px" Visible="False" 
                            Width="90%"></asp:Label>
                    </td>
                    <td style="height: 21px; width: 33px;">
                        &nbsp;</td>
                    <td style="height: 21px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 21px">
                        Fecha Cesión</td>
                    <td style="height: 21px">
                        <asp:TextBox ID="TxtFecCes" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="TxtFecCes_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="TxtFecCes">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                    <td style="height: 21px; width: 33px;">
                        &nbsp;</td>
                    <td style="height: 21px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 19px">
                        Plazo Ejecución</td>
                    <td style="width: 118px; height: 19px">
                        <asp:TextBox ID="TxtPla" runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="TxtPla_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtPla">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td style="width: 33px; height: 19px">
                        &nbsp;</td>
                    <td style="width: 122px; height: 19px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 19px">
                        Valor</td>
                    <td style="width: 118px; height: 19px">
                        <asp:TextBox ID="TxtVal" runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="TxtVal_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtVal">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td style="width: 33px; height: 19px">
                        &nbsp;</td>
                    <td style="width: 122px; height: 19px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 19px">
                        Resolución</td>
                    <td style="width: 118px; height: 19px">
                        <asp:TextBox ID="TxtRes" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 33px; height: 19px">
                        &nbsp;</td>
                    <td style="width: 122px; height: 19px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 19px">
                        Fecha de Resolución</td>
                    <td style="width: 118px; height: 19px">
                        <asp:TextBox ID="TxtFecRes" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="TxtFecRes_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="TxtFecRes">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                    <td style="width: 33px; height: 19px">
                        &nbsp;</td>
                    <td style="width: 122px; height: 19px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100px; ">
                        Nuevo Contratista</td>
                    <td>
                        <asp:TextBox ID="TxtIde" runat="server"></asp:TextBox>
                        &nbsp;</td>
                    <td style="width: 33px">
                        <asp:Button ID="Button1" runat="server" Text="..." />
                    </td>
                    <td>
                        <asp:TextBox ID="TxtNom" runat="server" Width="275px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 21px">
                    </td>
                    <td style="width: 118px; height: 21px">
                        &nbsp;</td>
                    <td style="width: 33px; height: 21px">
                        &nbsp;</td>
                    <td style="width: 122px; height: 21px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 21px; text-align: center">
                        &nbsp;<asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" />
                    </td>
                    <td style="height: 21px; text-align: center; width: 33px;">
                        &nbsp;</td>
                    <td style="height: 21px; text-align: center">
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" 
                            BackgroundCssClass="modalBackground" 
                            BehaviorID="programmaticModalPopupBehavior" DropShadow="True" 
                            PopupControlID="programmaticPopup" 
                            PopupDragHandleControlID="programmaticPopupDragHandle" 
                            RepositionMode="RepositionOnWindowScroll" TargetControlID="Button6">
                        </ajaxToolkit:ModalPopupExtender>
    <asp:Button style="DISPLAY: none" id="Button6" runat="server"></asp:Button>
            <asp:Panel id="programmaticPopup" runat="server" Width="800px" Height="600px" CssClass="ModalPanel2" ScrollBars="Auto" >
            <asp:Panel id="programmaticPopupDragHandle" runat="Server" Width="100%" 
                    Height="33px" CssClass="BarTitleModal2" >
            <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
            <DIV style="FLOAT: left">
                Buscar Tercero </DIV>
             <DIV style="FLOAT: right" __designer:dtid="1407383473487880"  >
                 <asp:Button ID="Button2" runat="server" Text="X" />
                </DIV></DIV></asp:Panel>
                <panel id="pnCuadroInterno" runat="Server" ScrollBars="Auto" >
                    <uc3:AdmTercero ID="AdmTercero1" runat="server" />
                    <BR />
                </panel>
              </asp:Panel> 
    </div>
</asp:Content>

