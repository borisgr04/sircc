<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptSireci.aspx.vb" Inherits="Reportes_Sireci_RptSireci" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <br />
    <h2>
        GENERACION DE INFORME DE SIRECI</h2>
    <br />
    &nbsp;&nbsp; Fecha Inicial 
    <asp:TextBox ID="TxtFecIni" runat="server">01/01/2013</asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="TxtFecIni_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="TxtFecIni">
    </ajaxToolkit:CalendarExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TxtFecIni" ErrorMessage="*"></asp:RequiredFieldValidator>
    Fecha Final
    <asp:TextBox ID="TxtFecFin" runat="server">31/12/2013</asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="TxtFecFinCalendarExtender1" runat="server" 
        Enabled="True" TargetControlID="TxtFecFin">
    </ajaxToolkit:CalendarExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TxtFecFin" ErrorMessage="*"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<rsweb:ReportViewer ID="ReportViewer1" runat="server" 
        Font-Names="Verdana" Font-Size="8pt" Height="617px" 
        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Width="925px">
        <LocalReport ReportPath="Informes4\Sireci\ReportContSireci.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetInfSireci" 
        TypeName="RptSireci">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFecIni" DefaultValue="01/01/2013" 
                Name="Fec_ini" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TxtFecFin" DefaultValue="31/12/2013" 
                Name="Fec_Fin" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>

