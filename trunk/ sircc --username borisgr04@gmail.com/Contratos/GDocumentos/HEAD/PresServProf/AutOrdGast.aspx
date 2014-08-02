<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="AutOrdGast.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_AutOrdGast" %>
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
                <b>MARIANO SEBASTIAN OJEDA MARTINEZ</b><br />
                Subdirector Administrativo<br />
                E.S.E. Hospital Eduardo Arredondo Daza<br />
                E.	S.	D.
                <br />
                <br />
                <p style=" text-align:right;  "> REF.  AUTORIZACIÓN PROCESO CONTRACTUAL. </p>
                <br />
                <br />
                Atento saludo,
                <br />
                <br />
                En atención al comunicado a través del cual la Subdirectora Científica, solicita autorización para llevar a cabo los trámites administrativos pertinentes, previos a todo proceso contractual, específicamente para la contratación de la {OBJETO}.; me permito manifestarle que esta Gerencia lo autoriza para que de conformidad con lo estipulado en el Estatuto Único de Contratación de Bienes y Servicios de la ESE-HEAD (Acuerdos Nros 053 y 054 de 2008 y sus modificaciones), proceda a realizar los trámites y procedimientos a que hubiere lugar.
                <br />
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
                LEONARDO JOSÉ MAYA AMAYA
                <br />
                Gerente ESE-HEAD 
                <br />
            </asp:Literal>
        </div>
    </form>      
</asp:content>

                                         