<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Anulacion.aspx.vb" Inherits="Solicitudes_Anulacion_Anulacion" %>

<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTerxDep.ascx" TagName="consultaterxDep"
    TagPrefix="uc1" %>
<%@ Register Src="../../CtrlUsr/DepSolicitudes/DetPSolicitudes.ascx" TagName="DetPSolicitudes"
    TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/Solicitudes/DetPSolicitudesAll.ascx" TagName="DetPSolicitudesAll"
    TagPrefix="uc3" %>
<%@ Register Src="../../CtrlUsr/Progreso/Progress.ascx" TagName="Progress" TagPrefix="ucProg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
   <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
        
        <div class="Titulo" >
            Anulación de Solicitudes
        </div>
  
   <table style="width: 610px">
                <tr>
                    <td class="style7" style="width: 135px">
                      <asp:Label ID="NumSolicitud" runat="server" 
                            Text="No Solicitud" style="font-weight: 700"></asp:Label>
                    </td>
                    </td>
                    <td class="style7" style="width: 134px">
                        <asp:TextBox ID="TxtCod" runat="server" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="style7">
                        <asp:ImageButton ID="BtnBuscar" runat="server" SkinID="IBtnAbrir" 
                            Height="32px" />
                    </td>
                </tr>
                <tr>
                    <td class="style7" style="width: 135px">
                        &nbsp;</td>
                    <td class="style7" style="width: 134px">
                        &nbsp;</td>
                    <td class="style7">
                        Buscar</tr>
             </table>
        <asp:UpdatePanel ID="UpdAsig" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <%--<uc3:DetPSolicitudesAll ID="DetPSolicitudesAll1" runat="server" />--%>

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

                
                <asp:Label ID="LbMsg" runat="server" SkinID="MsgResult"><br /></asp:Label>
                
                
                <div class="fila" >
                <label for="txtObs"> Observación </label>
                <asp:TextBox ID="txtObs"  Width="100%" Rows="5" TextMode="MultiLine" placeholder ="Motivos de la Anulación" runat="server"></asp:TextBox>
                </div>
                <div class="fila" >
                <asp:Button ID="BtnAnular" runat="server" Text="Anular" CssClass="button_example" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
