<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdmTercero.ascx.vb" Inherits="CtrlUsr_AdmTercero_AdmTercero" %>

<%@ Register src="../Terceros/ConsultaTer2.ascx" tagname="consultater2" tagprefix="uc3" %>
<%@ Register src="../CrTerceros/CrTerceros.ascx" tagname="crterceros" tagprefix="uc1" %>
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    
        <asp:View ID="View1" runat="server">
<uc3:ConsultaTer2 ID="ConsultaTer21" runat="server" OnSelClicked="ConsultaTer21_SelClicked" OnEditClicked="ConsultaTer21_EditClicked" OnNuevoClicked="ConsultaTer21_OnNuevoClicked" />
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table class="style1">
                <tr>
                    <td style="text-align: right">
                        <asp:Button ID="BtnVoler" runat="server" Text="Volver" CausesValidation="False" 
                            ValidationGroup="NOVALIDAR" />
                    </td>
                </tr>
            </table>
        <uc1:CrTerceros ID="CrTerceros1" runat="server"   />
            
</asp:View>
        </asp:MultiView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="BtnVoler" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
