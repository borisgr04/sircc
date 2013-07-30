<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Auditoria.aspx.vb" Inherits="Consultas_Auditoria_Auditoria" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ToolkitScriptManager>
    <script src="<%= ResolveUrl("~/Scripts/jquery-1.9.1.js") %>" type="text/javascript"></script>
    <link rel="stylesheet" href="../../jqwidgets/styles/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="../../jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxchart.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.sort.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.pager.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.selection.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.aggregates.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.filter.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxmenu.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxcheckbox.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxtabs.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxdata.export.js"></script>
    <script type="text/javascript" src="../../jqwidgets/jqxgrid.export.js"></script>
    <script src="../../Scripts/jquery.BlockUI.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/gettheme.js"></script>
    <script type="text/javascript">

        $(function () {
            //$.blockUI.defaults.message = '<h1><img src="../../imagenes/loading.gif" /> Procesando</h1>';
            //$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

            var theme = getDemoTheme();

            function bloquear() {
                $.blockUI();
            }
            function desbloquear() {
                $.unblockUI();
            }

            $('#BtnDat').click(function () {
                wizard.loadPageTabs(1);
            });

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
                    url: "Auditoria.aspx/GetTercerosPk",
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


        var wizard = (function () {

            var _addHandlers = function () {
                $('#jqxTabs').on('selected', function (event) {
                    var pageIndex = event.args.item + 1;
                    wizard.loadPageTabs(pageIndex);
                });
            };
            var _createElements = function () {
                $('#jqxTabs').jqxTabs({ width: '90%', position: 'top', theme: wizard.config.theme, collapsible: true });
            };
            return {
                config: {
                    dragArea: null,
                    theme: null,
                    oper: null,
                    iVig_Con: null,
                    iDep_Nec: '',
                    iIde_Sup: ''
                },
                loadPageTabs: function (tabIndex) {
                    var pagTab = {
                        content1: "Chart.htm",
                        content2: "Datos.htm"
                    };
                    var pajAjax = pagTab['content' + tabIndex];
                    if (typeof (pajAjax) === "undefined") {

                    } else {
                        $.get(pajAjax, function (data) {
                            $('#content' + tabIndex).html(data);
                        });
                    }
                },
                LeerDatos: function () {
                    wizard.config.iVig_Con = $("#<%=CmbVig.ClientID %>").val();
                    wizard.config.iDep_Nec = ChkDepNec.checked ? $("#<%=CmbDep.ClientID %>").val() : '';
                    wizard.config.iIde_Sup = (ChkSup.checked) ? $("#<%=TxtIdeSup.ClientID %>").val() : '';

                },
                init: function () {
                    _createElements();
                    _addHandlers();
                }
            };
        } ());
    


        function LoadJqWidget() {
            var theme;
            $.data(document.body, 'theme', 'bootstrap');
            theme = getDemoTheme();
            var url = "../../jqwidgets/styles/jqx." + theme + '.css';
            $(document).find('head').append('<link rel="stylesheet" href="' + url + '" media="screen" />');

            wizard.config.theme = theme;
            wizard.init();
         
        
        }

        //Agregar factorias de jquery al update panel.
        //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(LoadJqWidget);


        //Factoria de jquery(pagina lista)
        $(document).ready(function () {
            LoadJqWidget();
        });
    </script>
    <asp:HiddenField ID="HdUser" runat="server" />
    <h2>
        Auditoria de Gestión de Contratos
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
                    <input id="ChkSup" type="checkbox" />
                    Supervisor <span class="small"></span>
                </label>
                <asp:TextBox ID="TxtIdeSup" Style="width: 100px" runat="server"></asp:TextBox>
                <input id="btnBuscarS" type="button" value="" class="button_buscar" onclick="mpeShow('Supervisor');"
                    title="Abrir Cuadro de Busqueda" />
                <asp:TextBox ID="TxtSupervisor" Style="width: 230px" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p>
                <label>
                    <input id="ChkDepNec" type="checkbox" />
                    Dependencia <span class="small"></span>
                </label>
                <asp:DropDownList ID="CmbDep" runat="server" DataSourceID="odsDepNec" DataTextField="NOM_DEP"
                    DataValueField="COD_DEP">
                </asp:DropDownList>
            </p>
            <span id="botones" style=" text-align:center">
                <input id="BtnDat" class="button_example" type="button" value="Consultar" />
            </span>
            <asp:HiddenField ID="hdIdeCon" runat="server" />
            <asp:HiddenField ID="hdIdeSup" runat="server" />
            <asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetRecords"
                TypeName="Vigencias" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsDepNec" runat="server" SelectMethod="GetRecords" TypeName="Dependencias"
                OldValuesParameterFormatString="original_{0}" >
                <UpdateParameters>
                    <asp:Parameter Name="ID_HDEP" Type="String" />
                    <asp:Parameter Name="ASIG_PROC" Type="String" />
                    <asp:Parameter Name="Coordinador" Type="String" />
                    <asp:Parameter Name="connect" Type="Boolean" />
                </UpdateParameters>
            </asp:ObjectDataSource>
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
            <li>Grafico</li>
            <li>Datos</li>
        </ul>
        <div id="content1">
            
        </div>
        <div id="content2">
            
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
