<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ExImpC.ascx.vb" Inherits="CtrlUsr_ExImpC_ExImpC" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>

<table class="style1">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Exonerado de Impuestos"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="ChkExo" runat="server" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td valign="top">
            <asp:Label ID="Label2" runat="server" Text="Observación"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtObsExo" runat="server" Height="85px" TextMode="MultiLine" 
                ToolTip="Escriba la Soporte y los impuestos que se van a exonerar" 
                Width="371px"></asp:TextBox>
        </td>
        <td valign="top">
            Escriba el número de la resolución de exoneración, impuestos exonerados y toda 
            información de soporte del acto administrativo.</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGuardarEx" runat="server" OnClick="BtnGuardarEx_Click" 
                Text="Guardar" ValidationGroup="EXOIMP" />
        </td>
        <td style="text-align: center">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

        </td>
        <td style="text-align: center">
            &nbsp;</td>
    </tr>
</table>

