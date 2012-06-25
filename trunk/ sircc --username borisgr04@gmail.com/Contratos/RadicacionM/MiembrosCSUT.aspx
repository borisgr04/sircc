<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MiembrosCSUT.aspx.vb" Inherits="Contratos_RadicacionM_MiembrosCSUT" %>

<%@ Register src="../../CtrlUsr/ConsorciosUT/ConsorciosUT.ascx" tagname="ConsorciosUT" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

        <asp:Button ID="BtnVolver" runat="server" Text="Volver" />
    <uc4:ConsorciosUT ID="ConsorciosUT1" runat="server" />

</asp:Content>

