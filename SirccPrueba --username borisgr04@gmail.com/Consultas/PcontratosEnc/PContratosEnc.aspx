﻿<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PContratosEnc.aspx.vb" Inherits="Consultas_Pcontratos_PContratosEnc" %>

<%@ Register src="../../CtrlUsr/FiltroSol/FiltroSolP.ascx" tagname="FiltroSolP" tagprefix="uc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register src="../../CtrlUsr/FiltroPCon/FiltroPConP.ascx" tagname="FiltroPConP" tagprefix="uc2" %>

<%@ Register src="../../CtrlUsr/FiltroPCon/FiltroPConE.ascx" tagname="FiltroPConE" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

     <div class="demoheading">REPORTE DE PROCESOS</div>
        <uc3:FiltroPConE ID="FiltroPConE1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="924px">
                    <LocalReport ReportPath="PReportes\PContratos\RptPCont.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjPCont" Name="DsPCont" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:HiddenField ID="ValFiltro" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="FiltroPConE1" EventName="FiltrarClicked" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <asp:ObjectDataSource ID="ObjPCont" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecordsxEncRep" 
            TypeName="Con_PContratos" InsertMethod="InsertP">
            <InsertParameters>
                <asp:Parameter Name="COD_TPRO" Type="String" />
                <asp:Parameter Name="OBJ_CON" Type="String" />
                <asp:Parameter Name="DEP_CON" Type="String" />
                <asp:Parameter Name="DEP_PCON" Type="String" />
                <asp:Parameter Name="VIG_CON" Type="Decimal" />
                <asp:Parameter Name="TIP_CON" Type="String" />
                <asp:Parameter Name="STIP_CON" Type="String" />
                <asp:Parameter Name="FEC_RECIBIDO" Type="DateTime" />
                <asp:Parameter Name="NUM_SOL" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ValFiltro" Name="Filtro" PropertyName="Value" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />

     </div>
</asp:Content>