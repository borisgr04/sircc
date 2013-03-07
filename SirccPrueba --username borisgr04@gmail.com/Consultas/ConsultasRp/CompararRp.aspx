<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CompararRp.aspx.vb" Inherits="Consultas_ConsultasRp_CompararRp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    <br />
    <asp:Button ID="BtnExport" runat="server" Text="Exportar" />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjConsultas" 
        EnableModelValidation="True" DataKeyNames="numero" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ButtonType="Image" 
                SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
            <asp:BoundField DataField="NUMERO" HeaderText="Número" SortExpression="NUMERO">
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="VALOR_RP" DataFormatString="{0:c}" 
                HeaderText="Valor RP" NullDisplayText="Sin Valor">
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="CANTIDAD_RP" HeaderText="Cantidad de RP" 
                NullDisplayText="Sin Registro" SortExpression="CANTIDAD_RP">
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="VALOR_TOTAL" DataFormatString="{0:c}" 
                HeaderText="Valor Total Documento" NullDisplayText="0" 
                SortExpression="VALOR_TOTAL">
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="VALOR_APORTES" DataFormatString="{0:c}" 
                HeaderText="Valor Aportes Propios" SortExpression="VALOR_APORTES">
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="DIFERENCIA" DataFormatString="{0:c}" 
                HeaderText="Diferencia" SortExpression="DIFERENCIA" />
            <asp:BoundField DataField="OBJETO" HeaderText="Objeto" SortExpression="OBJETO">
            <ItemStyle Font-Size="Smaller" VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHA_SUSCRIPCIÓN" DataFormatString="{0:d}" 
                HeaderText="Fecha de Suscripción">
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="CONTRATISTA" HeaderText="Contratista" 
                SortExpression="CONTRATISTA">
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="NUMERO" 
                DataNavigateUrlFormatString="DCompararRp.aspx?Cod_Con={0}" 
                DataTextField="NUMERO" Text="Detalle">
            <ItemStyle VerticalAlign="Top" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="HdVigencia" runat="server" />
    <asp:ObjectDataSource ID="ObjConsultas" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetConsultaRp" 
        TypeName="Consultas">
        <SelectParameters>
            <asp:ControlParameter ControlID="HdVigencia" Name="Vigencia" 
                PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</div>
</asp:Content>

