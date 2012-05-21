<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ReportF19a.aspx.vb" Inherits="Reportes_CGR_F19A_Report" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" 
namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxtoolkit:toolkitscriptmanager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Rpt\RptConsTCtF19A_2011.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjRptContratos" Name="VCONTRATOSC_A" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

      
        
        <asp:ObjectDataSource ID="ObjRptContratos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GenerarReport" 
            TypeName="Reportes">
            <SelectParameters>
                <asp:QueryStringParameter Name="Sql" QueryStringField="Sql" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

      
        
        <asp:TextBox ID="TxtSql" runat="server" ReadOnly="True" TextMode="MultiLine" Width="945px"></asp:TextBox>&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Actualizar Reporte" /><br />
    
</div>
</asp:Content>

