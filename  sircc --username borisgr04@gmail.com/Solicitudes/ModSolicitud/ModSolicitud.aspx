<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="true" AutoEventWireup="false" CodeFile="ModSolicitud.aspx.vb" 
Inherits="Solicitudes_ModSolicitud_Default"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

<%@ Register src="../../CtrlUsr/DepSolicitudes/ConPSolicitudes.ascx" tagname="conpsolicitudes" tagprefix="uc1" %>
<%@ Register Src="../../CtrlUsr/AdmTercero/AdmTercero.ascx" TagName="AdmTercero"
    TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
                       <script type="text/javascript">
            function Presupuesto(){
            
            var val2=document.aspnetForm.<%=Me.TxtPpto.ClientID%>.value;
            
            document.aspnetForm.<%=Me.TxtPpto.ClientID%>.value=(parseFloat(val2)).toFixed(2);
            
                                    
            }
            
     </script>
        
        <br />
        <asp:Label ID="Label10" runat="server" CssClass="Titulo" 
            Text="Modificar Solicitud"></asp:Label>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
        <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 41px">
                            &nbsp;</td>
                        <td style="width: 115px">
                            <asp:TextBox ID="TxtNprocA" runat="server" AutoPostBack="True"></asp:TextBox>
                            
                        </td>
                        <td style="width: 53px; text-align: center;">
                            <asp:ImageButton ID="BtnBuscar" runat="server" SkinID="IBtnBuscar" />
                        </td>
                        <td style="width: 47px; text-align: center;">
                            <asp:ImageButton ID="IBtnAbrir" runat="server" Height="32px" Width="32px" 
                                SkinID="IBtnAbrir" />
                        </td>
                        <td style="width: 33px" class="style4">
                            <asp:ImageButton ID="IBtnEditar" runat="server" Height="32px" Width="32px" 
                                SkinID="IBtnEditar" />
                        </td>
                        <td style="width: 43px">
                            <asp:ImageButton ID="IBtnGuardar" runat="server" Height="32px" 
                                SkinID="IBtnGuardar" Width="32px" />
                        </td>
                        <td style="width: 44px" class="style1">
                            <asp:ImageButton ID="IBtnCancelar" runat="server" Height="32px" Width="32px" 
                                SkinID="IBtnCancelar" />
                        </td>
                        <td style="width: 87px; text-align: center">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 41px">
                            </td>
                        <td style="width: 115px">
                            &nbsp;</td>
                        <td style="width: 53px; text-align: center;">
                            Buscar</td>
                        <td style="width: 47px; text-align: center;">
                            Abrir</td>
                        <td style="width: 33px" class="style4">
                            Editar</td>
                        <td style="width: 43px">
                            Guardar</td>
                        <td style="width: 44px" class="style1">
                            Cancelar</td>
                        <td style="width: 87px; text-align: center">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 41px">
                            &nbsp;</td>
                        <td style="width: 115px">
                            &nbsp;</td>
                        <td style="width: 53px">
                            &nbsp;</td>
                        <td style="width: 47px">
                            &nbsp;</td>
                        <td style="width: 33px" class="style4">
                            &nbsp;</td>
                        <td style="width: 43px">
                            &nbsp;</td>
                        <td style="width: 44px" class="style1">
                            &nbsp;</td>
                        <td style="width: 87px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
    <br />
                <table border="0px" cellpadding="2px" cellspacing="2px" style="width: 90%; ">
                    <tr>
                        <td colspan="6">
                            <asp:Label ID="Label12" runat="server" CssClass="SubTitulo" 
                                Text="DATOS BASICOS DE LA SOLICITUD"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label2" runat="server" Text="Dependencia a Cargo de la Solicitud" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 92px">
                            &nbsp;</td>
                        <td colspan="4">
                            <b>
                            <asp:Label ID="Label5" runat="server" Text="Número de la Solicitud" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td>
                            <b>
                            <asp:Label ID="Label11" runat="server" CssClass="Caption" Text="Estado"></asp:Label>
                            </b></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="TxtNProc" runat="server" Width="180px" BackColor="#000066" 
                                Font-Size="12pt" ForeColor="White" ReadOnly="True"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtNProc_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtNProc" 
                                WatermarkCssClass="watermarked" WatermarkText="Automático ">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                        <td>
                            <asp:Label ID="LbEstado" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label4" runat="server" 
                                Text="Dependencia que Genera la Necesidad" CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 92px">
                            &nbsp;</td>
                        <td colspan="4">
                            <b>
                            <asp:Label ID="Label6" runat="server" 
                                Text="Planeación Precontractual/Estudio Previo" CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DropDownList ID="cboDep" runat="server" DataSourceID="ObjDep" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td colspan="4">
                            <asp:TextBox ID="TxtNPla" runat="server"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtNPla_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtNPla" 
                                WatermarkCssClass="watermarked" WatermarkText="Numero de Planeación">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label7" runat="server" Text="Proceso de Contratación" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 92px">
                            &nbsp;</td>
                        <td colspan="3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 25px">
                            <asp:DropDownList ID="CboTproc" runat="server" CssClass="txt" 
                                DataSourceID="ObjTipoProc" DataTextField="Nom_TProc" DataValueField="Cod_TProc" 
                                ToolTip="Proceso PreContractual">
                            </asp:DropDownList>
                        </td>
                        <td style="height: 25px">
                            </td>
                        <td style="height: 25px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label8" runat="server" Text="Tipo de Documento Contractual" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td colspan="2">
                            <b>
                            <asp:Label ID="Label9" runat="server" Text="Clase de Contratación" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td colspan="2" style="width: 119px">
                            <b>
                            <asp:Label ID="Label15" runat="server" CssClass="Caption" 
                                Text="Fecha de Recibido"></asp:Label>
                            </b>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" CssClass="txt" 
                                DataSourceID="ObjTiposCont" DataTextField="Nom_Tip" DataValueField="Cod_Tip">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 92px">
                            <asp:DropDownList ID="cboStip" runat="server" CssClass="txt" 
                                DataSourceID="ObjSubTipos" DataTextField="nom_stip" 
                                DataValueField="cod_stip" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" style="width: 64px">
                        
                            <asp:TextBox ID="TxtFechaRecibido" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender 
                            ID="CalFechaRecibido" 
                            runat="server" 
                            TargetControlID="TxtFechaRecibido" 
                            Format="dd/MM/yyyy"> 
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label21" runat="server" CssClass="Caption" Text="Valor Presupuesto Oficial"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 92px">
                            &nbsp;</td>
                        <td colspan="2" style="width: 64px">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <telerik:RadNumericTextBox ID="TxtPpto" runat="server" Culture="es-CO" Height="19px"
                                                        Skin="Default" Value="0" Width="125px">
                            </telerik:RadNumericTextBox>

                        </td>
                        <td style="width: 92px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TxtPpto" ErrorMessage="Debe diligenciar el Presupuesto" 
                                ValidationGroup="GUARDAR">*</asp:RequiredFieldValidator>
                        </td>
                        <td colspan="2" style="width: 64px">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="TxtIde" runat="server" AutoPostBack="True" CssClass="txt" Width="121px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="BtnBCon" runat="server" CausesValidation="False" Text="..." />
                        </td>
                        <td>
                            <asp:TextBox ID="TxtNom" runat="server" CssClass="txt" ReadOnly="True" Width="100%"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="TxtIde_FilteredTextBoxExtender1" runat="server"
                                Enabled="True" FilterType="Numbers" TargetControlID="TxtIde" ValidChars="">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 90%">
                    <tr>
                        <td style="font-weight: 700" colspan="3">
                            <b>
                            <asp:Label ID="Label13" runat="server" CssClass="Caption" 
                                Text="Objeto a Contratar"></asp:Label>
                            </b></td>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:TextBox ID="TxtObj" runat="server" CssClass="txt" Height="68px" 
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                            <asp:Label ID="Label14" runat="server" CssClass="Caption" 
                                Text="Funcionario Encargado"></asp:Label>
                            </b>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LbEncargado" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <hr />
        <br />
    <asp:ObjectDataSource ID="ObjDep" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Dependencias"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbySoloUser" 
            TypeName="Dependencias" 
            InsertMethod="AsignarAbogado" >
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTiposCont" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Tipos"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjSubTipos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByTipo" 
            TypeName="SubTipos" InsertMethod="Insert" UpdateMethod="Update">
            <UpdateParameters>
                <asp:Parameter Name="Cod_Stip_O" Type="String" />
                <asp:Parameter Name="Cod_Stip" Type="String" />
                <asp:Parameter Name="Nom_Stip" Type="String" />
                <asp:Parameter Name="Cod_Tip" Type="String" />
                <asp:Parameter Name="Cla_Con_Dep" Type="String" />
                <asp:Parameter Name="Crt_F20_1A" Type="String" />
                <asp:Parameter Name="Cla_Con_Dp" Type="String" />
                <asp:Parameter Name="Estado" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="CboTip" Name="cod_tip" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Cod_Stip" Type="String" />
                <asp:Parameter Name="Nom_Stip" Type="String" />
                <asp:Parameter Name="Cod_Tip" Type="String" />
                <asp:Parameter Name="Cla_Con_Dep" Type="String" />
                <asp:Parameter Name="Crt_F20_1A" Type="String" />
                <asp:Parameter Name="Cla_Con_Dp" Type="String" />
                <asp:Parameter Name="estado" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTipoProc" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="TiposProc"></asp:ObjectDataSource>
            
            
        <br />
        <asp:UpdatePanel runat="server" ID="Updmp" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="PanelSolicitudes" runat="server" BackColor="White" Width="650px">
            <asp:Panel ID="Panel2" runat="server" BorderColor="White" CssClass="BarTitleModal2"
 
                Height="27px" Width="649px">
                <table style="width:100%;">
                    <tr>
                        <td class="style1" style="width: 128px">
                            <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Buscar Solicitud" 
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
                <uc1:conpsolicitudes ID="conpsolicitudes1" runat="server" />
            </asp:Panel>
        </asp:Panel>
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
        </ContentTemplate></asp:UpdatePanel>
        <asp:Panel ID="PanelOperaciones" runat="server" BackColor="White" Width="379px">
            <asp:Panel ID="Panel4" runat="server" BackColor="Blue" BorderColor="White" CssClass="BarTitleModal2"
                Height="27px" Width="379px">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 900px">
                            <asp:Label ID="Label18" runat="server" ForeColor="White" Text="Reabrir Solicitud" 
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
                    <td style="width: 123px">
                        &nbsp;</td>
                    <td style="width: 233px">
                        &nbsp;</td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label ID="Label17" runat="server" Text="Fecha"></asp:Label>
                    </td>
                    <td style="width: 233px">
                        <asp:TextBox ID="Txt_FecRec" runat="server" Width="114px" Enabled="false"></asp:TextBox>
                          
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 123px">
                        <asp:Label ID="Label20" runat="server" Text="Observacion"></asp:Label>
                    </td>
                    <td style="width: 233px">
                        <asp:TextBox ID="Txt_ObsRec" runat="server" Width="228px" Height="85px" 
                            TextMode="MultiLine" ></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="3">
                        
                        <asp:Button ID="Btn_Guardar" runat="server" OnClick="Btn_Guardar_Click" 
                            Text="Guardar" />
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
         </div>
         <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup" runat="server">
        </asp:Button>
         <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" BackgroundCssClass="modalBackground"
            BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
            PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
            TargetControlID="hiddenTargetControlForModalPopup">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="programmaticPopup" runat="server" Width="693px" Height="555px" CssClass="ModalPanel2"
            ScrollBars="Auto">
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Width="97%" Height="30px"
                CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                    padding-top: 5px">
                    <div style="float: left">
                        Buscar Tercero
                    </div>
                    <div style="float: right">
                        <input id="hideModalPopupViaClientButton" type="button" value="X" /></div>
                </div>
            </asp:Panel>
            <panel id="pnCuadroInterno" runat="Server" scrollbars="Auto">
                    <uc4:AdmTercero ID="AdmTercero1" runat="server" />
                    <BR />
                </panel>
        </asp:Panel>
</asp:Content>

