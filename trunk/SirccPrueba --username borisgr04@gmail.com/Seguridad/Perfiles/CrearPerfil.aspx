<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CrearPerfil.aspx.vb" Inherits="Seguridad_Perfiles_crearPerfil" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<div class="demoarea">
    &nbsp;<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
&nbsp;<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="~/Seguridad/Perfiles/ModPerfil.aspx" __designer:wfdid="w17">Administrar Perfiles</asp:HyperLink>&nbsp; <TABLE style="WIDTH: 600px"><TBODY><TR><TD class="Titulos" colSpan=2><asp:Label id="msgResult" runat="server" Width="90%" Visible="False" Text="Label" Height="30px"></asp:Label></TD></TR><TR><TD class="Titulos" colSpan=2>REGISTRO DE PERFIL</TD></TR><TR><TD colSpan=2>
                &nbsp;</TD></TR><TR><TD colSpan=2>NOMBRE PERFIL
                    <asp:TextBox ID="TxtNomPer" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="BtnAgregar" runat="server" onclick="BtnAgregar_Click" 
                        Text="Agregar" />
                    </TD></TR>
                <tr>
                    <td colspan="2">
                        Módulo:<asp:DropDownList ID="CboMod" runat="server" AutoPostBack="True" 
                            DataSourceID="ObjModulos" DataTextField="Nom_Mod" DataValueField="Cod_Mod">
                        </asp:DropDownList>
                        <asp:Button ID="BtnAct" runat="server" Text="Consultar" />
                    </td>
                </tr>
                <TR><TD style="text-align: left;" colspan="2">
                <div style="overflow:scroll; height:400px">
                    <asp:TreeView ID="Tvw" runat="server" ShowCheckBoxes="Root" ShowLines="True" >
                    </asp:TreeView>
                    </div>
                    </TD></TR><TR><TD style="WIDTH: 100px">&nbsp;</TD><TD style="WIDTH: 100px">&nbsp;</TD></TR>
                <tr>
                    <td style="WIDTH: 100px">
                    </td>
                    <td style="WIDTH: 100px">
                    </td>
                </tr>
                </TBODY></TABLE>
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnAgregar" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>&nbsp;&nbsp;<br />
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
                <div class="Loading">
                    <asp:Image ID="Image1" runat="server" SkinID="ImgProgress" />
                    Cargando …
                </div>
            </progresstemplate>
    </asp:UpdateProgress>
    <asp:ObjectDataSource ID="ObjModulos" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Modulos"></asp:ObjectDataSource>
    <br />
    </div>
</asp:Content>

