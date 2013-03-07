<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Formato19.aspx.vb" Inherits="Consultas_Formato19" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register src="../../../CtrlUsr/FiltroPCon/FiltroPConE.ascx" tagname="FiltroPConE" tagprefix="uc3" %>

<%@ Register src="../../../CtrlUsr/FiltroPCon/FiltroPConP.ascx" tagname="FiltroPConP" tagprefix="uc1" %>

<%@ Register src="../../../CtrlUsr/FiltroCon/FiltroCon.ascx" tagname="FiltroCon" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

     <div class="demoheading">REPORTE CONTRALORIA FORMATO 20</div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <uc2:FiltroCon ID="FiltroCon1" runat="server" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="924px">
                    <LocalReport ReportPath="Rpt\RptF20.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjPCont" Name="DsF20" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:HiddenField ID="ValFiltro" runat="server" />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="ObjPCont" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GenerarReportF19" 
            TypeName="Reportes">
            <SelectParameters>
                <asp:ControlParameter ControlID="ValFiltro" Name="RSql" PropertyName="Value" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />

     </div>
</asp:Content>