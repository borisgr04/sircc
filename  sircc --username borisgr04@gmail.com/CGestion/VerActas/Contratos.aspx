<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Contratos.aspx.vb" Inherits="Consultas_Contratos_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="../../CtrlUsr/DetContratosN/DetContratoN.ascx" tagname="DetContratoN" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/ConDocContratos/ConDocContratos.ascx" tagname="ConDocContratos" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<script src="<%= ResolveUrl("~/Scripts/jquery-1.9.1.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui-1.10.3.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui.js") %>" type="text/javascript"></script>
    <link rel="stylesheet" href="<%= ResolveUrl("~/Styles/base/jquery-ui.css") %>" />
    <%--<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/smoothness/jquery-ui.css") %>" />--%>
    <script type="text/javascript">

        function pageLoad() {
            //            $("#tabs").tabs({
            //                collapsible: true
            //            });

            $('#<%=TxtCodCon.ClientID %>').keypress(function (e) {
                if (e.which == 13) {
                    numeroC();
                }
            });
            $('#<%=TxtCodCon.ClientID %>').blur(function () {
                numeroC();
            });
            function numeroC() {
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
            }
            $('#<%=TxtCodCon.ClientID %>').blur(function () {
                numeroC();
            });
            function pad(str, max) {
                return str.length < max ? pad("0" + str, max) : str;
            }

        }
    </script>
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    
    <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="Consulta de Contratos"></asp:Label>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="float:right">
            <a href="VerActas.aspx" title="Ir a Verificar Actas" class="button_example">Verficicación de Actas</a>
            </div>

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
                
            <br />
            <asp:ObjectDataSource ID="ObjObli" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="CObligaciones">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            
            <asp:ObjectDataSource ID="ObjProy" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyNum_Proc" 
                TypeName="CProyectos">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            
            <asp:ObjectDataSource ID="ObjCDP" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="CDP_Contratos">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            
            <asp:ObjectDataSource ID="ObjRubros" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Rubros_Contratos">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <ajaxToolkit:Accordion ID="Accordion1" runat="server" SelectedIndex="-1"
            HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContentByA" FadeTransitions="true" FramesPerSecond="40" 
            TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
            <Panes>
                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header><a href="" class="accordionLink"> 1. REGISTRO PRESUPUESTAL </a></Header>
                <Content>
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjRP" 
                EnableModelValidation="True" Width="536px" AutoGenerateColumns="false" SkinID="gridView">
                <Columns>
                    <asp:BoundField DataField="Nro_RP" HeaderText="No. RP" />
                    <asp:BoundField DataField="Fec_Rp" HeaderText="Fecha RP" />
                    <asp:BoundField DataField="Val_RP" HeaderText="Valor RP" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField DataField="Doc_Sop" />
                </Columns>
            </asp:GridView>
                </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header><a href="" class="accordionLink"> 2. POLIZAS DE GARANTIA </a></Header>
                <Content>
                    <asp:GridView ID="GridView2" runat="server" DataSourceID="ObjPol" 
                EnableModelValidation="True" AutoGenerateColumns="false" SkinID="gridView">
                <Columns>
                    <asp:BoundField DataField="Cod_Pol" HeaderText="Código" />
                    <asp:BoundField DataField="Nom_Pol" HeaderText="Nombre de Poliza" />
                    <asp:BoundField DataField="Nro_pol" HeaderText="Número" />
                    <asp:BoundField DataField="Nom_Ase" HeaderText="Aseguradora" />
                    <asp:BoundField DataField="Fec_Pol" HeaderText="Fecha Poliza" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Val_Pol" HeaderText="Valor" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField DataField="Tip_Pol" HeaderText="Tipo" />
                </Columns>
            </asp:GridView>
                </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header><a href="" class="accordionLink"> 3. IMPUESTOS </a></Header>
                <Content>
                    <asp:GridView ID="GridView3" runat="server" DataSourceID="ObjImpuestos" 
                EnableModelValidation="True" AutoGenerateColumns="false" SkinID="gridView">
                <Columns>
                    <asp:BoundField DataField="Nro_Imp" HeaderText="Número" />
                    <asp:BoundField DataField="Nom_Imp" HeaderText="Impuesto" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField DataField="Vigencia" HeaderText="Vigencia Liquidación" />
                    <asp:BoundField DataField="Nro_Com" HeaderText="Número Liquidación" />
                    <asp:BoundField DataField="Cod_Sop" HeaderText="Documento Soporte" />
                </Columns>
            </asp:GridView>
                </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header><a href="" class="accordionLink"> 4. INTERVENTORIA/SUPERVISIÓN </a></Header>
                <Content>
                    <asp:GridView ID="GridView4" runat="server" DataSourceID="ObjInterventor" 
                EnableModelValidation="True" AutoGenerateColumns="false" SkinID="gridView">
                <Columns>
                    <asp:BoundField DataField="Ide_Int" HeaderText="Identificación" />
                    <asp:BoundField DataField="Nom_Ter" HeaderText="Nombre" />
                    <asp:BoundField DataField="NTip_Int" HeaderText="Tipo" />
                    <asp:BoundField DataField="Obs_Int" HeaderText="Observación" />
                </Columns>
            </asp:GridView>
                </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                <Header><a href="" class="accordionLink"> 5. FORMA DE PAGO </a></Header>
                <Content>
                    <asp:GridView ID="GridView5" runat="server" DataSourceID="ObjCFP" 
                EnableModelValidation="True" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Nom_Pago" HeaderText="Tipo de Pago" />
                    <asp:BoundField DataField="Fecha_Pago" HeaderText="Fecha del Pago" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Valor_Pago" HeaderText="Valor" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" DataFormatString="{0:p}" />
                    <asp:BoundField DataField="Condicion_Pago" HeaderText="Condición" />
                </Columns>
            </asp:GridView>
                </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server">
                <Header><a href="" class="accordionLink"> 6. OBLIGACIONES </a></Header>
                <Content>
                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjObli" EnableModelValidation="True" Width="550">
                <Columns>
                    <asp:BoundField DataField="Des_Oblig" HeaderText="Obligaciones" />
                </Columns>
            </asp:GridView>
                </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane7" runat="server">
                <Header><a href="" class="accordionLink"> 7. PROYECTOS </a></Header>
                <Content>
                <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjProy" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" />
                    <asp:BoundField DataField="Nombre_Proyecto" HeaderText="Nombre del Proyecto" />
                </Columns>
            </asp:GridView>
                </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane8" runat="server">
                <Header><a href="" class="accordionLink"> 8. CERTIFICADOS DE DISPONIBILIDAD </a></Header>
                <Content>
                <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjCDP" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="Nro_CDP" HeaderText="No. CDP" />
                    <asp:BoundField DataField="Fec_CDP" HeaderText="Fecha del CDP" />
                    <asp:BoundField DataField="Val_CDP" HeaderText="Valor del CDP" />
                </Columns>
            </asp:GridView>
                </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane9" runat="server">
                <Header><a href="" class="accordionLink"> 9. RUBROS </a></Header>
                <Content>
                <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjRubros" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="Cod_Rub" HeaderText="Código" />
                    <asp:BoundField DataField="Nom_Rub" HeaderText="Descripción" />
                </Columns>
            </asp:GridView>
                </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPaneConDoc" runat="server">
                <Header><a href="" class="accordionLink">10. DOCUMENTOS DEL CONTRATO</a></Header>
                <Content>
                <%--<uc3:ConDocContratos ID="ConDocContratos1" runat="server" />--%>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane10" runat="server">
                <Header><a href="" class="accordionLink">11. GESTION DEL CONTRATO</a></Header>
                <Content>
                <asp:GridView ID="grdEstContratos" runat="server" 
        AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="ID" DataSourceID="ObjEstContratos" 
        ForeColor="#333333" GridLines="Vertical" ShowFooter="True" SkinID="gridView">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/BlueTheme/Select.png" SelectText=""
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="ESTADO_INICIAL" HeaderText="DOCUMENTO ANTERIOR" 
                            SortExpression="ESTADO_INICIAL" Visible="False" />
                        <asp:BoundField DataField="ESTADO_FINAL" HeaderText="DOCUMENTO " 
                            SortExpression="ESTADO_FINAL" />
                        <asp:BoundField DataField="Nro_Doc" HeaderText="N° DOCUMENTO" 
                            SortExpression="Nro_Doc" />
                        <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="FECHA" SortExpression="FECHA" />
                        <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" SortExpression="USUARIO" />
                        <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" Visible="False" />
                        <asp:BoundField DataField="VALOR_PAGO" HeaderText="VALOR_PAGO" Visible="True" 
                            DataFormatString="{0:c}" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
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
                <asp:ObjectDataSource ID="ObjEstContratos" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyCod_Con" 
                    TypeName="EstContratos">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtCodCon" Name="cod_con" 
                            PropertyName="Text" Type="String" />
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
                </Content>
            </ajaxToolkit:AccordionPane>
            </Panes>
            </ajaxToolkit:Accordion>
            <asp:ObjectDataSource ID="ObjRP" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="RP_Contratos">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjPol" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Polizas_Contrato">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjImpuestos" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Imp_Contratos">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjInterventor" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="Interventores_Contrato">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjCFP" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="CForma_Pago">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCodCon" Name="Cod_Con" 
                        PropertyName="Text" Type="String" />
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
    
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </div>
</asp:Content>

