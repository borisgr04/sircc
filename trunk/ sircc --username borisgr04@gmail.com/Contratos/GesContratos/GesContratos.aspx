<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="GesContratos.aspx.vb" Inherits="Contratos_GesContratos_Default" %>

<%@ Register Src="../../CtrlUsr/DetContratos/DetContratoD.ascx" TagName="DetContrato"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <script src="<%= ResolveUrl("~/Scripts/jquery-1.9.1.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui-1.10.3.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui.js") %>" type="text/javascript"></script>
    <link rel="stylesheet" href="<%= ResolveUrl("~/Styles/base/jquery-ui.css") %>" />
    <%--<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/smoothness/jquery-ui.css") %>" />--%>
    <script type="text/javascript">

        function pageLoad(){
//            $("#tabs").tabs({
//                collapsible: true
//            });

            $('#<%=TxtCodCon.ClientID %>').blur(function () {
                var nro = 0;
                var TxtNroCto = $get('<%=TxtCodCon.ClientID %>');
                var CmbVig = $get('<%=CmbVigencia.ClientID %>');
                var cboTipo = $get('<%=cboTip.ClientID %>');
                if (TxtNroCto.value.length < 10) {
                    nro = CmbVig.value + cboTipo.value + pad(TxtNroCto.value, 4);
                }
                else {
                    nro = TxtNroCto.value;
                }
                TxtNroCto.value = nro;
            });
            function pad(str, max) {
                return str.length < max ? pad("0" + str, max) : str;
            }
        
        }
    </script>
    <div class="demoarea">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <h2 class="Titulo">
                    Gestión del Contrato
                </h2>
                <hr />
                <p>
                    <asp:Label ID="Label6" runat="server" CssClass="Caption" Text="Vigencia" Visible="False"></asp:Label>
                    <asp:DropDownList ID="CmbVigencia" runat="server" AutoPostBack="True" DataSourceID="ObjVigencias"
                        DataTextField="Year_Vig" DataValueField="Year_Vig" Visible="True">
                    </asp:DropDownList>
                    <asp:Label ID="Label3" runat="server" CssClass="Caption" Text="Tipo"></asp:Label>
                    <asp:DropDownList ID="CboTip" runat="server" AutoPostBack="True" CssClass="txt" DataSourceID="ObjTiposCont"
                        DataTextField="NOM_TIP" DataValueField="COD_TIP">
                    </asp:DropDownList>
                    <asp:Label ID="Label4" runat="server" CssClass="Caption" Text="Número"></asp:Label>
                    <asp:TextBox ID="TxtCodCon" runat="server" AutoPostBack="True"></asp:TextBox>
                    <asp:Button ID="BtnBuscar" runat="server" Text="" class="button_buscar" CausesValidation="False" />
                    <asp:Label ID="LbCodCod" runat="server"></asp:Label>
                    <a href="CGesContratos.aspx" title="Ir a opción de Filtro de Otros Contratos ">Volver
                        Filtro de Contratos</a>
                </p>
                <asp:HiddenField ID="hdEstado" runat="server" />
                <div style="height: 200px; overflow: auto">
                    <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" CellPadding="4"
                        DataKeyNames="Cod_Tpro" Font-Size="Small" ForeColor="#333333" GridLines="None"
                        Height="84px" Width="95%" EnableModelValidation="True">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EmptyDataTemplate>
                            <br />
                            El Contrato no existe o pertenece a una Delegación de la cual no esta autorizado.
                        </EmptyDataTemplate>
                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <Fields>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                            <asp:BoundField DataField="Numero" HeaderText="Número" SortExpression="Numero">
                                <ItemStyle Font-Bold="True" Font-Italic="False" Font-Size="Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="OBJ_CON" HeaderText="Objeto" SortExpression="OBJ_CON" />
                            <asp:BoundField DataField="CONTRATISTA" HeaderText="Contratista" SortExpression="CONTRATISTA" />
                            <asp:BoundField DataField="FEC_SUS_CON" HeaderText="Fecha de Suscripción" SortExpression="FEC_SUS_CON"
                                DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Valor_Total_Prop" DataFormatString="{0:c}" HeaderText="Valor Total   ">
                                <ItemStyle Font-Bold="True" Font-Size="Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PLAZO_TOTAL" HeaderText="Plazo de Ejecución Total" />
                            <asp:BoundField DataField="VAL_CON" DataFormatString="{0:c}" HeaderText="Valor Inicial  " />
                            <asp:BoundField DataField="PLA_EJE_CON" HeaderText="Plazo de Ejecución Inicial" />
                            <asp:BoundField DataField="NRO_ADI" HeaderText="Cantidad de Adiciones " />
                            <asp:BoundField DataField="VAL_ADI" DataFormatString="{0:c}" HeaderText="Valor Adicionado " />
                            <asp:BoundField DataField="PLA_ADI" HeaderText="Plazo de Ejecución Adicional" />
                            <asp:BoundField DataField="Valor_Total_Doc" DataFormatString="{0:c}" HeaderText="Valor Total del Contrato/Convenio" />
                            <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Acta de Inicio" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="fec_apr_pol" HeaderText="Fecha Legalización" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Dependencia" HeaderText="Dependencia que Genera la Necesidad"
                                SortExpression="Dependencia" />
                            <asp:BoundField DataField="DependenciaP" HeaderText="Dependencia a Cargo del Proceso"
                                SortExpression="DependenciaP" />
                            <asp:BoundField DataField="Abogado" HeaderText="Proyectó" />
                            <asp:BoundField DataField="RevisadoPor" HeaderText="Revisado Por" />
                        </Fields>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderTemplate>
                            INFORMACIÓN DETALLADA DEL CONTRATO
                        </HeaderTemplate>
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:DetailsView>
                </div>
                <hr />
                <div id="tabs">
                    <ul>
                        <li><a href="#tabs-1">Registrar de Actas</a></li>
                        <li><a href="#tabs-2">Listado de Actas</a></li>
                    </ul>
                    <hr />
                    <div id="tabs-1">
                        <fieldset id="regFiltro">
                            <legend>Registro de Datos</legend>
                            <asp:Label ID="MsgResult" runat="server" Height="30px" Width="90%"></asp:Label>
                            <div id="lbMsgResult">
                            </div>
                            <div id="form">
                                <h2 class="Titulo">
                                    Registro de Actas</h2>
                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <p>
                                        <label>
                                            Fecha Documento <span class="small"></span>
                                        </label>
                                        <asp:TextBox ID="txtFecDoc" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtFecDoc_CalendarExtender" runat="server" Enabled="True"
                                            TargetControlID="txtFecDoc">
                                        </ajaxToolkit:CalendarExtender>
                                    </p>
                                    <p>
                                        <label>
                                            Documento <span class="small"></span>
                                        </label>
                                        <asp:DropDownList ID="CboEstSig" runat="server" DataTextField="NOM_EST" DataValueField="EST_FIN"
                                            DataSourceID="ObjRutaEst" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:Label ID="LbEst" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <label>
                                            Observación <span class="small"></span>
                                        </label>
                                        <asp:TextBox ID="txtObs" runat="server" TextMode="MultiLine" Width="421px">.</asp:TextBox>
                                    </p>
                                    <p>
                                        <label>
                                            N° de Visitas <span class="small"></span>
                                        </label>
                                        <asp:TextBox ID="TxtNVisitas" runat="server"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="TxtNVisitas_FilteredTextBoxExtender" runat="server"
                                            Enabled="True" FilterType="Numbers" TargetControlID="TxtNVisitas">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        &nbsp; En el Periodo del Acta
                                    </p>
                                    <p>
                                        <label>
                                            Valor Autorizado Pago <span class="small"></span>
                                        </label>
                                        <asp:TextBox ID="TxtValPago" runat="server">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="TxtValPago_FilteredTextBoxExtender" FilterType="Custom, Numbers"
                                            ValidChars="." runat="server" Enabled="True" TargetControlID="TxtValPago">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        &nbsp; En el Acta
                                    </p>
                                    <p>
                                        <label>
                                            % de Ejecución Fisico <span class="small"></span>
                                        </label>
                                        <asp:TextBox ID="TxtPorFis" runat="server">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Custom, Numbers"
                                            ValidChars="." runat="server" Enabled="True" TargetControlID="TxtPorFis">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </p>
                                    <span id="botones">
                                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" CssClass="button_example" />
                                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="button_example" />
                                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="button_example" />
                                    </span>
                                    <br />
                                </asp:Panel>
                            </div>
                    </div>
                    <br />
                    <div id="tabs-2">
                        <h2 class="Titulo">
                            Listado de Actas</h2>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Total por Pagar"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lbTotalPorPagar" runat="server" CssClass="subheading"></asp:Label>
                        <asp:GridView ID="grdEstContratos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataKeyNames="ID" DataSourceID="ObjEstContratos" ForeColor="#333333" ShowFooter="True"
                            SkinID="gridView" EnableModelValidation="True">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/BlueTheme/Select.png"
                                    SelectText="" ShowSelectButton="True" />
                                <asp:BoundField DataField="ID" HeaderText="CODIGO VERIFICACION" SortExpression="ID" />
                                <asp:BoundField DataField="ESTADO_INICIAL" HeaderText="DOCUMENTO ANTERIOR" SortExpression="ESTADO_INICIAL"
                                    Visible="False" />
                                <asp:BoundField DataField="ESTADO_FINAL" HeaderText="DOCUMENTO " SortExpression="ESTADO_FINAL" />
                                <asp:BoundField DataField="NRO_DOC" HeaderText="N° DOCUMENTO" SortExpression="Nro_Doc" />
                                <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="FECHA" SortExpression="FECHA" />
                                <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" SortExpression="USUARIO" />
                                <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" Visible="False" />
                                <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" Visible="False" />
                                <asp:BoundField DataField="NVISITAS" HeaderText="N° VISITAS" Visible="True" />
                                <asp:BoundField DataField="por_eje_fis" HeaderText="% EJECUCIÓN FISICO" Visible="True">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VALOR_PAGO" HeaderText="VALOR AUTORIZADO A PAGAR" Visible="True"
                                    DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="EDITAR" ImageUrl="~/images/Operaciones/Edit2.png"
                                    Text="Editar" />
                                <asp:TemplateField ShowHeader="False" HeaderText="ANULAR">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Anular"
                                            Visible='<%#IIF((DataBinder.Eval(Container.DataItem, "Ult")="OK"),True,False)%>'
                                            Text="Anular" CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex")) %>'></asp:LinkButton>
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
                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
                            DataSourceID="ObjDetEstContratos" ForeColor="#333333" GridLines="None" HeaderText="DETALLE"
                            Height="50px" Width="420px" EnableModelValidation="True">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <Fields>
                                <asp:BoundField DataField="ESTADO_FINAL" HeaderText="DOCUMENTO" SortExpression="ESTADO_FINAL" />
                                <asp:BoundField DataField="ESTADO_INICIAL" HeaderText="DOCUMENTO ANTERIOR" SortExpression="ESTADO_INICIAL" />
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
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource ID="ObjEstContratos" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetbyCod_Con" TypeName="EstContratos">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtCodCon" Name="cod_con" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjDetEstContratos" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetbyID" TypeName="EstContratos" InsertMethod="Insert" UpdateMethod="Update">
        <SelectParameters>
            <asp:ControlParameter ControlID="grdEstContratos" Name="ID" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjTiposCont" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetRecords" TypeName="Tipos"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjContratos" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetByPk" TypeName="Contratos">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetRecords" TypeName="Vigencias"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjRutaEst" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetByEstIni" TypeName="Est_Ruta">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdEstado" DefaultValue="" Name="EST_INI" PropertyName="Value"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
