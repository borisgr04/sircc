<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DetPSolicitudes.ascx.vb" Inherits="Controles_DetPSolicitudes" %>

<%@ Register src="../Progreso/Progress.ascx" tagname="Progress" tagprefix="uc11" %>

<%@ Register src="ConPSolicitudes.ascx" tagname="ConPSolicitudes" tagprefix="uc1" %>

<style type="text/css">
    .style5
    {
        width: 286px;
    }
    .style6
    {
        width: 154px;
    }
    .style7
    {
        width: 109px;
    }
    .style8
    {
        width: 65px;
    }
</style>

<asp:UpdatePanel ID="UpdDetPSol" runat="server" UpdateMode="Conditional">
<ContentTemplate>
          
                       <table style="width: 610px">
                <tr>
                    <td class="style7" >
             
                        N° Solicitud</td>
                    <td class="style6" >
                        <asp:TextBox ID="TxtCodCon" runat="server" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="style8">
                        <asp:ImageButton ID="IBtnBuscarSol" runat="server" SkinID="IBtnBuscar" />
                    </td>
                    <td >
                        <asp:ImageButton ID="IBtnAbrir" runat="server" SkinID="IBtnAbrir" />
                    </td>
                    <td >
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                </tr>
                           <tr>
                               <td class="style7" >
                                   &nbsp;</td>
                               <td class="style6" >
                                   &nbsp;</td>
                               <td class="style8">
                                   Buscar</td>
                               <td >
                                   Abrir</td>
                               <td >
                                   &nbsp;</td>
                               <td >
                                   &nbsp;</td>
                           </tr>
                <tr>
                    <td colspan="6" >
                        <asp:Label ID="MsgResult" runat="server" Height="30px" Visible="False" 
                            Width="90%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" 
                            CellPadding="4" DataKeyNames="Num_Sol" EnableModelValidation="True" 
                            Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="84px" 
                            Width="95%" 
                            EmptyDataText="No se encontraro la solicitud en la base de datos ">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <EmptyDataTemplate>
                                <asp:Label ID="MsgResult" runat="server" CssClass="alerta" SkinID="MsgResult" 
                                    Text="No se ha encontrado esta solicitud."></asp:Label>
                            </EmptyDataTemplate>
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <Fields>
                                <asp:BoundField DataField="Cod_Sol" HeaderText="Número de la Solicitud" 
                                    SortExpression="Cod_Sol">
                                <ItemStyle Font-Bold="True" Font-Size="Medium" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOM_TPROC" HeaderText="Modalidad de Contratación" 
                                    SortExpression="NOM_TPROC" />
                                <asp:BoundField DataField="OBJ_SOL" HeaderText="Objeto" 
                                    SortExpression="OBJ_SOL" />
                                <asp:BoundField DataField="Dep_Nec" 
                                    HeaderText="Dependencia que Genera la Necesidad" SortExpression="Dep_Nec" />
                                <asp:BoundField DataField="DEP_DEL" 
                                    HeaderText="Dependencia a Cargo del Proceso" SortExpression="DEP_DEL" />
                                <asp:BoundField DataField="Encargado" HeaderText="Funcionario Encargado" 
                                    SortExpression="Encargado" />
                                <asp:BoundField DataField="EST_CONCEPTO" HeaderText="Concepto de Revisión" />
                            </Fields>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderTemplate>
                                INFORMACIÓN DETALLADA DE LA SOLICITUD
                            </HeaderTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:DetailsView>
                   </td>
                </tr>
            </table>
   </ContentTemplate></asp:UpdatePanel>                   
   
   <asp:UpdateProgress ID="UpdPrgDetPSol" runat="server" AssociatedUpdatePanelID="UpdDetPSol">
                <progresstemplate>
                    <uc11:Progress ID="Progress1" runat="server" />
                </progresstemplate>
</asp:UpdateProgress> 
        <asp:Panel ID="PanelSolicitudes" runat="server" BackColor="White" Width="650px">
            <asp:Panel ID="Panel2" runat="server" BorderColor="White" CssClass="BarTitleModal2" Height="27px" Width="649px">
                <table style="width:100%;">
                    <tr>
                        <td class="style5">
                            <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Buscar ..." Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 803px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar1" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
             <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
            
                 <uc1:ConPSolicitudes ID="ConPSolicitudes1" runat="server" />
            
            </asp:Panel>
        </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Button2" runat="server"></asp:Button>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupSolicitudes" 
        runat="server"
        TargetControlID="Button2"
        BackgroundCssClass="modalBackground"
        PopupControlID="PanelSolicitudes" 
        DropShadow="True"
        CancelControlID="BtnCerrar1"
        PopupDragHandleControlID="Panel2">
        </ajaxToolkit:ModalPopupExtender>
        
        



                

    
    