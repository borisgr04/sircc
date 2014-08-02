<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="SolOferta.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_SolOferta" %>

<asp:content id="Content1" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" contentplaceholderid="head" runat="Server">
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
          No estaba en los Oficos enviados

     </asp:Literal>
    </div>
    </form>
</asp:content>
