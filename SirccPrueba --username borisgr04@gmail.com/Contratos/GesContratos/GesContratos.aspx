<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GesContratos.aspx.vb" Inherits="Contratos_GesContratos_Default" %>

<%@ Register src="../../CtrlUsr/DetContratos/DetContratoD.ascx" tagname="DetContrato" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<style>
.disabledImageButton
{
     filter: alpha(opacity=30);
     opacity: .30;
     background-color:#111;
}
</style>

    <div class="demoarea">
    <br />
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

    

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
                    Text="GESTIÓN DE CONTRATOS"></asp:Label>
                <uc1:DetContrato ID="DetContrato1" runat="server"  />
                <br />
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                    
    <table  >
        <tr>
            <td colspan="6" 
                style="text-align: left; empty-cells: show; vertical-align: top;">
                
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 21px">
                <asp:Label ID="MsgResult" runat="server" Height="30px"
                    Width="90%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                Fecha Documento</td>
            <td colspan="5" >
                <asp:TextBox ID="txtFecDoc" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFecDoc_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtFecDoc">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td >
                Documento</td>
            <td colspan="3" >
                <asp:DropDownList ID="CboEstSig" runat="server" DataTextField="NOM_EST"
                    DataValueField="EST_FIN" DataSourceID="ObjRutaEst" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Label ID="LbEst" runat="server"></asp:Label>
            </td>
            <td >
            </td>
        </tr>
        <tr>
            <td >
                Observación</td>
            <td colspan="3" >
                <asp:TextBox ID="txtObs" runat="server" TextMode="MultiLine" Width="421px">.</asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td >
                N° de Visitas</td>
            <td colspan="3" >
                <asp:TextBox ID="TxtNVisitas" runat="server"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="TxtNVisitas_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="TxtNVisitas">
                </ajaxToolkit:FilteredTextBoxExtender>
                &nbsp; En el Periodo del Acta</td>
            <td >
                &nbsp;</td>
            <td >
            </td>
        </tr>
        <tr>
            <td >
                Valor Autorizado Pago</td>
            <td colspan="3" >
                <asp:TextBox ID="TxtValPago" runat="server">0</asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="TxtValPago_FilteredTextBoxExtender" FilterType="Custom, Numbers"
                                                ValidChars="."
                    runat="server" Enabled="True" TargetControlID="TxtValPago">
                </ajaxToolkit:FilteredTextBoxExtender>
                &nbsp; En el Acta</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                % de Ejecución Fisico</td>
            <td colspan="3" >
                <asp:TextBox ID="TxtPorFis" runat="server">0</asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Custom, Numbers"
                                                ValidChars="."
                    runat="server" Enabled="True" TargetControlID="TxtPorFis">
                </ajaxToolkit:FilteredTextBoxExtender>
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                <asp:ImageButton ID="BtnNuevo" runat="server" SkinID="IBtnNuevo" />
            </td>
            <td style="text-align: center">
                <asp:ImageButton ID="BtnGuardar" runat="server" Enabled="False" 
                    SkinID="IBtnGuardar" />
            </td>
            <td style="text-align: center">
                <asp:ImageButton ID="BtnCancelar" runat="server" Enabled="False" 
                    SkinID="IBtnCancelar" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                Nuevo</td>
            <td style="text-align: center">
                Guardar</td>
            <td style="text-align: center">
                Cancelar</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" >
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 21px; text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" style="height: 21px; text-align: center">
                <asp:ObjectDataSource ID="ObjRutaEst" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetByEstIni" 
                    TypeName="Est_Ruta">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DetContrato1" DefaultValue="00" Name="EST_INI" 
                            PropertyName="Estado" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    <br />
    <br />
                    <asp:Label ID="Label2" runat="server" Text="Total por Pagar"></asp:Label>
                    &nbsp;
                    <asp:Label ID="lbTotalPorPagar" runat="server" CssClass="subheading"></asp:Label>
                    <br />
                    <br />

<asp:GridView ID="grdEstContratos" runat="server" 
        AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="ID" DataSourceID="ObjEstContratos" 
        ForeColor="#333333" ShowFooter="True" SkinID="gridView">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/BlueTheme/Select.png" SelectText=""
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="ESTADO_INICIAL" HeaderText="DOCUMENTO ANTERIOR" SortExpression="ESTADO_INICIAL" Visible="False" />
                        <asp:BoundField DataField="ESTADO_FINAL" HeaderText="DOCUMENTO " SortExpression="ESTADO_FINAL" />
                        <asp:BoundField DataField="NRO_DOC" HeaderText="N° DOCUMENTO" SortExpression="Nro_Doc" />
                        <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="FECHA" SortExpression="FECHA" />
                        <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" SortExpression="USUARIO" />
                        <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" Visible="False" />
                        <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" Visible="False" />
                        <asp:BoundField DataField="NVISITAS" HeaderText="N° VISITAS" Visible="True" />
                        <asp:BoundField DataField="por_eje_fis" HeaderText="% EJECUCIÓN FISICO" Visible="True"  >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VALOR_PAGO" HeaderText="VALOR AUTORIZADO A PAGAR" Visible="True" DataFormatString="{0:c}" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="EDITAR" 
                            ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                        <asp:TemplateField ShowHeader="False" HeaderText="ANULAR">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Anular" visible='<%#IIF((DataBinder.Eval(Container.DataItem, "Ult")="OK"),True,False)%>' 
                                    Text="Anular" CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex")) %>'  ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                    
                <br />
   
                <asp:DetailsView ID="DetailsView1" runat="server" 
        AutoGenerateRows="False" CellPadding="4"
                    DataSourceID="ObjDetEstContratos" ForeColor="#333333" 
        GridLines="None" HeaderText="DETALLE"
                    Height="50px" Width="420px" EnableModelValidation="True">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <Fields>
                        <asp:BoundField DataField="ESTADO_FINAL" HeaderText="DOCUMENTO" 
                            SortExpression="ESTADO_FINAL" />
                        <asp:BoundField DataField="ESTADO_INICIAL" HeaderText="DOCUMENTO ANTERIOR" 
                            SortExpression="ESTADO_INICIAL" />
                        <asp:BoundField DataField="FECHA" DataFormatString="{0:D}" HeaderText="FECHA" SortExpression="FECHA" />
                        <asp:BoundField DataField="DOCUMENTO" HeaderText="DOCUMENTO" SortExpression="DOCUMENTO" />
                        <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" SortExpression="USUARIO" />
                        <asp:BoundField DataField="NRO_CONTRATO" HeaderText="NRO_CONTRATO" SortExpression="NRO_CONTRATO" />
                        <asp:BoundField DataField="EXT" HeaderText="EXT" SortExpression="EXT" />
                        <asp:BoundField DataField="DIAS_EJEC" HeaderText="DIAS_EJEC" ReadOnly="True" SortExpression="DIAS_EJEC" />
                        <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" SortExpression="OBSERVACION" />
                    </Fields>
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                        VerticalAlign="Middle" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:DetailsView>

                </asp:Panel>
                </ContentTemplate>
                </asp:UpdatePanel>

                <asp:ObjectDataSource ID="ObjEstContratos" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyCod_Con" 
                    TypeName="EstContratos">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DetContrato1" Name="cod_con" 
                            PropertyName="cod_con" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjDetEstContratos" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyID" 
                    TypeName="EstContratos">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="grdEstContratos" Name="ID" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>


    </div>
    </asp:Content>

