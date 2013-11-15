<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PanelReporte.aspx.vb" Inherits="Reportes_PanelProcesos_PanelReporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
    <div>
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

        Delegación
        <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel"
                                DataTextField="nom_dep" DataValueField="cod_dep"
                                AutoPostBack="True">
        </asp:DropDownList>
        <asp:Button ID="BtnEnc" runat="server" Text="..." />
         Encargado
         <asp:DropDownList ID="CboEnc" runat="server" DataSourceID="ObjTerceros" 
                                DataTextField="Nom_Ter" DataValueField="Ide_Ter">
        </asp:DropDownList>

        Modalidad
         <asp:DropDownList ID="CboTproc" runat="server" CssClass="txt" 
                                DataSourceID="ObjTipoProc" DataTextField="Nom_TProc" DataValueField="Cod_TProc" 
                                ToolTip="Proceso PreContractual">
                            </asp:DropDownList>
        Mostrar Actividades
         <asp:DropDownList ID="CboObl" runat="server" >
            <asp:ListItem Text="Hitos" Value ="NT"></asp:ListItem>
            <asp:ListItem Text="Obligatorias" Value ="OB"></asp:ListItem>
            <asp:ListItem Text="Todas" Value ="TD"></asp:ListItem>
         </asp:DropDownList>
        
        
        
        <asp:Button ID="BtnActualizar" runat="server" Text="Consultar" />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="600px">
    <LocalReport ReportPath="Reportes\PanelProcesos\RptPanelProcesos.rdlc" >
    <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjCrono" Name="DataSet1" />
      </DataSources>
    </LocalReport>
     
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjTipoProc" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="TiposProc"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjCrono" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="getActividades2" 
            TypeName="ConsCronograma">
            <SelectParameters>
                <asp:Parameter DefaultValue="2013" Name="Vigencia" Type="String" />
                <asp:ControlParameter ControlID="CboTproc" Name="TipProc" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="CboObl" Name="Clasificacion" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="CboEnc" Name="Encargado" 
                    PropertyName="SelectedValue" Type="String" />
                    
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjTerceros" runat="server" 
    SelectMethod="GetTercerosxDep" TypeName="Terceros" DeleteMethod="Delete" 
    OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter Name="busc" Type="String" />
        <asp:ControlParameter ControlID="CboDepP" Name="cod_dep" 
            PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbyUser" 
            TypeName="Dependencias" >
        </asp:ObjectDataSource>      
    </div>
    </form>
</body>
</html>
