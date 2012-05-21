<%@ Page Language="VB" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PContratosInf.aspx.vb" Inherits="Consultas_Pcontratos_PContratosInf" %>

<%@ Register src="../../CtrlUsr/FiltroSol/FiltroSolP.ascx" tagname="FiltroSolP" tagprefix="uc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register src="../../CtrlUsr/FiltroPCon/FiltroPConP.ascx" tagname="FiltroPConP" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>


     <div class="demoheading">REPORTE DE PROCESOS</div>
        <br />
<%--
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
--%>        <table >
            <tr>
                <td>
                    Dependencia a Cargo del Proceso</td>
                <td>
<span>
                            <asp:DropDownList ID="CboDepP" runat="server" DataSourceID="ObjDepDel" 
                                DataTextField="nom_dep" DataValueField="cod_dep" Width="250px">
                            </asp:DropDownList>
                        </span>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Fecha Inicial</td>
                <td>
                            <asp:TextBox ID="TxtF1" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="TxtF1_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtF1">
                            </ajaxToolkit:CalendarExtender>
                </td>
                <td>
                    
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    Fecha Final</td>
                <td>
                            <asp:TextBox ID="TxtF2" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="TxtF2_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtF2">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="" Visible="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    Modalidad de Contratación</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:CheckBoxList ID="ChkMod" runat="server" AutoPostBack="True" 
                        DataSourceID="ObjModalidad" DataTextField="Nom_Tproc" 
                        DataValueField="Cod_Tproc" RepeatColumns="4" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnAct" runat="server" Text="Actualizar" />
                </td>
                <td>
                    <asp:ObjectDataSource ID="ObjModalidad" runat="server" InsertMethod="Insert" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                        TypeName="TiposProc" UpdateMethod="Update">
                        <InsertParameters>
                            <asp:Parameter Name="Cod_Tproc" Type="String" />
                            <asp:Parameter Name="Nom_Tproc" Type="String" />
                            <asp:Parameter Name="Abre_Tproc" Type="String" />
                            <asp:Parameter Name="Esta_Tproc" Type="String" />
                            <asp:Parameter Name="Cod_Ctr" Type="String" />
                            <asp:Parameter Name="Ctr_F20_1A" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Cod_Tproc_O" Type="String" />
                            <asp:Parameter Name="Cod_Tproc" Type="String" />
                            <asp:Parameter Name="Nom_Tproc" Type="String" />
                            <asp:Parameter Name="Abre_Tproc" Type="String" />
                            <asp:Parameter Name="Esta_Tproc" Type="String" />
                            <asp:Parameter Name="Cod_Ctr" Type="String" />
                            <asp:Parameter Name="Ctr_F20_1A" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
     
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="924px">
                    <LocalReport ReportPath="PReportes\PContratos\RptPContMes.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjPCont" Name="DsPCont" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:HiddenField ID="ValFiltro" runat="server" />

                <asp:ObjectDataSource ID="ObjPCont" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecordsRepMes" 
            TypeName="Con_PContratos" InsertMethod="InsertP">
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
                <asp:ControlParameter ControlID="Label1" Name="lstMod" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="TxtF1" Name="fechaI" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="TxtF2" Name="fechaF" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="CboDepP" Name="dep_pcon" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
                <span>
                <asp:ObjectDataSource ID="ObjDepDel" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDelbySoloUser" 
                    TypeName="Dependencias"></asp:ObjectDataSource>
                </span>
<%--            </ContentTemplate>
         
        </asp:UpdatePanel>--%>
        <br />
        
        <br />

     </div>
</asp:Content>