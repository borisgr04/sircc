<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PCronogramasG.aspx.vb" Inherits="Reportes_PCronogramasG_Default" %>

<%@ Register src="../../CtrlUsr/DetPContratos/DetPContrato.ascx" tagname="DetPContrato" tagprefix="uc3" %>

<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering=true 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <div class="demoheading">CRONOGRAMA DEL PROCESO DE CONTRATACIÓN</div>
        <asp:UpdatePanel ID="UpdPCon" runat="server" UpdateMode="Conditional">        
         <ContentTemplate> 
             <uc3:DetPContrato ID="DetPContrato1" runat="server" />

                 <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="PReportes\PCronogramas\RptPCrono.rdlc"  >
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjvPCronograma" Name="vProconograma" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
         </ContentTemplate>
            <triggers>
                <asp:AsyncPostBackTrigger ControlID="DetPContrato1" 
                    EventName="AceptarClicked" />
                
            </triggers>
        </asp:UpdatePanel> 
           
            

            <asp:Panel ID="PanelvConP" runat="server" BackColor="White" Width="900px" Height="500px">
            <asp:Panel ID="Panel4" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
                Height="27px" Width="100%" >
                <table style="width:100%;">
                    <tr>
                        <td style="width: 1159px">
                            <asp:Label ID="LbTitModal" runat="server" ForeColor="White" Text=" Consulta de Procesos a Cargo" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
            <uc4:ConPContratos ID="ConPContratos1" runat="server" />
            </asp:Panel>
             </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target" runat="server"></asp:Button>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupConP" 
        runat="server"
        TargetControlID="Btn_Target" 
        PopupControlID="PanelvConP" 
        CancelControlID="BtnCerrar" 
        BackgroundCssClass="modalBackground" 
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>   
 <asp:ObjectDataSource ID="ObjPContratos" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetxUsuario" 
        TypeName="PContratos">
        <SelectParameters>
            <asp:SessionParameter Name="filtro" SessionField="FiltroPCon_Filtro" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
            
            <br />
        <br />
    
        <asp:ObjectDataSource ID="ObjvPCronograma" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecordsRPT" 
            TypeName="PCronogramas"  >
            <SelectParameters>
                <asp:ControlParameter ControlID="DetPContrato1" Name="Num_ProC" 
                    PropertyName="CodigoPContrato" Type="String" />
            </SelectParameters>
       
        </asp:ObjectDataSource>
  </div>
  <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="Loading">
            <asp:Image SkinID="ImgProgress" runat="server" ID="ImgAjax"/> Cargando …
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>--%>
</asp:Content>

