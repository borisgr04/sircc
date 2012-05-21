<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MinProc.aspx.vb" Inherits="Procesos_GRadicacion_Default" %><%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #FFFFFF">
    <div>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
                    EnablePartialRendering="true" EnableScriptGlobalization="True">
                </ajaxToolkit:ToolkitScriptManager>

     <div class="demoheading">REPORTE DE MINUTA DEL PROCESO</div>
                <br />
                <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                <br />
        
                <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="924px">
                    <LocalReport ReportPath="PReportes\PContratos\DBProceso.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjPcont" Name="DsProceso" />
                            <rsweb:ReportDataSource DataSourceId="PagosParciales" Name="DsPagos" />
                            <rsweb:ReportDataSource DataSourceId="ObjObligaciones" Name="DsObligaciones" />
                            <rsweb:ReportDataSource DataSourceId="ObjCDP" Name="DsCDP" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjCDP" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                    TypeName="CDP_GProcesos">
                    <SelectParameters>
                        <asp:SessionParameter Name="Num_Pcon" SessionField="NumProc" Type="String" />
                        <asp:SessionParameter Name="Grupo" SessionField="Grupo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjObligaciones" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                    TypeName="GPObligaciones">
                    <SelectParameters>
                        <asp:SessionParameter Name="Num_PCon" SessionField="NumProc" Type="String" />
                        <asp:SessionParameter Name="Grupo" SessionField="Grupo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField ID="HfNumPcon" runat="server" />
        <asp:HiddenField ID="HfGrupo" runat="server" />
                <asp:HiddenField ID="ValFiltro" runat="server" />
                <span>
                <asp:ObjectDataSource ID="PagosParciales" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                    TypeName="Pagos_Gprocesos">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HfNumPcon" Name="Num_Proc" 
                            PropertyName="Value" Type="String" />
                        <asp:ControlParameter ControlID="HfGrupo" Name="Grupo" PropertyName="Value" 
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                </span>
                <asp:ObjectDataSource ID="ObjPcont" runat="server" InsertMethod="InsertP" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetByPkRad" 
                    TypeName="ConGProcesos">
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
                        <asp:SessionParameter Name="Num_PCon" SessionField="NumProc" Type="String" />
                        <asp:SessionParameter Name="Grupo" SessionField="Grupo" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
           
    
    </div>
    </form>
</body>
</html>
