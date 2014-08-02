<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="CertTalHum.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_CertTalHum" %>


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
            REF.  CERTIFICACIÓN
            <br />
            <br />
            Atento  saludo:
            <br />
            <br />
             En atención a la solicitud realizada, en mi condición de profesional especializado a cargo de la oficina de Recursos Humanos, hago constar que dentro de la planta de cargos de esta institución hospitalaria no se cuenta con el perfil de un profesional para la {OBJETO}
            <br />
            <br />
            La anterior certificación se expide en los términos del artículo 3 del Decreto 1737 del 21 de agosto de 1998, modificado por el artículo 1 del Decreto 2209 del 29 de octubre de 1998, por el cual se expiden medidas de austeridad y eficiencia y se someten a condiciones especiales la asunción de compromisos por parte de las entidades públicas que manejan recursos del Tesoro Público.
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
            YIMMY  SILVA CASTRILLON <br />
            Profesional Especializado Recursos Humanos  <br />

            </asp:Literal>


        </div>

    </form>
</asp:Content>
