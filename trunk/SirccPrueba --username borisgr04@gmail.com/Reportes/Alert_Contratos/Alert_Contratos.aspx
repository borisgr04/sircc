<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Alert_Contratos.aspx.vb" Inherits="Reportes_Alert_Contratos_Alert_Contratos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <p>
                    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </ajaxToolkit:ToolkitScriptManager>

        &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    CONTRATOS X TERMINAR</td>
                <td style="width: 4px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Vigencia</td>
                <td>
                        <asp:DropDownList ID="CboFilVig0" runat="server" 
                            DataSourceID="Vigencias0" DataTextField="year_vig" DataValueField="year_vig" 
                            Width="111px">
                        </asp:DropDownList>
                        </td>
                <td style="width: 4px">
                        &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Filtro</td>
                <td>
                        <asp:DropDownList ID="CboTipo" runat="server">
                            <asp:ListItem Value="CxT">Contratos x Terminar</asp:ListItem>
                            <asp:ListItem Value="CxL">Contratos x Liquidar</asp:ListItem>
                            <asp:ListItem Value="PxV">Polizas x Vencer</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                <td style="width: 4px">
                        &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Dias para Vencerce</td>
                <td>
                    <asp:TextBox ID="txtNdias" runat="server">30</asp:TextBox>
                    <asp:Button ID="BtnGuardar" runat="server" Text="Actualizar" />
                </td>
                <td style="width: 4px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View1" runat="server">
                            <asp:LinkButton ID="ExpExcel0" runat="server">Exportar a Excel</asp:LinkButton>
                            <br />
                            <asp:GridView ID="grdAlert_Contratos" runat="server" AllowPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Numero" 
                                DataSourceID="ObjAlert_Contratos" EnableModelValidation="True">
                                <Columns>
                                    <asp:CommandField ButtonType="Image" 
                                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                                    <asp:BoundField DataField="Numero" HeaderText="Número" 
                                        SortExpression="Numero" />
                                    <asp:BoundField DataField="Fec_Sus_Con" DataFormatString="{0:d}" 
                                        HeaderText="Fecha Suscripción" SortExpression="Fec_Sus_Con" />
                                    <asp:BoundField DataField="fec_apr_pol" DataFormatString="{0:d}" 
                                        HeaderText="Fecha Legalización" SortExpression="fec_apr_pol" />
                                    <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" 
                                        HeaderText="Fecha Inicio" SortExpression="FechaInicio" />
                                    <asp:BoundField DataField="Total" HeaderText="Plazo (Inicial+Adiciones)" 
                                        SortExpression="Total" />
                                    <asp:BoundField DataField="xEjecutar" HeaderText="Por Ejecutar" 
                                        SortExpression="xEjecutar" />
                                    <asp:BoundField DataField="FechaFinal" DataFormatString="{0:d}" 
                                        HeaderText="Fecha Final(Acta)" />
                                    <asp:BoundField DataField="FechaLiq" DataFormatString="{0:d}" 
                                        HeaderText="Fecha Liquidación" SortExpression="FechaLiq" />
                                    <asp:BoundField DataField="fechafinalprob" DataFormatString="{0:d}" 
                                        HeaderText="Fecha Final Probable" SortExpression="fechafinalprob" />
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                                CellPadding="4" DataSourceID="ObjAlert_Contratos2" EnableModelValidation="True" 
                                ForeColor="#333333" GridLines="None" HeaderText="DETALLE DEL CONTRATO/CONVENIO" 
                                Height="50px" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                                <EditRowStyle BackColor="#999999" />
                                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                                <Fields>
                                    <asp:BoundField DataField="Numero" HeaderText="Numero" 
                                        SortExpression="Numero" />
                                    <asp:BoundField DataField="Obj_Con" HeaderText="Objeto" 
                                        SortExpression="Obj_Con" />
                                </Fields>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            </asp:DetailsView>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:LinkButton ID="ExpExcel" runat="server">Exportar a Excel</asp:LinkButton>
                            <br />
                            <asp:GridView ID="grdPolizas" runat="server" AllowPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="numero" 
                                DataSourceID="ObjAlert_Contratos4" EnableModelValidation="True">
                                <Columns>
                                    <asp:CommandField ButtonType="Image" 
                                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                                    <asp:BoundField DataField="NUMERO" HeaderText="N° Contrato" 
                                        SortExpression="NUMERO" />
                                    <asp:BoundField DataField="NRO_POL" HeaderText="N° Poliza" 
                                        SortExpression="NRO_POL" />
                                    <asp:BoundField DataField="NOM_POL" HeaderText="Amparo" 
                                        SortExpression="NOM_POL" />
                                    <asp:BoundField DataField="NOM_ASE" HeaderText="Aseguradora" 
                                        SortExpression="NOM_ASE" />
                                    <asp:BoundField DataField="FEC_POL" HeaderText="Fecha Vencimiento" 
                                        SortExpression="FEC_POL" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="TIP_POL" HeaderText="Tipo" 
                                        SortExpression="TIP_POL" />
                                </Columns>
                            </asp:GridView>
                            <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" 
                                CellPadding="4" DataSourceID="ObjAlert_Contratos3" EnableModelValidation="True" 
                                ForeColor="#333333" GridLines="None" HeaderText="DETALLE DEL CONTRATO/CONVENIO" 
                                Height="50px" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                                <EditRowStyle BackColor="#999999" />
                                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                                <Fields>
                                    <asp:BoundField DataField="Numero" HeaderText="Numero" 
                                        SortExpression="Numero" />
                                    <asp:BoundField DataField="Obj_Con" HeaderText="Objeto" 
                                        SortExpression="Obj_Con" />
                                </Fields>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            </asp:DetailsView>
                            <br />
                            <asp:HyperLink ID="hlContrato" runat="server" 
                                NavigateUrl="~/Consultas/Contratos/Contratos.aspx" Target="_blank">Ver Datalle</asp:HyperLink>
                            <asp:HiddenField ID="hdUrl" runat="server" 
                                Value="~/Consultas/Contratos/Contratos.aspx" />
                        </asp:View>
                    </asp:MultiView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="font-weight: 700">
                    <asp:ObjectDataSource ID="ObjAlert_Contratos" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                        TypeName="Alert_Contratos">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="CboTipo" Name="Tipo_Alerta" 
                                PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="txtNdias" Name="dias" PropertyName="Text" 
                                Type="Int32" />
                            <asp:ControlParameter ControlID="CboFilVig0" DefaultValue="" Name="Vigencia" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjAlert_Contratos4" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAlert_Polizas" 
                        TypeName="Alert_Contratos">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNdias" Name="dias" PropertyName="Text" 
                                Type="Int32" />
                            <asp:ControlParameter ControlID="CboFilVig0" DefaultValue="" Name="Vigencia" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjAlert_Contratos2" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                        TypeName="Alert_Contratos">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="grdAlert_Contratos" Name="numero" PropertyName="SelectedValue" 
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjAlert_Contratos3" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                        TypeName="Alert_Contratos">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="grdPolizas" Name="numero" PropertyName="SelectedValue" 
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td rowspan="5" valign="top" style="width: 4px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                        &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                        <asp:ObjectDataSource ID="Vigencias0" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                            TypeName="Vigencias"></asp:ObjectDataSource>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ExpExcel" />
            <asp:PostBackTrigger ControlID="ExpExcel0" />
        </Triggers>
        </asp:UpdatePanel>
        
    </p>
</asp:Content>

