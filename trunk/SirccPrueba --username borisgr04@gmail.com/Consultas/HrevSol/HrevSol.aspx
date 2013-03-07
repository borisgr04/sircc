<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HrevSol.aspx.vb" Inherits="Consultas_HrevSol" %>

<%@ Register src="../../CtrlUsr/FiltroSol/FiltroSolP.ascx" tagname="FiltroSolP" tagprefix="uc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register src="../../CtrlUsr/FiltroPCon/FiltroPConP.ascx" tagname="FiltroPConP" tagprefix="uc2" %>



<%@ Register src="../../CtrlUsr/Solicitudes/ConPSolicitudesPK.ascx" tagname="ConPSolicitudesPK" tagprefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

     <div class="demoheading">REPORTE DE HISTORIAL DE REVISIONES DE SOLICITUDES</div>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 117px; height: 21px">
                            &nbsp;</td>
                        <td style="width: 203px; height: 21px">
                        </td>
                        <td style="height: 21px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 117px">
                            <asp:Label ID="Label1" runat="server" Text="Código de la Solicitud"></asp:Label>
                        </td>
                        <td style="width: 203px">
                            <asp:TextBox ID="TxtCodSol" runat="server" AutoPostBack="True" Width="202px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="BtnBuscar" runat="server" SkinID="IBtnBuscar" />
                        </td>
                    </tr>
                </table>
                <br />
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="924px">
                    <LocalReport ReportPath="PReportes\Hrevision\RptHrev.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjHrev" Name="DsHrev" />
                            <rsweb:ReportDataSource DataSourceId="ObjSolicitud" Name="DsSol" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:HiddenField ID="ValFiltro" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TxtCodSol" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <asp:ObjectDataSource ID="ObjHrev" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetHrevRep" 
            TypeName="ConSolicitudes" InsertMethod="InsertHREV">
            <InsertParameters>
                <asp:Parameter Name="COD_SOL" Type="String" />
                <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCodSol" Name="Cod_Sol" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjSolicitud" runat="server" 
            InsertMethod="InsertHREV" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetByPKRep" TypeName="ConSolicitudes">
            <InsertParameters>
                <asp:Parameter Name="COD_SOL" Type="String" />
                <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCodSol" Name="Cod_Sol" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Panel ID="PanelSolicitudes" runat="server" BackColor="White" Width="650px">
            <asp:Panel ID="Panel2" runat="server" BorderColor="White" 
                CssClass="BarTitleModal2" Height="27px" Width="649px">
                <table style="width:100%;">
                    <tr>
                        <td class="style1" style="width: 128px">
                            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Buscar Solicitud" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar1" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
            
                <uc3:ConPSolicitudesPK ID="ConPSolicitudesPK1" runat="server" />
            
            </asp:Panel>
        </asp:Panel>
        <br />
        <asp:Button style="DISPLAY: none" id="Button2" runat="server"></asp:Button>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupSolicitudes" 
        runat="server"
        TargetControlID="Button2"
        BackgroundCssClass="modalBackground"
        PopupControlID="PanelSolicitudes" 
        DropShadow="True"
        CancelControlID="BtnCerrar1"
        PopupDragHandleControlID="Panel2">
        </ajaxToolkit:ModalPopupExtender>
             </div>
</asp:Content>