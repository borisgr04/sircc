<%@ Page Title="" Language="VB" MasterPageFile="~/Contratos/GDocumentos/HEAD/PresServProf/PrestServ.master" AutoEventWireup="false" CodeFile="ECOpor.aspx.vb" Inherits="Contratos_GDocumentos_HEAD_PresServProf_ECOpor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <b>ESTUDIO PREVIO DE CONVENIENCIA Y OPORTUNIDAD PARA LA CONTRATACION DE {OBJETO}</b>
            <br />
            De conformidad con los dispuesto en la Constitución Nacional, Estatuto Único de Contratación de Bienes y Servicios (Acuerdo 053 y 054 y sus modificaciones) de la E.S.E. Hospital Eduardo Arredondo Daza, la Ley 100 de 1993 y demás normas concordantes del ordenamiento jurídico vigente; se procede a evaluar la conveniencia y oportunidad para la contratación de un(una) {CAR_FUN} por lo cual mediante el presente documento se define la necesidad y se analiza la conveniencia y oportunidad para realizar la contratación que a continuación se especifica:<br />
            <br />
            <b>A.	DEFINICIÓN DE LA NECESIDAD QUE LA ENTIDAD PRETENDE SATISFACER</b>
                {NECESIDAD}<br />
            <b> B.	CONDICIONES DEL CONTRATO A CELEBRAR DESCRIPCIÓN DEL OBJETO, ESPECIFICACIONES DEL MISMO Y CONTRATO A CELEBRAR.</b><br />
            <br />
            <b>1.- OBJETO PRINCIPAL: </b>{OBJETO}<br /><br />
            <b>2.   OBLIGACIONES DEL CONTRATO A CELEBRAR: </b> El contratista debe cumplir con las siguientes obligaciones:<br /><br />
            {OBLIGACIONES}<br /><br />
            <b> 3.  SUPERVISIÓN:</b> La interventoria del contrato que resulte del presente proceso de selección, estará a cargo de la Subdirección Científica de la E.S.E. HOSPITAL EDUARDO ARREDONDO DAZA. El supervisor del contrato deberá solicitar al contratista, la información que acredite el pago de las obligaciones con el Sistema Integral de Seguridad Social (ARP, EPS, Pensiones) y Aportes Parafiscales (ICBF, Cajas de Compensación Familiar y SENA) cuando a ello haya lugar.<br /><br />
            <b>4. IDENTIFICACIÓN DEL CONTRATO A CELEBRAR:</b> El contrato que se pretende celebrar es un CONTRATO DE {SUBTIPO_CTO}<br /><br />

            <b>5.  PLAZO DE EJECUCIÓN:</b> El plazo de ejecución del presente contrato será de {PLAZO}, contados a partir del perfeccionamiento del Contrato, esto es, la expedición del Certificado de Registro Presupuestal y la aprobación de la póliza de garantía exigida por este centro hospitalario para amparar el cumplimiento del contrato y la respectiva acta de inicio.<br /><br />

            <b>6. FINANCIACION:</b> El presupuesto del contrato resultante de la adjudicación se hará con recursos propios de la Empresa Social del Estado – Hospital Eduardo Arredondo Daza, por valor de  {VALOR_LETRAS} {VALOR_A_CONTRATAR}<br /><br />

            <b>7. LUGAR DE EJECUCIÓN:</b> El presente contrato se ejecutará en {LUG_EJE}<br /><br />

            <b>8. FORMA DE PAGO:</b> Por la naturaleza del objeto a ejecutar se deberá pactar que dicho valor se le cancelará al contratista de la siguiente manera: Por evento a tarifa SOAT menos el diez por ciento (10%) por mensualidad vencida, previa la presentación de los siguientes documentos:    1) el informe de actividades desarrolladas durante el mes, debidamente soportadas.                 2) certificación de la ejecución del contrato a cabalidad y a satisfacción por parte de la Institución Hospitalaria, expedida por el supervisor del contrato. 3) pago de aportes al sistema de seguridad social integral (Salud, Pensión, Riesgos Profesionales) de acuerdo a como lo establece la normatividad vigente. <br /><br />

            <b>ANALISIS TÉCNICO Y ECONÓMICO QUE SOPORTA EL VALOR ESTIMADO DEL CONTRATO.</b><br /><br />
                
            La Empresa Social del Estado - Hospital Eduardo Arredondo Daza, requiere la {OBJETO}
             <b>   1.	SOPORTE ECONÓMICO - PRECIOS  HISTÓRICOS</b><br /><br />

            Existe en el presupuesto de la EMPRESA SOCIAL DEL ESTADO HOSPITAL EDUARDO ARREDONDO DAZA, los recursos disponibles dentro del rubro HONORARIOS, correspondientes al presupuesto de rentas, gastos e inversiones de la vigencia 2014, para adelantar la contratación del {CAR_FUN}, el cual asume todos los impuestos y demás descuentos que ocasione la legalización del contrato que se celebre.<br /><br />

            La oficina de Subdirección Científica para determinar el soporte económico del contrato a celebrarse, tuvo en cuenta el precio histórico cancelado por el Hospital  por este  concepto  durante  las  vigencias  anteriores,  evidenciándose que en el año 2011, este servicio fue liquidado de acuerdo a los estudios realmente efectuados así: Por evento a tarifa SOAT vigente menos el 10% Colposcopia más Biopsia  por valor de $69.030 y topificaciones a razón de $20.700; para la vigencia 2012, fue contratado este servicio por valor de  QUINCE  MILLONES DE  PESOS M/L ($15.000.000,00), durante cinco (5) meses a razón de ciento veintidós mil setecientos pesos m/l ($122.700,00), por cada uno de los procedimientos realizados, de la misma manera se contrato para la vigencia de 2013; teniendo en cuenta que anteriormente estos servicios se tenían contratado con las ocho EPS-S del municipio de Valledupar se cancelaba la vigencia anterior dicha cuantía por cada  procedimiento, para este año 2014, se disminuye la contratación con las EPS-S por lo tanto se considera hacer el ajuste por un valor de TREINTA MILLONES DE PESOS M/L ($30.000.000,00), por evento a Tarifa SOAT menos el diez por ciento (10%), garantizando la calidad y confiabilidad de los estudios de colposcopia y toma de biopsia a los pacientes del hospital de forma eficaz y eficiente.<br /><br />

            <b>C.	FUNDAMENTOS JURÍDICOS QUE SOPORTAN LA MODALIDAD DE SELECCIÓN.</b><br /><br />

            Tanto el proceso de solicitud de oferta así como el contrato que se suscriba como resultado del mismo, estarán sometidos a la legislación y jurisdicción colombiana y se rige por las normas administrativas, civiles y comerciales que regulan el objeto de la misma, esto es, por el derecho privado, en concordancia con el régimen jurídico de la contratación administrativa, de conformidad con lo previsto en los artículos 194 y 195  de la Ley 100 de 1993, los Acuerdos No. 053 y No. 054 proferidos por la Junta Directiva de esta Empresa Social del Estado – Hospital Eduardo Arredondo Daza, el día 6 de octubre de 2008, por medio de los cuales se adoptó el Estatuto Único de Contratación y el Manual de Procesos y Procedimientos para la adquisición de Bienes y Servicios y el Acuerdo No. 000012 de 2 de octubre de 2012, por medio de los cuales se modifican los artículos 34 y 36 del estatuto Único de Contratación.<br /><br />
Atendiendo el objeto de la contratación y  lo señalado en el Estatuto de Contratación de la Empresa Social del Estado, esta contratación debe llevarse a cabo por el procedimiento de contratación directa. <br /><br />

D.	JUSTIFICACION DE LOS FACTORES QUE PERMITAN IDENTIFICAR LA OFERTA MAS FAVORABLE<br /><br />

Para seleccionar la oferta más favorable para contratar los servicios profesionales de un médico especialista en ginecología para la realización de colposcopia y toma de biopsia, se tendrán en cuenta la idoneidad y experiencia. El contrato será suscrito una vez que el oferente haya presentado la oferta con la mejor relación costo-beneficio y se suscribirá por el precio total ofrecido.<br /><br />


1.   REQUISITOS MINIMOS HABILITANTES<br /><br />

La entidad adjudicará el contrato al oferente al que se le solicite la oferta, siempre y cuando cumpla con los siguientes requisitos mínimos habilitantes, que correspondan a los criterios de selección, los cuales se calificarán con CUMPLE O NO CUMPLE:<br /><br />

<b>REQUISITOS MINIMOS HABILITANTES	CALIFICACIÓN</b><br /><br />
1.1.- Verificación de requisitos jurídicos	Cumple / No cumple
1.2.- Verificación de experiencia	Cumple / No cumple
1.4.- Verificación económica	Cumple / No cumple

La verificación de los requisitos jurídicos habilitantes antes señalados, estará  cargo del Subdirector Administrativo, se realizará verificando los documentos presentados en cumplimiento de los términos y condiciones establecidos en la solicitud de oferta y las disposiciones legales vigentes.  Aspecto que se calificará con CUMPLE O NO CUMPLE.<br /><br />

El oferente demostrará experiencia, mediante el anexo de certificaciones o copia de contratos ejecutados, cuyo objeto sea igual o relacionado con el presente objeto. Aspecto que se calificará con CUMPLE O NO CUMPLE.<br /><br />

En lo que atañe a la parte económica, se verificará que la propuesta presentada por el contratista no supere el presupuesto oficial. Aspecto que se calificará con CUMPLE O NO CUMPLE.<br /><br />

<b>E.	SOPORTE QUE PERMITE LA ESTIMACIÓN, TIPIFICACIÓN Y ASIGNACIÓN DE LOS RIESGOS PREVISIBLES DEL CONTRATO.</b> <br /><br />

Luego de evaluadas las experiencias de contratos anteriores con la misma necesidad por satisfacer, se recomienda tener en cuenta los posibles riesgos o siniestros en que se puede incurrir en la ejecución y en la etapa pos contractual, se estiman, tipifican y asignan como riesgos los siguientes:<br /><br />

<b>1.	CUMPLIMIENTO DEL CONTRATO:</b><br /><br />

Para mitigar este riesgo, el Contratista deberá constituir a favor de la E.S.E. HOSPITAL EDUARDO ARREDONDO DAZA, una póliza que ampare el cumplimiento del objeto contractual, equivalente al diez por ciento (10%) del valor del contrato, y una vigencia igual al término de duración del contrato y cuatro (4) meses más.<br /><br />

<b>2.	CALIDAD DEL SERVICIO</b>,  en cuantía del 10% del valor contrato, y una vigencia igual al término de duración del contrato y cuatro (4) meses más. <br /><br />

Todas las pólizas requeridas deben ser expedidas por una compañía de seguro debidamente autorizada para operar en Colombia por la Superintendencia Bancaria. <br /><br />

F.	CONCLUSIONES <br /><br />

Con la presentación de este estudio, queda evidenciada la existencia de un requerimiento para contratar {OBJETO}, a fin de garantizar un diagnostico y oportuno tratamiento, por consiguiente se aconseja adelantar los procesos contractuales respectivos y su perfeccionamiento.<br /><br />

El presente documento se firma el <span id="FechaOficio"></span>.<br /><br />


____________________________
MAIRA FERNANDA PINTO SANCHEZ
Subdirectora  Científica 

            

     </asp:Literal>
    </div>
    </form>
</asp:Content>

