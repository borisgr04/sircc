<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="InfAdicones.aspx.vb" Inherits="Informes4_Adiciones_InfAdicones" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <br />
    <h2>
        GENERACIÓN DE INFORME DE ADICONES</h2>
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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" 
        Font-Names="Verdana" Font-Size="8pt" Height="617px" 
        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Width="925px">
        <LocalReport ReportPath="Informes4\Adiciones\RptAdiciones.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjAdiciones" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjAdiciones" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAdiciones" 
        TypeName="Adiciones" InsertMethod="Insert">
     
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFecIni" 
                Name="fecini" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TxtFecFin" 
                Name="fecfin" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


