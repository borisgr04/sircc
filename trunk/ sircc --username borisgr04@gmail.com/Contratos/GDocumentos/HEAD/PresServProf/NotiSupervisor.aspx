<%@ Page Language="VB"  MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="NotiSupervisor.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_NotiSupervisor" %>




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
             Doctor <br/>
             <b>{NOM_SUPERVISOR}</b><br />
             <b>{DEP_SUPERVISOR}</b><br />
            E.S.E. Hospital Eduardo Arredondo Daza<br />
            Ciudad
            <br />
            <br />
             Ref. Interventoría Contrato No <b>{NUMERO}.</b>
            <br />
            <br />
            Mediante la presente me permito informa a usted, que ha sido designado como interventor del contrato No <b>{NUMERO}</b>, suscrito con <b>{NOM_CONTRATISTA}</b> cuyo objeto es  {OBJETO}.
            <br />
            <br />
           <b> ACTIVIDADES A DESARROLLAR DURANTE LA EJECUCIÓN DEL CONTRATO: </b>
            <br />
            <br />
            La función de vigilancia y supervisión contractual deberá ser de carácter técnico, económico, administrativo y jurídico.  El interventor tendrá, entre otras, las siguientes funciones generales:
            <br />
            <br />

            <ol>
                <li>Exigir al contratista la ejecución idónea y oportuna del objeto del contrato.</li>
                <li>Llevar el control sobre la ejecución y cumplimiento del objeto contratado, e informar oportunamente y durante el término de ejecución del contrato a la Gerencia y Oficina Jurídica, cualquier situación o irregularidad, deficiente cumplimiento o incumplimiento, con la debida fundamentación a fin de que se impongan los correctivos o sanciones a que haya lugar.</li>
                <li>Emitir concepto técnico y recomendación oportuna a la Administración sobre la conveniencia de prórrogas, plazo y/o duración del contrato. </li>
                <li>Rendir los informes que le sean requeridos por la Administración y aquellos que se hayan estipulado en el contrato. </li>
                <li>Informar y exponer los motivos de que justificadamente proceda una prórroga, modificación, suspensión o adición al contrato, la cual debe estar soportada y dirigida al ordenador del gasto, cuando menos con ocho (8) días hábiles de anticipación al vencimiento del plazo y/o duración del contrato. </li>
                <li>Remitir a la Gerencia y Oficina Jurídica, copia de todas las comunicaciones recibidas y enviadas al contratista y demás documentos producidos en el desarrollo del contrato. </li>
                <li>Velar por que las garantías se mantengan vigentes durante el término del contrato y en los términos pactados para cada uno de los riesgos. </li>
                <li>Emitir las certificaciones respectivas para que se hagan efectivos los pagos al contratista, de conformidad con las obligaciones pactadas. </li>
                <li>Elaborar las actas de liquidación de los contratos y presentarlas al ordenador del gasto para consideración y firma de las partes contratantes. </li>
                <li>Abstenerse de suscribir documentos y dar órdenes verbales al Contratista que modifiquen o alteren las condiciones inicialmente pactadas en el contrato, siendo de competencia de quien suscribe el contrato, para lo cual deberá informar lo pertinente en la Gerencia y Oficina Jurídica, a fin de que se proyecten y tramiten los actos respectivos.  </li>
                <li>Cualquier divergencia que se llegare a presentar entre el Supervisor y la empresa Contratista, deberá ser puesta en conocimiento de quien suscribe el contrato en nombre y presentación de la Entidad a fin de que se dirima por este.</li>
                <li>Exigir que la calidad del servicio contratado se ajusten a los requisitos mínimos previstos en las normas técnicas obligatorias y a las características y especificaciones estipuladas en el contrato. </li>
                <li>Certificar el cumplimiento del Contratista una vez se haya terminado el contrato, y así mismo enviarla a la Oficina Jurídica para su archivo.</li>
             </ol>
            <br />
            <b>TERMINO PARA LIQUIDAR</b>
            <br />
            Tenga presente que los contratos de tracto sucesivo, los que se den por terminado anticipadamente ya sea por voluntad de las partes o por declaratoria de caducidad, deben ser objeto de liquidación.
            <br />
            <br />
            La liquidación contractual deberá realizarse de común acuerdo, dentro del plazo convenido por las partes en el contrato o dentro del término fijado en la Ley.
            <br />
            <br />
            Atentamente,
            <br />
            <br />
            <br />
            
            _______________________________________ <br />
            <b>LEONARDO JOSE MAYA AMAYA</b> <br />
            Gerente <br />

               <p style="font-size:10px"> Anexo: fotocopia simple del contrato</p>
      </asp:Literal>
    </div>
    </form>
</asp:content>
