<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="SiaF20.aspx.vb" Inherits="Informes4_SIAF20_SiaF20" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <br />
    <h2>
        GENERACION DE FORMATOS SIA
    </h2>
    <br />
    &nbsp;&nbsp;
    Fecha Inicial
    <asp:TextBox ID="TxtFecIni" runat="server">01/01/2012</asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="TxtFecIni_CalendarExtender" runat="server" Enabled="True"
        TargetControlID="TxtFecIni">
    </ajaxToolkit:CalendarExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TxtFecIni" ErrorMessage="*"></asp:RequiredFieldValidator>
    Fecha Final
    <asp:TextBox ID="TxtFecFin" runat="server">31/12/2012</asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="TxtFecFinCalendarExtender1" runat="server" Enabled="True"
        TargetControlID="TxtFecFin">
    </ajaxToolkit:CalendarExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TxtFecFin" ErrorMessage="*"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnGenRpt" runat="server" Text="F20_1A" />
    <asp:Button ID="BtnF20_1B" runat="server" Text="F20_1B" />
    <asp:Button ID="BtnF20_1C" runat="server" Text="F20_1C" />
    <br />
    <br />
    <hr />
    Resultado... [
    <asp:Label ID="MsgResult" runat="server" Text="Label"></asp:Label>]


    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="Informes4\SIAF20\RptF20_1a.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjF20_1a" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjF20_1a" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="getF20_1a" 
        TypeName="CtrF20_2013">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFecIni" Name="fec_ini" PropertyName="Text" 
                Type="DateTime" />
            <asp:ControlParameter ControlID="TxtFecFin" Name="fec_fin" PropertyName="Text" 
                Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>

    
</asp:Content>
