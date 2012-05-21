<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CargarDoc.ascx.vb" Inherits="Controles_CargarDoc" %>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
<style type="text/css">


.Titulos
{
    background-color:#EBEBEB;
    height: 30px;
    color:#3A4C87;
    font-weight:bolder;
}

td
{
    height:10px;
    empty-cells:show;
    text-align:left;
    vertical-align:top;
        }

</style>


    <table id="TABLE1" >
        <tr>
            <td colspan="3" >
                <asp:Label ID="MsgResult" runat="server" Height="30px" Visible="False"
                    Width="90%" SkinID="MsgResult"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 170px; height: 21px">
                <asp:CheckBox ID="ChkCargar" runat="server" Text="Subir este documento" />
            </td>
            <td colspan="2" style="height: 21px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 170px; height: 21px">
                Fecha Documento</td>
            <td colspan="2" style="height: 21px">
                <ew:CalendarPopup ID="TxtFecEnt" runat="server">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td style="width: 170px; height: 21px">
                Tipo de Documento</td>
            <td style="height: 21px" colspan="2">
                <asp:DropDownList ID="Tip_Doc" runat="server" DataSourceID="ObjTipDoc" DataTextField="DES_TIP"
                    DataValueField="COD_TIP">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 170px; height: 21px">
                Observación</td>
            <td colspan="2" style="height: 21px">
                <asp:TextBox ID="txtObs" runat="server" TextMode="MultiLine" Width="421px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 170px; height: 21px">
                Documento</td>
            <td style="height: 21px">
                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
            <td style="width: 122px; height: 21px">
                &nbsp;</td>
        </tr>
        <asp:Label runat="server" Text="&nbsp;" ID="uploadResult" />
        </table>
        <asp:ObjectDataSource ID="ObjEtapas" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Etapas"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjTipDoc" runat="server" InsertMethod="Insert" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
    TypeName="Tip_Doc" UpdateMethod="Update">
        <InsertParameters>
            <asp:Parameter Name="Cod_Tip" Type="String" />
            <asp:Parameter Name="Des_Tip" Type="String" />
            <asp:Parameter Name="Est_Tip" Type="String" />
            <asp:Parameter Name="Cod_Etapa" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Cod_Tip_O" Type="String" />
            <asp:Parameter Name="Cod_Tip" Type="String" />
            <asp:Parameter Name="Des_Tip" Type="String" />
            <asp:Parameter Name="Est_Tip" Type="String" />
            <asp:Parameter Name="Cod_Etapa" Type="String" />
        </UpdateParameters>
</asp:ObjectDataSource>

    