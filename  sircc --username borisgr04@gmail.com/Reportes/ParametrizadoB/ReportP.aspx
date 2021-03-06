﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ReportP.aspx.vb" Inherits="Reportes_ParametrizadoB_ReportP" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" 
namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxtoolkit:toolkitscriptmanager>
        <asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" > REPORTE PARAMETRIZADO </asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Reportes/ParametrizadoB/Parametrizado.aspx">Volver</asp:HyperLink>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Rpt/RptB/RptConsTCt2013.rdlc">
                
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjRptContratos" Name="DataSet1" />
                </DataSources>
            </LocalReport>
            
        </rsweb:ReportViewer>
        
        <asp:ObjectDataSource ID="ObjRptContratos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GenerarReportB" 
            TypeName="RptContratosB">
            <SelectParameters>
                <asp:QueryStringParameter Name="Sql" QueryStringField="Sql" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

      
        
        <asp:TextBox ID="TxtSql" runat="server" ReadOnly="True" TextMode="MultiLine" Width="945px"></asp:TextBox>&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Actualizar Reporte" /><br />
    
</div>
</asp:Content>

