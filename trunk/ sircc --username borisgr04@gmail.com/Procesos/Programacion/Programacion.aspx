<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Programacion.aspx.vb" Inherits="Procesos_Programacion_Default" %>

<%@ Register assembly="ControlesWeb" namespace="ControlesWeb" tagprefix="cc1" %>

<%@ Register src="../../CtrlUsr/FiltroPCon/FiltroPCon.ascx" tagname="FiltroPCon" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/CalenProg/CalenProgl.ascx" tagname="CalenProgl" tagprefix="uc2" %>

<%@ Register src="../../CtrlUsr/DetPContratos/DetPContrato.ascx" tagname="DetPContrato" tagprefix="uc3" %>

<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="True" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <div class="demoheading">CRONOGRAMA DEL PROCESO DE CONTRATACIÓN</div>
        <asp:UpdatePanel ID="UpdPCon" runat="server" UpdateMode="Conditional">        
         <ContentTemplate>
             
             <uc3:DetPContrato ID="DetPContrato1" runat="server" />
             <hr />
              <asp:HyperLink ID="HyperLink1" runat="server" 
                 NavigateUrl="~/Procesos/Programacion/ImprimirCrono.aspx" Target="_blank">Vista de Calendario</asp:HyperLink>
              &nbsp;&nbsp;&nbsp;&nbsp;
              <asp:HyperLink ID="HyperLink2" runat="server" 
                 NavigateUrl="~/Procesos/Programacion/RptCrono.aspx" Target="_blank">Ver Reporte</asp:HyperLink>
              
                 <hr />
              <uc2:CalenProgl ID="CalenProgl1" runat="server" />

         </ContentTemplate>
            <triggers>
                <asp:AsyncPostBackTrigger ControlID="DetPContrato1" 
                    EventName="AceptarClicked" />
                <asp:AsyncPostBackTrigger ControlID="CalenProgl1" EventName="CambiarEstProc" />
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
        PopupDragHandleControlID="Panel4" 
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
  </div>
  <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="Loading">
            <asp:Image SkinID="ImgProgress" runat="server" ID="ImgAjax"/> Cargando …
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>--%>
</asp:Content>

