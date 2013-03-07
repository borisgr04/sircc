<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="recep.aspx.vb" Inherits="GPagosTerceros_Radicacion_recep" %>

<%@ Register src="../../Interventorias/CtrlUsr/DetContratosI/DetContratoI.ascx" tagname="DetContratoI" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
     <asp:HiddenField ID="hdCodCon" runat="server" />
    <div style="overflow:auto; height:130px">
    <uc1:DetContratoI ID="DetContratoI1" runat="server" />
    </div>
    <br />
    <asp:Panel ID="Panel1" runat="server">
    <fieldset>
    <legend>Radicar Documento</legend>
        <table style="width: 100%">
            <tr>
                <td style="width: 97px; text-align: center">
                    <asp:ImageButton ID="IBtnVerDoc" runat="server" SkinID="IBtnEditBase" />
                </td>
                <td style="width: 174px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="MsgResult" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 97px; text-align: center">
                    Ver Documento</td>
                <td style="width: 174px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 97px">
                    Fecha</td>
                <td style="width: 174px">
                    <asp:TextBox ID="TxtRad" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="IBtnGuardar" runat="server" SkinID="IBtnGuardar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </fieldset>
    </asp:Panel>
</asp:Content>

