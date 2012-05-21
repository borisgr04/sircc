<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReportIP.aspx.vb" Inherits="Reportes_Parametrizado_ReportI" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" 
namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="demoarea">
   <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxtoolkit:toolkitscriptmanager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <input id="htmlBtnAtras" type="button" value="Ir Atrás" onclick="javascript:history.back()" />&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Actualizar Reporte" /><rsweb:ReportViewer 
            ID="ReportViewer1" runat="server" Width="100%" 
            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" 
            Height="600px">
            <LocalReport ReportPath="Rpt\RptConsTCt2011.rdlc">
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
        <br />
</ContentTemplate>
          
        </asp:UpdatePanel>     
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                AssociatedUpdatePanelID="UpdatePanel1">
                <progresstemplate>
                    <div class="Loading">
                        <asp:Image ID="ImgAjax" runat="server" SkinID="ImgProgress" />
                        Cargando …
                    </div>
                </progresstemplate>
            </asp:UpdateProgress> 
    </div>
    </form>
</body>
</html>
