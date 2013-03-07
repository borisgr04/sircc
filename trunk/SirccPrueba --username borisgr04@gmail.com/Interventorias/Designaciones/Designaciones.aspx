<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Designaciones.aspx.vb" Inherits="Interventorias_Designaciones_Default" %>

<%@ Register src="../../CtrlUsr/Terceros/ConsultaTerxDep.ascx" tagname="consultaterxDep" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>

<%@ Register src="../CtrlUsr/DetContratosI/DetContratoI.ascx" tagname="DetContratoI" tagprefix="uc2" %>

<%@ Register src="../../CtrlUsr/AdmTercero/UpdAdmTerceros.ascx" tagname="UpdAdmTerceros" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
        
  
        
<asp:UpdatePanel ID="UpdatePanel1" 
        runat="server" UpdateMode="Always">
        <contenttemplate> 
        <div style="height:250px; overflow:scroll; width:100%;">
        <uc2:DetContratoI ID="DetContratoI1" runat="server" />
            <asp:HiddenField ID="HfCod_Con" runat="server" />
        </div>
        
            <asp:Panel ID="Panel1" runat="server">
                
            <br />
            <br />
                <TABLE>
                    <tbody>
                        <tr>
                            <td colspan="5">
                                <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" 
                                    Text="Asignar Supervisor"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
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
                                    Width="300px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="WIDTH: 99px">
                                Fecha&nbsp; Designación</td>
                            <td style="WIDTH: 99px">
                                <asp:TextBox ID="TxtFec_Ini" runat="server" AutoPostBack="True" Width="80px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="FI" TargetControlID="TxtFec_Ini"
                                Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                            </td>
                            <td style="WIDTH: 99px">
                                <asp:Button ID="BtnAsignar" runat="server" Text="Asignar" 
                                    ValidationGroup="ASIGNAR" />
                            </td>
                        </tr>
                        
                       
                    </tbody>
                </TABLE>
                <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <br />
                  <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                    DataSourceID="ObjHUsuEnc" EnableModelValidation="True" 
                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Ide_Int" HeaderText="Identificación" />
                                        <asp:BoundField DataField="Nom_Ter" HeaderText="Nombre" />
                                        <asp:BoundField DataField="NTip_Int" HeaderText="Tipo" />
                                        <asp:BoundField DataField="Obs_Int" HeaderText="Observación" />
                                        <asp:BoundField DataField="Est_Int" HeaderText="Estado" />
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:ImageButton ID="IbtnSelect" runat="server" Width="32px" Height="32px" SkinID="IBtnEliminar"
                                            CommandName="Eliminar" CommandArgument='<%# Eval("Cod_Con")+","+Eval("Ide_Int") %>' />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No hay dato
                                    </EmptyDataTemplate>
                                </asp:GridView>
            </asp:Panel>
            <br />
            <asp:ObjectDataSource ID="ObjHUsuEnc" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetIntxContrato" 
                TypeName="Designaciones">
                <SelectParameters>
                    <asp:ControlParameter ControlID="HfCod_Con" Name="Numero" PropertyName="Value" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
    <br />
         </contenttemplate>
    </asp:UpdatePanel> 
    <asp:Panel ID="PanelOperaciones" runat="server" BackColor="White" Width="379px">
            <asp:Panel ID="Panel4" runat="server" BorderColor="White"  CssClass="BarTitleModal2"
                Height="27px" Width="379px">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 1159px">
                            <asp:Label ID="Label18" runat="server" ForeColor="White" Text="Deshabilitar Supervisor" 
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
            <table style="width:376px;">
                <tr>
                    <td style="text-align: center">
                        Fecha</td>
                    <td>
                        <asp:TextBox ID="TxtFecFin" runat="server" Width="80px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="TxtFecFin"
                                Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        
                        <asp:Label ID="Label22" runat="server" Text="Observacion"></asp:Label>
                    </td>
                    <td rowspan="3" style="text-align: left">
                        <asp:TextBox ID="TxtObservaciones" runat="server" Height="128px" TextMode="MultiLine" 
                            Width="291px"></asp:TextBox>
                    </td>
                    <td style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        &nbsp;</td>
                    <td style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        &nbsp;</td>
                    <td style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:Button ID="Btn_Recibir" runat="server" 
                            Text="Deshabilitar" />
                    </td>
                </tr>
            </table>
                    
        </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target" runat="server"></asp:Button>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" 
        runat="server"
        TargetControlID="Btn_Target" 
        PopupControlID="PanelOperaciones" 
        CancelControlID="BtnCerrar" 
        BackgroundCssClass="modalBackground" 
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>
    <uc3:UpdAdmTerceros ID="UpdAdmTerceros1" runat="server" />
</div>
</asp:Content>

