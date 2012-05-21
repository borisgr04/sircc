<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Asignaciones.aspx.vb" Inherits="Contratos_Asignaciones_Default" %>

<%@ Register src="../../CtrlUsr/DetPContratos/DetPContrato.ascx" tagname="DetPContrato" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/Terceros/ConsultaTerxDep.ascx" tagname="consultaterxDep" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>

<%@ Register src="../../CtrlUsr/DetContratos/DetContrato.ascx" tagname="DetContrato" tagprefix="uc2" %>

<%@ Register src="../../CtrlUsr/DetContratosN/DetContratoN.ascx" tagname="DetContratoN" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<script type='text/javascript'>
// Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrarT"), 'click', CerrarModalTercero);
        }

        function CerrarModalTercero(ev) {
            ev.preventDefault();
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior');
            modalPopupBehavior2.hide();
        }
        function CerrarModalTerceros() {
            
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior');
            modalPopupBehavior2.hide();
        }
        function MostrarTerceros() {
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }
     
      function enviar(ced,rsocial,tip_ter)
         {
         document.aspnetForm.<%=Me.TxtIde.ClientID%>.value=ced;
         document.aspnetForm.<%=Me.TxtNomTer.ClientID%>.value=rsocial;
         __doPostBack("<%= button1.ClientID %>","");
         }
    </script>
<div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
        
  
        
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/Procesos/Asignaciones/ConAsignaciones.aspx" Target="_blank">Ver Carga de Trabajo</asp:HyperLink>
        
  
        
    <br />
        
  
        
<asp:UpdatePanel ID="UpdatePanel1" 
        runat="server" UpdateMode="Conditional">
        <contenttemplate> 
            <uc2:DetContrato ID="DetContrato1" runat="server" />
            <br />
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <TABLE>
                    <tbody>
                        <tr>
                            <td colspan="5">
                                <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Asignar Abogado"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 165px">
                                Identificación Funcionario<asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtIde" 
                                    ErrorMessage="Debe escoger un funcionario" ValidationGroup="ASIGNAR">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="WIDTH: 100px">
                                <asp:TextBox ID="TxtIde" runat="server" AutoPostBack="True"></asp:TextBox>
                            </td>
                            <td style="WIDTH: 24px">
                                <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="..." />
                            </td>
                            <td style="WIDTH: 100px">
                                <asp:TextBox ID="TxtNomTer" runat="server" Height="18px" ReadOnly="true" 
                                    Width="168px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="WIDTH: 99px">
                                <asp:Button ID="BtnAsignar" runat="server" Text="Asignar" 
                                    ValidationGroup="ASIGNAR" />
                            </td>
                            <td style="WIDTH: 99px">
                                &nbsp;</td>
                        </tr>
                        
                       
                    </tbody>
                </TABLE>
                <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <br />
                  <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                    DataSourceID="ObjHUsuEnc" EnableModelValidation="True" 
                    AutoGenerateColumns="False" Width="555px">
                                    <Columns>
                                        <asp:BoundField DataField="Cod_Con" HeaderText="Código" />
                                        <asp:BoundField DataField="Fec_Reg" HeaderText="Fecha de Registro" />
                                        <asp:BoundField DataField="ENC_SIGUIENTE" HeaderText="Encargado Actual" />
                                        <asp:BoundField DataField="ENC_ANTERIOR" HeaderText="Encargado Anterior" />
                                        <asp:BoundField DataField="Obs" HeaderText="Observacion" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No se ha asignado el contrato a ningún funcionario
                                    </EmptyDataTemplate>
                                </asp:GridView>
            </asp:Panel>
            <br />
            <asp:ObjectDataSource ID="ObjHUsuEnc" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetvHUsuEncargados" 
                TypeName="ContratosA">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DetContrato1" Name="Cod_Con" 
                        PropertyName="Cod_Con" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
    <br />
    
<!-- Mensaje de Salida-->
            <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" 
                style="DISPLAY: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" 
                BackgroundCssClass="modalBackground" 
                BehaviorID="programmaticModalPopupBehavior" DropShadow="True" 
                PopupControlID="programmaticPopup" 
                PopupDragHandleControlID="programmaticPopupDragHandle" 
                RepositionMode="RepositionOnWindowScroll" 
                TargetControlID="hiddenTargetControlForModalPopup">
            </ajaxToolkit:ModalPopupExtender>
            &nbsp;
            <asp:Panel ID="programmaticPopup" runat="server" CssClass="ModalPanel2" 
                 Width="625px">
                <asp:Panel ID="programmaticPopupDragHandle" runat="Server" 
                    CssClass="BarTitleModal2" Height="30px">
                    <div style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
                        <div style="FLOAT: left">
                            Asignar Encargado</div>
                        <div style="FLOAT: right">
                            <input id="BtnCerrarT" type="button" value="X" />
&nbsp;</div>
                       </div>
                </asp:Panel>
                <uc1:ConsultaTerxDep ID="ConsultaTerxDep" runat="server" Ret="AR" Tipo="06" />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Button" style="visibility:hidden" />
                <br />
                <br />
            </asp:Panel>
       

        </contenttemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnBuscar" EventName="Click" />
             <asp:AsyncPostBackTrigger ControlID="DetContrato1" 
                    EventName="AceptarClicked" />
        </Triggers>
    </asp:UpdatePanel> 
</div>
</asp:Content>

