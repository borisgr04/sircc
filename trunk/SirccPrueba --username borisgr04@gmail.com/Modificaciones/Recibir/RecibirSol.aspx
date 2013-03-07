<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RecibirSol.aspx.vb" Inherits="Modificaciones_Recibir_Recibir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" EnableScriptGlobalization="True" runat="server">
    </ajaxToolkit:ToolkitScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
    <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Recibir Solicitudes de Modificación a Contrato"></asp:Label>
    <br />
    <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

    <br />
    <table style="width:100%;">
        <tr>
            <td style="width: 84px">
                &nbsp;</td>
            <td colspan="4">
                <asp:Menu ID="Menu1" runat="server" CssClass="MenuIE8" Height="16px" 
                    Orientation="Horizontal" Width="320px" BorderColor="#003366">
                    <Items>
                        <asp:MenuItem Text="[Solicitudes por Recibir]" 
                            ToolTip="Muestra las Solicitudes Pendientes de Revisión" Value="1">
                        </asp:MenuItem>
                        <asp:MenuItem Text="[Solicitudes Recibidas]" ToolTip="Muestra la solicitudes Recibidas" 
                            Value="2"></asp:MenuItem>
                        <asp:MenuItem Text="[Todas]" ToolTip="Muestra todas la Solicitudes a su cargo" 
                            Value="3"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td style="width: 84px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 184px">
                <asp:Label ID="Label2" runat="server" CssClass="selectIndex" 
                    Text="Fecha Inicial"></asp:Label>
            </td>
            <td style="width: 192px">
                <asp:Label ID="Label3" runat="server" CssClass="selectIndex" Text="Fecha Final"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="selectIndex" 
                    Text="No. de Proceso"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 84px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 184px">
                <asp:TextBox ID="TxtDesde" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtDesde_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtDesde" Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="width: 192px">
                <asp:TextBox ID="TxtHasta" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtHasta_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtHasta" Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td>
                <asp:TextBox ID="TxtNSol" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 84px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 184px">
                &nbsp;</td>
            <td style="width: 192px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjSolAdi" 
            AutoGenerateColumns="False" 
            DataKeyNames="Num_Sol_Adi,Cod_Con" 
            EmptyDataText="No hay Solicitudes para mostrar" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="Num_Sol_Adi" HeaderText="No. Solicitud" />
            <asp:BoundField DataField="Cod_Con" HeaderText="Contrato a Modificar" />
            <asp:BoundField DataField="Fec_Recibido" 
                HeaderText="Fecha Recibido - Dependencia" />
            <asp:BoundField DataField="Nom_Tip" HeaderText="Tipo de Solicitud" />
            <asp:BoundField DataField="Fecha_Asignado" HeaderText="Fecha de Asignación" />
            <asp:BoundField DataField="Fec_Rec_Abog" 
                HeaderText="Fecha Recibido - Abogado" />
            <asp:BoundField DataField="Recibido" HeaderText="Recibido" />
            <asp:BoundField DataField="Est_Concepto" HeaderText="Concepto de Revision" />
            <asp:BoundField DataField="Fecha_Revisado" HeaderText="Fecha Revisado" />
            <asp:BoundField DataField="Obs_Revisado" HeaderText="Observación Revisión" />
            <asp:ButtonField CommandName="recibir" Text="Recibir" />
            <asp:ButtonField CommandName="modificar" Text="Modificar" />
            <asp:ButtonField CommandName="revisar" Text="Revisar" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjSolAdi" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetByAbogxFec" 
        TypeName="Sol_Adiciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Menu1" Name="RECIBIDO" 
                PropertyName="SelectedValue" Type="String" DefaultValue="1" />
            <asp:ControlParameter ControlID="TxtDesde" Name="Desde" PropertyName="Text" 
                Type="DateTime" />
            <asp:ControlParameter ControlID="TxtHasta" Name="Hasta" PropertyName="Text" 
                Type="DateTime" />
            <asp:ControlParameter ControlID="TxtNSol" Name="Num_Sol_Adi" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <asp:Panel ID="PanelOperaciones" runat="server" BackColor="White" Width="379px">
            <asp:Panel ID="Panel4" runat="server" BorderColor="White"  CssClass="BarTitleModal2"
                Height="27px" Width="376px">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 1159px">
                            <asp:Label ID="Label18" runat="server" ForeColor="White" Text="Recibir" 
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
                    <td colspan="2" style="text-align: center">
                        &nbsp;</td>
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
                            Text="Recibir" />
                    </td>
                </tr>
            </table>
                    
        </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target" runat="server"></asp:Button>
        <ajaxToolkit:ModalPopupExtender 
            ID="ModalPopupsOper" 
            runat="server" 
            DynamicServicePath="" 
            Enabled="True" 
            TargetControlID="Btn_Target"
            PopupControlID="PanelOperaciones" 
            CancelControlID="BtnCerrar" 
            BackgroundCssClass="modalBackground" 
            DropShadow="True"
            PopupDragHandleControlID="Panel4">
        </ajaxToolkit:ModalPopupExtender>
     
     </ContentTemplate>
        </asp:UpdatePanel>
    
        </div>   
</asp:Content>

