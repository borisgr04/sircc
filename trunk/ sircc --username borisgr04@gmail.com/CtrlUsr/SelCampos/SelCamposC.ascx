<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SelCamposC.ascx.vb" Inherits="CtrlUsr_SelCampos_SelCamposC" %>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>
    <asp:ObjectDataSource ID="ObjPlantillasCampos" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="PPlantillas_Campos">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdVista" DefaultValue="" Name="Vista" 
                PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <asp:HiddenField ID="HdVista" runat="server" Value="VCONTRATOS_SINC_P" />
        <br />
    <br />
        <asp:Label id="labelTit" runat="server" Text="Seleccione Columnas a Mostrar" class="SubTitulo"></asp:Label>
    <table >
    <tr>
    <td style="width: 309px">
        <asp:Label ID="Label1" runat="server" Text="Listado de Columnas" Font-Bold="true"></asp:Label>
        <asp:Button ID="BtnOrdenas" runat="server" Text="Ordenar" Visible="False" />
    </td>
    <td>
    </td>
    <td><asp:Label ID="Label2" runat="server" Text="Columnas Seleccionadas" Font-Bold="true"></asp:Label>
    </td>
    
    </tr>
        <tr>
            <td style="width: 309px" rowspan="10">
                    <asp:ListBox ID="ListBox1" runat="server" DataSourceID="ObjPlantillasCampos" 
                    DataTextField="Nom_Pla" DataValueField="Nom_Cam" Height="256px" 
                    Width="285px" SelectionMode="Multiple"></asp:ListBox>
            </td>
            <td style="width: 98px; text-align: center;" valign="bottom">
                            &nbsp;</td>
            <td rowspan="10">
                    <asp:ListBox ID="ListBox2" runat="server" Height="256px" 
                    Width="285px" SelectionMode="Multiple"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 98px; text-align: center;" valign="bottom">
                <ew:listtransfer id="ListTransfer5" runat="server" text="Subir" tooltip="Subir Campo"
                    transferfromid="listbox2" transfertoid="listbox1" transfertype="Up" Font-Bold="True" 
                                Font-Names="Arial Black" ImageUrl="~/images/2012/subir.png"></ew:listtransfer>
            </td>
        </tr>
        <tr>
            <td style="width: 98px; text-align: center;" valign="bottom">
                            Subir</td>
        </tr>
        <tr>
            <td style="width: 98px; text-align: center;" valign="bottom">
                            <ew:listtransfer id="ListTransfer2" runat="server" text=">>" tooltip="Agregar Campo"
                    transferfromid="LISTBOX1" transfertoid="LISTBOX2" transfertype="Control" 
                                Font-Bold="True" Font-Names="Arial Black" 
                                ImageUrl="~/images/2012/derechaazul.png"></ew:listtransfer>
            </td>
        </tr>
        <tr>
            <td style="width: 98px; text-align: center;" valign="bottom">
                            Agregar</td>
        </tr>
        <tr>
            <td style="width: 98px; text-align: center;" valign="top">
                <ew:listtransfer id="ListTransfer3" runat="server" text="<<" tooltip="Quitar Campo"
                    transferfromid="listbox2" transfertoid="listbox1" transfertype="Control" 
                    Font-Bold="True" Font-Names="Arial Black" 
                    ImageUrl="~/images/2012/izquierdaazul.png"></ew:listtransfer>
            </td>
        </tr>
        <tr>
            <td style="width: 98px; text-align: center;" valign="top">
                Quitar</td>
        </tr>
        <tr>
            <td style="width: 98px; text-align: center;" valign="top">
                <ew:listtransfer id="ListTransfer4" runat="server" text="Bajar" tooltip="Quitar Campo"
                    transferfromid="listbox2" transfertoid="listbox1" transfertype="Down" 
                    Font-Bold="True" Font-Names="Arial Black" ImageUrl="~/images/2012/Bajar.png"></ew:listtransfer>
            </td>
        </tr>
        <tr>
            <td style="width: 98px; text-align: center;" valign="top">
                Bajar</td>
        </tr>
        <tr>
            <td style="width: 98px; text-align: center;" valign="top">
                &nbsp;</td>
        </tr>
    </table>
    
    
    <br />
        
        <asp:Label ID="LbCampos" runat="server"></asp:Label>
<asp:Button ID="Button1" runat="server" Text="Button" />

