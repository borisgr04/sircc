<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grdProy.ascx.vb" Inherits="CtrlUsr_grdOblig_grdProy" %>
                            
                            <%@ Register src="ConProyectos.ascx" tagname="ConProyectos" tagprefix="uc1" %>
<style type="text/css">
    .style2
    {
        width: 23px;
    }
    .style9
    {
        width: 178px;
    }
    .style10
    {
        width: 611px;
    }
    .style11
    {
        width: 134px;
    }
    .style12
    {
        width: 263px;
    }
    .style3
    {
        width: 72px;
    }
    .style1
    {
        width: 291px;
    }
    .style6
    {
        width: 26px;
    }
    .style8
    {
        width: 385px;
    }
    .style4
    {
        height: 71px;
        text-align: left;
    }
    </style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Label ID="Label1" runat="server" 
    CssClass="Titulo" Text="PROYECTOS"></asp:Label>
        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" DataKeyNames="Proyecto" EnableModelValidation="True" 
                                ForeColor="#333333" GridLines="None" 
    Width="100%">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField HeaderText="Proyecto" SortExpression="Proyecto">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNro_Cdp" runat="server" Text='<%# Eval("Proyecto")  %>' 
                                                Width="100%"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNewProyecto" runat="server" Width="100%"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LbProyecto" runat="server" Text='<%# Bind("Proyecto") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre del Proyecto" 
                                        SortExpression="Nombre_Proyecto">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombre_Proyecto" runat="server" Text='<%# Eval("Nombre_Proyecto") %>' 
                                                Width="100%"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LbNombre_Proyecto" runat="server" 
                                                Text='<%# Eval("Nombre_Proyecto") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="80%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" 
                                                CommandName="AddNew" Text="Agregar..." 
                            ForeColor="White"></asp:LinkButton>
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
        <p>
            <table style="width:100%;">
                <tr>
                    <td class="style9">
                        <asp:Label ID="Label2" runat="server" 
                                            CssClass="selectIndex" Text="Seleccionar Proyecto"></asp:Label>
                    </td>
                    <td class="style2">
                        &nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style9">
                        <asp:TextBox ID="TxtProyecto" runat="server" Width="171px" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="style2">
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                                            Height="32px" SkinID="IBtnBuscar" Width="32px" />
                    </td>
                    <td class="style12">
                        <asp:TextBox ID="TxtNomProyecto" runat="server" Width="260px" 
                            AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton ID="IbtnGuardar" runat="server" SkinID="IBtnGuardar" />
                    </td>
                </tr>
                <tr>
                    <td class="style9">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </p>
    </ContentTemplate>
</asp:UpdatePanel>
<p>
    &nbsp;</p>
<asp:Button ID="Button2" runat="server" style="DISPLAY: none" />
<ajaxToolkit:ModalPopupExtender ID="ModalPopupSolicitudes" runat="server" 
    BackgroundCssClass="modalBackground" CancelControlID="BtnCerrar1" 
    DropShadow="True" PopupControlID="PanelSolicitudes" 
    PopupDragHandleControlID="Panel2" TargetControlID="Button2">
</ajaxToolkit:ModalPopupExtender>
<p>
    &nbsp;</p>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="PanelSolicitudes" runat="server" 
    BackColor="White" Width="650px">
            <asp:Panel ID="Panel2" runat="server" 
        CssClass="BarTitleModal2" Height="26px" Width="648px">
                <table style="width:100%;">
                    <tr>
                        <td class="style11">
                            <asp:Label ID="Label3" runat="server" 
                        Text="Buscar Proyectos"></asp:Label>
                        </td>
                        <td class="style10">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar1" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <uc1:ConProyectos ID="ConProyectos1" runat="server" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>


                            
                        
                        

                        