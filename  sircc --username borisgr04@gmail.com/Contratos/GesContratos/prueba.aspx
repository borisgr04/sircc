<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="prueba.aspx.vb" Inherits="Contratos_GesContratos_prueba" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ToolkitScriptManager>
    <link rel="stylesheet" href="../../jqwidgets/styles/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.10.1.min.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxchart.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxmenu.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxcheckbox.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.sort.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.pager.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.selection.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.edit.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.aggregates.js"></script>
    <script type="text/javascript" src="../../js/gettheme.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //{ide_ter:'" + ide_ter + "'}
            var sampleData={};
            var Vigencia = '2013';
            var Dep_Nec = '';
            var Ide_Sup = '';
            jsonData = "{'Vigencia':'" + Vigencia + "','Dep_Nec':'" + Dep_Nec + "','Ide_Sup':'" + Ide_Sup + "'}";
            var Serie = {};
            $.ajax({
                type: "POST",
                url: "prueba.aspx/GetDatos",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async : false,
                success: function (response) {
                    var sampleData = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;
                    var MaximoValor = 0;
                    $.each(sampleData, function (index, item) {
                        if (item.Cantidad > MaximoValor) MaximoValor = item.Cantidad;
                        //alert(item.Estado + item.Cantidad);
                    });
                    if (Object.prototype.toString.call(sampleData) === '[object Array]') {
                        //alert('Es un Vector' + sampleData[1].Estado);
                    }
                    MaximoValor = MaximoValor * 1.2;
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
                                unitInterval: MaximoValor / 10,
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
                    var theme = getDemoTheme();

            // prepare the data
            source = {
	            datatype: "xml",
	            datafields: [
	                { name: 'ESTADO'},
                    { name: 'CANTIDAD'}
	             ],
	            async: false,
	            record: 'Table',
	            url: 'prueba.aspx/GetDatos2',
                 data: {
                    Vigencia: "2013",
                    Dep_Nec: '',
                    Ide_Sup: ''
                },
            };
            var dataAdapter = new $.jqx.dataAdapter(source,
        	{  contentType: 'application/json; charset=utf-8'}
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
            $("#jqxgrid").jqxGrid(
            {
                width: 400,
                source: dataAdapter,
                theme: theme,
                autoheight: true,
                sortable: true,
                altrows: true,
                enabletooltips: true,
                showaggregates: true,
                showstatusbar: true,
                columns: [
                  { text: 'Estado', datafield: 'ESTADO', width: 250 },
                  { text: 'Cantidad', datafield: 'CANTIDAD', cellsalign: 'right', align: 'right', width: 150,aggregates: ['sum']}
                ]
            });

            $("#jqxgrid").bind('rowselect', function (event) {
                var selectedRowIndex = event.args.rowindex;
                alert(sampleData[selectedRowIndex].Estado);
                var datafield = event.args.datafield;
            });
                    //-------------------------------------------------------------------
                },
                error: function (response) {
                    if (response.length != 0)
                        alert(response);
                }
            });
            
            
            
        });




        
    </script>
    <div id='jqxChart2' style="width: 680px; height: 600px; position: relative; left: 0px;
        top: 0px;">
    </div>
    <div id='eventText' style="width: 600px; height: 30px">
    </div>
    <div id='jqxWidget' style="font-size: 13px; font-family: Verdana; float: left;">
        <div id="jqxgrid">
        </div>
    </div>
</asp:Content>
