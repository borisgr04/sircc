<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PanelSupervision.aspx.vb" Inherits="Interventorias_PanelSupervision_PanelSupervision" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" TagName="ctrAyudIzql"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true"
        EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <uc2:ctrAyudIzql ID="ctrAyudIzql1" runat="server" Mensaje=" Para Diligenciar las Actas de los Contratos siga las indicaciones: <br/> 1. Busque el Contrato requerido por Número, Contratista u Objeto. 2. <br/> Seleccionelo haciendo Click en el Boton de la Izquierda.<br/> 3.Seleccione el Documento a Diligenciar " />
    <div class="demoarea">
        <asp:Label CssClass="Titulo" ID="Label5" runat="server" Text='SUPERVISIONES/INTERVENTORIAS A CARGO' />
        <asp:HiddenField ID="hdUserName" runat="server" />
        <br />
        <br />
        <fieldset>
            <legend>1. Seleccione el Contrato </legend>
            <table>
                <tr>
                    <td>
                        Vigencia:
                    </td>
                    <td>
                        <asp:DropDownList ID="CmbVigencia" runat="server" DataSourceID="ObjVigencias" DataTextField="Year_Vig"
                            DataValueField="Year_Vig">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBuscar" runat="server" Width="450px" ToolTip="Busca por Nombre de Contratista, Numero u Objeto "></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton ID="IBtnBuscar" runat="server" SkinID="IBtnBuscar" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Buscar
                    </td>
                </tr>
            </table>
            <asp:ObjectDataSource ID="ObjVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetRecords" TypeName="Vigencias"></asp:ObjectDataSource>
            <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
            <br />
            <asp:ListView ID="LstSupervisiones" runat="server" DataKeyNames="Numero" DataSourceID="ObjPanelS"
                EnableModelValidation="True" OnSelectedIndexChanging="LstSupervisiones_SelectedIndexChanged">
                <ItemTemplate>
                    <td class="rows">
                        <asp:Label CssClass="SubTitulo" ID="Label5" runat="server" Text='<%# Eval("Tipo") +" DE "+Eval("Nom_Stip") +" N°"  %>' />
                        <asp:Label ID="LbNumero" runat="server" Text='<%# Eval("Numero") %>' Font-Bold="true" />
                        del
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Fec_Sus_Con","{0:D}") %>' />
                        <br />
                        <%# Eval("Obj_Con") %>
                        <br />
                        Contratista: <span class="datosck">
                            <%# Eval("Contratista") %></span>
                        <br />
                        <asp:HiddenField ID="hdEstado" runat="server" Value='<%# Eval("Est_Con") %>' />
                        Estado <span class="datosc">
                            <%# Eval("Estado") %></span> Última Acta <span class="datosc">
                                <%# Eval("Acta_Actual")%></span> Valor Inicial <span class="datosc">
                                    <%# Eval("Val_Con","{0:c}") %></span> Valor Adicionado <span class="datosc">
                                        <%# Eval("Val_Adi","{0:c}")%></span> Valor Total <span class="datosc">
                                            <%# Eval("Valor_Total_Doc","{0:c}") %></span>
                        <td style="text-align: center">
                            <asp:ImageButton ID="IbtnSelect" runat="server" SkinID="IBtnSelect2" CommandName="Select"
                                CommandArgument='<%# Eval("Numero") %>' />
                        </td>
                    </td>
                </ItemTemplate>
                <%--<AlternatingItemTemplate>
        </AlternatingItemTemplate>
                --%>
                <SelectedItemTemplate>
                    <td class="alt">
                        <asp:Label CssClass="SubTitulo" ID="Label5" runat="server" Text='<%# Eval("Tipo") +" DE "+Eval("Nom_Stip") +" N°"  %>' />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Numero") %>' Font-Bold="true" />
                        del
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Fec_Sus_Con","{0:D}") %>' />
                        <br />
                        <%# Eval("Obj_Con") %>
                        <br />
                        Contratista: <span class="datosck">
                            <%# Eval("Contratista") %></span>
                        <br />
                        <asp:HiddenField ID="hdEstado" runat="server" Value='<%# Eval("Est_Con") %>' />
                        Estado <span class="datosc">
                            <%# Eval("Estado") %></span> Última Acta <span class="datosc">
                                <%# Eval("Acta_Actual")%></span> Valor Inicial <span class="datosc">
                                    <%# Eval("Val_Con","{0:c}") %></span> Valor Adicionado <span class="datosc">
                                        <%# Eval("Val_Adi")%></span> Valor Total <span class="datosc">
                                            <%# Eval("Valor_Total_Doc","{0:c}") %></span>
                        <td style="text-align: center">
                            <asp:ImageButton ID="IbtnSelect" runat="server" Width="32px" Height="32px" SkinID="IBtnSelect2"
                                CommandName="Select" CommandArgument='<%# Eval("Numero") %>' />
                        </td>
                    </td>
                </SelectedItemTemplate>
                <GroupTemplate>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </tr>
                </GroupTemplate>
                <LayoutTemplate>
                    <asp:DataPager ID="dtTop" runat="server" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField />
                            <asp:NumericPagerField />
                        </Fields>
                    </asp:DataPager>
                    <div style="height: 250px; overflow: auto">
                        <table border="0" class="mGrid">
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />
                        </table>
                    </div>
                </LayoutTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="ObjPanelS" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetRecords" TypeName="PanelSupervision">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtBuscar" Name="Filtro" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="HdUsername" Name="ide_int" PropertyName="Value"
                        Type="String" />
                    <asp:ControlParameter ControlID="CmbVigencia" Name="vigencia" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </fieldset>
        <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" BackgroundCssClass="modalBackground"
            CancelControlID="btCerrarCon" DropShadow="true" PopupControlID="pCons" PopupDragHandleControlID="pConsT"
            TargetControlID="btn_Target">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="pCons" runat="server" CssClass="ModalPanel2" Height="400px" Width="800px">
            <asp:Panel ID="pConsT" runat="Server" CssClass="BarTitleModal2" Height="30px">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                    padding-top: 5px">
                    <div style="float: left">
                        2.Seleccione el Documento a Editar/Crear
                    </div>
                    <div style="float: right">
                        <asp:Button ID="btCerrarCon" runat="server" Text="X" />
                    </div>
                </div>
            </asp:Panel>
            <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; vertical-align: middle;
                padding-top: 5px; overflow: auto; height: 370px">
                <asp:Panel ID="PnLabelNuevo" runat="server" Visible="false">
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="LbNuevo" SkinID="MsgResult" runat="server" Text=""></asp:Label><br />
                                </td>
                            </tr>
                        </table>
                    </center>
                </asp:Panel>
                <asp:Panel ID="PnlNuevoDoc" runat="server">
                    <center>
                        <table width="90%">
                            <tr>
                                <td>
                                    Documento a Elaborar:
                                </td>
                                <td>
                                    <asp:ImageButton ID="IBtnDoc" runat="server" CommandArgument='<%# Eval("Numero") %>'
                                        CommandName="nuevo" SkinID="IBtnNuevo" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="IBtnVolver" runat="server" SkinID="IBtnCancelar" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="CboEstSig" runat="server" AutoPostBack="True" DataSourceID="ObjRutaEst"
                                        DataTextField="NOM_EST" DataValueField="EST_FIN">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Nuevo
                                </td>
                                <td>
                                    Cancelar
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                </asp:Panel>
                <asp:Panel ID="PnDocs" runat="server">
                    <asp:GridView ID="grdEstContratos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID,EST_FIN"
                        DataSourceID="ObjEstContratos" ShowFooter="True" EnableModelValidation="True"
                        EmptyDataText="No tiene Actas Registradas" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="ESTADO_INICIAL" HeaderText="DOCUMENTO ANTERIOR" SortExpression="ESTADO_INICIAL"
                                Visible="False" />
                            <asp:BoundField DataField="ESTADO_FINAL" HeaderText="DOCUMENTO " SortExpression="ESTADO_FINAL" />
                            <asp:BoundField DataField="NRO_DOC" HeaderText="N° DOCUMENTO" SortExpression="Nro_Doc">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FECHA" DataFormatString="{0:d}" HeaderText="FECHA" SortExpression="FECHA" />
                            <asp:BoundField DataField="NVISITAS" HeaderText="N° VISITAS" Visible="True">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="por_eje_fis" HeaderText="% EJECUCIÓN FISICO" Visible="True">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VALOR_PAGO" HeaderText="VALOR AUTORIZADO A PAGAR" Visible="True"
                                DataFormatString="{0:c}">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="USUARIO" HeaderText="USUARIO" SortExpression="USUARIO" />
                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" Visible="True" />
                            <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="EDITAR" ImageUrl="~/images/Operaciones/Edit2.png"
                                Text="Editar">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:ButtonField>
                            <asp:TemplateField ShowHeader="False" HeaderText="ANULAR">
                                <ItemTemplate>
                                    <asp:ImageButton ID="IBtnAnular" runat="server" SkinID="IBtnAnularM" CommandName="Anular"
                                        CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex")) %>'
                                        Visible='<%#IIF((DataBinder.Eval(Container.DataItem, "Ult")="OK"),True,False)%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" HeaderText="ANULAR">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Anular"
                                        Visible='<%#IIF((DataBinder.Eval(Container.DataItem, "Ult")="OK"),True,False)%>'
                                        Text="Anular" CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex")) %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjEstContratos" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetPorCodCon" TypeName="ActasSupervision" InsertMethod="Insert"
                        UpdateMethod="Update">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="LstSupervisiones" Name="Cod_Con" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>
                <asp:Button ID="btn_Target" runat="server" Style="display: none" />
            </div>
        </asp:Panel>
        <asp:ObjectDataSource ID="ObjRutaEst" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetbyCodCon" TypeName="Est_Ruta">
            <SelectParameters>
                <asp:ControlParameter ControlID="LstSupervisiones" Name="Cod_Con" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
