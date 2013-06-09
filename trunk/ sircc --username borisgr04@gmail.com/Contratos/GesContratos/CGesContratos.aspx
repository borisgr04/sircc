<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CGesContratos.aspx.vb" Inherits="Contratos_GesContratos_CGesContratos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<script src="<%= ResolveUrl("~/Scripts/jquery-1.9.1.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui-1.10.3.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/jquery-ui.js") %>" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.0/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />

<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <script src="../../Scripts/dataTables.js" type="text/javascript"></script>
    <style type="text/css" title="currentStyle">
        @import "../../Scripts/DataTables/media/css/demo_page.css";
        @import "../../Scripts/DataTables/media/css/demo_table_jui.css";
        @import "../../Scripts/themes/smoothness/jquery-ui-1.8.4.custom.css";
    </style>
    <script type="text/javascript">
        $(function () {
            $('#tb-consulta').dataTable({
                "oLanguage": { "sSearch": "Buscar el Contrato:" },
                "bJQueryUI": true,
                "bPaginate": true,
                "bInfo": true,
                "oLanguage": {
                    "sUrl": "../../Styles/datatablesES.txt"
                },
                "sScrollY": 400,
                "sScrollX": 700,
                "sScrollXInner": "120%"
            });

            $('#<%=TxtNroCto.ClientID %>').blur(function () {
                var nro = 0;
                var TxtNroCto = $get('<%=TxtNroCto.ClientID %>');
                var CmbVig = $get('<%=CmbVig.ClientID %>');
                var cboTipo = $get('<%=cboTipo.ClientID %>');
                if (TxtNroCto.value.length < 10) {
                    nro = CmbVig.value + cboTipo.value + pad(TxtNroCto.value, 4);
                }
                else {
                    nro = TxtNroCto.value;
                }
                TxtNroCto.value = nro;
            });
            $('#<%=TxtIdeCon.ClientID %>').blur(function () {
                var TxtIdeCon = $get('<%=TxtIdeCon.ClientID %>');
                var TxtCtotista = $get('<%=TxtCtotista.ClientID %>');
                if (TxtIdeCon.value.length > 0) {
                    BuscarTercero(TxtIdeCon.value, TxtCtotista);
                }

            });
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
                return nombre;
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
        function trim (myString)
        {
            return myString.replace(/^\s+/g, '').replace(/\s+$/g, '');
        }

        function mostrarDatos(tip, codigo, nombre) {
            if (tip == "Contratistas") {
                $get('<%= TxtCtotista.ClientID %>').value = nombre;
                $get('<%=TxtIdeCon.ClientID %>').value=codigo;
            }
            else {
                $get('<%= TxtSupervisor.ClientID %>').value = nombre;
                $get('<%=TxtIdeSup.ClientID %>').value = codigo;

            }

        }
            
            
    </script>
 <asp:HiddenField ID="HdUser" runat="server" />
 <div style="width:950px; overflow:scroll">
 
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="ViewFiltroCon" runat="server">
            
            <h2>Filtro Contratos a Cargo</h2>
            <fieldset id="regFiltro">
            <legend>Seleccione el Filtro</legend>
                <div id="form" >
                    <p>
                    <label>
                    <input id="ChkVigencia" type="checkbox" runat="server" checked="checked"  />
                        Vigencia <span class="small"></span>
                    </label>
                    <asp:DropDownList ID="CmbVig" runat="server" DataSourceID="odsVigencias" DataTextField="YEAR_VIG" 
                    DataValueField="YEAR_VIG">
                    </asp:DropDownList>
                    </p>
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <p>
                            <label>
                                <input id="ChkTipo" type="checkbox" runat="server" style="display:inline"/> Tipo <span class="small"></span>
                            </label>
                            <asp:DropDownList ID="cboTipo" runat="server" DataSourceID="odsTipos" DataTextField="NOM_TIP" 
                                DataValueField="COD_TIP" AutoPostBack="True">
                            </asp:DropDownList>
                            </p>
                            <p>
                            <label >
                                <input id="ChkSTipo" type="checkbox" runat="server" /> SubTipo <span class="small"></span>
                            </label>
                            <asp:DropDownList ID="CboSubTipo" runat="server" DataSourceID="odsSTipos" DataTextField="NOM_STIP"
                                DataValueField="COD_STIP">
                            </asp:DropDownList>
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                            <p>
                    <label>
                        <input id="ChkNContrato" type="checkbox" runat="server" />
                        N° del Contrato <span class="small"></span>
                    </label>
                    <asp:TextBox ID="TxtNroCto"  runat="server"></asp:TextBox>
                    </p>
                    <p>
                    <label>
                        <input id="ChkContratista" type="checkbox" runat="server" />
                        Contratista
                        <span class="small"></span>
                    </label>
                    <asp:TextBox ID="TxtIdeCon"  style="width:100px" runat="server" ></asp:TextBox>
                    <input id="btnBuscarC" type="button" value="" class="button_buscar" onclick="mpeShow('Contratistas');" title="Abrir Cuadro de Busqueda"/>
                    <asp:TextBox ID="TxtCtotista" style="width:230px" runat="server"  ReadOnly="True"></asp:TextBox>
                    
                    </p>
                    <p>
                    <label>
                        <input id="ChkSup" type="checkbox" runat="server" />
                        Supervisor <span
                            class="small"></span>
                    </label>
                    <asp:TextBox ID="TxtIdeSup" style="width:100px"  runat="server"></asp:TextBox>
                    <input id="btnBuscarS" type="button" value="" class="button_buscar" onclick="mpeShow('Supervisor');" title="Abrir Cuadro de Busqueda"/>
                    <asp:TextBox ID="TxtSupervisor" style="width:230px"  runat="server"  ReadOnly="True"></asp:TextBox>
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
                   
                    <p>
                    <label>
                    <input id="ChkEstado" type="checkbox" runat="server" />
                        Estado <span class="small"></span>
                    </label>
                    <asp:DropDownList ID="CmbEst" runat="server" DataSourceID="odsEstados" DataTextField="estado"
                        DataValueField="estado">
                    </asp:DropDownList>
                    </p>
                    <p>
                    <label>
                        <input id="ChkFecha" type="checkbox" runat="server" />
                        Fecha de Suscripción <span class="small"></span>
                    </label>
                    <asp:TextBox ID="TxtFecIni" placeHolder="Fecha Inicial"  runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFecIni_Calendarextender" runat="server" Enabled="True"
                        Format="dd / MM / yyyy" TargetControlID="TxtFecIni">
                    </asp:CalendarExtender>
                    
                    <asp:TextBox ID="TxtFecFin" placeHolder="Fecha Final" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFecFin_CalendarExtender" runat="server" Enabled="True"
                        Format="dd / MM / yyyy" TargetControlID="TxtFecFin">
                    </asp:CalendarExtender>
                    </p>
                    
                    <p>
                    <label>
                        <input id="ChkObj" type="checkbox" runat="server" />
                        Objeto Contrato <span class="small"></span>
                    </label>
                    <asp:TextBox ID="TxtObjCont" runat="server" TextMode="MultiLine" ></asp:TextBox>
                    </p>
                    <span id="botones">
                    <asp:Button ID="BtnCons" runat="server" OnClick="BtnCons_Click" Text="Consultar" CssClass="button_example" />
                    </span>

                    <asp:HiddenField ID="hdIdeCon" runat="server" />
                    <asp:HiddenField ID="hdIdeSup" runat="server" />
                    <asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetRecords"
                        TypeName="Vigencias" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsDepNec" runat="server" SelectMethod="GetDelbySoloUser"
                        TypeName="Dependencias" 
                        OldValuesParameterFormatString="original_{0}" DeleteMethod="Delete" 
                        InsertMethod="AsignarAbogado" UpdateMethod="Update">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsSTipos" runat="server" SelectMethod="GetByTipo" 
                        TypeName="SubTipos" InsertMethod="Insert" 
                        OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
                      
                        <SelectParameters>
                            <asp:ControlParameter ControlID="cboTipo" Name="Cod_Tip" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                       
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsTipos" runat="server" SelectMethod="GetRecords" 
                        TypeName="Tipos" InsertMethod="Insert" 
                        OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsEstados" runat="server" SelectMethod="GetRecordsD" 
                        TypeName="EstadosC" 
                        OldValuesParameterFormatString="original_{0}">
                    </asp:ObjectDataSource>
                </div>
            </fieldset>
            
        </asp:View>
        <asp:View ID="ViewCons" runat="server">
            <br />
            <h2>Resultado del Filtro</h2>
            <br />
            
            <div class="information">
            Seleccione un Contrato para Ingresar su Gestión de Actas
            </div>
            
            <asp:LinkButton ID="LnBtFilt" runat="server" OnClick="LnBtFilt_Click">[Volver a Filtrar]</asp:LinkButton>
            <br />
            <br />
            <asp:ListView ID="ListView1" runat="server" EnableModelValidation="True">
                <ItemTemplate>
                    <tr class="rows" onclick="AbrirPagina('GesContratos.aspx?CodCon=<%# Eval("Numero") %>')" title="Click para Diligenciar Gestión de Actas del Contrato N° "+<%# Eval("Numero") %>>
                        <td>
                            <a href="#" onclick="AbrirPagina('GesContratos.aspx?CodCon=<%# Eval("Numero") %>')">Gestión</a>
                        </td>
                        <td>
                            <asp:Label ID="NumeroLabel" runat="server" Text='<%# Eval("Numero") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ContratistaLabel" runat="server" Text='<%# Eval("Contratista") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ObjetoLabel" runat="server" Text='<%# Eval("Obj_Con") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Ide_ContratistaLabel" runat="server" Text='<%# Eval("Ide_Con") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TipoLabel" runat="server" Text='<%# Eval("Tipo") %>' />
                        </td>
                        
                        <td>
                            <asp:Label ID="Valor_ContratoLabel" runat="server" Text='<%# Eval("Val_Otros")+Eval("Val_Apo_Gob") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Fecha_SuscripcionLabel" runat="server" Text='<%# Eval("Fec_Sus_Con") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("Estado") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DependenciaDelLabel" runat="server" Text='<%# Eval("Dependencia") %>' />
                        </td>
                        <%--<td>
                                <asp:Label ID="DependenciaNecLabel" runat="server" Text='<%# Eval("DependenciaNec") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Ide_InterventorLabel" runat="server" Text='<%# Eval("Ide_Interventor") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Nom_InterventorLabel" runat="server" Text='<%# Eval("Nom_Interventor") %>' />
                            </td>
                            <td>
                                <asp:Label ID="VigenciaLabel" runat="server" Text='<%# Eval("Vigencia") %>' />
                            </td>--%>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                        <tr class="alt" onclick="AbrirPagina('GesContratos.aspx?CodCon=<%# Eval("Numero") %>')" title="Click para Diligenciar Gestión de Actas del Contrato N° "+<%# Eval("Numero") %>>
                        <td>
                            <a href="#" onclick="AbrirPagina('GesContratos.aspx?CodCon=<%# Eval("Numero") %>')">Gestión</a>
                        </td>
                        <td>
                            <asp:Label ID="NumeroLabel" runat="server" Text='<%# Eval("Numero") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ContratistaLabel" runat="server" Text='<%# Eval("Contratista") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ObjetoLabel" runat="server" Text='<%# Eval("Obj_Con") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Ide_ContratistaLabel" runat="server" Text='<%# Eval("Ide_Con") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TipoLabel" runat="server" Text='<%# Eval("Tipo") %>' />
                        </td>
                        
                        <td>
                            <asp:Label ID="Valor_ContratoLabel" runat="server" Text='<%# Eval("Val_Otros")+Eval("Val_Apo_Gob") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Fecha_SuscripcionLabel" runat="server" Text='<%# Eval("Fec_Sus_Con") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("Estado") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DependenciaDelLabel" runat="server" Text='<%# Eval("Dependencia") %>' />
                        </td>
                        <%--
                            <td>
                                <asp:Label ID="DependenciaNecLabel" runat="server" Text='<%# Eval("DependenciaNec") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Ide_InterventorLabel" runat="server" Text='<%# Eval("Ide_Interventor") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Nom_InterventorLabel" runat="server" Text='<%# Eval("Nom_Interventor") %>' />
                            </td>
                            <td>
                                <asp:Label ID="VigenciaLabel" runat="server" Text='<%# Eval("Vigencia") %>' />
                            </td>--%>
                    </tr>
                </AlternatingItemTemplate>
                <LayoutTemplate>
                    <table style="width: 1500px" id="tb-consulta" class="mGridx">
                        <thead>
                            <tr>
                                <th>
                                    
                                </th>
                                <th>
                                    Número
                                </th>
                                <th>
                                    Nombre Contratista
                                </th>
                                <th style='width: 500px'>
                                    Objeto del Contrato
                                </th>
                                <th>
                                    Tipo/SubTipo
                                </th>
                                <th>
                                    Identificación Contratista
                                </th>
                                <th>
                                    Valor del Contrato
                                </th>
                                <th>
                                    Fecha de Suscripcion
                                </th>
                                <th>
                                    Estado
                                </th>
                                <th>
                                    Dependencia a Cargo del Proceso
                                </th>
                                <%-- 
                                   <th>
                                        DependenciaNec
                                    </th>
                                   <th>
                                        Ide_Interventor
                                    </th>
                                    <th>
                                        Nom_Interventor
                                    </th>
                                    <th>
                                        Vigencia
                                    </th>--%>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="9">
                                    <div id="paging">
                                        <ul>
                                            <%--<asp:DataPager ID="dtBottom" runat="server" PageSize="5">
                            <Fields>
                                    <asp:NextPreviousPagerField   
                                        ButtonType="Link"   
                                        ShowFirstPageButton="true"  
                                        ShowNextPageButton="true"  
                                        ShowPreviousPageButton="false" 
                                        ButtonCssClass="pagerCSS" 
                                        />
                                    <asp:NumericPagerField   
                                        NumericButtonCssClass="pagerCSS"  
                                        CurrentPageLabelCssClass="CurrentPageLabelCSS"  
                                        NextPreviousButtonCssClass="pagerCSS"
                                        />  
                                     <asp:NextPreviousPagerField   
                                        ButtonType="Link" 
                                        ShowLastPageButton="true"  
                                        ShowNextPageButton="false"
                                        ButtonCssClass="pagerCSS"   
                                        />
                            </Fields>
                        </asp:DataPager>--%>
                                        </ul>
                                    </div>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </LayoutTemplate>
                <EmptyItemTemplate>
                    <td>
                        &nbsp; NO HAY DATOS
                    </td>
                </EmptyItemTemplate>
            </asp:ListView>
            <br />
            <asp:ObjectDataSource ID="ObjDtConsCont" runat="server" 
                SelectMethod="GetRecords" OnSelecting="ObjDtConsCont_Selecting" 
                OldValuesParameterFormatString="original_{0}" TypeName="CtrCGesContratos">
                <SelectParameters>
                    <asp:Parameter Name="cFil" Type="Object" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:View>
    </asp:MultiView>
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
            <asp:TextBox ID="txtFiltro" Width="70%" runat="server" >
            </asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Filtrar" OnClick="btnBuscar_Click" CssClass="button_exampleModal" />
            &nbsp;&nbsp;
            <input id="btnCerrar" type="button" value="Cerrar" onclick="CerrarModal();" class ="button_exampleModal" />
        </p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="mydivgrid">
                    <asp:GridView ID="grdBusqueda" runat="server"  SkinID="grdSkin" AutoGenerateColumns="false"
                        OnRowDataBound="grdBusqueda_RowDataBound" AllowPaging="True" 
                        DataSourceID="odsTerceros" EnableModelValidation="True">
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
                    <asp:ObjectDataSource ID="odsTerceros" runat="server" SelectMethod="GetRecords"
                        TypeName="Terceros" 
                        OldValuesParameterFormatString="original_{0}">
                    
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtFiltro" Name="busc" PropertyName="Text" 
                                Type="String" />
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

