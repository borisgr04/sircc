<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Recibido.aspx.vb" Inherits="Solicitudes_Recibido_Default" %>

<%@ Register src="../../CtrlUsr/DetPContratos/DetPContrato.ascx" tagname="DetPContrato" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    
    <div class="demoarea">

<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Label ID="Label10" runat="server" CssClass="Titulo" 
            Text="Solicitudes de Contratos a Cargo"></asp:Label>

        <br />
    <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>

    <table style="width: 100%">
        <tr>
            <td colspan="8">
                
            </td>
        </tr>
               
        <tr>
            <td style="width: 65px">
                &nbsp;</td>
            <td colspan="7">
                &nbsp;</td>
        </tr>
               
        <tr>
            <td style="width: 65px">
                &nbsp;</td>
            <td style="width: 197px">
                <asp:Label ID="Label24" runat="server" Text="Estado" CssClass="selectIndex"></asp:Label>
            </td>
            <td style="width: 135px">
                <asp:Label ID="Label25" runat="server" CssClass="selectIndex" 
                    Text="Fecha Inicial"></asp:Label>
            </td>
            <td style="width: 145px">
                <asp:Label ID="Label26" runat="server" CssClass="selectIndex" 
                    Text="Fecha Final"></asp:Label>
            </td>
            <td style="width: 144px">
                <asp:Label ID="Label28" runat="server" CssClass="selectIndex" 
                    Text="N° Solicitud"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LbConcepto" runat="server" CssClass="selectIndex" 
                    Text="Concepto" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
               
        <tr>
            <td style="width: 65px">
                &nbsp;</td>
            <td style="width: 197px">
                <asp:DropDownList ID="CboEstRec" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="S">SOLICITUDES RECIBIDAS</asp:ListItem>
                    <asp:ListItem Selected="True" Value="N">SOLICITUDES SIN RECIBIR</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 135px">
                <asp:TextBox ID="TxtDesde" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtDesde_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtDesde">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="width: 145px">
                <asp:TextBox ID="TxtHasta" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtHasta_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtHasta">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="width: 144px">
                <asp:TextBox ID="TxtNSol" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                 <asp:DropDownList ID="CboConcepto" runat="server" Width="108px" 
                     AutoPostBack="True" Visible="False">
                                        <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="P">PENDIENTE</asp:ListItem>
                                        <asp:ListItem Value="A">ACEPTADO</asp:ListItem>
                                        <asp:ListItem Value="R">RECHAZADO</asp:ListItem>
                                    </asp:DropDownList></td>
            <td>
                 &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
               
        <tr>
            <td style="width: 65px">
                &nbsp;</td>
            <td style="width: 197px">
                &nbsp;</td>
            <td style="width: 135px">
                &nbsp;</td>
            <td style="width: 145px">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
               
    </table>
     <asp:ObjectDataSource ID="ObjPSol" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByAbogxFec" 
            TypeName="PSolicitudes" InsertMethod="InsertHREV" >
            <InsertParameters>
                <asp:Parameter Name="COD_SOL" Type="String" />
                <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="CboEstRec" Name="RECIBIDO" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="TxtDesde" Name="Desde" PropertyName="Text" 
                    Type="DateTime" />
                <asp:ControlParameter ControlID="TxtHasta" Name="Hasta" PropertyName="Text" 
                    Type="DateTime" />
                <asp:ControlParameter ControlID="TxtNSol" Name="Cod_Sol" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="CboConcepto" Name="Concepto" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
      
        </asp:ObjectDataSource>
                <br />
                <asp:GridView 
                id="GridView1" runat="server" Width="95%" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound" 
                DataSourceID="ObjPSol" GridLines="None" CellPadding="4" 
                DataKeyNames="Cod_Sol" 
                AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
            AllowSorting="True" EnableModelValidation="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>

    <asp:BoundField DataField="Cod_Sol" 
        HeaderText="N° Solicitud" SortExpression="COD_SOL" >

    <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>

    <asp:BoundField DataField="asignado_por" HeaderText="Asignado por" 
        SortExpression="asignado_por" >

    <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>

    <asp:BoundField DataField="FECHA_RECIBIDO" DataFormatString="{0:d}" 
        HeaderText="Fecha Recibido - Dependencia" SortExpression="FECHA_RECIBIDO" >
          <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>


    <asp:BoundField DataField="Obj_sol" HeaderText="Objeto a Contratar" 
        SortExpression="Obj_sol" >
          <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>
    
    <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia que Genera la Necesidad" 
        SortExpression="Dep_Nec" >
          <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>
    <asp:BoundField DataField="FEC_ASIGNADO" HeaderText="Fecha de Asignación" 
        SortExpression="FEC_ASIGNADO" >
          <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>
    <asp:BoundField DataField="FEC_REC_ABOG" HeaderText="Fecha Recibido - Abogado" 
        SortExpression="FEC_REC_ABOG" >
          <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>
    <asp:BoundField DataField="Est_Concepto" HeaderText="Concepto de Revisión" SortExpression="Est_Concepto">
          <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>
    <asp:BoundField DataField="FECHA_REVISADO"  SortExpression="FECHA_REVISADO" 
        HeaderText="Fecha Revisado" >
          <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>
    <asp:BoundField DataField="OBS_REVISADO" HeaderText="Observación Revisión" SortExpression="OBS_REVISADO"  >
          <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>
    <asp:ButtonField CommandName="recibir" Text="Recibir" />
    <asp:ButtonField CommandName="modificar" Text="Modificar" />
    <asp:ButtonField CommandName="revisar" Text="Revisar" />
</Columns>

                    <EmptyDataTemplate>
                        <asp:Label ID="Label29" runat="server" CssClass="alerta" 
                            Text="La Consulta no muestra registros"></asp:Label>
                    </EmptyDataTemplate>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
    <br />
        <asp:Panel ID="PanelOperaciones" runat="server" BackColor="White" Width="379px">
            <asp:Panel ID="Panel4" runat="server" BorderColor="White"  CssClass="BarTitleModal2"
                Height="27px" Width="379px">
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

