<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Con_Documentos.aspx.vb" Inherits="Consultas_AvisosActD_Con_Documentos" %>

<%@ Register src="../../CtrlUsr/DetPContratos/DetPContratoF.ascx" tagname="DetPContratoF" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true" EnablePartialRendering="true" >
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:DetPContratoF ID="DetPContratoF1" runat="server" />
            <br />
            <asp:Label ID="Label4" runat="server" CssClass="Titulo" 
                Text="Documentos del Proceso"></asp:Label>
            <br />
            <table style="width:50%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="text-align:right; width: 409px;">
                        &nbsp;</td>
                    <td style="text-align:center;">
                        <asp:ImageButton ID="ImageButton1" runat="server" SkinID="IBtnDescargarZip" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="text-align:right; width: 409px;">
                        &nbsp;</td>
                    <td style="text-align:center;">
                        Descargar Todo</td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="grdDocP" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="Id" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" SortExpression="ID" />
                    <asp:BoundField DataField="NOM_ETA" HeaderText="Etapa" 
                        SortExpression="NOM_ETA" />
                    <asp:BoundField DataField="DES_TIP" HeaderText="Documento" 
                        SortExpression="DES_TIP" />
                    <asp:BoundField DataField="Nombre" HeaderText="Descripción" 
                        SortExpression="Nombre" />
                    <asp:BoundField DataField="Fec_Doc" DataFormatString="{0:d}" 
                        HeaderText="Fecha Doc" SortExpression="Fec_Doc" />
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/2013/Dowload_Doc.png" 
                        ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

