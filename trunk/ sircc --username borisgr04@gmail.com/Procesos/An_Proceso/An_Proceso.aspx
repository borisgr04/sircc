<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="An_Proceso.aspx.vb" Inherits="Procesos_AnProceso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../../CtrlUsr/ConPContratos/ConPContratos.ascx" tagname="ConPContratos" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    
    <asp:UpdatePanel ID="UpdRad" runat="server">
        <ContentTemplate>
            <table style="width: 73%;">
                <tr>
                    <td colspan="7" style="height: 21px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" style="height: 21px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" style="height: 21px">
                        <asp:Label ID="lbClase0" runat="server" CssClass="Titulo" Font-Bold="True">DATOS DEL PROCESO A ANULAR</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 93px; height: 21px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 180px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 82px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 26px;">
                        &nbsp;</td>
                    <td style="height: 21px; width: 128px;">
                        &nbsp;</td>
                    <td style="height: 21px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 220px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 93px; height: 21px">
                        <asp:Label ID="Label1" runat="server" Text="Código del Proceso"></asp:Label>
                    </td>
                    <td style="height: 21px; width: 180px">
                        <asp:TextBox ID="TxtNumProc" runat="server" AutoPostBack="True" Width="177px"></asp:TextBox>
                    </td>
                    <td style="height: 21px; width: 82px">
                        <asp:ImageButton ID="BtnBuscar" runat="server" SkinID="IBtnBuscar" />
                    </td>
                    <td style="height: 21px; width: 26px;">
                        &nbsp;</td>
                    <td style="height: 21px; width: 128px;">
                        <asp:ImageButton ID="BtnRadicar" runat="server" Height="32px" 
                            ImageUrl="~/images/Operaciones/cancel.png" 
                            ToolTip="Anular Proceso Contratual" />
                    </td>
                    <td style="height: 21px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 220px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 21px" colspan="2">
                        &nbsp;</td>
                    <td style="height: 21px; width: 82px">
                        Buscar</td>
                    <td style="height: 21px; width: 26px;">
                        &nbsp;</td>
                    <td style="height: 21px; width: 128px;">
                        Anular</td>
                    <td style="height: 21px">
                        &nbsp;</td>
                    <td style="height: 21px; width: 220px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 21px">
                        <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
                    </td>
                    <td style="height: 21px; width: 220px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                            CellPadding="4" DataSourceID="ObjPcont" EnableModelValidation="True" 
                            ForeColor="#333333" GridLines="None" HeaderText="Proceso Contractual" 
                            Height="50px" Width="653px" DataKeyNames="Pro_sel_nro">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <EditRowStyle BackColor="#999999" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <Fields>
                                <asp:BoundField DataField="Pro_Sel_Nro" HeaderText="Código">
                                <ItemStyle Font-Size="Medium" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Vig_Con" HeaderText="Vigencia" />
                                <asp:BoundField DataField="Obj_Con" HeaderText="Objeto del Contrato" />
                                <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia de la Necesidad" />
                                <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia a Cargo" />
                                <asp:BoundField DataField="Nom_TProc" HeaderText="Modalidad de Contratación" />
                                <asp:BoundField DataField="TipDocumento" HeaderText="Documento Contractual" />
                                <asp:BoundField DataField="Val_Con" DataFormatString="{0:c}" 
                                    HeaderText="Valor del Contrato" />
                                <asp:BoundField DataField="Val_Apo_Gob" DataFormatString="{0:c}" 
                                    HeaderText="Valor Aportes Propios" />
                                <asp:BoundField DataField="Encargado" HeaderText="Encargado" />
                                <asp:BoundField DataField="Nom_Est" HeaderText="Estado" />
                            </Fields>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="Medium" 
                                ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        </asp:DetailsView>
                    </td>
                    <td valign="top" style="width: 220px">
                        &nbsp;</td>
                </tr>
            </table>
            <table style="width: 73%;">
                <tr>
                    <td>
                        Observacion</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox1" runat="server" Height="102px" TextMode="MultiLine" 
                            Width="650px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:ObjectDataSource ID="ObjPcont" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetByPk" 
                TypeName="PContratos">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtNumProc" Name="Num_PCon" PropertyName="Text" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
<br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
            
            
         <asp:Panel ID="PanelvConP" runat="server" BackColor="White" Width="900px" Height="500px">
            <asp:Panel ID="Panel6" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
                Height="27px" Width="100%" >
                <table style="width:100%;">
                    <tr>
                        <td style="width: 1159px">
                            <asp:Label ID="LbTitModal" runat="server" ForeColor="White" Text=" Consulta de Procesos a Cargo" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar2" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PnAreaT" ScrollBars="Both" runat="server" Height="473px">
            <uc4:ConPContratos ID="ConPContratos1" runat="server" />
            
            </asp:Panel>
             </asp:Panel>
        <asp:Button style="DISPLAY: none" id="Btn_Target2" runat="server"></asp:Button>
           <ajaxToolkit:ModalPopupExtender ID="ModalPopupConP" 
        runat="server"
        TargetControlID="Btn_Target2" 
        PopupControlID="PanelvConP" 
        CancelControlID="BtnCerrar2" 
        BackgroundCssClass="modalBackground"
        PopupDragHandleControlID="Panel4" 
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>   
</div>
</asp:Content>

