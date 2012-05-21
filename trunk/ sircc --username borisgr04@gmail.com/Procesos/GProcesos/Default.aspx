<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Procesos_GProcesos_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 114px;
        }
        .style3
        {
            width: 96px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style1" colspan="6">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        SkinID="gridView" Width="615px">
                        <Columns>
                            <asp:BoundField DataField="Cod_Sol" HeaderText="Amparo" 
                                SortExpression="Cod_Sol" />
                            <asp:BoundField DataField="Por_SMMLV" HeaderText="% o SMMVL" 
                                SortExpression="Por_SMMLV" />
                            <asp:BoundField DataField="Nom_CalPol" HeaderText="Calcular a partir de" />
                            <asp:BoundField DataField="Vigencia" HeaderText="Vigencia" />
                            <asp:BoundField DataField="Nom_Cal_Vig_Pol" HeaderText="A partir de" />
                            <asp:BoundField DataField="Cubrimiento" HeaderText="Cubrimiento" />
                            <asp:ButtonField ButtonType="Image" CommandName="Eliminar" 
                                ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label1" runat="server" Text="Amparo"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="% o SMMLV"></asp:Label>
                </td>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="Calcular a partir de"></asp:Label>
                </td>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="Vigencia"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="A partir de"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Cubrimiento"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:DropDownList ID="CboAmparo" runat="server" DataSourceID="Polizas" 
                        DataTextField="Nom_Pol" DataValueField="Cod_Pol" Width="166px">
                    </asp:DropDownList>
                </td>
                <td class="style2">
                    <asp:TextBox ID="TxtSMMLV" runat="server"></asp:TextBox>
                    
                </td>
                <td class="style3">
                    <asp:DropDownList ID="CboCalPol" runat="server" Width="190px">
                    </asp:DropDownList>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TxtVigencia" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="CboCalVigPol" runat="server" Width="190px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="TxtCubrimiento" runat="server" Width="190px"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="BtnGuardarPol" runat="server" SkinID="IBtnGuardar" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <asp:ObjectDataSource ID="Polizas" runat="server" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Polizas" UpdateMethod="Update">
        <UpdateParameters>
            <asp:Parameter Name="Cod_Pol_O" Type="String" />
            <asp:Parameter Name="Cod_Pol" Type="String" />
            <asp:Parameter Name="Nom_Pol" Type="String" />
            <asp:Parameter Name="Est_Pol" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Cod_Pol" Type="String" />
            <asp:Parameter Name="Nom_Pol" Type="String" />
            <asp:Parameter Name="Est_Pol" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
