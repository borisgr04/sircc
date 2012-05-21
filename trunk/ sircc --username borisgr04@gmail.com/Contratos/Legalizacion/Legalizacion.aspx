<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Legalizacion.aspx.vb" Inherits="Contratos_Legalizacion_Default" %>

<%@ Register src="../../CtrlUsr/DetContratos/DetContrato.ascx" tagname="DetContrato" tagprefix="uc1" %>

<%@ Register src="../../CtrlUsr/grdRP/grdRP.ascx" tagname="grdRP" tagprefix="uc2" %>

<%@ Register src="../../CtrlUsr/grdImpC/grdImpC.ascx" tagname="grdImpC" tagprefix="uc3" %>

<%@ Register src="../../CtrlUsr/ExImpC/ExImpC.ascx" tagname="ExImpC" tagprefix="uc4" %>

<%@ Register src="../../CtrlUsr/grdPolC/grdPolC.ascx" tagname="grdPolC" tagprefix="uc5" %>

<%@ Register src="../../CtrlUsr/grdIntC/grdIntC.ascx" tagname="grdIntC" tagprefix="uc6" %>

<%@ Register src="../../CtrlUsr/grdLegC/grdLegC.ascx" tagname="grdLegC" tagprefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <style type="text/css">
    .cuadro
    {
        padding: 10px 20px 20px 20px; margin: 0px; border: 0.5pt solid #9FBFDF;
        }
</style>
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
    
<div class="demoarea">
    
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <uc1:DetContrato ID="DetContrato1" runat="server" AceptarClicked="DetContrato1_AceptarClicked" />
        <br /><br />
        <asp:Label ID="MsgResult" runat="server"></asp:Label>
        <br /><br />
        <ajaxToolkit:Accordion ID="Accordion1" runat="server" SelectedIndex="-1"
            HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContentByA" FadeTransitions="true" FramesPerSecond="40" 
            TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
        <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
            <Header><a href="" class="accordionLink"> 1. REGISTRO PRESUPUESTAL </a></Header>
           <Content>
           <div style="padding: 10px 20px 20px 20px; margin: 0px; border: 0.5pt solid #9FBFDF;">
        <asp:Label runat="server" Text="REGISTRO PRESUPUESTAL" ID="LABEL10" CssClass="Titulo"></asp:Label><br /><br />
        <uc2:grdRP ID="grdRP1" runat="server" />
        </div>
           </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
            <Header><a href="" class="accordionLink"> 2. POLIZAS DE GARANTIA </a></Header>
           <Content>
           <div class="cuadro">
        <asp:Label runat="server" Text="POLIZAS DE GARANTIA" ID="LABEL1" CssClass="Titulo"></asp:Label>  <br />
        <uc5:grdPolC ID="grdPolC1" runat="server" />
        </div>
           </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
            <Header><a href="" class="accordionLink"> 3. IMPUESTOS </a></Header>
           <Content>
           <div class="cuadro">
        <asp:Label runat="server" Text="IMPUESTOS" ID="LABEL2" CssClass="Titulo"></asp:Label>          <br /><br />
        <uc3:grdImpC ID="grdImpC1" runat="server" />            
        </div>
           </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
            <Header><a href="" class="accordionLink"> 4. EXONERACION DE IMPUESTOS </a></Header>
           <Content>
           <div class="cuadro">
        <asp:Label runat="server" Text="EXONERACION DE IMPUESTOS" ID="LABEL3" CssClass="Titulo"></asp:Label>   <br /><br />
        <uc4:ExImpC ID="ExImpC1" runat="server" />
        </div>
           </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
            <Header><a href="" class="accordionLink"> 5. INTERVENTORIA/SUPERVISIÓN </a></Header>
           <Content>
           <div class="cuadro">
        <asp:Label runat="server" Text="INTERVENTORIA/SUPERVISIÓN" ID="LABEL4" CssClass="Titulo"></asp:Label>        <br /><br />
        <uc6:grdIntC ID="grdIntC1" runat="server" />
        </div>
           </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server">
            <Header><a href="" class="accordionLink"> 6. CONFIRMAR LEGALIZACION </a></Header>
           <Content>
          <div class="cuadro">
        <asp:Label runat="server" Text="CONFIRMAR LEGALIZACION" ID="LABEL5" CssClass="Titulo"></asp:Label>                  <br /><br />
        <uc7:grdLegC ID="grdLegC1" runat="server" />
        </div>
           </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
        </ajaxToolkit:Accordion>
        <br />
</ContentTemplate></asp:UpdatePanel>
</div>
 <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                AssociatedUpdatePanelID="UpdatePanel1">
                <progresstemplate>
                    <div class="Loading">
                        <asp:Image ID="ImgAjax" runat="server" SkinID="ImgProgress" />
                        Cargando …
                    </div>
                </progresstemplate>
            </asp:UpdateProgress>
</asp:Content>

