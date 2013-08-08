<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="VerActas.aspx.vb" Inherits="CGestion_VerActas_VerActas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    
<div class="demoarea">
<h2 class="Titulo">
                    Verificación de Actas
                </h2>
                <hr />
                <p>
                <label>
                    Número de Verficación
                </label>
                
                <asp:TextBox ID="TxtID" runat="server" AutoPostBack="True"
                        CssClass="TextBox_LetrasGrandes"></asp:TextBox>
                <asp:Button ID="BtnBuscar" runat="server" Text=""  class="button_buscar" CausesValidation="False" />
                <label>
                    Ultima Acta Creada....
                </label>     
                <asp:TextBox ID="TxtUltimaActa" runat="server" AutoPostBack="True" ReadOnly="true" 
                        CssClass="TextBox_LetrasGrandes"></asp:TextBox>
             
                <a href="Contratos.aspx" title="Realizar Busqueda por N° de Contrato" class="button_example">Buscar << N° Contrato >> </a>
            
                    </p>
                     <asp:ListView ID="ListView1" runat="server" EnableModelValidation="True" DataSourceID="ObjVerActas">
                    <ItemTemplate>
                    <tr class="rows" onclick="AbrirPagina('Contratos.aspx?CodCon=<%# Eval("NRO_CONTRATO") %>')" title="Click para Ver Detalle del Contrato N° "+<%# Eval("NRO_CONTRATO") %>>
                        
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lbNumero" runat="server" Text='<%# Eval("NRO_CONTRATO") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ESTADO_FINALabel" runat="server" Text='<%# Eval("ESTADO_FINAL") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FECHALabel" runat="server" Text='<%# Eval("FECHA","{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NRO_DOCLabel" runat="server" Text='<%# Eval("NRO_DOC") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NVISITASLabel" runat="server" Text='<%# Eval("NVISITAS") %>' />
                        </td>
                        <td>
                            <asp:Label ID="VALOR_PAGOLabel" runat="server" Text='<%# Eval("VALOR_PAGO","{0:c}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="POR_EJE_FISLabel" runat="server" Text='<%# Eval("POR_EJE_FIS") %>' />
                        </td>
                        <td>
                            <a href="#" onclick="AbrirPagina('Contratos.aspx?CodCon=<%# Eval("NRO_CONTRATO") %>')">Detalle Contrato</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="alt" onclick="AbrirPagina('Contratos.aspx?CodCon=<%# Eval("NRO_CONTRATO") %>')" title="Ver Detalle del Contrato "+<%# Eval("NRO_CONTRATO") %>>
                        
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lbNumero" runat="server" Text='<%# Eval("NRO_CONTRATO") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ESTADO_FINALabel" runat="server" Text='<%# Eval("ESTADO_FINAL") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FECHALabel" runat="server" Text='<%# Eval("FECHA","{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NRO_DOCLabel" runat="server" Text='<%# Eval("NRO_DOC") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NVISITASLabel" runat="server" Text='<%# Eval("NVISITAS") %>' />
                        </td>
                        <td>
                            <asp:Label ID="VALOR_PAGOLabel" runat="server" Text='<%# Eval("VALOR_PAGO","{0:c}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="POR_EJE_FISLabel" runat="server" Text='<%# Eval("POR_EJE_FIS") %>' />
                        </td>
                        <td>
                            <a href="#" onclick="AbrirPagina('Contratos.aspx?CodCon=<%# Eval("NRO_CONTRATO") %>')">Detalle Contrato</a>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%" id="tb-consulta" class="mGrid">
                        <thead>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    Número
                                </th>
                                <th>
                                    Tipo de Acta
                                </th>
                                <th >
                                    Fecha Acta
                                </th>
                                <th>
                                    Documento N°
                                </th>
                                <th>
                                    N° de Visitas
                                </th>
                                <th>
                                    Valor Autorizado a Pagar
                                </th>
                                <th>
                                    Porcentaje de Ejecución Fisico
                                </th>
                                <th>
                                    
                                </th>
                           </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <EmptyItemTemplate>
                    <td>
                        &nbsp; No se encontraton datos
                    </td>
                </EmptyItemTemplate>
            </asp:ListView>
                 
                    <asp:ObjectDataSource ID="ObjVerActas" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="getActabyID" 
                        TypeName="CtrVerActas">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtID" Name="Id" PropertyName="Text" 
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                
</div>
<script type="text/javascript">
        <%= TxtID.ClientID%>.focus();
        function AbrirPagina(url) {
            self.location.href = url;
        }
    </script>
</asp:Content>

