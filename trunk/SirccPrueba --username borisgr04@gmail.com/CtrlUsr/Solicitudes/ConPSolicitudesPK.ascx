<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConPSolicitudesPK.ascx.vb" Inherits="CtrlUsr_ConPSolicitudesPk" %>

<%@ Register src="../Progreso/Progress.ascx" tagname="Progress" tagprefix="uc1" %>

<style type="text/css">
    .style1
    {
        width: 53px;
    }
    .style3
    {
        width: 206px;
    }
    .style4
    {
        width: 34px;
    }
</style>
<asp:UpdatePanel ID="UpdCSol" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table style="width: 90%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TxtFill" runat="server" Width="212px" AutoPostBack="True"></asp:TextBox>
            </td>
            <td class="style4">
            <asp:ImageButton ID="BtnBuscar" runat="server" OnClick="BtnBuscar_Click" AlternateText="Buscar"
                CausesValidation="False" CommandName="Buscar" SkinID="IBtnBuscar"
                 />
            </td>
            <td>
                Vigencia
                <asp:Label ID="LbVigencia" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="grdProcesos" runat="server" 
        AutoGenerateColumns="False" DataSourceID="ObjPContratos" 
        EnableModelValidation="True" Width="90%" DataKeyNames="Cod_Sol">
        <Columns>
            <asp:BoundField DataField="Cod_Sol" HeaderText="Codigo" 
                SortExpression="Cod_Sol" >
                <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="Nom_Tproc" HeaderText="Modalidad Contratación" 
                SortExpression="Nom_Tproc" >
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="Obj_Sol" HeaderText="Objeto de la Solicitud" 
                SortExpression="Obj_Sol" >
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia-Necesidad" 
                SortExpression="Dep_Nec" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia-Delegada" 
                SortExpression="Dep_Del" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Encargado" HeaderText="Encargado" 
                SortExpression="Encargado" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Est_Concepto" HeaderText="Concepto de Revisión" 
                SortExpression="Est_Concepto" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:CommandField ButtonType="Image" 
                SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjPContratos" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllSol" 
        TypeName="PSolicitudes" InsertMethod="InsertHREV" >
        <InsertParameters>
            <asp:Parameter Name="COD_SOL" Type="String" />
            <asp:Parameter Name="FECHA_RECIBIDO" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFill" Name="Cod_Sol" PropertyName="Text" 
                Type="String" />
            <asp:ControlParameter ControlID="LbVigencia" Name="Vig_Sol" PropertyName="Text" 
                Type="String" />
            <asp:Parameter Name="connect" Type="Boolean" />
        </SelectParameters>
       
    </asp:ObjectDataSource>

  </ContentTemplate></asp:UpdatePanel>          
 <asp:UpdateProgress ID="UpdPrgCSol" runat="server" AssociatedUpdatePanelID="UpdCSol">
                <progresstemplate>
                    <uc1:Progress ID="Progress1" runat="server" />
                </progresstemplate>
</asp:UpdateProgress> 