<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Documentos.aspx.vb" Inherits="Contratos_Documentos_default" %>

<%@ Register src="../../CtrlUsr/CargarDoc/CargarDoc.ascx" tagname="CargarDoc" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/DetContratos/DetContrato.ascx" tagname="DetContrato" tagprefix="uc2" %>
<%@ Register src="../../CtrlUsr/ConDocContratos/ConDocContratos.ascx" tagname="ConDocContratos" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>

    <uc2:DetContrato ID="DetContrato1" runat="server" />
    <br />
    <hr/>
    <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="-1"
            HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContentByA" FadeTransitions="true" FramesPerSecond="40" 
            TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
           <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPaneConDoc" runat="server">
                <Header><a href="" class="accordionLink"> Listado de Documentos Cargados ...</a></Header>
                <Content>
                <uc3:ConDocContratos ID="ConDocContratos1" runat="server" />
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header><a href="" class="accordionLink"> Documento N° 1 ...</a></Header>
                <Content>
                <uc1:CargarDoc ID="CargarDoc1" runat="server" />
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header><a href="" class="accordionLink"> Documento N° 2 ...</a></Header>
                <Content>
                <uc1:CargarDoc ID="CargarDoc2" runat="server" />
                </Content>
            </ajaxToolkit:AccordionPane>        
            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header><a href="" class="accordionLink"> Documento N° 3 ... </a></Header>
                <Content>
                <uc1:CargarDoc ID="CargarDoc3" runat="server" />
                </Content>
            </ajaxToolkit:AccordionPane>        
            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header><a href="" class="accordionLink"> Documento N° 4 ... </a></Header>
                <Content>
                <uc1:CargarDoc ID="CargarDoc4" runat="server" />
                </Content>
            </ajaxToolkit:AccordionPane>        
            <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                <Header><a href="" class="accordionLink"> Documento N° 5 ... </a></Header>
                <Content>
                <uc1:CargarDoc ID="CargarDoc5" runat="server" />
                </Content>
            </ajaxToolkit:AccordionPane>        
            </Panes>
        </ajaxToolkit:Accordion>

        <center>
        <br />
         <asp:Button ID="BtnDoc" runat="server" Text="Subir Documentos" />
        <br />
        </center>
</div>
</asp:Content>

