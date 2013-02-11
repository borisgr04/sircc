<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Con_Cronograma.aspx.vb" Inherits="Consultas_AvisosActD_Con_Cronograma" %>

<%@ Register src="../../CtrlUsr/DetPContratos/DetPContratoF.ascx" tagname="DetPContratoF" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptLocalization="true" EnablePartialRendering="true" >
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:DetPContratoF ID="DetPContratoF1" runat="server" />
            <br />
            <asp:Label ID="Label1" runat="server" CssClass="Titulo" 
                Text="Cronograma del Proceso"></asp:Label>
                <br />
            <hr />
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/Procesos/Programacion/ImprimirCrono.aspx" Target="_blank">Vista de Calendario</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" 
                NavigateUrl="~/Procesos/Programacion/RptCrono.aspx" Target="_blank">Ver Reporte</asp:HyperLink>
            <hr />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="Nom_Act" HeaderText="Actividad" />
                    <asp:BoundField DataField="FECHACRONO" HeaderText="Fecha">
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <%--<asp:BoundField DataField="FECHAI" DataFormatString="{0:d}" 
                HeaderText="Desde" />
            <asp:BoundField DataField="des_hori" HeaderText="Hora" />
            <asp:BoundField DataField="FechaF" DataFormatString="{0:d}" 
                HeaderText="Hasta" />
            <asp:BoundField DataField="des_horf" HeaderText="Hora" />--%>
                    <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" />
                    <asp:BoundField DataField="Nom_Est" HeaderText="Estado" />
                    <%--<asp:BoundField DataField="Fecha_Aviso" DataFormatString="{0:d}" 
                HeaderText="Fecha Aviso" />--%>
                    <asp:ButtonField ButtonType="Image" CommandName="editar" HeaderText="Editar" 
                        ImageUrl="~/images/Operaciones/Edit2.png" Text="Button" Visible="false" />
                    <asp:ButtonField ButtonType="Image" CommandName="anular" HeaderText="Anular" 
                        ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" Visible="false" />
                    <asp:ButtonField ButtonType="Image" CommandName="seguimiento" 
                        HeaderText="Seguimiento" ImageUrl="~/images/Operaciones/Calendar-icon.png" 
                        Visible="false" />
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" 
                        Visible="false" />
                </Columns>
            </asp:GridView>
                <br /><br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

