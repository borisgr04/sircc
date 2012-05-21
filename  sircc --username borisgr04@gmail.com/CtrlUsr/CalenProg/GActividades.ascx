﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GActividades.ascx.vb" Inherits="CtrlUsr_CalenProg_GActividades" %>
<%@ Register src="../Progreso/Progress.ascx" tagname="Progress" tagprefix="uc1" %>
<script language="javascript" type="text/javascript">
    function colorChanged(sender) {
        sender.get_element().style.color = "#" + sender.get_selectedColor();
        //document.getElementById("MostrarColor").style.background = "#" + sender.get_selectedColor();
    }
</script>


<style type="text/css">
    .style1
    {
        width: 59px;
    }
    .style2
    {
        width: 100px;
    }
       .style2
    {
        width: 100px;
    }
    .style3
    {
        width: 25px;
    }
    </style>



<asp:UpdatePanel ID="UpdateAct" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                 <ContentTemplate>
                 
            <table class="style1" width="100%">
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td colspan="11">
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                     ShowMessageBox="True" ShowSummary="False" ValidationGroup="MODALACT" />
                 <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:Label ID="LbEstado" runat="server" CssClass="Caption">Actividad</asp:Label>
             </td>
             <td colspan="10">
                 <asp:DropDownList ID="CboAct" runat="server" DataSourceID="ObjPActividades" 
                     DataTextField="Nom_Act" DataValueField="Cod_Act" AutoPostBack="True" 
                     Width="100%">
                 </asp:DropDownList>
             </td>
         </tr>
                <tr>
                    <td colspan="13">
                        <asp:UpdatePanel ID="UpdAct" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <table width="100%">
                                    <tr>
                                        <td class="style2">
                                            &nbsp;</td>
                                        <td  class="style2">
                                            <asp:Label ID="Label1" runat="server" Text="Ocupado"></asp:Label>
                                        </td>
                                        <td  class="style2">
                                            <asp:Label ID="Label2" runat="server" Text="Dia no hábil" 
                                                ToolTip="Permitido dia no hábil"></asp:Label>
                                        </td>
                                        <td class="style2">
                                                <asp:Label ID="LbObligx" runat="server" Text="Obligatorio"></asp:Label>
                                        </td>
                                        <td class="style2">
                                            <asp:Label ID="LbOblig1" runat="server" Text="Estado"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            &nbsp;</td>
                                        <td class="style2">
                                            <asp:CheckBox ID="ChkOcup" runat="server" Enabled="False" Text="" />
                                        </td>
                                        <td class="style2">
                                            <asp:CheckBox ID="ChkDia_NoHabil" runat="server" Enabled="False" Text="" 
                                                ToolTip="Permitido dia no hábil" />
                                        </td>
                                        <td class="style2">
                                            <asp:CheckBox ID="ChkOblig" runat="server" Enabled="False" Text="" />
                                        </td>
                                        <td class="style2">
                                            <asp:DropDownList ID="cboEstProc" runat="server" DataSourceID="ObjEstProc" 
                                                DataTextField="Nom_Est" DataValueField="Cod_Est" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                        </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="CboAct" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:Label ID="LbFi" runat="server">Desde</asp:Label>
             </td>
             <td colspan="3">
                 <asp:TextBox ID="TxtFechaI" runat="server" ValidationGroup="MODALACT"></asp:TextBox>
                 <ajaxToolkit:CalendarExtender ID="TxtFechaI_CalendarExtender" runat="server" 
                     Enabled="True" TargetControlID="TxtFechaI">
                 </ajaxToolkit:CalendarExtender>
             </td>
             <td>
                 <asp:CustomValidator ID="CustomValidator1" runat="server" 
                     ControlToValidate="TxtFechaI" Display="Dynamic" 
                     ErrorMessage="La Fecha (Hasta) debe ser un dia hábil." 
                     ValidationGroup="MODALACT">*</asp:CustomValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                     ControlToValidate="TxtFechaI" Display="Dynamic" 
                     ErrorMessage="Campo(Desde) Requerido" ValidationGroup="MODALACT">*</asp:RequiredFieldValidator>
             </td>
             <td>
                 <asp:DropDownList ID="cbohor_i" runat="server" AutoPostBack="True" 
                     DataSourceID="ObjHoras" DataTextField="Desc_Hor" DataValueField="Cod_Hor">
                 </asp:DropDownList>
             </td>
             <td colspan="2">
                 <asp:DropDownList ID="cbomin_i" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="00">:00</asp:ListItem>
                     <asp:ListItem Value="15">:15</asp:ListItem>
                     <asp:ListItem Value="30">:30</asp:ListItem>
                     <asp:ListItem Value="45">:45</asp:ListItem>
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
             <td class="style3">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:Label ID="LbFF" runat="server">Hasta</asp:Label>
             </td>
             <td colspan="3">
                 <asp:TextBox ID="TxtFechaF" runat="server"></asp:TextBox>
                 <ajaxToolkit:CalendarExtender ID="TxtFechaF_CalendarExtender" runat="server" 
                     Enabled="True" TargetControlID="TxtFechaF">
                 </ajaxToolkit:CalendarExtender>
             </td>
             <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                     ControlToValidate="TxtFechaF" ErrorMessage="Campo (Hasta) Requerido" 
                     ValidationGroup="MODALACT">*</asp:RequiredFieldValidator>
             </td>
             <td>
                 <asp:UpdatePanel ID="UpdHoraF2" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
                         <asp:DropDownList ID="cbohor_f" runat="server" DataSourceID="ObjHorasF" 
                             DataTextField="Desc_Hor" DataValueField="Cod_Hor">
                         </asp:DropDownList>
                     </ContentTemplate>
                     <triggers>
                         <asp:AsyncPostBackTrigger ControlID="TxtFechaF" EventName="TextChanged" />
                         <asp:AsyncPostBackTrigger ControlID="TxtFechaI" EventName="TextChanged" />
                         <asp:AsyncPostBackTrigger ControlID="cbohor_i" 
                             EventName="SelectedIndexChanged" />
                     </triggers>
                 </asp:UpdatePanel>
                 
             </td>
             <td colspan="2">
                 <asp:UpdatePanel ID="UpdMinF2" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
                         <asp:DropDownList ID="cbomin_f" runat="server">
                             <asp:ListItem Value="00">:00</asp:ListItem>
                             <asp:ListItem Value="15">:15</asp:ListItem>
                             <asp:ListItem Value="30">:30</asp:ListItem>
                             <asp:ListItem Value="45">:45</asp:ListItem>
                         </asp:DropDownList>
                     </ContentTemplate>
                     <triggers>
                         <asp:AsyncPostBackTrigger ControlID="TxtFechaF" EventName="TextChanged" />
                         <asp:AsyncPostBackTrigger ControlID="TxtFechaI" EventName="TextChanged" />
                         <asp:AsyncPostBackTrigger ControlID="cbomin_i" 
                             EventName="SelectedIndexChanged" />
                     </triggers>
                 </asp:UpdatePanel>

             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:Label ID="LbUbicacion" runat="server" CssClass="Caption">Lugar y Caracteristica</asp:Label>
             </td>
             <td colspan="10">
                 <asp:TextBox ID="TxtUbicacion" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:Label ID="LbNotas" runat="server" CssClass="Caption">Notas</asp:Label>
             </td>
             <td colspan="10">
                 <asp:TextBox ID="TxtNotas" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:Label ID="LbAviso" runat="server" CssClass="Caption">Fecha de Aviso</asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="TxtFecAviso" runat="server" ValidationGroup="MODALACT"></asp:TextBox>
                 <ajaxToolkit:CalendarExtender ID="TxtFecAviso_CalendarExtender" runat="server" 
                     Enabled="True" TargetControlID="TxtFecAviso">
                 </ajaxToolkit:CalendarExtender>
             </td>
             <td colspan="4">
                 &nbsp;</td>
             <td colspan="2">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:Label ID="LbColor" runat="server" CssClass="Caption">Color</asp:Label>
             </td>
             <td colspan="10">
                 <asp:TextBox ID="TxtColor" runat="server" AutoCompleteType="None" MaxLength="6" style="float:left"></asp:TextBox>
                 <ajaxToolkit:ColorPickerExtender runat="server" 
                ID="ColorPickerExtender1"
                TargetControlID="TxtColor"
                OnClientColorSelectionChanged="colorChanged" />
                 <span id="MostrarColor" style="width:40px;height:18px;border:1px solid #000;margin:0 3px;float:left" ></span>
             </td>
         </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="LbEst" runat="server" CssClass="Caption">Estado</asp:Label>
                    </td>
                    <td colspan="10">
                        <asp:DropDownList ID="cboEstAct" runat="server" DataSourceID="ObjEstAct" 
                            DataTextField="nom_est" DataValueField="cod_est">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="LbEst0" runat="server" CssClass="Caption">Observación</asp:Label>
                    </td>
                    <td colspan="10">
                        <asp:TextBox ID="TxtObs" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox>
                    </td>
                </tr>
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td colspan="11">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td class="style3">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td colspan="2">
                 &nbsp;</td>
             <td colspan="2">
                 <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" 
                     ToolTip="Nueva Actividad" />
             </td>
             <td style="text-align: center">
                 <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" 
                     ValidationGroup="MODALACT" />
                 <ajaxToolkit:ConfirmButtonExtender ID="BtnGuardar_ConfirmButtonExtender" 
                     runat="server" 
                     ConfirmText="Desea Guardar la Actividad? Asegurese que la Información es la Correcta" 
                     Enabled="True" TargetControlID="BtnGuardar">
                 </ajaxToolkit:ConfirmButtonExtender>
             </td>
             <td style="text-align: center">
                 <asp:Button ID="BtnEliminar" runat="server" Text="Anular" />
                 <ajaxToolkit:ConfirmButtonExtender ID="BtnEliminar_ConfirmButtonExtender" 
                     runat="server" 
                     ConfirmText="Desea Anular la Actividad, asegurese de digitar una observación" 
                     Enabled="True" TargetControlID="BtnEliminar">
                 </ajaxToolkit:ConfirmButtonExtender>
             </td>
             <td style="text-align: center">
                 &nbsp;</td>
             <td style="text-align: center">
                 <asp:Button ID="BtnCancelar" runat="server" Text="Cerrar"  
                     CausesValidation="False" ToolTip="Cierra la ventana actual" />
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td colspan="4">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
     </table>    
     <asp:HiddenField ID="HdNumProc" runat="server" />
                     <asp:HiddenField ID="HdEsFinal" runat="server" />
                     <asp:HiddenField ID="HdEsFinalPA" runat="server" />
                     <asp:HiddenField ID="HdNotificar" runat="server" />
                     <asp:HiddenField ID="HdDTFecIni" runat="server" />
                     <asp:HiddenField ID="HdCod_TProc" runat="server" />
                     
                     <asp:HiddenField ID="HdMFi" runat="server" />
                     <asp:HiddenField ID="HdMHi" runat="server" />
                     <asp:HiddenField ID="HdMFf" runat="server" />
                     <asp:HiddenField ID="HdOrdenAct" runat="server" />
                     
                     
                     <asp:HiddenField ID="HdMHf" runat="server" />
                     
                     
              </ContentTemplate>
                 </asp:UpdatePanel>        

      <asp:ObjectDataSource ID="ObjPActividades" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
        TypeName="PActividades">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdNumProc" Name="Num_Proc" 
                PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

         <asp:ObjectDataSource ID="ObjPActividad" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyPk" 
        TypeName="PActividades">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdNumProc" Name="Num_Proc" 
                PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="CboAct" Name="Cod_Act" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ObjHoras" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Horas">
    </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ObjHorasF" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Horas">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtFechaI" Name="FechaI" PropertyName="Text" 
                    Type="DateTime" />
                <asp:ControlParameter ControlID="cbohor_i" Name="HoraI" 
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="TxtFechaF" Name="FechaF" PropertyName="Text" 
                    Type="DateTime" />
            </SelectParameters>
    </asp:ObjectDataSource>

    
            <asp:ObjectDataSource ID="ObjEstAct" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
    TypeName="PEstadosAct"></asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ObjEstProc" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
    TypeName="PEstados"></asp:ObjectDataSource>


         <asp:UpdateProgress ID="UpdPrgAct" runat="server" AssociatedUpdatePanelID="UpdateAct">
                <progresstemplate>
                    <uc1:Progress ID="Progress1" runat="server" />
                </progresstemplate>
</asp:UpdateProgress> 