<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ReportPMesDepClas.aspx.vb" Inherits="Reportes_Mes_ReportPMesDepClas" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" 
namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxtoolkit:toolkitscriptmanager>
        &nbsp;
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="800px">
            <LocalReport ReportPath="Rpt\EstMes\RptMesDepClase.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjMesDepClase" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjMesDepClase" runat="server" 
            SelectMethod="GetMesDepClase" TypeName="RptEstMes">
            <SelectParameters>
                <asp:Parameter DefaultValue="2012" Name="vigencia" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    
</div>
</asp:Content>

