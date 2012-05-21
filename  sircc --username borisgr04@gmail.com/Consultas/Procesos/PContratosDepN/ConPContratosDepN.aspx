<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConPContratosDepN.aspx.vb" Inherits="Consultas_ConPContratosDepN" %>

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
                    Orientation="Horizontal" Width="900px" BorderColor="#003366" 
                    Visible="False">
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
            <td style="width: 109px" __designer:mapid="1f">
                <asp:Label ID="Label4" runat="server" CssClass="selectIndex" 
                    Text="No. Proceso"></asp:Label>
            </td>
            <td __designer:mapid="20">
                &nbsp;</td>
            <td style="width: 184px" __designer:mapid="21">
                &nbsp;</td>
            <td style="width: 192px" __designer:mapid="23">
                &nbsp;</td>
            <td __designer:mapid="25">
                &nbsp;</td>
        </tr>
        <tr __designer:mapid="27">
            <td style="width: 109px" __designer:mapid="28">
                <asp:TextBox ID="TxtNSol" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
            <td __designer:mapid="29">
                &nbsp;</td>
            <td style="width: 184px" __designer:mapid="2a">
                &nbsp;</td>
            <td style="width: 192px" __designer:mapid="2d">
                &nbsp;</td>
            <td __designer:mapid="30">
                &nbsp;</td>
        </tr>
        <tr __designer:mapid="32">
            <td style="width: 109px" __designer:mapid="33">
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
                DataKeyNames="Pro_Sel_Nro" 
                AutoGenerateColumns="False" 
                AllowSorting="True" EnableModelValidation="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>

    <asp:BoundField DataField="Pro_Sel_Nro" 
        HeaderText="N° Proceso" SortExpression="Pro_Sel_Nro" >

    <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>

    <asp:BoundField DataField="Encargado" HeaderText="Encargado" />

    <asp:BoundField DataField="Obj_Con" HeaderText="Objeto a Contratar" 
        SortExpression="Obj_Con" >

    <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>

    <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia que Genera la Necesidad" 
        SortExpression="Dep_Nec" >
          <ItemStyle VerticalAlign="Top" />
    </asp:BoundField>
    <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia a Cargo" 
        SortExpression="Dep_Del" >
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
        <asp:ObjectDataSource ID="ObjSol" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetByDepNecxFec" 
            TypeName="Con_PContratos" InsertMethod="InsertP">
            <InsertParameters>
                <asp:Parameter Name="COD_TPRO" Type="String" />
                <asp:Parameter Name="OBJ_CON" Type="String" />
                <asp:Parameter Name="DEP_CON" Type="String" />
                <asp:Parameter Name="DEP_PCON" Type="String" />
                <asp:Parameter Name="VIG_CON" Type="Decimal" />
                <asp:Parameter Name="TIP_CON" Type="String" />
                <asp:Parameter Name="STIP_CON" Type="String" />
                <asp:Parameter Name="FEC_RECIBIDO" Type="DateTime" />
                <asp:Parameter Name="NUM_SOL" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtNSol" Name="Cod_Sol" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />

     </div>
</asp:Content>