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
    &nbsp;<br />
    &nbsp;<br />
         <asp:Label ID="Msg" runat="server"></asp:Label>

         <asp:GridView ID="grdOficios" runat="server" EnableModelValidation="True" AutoGenerateColumns="False" DataKeyNames="tip_ofi" Width="100%">
             <Columns>
                 <asp:BoundField DataField="ID" HeaderText="Id" />
                 <asp:BoundField DataField="tip_ofi" HeaderText="Tipo" />
                 <asp:BoundField DataField="nom_ofi" HeaderText="Nombre" />
                 <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
                 <asp:BoundField DataField="FEC_OFI" HeaderText="Fecha Generación" />
                 <asp:CommandField ShowSelectButton="True" />
             </Columns>
         </asp:GridView>

         
         
         </div>
</asp:Content>

