<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DetPSolicitudesAll.ascx.vb" Inherits="Controles_DetPSolicitudesAll" %>
<%@ Register src="ConPSolicitudesPK.ascx" tagname="ConPSolicitudesPK" tagprefix="uc1" %>

<asp:UpdatePanel ID="UpdCSol" runat="server" UpdateMode="Conditional">
<ContentTemplate>
            <table style="width: 610px">
                <tr>
                    <td class="style7">
                      <asp:Label ID="NumSolicitud" runat="server" 
                            Text="No Solicitud" style="font-weight: 700"></asp:Label>
                    </td>
                    </td>
                    <td class="style7">
                        <asp:TextBox ID="TxtCod" runat="server" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="style7">
                        <asp:ImageButton ID="IBtnBuscar" runat="server" SkinID="IBtnBuscar" 
                            Height="32px" Width="32px" />
                    </td>
                    <td class="style7">
                        <asp:ImageButton ID="BtnBuscar" runat="server" SkinID="IBtnAbrir" 
                            Height="32px" />
                    </td>
                    <td class="style7">
                        <asp:ImageButton ID="IBtnNuevaSol" runat="server" SkinID="IBtnNuevo" />
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style7">
                        Buscar</td>
                    <td class="style7">
                        Abrir</td>
                    <td class="style7">
                        Nueva Solicitud</td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 14px; text-align: center;">
                        <asp:Label ID="MsgResult" runat="server" Height="30px" Visible="False" 
                            Width="90%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" 
                            CellPadding="4" DataKeyNames="Num_Sol" EnableModelValidation="True" 
                            Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="84px" 
                            Width="95%">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <EmptyDataTemplate>
                                <asp:Label ID="MsgResult" runat="server" CssClass="alerta" SkinID="MsgResult" 
                                    Text="No se encontraro la solicitud en la base de datos "></asp:Label>
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
                <br />
                    </td>
                </tr>
            </table>
            
        </ContentTemplate></asp:UpdatePanel>

        <asp:Panel ID="PanelSolicitudes" runat="server" BackColor="White" Width="650px">
            <asp:Panel ID="Panel2" runat="server" BorderColor="White" CssClass="BarTitleModal2"
                Height="27px" Width="649px">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 823px">
                         <asp:Label ID="Label1" runat="server" ForeColor="White" Width="100%" Text="Buscar Solicitud" 
                                Font-Bold="True"></asp:Label>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar1" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            
            <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
    
                
    
                
    
                
    
                
    
                
    
                <uc1:ConPSolicitudesPK ID="ConPSolicitudesPK1" runat="server" />
    
                
    
                
    
                
    
                
    
                
    
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
        
        



                

    
    