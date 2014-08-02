<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="TrasOFerta.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_TrasOFerta" %>

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
            <p>
            Valledupar, <span id="FechaOficio"></span>
            </p>
            <br />
            <br />
            Doctor<br />
            <b>MARIANO SEBASTIAN OJEDA MARTÍNEZ</b><br />
            Subdirector Administrativo<br />
            E.S.E. Hospital Eduardo Arredondo Daza<br />
            E.	S.	D.
            <br />
            <br />
            Atento  saludo:
            <br />
            <br />
            Anexo a la presente, la propuesta presentada por <b>{NOM_CONTRATISTA}</b> que hace parte del proceso para la contratación de la {OBJETO};  con el fin de que se elabore la respectiva acta de verificación documental, la cual es de su competencia.
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
           <b>  OLGA LUCIA RASGO CUELLO <br /></b>
            Secretaria de Gerencia  <br />
    </asp:Literal>
    </div>
    </form>
</asp:content>

