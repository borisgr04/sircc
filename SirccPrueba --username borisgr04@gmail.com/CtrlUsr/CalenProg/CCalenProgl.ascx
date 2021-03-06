﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CCalenProgl.ascx.vb" Inherits="CtrlUsr_CalenProg_CCalenProgl" %>
<%@ Register assembly="DataCalendar" namespace="DataControls" tagprefix="dc" %>
<%@ Register src="GActividades.ascx" tagname="GActividades" tagprefix="uc1" %>

 <style>
a.info {
    position:relative;
    z-index:24; 
    background-color:#FFFFFF;
    background-color:transparent;
    color:#000000;
    text-decoration:none;
    
} 
a.info:hover {
    z-index:25;
    color:#0000FF;
} 
a.info div.infodiv   
{
    
    display: none;
} 
a.info:hover div.infodiv   
{
    display:block;
    position:absolute;
    top:2em;
    left:2em;
    width:200px;
    border:1px solid #0cf;
    background-color:#EEEEEE;
    color:#000000;
    background-color:lemonchiffon;
    border:solid 1px Black;
    text-align: left;
    font-family: Arial, Helvetica, sans-serif;
    font-size: 10px;
    font-weight:normal;
    padding: 5px;
} 

.LbActT
{
    text-align:left; 
    font-size:x-small;
    }
    .LbAct
{
    text-align:left; 
    font-size:xx-small;
    }
</style>


<asp:Panel ID="pnBarra" runat="server">
<table width="100%">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
           &nbsp;
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td  style="width: 60%;">
            &nbsp;
        </td>
        <td style="text-align: right">
            <asp:UpdatePanel ID="UPModoVista" runat="server" UpdateMode="Always">
            <ContentTemplate>
        <asp:RadioButton ID="rdTabla" runat="server" AutoPostBack="True" 
                GroupName="VISTA" Text="Vista de Tabla" 
                ToolTip="Muestra cada actividad detallada" />
            <asp:RadioButton ID="rdCalendario" runat="server" AutoPostBack="True" 
                GroupName="VISTA" Text="Vista de Calendario" />
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
    </tr>
</table>
</asp:Panel>            


<asp:UpdatePanel ID="UpdateHora" runat="server" UpdateMode="Conditional" >
<ContentTemplate>
<asp:Panel ID="PnCronograma" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:LinkButton ID="LnkNu" runat="server" Visible="False">Nueva Actividad</asp:LinkButton>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="Num_Proc" HeaderText="N° Proceso" />
            <asp:BoundField DataField="Nom_Act" HeaderText="Actividad" />
            <asp:BoundField DataField="FECHAI" DataFormatString="{0:d}" 
                HeaderText="Desde" />
            <asp:BoundField DataField="des_hori" HeaderText="Hora" />
            <asp:BoundField DataField="FechaF" DataFormatString="{0:d}" 
                HeaderText="Hasta" />
            <asp:BoundField DataField="des_horf" HeaderText="Hora" />
            <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" />
            <asp:BoundField DataField="Nom_Est" HeaderText="Estado" />
            <asp:BoundField DataField="Fecha_Aviso" DataFormatString="{0:d}" 
                HeaderText="Fecha Aviso" />
            <asp:CommandField ButtonType="Image" 
                SelectImageUrl="~/images/BlueTheme/Select.png" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
      <asp:GridView ID="GridView2" runat="server" 
    DataSourceID="ObjPCronogramasF" EnableModelValidation="True" 
                AutoGenerateColumns="False">    
          <Columns>
              <asp:BoundField DataField="Fecha" DataFormatString="{0:d}" HeaderText="Fecha" />
          </Columns>
</asp:GridView>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:LinkButton ID="LnkNu0" runat="server" Visible="False">Nueva Actividad</asp:LinkButton>
        <dc:DataCalendar id="cal1" runat="server" width="100%"
                             DayField="Fecha" DayNameFormat="Full"
                             VisibleDate="12/12/2010"
                             OnVisibleMonthChanged="MonthChange" >
                            <TitleStyle CssClass="Titulo" HorizontalAlign="Center"  BackColor="White" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" Height="25px" />
                            <DayStyle HorizontalAlign="Right" VerticalAlign="Top"  Font-Size="10" Font-Name="Arial" BackColor="White"  />
                            <WeekendDayStyle ForeColor="#992200" Font-Bold="true"/>
                            <TodayDayStyle ForeColor="#00FF00"  Font-Bold="true"  />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#000000" Font-Bold="true"  />
                <itemtemplate>
                    <%-- SelectionMode="Day" href='../../DatosBasicos/Calendario/eventDetail.aspx?id=<%# Container.DataItem("Id") %>'--%>
                    <a  class="info">  
                    <%--<asp:Image ID="Image1" runat=server ImageUrl='<%# Container.DataItem("Imagen") %>'  height="16" width="16" align="absmiddle" border="0"/>--%>
                    <%-- CssClass="BarTitleModal2" Font-Strikeout='<%#IIf(Container.DataItem("Realizado")="S","True","False")%>'--%>
                    <asp:Panel ID="Panel1" runat="server" CssClass="ItemCalendar" height="100%"  >
                    <div style="text-align:justify; padding:2px 2px 2px 2px ">
                    <table>
                    <tr>
                    <td>
                     <asp:Label ID="Label1" runat="server" Text=""  CssClass="LbActT" ForeColor=<%#Util.HEXCOL2RGB(Container.DataItem("COLOR"))%> Font-Bold="true"   >
                        <%# Container.DataItem("Nom_Act")%></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:Label ID="LbProc" runat="server" Text=""  CssClass="LbAct" ForeColor="#333333"   >
                        <%# Container.DataItem("Num_Proc")%></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text=""  CssClass="LbAct" ForeColor="#333333"   >
                        <%# IIf(Container.DataItem("Fecha") = Container.DataItem("FechaI"), "<b>Inicia: </b> " + Container.DataItem("Des_HorI").ToString, "")%></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:Label ID="Label3" runat="server" Text=""  CssClass="LbAct" ForeColor="#333333"   >
                        <%# IIf(Container.DataItem("Fecha") = Container.DataItem("FechaF"), "<b>Termina: </b> " + Container.DataItem("Des_HorF").ToString, "")%></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                        <asp:CheckBox ID="chkOcup" runat="server" CssClass="LbAct"   Checked= <%# Util.SI_NO(Container.DataItem("Ocupado"))%> Enabled="false" Text="Ocupado"></asp:CheckBox>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        <asp:label ID="LbEst" runat="server" CssClass="LbAct"  Text= <%# Container.DataItem("Nom_Est")%> ></asp:label>                        </td>
                        </tr>
                        </table>
                        </div>
                    </asp:Panel> <div class="SepCalendar"></div>  
                    <div class="infodiv">
                    <b>ID Actividad:</b><%#CStr( Container.DataItem("ID"))%><br /><b>Ubicación:</b><%# Container.DataItem("Ubicacion")%><br /><b>Notas:</b><%# Container.DataItem("Notas")%><br /><b>Observación:</b><%# Container.DataItem("Obs_Seg")%><br /><b>Modalidad Contratación:</b><%# Container.DataItem("nom_tproc")%><br /><b>Dependencia Necesidad:</b><%# Container.DataItem("dep_nec")%><br /><b>Dependencia Delegada:</b><%# Container.DataItem("dep_del")%><br /><b>Objeto:</b><%# Container.DataItem("Obj_Con")%><br /><b>Encargado:</b> <%# Container.DataItem("Encargado")%><br />
                        <%--<b>Fecha Asignación:</b> <%# CDate(Container.DataItem("fechaasig")).ToShortDateString%>--%>
                        <%--<br /><b>Observación:</b><%# Container.DataItem("Obs")%><br /><b>Realizado:</b> <%# Container.DataItem("Realizado")%>--%>
                    </div>
                    </a>        
                        
                </ItemTemplate>
                
                <noeventstemplate>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </NoEventsTemplate>
            </dc:DataCalendar>
            </asp:View>
    </asp:MultiView>
    
</asp:Panel>
 
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="GActividades1" EventName="CancelClicked" />
<asp:AsyncPostBackTrigger ControlID="GActividades1" EventName="SaveNuevoClicked" />
    <asp:AsyncPostBackTrigger ControlID="rdTabla" EventName="CheckedChanged" />
    <asp:AsyncPostBackTrigger ControlID="rdCalendario" EventName="CheckedChanged" />
    
    <asp:AsyncPostBackTrigger ControlID="LnkNu" EventName="Click" />
    
</Triggers>
</asp:UpdatePanel>
<!----Modal-->

        <asp:Panel ID="PanelvRegistro" runat="server" BackColor="White" Width="700px">
            <asp:Panel ID="Panel4" runat="server" CssClass="BarTitleModal2" BorderColor="White" 
                Height="27px" Width="99%">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 1159px">
                            <asp:Label ID="LbTitModal" runat="server" ForeColor="White" Text=" Registro de Actividades" 
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 923px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCerrar" runat="server" Text="X" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        <uc1:GActividades ID="GActividades1" runat="server" />
        </asp:Panel>

        
        <asp:Button style="DISPLAY: none" id="Btn_Target" runat="server"></asp:Button>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupAct" 
        runat="server"
        TargetControlID="Btn_Target" 
        PopupControlID="PanelvRegistro" 
        CancelControlID="BtnCerrar" 
        BackgroundCssClass="modalBackground" 
        DropShadow="True">
        </ajaxToolkit:ModalPopupExtender>   
<!----->

     

        <asp:ObjectDataSource ID="ObjPCronogramas" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="PCronogramas" >
            
        <SelectParameters>
            <asp:ControlParameter ControlID="HdNumProc" Name="Num_Proc" PropertyName="Value" 
                Type="String" />
        </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ID_O" Type="String" />
                <asp:Parameter Name="OBS_SEG" Type="String" />
            </UpdateParameters>
    </asp:ObjectDataSource>

        

        <asp:ObjectDataSource ID="ObjPCronogramasF" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetbyFechas" 
        TypeName="PCronogramas" >
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="ID" PropertyName="SelectedValue" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

       <asp:HiddenField ID="HdNumProc" runat="server" />


       <asp:HiddenField ID="HdFiltro" runat="server" />


