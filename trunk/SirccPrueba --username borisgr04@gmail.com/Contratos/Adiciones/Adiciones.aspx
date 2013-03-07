<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Adiciones.aspx.vb" Inherits="Contratos_Adiciones_Default" %>

<%@ Register src="../../CtrlUsr/DetContratos/DetContratoL.ascx" tagname="DetContrato" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/grdAdiC/grdAdiC.ascx" tagname="grdAdiC" tagprefix="uc2" %>
<%@ Register Src="../../CtrlUsr/Progreso/Progress.ascx" TagName="Progress" TagPrefix="ucProg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

                <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
                    Text="MODIFICATORIOS / ADICIONES"></asp:Label>

    <asp:UpdatePanel ID="UpdAdi" runat="server">
    <ContentTemplate>
    <uc1:DetContrato ID="DetContrato1" runat="server" OnAceptarClicked="DetContrato1_OnAceptarClicked" />
    <uc2:grdAdiC ID="grdAdiC1" runat="server" Visible="false" />
    </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdateProgress ID="UpdPrgAdi" runat="server" AssociatedUpdatePanelID="UpdAdi">
            <ProgressTemplate>
                <ucProg:Progress ID="Progress1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>

</div>
</asp:Content>

