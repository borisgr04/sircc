<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RptDinamico.aspx.vb" Inherits="Reportes_Dinamico_RptDinamico" EnableEventValidation="false" %>

<%@ Register Src="../../CtrlUsr/SelCampos/SelCampos.ascx" TagName="SelCampos" TagPrefix="uc1" %>
<%@ Register Src="../../CtrlUsr/FiltroCon/FiltroCon.ascx" TagName="FiltroCon" TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/FiltroContratos/FiltroContratos.ascx" TagName="FiltroContratos"
    TagPrefix="uc3" %>
<%@ Register src="../../CtrlUsr/SelCampos/SelCamposC.ascx" tagname="SelCamposC" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <%--<style>
        #wizHeader li .prevStep
        {
            background-color: #669966;
        }
        #wizHeader li .prevStep:after
        {
            border-left-color: #669966 !important;
        }
        #wizHeader li .currentStep
        {
            background-color: #C36615;
        }
        #wizHeader li .currentStep:after
        {
            border-left-color: #C36615 !important;
        }
        #wizHeader li .nextStep
        {
            background-color: #C2C2C2;
        }
        #wizHeader li .nextStep:after
        {
            border-left-color: #C2C2C2 !important;
        }
        #wizHeader
        {
            list-style: none;
            overflow: hidden;
            font: 18px Helvetica, Arial, Sans-Serif;
            margin: 0px;
            padding: 0px;
        }
        #wizHeader li
        {
            float: left;
        }
        #wizHeader li a
        {
            color: white;
            text-decoration: none;
            padding: 10px 0 10px 55px;
            background: brown; /* fallback color */
            background: hsla(34,85%,35%,1);
            position: relative;
            display: block;
            float: left;
        }
        #wizHeader li a:after
        {
            content: " ";
            display: block;
            width: 0;
            height: 0;
            border-top: 50px solid transparent; /* Go big on the size, and let overflow hide */
            border-bottom: 50px solid transparent;
            border-left: 30px solid hsla(34,85%,35%,1);
            position: absolute;
            top: 50%;
            margin-top: -50px;
            left: 100%;
            z-index: 2;
        }
        #wizHeader li a:before
        {
            content: " ";
            display: block;
            width: 0;
            height: 0;
            border-top: 50px solid transparent;
            border-bottom: 50px solid transparent;
            border-left: 30px solid white;
            position: absolute;
            top: 50%;
            margin-top: -50px;
            margin-left: 1px;
            left: 100%;
            z-index: 1;
        }
        #wizHeader li:first-child a
        {
            padding-left: 10px;
        }
        #wizHeader li:last-child
        {
            padding-right: 50px;
        }
        #wizHeader li a:hover
        {
            background: #FE9400;
        }
        #wizHeader li a:hover:after
        {
            border-left-color: #FE9400 !important;
        }
        .content
        {
            height: 150px;
            padding-top: 75px;
            text-align: center;
            background-color: #F9F9F9;
            font-size: 48px;
        }
    </style>--%>
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
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0">
            <WizardSteps>
                <asp:WizardStep runat="server" title="Paso 1. Seleccion Campos">
                <uc1:SelCampos ID="SelCampos1" runat="server" Vista="VCONTRATOS_SINC_P" />
                </asp:WizardStep>
                <asp:WizardStep runat="server" title="Paso 2. Filtro" >
                <uc3:FiltroContratos ID="FiltroContratos1" runat="server"  />
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Paso 3. Consolidados">
                    <br />
                    <uc4:SelCamposC ID="SelCamposC1" runat="server" Vista="VCONTRATOS_SINC_P" />
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
