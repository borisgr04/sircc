<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HContratos.aspx.vb" Inherits="DatosBasicos_CSUT_Default" %>

<%@ Register src="../../CtrlUsr/Consorcios/ConsultaCONUT.ascx" tagname="ConsultaCONUT" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/Terceros/ConsultaTer.ascx" tagname="ConsultaTer" tagprefix="uc2" %>

<%@ Register src="../../CtrlUsr/DetContratos/DetContrato.ascx" tagname="DetContrato" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea"> 
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" 
                Text="Auditoria Contratos"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<ajaxToolkit:ToolkitScriptManager 
                ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
            </ajaxToolkit:ToolkitScriptManager>
            <br />
            <br />
            <uc3:DetContrato ID="DetContrato2" runat="server" />
            <br />
            <br />
            <!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->
            <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjHContratos" 
                EnableModelValidation="True">
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjHContratos" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetHContratos" 
                TypeName="Contratos">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DetContrato2" Name="Cod_Con" 
                        PropertyName="Cod_Con" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
</contenttemplate>
    </asp:UpdatePanel>

    </div>
</asp:Content>

