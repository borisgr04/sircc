<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdProyC.ascx.vb" Inherits="CtrlUsr_grdOblig_grdProyC" %>
<%@ Register Src="../grdProy/ConProyectos.ascx" TagName="ConProyectos" TagPrefix="uc1" %>
<asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CellPadding="4"
    DataKeyNames="Proyecto" EnableModelValidation="True" ForeColor="#333333" GridLines="None"
    ShowFooter="True" Width="100%">
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <Columns>
        <asp:TemplateField HeaderText="Proyecto" SortExpression="Proyecto">
            <EditItemTemplate>
                <asp:TextBox ID="txtNro_Cdp" runat="server" Text='<%# Eval("Proyecto")  %>' Width="100%"></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txtNewProyecto" runat="server" Width="100%"></asp:TextBox>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="LbProyecto" runat="server" Text='<%# Bind("Proyecto") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="20%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre del Proyecto" SortExpression="Nombre_Proyecto">
            <EditItemTemplate>
                <asp:TextBox ID="txtNombre_Proyecto" runat="server" Text='<%# Eval("Nombre_Proyecto") %>'
                    Width="100%"></asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="LbNombre_Proyecto" runat="server" Text='<%# Eval("Nombre_Proyecto") %>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle Width="80%" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Eliminar"></asp:LinkButton>
            </ItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="AddNew"
                    Text="Agregar..." ForeColor="White"></asp:LinkButton>
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
<asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
<%--<p>
    &nbsp;</p>
<table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Código del Proyecto"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Nombre del Proyecto"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TxtCodPro" runat="server"></asp:TextBox>
            <asp:ImageButton ID="IBtnBuscar" runat="server" SkinID="IBtnBuscar" />
        </td>
        <td>
            <asp:TextBox ID="TxtNomPro" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
<asp:Panel ID="Panel1" runat="server" Width="639px" BackColor="White">
    <asp:Panel ID="Panel2" runat="server" CssClass="BarTitleModal2" Height="26px">
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    <asp:Label ID="Label33" runat="server" Text="Seleccionar Proyectos"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="BtnCerrar" runat="server" Text="X" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel3" ScrollBars="Both" runat="server" Height="473px">
        <uc1:ConProyectos ID="ConProyectos1" runat="server" />
    </asp:Panel>
</asp:Panel>
<asp:Button Style="display: none" ID="Btn_Target" runat="server"></asp:Button>
<ajaxToolkit:ModalPopupExtender ID="modalProy" runat="server" Drag="True" CancelControlID="BtnCerrar"
    PopupDragHandleControlID="Panel2" PopupControlID="Panel1" TargetControlID="Btn_Target"
    BackgroundCssClass="modalBackground" DropShadow="True">
</ajaxToolkit:ModalPopupExtender>
--%>