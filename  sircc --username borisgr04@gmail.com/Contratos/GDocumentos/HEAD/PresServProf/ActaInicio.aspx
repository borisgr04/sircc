<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="ActaInicio.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_ActaInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
<br />
<br />
<br />
<br />
<asp:HiddenField ID="hdNumero" runat="server" />

<div style="text-align: justify" contenteditable="true" class="hoja" id="HojaImpr">

<asp:Literal ID="ltPlantilla" runat="server">
     <table style="  width:100%">
                <tr >
                    <td >
                        <img src="../../../../images/2014/LogoHEAD3.png" width="100" height="50" />
                    </td>
                    <td  style=" border-bottom:1px double #000000; font-size:9px; font-family:Verdana;  width:85%">
                        <b>EMPRESA SOCIAL DEL ESTADO<br />
                            HOSPITAL EDUARDO ARREDONDO DAZA<br />
                            NIT.824.000.725-0<br />
                        </b>
                    </td>
                </tr>
            </table>
            
            <br />
No está dentro de los oficios enviados

            
</asp:Literal>
</div>
</form>
</asp:Content>
