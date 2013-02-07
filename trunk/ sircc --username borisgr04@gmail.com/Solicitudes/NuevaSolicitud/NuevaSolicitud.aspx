<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="true" AutoEventWireup="false" CodeFile="NuevaSolicitud.aspx.vb" 
Inherits="Procesos_NuevaSolicitud_Default"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../../CtrlUsr/grdOblig/grdOblig.ascx" tagname="grdOblig" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/grdCDP/grdCDP.ascx" tagname="grdCDP" tagprefix="uc2" %>
<%--<%@ Register src="../../CtrlUsr/Solicitudes/ConPSolicitudes.ascx" tagname="conpsolicitudes" tagprefix="uc1" %>--%>
<%@ Register src="../../CtrlUsr/Solicitudes/ConPSolicitudesPK.ascx" tagname="ConPSolicitudesPK" tagprefix="uc3" %>
<%@ Register src="../../CtrlUsr/Progreso/Progress.ascx" tagname="Progress" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
                <script type="text/javascript">
//            function Presupuesto(){
//            var val2=document.aspnetForm.<%=Me.TxtPpto.ClientID%>.value;
//            document.aspnetForm.<%=Me.TxtPpto.ClientID%>.value=(parseFloat(val2)).toFixed(2);
//                                   
//            }
            
     </script>
        <div>
            <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="1000" Enabled="false">
            </asp:Timer>
        </div>

        <br />
        <asp:Label ID="Label10" runat="server" CssClass="Titulo" 
            Text="REGISTRO DE SOLICITUDES"></asp:Label>
        <br />
        <asp:UpdatePanel ID="UpdSol" runat="server" UpdateMode="Conditional" >
            <ContentTemplate>
        <br />
        
                <table style="width: 100%">
                    <tr>
                        <td style="width: 41px">
                            <asp:TextBox ID="TxtNprocA" runat="server" AutoPostBack="True"></asp:TextBox>
                        </td>
                        <td style="width: 49px" class="style1">
                            <asp:ImageButton ID="IBtnBuscar" runat="server" SkinID="IBtnBuscar" />
                            
                        </td>
                        <td style="width: 53px">
                            <asp:ImageButton ID="IBtnNuevo" runat="server" Height="32px" SkinID="IBtnNuevo" 
                                Width="32px" />
                        </td>
                        <td style="width: 47px">
                            <asp:ImageButton ID="IBtnAbrir" runat="server" Height="32px" 
                                ImageUrl="~/images/mnProcesos/open-icon32.png" Width="32px" />
                        </td>
                        <td style="width: 33px" class="style4">
                            <asp:ImageButton ID="IBtnEditar" runat="server" Height="32px" Width="32px" 
                                SkinID="IBtnEditar" />
                        </td>
                        <td style="width: 43px; text-align: center;">
                            <asp:ImageButton ID="IBtnGuardar" runat="server" Height="32px" 
                                SkinID="IBtnGuardar" Width="32px" ValidationGroup="GUARDAR" 
                                style="text-align: center" />
                            <cc1:ConfirmButtonExtender ID="IBtnGuardar_ConfirmButtonExtender" 
                                runat="server" ConfirmText="Confirme si desea Guardar los Cambios?" 
                                Enabled="True" TargetControlID="IBtnGuardar">
                            </cc1:ConfirmButtonExtender>
                        </td>
                        <td style="width: 44px; text-align: center;" class="style1">
                            <asp:ImageButton ID="IBtnCancelar" runat="server" Height="32px" Width="32px" 
                                SkinID="IBtnCancelar" />
                        </td>
                        <td style="width: 87px; text-align: center">
                            <asp:ImageButton ID="BtnReabrir" runat="server" Height="32px" Width="32px" 
                                Enabled="False" SkinID="IBtnReabrir" />
                        </td>
                        <td>
                            <asp:ImageButton ID="BtnAsig0" runat="server" SkinID="IBtnAsig" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 41px">
                            &nbsp;</td>
                        <td style="width: 49px" class="style1">
                            Buscar</td>
                        <td style="width: 53px">
                            Nuevo</td>
                        <td style="width: 47px">
                            Abrir</td>
                        <td style="width: 33px" class="style4">
                            Editar</td>
                        <td style="width: 43px">
                            Guardar</td>
                        <td style="width: 44px" class="style1">
                            Cancelar</td>
                        <td style="width: 87px; text-align: center">
                            Reabrir Solicitud</td>
                        <td>
                            Asignar</td>
                    </tr>
                    <tr>
                        <td style="width: 41px">
                            &nbsp;</td>
                        <td style="width: 49px" class="style1">
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
                    
                <asp:Label ID="MsgResult" runat="server" Height="100%"   ></asp:Label>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    SkinID="ValidationSummary1" ValidationGroup="GUARDAR" />

                <table border="0px" cellpadding="2px" cellspacing="2px" style="width: 90%; ">
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="Label12" runat="server" 
                                Text="DATOS BASICOS DE LA SOLICITUD" CssClass="SubTitulo"></asp:Label>
                        </td>
                        <td>
                            <b>
                            <asp:Label ID="Label11" runat="server" CssClass="Caption" Text="Estado: "></asp:Label>
                            </b>
                            <asp:Label ID="LbEstado" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 234px; height: 23px;">
                            <b>
                            <asp:Label ID="Label5" runat="server" Text="Número de la Solicitud" 
                                CssClass="Caption"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 132px; height: 23px;">
                            <b>
                            <asp:Label ID="Label6" runat="server" CssClass="Caption" 
                                Text="Planeación Precontractual/Estudio Previo"></asp:Label>
                            </b></td>
                        <td colspan="2" style="height: 23px">
                            <b>
                            <asp:Label ID="Label15" runat="server" CssClass="Caption" 
                                Text="Fecha de Recibido"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="TxtFechaRecibido" 
                                ErrorMessage="Debe digitar la fecha de recibido" ValidationGroup="GUARDAR">*</asp:RequiredFieldValidator>
                            </b>
                        </td>
                        <td style="height: 23px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px; height: 23px;">
                            <asp:TextBox ID="TxtNProc" runat="server" BackColor="#ACC4F9" Font-Size="12pt" 
                                ForeColor="White" ReadOnly="True" Width="180px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtNProc_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtNProc" 
                                WatermarkCssClass="watermarked" WatermarkText="Automático ">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                        <td style="width: 132px; height: 23px;">
                            <asp:TextBox ID="TxtNPla" runat="server"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtNPla_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtNPla" 
                                WatermarkCssClass="watermarked" WatermarkText="Numero de Planeación">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                        <td colspan="2" style="height: 23px">
                        
                            <asp:TextBox ID="TxtFechaRecibido" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalFechaRecibido" runat="server" Format="dd/MM/yyyy" 
                                TargetControlID="TxtFechaRecibido">
                            </cc1:CalendarExtender>
                            
                        </td>
                        <td style="height: 23px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px; height: 23px;">
                            <b>
                            <asp:Label ID="Label8" runat="server" CssClass="Caption" 
                                Text="Tipo de Documento Contractual"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 132px; height: 23px;">
                            <b>
                            <asp:Label ID="Label9" runat="server" CssClass="Caption" 
                                Text="Tipo de Contratación"></asp:Label>
                            </b>
                        </td>
                        <td colspan="2" style="height: 23px">
                            <b>
                            <asp:Label ID="Label21" runat="server" CssClass="Caption" 
                                Text="Valor Presupuesto Oficial"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TxtPpto" ErrorMessage="Debe diligenciar el Presupuesto" 
                                ValidationGroup="GUARDAR">*</asp:RequiredFieldValidator>
                            </b>
                        </td>
                        <td style="height: 23px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px; height: 23px;">
                            <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" CssClass="txt" 
                                DataSourceID="ObjTiposCont" DataTextField="Nom_Tip" DataValueField="Cod_Tip">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 132px; height: 23px;">
                            <asp:DropDownList ID="cboStip" runat="server" AutoPostBack="True" 
                                CssClass="txt" DataSourceID="ObjSubTipos" DataTextField="nom_stip" 
                                DataValueField="cod_stip">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" style="height: 23px">
                            <telerik:RadNumericTextBox ID="TxtPpto" runat="server" Culture="es-CO" 
                                Height="19px" Skin="Default" Value="0" Width="125px">
                            </telerik:RadNumericTextBox>
                        </td>
                        <td style="height: 23px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label7" runat="server" CssClass="Caption" 
                                Text="Modalidad de Contratación"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 132px">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DropDownList ID="CboTproc" runat="server" CssClass="txt" 
                                DataSourceID="ObjTipoProc" DataTextField="Nom_TProc" DataValueField="Cod_TProc" 
                                ToolTip="Proceso PreContractual">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label4" runat="server" CssClass="Caption" 
                                Text="Dependencia que Genera la Necesidad"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 132px">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DropDownList ID="cboDep" runat="server" DataSourceID="ObjDep" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 234px">
                            <b>
                            <asp:Label ID="Label2" runat="server" CssClass="Caption" 
                                Text="Dependencia a Cargo de la Solicitud"></asp:Label>
                            </b>
                        </td>
                        <td style="width: 132px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 25px">
                            <b>
                            <asp:Label ID="Label22" runat="server" CssClass="Caption" 
                                Text="Objeto a Contratar"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TxtObj" ErrorMessage="Debe digitar el Objeto a Contratar" 
                                ValidationGroup="GUARDAR">*</asp:RequiredFieldValidator>
                            </b>
                        </td>
                        <td style="height: 25px">
                            </td>
                        <td style="height: 25px">
                            </td>
                    </tr>
                    <tr>
                        <td style="height: 23px;" colspan="5">
                            <asp:TextBox ID="TxtObj" runat="server" CssClass="txt" Height="68px" 
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                   
                    
                    
                </table>
                <table style="width: 90%">
                    <tr>
                        <td style="font-weight: 700" colspan="3">
                            <b>
                            <asp:Label ID="Label14" runat="server" CssClass="Caption" 
                                Text="Funcionario Encargado:"></asp:Label>
                            &nbsp;</b></td>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 21px">
                            <b>
                            <asp:Label ID="LbEncargado" runat="server" style="font-weight: 700"></asp:Label>
                            &nbsp;
                            </b></td>
                    </tr>
                    
                    <tr>
                        <td>
                            <b>
                            &nbsp;<asp:LinkButton ID="LnkAsig" runat="server">Ir a Asignaciones</asp:LinkButton>
                            </b></td>
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
                            &nbsp;</td>
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
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>

        </asp:UpdatePanel>
         <asp:UpdateProgress ID="UpdPrgSol" runat="server" AssociatedUpdatePanelID="UpdSol">
                <progresstemplate>
                    <uc1:Progress ID="ProgressSol" runat="server" />
                </progresstemplate>
</asp:UpdateProgress> 
        <br />
        <hr />
        <br />
    <asp:ObjectDataSource ID="ObjDep" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Dependencias"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbySoloUser" 
            TypeName="Dependencias" 
            >
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
            <asp:Panel ID="Panel2" runat="server" BorderColor="White" CssClass="BarTitleModal2" Height="27px" Width="649px">
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
            <uc3:ConPSolicitudesPK ID="ConPSolicitudesPK1" runat="server" />
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
 <asp:UpdateProgress ID="UpdPrgmp" runat="server" AssociatedUpdatePanelID="Updmp">
                <progresstemplate>
                    <uc1:Progress ID="Progress1" runat="server" />
                </progresstemplate>
</asp:UpdateProgress> 
        <asp:Panel ID="PanelOperaciones" runat="server" BackColor="White" Width="379px">
            <asp:Panel ID="Panel4" runat="server" BackColor="Blue" BorderColor="White" CssClass="BarTitleModal2" Height="27px" Width="379px">
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
                        <asp:UpdatePanel ID="UpdFecReAbrir" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:TextBox ID="Txt_FecRec" runat="server" Width="114px"></asp:TextBox>
                        <cc1:CalendarExtender ID="Txt_FecRec_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="Txt_FecRec">
                        </cc1:CalendarExtender>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        
                          
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
</asp:Content>


