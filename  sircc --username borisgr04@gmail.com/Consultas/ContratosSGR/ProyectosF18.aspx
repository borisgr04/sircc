<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ProyectosF18.aspx.vb" Inherits="Consultas_ContratosSGR_ProyectosF18" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
          <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </ajaxToolkit:ToolkitScriptManager>
     <div>
         <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
        Text="FORMATO F18"></asp:Label>
         <br />
         <br />
                    <asp:Label ID="Label11" runat="server" Text="Vigencia"></asp:Label>
                    <asp:DropDownList ID="CmbVig" runat="server" DataSourceID="odsVigencias" DataTextField="YEAR_VIG"
                        DataValueField="YEAR_VIG">
                    </asp:DropDownList>
                    <asp:Button ID="BtnBuscar" runat="server" ValidationGroup="NoValidar" Text="Buscar" />
                    <asp:Button ID="BtnExport" runat="server" ValidationGroup="NoValidar" Text="Exportar" />
                </div>
                <br />
                
                <div style="overflow:auto; width:900px; height:500px" >
                <asp:GridView ID="GridView1" runat="server"
                    AllowSorting="True" AutoGenerateColumns="True" CellPadding="4"
                    EmptyDataText="No se encontraron Registros en la Base de Datos"
                    EnableModelValidation="True" ForeColor="#333333" GridLines="None"
                    OnRowDataBound="GridView1_RowDataBound1"
                    Width="90%" >
                </asp:GridView>
                </div>
               
    <asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetRecords"
        TypeName="Vigencias" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>

</asp:Content>

