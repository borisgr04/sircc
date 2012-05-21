<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SolicitudesDepN.aspx.vb" Inherits="Consultas_SolicitudesCord_SolicitudesDepN" %>

<%@ Register src="../../CtrlUsr/FiltroSol/FiltroSolP.ascx" tagname="FiltroSolP" tagprefix="uc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register src="../../CtrlUsr/FiltroSol/FiltroSolN.ascx" tagname="FiltroSolN" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

     <div class="demoheading">REPORTE DE SOLICITUDES</div>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <uc2:FiltroSolN ID="FiltroSolN1" runat="server" />
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="924px">
                    <LocalReport ReportPath="PReportes\Solicitudes\SolicitudesCord.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjSolCord" Name="DsSolCord" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:HiddenField ID="ValFiltro" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="FiltroSolN1" EventName="FiltrarClicked" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <asp:ObjectDataSource ID="ObjSolCord" runat="server" InsertMethod="InsertHREV" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetSolCord" 
            TypeName="ConSolicitudes">
            <InsertParameters>
                <asp:Parameter Name="COD_SOL" Type="String" />
                <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ValFiltro" Name="Filtro" PropertyName="Value" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjSolCord">
        </asp:GridView>
        <br />

     </div>
</asp:Content>