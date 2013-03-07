<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DetPContratoE.ascx.vb"
    Inherits="Controles_DetPContratoE" %>
<style type="text/css">
    td
    {
        height: 10px;
        empty-cells: show;
        text-align: left;
        vertical-align: top;
    }
    
    .txt
    {
        font-size: 9pt;
    }
</style>

<style type="text/css">
    
.rcbHeader ul,
.rcbFooter ul,
.rcbItem ul, .rcbHovered ul, .rcbDisabled ul
{
    width: 100%;
    display: inline-block;
    margin: 0;
    padding: 0;
    list-style-type: none;
    z-index:200;
}

.col1, .col2, .col3,.col4,.col5
{
    float: left;
    width: 110px;
    margin: 0;
    padding: 0 5px 0 0;
    line-height: 14px;
}

label,
.selection-result
{
    font: 13px 'Segoe UI', Arial, sans-serif;
    color: #4888a2;
}

label
{
    padding: 0 10px 0 0;
}

.button
{
    vertical-align: middle;
    margin-left: 10px;
}

.selection-result
{
    padding: 10px 0 10px 0;
    display: block;
}

div.bigModuleBottom
{
    padding-top: 25px;
}


        .multipleRowsColumns .rcbItem, .multipleRowsColumns .rcbHovered
        {
            float: left;
            margin: 0 1px;
            min-height: 13px;
            overflow: hidden;
            padding: 2px 19px 2px 6px;
            width: 125px;
        }
        html.rfdButton a.rfdSkinnedButton 
     {
     vertical-align: middle;
     margin: 0 0 0 5px;
     }
     label
     {
     display: inline-block;
     width: 200px;
     text-align: right;
     padding-right: 5px;
     margin-top: 10px;
     }
        * html.rfdButton a.rfdSkinnedButton,
     * html.rfdButton input.rfdDecorated
     {
         vertical-align: top;
     }
    </style>

<table style="width: 610px">
    <tr>
        <td style="width: 509px; height: 14px; ">
            &nbsp; <strong>N°PROCESO</strong>
        </td>
        <td colspan="2" style="width: 509px; height: 14px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="height: 14px; text-align: center;" colspan="2">
        
           <telerik:RadComboBox ID="RadComboBox1" runat="server" Skin="WebBlue" DataSourceID="ObjPContratos"
                DataTextField="Pro_Sel_Nro" DataValueField="Pro_Sel_Nro" AllowCustomText="True" EnableLoadOnDemand="false"
                AutoPostBack="True" Culture="es-CO" Filter="Contains" IsCaseSensitive="True" Width="650px">
                <HeaderTemplate>
                    <ul >
                        <li class="col1">N° Proceso</li>
                        <li class="col2">Objeto</li>
                        <li class="col3">Dependencia Solicitante</li>
                        <li class="col4">Modalidad</li>
                        <li class="col5">Estado</li>
                    </ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <ul>
                        <li class="col1">
                            <%# DataBinder.Eval(Container.DataItem, "Pro_Sel_Nro")%></li>
                        <li class="col2">
                          <i>  <%# DataBinder.Eval(Container.DataItem, "Obj_Con")%></i></li>
                        <li class="col3">
                          <b>  <%# DataBinder.Eval(Container.DataItem, "Dep_Nec")%></b></li>
                        <li class="col4">
                            <%# DataBinder.Eval(Container.DataItem, "Nom_Tproc")%><li>
                         <li class="col5">
                            <%# DataBinder.Eval(Container.DataItem, "Nom_Est")%></li>
                    </ul>
                </ItemTemplate>
                <FooterTemplate>
                    Un Total de 
                    <asp:Literal runat="server" ID="RadComboItemsCount" />
                    items
                </FooterTemplate>
            </telerik:RadComboBox>
        
        </td>
        <td style="width: 509px; height: 14px">
            <asp:ImageButton ID="IbtnBuscar" runat="server" 
                ImageUrl="~/images/Operaciones/Search.png" Visible="False" />
        </td>
    </tr>
    <tr>
        <td colspan="3" style="height: 14px; text-align: center;">
            <asp:Label ID="MsgResult" runat="server" Height="30px" Visible="False" Width="90%"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:DetailsView ID="DtPCon" runat="server" AutoGenerateRows="False" CellPadding="4"
                DataKeyNames="Cod_Tpro" EnableModelValidation="True" Font-Size="X-Small" ForeColor="#333333"
                GridLines="None" Height="84px" Width="95%">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <Fields>
                    <asp:BoundField DataField="Nom_TProc" HeaderText="Tipo de Proceso" SortExpression="Nom_TProc" />
                    <asp:BoundField DataField="PRO_SEL_NRO" HeaderText="N° Proceso " SortExpression="PRO_SEL_NRO">
                        <ItemStyle Font-Bold="True" Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="OBJ_CON" HeaderText="Objeto" SortExpression="OBJ_CON" />
                    <asp:BoundField DataField="PLA_EJE_CON" HeaderText="Plazo de Ejecución" SortExpression="PLA_EJE_CON" />
                    <asp:BoundField DataField="VAL_CON" DataFormatString="{0:c}" HeaderText="Valor "
                        SortExpression="VAL_CON" />
                    <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia que Genera la Necesidad"
                        SortExpression="Dep_Nec" />
                    <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia a Cargo del Proceso"
                        SortExpression="Dep_Del" />
                    <asp:BoundField DataField="Encargado" HeaderText="Funcionario Encargado" SortExpression="Encargado" />
                    <asp:BoundField DataField="Nom_Est" HeaderText="Estado del Proceso" SortExpression="Nom_Est">
                        <ItemStyle Font-Bold="True" Font-Size="Medium" />
                    </asp:BoundField>
                </Fields>
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderTemplate>
                    INFORMACIÓN DETALLADA DEL PROCESO DE CONTRATACIÓN
                </HeaderTemplate>
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:DetailsView>
            <asp:ObjectDataSource ID="ObjPContratos" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetxUsuario" TypeName="PContratos">
                <SelectParameters>
                    <asp:Parameter Name="Filtro" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>
          
