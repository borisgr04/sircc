<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="EdContratos.aspx.vb" Inherits="Contratos_EdContratos_EdContratos" %>

<%@ Register Src="~/CtrlUsr/DetContratos/DetContratoD.ascx" TagName="DetContrato"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <div class="demoarea">
        <br />
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
                    Text="MODIFICAR FECHA SUSCRIPCIÓN DE CONTRATOS"></asp:Label>
                <uc1:DetContrato ID="DetContrato1" runat="server" />
                <br />
                <asp:Panel ID="Panel1" runat="server"  Visible="False"  >

                    <br />
                    &nbsp;&nbsp;<asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 157px">
                                <asp:Label ID="Label2" runat="server" Text="Nueva Fecha de Suscripción"></asp:Label>
                            </td>
                            <td style="width: 169px">
                                <asp:TextBox ID="TxtFecSusCon" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="TxtFecSusCon_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtFecSusCon">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td style="width: 59px; text-align: center">
                                <asp:ImageButton ID="IBtnGuardar" runat="server" SkinID="IBtnGuardar" />
                            </td>
                            <td style="width: 51px; text-align: center">
                                <asp:ImageButton ID="IBtnCancelar" runat="server" SkinID="IBtnCancelar" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 157px">
                                &nbsp;</td>
                            <td style="width: 169px">
                                &nbsp;</td>
                            <td style="width: 59px; text-align: center">
                                Guadar</td>
                            <td style="width: 51px; text-align: center">
                                Cancelar</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 157px">
                                Fecha Minima Válida</td>
                            <td style="width: 169px">
                                <asp:Label ID="LbFS_Ant" runat="server"></asp:Label>
                            </td>
                            <td style="width: 59px">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 157px">
                                Fecha Máxima Válida</td>
                            <td style="width: 169px">
                                <asp:Label ID="lbFS_Sig" runat="server"></asp:Label>
                            </td>
                            <td style="width: 59px">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                    </table>

                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
