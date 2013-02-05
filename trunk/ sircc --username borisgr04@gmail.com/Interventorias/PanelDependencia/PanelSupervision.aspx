<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PanelSupervision.aspx.vb" Inherits="Interventorias_PanelDependencias_PanelDependencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" TagName="ctrAyudIzql"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true"
        EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="demoarea">
        <asp:Label CssClass="Titulo" ID="Label5" runat="server" Text='SUPERVISIONES/INTERVENTORIAS A CARGO' />
        <asp:HiddenField ID="hdUserName" runat="server" />
        <br />
        <br />
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
            SelectedIndex="0" Skin="MetroTouch">
        <Tabs>
        <telerik:RadTab runat="server" Text="Todos" Selected="True">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Asignados">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Sin Asignar">
        </telerik:RadTab>    
        </Tabs>
        </telerik:RadTabStrip>
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
                            <asp:ImageButton ID="IbtnSelect" runat="server" Width="32px" Height="32px" SkinID="IBtnDetalle"
                                CommandName="Detalle" ToolTip="Ver detalles del contrato" CommandArgument='<%# Eval("Numero") %>' />
                        </td>
                        <td style="text-align: center">
                            <asp:ImageButton ID="IbtnDesignar" runat="server" Width="32px" Height="32px" SkinID="IBtnSuper"
                                CommandName="Designar" ToolTip="Designar Supervisor" CommandArgument='<%# Eval("Numero") %>' />
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
                SelectMethod="GetContratosDep" TypeName="PanelDependencias">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtBuscar" Name="filtro" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="HfOper" Name="oper" PropertyName="Value" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="HfOper" runat="server" Value="Todos" />
        </fieldset>
    </div>
</asp:Content>
