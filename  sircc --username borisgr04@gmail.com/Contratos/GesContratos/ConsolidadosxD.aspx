<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ConsolidadosxD.aspx.vb" Inherits="Contratos_GesContratos_ConsolidadosxD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <script src="<%= ResolveUrl("~/Scripts/jquery-1.9.1.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui-1.10.3.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui.js") %>" type="text/javascript"></script>
    <link rel="stylesheet" href="../../jqwidgets/styles/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="../../jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxchart.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.sort.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.pager.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.selection.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.edit.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.aggregates.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.filter.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxmenu.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxcheckbox.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxcalendar.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxdatetimeinput.js"></script>
     <script type="text/javascript" src="../../jqwidgets/jqxtabs.js"></script>
    <script type="text/javascript" src="../../js/gettheme.js"></script>
    <link rel="stylesheet" href="<%= ResolveUrl("~/Styles/base/jquery-ui.css") %>" />
    <%--<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/smoothness/jquery-ui.js") %>" />--%>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ToolkitScriptManager>
    <script src="../../Scripts/dataTables.js" type="text/javascript"></script>
    <style type="text/css" title="currentStyle">
        @import "../../Scripts/DataTables/media/css/demo_page.css";
        @import "../../Scripts/DataTables/media/css/demo_table_jui.css";
        @import "../../Scripts/themes/smoothness/jquery-ui-1.8.4.custom.css";
    </style>
    <script type="text/javascript">
        var Datos = {};
        var MaximoValor = 0;
        var iVig_Con = '';
        var iDep_Nec = '';
        var iIde_Sup = '';
        $(function () {
            var theme = getDemoTheme();

            //Consultar();
            $('#BtnDat').click(function () {
                verDatos();
                verGrafica();
                verDetalle('00');
                return false;
            });

            function verDatos() {
                LeerDatos();
                // prepare the data
                var source = {
                    datatype: "xml",
                    datafields: [
	                { name: 'ESTADO' },
                    { name: 'CANTIDAD' }
	             ],
                    async: false,
                    record: 'Table',
                    url: 'ConsolidadosxD.aspx/GetDatos2',
                    data: {
                        Vigencia: "'" + iVig_Con + "'",
                        Dep_Nec: "'" + iDep_Nec + "'",
                        Ide_Sup: "'" + iIde_Sup + "'"
                    }
                };
                var dataAdapter = new $.jqx.dataAdapter(source, { contentType: 'application/json; charset=utf-8' });
                //var dataAdapter = new $.jqx.dataAdapter(source);
                var cellsrenderer = function (row, columnfield, value, defaulthtml, columnproperties) {
                    if (value < 20) {
                        return '<span style="margin: 4px; float: ' + columnproperties.cellsalign + '; color: #ff0000;">' + value + '</span>';
                    }
                    else {
                        return '<span style="margin: 4px; float: ' + columnproperties.cellsalign + '; color: #008000;">' + value + '</span>';
                    }
                }
                // initialize jqxGrid
                $("#jqxgrid").jqxGrid({
                    width: 200,
                    source: dataAdapter,
                    theme: theme,
                    autoheight: true,
                    sortable: true,
                    altrows: true,
                    enabletooltips: true,
                    showaggregates: true,
                    showstatusbar: true,
                    columns: [
                  { text: 'Estado', datafield: 'ESTADO', width: 100 },
                  { text: 'Cantidad', datafield: 'CANTIDAD', cellsalign: 'right', align: 'right', width: 100, aggregates: ['sum'] }
                ]
                });

                $("#jqxgrid").bind('rowselect', function (event) {
                    var selectedRowIndex = event.args.rowindex;
                    var cell = $('#jqxgrid').jqxGrid('getcell', selectedRowIndex, 'ESTADO');
                    verDetalle(cell.value);

                });
                //-------------------------------------------------------------------

            }

            function LeerDatos() {
                iVig_Con = $("#<%=CmbVig.ClientID %>").val();
                CmbDep = '';
                if ($("#<%=CmbDep.ClientID %>").val() != null) iDep_Nec = $("#<%=CmbDep.ClientID %>").val();
                iIde_Sup = '';
                if ($("#<%=TxtIdeSup.ClientID %>").val() != null) iIde_Sup = $("#<%=TxtIdeSup.ClientID %>").val();
                MaximoValor = 0;
            }
            function verGrafica() {
                LeerDatos();
                jsonData = "{'Vigencia':'" + iVig_Con + "','Dep_Nec':'" + iDep_Nec + "','Ide_Sup':'" + iIde_Sup + "'}";
                $.ajax({
                    type: "POST",
                    url: "ConsolidadosxD.aspx/GetDatos",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: Graficar,
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                }); // Fin de Ajax
            }
            function Graficar(response) {
                var sampleData = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                var MaximoValor = 0;
                $.each(sampleData, function (index, item) {
                    if (item.Cantidad > MaximoValor) MaximoValor = item.Cantidad;
                    //alert(item.Estado + item.Cantidad);
                });
                //if (Object.prototype.toString.call(sampleData) === '[object Array]') {
                //alert('Es un Vector' + sampleData[1].Estado);
                //}
                alert(MaximoValor);
                mInterval = MaximoValor > 10 ? MaximoValor / 5 : 1;
                MaximoValor = MaximoValor * 1;


                // prepare jqxChart settings
                var settings = {
                    title: "Contratos ",
                    description: "Consolidado por Dependencia",
                    showLegend: true,
                    enableAnimations: true,
                    padding: { left: 20, top: 5, right: 20, bottom: 5 },
                    titlePadding: { left: 90, top: 0, right: 0, bottom: 10 },
                    source: sampleData,
                    categoryAxis:
                    {
                        dataField: 'Estado',
                        showGridLines: true,
                        flip: false
                    },
                    colorScheme: 'scheme01',
                    seriesGroups:
                    [
                        {
                            type: 'column',
                            orientation: 'horizontal',
                            columnsGapPercent: 100,
                            toolTipFormatSettings: { thousandsSeparator: ',' },
                            valueAxis:
                            {
                                flip: true,
                                unitInterval: mInterval,
                                minValue: 0,
                                maxValue: MaximoValor,
                                displayValueAxis: true,
                                description: '',
                                formatFunction: function (value) {
                                    return parseInt(value);
                                }
                            },
                            click: myEventHandler,
                            series: [
                                    { dataField: 'Cantidad', displayText: 'Cantidad (unidades)' }
                                ]
                        }
                    ]
                };
                function myEventHandler(e) {
                    var eventData = '<div><b>Last Event: </b>' + e.event + '<b>, DataField: </b>' + e.serie.dataField + '<b>, Value: </b>' + e.elementValue + "<b> Elemento:</b> " + sampleData[e.elementIndex].Estado + "</div>";
                    $('#eventText').html(eventData);
                };
                // setup the chart
                $('#jqxChart2').jqxChart(settings);
                //.-----------------------------------------------------------
            }

            $('#jqxTabs').jqxTabs({ width: '90%', position: 'top', theme: theme, collapsible: true });

            function verDetalle(iEstado) {
                // prepare the data
                var source = {
                    datatype: "xml",
                    datafields: [
	                { name: 'NUMERO' },
                    { name: 'CONTRATISTA' },
                    { name: 'FEC_SUS_CON' },
                    { name: 'FECHAINICIO' },
                    { name: 'ESTADO' },
                    { name: 'PLAZO_TOTAL' },
                    { name: 'SUSPENSION' },
                    { name: 'DEPENDENCIA' },
                    { name: 'FECHAFINALPROB' },
                    { name: 'POR_TERMINAR' },
		     { name: 'ESTADO' }

	             ],
                    async: false,
                    record: 'Table',
                    url: 'ConsolidadosxD.aspx/GetDetalle',
                    data: {
                        Vigencia: "'" + iVig_Con + "'",
                        Dep_Nec: "'" + iDep_Nec + "'",
                        Ide_Sup: "'" + iIde_Sup + "'",
                        Est: "'" + iEstado + "'"
                    }
                };
                var dataAdapter = new $.jqx.dataAdapter(source,
        	{ contentType: 'application/json; charset=utf-8' }
            );
                //var dataAdapter = new $.jqx.dataAdapter(source);
                var cellsrenderer = function (row, columnfield, value, defaulthtml, columnproperties) {
                    if (value < 20) {
                        return '<span style="margin: 4px; float: ' + columnproperties.cellsalign + '; color: #ff0000;">' + value + '</span>';
                    }
                    else {
                        return '<span style="margin: 4px; float: ' + columnproperties.cellsalign + '; color: #008000;">' + value + '</span>';
                    }
                }
                // initialize jqxGrid
                $("#jqxgridD").jqxGrid(
            {
                width: 800,
                source: dataAdapter,
                theme: theme,
                autoheight: true,
                sortable: true,
                altrows: true,
                showfilterrow: true,
                filterable: true,
                pageable: true,
                enabletooltips: true,
                showaggregates: true,
                showstatusbar: true,
                columns: [
                  { text: 'Número', datafield: 'NUMERO', width: 100 },
                  { text: 'Estado', datafield: 'ESTADO', width: 100 },
                  { text: 'Contratista', datafield: 'CONTRATISTA' },
                  { text: 'F. Suscripción', datafield: 'FEC_SUS_CON' },
                  { text: 'F.Inicio', datafield: 'FECHAINICIO' },
                  { text: 'Plazo Total', datafield: 'PLAZO_TOTAL' },
                  { text: 'Suspensión', datafield: 'SUSPENSION' },
                  { text: 'F.Fin Estimada ', datafield: 'FECHAFINALPROB' },
                  { text: 'Por Terminar', datafield: 'POR_TERMINAR', columntype: 'checkbox', filtertype: 'checkedlist' },
                ]
            });

                $("#jqxgrid2").bind('rowselect', function (event) {
                    var selectedRowIndex = event.args.rowindex;
                    var datafield = event.args.datafield;
                    alert(selectedRowIndex + datafield);
                });
                //-------------------------------------------------------------------

            }

            function VerDependencia() {
                if ($('#<%=HdUser.ClientID %>').val() != "admin") {
                    if ($get('<%=CmbDep.ClientID %>').selectedIndex == -1) {
                        alert("No tiene ninguna dependencia asignada, por favor comuniquese con el Administrador del Sistema!!!");
                        return false;
                    }
                }
            }
            $('#<%=TxtIdeSup.ClientID %>').blur(function () {
                var TxtIdeSup = $get('<%=TxtIdeSup.ClientID %>');
                var TxtSupervisor = $get('<%=TxtSupervisor.ClientID %>');
                if (TxtIdeSup.value.length > 0) {
                    BuscarTercero(TxtIdeSup.value, TxtSupervisor);
                }
            });

            function BuscarTercero(ide_ter, txtNom) {
                var nombre = "";
                $.ajax({
                    type: "POST",
                    url: "CGesContratos.aspx/GetTercerosPk",
                    data: "{ide_ter:'" + ide_ter + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == "0") {
                            alert("Tercero no Encontrado");
                            txtNom.value = "";
                        } else {
                            txtNom.value = response.d;
                        }

                    },
                    error: function (response) {
                        if (response.length != 0)
                            alert(response);
                    }
                });
            }
        });

        function AbrirPagina(url) {
            self.location.href = url;
        }
        function pad(str, max) {
            return str.length < max ? pad("0" + str, max) : str;
        }
        function CerrarModal() {
            var modalPopup1 = $find('<%= modalPopup1.ClientID%>');
            limpiarGrid();
            modalPopup1.hide();
        }
        function AbrirModal() {
            var modalPopup1 = $find('<%= modalPopup1.ClientID%>');
            limpiarGrid();
            modalPopup1.show();
        }
        function limpiarGrid() {
            $get('<%=txtFiltro.ClientID %>').value = "";
            //__doPostBack('btnBuscar', '');
            __doPostBack('<%= UpdatePanel1.UniqueID %>', '');
        }
        function mpeShow(valor) {
            $get('<%= HdTipo.ClientID %>').value = valor;
            $get('htitulo').innerHTML = "Consulta de " + valor;
            AbrirModal();
        }
        function GetSelectedRow(lnk) {
            var row = lnk.parentNode.parentNode;
            GetSelectedRowC(row);
            return false;
        }
        function GetSelectedRowC(row) {
            var codigo = row.cells[0].innerHTML;
            var nombre = trim(row.cells[1].innerHTML);
            var tip = $get('<%= HdTipo.ClientID %>').value;
            //alert("Tipo:" + tip + " Id: " + codigo + " Nombre:" + nombre);
            mostrarDatos(tip, codigo, nombre);
            CerrarModal();
            return true;
        }
        function trim(myString) {
            return myString.replace(/^\s+/g, '').replace(/\s+$/g, '');
        }

        function mostrarDatos(tip, codigo, nombre) {
            $get('<%= TxtSupervisor.ClientID %>').value = nombre;
            $get('<%=TxtIdeSup.ClientID %>').value = codigo;
        }
        

        

    </script>
    <asp:HiddenField ID="HdUser" runat="server" />
    <h2>
        Filtro Contratos
    </h2>
    <fieldset id="regFiltro">
        <legend>Seleccione el Filtro</legend>
        <div id="form">
            <p>
                <label>
                    <input id="ChkVigencia" type="checkbox" runat="server" checked="checked" />
                    Vigencia <span class="small"></span>
                </label>
                <asp:DropDownList ID="CmbVig" runat="server" DataSourceID="odsVigencias" DataTextField="YEAR_VIG"
                    DataValueField="YEAR_VIG">
                </asp:DropDownList>
            </p>
            <p>
                <label>
                    <input id="ChkSup" type="checkbox" runat="server" />
                    Supervisor <span class="small"></span>
                </label>
                <asp:TextBox ID="TxtIdeSup" Style="width: 100px" runat="server"></asp:TextBox>
                <input id="btnBuscarS" type="button" value="" class="button_buscar" onclick="mpeShow('Supervisor');"
                    title="Abrir Cuadro de Busqueda" />
                <asp:TextBox ID="TxtSupervisor" Style="width: 230px" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p>
                <label>
                    <input id="ChkDepNec" type="checkbox" runat="server" checked="checked" disabled="disabled" />
                    Dependencia <span class="small"></span>
                </label>
                <asp:DropDownList ID="CmbDep" runat="server" DataSourceID="odsDepNec" DataTextField="NOM_DEP"
                    DataValueField="COD_DEP">
                </asp:DropDownList>
            </p>
            <span id="botones">
                <input id="BtnDat" class="button_example" type="button" value="Consultar"  />
                <input id="BtnGestión" class="button_example" type="button" onclick="AbrirPagina('GesContratos.aspx')"
                    value="Ir a Gestión" title="Haga click aquí para dirigirse inmediantamente al formulario de gestión." />
            </span>
            <asp:HiddenField ID="hdIdeCon" runat="server" />
            <asp:HiddenField ID="hdIdeSup" runat="server" />
            <asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetRecords"
                TypeName="Vigencias" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsDepNec" runat="server" SelectMethod="GetNecbyUser" TypeName="Dependencias"
                OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
        </div>
    </fieldset>
    <%----------------------------------------------------------------------------%>
    <br />
    <h2>
        Resultado del Filtro</h2>
    <br />
    <%----------------------------------------------------------------------------%>
    
    <div id='jqxTabs'>
        <ul>
            <li >Grafico</li>
            <li>Datos</li>
        </ul>
        <div>
            <div id='jqxChart2' style="width: 680px; height: 600px; position: relative; margin: 0;">
            </div>
            <div id='eventText' style="width: 600px; height: 30px">
            </div>
        </div>
        <div>
            <br />
            <div class="information">
                Puede hacer Click en un Estado para ver el detalle de los contratos
            </div>
            <div id="jqxgrid">
            </div>
            <br />
            <div id="jqxgridD">
            </div>
        </div>
    </div>
    <%-------------------------MODAL POPUP------------------------------------------------------%>
    <asp:Panel ID="pnlPopup" runat="server" BackColor="White" Width="600px" Height="400px"
        ScrollBars="Auto" CssClass="PanelModal">
        <asp:Panel ID="BarraPopup" runat="server">
            <h2 id="htitulo">
                Formulario de Consulta</h2>
        </asp:Panel>
        <asp:HiddenField ID="HdTipo" runat="server" />
        <br />
        <p>
            <asp:TextBox ID="txtFiltro" Width="70%" runat="server">
            </asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Filtrar" OnClick="btnBuscar_Click"
                CssClass="button_exampleModal" />
            &nbsp;&nbsp;
            <input id="btnCerrar" type="button" value="Cerrar" onclick="CerrarModal();" class="button_exampleModal" />
        </p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="mydivgrid">
                    <asp:GridView ID="grdBusqueda" runat="server" SkinID="grdSkin" AutoGenerateColumns="false"
                        OnRowDataBound="grdBusqueda_RowDataBound" AllowPaging="True" DataSourceID="odsTerceros"
                        EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="Ide_Ter" HeaderText="Identificación" SortExpression="Ide_Ter" />
                            <asp:BoundField DataField="Nom_Ter" HeaderText="Nombre/Razon Social" SortExpression="Nom_Ter" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelect" runat="server" Text="Seleccionar" CommandName="Select"
                                        OnClientClick="return GetSelectedRow(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsTerceros" runat="server" SelectMethod="GetRecords" TypeName="Terceros"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtFiltro" Name="busc" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="grdBusqueda" EventName="PageIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="BtnAbrirM" runat="server" Text="..." class="Invisible" />
    <asp:ModalPopupExtender ID="modalPopup1" runat="server" TargetControlID="BtnAbrirM"
        PopupControlID="pnlPopup" DropShadow="true" PopupDragHandleControlID="BarraPopup"
        BackgroundCssClass="FondoAplicacion">
    </asp:ModalPopupExtender>
</asp:Content>
