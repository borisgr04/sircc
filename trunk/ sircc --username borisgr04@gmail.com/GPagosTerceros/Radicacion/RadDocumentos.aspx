<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RadDocumentos.aspx.vb" Inherits="GPagosTerceros_Radicacion_RadDocumentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <%--<link href="Style.css" rel="stylesheet" type="text/css" />--%>
    
     <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
    <br />
    <asp:HiddenField ID="HdEstado" runat="server" />
    <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
                    Text="Radicación de Cuentas"></asp:Label>
    <br />
    <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label>
    <br />
    <telerik:RadTabStrip ID="RTabDocs" runat="server" DataFieldID="Cod_Est"  
        DataSourceID="ObjGPEst" DataTextField="Nom_Est" DataValueField="Cod_Est" 
        MultiPageID="Cod_Est">
        <Tabs>
      
        </Tabs>
    </telerik:RadTabStrip>
   
    <table style="width: 100%">
        <tr>
            <td style="width: 147px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 147px">
                <asp:RadioButtonList ID="rdFiltro" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal" Height="26px" Width="229px">
                    <asp:ListItem Selected="True" Value="N">Por Recibir</asp:ListItem>
                    <asp:ListItem Value="S">Recibidas</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:TextBox ID="txtfiltro" runat="server" Width="90%"></asp:TextBox>
      <%--   <telerik:RadComboBox runat="server" ID="RadCboFiltro" Height="190px" Width="400px" DropDownWidth="460px"
            MarkFirstMatch="true" DataSourceID="ObjDocs" EnableLoadOnDemand="true" AutoPostBack="true"
            HighlightTemplatedItems="true"  Filter="Contains" 
            OnClientItemsRequested="UpdateItemCountField"
            OnDataBound="RadComboBox1_DataBound" OnItemDataBound="RadComboBox1_ItemDataBound"
            OnItemsRequested="RadComboBox1_ItemsRequested" Label="Seleccione Documento:">
            <HeaderTemplate>
                <ul>
                    <li class="col1">Número</li>
                    <li class="col2">Documento</li>
                    <li class="col3">Contratista</li>
                    <li class="col4">Objeto</li>
                </ul>
            </HeaderTemplate>
            <ItemTemplate>
                <ul>
                    <li class="col1">
                        <%# DataBinder.Eval(Container.DataItem, "Numero") %> </li> 
                    
                    <li class="col2">
                        <%# DataBinder.Eval(Container.DataItem, "Documento") & "-" & DataBinder.Eval(Container.DataItem, "ID")%></li> 
                    <li class="col3">
                        <%# DataBinder.Eval(Container.DataItem, "Contratista")%></li>
                    <li class="col4">
                        <%# DataBinder.Eval(Container.DataItem, "Objeto")%></li>
                </ul>
            </ItemTemplate>
            <FooterTemplate>
                Un total de
                <asp:literal runat="server" id="RadComboItemsCount" />
                items
            </FooterTemplate>
        </telerik:RadComboBox>
      --%>      
                <asp:ImageButton ID="IBtnBuscar" runat="server" SkinID="IBtnBuscar" />
            
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 147px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 147px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
               <div class="qsf-demo-canvas">
            
            </div>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
   
   <br />
   
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjDocs" 
        EnableModelValidation="True" AutoGenerateColumns="False" 
        DataKeyNames="numero,id">
        <Columns>
        <asp:BoundField DataField="NUMERO" HeaderText="N° Contrato" SortExpression="NUMERO" />
        <asp:BoundField DataField="ID" HeaderText="ID DOCUMENTO" SortExpression="ID" />
        <asp:BoundField DataField="DOCUMENTO" HeaderText="DOCUMENTO" SortExpression="DOCUMENTO" />
        <asp:BoundField DataField="CONTRATISTA" HeaderText="CONTRATISTA" SortExpression="CONTRATISTA" />
        <asp:BoundField DataField="OBJETO" HeaderText="OBJETO" SortExpression="OBJETO" />
        <asp:BoundField DataField="VAL_PAGO" HeaderText="VALOR A PAGAR" SortExpression="VAL_PAGO" DataFormatString="{0:c}" >
        <ItemStyle  HorizontalAlign="Right" Wrap="false" />
        </asp:BoundField>
        <asp:BoundField DataField="SUPERVISOR" HeaderText="SUPERVISOR" SortExpression="SUPERVISOR" />
        <asp:BoundField DataField="VALOR" HeaderText="VALOR" SortExpression="VALOR"  DataFormatString="{0:c}" >
        <ItemStyle  HorizontalAlign="Right" Wrap="false" />
        </asp:BoundField>
        <asp:BoundField DataField="APORTES_PROPIOS" HeaderText="APORTES PROPIOS" SortExpression="APORTES_PROPIOS"  DataFormatString="{0:c}" >
        <ItemStyle  HorizontalAlign="Right" Wrap="false" />
        </asp:BoundField>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/2012/select.png" 
                SelectText="" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
   
    <asp:ObjectDataSource ID="ObjGPEst" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetEstados" 
        TypeName="RadDocumentos">
        <SelectParameters>
            <asp:SessionParameter Name="Vig_Est" SessionField="vigencia" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjDocs" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocs" 
        TypeName="RadDocumentos">
        <SelectParameters>
            <asp:SessionParameter Name="Vig_Est" SessionField="vigencia" Type="String" />
            <asp:Parameter DefaultValue="AP" Name="Cla_Doc" Type="String" />
            <asp:ControlParameter ControlID="HdEstado" DefaultValue="" Name="Est_Para" 
                PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="rdFiltro" DefaultValue="N" Name="Hecho" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="txtfiltro" Name="filtro" 
                PropertyName="text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function UpdateItemCountField(sender, args) {
                //Set the footer text.
                sender.get_dropDownElement().lastChild.innerHTML = " Total de " + sender.get_items().get_count() + " items";
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>

