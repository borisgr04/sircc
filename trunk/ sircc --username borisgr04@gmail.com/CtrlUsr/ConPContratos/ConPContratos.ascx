<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConPContratos.ascx.vb" Inherits="CtrlUsr_ConPContratos_ConPContratos" %>
<%@ Register src="../FiltroPCon/FiltroPCon.ascx" tagname="FiltroPCon" tagprefix="uc1" %>

<asp:UpdatePanel ID="UpdateAct" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                 <ContentTemplate>
<div style="padding-left:5%; padding-bottom:5%; padding-right:5%; padding-top:2%;">
<uc1:FiltroPCon ID="FiltroPCon1" runat="server" />
    <asp:GridView ID="grdProcesos" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" DataSourceID="ObjPContratos" 
        EnableModelValidation="True" Width="90%" DataKeyNames="Pro_Sel_Nro">
        <Columns>
            <asp:BoundField DataField="Pro_Sel_Nro" HeaderText="N° Proceso" 
                SortExpression="Pro_Sel_Nro" />
            <asp:BoundField DataField="Nom_Tproc" HeaderText="Modalidad Contratación" 
                SortExpression="Nom_Tproc" />
            <asp:BoundField DataField="Obj_Con" HeaderText="Objeto a Contratar" 
                SortExpression="Obj_Con" />
            <asp:BoundField DataField="Dep_Nec" HeaderText="Dependencia-Necesidad" 
                SortExpression="Dep_Nec" />
            <asp:BoundField DataField="Dep_Del" HeaderText="Dependencia-Delegada" 
                SortExpression="Dep_Del" />
            <asp:BoundField DataField="Nom_Est" HeaderText="Estado" 
                SortExpression="Nom_Est" />
            <asp:CommandField ButtonType="Image" 
                SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjPContratos" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetxUsuario" 
        TypeName="PContratos">
   
        <SelectParameters>
            <asp:SessionParameter Name="filtro" SessionField="FiltroPCon_Filtro" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>            

</ContentTemplate></asp:UpdatePanel>            
