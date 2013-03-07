<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConsultaTer2.ascx.vb" Inherits="CtrlUsr_ConsultaTer2" %>
    <table style="width: 573px; height: 10px">
    <tr>
        <td style="width: 100px">
            Nit/Nombre</td>
        <td colspan="1" style="width: 290px">
            <asp:TextBox ID="TxtFilNom" runat="server" Width="277px" AutoPostBack="True"></asp:TextBox>
        
        </td>
        <td colspan="1" style="width: 53px">
            <asp:ImageButton ID="BtnBuscar" runat="server" AccessKey="b" AlternateText="Buscar"
                CausesValidation="False" CommandName="Buscar" ImageUrl="~/images/Operaciones/search2.png"
                OnClick="BtnBuscar_Click" /></td>
        <td style="width: 49px">
            <asp:ImageButton ID="BtnAgregar" runat="server" CausesValidation="False" 
                CommandName="Nuevo" onclick="BtnAgregar_Click" SkinID="IBtnNuevo" />
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td colspan="1" style="width: 290px">
        </td>
        <td colspan="1" style="width: 53px">
            Buscar</td>
        <td style="width: 49px">
            Nuevo</td>
    </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="IDE_TER" DataSourceID="ObjTerceros" 
                    OnRowDataBound="GridView1_RowDataBound" 
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" 
                    EnableModelValidation="True" Width="100%" AllowPaging="True">
                    <Columns>
                       <asp:BoundField DataField="Ide_Ter" HeaderText="Identificacion"  />
                    <asp:BoundField DataField="Nom_Ter" HeaderText="Nombre o Raz�n Social"  />
                    <asp:BoundField DataField="Dir_Ter" HeaderText="Direcci�n"  />
                    <asp:BoundField DataField="Tel_Ter" HeaderText="Tel�fono"  />
                    <asp:BoundField DataField="Ema_Ter" HeaderText="Email"  />
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
                        <asp:ButtonField ButtonType="Image" CommandName="editar" 
                            ImageUrl="~/images/Operaciones/Edit2.png" Text="Button" />
                    </Columns>
                    <EmptyDataTemplate>
                        <br />
                        <asp:Label ID="Label1" runat="server" CssClass="NoData" 
                            Text="No se encontraron registros" Width="166px"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
</table>

&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:HiddenField ID="HiddenField1" runat="server" Value="Tipo" />
<asp:ObjectDataSource ID="ObjTerceros" runat="server" SelectMethod="GetRecords" TypeName="Terceros">
    <SelectParameters>
        <asp:ControlParameter ControlID="TxtFilNom" Name="busc" PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="HiddenField1" Name="Tipo" PropertyName="Value" />
    </SelectParameters>
</asp:ObjectDataSource>
