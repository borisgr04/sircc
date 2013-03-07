<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BarraTareas.ascx.vb" Inherits="CtrlUsr_BarraTareas_BarraTareas" %>
<center>
      <asp:DataList ID="DtTareasP" runat="server" 
        RepeatDirection="Horizontal" 
        DataSourceID="ObjTareasP">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton2" runat="server" 
            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Descrip")%>' 
            ToolTip=''>
            <%# DataBinder.Eval(Container.DataItem, "Descrip")%>(<b><%# DataBinder.Eval(Container.DataItem, "Cantidad") %></b>)</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </ItemTemplate>
    </asp:DataList>
</center>  
    <asp:ObjectDataSource ID="ObjTareasP" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPendietes" 
        TypeName="Consultas"></asp:ObjectDataSource>
             

