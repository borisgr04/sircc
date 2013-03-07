<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptCrono.aspx.vb" Inherits="Procesos_Programacion_RptCrono" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering=true 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
     <div class="demoheading">CRONOGRAMA DEL PROCESO DE CONTRATACIÓN</div>

      
        <asp:UpdatePanel ID="UpdPCon" runat="server" UpdateMode="Conditional">        
         <ContentTemplate>
             
        
           <asp:ObjectDataSource ID="ObjvPCronograma" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecordsRPT" 
            TypeName="PCronogramas" InsertMethod="Insert" UpdateMethod="Anular"  >
            <SelectParameters>
                <asp:ControlParameter ControlID="HdNum_Proc" Name="Num_ProC" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
             <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                 Font-Size="8pt" Height="500px" InteractiveDeviceInfos="(Collection)" 
                 WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                 <LocalReport ReportPath="PReportes\PCronogramas\RptPCrono.rdlc">
                     <DataSources>
                         <rsweb:ReportDataSource DataSourceId="ObjvPCronograma" Name="vProconograma" />
                     </DataSources>
                 </LocalReport>
             </rsweb:ReportViewer>
         <asp:HiddenField ID="HdNum_Proc" runat="server" />
         </ContentTemplate>
           
        </asp:UpdatePanel> 
    <br />
            
    </div>
    </form>
</body>
</html>
