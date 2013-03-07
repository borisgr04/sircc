<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Alert_Inf.ascx.vb" Inherits="CtrlUsr_alert_Inf_Alert_Inf" %>
<style type="text/css">
    ul
    {
    list-style-type: none;
    padding: 15px;
    margin: 15px;
    }
    .even 
    { 
         
        background-color: White;
        color:#333333;background-color:#F7F6F3;
    }
    .odd 
    {
        background-color: #8080FF;
        color:#284775;
        background-color:White;
    }
    </style>
<br />
<asp:Label ID="LbTitulo" runat="server" Text="RECORDATORIOS DE INFORMES A ENTREGAR" CssClass="Titulo"  ></asp:Label>
<br /><br />
        <asp:DataPager ID="dtTop" runat="server" PageSize="5" PagedControlID="ListView1">
        <Fields>
            <asp:NextPreviousPagerField />
            <asp:NumericPagerField />
        </Fields>
       </asp:DataPager>
       <br />
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="Vigencia,Codigo" DataSourceID="ObjAlertasInf"
        GroupItemCount="2" >
        <GroupTemplate>
                <tr runat="server" id="productRow"
                    style="height:80px">
                     <td runat="server" id="itemPlaceholder">
                </td> 
                </tr>
        </GroupTemplate>
        <ItemTemplate>
                <%--<li class="<%# iiF(Container.DisplayIndex Mod 2 = 0 , "even" , "odd") %>" >    
                <div style="float:left;" > 
                    <asp:Image ID="Image1" runat="server" ImageUrl=<%# Eval("Img") %>  Height="48" Width="48"  />
                </div>
                <%# Eval("TxtRecordatorio") %>  -             
                <b>Fecha PreInforme:</b> <%# CDate(Eval("Recordatorio")).ToShortDateString %>  
                </li>
                <br />--%>
                <td id="Td1" valign="top" align="left" style="width:100" runat="server">
                <div style="float:left;" > 
                <asp:Image ID="Image1" runat="server" ImageUrl=<%# Eval("Img") %>  Height="48" Width="48"  />
                </div>
                <%# Eval("TxtRecordatorio") %>  -             
                <b>Fecha PreInforme:</b> <%# CDate(Eval("Recordatorio")).ToShortDateString %>  
                 </td>

        </ItemTemplate>
        <LayoutTemplate>
        <%-- <ul>
            <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
        </ul>
--%>
         <table cellpadding="2" runat="server"
           id="tblProducts" style="height:320px">
            <tr runat="server" id="groupPlaceholder">
        </tr>
        </table>

        </LayoutTemplate>
     </asp:ListView>
   <asp:ObjectDataSource ID="ObjAlertasInf" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyTxt" 
            TypeName="Alertas"></asp:ObjectDataSource>
        