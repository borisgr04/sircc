<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="OficiosGral.aspx.vb" Inherits="Contratos_GDocumentos_OficiosGral" %>
<%@ Register src="../../CtrlUsr/DetContratos/DetContrato.ascx" tagname="DetContrato" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
     <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
  
         <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult"></asp:Label><br />
          <uc2:DetContrato ID="DetContratoN1" runat="server" />
            <br />
            
             
            <asp:ObjectDataSource ID="ObjObli" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                TypeName="CObligaciones">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DetContratoN1" Name="Cod_Con" 
                        PropertyName="Cod_Con" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
    &nbsp;<asp:LinkButton ID="LnkRPC" runat="server" >SOLICITUD   DE   REGISTRO  PRESUPUESTAL DE  COMPROMISOS</asp:LinkButton><br />
    &nbsp;<asp:LinkButton ID="LinkDesSup" runat="server">CARTA DE DESIGNACION DE SUPERVISOR</asp:LinkButton>
         
         
         </div>
</asp:Content>

