<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RptDinamico.aspx.vb" Inherits="Reportes_Dinamico_RptDinamico" EnableEventValidation="false" %>

<%@ Register Src="../../CtrlUsr/SelCampos/SelCampos.ascx" TagName="SelCampos" TagPrefix="uc1" %>
<%@ Register Src="../../CtrlUsr/FiltroCon/FiltroCon.ascx" TagName="FiltroCon" TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/FiltroContratos/FiltroContratos.ascx" TagName="FiltroContratos"
    TagPrefix="uc3" %>
<%@ Register src="../../CtrlUsr/SelCampos/SelCamposC.ascx" tagname="SelCamposC" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
  
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="true" >
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Label ID="Tit" runat="server" Text="REPORTE DINAMICO DE CONTRATACION" CssClass="Titulo"></asp:Label>
            <%--<HeaderTemplate>
                <ul id="wizHeader">
                    <asp:Repeater ID="SideBarList" runat="server">
                        <ItemTemplate>
                            <li><a class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>">
                                    <%# Eval("Name")%></a> </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </HeaderTemplate>--%>
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="3">
            <WizardSteps>
                <asp:WizardStep runat="server" title="Paso 1. Seleccion Campos">
                <uc1:SelCampos ID="SelCampos1" runat="server" Vista="VContratosMA" />
                </asp:WizardStep>
                <asp:WizardStep runat="server" title="Paso 2. Filtro" >
                <uc3:FiltroContratos ID="FiltroContratos1" runat="server"  />
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Paso 3. Consolidados">
                    <br />
                    <uc4:SelCamposC ID="SelCamposC1" runat="server" Vista="VContratosMA" />
                    <br />
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep1" StepType="Finish"  runat="server" 
                    title="Paso 4. Generar Reporte">
                    <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" SkinID="SinFormato">
                    </asp:GridView>
                    <br />
                    <br />
                    <asp:Label id="labelTit" runat="server" Text="Generación de Archivo a Excel" class="SubTitulo"></asp:Label>
                    <table>
                        <tr>
                            <td style="width: 128px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 128px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 128px">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" SkinID="MsgResult" 
                                    Text="Presione el Boton Finalizar Para Generar el Archivo en Excel"></asp:Label></td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            
                            &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 128px">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lbConsolidados" runat="server"></asp:Label>
                                 </td>
                            <td>&nbsp;
                                   </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 128px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>

                    <br />
                    <br />
                    
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
</asp:Content>
