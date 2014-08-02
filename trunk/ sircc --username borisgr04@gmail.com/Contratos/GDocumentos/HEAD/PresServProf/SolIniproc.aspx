<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="SolIniproc.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_SolIniproc" %>

<asp:content id="Content1" contentplaceholderid="head" runat="Server">
<style type="text/css"> 
@media print {
thead { display: table-header-group; }
tfoot { display: table-footer-group; }
}
@media screen {
thead { display: block; }
tfoot { display: block; }
}
 
</style>
</asp:content>

<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="Server">
<form id="form1" runat="server">
<br />
<br />
<br />
<br />
<asp:HiddenField ID="hdNumero" runat="server" />

<div style="text-align: justify" contenteditable="true" class="hoja" id="HojaImpr">

<asp:Literal ID="ltPlantilla" runat="server">
Por Implementar...

            
</asp:Literal>
</div>
</form>
</asp:content>
