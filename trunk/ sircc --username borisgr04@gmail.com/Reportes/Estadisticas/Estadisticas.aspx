<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Estadisticas.aspx.vb" Inherits="Reportes_Estadisticas_Estadisticas" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table >
        <tr>
            <td>
                Vigencia</td>
            <td>
                <asp:DropDownList ID="CmbVigencia" runat="server" Width="140px" 
                    DataSourceID="ObjVigencias" DataTextField="Year_Vig" 
                    DataValueField="Year_Vig"></asp:DropDownList></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="Label1" runat="server" 
        Text="Digite Número de CDP, separados por coma"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="TxtCdp" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="785px">
        <LocalReport ReportPath="Rpt\Estadisticas\Rpt_Cdp_Dep.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjRPT_CDP_DEP" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="785px">
        <LocalReport ReportPath="Rpt\Estadisticas\Rpt_Cdp_Dep_Clase.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjRPT_CDP_DEP_CLASE" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    <asp:ObjectDataSource ID="ObjRPT_CDP_DEP" runat="server" 
        SelectMethod="GetCdp_Dep" TypeName="Rpt_Cdp_Dep">
        <SelectParameters>
            <asp:ControlParameter ControlID="CmbVigencia" DefaultValue="" Name="Vigencia" 
                PropertyName="Text" />
            <asp:ControlParameter ControlID="TxtCdp" DefaultValue="" Name="LstCdp" 
                PropertyName="Text" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjRPT_CDP_DEP_CLASE" runat="server" 
        SelectMethod="GetCdp_Dep_Clase" TypeName="Rpt_Cdp_Dep">
        <SelectParameters>
            <asp:ControlParameter ControlID="CmbVigencia" DefaultValue="" Name="Vigencia" 
                PropertyName="Text" />
            <asp:ControlParameter ControlID="TxtCdp" DefaultValue="" Name="LstCdp" 
                PropertyName="Text" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Vigencias"></asp:ObjectDataSource>
    <br />
</asp:Content>

