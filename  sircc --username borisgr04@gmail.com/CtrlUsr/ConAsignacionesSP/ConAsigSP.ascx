<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConAsigSP.ascx.vb" Inherits="CtrlUsr_ConAsignacionesSP_ConAsigSP" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
        <div>
                                <asp:Label ID="SubT" runat="server" 
            CssClass="SubTitulo" Text="DEPENDENCIA A CARGO DEL PROCESO"></asp:Label>
    <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
            DataTextField="nom_dep" DataValueField="cod_dep" AutoPostBack="True">
    </asp:DropDownList>
    </div>
        <br />

    <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbySoloUser" 
            TypeName="Dependencias" 
            InsertMethod="AsignarAbogado" >
        </asp:ObjectDataSource>

<rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" 
    Height="600px">
    <LocalReport ReportPath="PReportes\PContratos\RptCargaPS.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ObjCargaPS" Name="dsCargaPS" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="ObjCargaPS" runat="server" InsertMethod="InsertP" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetCargaPSxDel" 
    TypeName="Con_PContratos">
    <InsertParameters>
        <asp:Parameter Name="COD_TPRO" Type="String" />
        <asp:Parameter Name="OBJ_CON" Type="String" />
        <asp:Parameter Name="DEP_CON" Type="String" />
        <asp:Parameter Name="DEP_PCON" Type="String" />
        <asp:Parameter Name="VIG_CON" Type="Decimal" />
        <asp:Parameter Name="TIP_CON" Type="String" />
        <asp:Parameter Name="STIP_CON" Type="String" />
        <asp:Parameter Name="FEC_RECIBIDO" Type="DateTime" />
        <asp:Parameter Name="NUM_SOL" Type="String" />
    </InsertParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="CboDepP" Name="Dep_PCon" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
