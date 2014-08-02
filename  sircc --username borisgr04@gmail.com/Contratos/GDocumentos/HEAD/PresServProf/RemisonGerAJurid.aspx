<%@ Page Language="VB"  MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="RemisonGerAJurid.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_RemisonGerAJurid" %>


<asp:content id="Content1" contentplaceholderid="head" runat="Server">
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
            <p>
            Valledupar, <span id="FechaOficio"></span>
            </p>
            <br />
            <br />
            Doctor<br />
            <b>LEONARDO JOSE MAYA AMAYA</b><br />
            Gerente<br />
            E.S.E. Hospital Eduardo Arredondo Daza<br />
            E.	S.	D.
            <br />
            <br />
            Cordial saludo,
            <br />
            <br />
            Mediante la presente me permito informarle que mediante acta de verificación documental realizada por el suscrito (anexa), se analizó la oferta para  {OBJETO} y se recomienda contratar con <b> {NOM_CONTRATISTA} </b> , por cumplir con las condiciones requeridas por el Hospital.
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            Atentamente,
            <br />
            <br />
            <br />
            <br />
            <br />
            _______________________________________ <br />
           <b> MARIANO SEBASTIAN OJEDA MARTÍNEZ </b><br />
            Subdirector Administrativo <br />
 </asp:Literal>
    </div>
    </form>
</asp:content>
