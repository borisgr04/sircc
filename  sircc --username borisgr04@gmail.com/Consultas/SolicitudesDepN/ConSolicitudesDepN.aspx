<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConSolicitudesDepN.aspx.vb" Inherits="Consultas_ConSolicitudesDepN" %>

<%@ Register src="../../CtrlUsr/FiltroSol/FiltroSolP.ascx" tagname="FiltroSolP" tagprefix="uc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

        <br />

    <table style="width:95%;" __designer:mapid="15">
        <tr __designer:mapid="16">
            <td __designer:mapid="17" colspan="5">
                <asp:Menu ID="Menu1" runat="server" CssClass="MenuIE8" Height="16px" 
                    Orientation="Horizontal" Width="900px" BorderColor="#003366">
                    <Items>
                        <asp:MenuItem Text="[Solicitudes sin Asignar]" Value="7">
                        </asp:MenuItem>
                        <asp:MenuItem Text="[Solicitudes Asignadas]" Value="6"></asp:MenuItem>
                        <asp:MenuItem Text="[Solicitudes sin Recibir]" 
                            ToolTip="Muestra las Solicitudes Pendientes de Revisión" Value="1">
                        </asp:MenuItem>
                        <asp:MenuItem Text="[Solicitudes Recibidas]" ToolTip="Muestra la solicitudes Recibidas" 
                            Value="2"></asp:MenuItem>
                        <asp:MenuItem Text="[Solicitudes sin Revisar]" ToolTip="Muestra un listado de Solicitudes para revisar" 
                            Value="4"></asp:MenuItem>
                        <asp:MenuItem Text="[Solicitudes Revisadas]" 
                            ToolTip="Muestra las solicitudes Revisadas" Value="3"></asp:MenuItem>
                        <asp:MenuItem Text="[Todas]" ToolTip="Muestra todas la Solicitudes a su cargo" 
                            Value="5"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
        <tr __designer:mapid="1e">
            <td style="width: 84px" __designer:mapid="1f">
                &nbsp;</td>
            <td __designer:mapid="20">
                &nbsp;</td>
            <td style="width: 184px" __designer:mapid="21">
                <asp:Label ID="Label2" runat="server" CssClass="selectIndex" 
                    Text="Fecha Inicial"></asp:Label>
            </td>
            <td style="width: 192px" __designer:mapid="23">
                <asp:Label ID="Label3" runat="server" CssClass="selectIndex" Text="Fecha Final"></asp:Label>
            </td>
            <td __designer:mapid="25">
                <asp:Label ID="Label4" runat="server" CssClass="selectIndex" 
                    Text="No. de Solicitud"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="27">
            <td style="width: 84px" __designer:mapid="28">
                &nbsp;</td>
            <td __designer:mapid="29">
                &nbsp;</td>
            <td style="width: 184px" __designer:mapid="2a">
                <asp:TextBox ID="TxtDesde" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtDesde_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtDesde" Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="width: 192px" __designer:mapid="2d">
                <asp:TextBox ID="TxtHasta" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TxtHasta_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtHasta" Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td __designer:mapid="30">
                <asp:TextBox ID="TxtNSol" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="32">
            <td style="width: 84px" __designer:mapid="33">
                &nbsp;</td>
            <td __designer:mapid="34">
                &nbsp;</td>
            <td style="width: 184px" __designer:mapid="35">
                &nbsp;</td>
            <td style="width: 192px" __designer:mapid="36">
                &nbsp;</td>
            <td __designer:mapid="37">
                &nbsp;</td>
        </tr>
    </table>
        <br />
                <asp:GridView 
                id="GridView1" runat="server" Width="95%" ForeColor="#333333" 
                DataSourceID="ObjSol" GridLines="None" CellPadding="4" 
                DataKeyNames="Cod_Sol" 
                AutoGenerateColumns="False" 
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

    <asp:BoundField DataField="Encargado" HeaderText="Asignado a" />

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
    <asp:CommandField ButtonType="Image" 
        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
</Columns>

                    <EmptyDataTemplate>
                        <asp:Label ID="Label29" runat="server" CssClass="alerta" 
                            Text="La Consulta no muestra registros"></asp:Label>
                    </EmptyDataTemplate>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> 
        <asp:ObjectDataSource ID="ObjSol" runat="server" InsertMethod="InsertHREV" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByDepNecxFec" 
            TypeName="ConSolicitudes">
            <InsertParameters>
                <asp:Parameter Name="COD_SOL" Type="String" />
                <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="Menu1" Name="RECIBIDO" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="TxtDesde" Name="Desde" PropertyName="Text" 
                    Type="DateTime" />
                <asp:ControlParameter ControlID="TxtHasta" Name="Hasta" PropertyName="Text" 
                    Type="DateTime" />
                <asp:ControlParameter ControlID="TxtNSol" Name="Cod_Sol" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />

     </div>
</asp:Content>