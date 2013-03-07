<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Radicacion.aspx.vb" Inherits="SolAdiciones_Radicacion_Default" %>

<%@ Register src="../../CtrlUsr/DetPContratos/DetPContrato.ascx" tagname="DetPContrato" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/Terceros/ConsultaTerxDep.ascx" tagname="consultaterxDep" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>

<%@ Register src="../../CtrlUsr/DetContratos/DetContrato.ascx" tagname="DetContrato" tagprefix="uc2" %>

<%@ Register src="../../CtrlUsr/DetContratosN/DetContratoN.ascx" tagname="DetContratoN" tagprefix="uc3" %>

<%@ Register src="../../CtrlUsr/DetcontratosAdi/DetContratoAdi.ascx" tagname="DetContratoAdi" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
        
  
        
    <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Asignación de Solicitudes de Modificación de Contratos"></asp:Label>
    <br />
        
  
        
    <br />
        
  
        
<asp:UpdatePanel ID="UpdatePanel1" 
        runat="server" UpdateMode="Conditional">
        <contenttemplate> 
            <uc5:DetContratoAdi ID="DetContratoAdi1" runat="server" />
            <br />
            <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
            <br />
            <table style="width:100%;">
                <tr>
                    <td style="width: 122px">
                        Fecha de Suscripción</td>
                    <td style="width: 482px">
                        <asp:TextBox ID="TxtFecha" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender 
                        ID="FecRad" 
                        runat="server"
                        TargetControlID="TxtFecha" 
                        Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:FilteredTextBoxExtender 
                        ID="FilteredTextBoxExtender1" 
                        runat="server" 
                        TargetControlID="TxtFecha" 
                        FilterType="Numbers, Custom" 
                        ValidChars="/">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" 
                            ImageUrl="~/images/Operaciones/sello.png" ToolTip="Radicar Modificación" 
                            Width="32px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 122px">
                        &nbsp;</td>
                    <td style="width: 482px">
                        &nbsp;</td>
                    <td>
                        Radicar</td>
                </tr>
                <tr>
                    <td style="width: 122px">
                        Observación</td>
                    <td style="width: 482px">
                        <asp:TextBox ID="TxtObs" runat="server" Height="130px" TextMode="MultiLine" 
                            Width="492px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 122px">
                        &nbsp;</td>
                    <td style="width: 482px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
    <br />
      </contenttemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DetContratoAdi1" 
                EventName="AceptarClicked" />
        </Triggers>
    </asp:UpdatePanel> 
</div>
</asp:Content>

