<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PContratosCord.aspx.vb" Inherits="Consultas_Pcontratos_PContratosCord" %>

<%@ Register src="../../CtrlUsr/FiltroSol/FiltroSolP.ascx" tagname="FiltroSolP" tagprefix="uc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register src="../../CtrlUsr/FiltroPCon/FiltroPConP.ascx" tagname="FiltroPConP" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

     <div class="demoheading">REPORTE DE PROCESOS X DELEGACIÓN</div>
        
        <uc2:FiltroPConP ID="FiltroPConP1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="924px">
                    <LocalReport ReportPath="PReportes\PContratos\RptPCont.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjPCont" Name="DsPCont" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:HiddenField ID="ValFiltro" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="FiltroPConP1" EventName="FiltrarClicked" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <asp:ObjectDataSource ID="ObjPCont" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecordsRep" 
            TypeName="Con_PContratos" InsertMethod="InsertP">
          <SelectParameters>
                <asp:ControlParameter ControlID="ValFiltro" Name="Filtro" PropertyName="Value" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />

     </div>
</asp:Content>