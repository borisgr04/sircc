<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt.aspx.vb" Inherits="Consultas_Contraloria_Formato19_Rpt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="demoarea">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Consultas/Contraloria/Formato19/ParametrizadoF19.aspx">Atrás</asp:HyperLink>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="Rpt\RptF19.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="Objf20" Name="DsF19" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="Objf20" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GenerarReportF19" 
            TypeName="Reportes">
            <SelectParameters>
                <asp:QueryStringParameter Name="RSql" QueryStringField="sql" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
