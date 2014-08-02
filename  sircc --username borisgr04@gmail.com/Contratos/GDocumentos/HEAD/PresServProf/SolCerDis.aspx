<%@ Page Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="SolCerDis.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_SolCerDis" %>


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
                <table  style="width:100%">
                <tr >
                       <td  rowspan="2">
                           <img src="../../../../images/2014/LogoHEAD.png" />
                            
                            <%--<img alt="" src="/ashx/ashxImg.ashx" width="60px" height="60px" />--%>
                     </td>  
                    <th rowspan="1">
                        <b>
                        EMPRESA SOCIAL DEL ESTADO <br/>
                        HOSPITAL EDUARDO ARREDONDO DAZA<br />
                        NIT.824.000.725-0<br />
                        </b>
                    </th>
                   
                </tr>
                                
            </table>
            <br />
           
            Valledupar, <span id="FechaOficio"></span> 
            <br />
            <br />
            Doctor<br />
            <b>MARIANO SEBASTIAN OJEDA MARTINEZ</b><br />
            Subdirector Administrativo<br />
            E.S.E. Hospital Eduardo Arredondo Daza<br />
            E.	S.	D.
            <br />
            <br />
            REF.  AUTORIZACIÓN PROCESO CONTRACTUAL.
            <br />
            <br />
            Atento saludo,
            <br />
            <br />
            En atención a la comunicación de fecha {FECHA}, a través de la cual la Subdirectora Científica, solicita autorización para llevar a cabo los trámites administrativos necesarios pertinentes, previos a todo proceso contractual, específicamente para la contratación de la {OBJETO}.; me permito manifestarle que esta Gerencia lo autoriza para que de conformidad con lo estipulado en el Estatuto Único de Contratación de Bienes y Servicios de la ESE-HEAD (Acuerdos Nros 053 y 054 de 2008 y sus modificaciones), proceda a realizar los trámites y procedimientos a que hubiere lugar.
            <br />
            <br />
            Atentamente,
            <br />
            <br />
            <br />
            <br />
            <br />
            LEONARDO JOSÉ MAYA AMAYA <br />
            Gerente ESE-HEAD  <br />
 </asp:Literal>
    </div>
    </form>
</asp:content>
