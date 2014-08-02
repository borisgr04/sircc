<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GDRegistro.aspx.vb" Inherits="GDocumentos_Registro_GDRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <br />
    <table >
        <tr>
            <td>Tipo de Documento</td>
            <td>   <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Tutelas</asp:ListItem>
                <asp:ListItem>Derechos de Peticion</asp:ListItem>
                <asp:ListItem>Otros</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Descripción    </td>
            <td>    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
 

            </td>
        </tr>
        <tr>
            <td>Remitente</td>
            <td>    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
 

            </td>
        </tr>
        <tr>
            <td>Vence</td>
            <td>    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
 

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>    &nbsp;</td>
        </tr>
        <tr>
            <td>Adjuntos</td>
            <td>    
                <asp:FileUpload runat="server" ID="UploadImages" AllowMultiple="true" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>    
                <asp:Button ID="BtnUpload" runat="server" Text="Guardar" />
 

            </td>
        </tr>
    </table>
 

</asp:Content>

