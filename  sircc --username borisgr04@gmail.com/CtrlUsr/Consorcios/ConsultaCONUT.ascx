<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConsultaCONUT.ascx.vb" Inherits="CtrlUsr_ConsultaCONUT" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="width: 573px; height: 10px">
    <tr>
        <td style="width: 100px">
            &nbsp;&nbsp; Nit/Nombre</td>
        <td colspan="1" style="width: 290px">
            <asp:TextBox ID="TxtFilNom" runat="server" Width="277px"> 
</asp:TextBox>
        
        </td>
        <td colspan="1" style="width: 53px">
            <asp:ImageButton ID="BtnBuscar" runat="server" AccessKey="b" AlternateText="Buscar"
                CausesValidation="False" CommandName="Buscar" ImageUrl="~/images/Operaciones/search2.png"
                OnClick="BtnBuscar_Click" /></td>
        <td style="width: 49px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td colspan="1" style="width: 290px">
        </td>
        <td colspan="1" style="width: 53px">
            Buscar</td>
        <td style="width: 49px">
            </td>
    </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataKeyNames="IDE_TER" DataSourceID="ObjTerceros" 
                    OnRowCommand="GridView1_RowCommand" 
                    OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" 
                    EnableModelValidation="True">
                    <Columns>
                    <asp:BoundField DataField="Ide_Ter" HeaderText="Identificacion"  />
                    <asp:BoundField DataField="Nom_Ter" HeaderText="Nombre o Razón Social"  />
                    <asp:BoundField DataField="Dir_Ter" HeaderText="Dirección"  />
                    <asp:BoundField DataField="Tel_Ter" HeaderText="Teléfono"  />
                    <asp:BoundField DataField="Ema_Ter" HeaderText="Email"  />
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
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
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:HiddenField ID="HiddenField1" runat="server" Value="Tipo" />
<asp:ObjectDataSource ID="ObjTerceros" runat="server" 
    SelectMethod="GetConsorcios" TypeName="Terceros" DeleteMethod="Delete" 
    InsertMethod="AsignarAbogado" OldValuesParameterFormatString="original_{0}">
    <DeleteParameters>
        <asp:Parameter Name="Ide_ter" Type="String" />
    </DeleteParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="TxtFilNom" Name="busc" PropertyName="Text" Type="String" />
        <asp:Parameter Name="tipo" Type="String" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="Id_Ter" Type="String" />
        <asp:Parameter Name="Id_Miembro" Type="String" />
        <asp:Parameter Name="Id_Estado" Type="String" />
    </InsertParameters>
</asp:ObjectDataSource>
