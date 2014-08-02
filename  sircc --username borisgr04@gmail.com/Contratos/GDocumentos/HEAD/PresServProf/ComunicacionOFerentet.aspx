<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="ComunicacionOFerentet.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_ComunicacionOFerentet" %>


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
            Señor(a)<br />
            <b>{NOM_CONTRATISTA}</b><br />
           {DIRECCION}<br />
           {TELEFONO}<br />
           Ciudad<br />
            <br />
            <br />

            <table>
            <p  style="text-align: right"><b>REF. ACEPTACIÓN DE LA OFERTA</b></p>
            </table>
            <br />
            <br />
            Comedidamente se le comunica que luego de elaborada el Acta de Verificación Documental por parte de la Subdirección Administrativa de la propuesta presentada por usted, de conformidad a lo dispuesto en el Manual de Procedimientos Contractuales para la adquisición de Bienes y Servicios de la E.S.E. Hospital Eduardo Arredondo Daza, el Subdirector Administrativo verificó que su propuesta cumplió con las exigencias contempladas en la solicitud de oferta,razón por la cual, se le solicita se acerque a las instalaciones de esta institución hospitalaria a suscribir el respectivo contrato, el cual tiene por objeto {OBJETO} por valor de {VALOR_A_CONTRATAR} y un plazo de  {PLAZO}
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
            LEONARDO JOSE MAYA AMAYA <br />
            Gerente <br />

            </asp:Literal>


        </div>



    </form>
</asp:Content>
