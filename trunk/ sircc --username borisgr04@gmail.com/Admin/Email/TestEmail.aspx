<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TestEmail.aspx.vb" Inherits="Admin_Email_TestEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<div class="demoarea">
<br />
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
<br />
<br />
<br />
    <table >
        <tr>
            <td colspan="3">
                <asp:Label ID="LbEnvios" runat="server" CssClass="SubTitulo" 
                    Text="TEST DE ENVIO DE CORREOS ELECTRONICOS"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Dependencia </td>
            <td>
                <asp:DropDownList ID="CboDep" runat="server" CssClass="txt" DataSourceID="ObjDep"
                    DataTextField="NOM_DEP" DataValueField="COD_DEP">
                    <asp:ListItem>-------------o-----------------</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:Button ID="BtnEnviarMail" runat="server" Text="Enviar Mail" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Correo especifico</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="BtnMailEsp" runat="server" Text="Enviar Mail" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="3">
                <asp:Label ID="MsgResult" runat="server" Height="100%" Width="100%"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>

                &nbsp;</td>
            <td>

    <asp:ObjectDataSource ID="ObjDep" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Dependencias"></asp:ObjectDataSource>

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</div>
</asp:Content>

