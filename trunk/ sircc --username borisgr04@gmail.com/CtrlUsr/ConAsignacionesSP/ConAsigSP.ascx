<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConAsigSP.ascx.vb" Inherits="CtrlUsr_ConAsignacionesSP_ConAsigSP" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
        <div>
    
<asp:Label ID="Label1" runat="server" 
            CssClass="SubTitulo" Text="DEPENDENCIA A CARGO DEL PROCESO"></asp:Label>

    <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
            DataTextField="nom_dep" DataValueField="cod_dep" AutoPostBack="True">
    </asp:DropDownList>

    <asp:Label ID="Label2" runat="server" 
            CssClass="SubTitulo" Text="Vigencia"></asp:Label>

    <asp:DropDownList ID="CmbVigencia" runat="server" Width="140px" 
                    DataSourceID="ObjVigencias" DataTextField="Year_Vig" 
                    DataValueField="Year_Vig"></asp:DropDownList>



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
<asp:ObjectDataSource ID="ObjCargaPS" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetCargaPSxDel" 
    TypeName="CargaPS">
    <SelectParameters>
        <asp:ControlParameter ControlID="CboDepP" Name="Dep_PCon" 
            PropertyName="SelectedValue" Type="String" />

            <asp:ControlParameter ControlID="CmbVigencia" Name="Vigencia" 
            PropertyName="SelectedValue" Type="String" />

            
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Vigencias"></asp:ObjectDataSource>
