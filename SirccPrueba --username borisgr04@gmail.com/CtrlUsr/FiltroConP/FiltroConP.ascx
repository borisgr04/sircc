<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltroConP.ascx.vb" Inherits="CtrlUsr_FiltroConP" %>
  
    <style type="text/css">
        .stylefp
        {
            width: 229px;
        }
        .txt
        {}
        </style>
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 80%">
                <tr>
                    <td style="width: 20px">
                        &nbsp;</td>
                    <td class="stylefp">
                        <asp:CheckBox ID="ChkVig" runat="server" AutoPostBack="True" Checked="True" 
                            Enabled="False" Text="Vigencia" />
                    </td>
                    <td colspan="4">
                        <asp:DropDownList ID="CmbVigencia" runat="server" DataSourceID="ObjVigencias" 
                            DataTextField="Year_Vig" DataValueField="Year_Vig" Width="142px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px">
                        &nbsp;</td>
                    <td class="stylefp">
                        <asp:CheckBox ID="ChkNProc" runat="server" AutoPostBack="True" 
                            Text="N° de Contrato" />
                    </td>
                    <td>
                        Tipo</td>
                    <td>
                        <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" CssClass="txt" 
                            DataSourceID="ObjTiposCont" DataTextField="NOM_TIP" DataValueField="COD_TIP">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Número</td>
                    <td>
                        <asp:TextBox ID="TxtNProc" runat="server" AutoPostBack="True" Width="180px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px">
                        &nbsp;</td>
                    <td class="stylefp">
                        <asp:CheckBox ID="ChkTproc" runat="server" AutoPostBack="True" 
                            Text="Cedula Contratista" />
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="TxtCedCon" runat="server" AutoPostBack="True" Width="180px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px">
                        &nbsp;</td>
                    <td class="stylefp">
                        <asp:CheckBox ID="ChkObj" runat="server" AutoPostBack="True" 
                            Text="Objeto a Contratado" />
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="TxtObj" runat="server" AutoPostBack="True" CssClass="txt" 
                            Height="39px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;" colspan="6">
                        <asp:Button ID="BtnFiltrar" runat="server" Text="Filtrar" />
                        <asp:Label ID="LbFiltro" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:ObjectDataSource ID="ObjVigencias" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Vigencias"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjTiposCont" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Tipos"></asp:ObjectDataSource>
        </ContentTemplate>
</asp:UpdatePanel>

        

            